using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Kassabuchkonto
    {
        public virtual int KassabuchkontoID { get; set; }
        public virtual string Kontonummer { get; set; }
        public virtual string Kontobezeichnung { get; set; }
        public virtual double Kontostand { get; set; }

        public Kassabuchkonto()
        {
           
        }
    }
}
