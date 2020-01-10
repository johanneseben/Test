using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Pass
    {
        public virtual int PassID { get; set; }
        public virtual Kontakt KontaktID { get; set; }
        public virtual string PassNr { get; set; }
        public virtual DateTime PassBeginn { get; set; }
        public virtual DateTime PassEnde { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }

        public Pass()
        {
            this.Kontakt1 = new HashSet<Kontakt>();
        }
    }
}
