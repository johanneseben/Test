using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Mapping
{
    public class BenutzerMap : ClassMap<Benutzer>
    {
        public BenutzerMap()
        {
            Id(x => x.BenutzerID).GeneratedBy.HiLo("10");
            Map(x => x.Benutzername).Not.Nullable();
            Map(x => x.Passwort).Not.Nullable();
        }
    }
}
