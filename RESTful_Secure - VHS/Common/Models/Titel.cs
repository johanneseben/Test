using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Titel
    {
        public virtual int TitelID { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual bool Vorgestellt { get; set; }


        public Titel()
        {
           
        }
    }
}
