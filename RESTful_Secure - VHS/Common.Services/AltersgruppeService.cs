using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class AltersgruppeService : BaseService
    {
        public AltersgruppeService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Altersgruppe> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Altersgruppe)).List<Altersgruppe>();
        }

        public Altersgruppe Get(int id)
        {
            return CurrentSession.Get<Altersgruppe>(id);
        }

        public Altersgruppe Add(Altersgruppe altersgruppe)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (altersgruppe.AltersgruppeID > 0)
                    {
                        throw new Exception(String.Format("A Altersgruppe with Bid {0} already exists. To update please use PUT.",altersgruppe.AltersgruppeID));
                    }
                    CurrentSession.Save(altersgruppe);
                    tran.Commit();

                    return altersgruppe;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Altersgruppe Update(Altersgruppe altersgruppe)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (altersgruppe.AltersgruppeID == 0)
                    {
                        throw new Exception("For creating a Altersgruppe please use POST");
                    }
                    CurrentSession.Update(altersgruppe);
                    tran.Commit();

                    return altersgruppe;
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
                    var altersgruppe = Get(id);
                    if (altersgruppe != null)
                    {
                        CurrentSession.Delete(altersgruppe);
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
