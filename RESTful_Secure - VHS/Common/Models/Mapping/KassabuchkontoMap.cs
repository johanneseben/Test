using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KassabuchkontoMap : ClassMap<Kassabuchkonto>
    {
        public KassabuchkontoMap()
        {
            Id(x => x.KassabuchkontoID).GeneratedBy.HiLo("10");
            Map(x => x.Kontonummer).Not.Nullable();
            Map(x => x.Kontobezeichnung).Not.Nullable();
            Map(x => x.Kontostand).Not.Nullable();
        }
    }
}
