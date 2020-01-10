using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KassabuchMap : ClassMap<Kassabuch>
    {
        public KassabuchMap()
        {
            Id(x => x.KassabuchID).GeneratedBy.HiLo("10");
            Map(x => x.Datum).Not.Nullable();
            Map(x => x.Buchungstext).Not.Nullable();
            Map(x => x.Betrag).Not.Nullable();
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
            References(x => x.KassabuchkontoID).Column("KassabuchkontoID").Not.Nullable().Not.LazyLoad();
        }
    }
}
