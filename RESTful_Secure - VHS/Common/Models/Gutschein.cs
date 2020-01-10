using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Gutschein
    {
        public virtual int GutscheinID { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual double Betrag { get; set; }

        public Gutschein()
        {
           
        }
    }
}
