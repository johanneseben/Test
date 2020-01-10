using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Schluessel
    {
        public virtual int SchluesselID { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual string Code { get; set; }
        public virtual string Platz { get; set; }
        public virtual string Anmerkung { get; set; }
        public virtual bool Aktiv { get; set; }



        public Schluessel()
        {
           
        }
    }
}
