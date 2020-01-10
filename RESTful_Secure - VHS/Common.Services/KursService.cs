using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KursService : BaseService
    {
        public KursService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kurs> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kurs)).List<Kurs>();
        }

        public Kurs Get(int id)
        {
            return CurrentSession.Get<Kurs>(id);
        }

        public Kurs Add(Kurs kurs)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kurs.KursID > 0)
                    {
                        throw new Exception(String.Format("A Kurs with Bid {0} already exists. To update please use PUT.",kurs.KursID));
                    }
                    CurrentSession.Save(kurs);
                    tran.Commit();

                    return kurs;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kurs Update(Kurs kurs)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kurs.KursID == 0)
                    {
                        throw new Exception("For creating a Kurs please use POST");
                    }
                    CurrentSession.Update(kurs);
                    tran.Commit();

                    return kurs;
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
                    var kurs = Get(id);
                    if (kurs != null)
                    {
                        CurrentSession.Delete(kurs);
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
