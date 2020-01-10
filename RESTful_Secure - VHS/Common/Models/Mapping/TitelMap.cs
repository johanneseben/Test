using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class TitelMap : ClassMap<Titel>
    {
        public TitelMap()
        {
            Id(x => x.TitelID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
            Map(x => x.Vorgestellt);
        }
    }
}
