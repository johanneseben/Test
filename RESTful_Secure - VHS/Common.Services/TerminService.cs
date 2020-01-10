using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class TerminService : BaseService
    {
        public TerminService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Termin> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Termin)).List<Termin>();
        }

        public Termin Get(int id)
        {
            return CurrentSession.Get<Termin>(id);
        }

        public Termin Add(Termin termin)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (termin.TerminID > 0)
                    {
                        throw new Exception(String.Format("A Termin with Bid {0} already exists. To update please use PUT.",termin.TerminID));
                    }
                    CurrentSession.Save(termin);
                    tran.Commit();

                    return termin;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Termin Update(Termin termin)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (termin.TerminID == 0)
                    {
                        throw new Exception("For creating a Termin please use POST");
                    }
                    CurrentSession.Update(termin);
                    tran.Commit();

                    return termin;
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
                    var termin = Get(id);
                    if (termin != null)
                    {
                        CurrentSession.Delete(termin);
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
