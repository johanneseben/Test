using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class RechnungService : BaseService
    {
        public RechnungService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Rechnung> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Rechnung)).List<Rechnung>();
        }

        public Rechnung Get(int id)
        {
            return CurrentSession.Get<Rechnung>(id);
        }

        public Rechnung Add(Rechnung rechnung)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (rechnung.RechnungID > 0)
                    {
                        throw new Exception(String.Format("A Rechnung with Bid {0} already exists. To update please use PUT.",rechnung.RechnungID));
                    }
                    CurrentSession.Save(rechnung);
                    tran.Commit();

                    return rechnung;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Rechnung Update(Rechnung rechnung)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (rechnung.RechnungID == 0)
                    {
                        throw new Exception("For creating a Rechnung please use POST");
                    }
                    CurrentSession.Update(rechnung);
                    tran.Commit();

                    return rechnung;
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
                    var rechnung = Get(id);
                    if (rechnung != null)
                    {
                        CurrentSession.Delete(rechnung);
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
