using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Kontakt
    {
        public virtual int KontaktID { get; set; }
        public virtual Titel TitelID { get; set; }
        public virtual string Vorname { get; set; }
        public virtual string Nachname { get; set; }
        public virtual string SVNr { get; set; }
        public virtual string Geschlecht { get; set; }
        public virtual string Familienstand { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefonnummer { get; set; }
        public virtual string Strasse { get; set; }
        public virtual Postleitzahl PostleitzahlID { get; set; }
        public virtual Altersgruppe AltersgruppeID { get; set; }
        public virtual Sozialgruppe SozialgruppeID { get; set; }
        public virtual Staatsbuergerschaft StaatsbuergerschaftID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Postleitzahl> Postleitzahl1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Altersgruppe> Altersgruppe1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sozialgruppe> Sozialgruppe1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Staatsbuergerschaft> Staatsbuergerschaft1 { get; set; }

        public Kontakt()
        {
            this.Postleitzahl1 = new HashSet<Postleitzahl>();
            this.Altersgruppe1 = new HashSet<Altersgruppe>();
            this.Sozialgruppe1 = new HashSet<Sozialgruppe>();
            this.Staatsbuergerschaft1 = new HashSet<Staatsbuergerschaft>();
        }
    }
}
