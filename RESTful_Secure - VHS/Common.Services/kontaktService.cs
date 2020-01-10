using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KontaktService : BaseService
    {
        public KontaktService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kontakt> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kontakt)).List<Kontakt>();
        }

        public Kontakt Get(int id)
        {
            return CurrentSession.Get<Kontakt>(id);
        }

        public Kontakt Add(Kontakt kontakt)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kontakt.KontaktID > 0)
                    {
                        throw new Exception(String.Format("A Kontakt with Bid {0} already exists. To update please use PUT.",kontakt.KontaktID));
                    }
                    CurrentSession.Save(kontakt);
                    tran.Commit();

                    return kontakt;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kontakt Update(Kontakt kontakt)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kontakt.KontaktID == 0)
                    {
                        throw new Exception("For creating a Kontakt please use POST");
                    }
                    CurrentSession.Update(kontakt);
                    tran.Commit();

                    return kontakt;
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
                    var kontakt = Get(id);
                    if (kontakt != null)
                    {
                        CurrentSession.Delete(kontakt);
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
