using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class SozialgruppeMap : ClassMap<Sozialgruppe>
    {
        public SozialgruppeMap()
        {
            Id(x => x.SozialgruppeID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Unique().Not.Nullable();
        }
    }
}
