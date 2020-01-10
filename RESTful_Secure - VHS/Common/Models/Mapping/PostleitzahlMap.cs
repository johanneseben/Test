using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class PostleitzahlMap : ClassMap<Postleitzahl>
    {
        public PostleitzahlMap()
        {
            Id(x => x.PostleitzahlID).GeneratedBy.HiLo("10");
            Map(x => x.Plz).Not.Nullable();
            Map(x => x.Ort).Not.Nullable();
        }
    }
}
