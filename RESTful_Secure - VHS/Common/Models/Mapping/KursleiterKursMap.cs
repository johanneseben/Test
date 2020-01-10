using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KursleiterKursMap : ClassMap<KursleiterKurs>
    {
        public KursleiterKursMap()
        {
            Id(x => x.KursleiterKursID).GeneratedBy.HiLo("10");
            Map(x => x.Honorar).Not.Nullable();
            Map(x => x.Zulage);
            References(x => x.KursleiterID).Column("KursleiterID").Not.Nullable().Not.LazyLoad();
            References(x => x.KursID).Column("KursID").Not.Nullable().Not.LazyLoad();
        }
    }
}
