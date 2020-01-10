using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class MitgliedschaftKontaktService : BaseService
    {
        public MitgliedschaftKontaktService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<MitgliedschaftKontakt> Get()
        {
            return CurrentSession.CreateCriteria(typeof(MitgliedschaftKontakt)).List<MitgliedschaftKontakt>();
        }

        public MitgliedschaftKontakt Get(int id)
        {
            return CurrentSession.Get<MitgliedschaftKontakt>(id);
        }

        public MitgliedschaftKontakt Add(MitgliedschaftKontakt mitgliedschaftKontakt)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (mitgliedschaftKontakt.MitgliedschaftKontaktID > 0)
                    {
                        throw new Exception(String.Format("A MitgliedschaftKontakt with Bid {0} already exists. To update please use PUT.",mitgliedschaftKontakt.MitgliedschaftKontaktID));
                    }
                    CurrentSession.Save(mitgliedschaftKontakt);
                    tran.Commit();

                    return mitgliedschaftKontakt;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public MitgliedschaftKontakt Update(MitgliedschaftKontakt mitgliedschaftKontakt)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (mitgliedschaftKontakt.MitgliedschaftKontaktID == 0)
                    {
                        throw new Exception("For creating a MitgliedschaftKontakt please use POST");
                    }
                    CurrentSession.Update(mitgliedschaftKontakt);
                    tran.Commit();

                    return mitgliedschaftKontakt;
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
                    var mitgliedschaftKontakt = Get(id);
                    if (mitgliedschaftKontakt != null)
                    {
                        CurrentSession.Delete(mitgliedschaftKontakt);
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
