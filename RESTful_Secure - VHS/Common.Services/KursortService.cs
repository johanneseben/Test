using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KursortService : BaseService
    {
        public KursortService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kursort> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kursort)).List<Kursort>();
        }

        public Kursort Get(int id)
        {
            return CurrentSession.Get<Kursort>(id);
        }

        public Kursort Add(Kursort kursort)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kursort.KursortID > 0)
                    {
                        throw new Exception(String.Format("A Kursort with Bid {0} already exists. To update please use PUT.",kursort.KursortID));
                    }
                    CurrentSession.Save(kursort);
                    tran.Commit();

                    return kursort;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kursort Update(Kursort kursort)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kursort.KursortID == 0)
                    {
                        throw new Exception("For creating a Kursort please use POST");
                    }
                    CurrentSession.Update(kursort);
                    tran.Commit();

                    return kursort;
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
                    var kursort = Get(id);
                    if (kursort != null)
                    {
                        CurrentSession.Delete(kursort);
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
