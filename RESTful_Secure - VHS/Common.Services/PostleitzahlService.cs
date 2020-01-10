using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class PostleitzahlService : BaseService
    {
        public PostleitzahlService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Postleitzahl> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Postleitzahl)).List<Postleitzahl>();
        }

        public Postleitzahl Get(int id)
        {
            return CurrentSession.Get<Postleitzahl>(id);
        }

        public Postleitzahl Add(Postleitzahl postleitzahl)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (postleitzahl.PostleitzahlID > 0)
                    {
                        throw new Exception(String.Format("A Postleitzahl with Bid {0} already exists. To update please use PUT.",postleitzahl.PostleitzahlID));
                    }
                    CurrentSession.Save(postleitzahl);
                    tran.Commit();

                    return postleitzahl;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Postleitzahl Update(Postleitzahl postleitzahl)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (postleitzahl.PostleitzahlID == 0)
                    {
                        throw new Exception("For creating a Postleitzahl please use POST");
                    }
                    CurrentSession.Update(postleitzahl);
                    tran.Commit();

                    return postleitzahl;
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
                    var postleitzahl = Get(id);
                    if (postleitzahl != null)
                    {
                        CurrentSession.Delete(postleitzahl);
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
