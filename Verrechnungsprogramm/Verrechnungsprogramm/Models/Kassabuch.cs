using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Kassabuch
    {
        public virtual int KassabuchID { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string Buchungstext { get; set; }
        public virtual double Betrag { get; set; }
        public virtual Kontakt KontaktID { get; set; }
        public virtual Kassabuchkonto KassabuchkontoID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kassabuchkonto> Kassabuchkonto1 { get; set; }

        public Kassabuch()
        {
            this.Kontakt1 = new HashSet<Kontakt>();
            this.Kassabuchkonto1 = new HashSet<Kassabuchkonto>();
        }
    }
}
