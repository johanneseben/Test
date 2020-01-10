using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class GutscheinService : BaseService
    {
        public GutscheinService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Gutschein> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Gutschein)).List<Gutschein>();
        }

        public Gutschein Get(int id)
        {
            return CurrentSession.Get<Gutschein>(id);
        }

        public Gutschein Add(Gutschein gutschein)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (gutschein.GutscheinID > 0)
                    {
                        throw new Exception(String.Format("A Gutschein with Bid {0} already exists. To update please use PUT.",gutschein.GutscheinID));
                    }
                    CurrentSession.Save(gutschein);
                    tran.Commit();

                    return gutschein;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Gutschein Update(Gutschein gutschein)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (gutschein.GutscheinID == 0)
                    {
                        throw new Exception("For creating a Gutschein please use POST");
                    }
                    CurrentSession.Update(gutschein);
                    tran.Commit();

                    return gutschein;
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
                    var gutschein = Get(id);
                    if (gutschein != null)
                    {
                        CurrentSession.Delete(gutschein);
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
