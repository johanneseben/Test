using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class SchluesselKontaktService : BaseService
    {
        public SchluesselKontaktService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<SchluesselKontakt> Get()
        {
            return CurrentSession.CreateCriteria(typeof(SchluesselKontakt)).List<SchluesselKontakt>();
        }

        public SchluesselKontakt Get(int id)
        {
            return CurrentSession.Get<SchluesselKontakt>(id);
        }

        public SchluesselKontakt Add(SchluesselKontakt schluesselKontakt)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (schluesselKontakt.SchluesselKontaktID > 0)
                    {
                        throw new Exception(String.Format("A SchluesselKontakt with Bid {0} already exists. To update please use PUT.",schluesselKontakt.SchluesselKontaktID));
                    }
                    CurrentSession.Save(schluesselKontakt);
                    tran.Commit();

                    return schluesselKontakt;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public SchluesselKontakt Update(SchluesselKontakt schluesselKontakt)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (schluesselKontakt.SchluesselKontaktID == 0)
                    {
                        throw new Exception("For creating a SchluesselKontakt please use POST");
                    }
                    CurrentSession.Update(schluesselKontakt);
                    tran.Commit();

                    return schluesselKontakt;
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
                    var schluesselKontakt = Get(id);
                    if (schluesselKontakt != null)
                    {
                        CurrentSession.Delete(schluesselKontakt);
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
