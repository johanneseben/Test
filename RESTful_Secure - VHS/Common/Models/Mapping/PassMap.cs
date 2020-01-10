using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class PassMap : ClassMap<Pass>
    {
        public PassMap()
        {
            Id(x => x.PassID).GeneratedBy.HiLo("10");
            References(x => x.KontaktID).Column("KontaktID").Not.Nullable().Not.LazyLoad();
            Map(x => x.PassNr).Not.Nullable();
            Map(x => x.PassBeginn).Not.Nullable();
            Map(x => x.PassEnde).Not.Nullable();

        }
    }
}
