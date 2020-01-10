using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KurskategorieMap : ClassMap<Kurskategorie>
    {
        public KurskategorieMap()
        {
            Id(x => x.KurskategorieID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
        }
    }
}
