using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KursMap : ClassMap<Kurs>
    {
        public KursMap()
        {
            Id(x => x.KursID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
            Map(x => x.Preis).Not.Nullable();
            Map(x => x.MinTeilnehmer).Not.Nullable();
            Map(x => x.MaxTeilnehmer).Not.Nullable();
            Map(x => x.AnzEinheiten).Not.Nullable();
            Map(x => x.Verbindlichkeit).Not.Nullable();
            Map(x => x.Foerderung).Not.Nullable();
            Map(x => x.Status).Not.Nullable();
            Map(x => x.Beschreibung).Not.Nullable();
            Map(x => x.ZeitVon).Not.Nullable();
            Map(x => x.ZeitBis).Not.Nullable();
            Map(x => x.DatumVon).Not.Nullable();
            Map(x => x.DatumBis).Not.Nullable();
            Map(x => x.Seminarnummer).Unique().Not.Nullable();
            References(x => x.KurskategorieID).Column("KurskategorieID").Not.Nullable().Not.LazyLoad();
            References(x => x.KursortID).Column("KursortID").Not.Nullable().Not.LazyLoad();
            Map(x => x.Anmeldeschluss);
            Map(x => x.Anmerkung);

        }
    }
}
