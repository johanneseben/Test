using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class KursleiterKurs
    {
        public virtual int KursleiterKursID { get; set; }
        public virtual double Honorar { get; set; }
        public virtual double Zulage { get; set; }
        public virtual Kursleiter KursleiterID { get; set; }
        public virtual Kurs KursID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kursleiter> Kursleiter1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kurs> Kurs1 { get; set; }

        public KursleiterKurs()
        {
            this.Kurs1 = new HashSet<Kurs>();
            this.Kursleiter1 = new HashSet<Kursleiter>();
        }
    }
}
