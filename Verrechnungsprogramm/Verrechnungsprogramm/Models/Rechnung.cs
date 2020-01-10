using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Rechnung
    {
        public virtual int RechnungID { get; set; }
        public virtual string Rechnungsnummer { get; set; }
        public virtual DateTime Rechnungsdatum { get; set; }
        public virtual Kontakt KontaktID { get; set; }
        public virtual Kurs KursID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kurs> Kurs1 { get; set; }

        public Rechnung()
        {
            this.Kontakt1 = new HashSet<Kontakt>();
            this.Kurs1 = new HashSet<Kurs>();
        }
    }
}
