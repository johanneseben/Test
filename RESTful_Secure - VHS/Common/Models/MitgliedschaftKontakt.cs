using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class MitgliedschaftKontakt
    {
        public virtual int MitgliedschaftKontaktID { get; set; }
        public virtual int Kalenderjahr { get; set; }
        public virtual Mitgliedschaft MitgliedschaftID { get; set; }
        public virtual Kontakt KontaktID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Mitgliedschaft> Mitgliedschaft1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }

        public MitgliedschaftKontakt()
        {
            this.Mitgliedschaft1 = new HashSet<Mitgliedschaft>();
            this.Kontakt1 = new HashSet<Kontakt>();
        }
    }
}
