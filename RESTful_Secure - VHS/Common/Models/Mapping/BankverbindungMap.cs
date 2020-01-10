using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class BankverbindungMap : ClassMap<Bankverbindung>
    {
        public BankverbindungMap()
        {
            Id(x => x.BankverbindungID).GeneratedBy.HiLo("10");
            Map(x => x.IBAN).Not.Nullable();
            Map(x => x.Kontoinhaber).Not.Nullable();
            References(x => x.KontaktID).Column("KontatkID").Not.Nullable().Not.LazyLoad();
        }
    }
}
