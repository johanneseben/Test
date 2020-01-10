using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KursleiterService : BaseService
    {
        public KursleiterService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kursleiter> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kursleiter)).List<Kursleiter>();
        }

        public Kursleiter Get(int id)
        {
            return CurrentSession.Get<Kursleiter>(id);
        }

        public Kursleiter Add(Kursleiter kursleiter)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kursleiter.KursleiterID > 0)
                    {
                        throw new Exception(String.Format("A Kursleiter with Bid {0} already exists. To update please use PUT.",kursleiter.KursleiterID));
                    }
                    CurrentSession.Save(kursleiter);
                    tran.Commit();

                    return kursleiter;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kursleiter Update(Kursleiter kursleiter)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kursleiter.KursleiterID == 0)
                    {
                        throw new Exception("For creating a Kursleiter please use POST");
                    }
                    CurrentSession.Update(kursleiter);
                    tran.Commit();

                    return kursleiter;
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
                    var kursleiter = Get(id);
                    if (kursleiter != null)
                    {
                        CurrentSession.Delete(kursleiter);
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
