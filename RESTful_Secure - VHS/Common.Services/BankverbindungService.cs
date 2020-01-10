using Common.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace Common.Services
{
    public class BankverbindungService : BaseService
    {
        public BankverbindungService(Func<ISession> session)
            : base(session)
        {
        }

        public IList<Bankverbindung> Get()
        {
            return CurrentSession.CreateCriteria(typeof(Bankverbindung)).List<Bankverbindung>();
        }

        public Bankverbindung Get(int id)
        {
            return CurrentSession.Get<Bankverbindung>(id);
        }

        public Bankverbindung Add(Bankverbindung bankverbindung)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (bankverbindung.BankverbindungID > 0)
                    {
                        throw new Exception(String.Format("A Bankverbindung with Bid {0} already exists. To update please use PUT.",bankverbindung.BankverbindungID));
                    }
                    CurrentSession.Save(bankverbindung);
                    tran.Commit();

                    return bankverbindung;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public Bankverbindung Update(Bankverbindung bankverbindung)
        {
            using (var tran = CurrentSession.BeginTransaction())
            {
                try
                {
                    if (bankverbindung.BankverbindungID == 0)
                    {
                        throw new Exception("For creating a Bankverbindung please use POST");
                    }
                    CurrentSession.Update(bankverbindung);
                    tran.Commit();

                    return bankverbindung;
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
                    var bankverbindung = Get(id);
                    if (bankverbindung != null)
                    {
                        CurrentSession.Delete(bankverbindung);
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
