using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class KursleiterMap : ClassMap<Kursleiter>
    {
        public KursleiterMap()
        {
            Id(x => x.KursleiterID).GeneratedBy.HiLo("10");
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
        }
    }
}
