using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Postleitzahl
    {
        public virtual int PostleitzahlID { get; set; }
        public virtual string Plz { get; set; }
        public virtual string Ort { get; set; }

        public Postleitzahl()
        {
           
        }
    }
}
