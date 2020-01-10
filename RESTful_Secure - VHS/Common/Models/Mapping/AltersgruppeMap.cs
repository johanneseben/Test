using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class AltersgruppeMap : ClassMap<Altersgruppe>
    {
        public AltersgruppeMap()
        {
            Id(x => x.AltersgruppeID).GeneratedBy.HiLo("10");
            Map(x => x.Bezeichnung).Unique().Not.Nullable();
        }
    }
}
