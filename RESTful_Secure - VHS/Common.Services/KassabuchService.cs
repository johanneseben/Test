using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KassabuchService : BaseService
    {
        public KassabuchService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kassabuch> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kassabuch)).List<Kassabuch>();
        }

        public Kassabuch Get(int id)
        {
            return CurrentSession.Get<Kassabuch>(id);
        }

        public Kassabuch Add(Kassabuch kassabuch)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kassabuch.KassabuchID > 0)
                    {
                        throw new Exception(String.Format("A Kassabuch with Bid {0} already exists. To update please use PUT.",kassabuch.KassabuchID));
                    }
                    CurrentSession.Save(kassabuch);
                    tran.Commit();

                    return kassabuch;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kassabuch Update(Kassabuch kassabuch)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kassabuch.KassabuchID == 0)
                    {
                        throw new Exception("For creating a Kassabuch please use POST");
                    }
                    CurrentSession.Update(kassabuch);
                    tran.Commit();

                    return kassabuch;
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
                    var kassabuch = Get(id);
                    if (kassabuch != null)
                    {
                        CurrentSession.Delete(kassabuch);
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
