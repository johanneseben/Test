using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Kurs
    {
        public virtual int KursID { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual double Preis { get; set; }
        public virtual int MinTeilnehmer { get; set; }
        public virtual int MaxTeilnehmer { get; set; }
        public virtual int AnzEinheiten { get; set; }
        public virtual bool Verbindlichkeit { get; set; }
        public virtual string Foerderung { get; set; }
        public virtual string Status { get; set; }
        public virtual string Beschreibung { get; set; }
        public virtual DateTime ZeitVon { get; set; }
        public virtual DateTime ZeitBis { get; set; }
        public virtual DateTime DatumVon { get; set; }
        public virtual DateTime DatumBis { get; set; }
        public virtual string Seminarnummer { get; set; }
        public virtual Kurskategorie KurskategorieID { get; set; }
        public virtual Kursort KursortID { get; set; }
        public virtual DateTime Anmeldeschluss { get; set; }
        public virtual string Anmerkung { get; set; }
        public virtual bool Anzeigen { get; set; }

        [JsonIgnore]
        public virtual ICollection<Kurskategorie> Kurskategorie1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kursort> Kursort1 { get; set; }


        public Kurs()
        {
            this.Kurskategorie1 = new HashSet<Kurskategorie>();
            this.Kursort1 = new HashSet<Kursort>();
        }
    }
}
