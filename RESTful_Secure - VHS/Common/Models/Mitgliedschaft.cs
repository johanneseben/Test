using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Mitgliedschaft
    {
        public virtual int MitgliedschaftID { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual double Mitgliedsbeitrag { get; set; }
        public virtual double Ermaessigung { get; set; }

        public Mitgliedschaft()
        {
           
        }
    }
}
