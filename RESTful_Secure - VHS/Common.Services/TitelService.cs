using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class TitelService : BaseService
    {
        public TitelService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Titel> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Titel)).List<Titel>();
        }

        public Titel Get(int id)
        {
            return CurrentSession.Get<Titel>(id);
        }

        public Titel Add(Titel titel)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (titel.TitelID > 0)
                    {
                        throw new Exception(String.Format("A Titel with Bid {0} already exists. To update please use PUT.",titel.TitelID));
                    }
                    CurrentSession.Save(titel);
                    tran.Commit();

                    return titel;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Titel Update(Titel titel)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (titel.TitelID == 0)
                    {
                        throw new Exception("For creating a Titel please use POST");
                    }
                    CurrentSession.Update(titel);
                    tran.Commit();

                    return titel;
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
                    var titel = Get(id);
                    if (titel != null)
                    {
                        CurrentSession.Delete(titel);
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
