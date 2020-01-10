using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Termin
    {
        public virtual int TerminID { get; set; }
        public virtual DateTime TerminDatum { get; set; }
        public virtual DateTime TerminBeginn { get; set; }
        public virtual DateTime TerminEnde  { get; set; }
        public virtual string TerminBetreff { get; set; }
        public virtual string TerminZusatz { get; set; }
        public virtual string TerminIntern { get; set; }
        public virtual Kurs KursID { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kurs> Kurs1 { get; set; }

        public Termin()
        {
           this.Kurs1 = new HashSet<Kurs>();
        }
    }
}
