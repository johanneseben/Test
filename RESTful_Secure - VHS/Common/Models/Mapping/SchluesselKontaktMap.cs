using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class SchluesselKontaktMap : ClassMap<SchluesselKontakt>
    {
        public SchluesselKontaktMap()
        {
            Id(x => x.SchluesselKontaktID).GeneratedBy.HiLo("10");
            References(x => x.SchluesselID).Column("SchluesselID").Not.Nullable().Not.LazyLoad();
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
            Map(x => x.Herausgeber).Not.Nullable();
            Map(x => x.AusgabeAm).Not.Nullable();
            Map(x => x.RetourAm);
            Map(x => x.Frist);
            Map(x => x.Einsatz);
            Map(x => x.Verlust).Not.Nullable(); 

        }
    }
}
