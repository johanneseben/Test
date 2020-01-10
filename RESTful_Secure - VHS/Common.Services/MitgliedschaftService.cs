using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class MitgliedschaftService : BaseService
    {
        public MitgliedschaftService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Mitgliedschaft> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Mitgliedschaft)).List<Mitgliedschaft>();
        }

        public Mitgliedschaft Get(int id)
        {
            return CurrentSession.Get<Mitgliedschaft>(id);
        }

        public Mitgliedschaft Add(Mitgliedschaft mitgliedschaft)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (mitgliedschaft.MitgliedschaftID > 0)
                    {
                        throw new Exception(String.Format("A Mitgliedschaft with Bid {0} already exists. To update please use PUT.",mitgliedschaft.MitgliedschaftID));
                    }
                    CurrentSession.Save(mitgliedschaft);
                    tran.Commit();

                    return mitgliedschaft;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Mitgliedschaft Update(Mitgliedschaft mitgliedschaft)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (mitgliedschaft.MitgliedschaftID == 0)
                    {
                        throw new Exception("For creating a Mitgliedschaft please use POST");
                    }
                    CurrentSession.Update(mitgliedschaft);
                    tran.Commit();

                    return mitgliedschaft;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    var mitgliedschaft = Get(id);
                    if (mitgliedschaft != null)
                    {
                        CurrentSession.Delete(mitgliedschaft);
                        tran.Commit();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }


    }
}
