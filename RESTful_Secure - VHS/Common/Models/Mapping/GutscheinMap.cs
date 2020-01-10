using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class GutscheinMap : ClassMap<Gutschein>
    {
        public GutscheinMap()
        {
            Id(x => x.GutscheinID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
            Map(x => x.Betrag).Not.Nullable();
        }
    }
}
