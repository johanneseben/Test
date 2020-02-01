using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KontaktKursMap : ClassMap<KontaktKurs>
    {
        public KontaktKursMap()
        {
            Id(x => x.KontaktKursID).GeneratedBy.HiLo("10");
            //Map(x => x.Teilnahmebestaetigung);
            //Map(x => x.TeilnahmebestaetigungDatum);
            Map(x => x.Buchungsdatum);
            Map(x => x.Bonus);
            Map(x => x.Bezahlt);
            References(x => x.KontakID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
            References(x => x.KursID).Column("KursID").Not.Nullable().Not.LazyLoad();

        }
    }
}
