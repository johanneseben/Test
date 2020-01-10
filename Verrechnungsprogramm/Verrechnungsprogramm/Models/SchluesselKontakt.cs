using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class SchluesselKontakt
    {
        public virtual int SchluesselKontaktID { get; set; }
        public virtual Schluessel SchluesselID { get; set; }
        public virtual Kontakt KontaktID { get; set; }
        public virtual string Herausgeber { get; set; }
        public virtual DateTime AusgabeAm { get; set; }
        public virtual DateTime RetourAm { get; set; }
        public virtual int Frist { get; set; }
        public virtual double Einsatz { get; set; }
        public virtual bool Verlust { get; set; }

        [JsonIgnore]
        public virtual ICollection<Schluessel> Schluessel1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }


        public SchluesselKontakt()
        {
            this.Schluessel1 = new HashSet<Schluessel>();
            this.Kontakt1 = new HashSet<Kontakt>();
        }
    }
}
