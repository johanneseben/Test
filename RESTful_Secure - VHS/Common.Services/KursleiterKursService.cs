using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KursleiterKursService : BaseService
    {
        public KursleiterKursService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<KursleiterKurs> Get()
        {
            return CurrentSession.CreateCriteria(typeof(KursleiterKurs)).List<KursleiterKurs>();
        }

        public KursleiterKurs Get(int id)
        {
            return CurrentSession.Get<KursleiterKurs>(id);
        }

        public KursleiterKurs Add(KursleiterKurs kursleiterKurs)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kursleiterKurs.KursleiterKursID > 0)
                    {
                        throw new Exception(String.Format("A KursleiterKurs with Bid {0} already exists. To update please use PUT.",kursleiterKurs.KursleiterKursID));
                    }
                    CurrentSession.Save(kursleiterKurs);
                    tran.Commit();

                    return kursleiterKurs;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public KursleiterKurs Update(KursleiterKurs kursleiterKurs)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kursleiterKurs.KursleiterKursID == 0)
                    {
                        throw new Exception("For creating a KursleiterKurs please use POST");
                    }
                    CurrentSession.Update(kursleiterKurs);
                    tran.Commit();

                    return kursleiterKurs;
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
                    var kursleiterKurs = Get(id);
                    if (kursleiterKurs != null)
                    {
                        CurrentSession.Delete(kursleiterKurs);
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
