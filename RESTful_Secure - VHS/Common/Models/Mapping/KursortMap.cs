using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KursortMap : ClassMap<Kursort>
    {
        public KursortMap()
        {
            Id(x => x.KursortID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Not.Nullable();
            Map(x => x.Beschreibung).Not.Nullable();
            Map(x => x.Strasse).Not.Nullable();
            References(x => x.PostleitzahlID).Column("PostleitzahlID").Not.Nullable().Not.LazyLoad();

        }
    }
}
