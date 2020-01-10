using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Common.Models
{
    public class Benutzer
    {
        public virtual int BenutzerID { get; set; }
        public virtual string Benutzername { get; set; }
        public virtual string Passwort { get; set; }

        public Benutzer()
        {

        }
    }
}
