using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Kursleiter
    {
        public virtual int KursleiterID { get; set; }
        public virtual Kontakt KontaktID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }

        public Kursleiter()
        {
            this.Kontakt1 = new HashSet<Kontakt>();
        }
    }
}
