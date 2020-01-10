using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class SozialgruppeService : BaseService
    {
        public SozialgruppeService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Sozialgruppe> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Sozialgruppe)).List<Sozialgruppe>();
        }

        public Sozialgruppe Get(int id)
        {
            return CurrentSession.Get<Sozialgruppe>(id);
        }

        public Sozialgruppe Add(Sozialgruppe sozialgruppe)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (sozialgruppe.SozialgruppeID > 0)
                    {
                        throw new Exception(String.Format("A Sozialgruppe with Bid {0} already exists. To update please use PUT.",sozialgruppe.SozialgruppeID));
                    }
                    CurrentSession.Save(sozialgruppe);
                    tran.Commit();

                    return sozialgruppe;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Sozialgruppe Update(Sozialgruppe sozialgruppe)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (sozialgruppe.SozialgruppeID == 0)
                    {
                        throw new Exception("For creating a Sozialgruppe please use POST");
                    }
                    CurrentSession.Update(sozialgruppe);
                    tran.Commit();

                    return sozialgruppe;
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
                    var sozialgruppe = Get(id);
                    if (sozialgruppe != null)
                    {
                        CurrentSession.Delete(sozialgruppe);
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
