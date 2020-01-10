namespace Api
{
    using Common.Models;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using Nancy;
    using Nancy.TinyIoc;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;
    using System;
    using Common;
    using Nancy.Bootstrapper;
    using Nancy.Authentication.Basic;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly ISessionFactory _sessionFactory;

        public Bootstrapper()
        {
            _sessionFactory = CreateSessionFactory();

            //Book b = new Book();
            //b.Author = "Hansi";
            //b.InventoryNumber = "B1";
            //b.Title = "Servus";
            //b.Lended = false;

            //User u = new User();
            //u.Email = "test@gmx.at";
            //u.Username = "test";



            //Lending l = new Lending();
            //l.DateOfLend = DateTime.Now;
            //l.User = u;
            //l.Book = b;

            Postleitzahl postleitzahl = new Postleitzahl();
            postleitzahl.Plz = "2223";
            postleitzahl.Ort = "Hohenruppersdorf";

            Titel titel = new Titel();
            titel.Bezeichnung = "Dr.";
            titel.Vorgestellt = true;

            Kursort kursort = new Kursort();
            kursort.Bezeichnung = "Raum1";
            kursort.Beschreibung = "erste Tür rechts";
            kursort.Strasse = "Brennerweg 8";
            kursort.PostleitzahlID = postleitzahl;

            Kurskategorie kurskategorie = new Kurskategorie();
            kurskategorie.Bezeichnung = "Reise";

            Kurs kurs = new Kurs();
            kurs.Bezeichnung = "Bez";
            kurs.Preis = 23.34;
            kurs.MinTeilnehmer = 1;
            kurs.MaxTeilnehmer = 4;
            kurs.AnzEinheiten = 4;
            kurs.Verbindlichkeit = true;
            kurs.Foerderung = "NÖ-Bildungsförderung";
            kurs.Status = "kommt zustande";
            kurs.Beschreibung = "Bei diesem Kurs können Sie das Kochen lernen!";
            kurs.ZeitVon = DateTime.Now;
            kurs.ZeitBis = DateTime.Now;
            kurs.DatumVon = DateTime.Now;
            kurs.DatumBis = DateTime.Now;
            kurs.Seminarnummer = "23EG43";
            kurs.KurskategorieID = kurskategorie;
            kurs.KursortID = kursort;
            kurs.Anmeldeschluss = DateTime.Now;
            kurs.Anmerkung = "des passt";

            Termin termin = new Termin();
            termin.TerminDatum = DateTime.Now;
            termin.TerminBeginn = DateTime.Now;
            termin.TerminEnde = DateTime.Now;
            termin.TerminBetreff = "betreff";
            termin.TerminZusatz = "zusatz";
            termin.TerminIntern = "intern";
            termin.KursID = kurs;

            Altersgruppe altersgruppe = new Altersgruppe();
            altersgruppe.Bezeichnung = "zwischen 14 und 18";

            Sozialgruppe sozialgruppe = new Sozialgruppe();
            sozialgruppe.Bezeichnung = "Schüler";

            Staatsbuergerschaft staatsbuergerschaft = new Staatsbuergerschaft();
            staatsbuergerschaft.Staat = "Österreich";

            Kontakt kontakt = new Kontakt();
            kontakt.TitelID = titel;
            kontakt.Vorname = "Franz";
            kontakt.Nachname = "Kautz";
            kontakt.SVNr = "4016270900";
            kontakt.Geschlecht = "m";
            kontakt.Familienstand = "ledig";
            kontakt.Email = "franz.kautz@gmx.net";
            kontakt.Telefonnummer = "025748469";
            kontakt.Strasse = "Milchhausstraße 1";
            kontakt.PostleitzahlID = postleitzahl;
            kontakt.AltersgruppeID = altersgruppe;
            kontakt.SozialgruppeID = sozialgruppe;
            kontakt.StaatsbuergerschaftID = staatsbuergerschaft;

            Bankverbindung bankverbindung = new Bankverbindung();
            bankverbindung.IBAN = "AT1290909585";
            bankverbindung.Kontoinhaber = "Franz Kautz";
            bankverbindung.KontaktID = kontakt;

            Rechnung rechnung = new Rechnung();
            rechnung.Rechnungsnummer = "A23";
            rechnung.Rechnungsdatum = DateTime.Now;
            rechnung.KontaktID = kontakt;
            rechnung.KursID = kurs;

            KontaktKurs kontaktkurs = new KontaktKurs();
            kontaktkurs.Teilnahmebestaetigung = false;
            kontaktkurs.TeilnahmebestaetigungDatum = DateTime.Now;
            kontaktkurs.Buchungsdatum = DateTime.Now;
            kontaktkurs.Bezahlt = true;
            kontaktkurs.KontakID = kontakt;
            kontaktkurs.KursID = kurs;

            Kursleiter kursleiter = new Kursleiter();
            kursleiter.KontaktID = kontakt;

            KursleiterKurs kursleiterKurs = new KursleiterKurs();
            kursleiterKurs.Honorar = 324.23;
            kursleiterKurs.KursleiterID = kursleiter;
            kursleiterKurs.KursID = kurs;

            Gutschein gutschein = new Gutschein();
            gutschein.Bezeichnung = "Geburtstagsgutschein";
            gutschein.Betrag = 10;

            Pass pass = new Pass();
            pass.KontaktID = kontakt;
            pass.PassNr = "AT2342423424324234234";
            pass.PassBeginn = DateTime.Now;
            pass.PassEnde = DateTime.Now;

            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();
            kassabuchkonto.Kontonummer = "20004";
            kassabuchkonto.Kontobezeichnung = "Kautz Franz";
            kassabuchkonto.Kontostand = 300.50;

            Schluessel schluessel = new Schluessel();
            schluessel.Bezeichnung = "Raum 1";
            schluessel.Code = "1234";
            schluessel.Platz = "recht oben";
            schluessel.Anmerkung = "hat nicht gesperrt";
            schluessel.Aktiv = false;

            Mitgliedschaft mitgliedschaft = new Mitgliedschaft();
            mitgliedschaft.Bezeichnung = "Theatermitlgiedschaft";
            mitgliedschaft.Mitgliedsbeitrag = 10;
            mitgliedschaft.Ermaessigung = 3;

            Kassabuch kassabuch = new Kassabuch();
            kassabuch.Datum = DateTime.Now;
            kassabuch.Buchungstext = "Einzahlung von Kautz";
            kassabuch.Betrag = 23;
            kassabuch.KontaktID = kontakt;
            kassabuch.KassabuchkontoID = kassabuchkonto;

            MitgliedschaftKontakt mitgliedschaftKontakt = new MitgliedschaftKontakt();
            mitgliedschaftKontakt.Kalenderjahr = 2009;
            mitgliedschaftKontakt.MitgliedschaftID = mitgliedschaft;
            mitgliedschaftKontakt.KontaktID = kontakt;

            Benutzer benutzer = new Benutzer();
            benutzer.Benutzername = "frakau";
            benutzer.Passwort = "1234";

            Benutzer benutzer1 = new Benutzer();
            benutzer1.Benutzername = "nichub";
            benutzer1.Passwort = "1234";

            KontaktGutschein kontaktGutschein = new KontaktGutschein();
            kontaktGutschein.KontaktID = kontakt;
            kontaktGutschein.GutscheinID = gutschein;
            kontaktGutschein.GetilgtAm = DateTime.Now;
            kontaktGutschein.GetilgtBei = "Frau Mustermann";
            kontaktGutschein.Betrag = 342;

            SchluesselKontakt schluesselKontakt = new SchluesselKontakt();
            schluesselKontakt.SchluesselID = schluessel;
            schluesselKontakt.KontaktID = kontakt;
            schluesselKontakt.Herausgeber = "Frau Mustermann";
            schluesselKontakt.AusgabeAm = DateTime.Now;
            schluesselKontakt.RetourAm = DateTime.Now;
            schluesselKontakt.Frist = 30;
            schluesselKontakt.Einsatz = 25;
            schluesselKontakt.Verlust = true;


            var session = _sessionFactory.OpenSession();

            using (var tran = session.BeginTransaction())
            {
                try
                {
                    //session.Save(postleitzahl);
                    //session.Save(kursort);
                    //session.Save(titel);
                    //session.Save(kurskategorie);
                    //session.Save(kurs);
                    //session.Save(termin);
                    //session.Save(altersgruppe);
                    //session.Save(sozialgruppe);
                    //session.Save(staatsbuergerschaft);
                    //session.Save(kontakt);
                    //session.Save(bankverbindung);
                    //session.Save(rechnung);
                    //session.Save(kontaktkurs);
                    //session.Save(kursleiter);
                    //session.Save(kursleiterKurs);
                    //session.Save(gutschein);
                    //session.Save(pass);
                    //session.Save(kassabuchkonto);
                    //session.Save(schluessel);
                    //session.Save(mitgliedschaft);
                    //session.Save(kassabuchkonto);
                    //session.Save(kassabuch);
                    //session.Save(mitgliedschaftKontakt);
                    //session.Save(benutzer);
                    //session.Save(benutzer1);
                    //session.Save(kontaktGutschein);
                    //session.Save(schluesselKontakt);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }


        }

        protected override void ApplicationStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.EnableBasicAuthentication(new BasicAuthenticationConfiguration(container.Resolve<IUserValidator>(),"Projektname"));
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register((c, o) => _sessionFactory.OpenSession());
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently
                .Configure()
                //.Database(MySQLConfiguration.Standard.ConnectionString("Server=[ServerIp]; Port=3306;Database=[Database]; Uid=[Username]; Pwd=[Password];"))
                .Database(MySQLConfiguration.Standard.ConnectionString("Server=127.0.0.1; Port=3306;Database=vhs_mistelbach; Uid=root;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Termin>())
                //uncomment to update schema db 
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)) 
                //uncoment to create schema db, each time the app is launched the db will be created
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
              .BuildSessionFactory();
        }
    }
}