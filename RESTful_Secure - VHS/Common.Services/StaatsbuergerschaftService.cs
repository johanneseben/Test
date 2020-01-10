using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class StaatsbuergerschaftService : BaseService
    {
        public StaatsbuergerschaftService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Staatsbuergerschaft> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Staatsbuergerschaft)).List<Staatsbuergerschaft>();
        }

        public Staatsbuergerschaft Get(int id)
        {
            return CurrentSession.Get<Staatsbuergerschaft>(id);
        }

        public Staatsbuergerschaft Add(Staatsbuergerschaft staatsbuergerschaft)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (staatsbuergerschaft.StaatsbuergerschaftID > 0)
                    {
                        throw new Exception(String.Format("A Staatsbuergerschaft with Bid {0} already exists. To update please use PUT.",staatsbuergerschaft.StaatsbuergerschaftID));
                    }
                    CurrentSession.Save(staatsbuergerschaft);
                    tran.Commit();

                    return staatsbuergerschaft;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Staatsbuergerschaft Update(Staatsbuergerschaft staatsbuergerschaft)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (staatsbuergerschaft.StaatsbuergerschaftID == 0)
                    {
                        throw new Exception("For creating a Staatsbuergerschaft please use POST");
                    }
                    CurrentSession.Update(staatsbuergerschaft);
                    tran.Commit();

                    return staatsbuergerschaft;
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
                    var staatsbuergerschaft = Get(id);
                    if (staatsbuergerschaft != null)
                    {
                        CurrentSession.Delete(staatsbuergerschaft);
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
