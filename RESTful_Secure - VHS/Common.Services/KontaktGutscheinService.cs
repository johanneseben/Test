using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KontaktGutscheinService : BaseService
    {
        public KontaktGutscheinService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<KontaktGutschein> Get()
        {
            return CurrentSession.CreateCriteria(typeof(KontaktGutschein)).List<KontaktGutschein>();
        }

        public KontaktGutschein Get(int id)
        {
            return CurrentSession.Get<KontaktGutschein>(id);
        }

        public KontaktGutschein Add(KontaktGutschein kontaktGutschein)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kontaktGutschein.KontaktGutscheinID > 0)
                    {
                        throw new Exception(String.Format("A KontaktGutschein with Bid {0} already exists. To update please use PUT.",kontaktGutschein.KontaktGutscheinID));
                    }
                    CurrentSession.Save(kontaktGutschein);
                    tran.Commit();

                    return kontaktGutschein;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public KontaktGutschein Update(KontaktGutschein kontaktGutschein)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kontaktGutschein.KontaktGutscheinID == 0)
                    {
                        throw new Exception("For creating a KontaktGutschein please use POST");
                    }
                    CurrentSession.Update(kontaktGutschein);
                    tran.Commit();

                    return kontaktGutschein;
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
                    var kontaktGutschein = Get(id);
                    if (kontaktGutschein != null)
                    {
                        CurrentSession.Delete(kontaktGutschein);
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
