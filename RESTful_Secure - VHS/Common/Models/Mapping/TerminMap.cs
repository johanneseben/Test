using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class TerminMap : ClassMap<Termin>
    {
        public TerminMap()
        {
            Id(x => x.TerminID).GeneratedBy.HiLo("10");
            Map(x => x.TerminDatum).Not.Nullable();
            Map(x => x.TerminBeginn).Not.Nullable();
            Map(x => x.TerminEnde).Not.Nullable();
            Map(x => x.TerminBetreff);
            Map(x => x.TerminZusatz);
            Map(x => x.TerminIntern);
            References(x => x.KursID).Column("KursID").Not.Nullable().Not.LazyLoad();
            
        }
    }
}
