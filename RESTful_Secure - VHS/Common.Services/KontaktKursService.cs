using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KontaktKursService : BaseService
    {
        public KontaktKursService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<KontaktKurs> Get()
        {
            return CurrentSession.CreateCriteria(typeof(KontaktKurs)).List<KontaktKurs>();
        }

        public KontaktKurs Get(int id)
        {
            return CurrentSession.Get<KontaktKurs>(id);
        }

        public KontaktKurs Add(KontaktKurs kontaktKurs)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kontaktKurs.KontaktKursID > 0)
                    {
                        throw new Exception(String.Format("A KontaktKurs with Bid {0} already exists. To update please use PUT.",kontaktKurs.KontaktKursID));
                    }
                    CurrentSession.Save(kontaktKurs);
                    tran.Commit();

                    return kontaktKurs;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public KontaktKurs Update(KontaktKurs kontaktKurs)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kontaktKurs.KontaktKursID == 0)
                    {
                        throw new Exception("For creating a KontaktKurs please use POST");
                    }
                    CurrentSession.Update(kontaktKurs);
                    tran.Commit();

                    return kontaktKurs;
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
                    var kontaktKurs = Get(id);
                    if (kontaktKurs != null)
                    {
                        CurrentSession.Delete(kontaktKurs);
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
