using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class MitgliedschaftMap : ClassMap<Mitgliedschaft>
    {
        public MitgliedschaftMap()
        {
            Id(x => x.MitgliedschaftID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
            Map(x => x.Mitgliedsbeitrag).Not.Nullable();
            Map(x => x.Ermaessigung).Not.Nullable();
            
        }
    }
}
