using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class MitgliedschaftKontaktMap : ClassMap<MitgliedschaftKontakt>
    {
        public MitgliedschaftKontaktMap()
        {
            Id(x => x.MitgliedschaftKontaktID).GeneratedBy.HiLo("10");
            Map(x => x.Kalenderjahr).Not.Nullable();
            References(x => x.MitgliedschaftID).Column("MitgliedschaftID").Not.Nullable().Not.LazyLoad();
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
        }
    }
}
