using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KassabuchkontoService : BaseService
    {
        public KassabuchkontoService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kassabuchkonto> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kassabuchkonto)).List<Kassabuchkonto>();
        }

        public Kassabuchkonto Get(int id)
        {
            return CurrentSession.Get<Kassabuchkonto>(id);
        }

        public Kassabuchkonto Add(Kassabuchkonto kassabuchkonto)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kassabuchkonto.KassabuchkontoID > 0)
                    {
                        throw new Exception(String.Format("A Kassabuchkonto with Bid {0} already exists. To update please use PUT.",kassabuchkonto.KassabuchkontoID));
                    }
                    CurrentSession.Save(kassabuchkonto);
                    tran.Commit();

                    return kassabuchkonto;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kassabuchkonto Update(Kassabuchkonto kassabuchkonto)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kassabuchkonto.KassabuchkontoID == 0)
                    {
                        throw new Exception("For creating a Kassabuchkonto please use POST");
                    }
                    CurrentSession.Update(kassabuchkonto);
                    tran.Commit();

                    return kassabuchkonto;
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
                    var kassabuchkonto = Get(id);
                    if (kassabuchkonto != null)
                    {
                        CurrentSession.Delete(kassabuchkonto);
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
