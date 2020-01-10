using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Bankverbindung
    {
        public virtual int BankverbindungID { get; set; }
        public virtual string IBAN { get; set; }
        public virtual string Kontoinhaber { get; set; }
        public virtual Kontakt KontaktID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }

        public Bankverbindung()
        {
            this.Kontakt1 = new HashSet<Kontakt>();
        }
    }
}
