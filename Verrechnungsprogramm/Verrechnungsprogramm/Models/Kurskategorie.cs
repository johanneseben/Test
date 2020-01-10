using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Kurskategorie
    {
        public virtual int KurskategorieID { get; set; }
        public virtual string Bezeichnung { get; set; }

        public Kurskategorie()
        {

        }
    }
}
