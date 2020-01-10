using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class KurskategorieService : BaseService
    {
        public KurskategorieService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Kurskategorie> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Kurskategorie)).List<Kurskategorie>();
        }

        public Kurskategorie Get(int id)
        {
            return CurrentSession.Get<Kurskategorie>(id);
        }

        public Kurskategorie Add(Kurskategorie kurskategorie)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kurskategorie.KurskategorieID > 0)
                    {
                        throw new Exception(String.Format("A Kurskategorie with Bid {0} already exists. To update please use PUT.",kurskategorie.KurskategorieID));
                    }
                    CurrentSession.Save(kurskategorie);
                    tran.Commit();

                    return kurskategorie;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Kurskategorie Update(Kurskategorie kurskategorie)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (kurskategorie.KurskategorieID == 0)
                    {
                        throw new Exception("For creating a Kurskategorie please use POST");
                    }
                    CurrentSession.Update(kurskategorie);
                    tran.Commit();

                    return kurskategorie;
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
                    var kurskategorie = Get(id);
                    if (kurskategorie != null)
                    {
                        CurrentSession.Delete(kurskategorie);
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
