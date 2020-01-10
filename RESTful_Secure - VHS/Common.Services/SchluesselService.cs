using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class SchluesselService : BaseService
    {
        public SchluesselService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Schluessel> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Schluessel)).List<Schluessel>();
        }

        public Schluessel Get(int id)
        {
            return CurrentSession.Get<Schluessel>(id);
        }

        public Schluessel Add(Schluessel schluessel)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (schluessel.SchluesselID > 0)
                    {
                        throw new Exception(String.Format("A Schluessel with Bid {0} already exists. To update please use PUT.",schluessel.SchluesselID));
                    }
                    CurrentSession.Save(schluessel);
                    tran.Commit();

                    return schluessel;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Schluessel Update(Schluessel schluessel)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (schluessel.SchluesselID == 0)
                    {
                        throw new Exception("For creating a Schluessel please use POST");
                    }
                    CurrentSession.Update(schluessel);
                    tran.Commit();

                    return schluessel;
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
                    var schluessel = Get(id);
                    if (schluessel != null)
                    {
                        CurrentSession.Delete(schluessel);
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
