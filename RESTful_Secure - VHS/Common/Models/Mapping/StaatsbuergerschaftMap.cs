using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class StaatsbuergerschaftMap : ClassMap<Staatsbuergerschaft>
    {
        public StaatsbuergerschaftMap()
        {
            Id(x => x.StaatsbuergerschaftID).GeneratedBy.HiLo("10");
            Map(x => x.Staat).Not.Nullable();
        }
    }
}
