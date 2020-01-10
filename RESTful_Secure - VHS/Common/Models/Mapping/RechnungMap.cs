using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class RechnungMap : ClassMap<Rechnung>
    {
        public RechnungMap()
        {
            Id(x => x.RechnungID).GeneratedBy.HiLo("10");
            Map(x => x.Rechnungsnummer).Not.Nullable();
            Map(x => x.Rechnungsdatum).Not.Nullable();
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
            References(x => x.KursID).Column("KursID").Not.Nullable().Not.LazyLoad();
        }
    }
}
