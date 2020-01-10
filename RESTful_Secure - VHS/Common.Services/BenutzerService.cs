using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class BenutzerService : BaseService
    {
        public BenutzerService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Benutzer> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Benutzer)).List<Benutzer>();
        }

        public Benutzer Get(int id)
        {
            return CurrentSession.Get<Benutzer>(id);
        }

        public Benutzer Add(Benutzer benutzer)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (benutzer.BenutzerID > 0)
                    {
                        throw new Exception(String.Format("A Benutzer with Bid {0} already exists. To update please use PUT.",benutzer.BenutzerID));
                    }
                    CurrentSession.Save(benutzer);
                    tran.Commit();

                    return benutzer;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Benutzer Update(Benutzer benutzer)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (benutzer.BenutzerID == 0)
                    {
                        throw new Exception("For creating a Benutzer please use POST");
                    }
                    CurrentSession.Update(benutzer);
                    tran.Commit();

                    return benutzer;
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
                    var benutzer = Get(id);
                    if (benutzer != null)
                    {
                        CurrentSession.Delete(benutzer);
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
