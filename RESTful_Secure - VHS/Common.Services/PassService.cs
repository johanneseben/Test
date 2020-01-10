using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class PassService : BaseService
    {
        public PassService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Pass> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Pass)).List<Pass>();
        }

        public Pass Get(int id)
        {
            return CurrentSession.Get<Pass>(id);
        }

        public Pass Add(Pass pass)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (pass.PassID > 0)
                    {
                        throw new Exception(String.Format("A Pass with Bid {0} already exists. To update please use PUT.",pass.PassID));
                    }
                    CurrentSession.Save(pass);
                    tran.Commit();

                    return pass;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Pass Update(Pass pass)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (pass.PassID == 0)
                    {
                        throw new Exception("For creating a Pass please use POST");
                    }
                    CurrentSession.Update(pass);
                    tran.Commit();

                    return pass;
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
                    var pass = Get(id);
                    if (pass != null)
                    {
                        CurrentSession.Delete(pass);
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
