using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class SchluesselMap : ClassMap<Schluessel>
    {
        public SchluesselMap()
        {
            Id(x => x.SchluesselID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
            Map(x => x.Code).Not.Nullable();
            Map(x => x.Platz).Not.Nullable();
            Map(x => x.Anmerkung);
            Map(x => x.Aktiv).Not.Nullable();

        }
    }
}
