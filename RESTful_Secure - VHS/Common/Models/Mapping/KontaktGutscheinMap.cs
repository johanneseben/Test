using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KontaktGutscheinMap : ClassMap<KontaktGutschein>
    {
        public KontaktGutscheinMap()
        {
            Id(x => x.KontaktGutscheinID).GeneratedBy.HiLo("10");
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
            References(x => x.GutscheinID).Column("GutscheinID").Not.Nullable().Not.LazyLoad();
            Map(x => x.GetilgtAm).Not.Nullable();
            Map(x => x.GetilgtBei).Not.Nullable();
            Map(x => x.Betrag).Not.Nullable();
        }
    }
}
