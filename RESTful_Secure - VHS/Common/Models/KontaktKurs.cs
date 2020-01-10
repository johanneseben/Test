using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class KontaktKurs
    {
        public virtual int KontaktKursID { get; set; }
        public virtual bool Teilnahmebestaetigung { get; set; }
        public virtual DateTime TeilnahmebestaetigungDatum { get; set; }
        public virtual DateTime Buchungsdatum { get; set; }
        public virtual bool Bezahlt { get; set; }
        public virtual Kontakt KontakID { get; set; }
        public virtual Kurs KursID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kurs> Kurs1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kontakt> Kontakt1 { get; set; }

        public KontaktKurs()
        {
            this.Kurs1 = new HashSet<Kurs>();
            this.Kontakt1 = new HashSet<Kontakt>();
        }
    }
}
