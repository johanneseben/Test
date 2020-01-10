using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public abstract class BaseService
    {
        private readonly Func<ISession> _lazySession;
        private ISession _session;

        protected BaseService(Func<ISession> session)
        {
            _lazySession = session;
        }

        public ISession CurrentSession
        {
            get { return _session ?? (_session = _lazySession()); }
        }
    }
}
