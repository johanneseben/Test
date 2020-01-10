using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KontaktMap : ClassMap<Kontakt>
    {
        public KontaktMap()
        {
            Id(x => x.KontaktID).GeneratedBy.HiLo("10");
            References(x => x.TitelID).Column("TitelID").Not.LazyLoad();
            Map(x => x.Vorname).Not.Nullable();
            Map(x => x.Nachname).Not.Nullable();
            Map(x => x.SVNr);
            Map(x => x.Geschlecht);
            Map(x => x.Familienstand);
            Map(x => x.Email);
            Map(x => x.Telefonnummer).Not.Nullable();
            Map(x => x.Strasse).Not.Nullable();
            References(x => x.PostleitzahlID).Column("PostleitzahlID").Not.Nullable().Not.LazyLoad();
            References(x => x.AltersgruppeID).Column("AltersgruppeID").Not.Nullable().Not.LazyLoad();
            References(x => x.SozialgruppeID).Column("SozialgruppeID").Not.Nullable().Not.LazyLoad();
            References(x => x.StaatsbuergerschaftID).Column("StaatsbuergerschaftID").Not.Nullable().Not.LazyLoad();
        }
    }
}
