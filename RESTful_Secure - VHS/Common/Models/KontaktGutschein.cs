using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class KontaktGutschein
    {
        public virtual int KontaktGutscheinID { get; set; }
        public virtual Kontakt KontaktID { get; set; }
        public virtual Gutschein GutscheinID { get; set; }
        public virtual DateTime GetilgtAm { get; set; }
        public virtual string GetilgtBei { get; set; }
        public virtual double Betrag { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Gutschein> Gutschein1 { get; set; }

        public KontaktGutschein()
        {
            this.Kontakt1 = new HashSet<Kontakt>();
            this.Gutschein1 = new HashSet<Gutschein>();
        }
    }
}
