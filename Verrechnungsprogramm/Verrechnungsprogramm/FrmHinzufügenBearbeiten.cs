﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Collections;
using Common.Models;
using RestSharp.Authenticators;

namespace Verrechnungsprogramm
{
    public partial class FrmHinzufügenBearbeiten : Form
    {
        public FrmHinzufügenBearbeiten()
        {
            InitializeComponent();
        }
        public string titel, altersgruppe, sozialgruppe, ort;

        private void FrmHinzufügenBearbeiten_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:8888");

            var requestTitel = new RestRequest("titel", Method.GET);
            requestTitel.AddHeader("Content-Type", "application/json");
            var responseTitel = client.Execute<List<Titel>>(requestTitel);

            var requestPlz = new RestRequest("postleitzahlen", Method.GET);
            requestPlz.AddHeader("Content-Type", "application/json");
            var responsePlz = client.Execute<List<Postleitzahl>>(requestPlz);

            var requestAltersgruppe = new RestRequest("altersgruppen", Method.GET);
            requestAltersgruppe.AddHeader("Content-Type", "application/json");
            var responseAltersgruppe = client.Execute<List<Altersgruppe>>(requestAltersgruppe);

            var requestSozialgruppe = new RestRequest("sozialgruppen", Method.GET);
            requestSozialgruppe.AddHeader("Content-Type", "application/json");
            var responseSozialgruppe = client.Execute<List<Sozialgruppe>>(requestSozialgruppe);

            var requestStaatsbuergerschaft = new RestRequest("staatsbuergerschaften", Method.GET);
            requestStaatsbuergerschaft.AddHeader("Content-Type", "application/json");
            var responseStaatsbuergerschaft = client.Execute<List<Staatsbuergerschaft>>(requestStaatsbuergerschaft);

            var requestKurskategorie = new RestRequest("kurskategorien", Method.GET);
            requestKurskategorie.AddHeader("Content-Type", "application/json");
            var responseKurskategorie = client.Execute<List<Kurskategorie>>(requestKurskategorie);


            var requestKursort = new RestRequest("kursorte", Method.GET);
            requestKursort.AddHeader("Content-Type", "application/json");
            var responseKursort = client.Execute<List<Kursort>>(requestKursort);

            foreach (Titel t in responseTitel.Data)
            {
                comboBoxTitel.Items.Add(t.Bezeichnung.ToString());
            }

            foreach (Postleitzahl p in responsePlz.Data)
            {
                comboBoxKontaktPostleitzahl.Items.Add(p.Plz.ToString());
                comboBoxKursortPlz.Items.Add(p.Plz.ToString());
            }

            foreach (Postleitzahl p in responsePlz.Data)
            {
                if(comboBoxKursortPlz.Text.Equals(p.Plz))
                {
                    comboBoxKursortOrt.Items.Add(p.Ort.ToString());
                }

                if (comboBoxKontaktPostleitzahl.Text.Equals(p.Plz))
                {
                    comboBoxKontaktOrt.Items.Add(p.Ort.ToString());
                }
            }

            foreach (Altersgruppe a in responseAltersgruppe.Data)
            {
                comboBoxAltersgruppe.Items.Add(a.Bezeichnung.ToString());
            }

            foreach (Sozialgruppe s in responseSozialgruppe.Data)
            {
                comboBoxSozialgruppe.Items.Add(s.Bezeichnung.ToString());
            }

            foreach (Staatsbuergerschaft s in responseStaatsbuergerschaft.Data)
            {
                comboBoxStaatsbuergerschaft.Items.Add(s.Staat.ToString());
            }

            foreach (Kurskategorie kk in responseKurskategorie.Data)
            {
                comboBoxKursKurskategorie.Items.Add(kk.Bezeichnung.ToString());
            }

            foreach (Kursort k in responseKursort.Data)
            {
                comboBoxKursKursort.Items.Add(k.Bezeichnung.ToString());
            }

            comboBoxTitel.SelectedIndex = comboBoxTitel.FindStringExact(titel);
            comboBoxKontaktOrt.SelectedIndex = comboBoxKontaktOrt.FindStringExact(ort);
            comboBoxAltersgruppe.SelectedIndex = comboBoxAltersgruppe.FindStringExact(altersgruppe);
            comboBoxSozialgruppe.SelectedIndex = comboBoxSozialgruppe.FindStringExact(sozialgruppe);

            comboBoxKursortOrt.SelectedIndex = comboBoxKursortOrt.FindStringExact(ort);

            listViewKontakt.FullRowSelect = true;

            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Altersgruppe"))
            {
                panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Titel"))
            {
                panelTitel.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Sozialgruppe"))
            {
                panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kontakt"))
            {
                panelKontakt.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kurskategorie"))
            {
                panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kurs"))
            {
                panelKurs.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Bankverbindung"))
            {
                panelBankverbindung.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Pass"))
            {
                panelPass.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Schlüssel"))
            {
                panelSchluessel.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Gutschein"))
            {
                panelGutschein.Visible = true;
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kassabuchkonto"))
            {
                panelKassabuchkonto.Visible = true;
                this.Height = 370;
                this.Width = 520;
                this.Location = new Point(200, 150);

            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kassabuch"))
            {
               panelKassabuch.Visible = true;
                this.Height = 470;
                this.Width = 520;
                this.Location = new Point(200, 150);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Rechnung"))
            {
                panelRechnung.Visible = true;
                this.Height = 450;
                this.Width = 520;
                this.Location = new Point(200, 150);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kursort"))
            {
                panelKursort.Visible = true;
            }



        }

        //private void comboboxenFüllen()
        //{

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("anlegen"))
            {
                if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Altersgruppe"))
                {
                    altersgruppeHinzufügen();
                    this.Close();
                }
                if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kurskategorie"))
                {
                    kurskategorieHinzufügen();
                    this.Close();
                }
                if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Sozialgruppe"))
                {
                    sozialgruppeHinzufügen();
                    this.Close();
                }
            }

            if (this.Text.Equals("bearbeiten"))
            {
                if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Altersgruppe"))
                {
                    altersgruppeBearbeiten();
                    this.Close();
                }
                if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kurskategorie"))
                {
                    kurskategorieBearbeiten();
                    this.Close();
                }
                if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Sozialgruppe"))
                {
                    sozialgruppeBearbeiten();
                    this.Close();
                }
            }
        }



        private void titelBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Titel titel = new Titel();

            var request = new RestRequest("titel", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Titel>>(request);

            foreach (Titel t in response.Data)
            {
                if (t.TitelID == Convert.ToInt32(labelID.Text))
                {
                    titel.TitelID = Convert.ToInt32(labelID.Text);
                    titel.Bezeichnung = textBoxBezeichnungTitel.Text;

                    bool vorgestellt = true;
                    if (checkBoxVorgestellt.Checked == true)
                    {
                        vorgestellt = true;
                    }
                    else
                    {
                        vorgestellt = false;
                    }
                    titel.Vorgestellt = vorgestellt;

                    var request1 = new RestRequest("titel", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(titel);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void sozialgruppeBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Sozialgruppe sozialgruppe = new Sozialgruppe();

            var request = new RestRequest("sozialgruppen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Sozialgruppe>>(request);

            foreach (Sozialgruppe s in response.Data)
            {
                if (s.SozialgruppeID == Convert.ToInt32(labelID.Text))
                {
                    sozialgruppe.SozialgruppeID = Convert.ToInt32(labelID.Text);
                    sozialgruppe.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

                    var request1 = new RestRequest("sozialgruppen", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(sozialgruppe);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void kurskategorieBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Kurskategorie kurskategorie = new Kurskategorie();

            var request = new RestRequest("kurskategorien", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kurskategorie>>(request);

            foreach (Kurskategorie kk in response.Data)
            {
                if (kk.KurskategorieID == Convert.ToInt32(labelID.Text))
                {
                    kurskategorie.KurskategorieID = Convert.ToInt32(labelID.Text);
                    kurskategorie.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

                    var request1 = new RestRequest("kurskategorien", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kurskategorie);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void altersgruppeBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Altersgruppe altersgruppe = new Altersgruppe();

            var request = new RestRequest("altersgruppen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Altersgruppe>>(request);

            foreach (Altersgruppe a in response.Data)
            {
                if (a.AltersgruppeID == Convert.ToInt32(labelID.Text))
                {
                    altersgruppe.AltersgruppeID = Convert.ToInt32(labelID.Text);
                    altersgruppe.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

                    var request1 = new RestRequest("altersgruppen", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(altersgruppe);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void passBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Pass pass = new Pass();
            Kontakt aktKontakt = new Kontakt();

            var requestPass = new RestRequest("paesse", Method.GET);
            requestPass.AddHeader("Content-Type", "application/json");
            var responsePass = client.Execute<List<Pass>>(requestPass);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            foreach (Pass p in responsePass.Data)
            {
                if (p.PassID == Convert.ToInt32(labelID.Text))
                {
                    pass.PassID = Convert.ToInt32(labelID.Text);

                    foreach (Kontakt k in responseKontakt.Data)
                    {
                        if (k.KontaktID.ToString().Equals(textBoxPassKontaktID.Text))
                        {
                            aktKontakt.KontaktID = k.KontaktID;
                            aktKontakt.TitelID = k.TitelID;
                            aktKontakt.Vorname = k.Vorname;
                            aktKontakt.Nachname = k.Nachname;
                            aktKontakt.SVNr = k.SVNr;
                            aktKontakt.Geschlecht = k.Geschlecht;
                            aktKontakt.Familienstand = k.Familienstand;
                            aktKontakt.Email = k.Email;
                            aktKontakt.Telefonnummer = k.Telefonnummer;
                            aktKontakt.Strasse = k.Strasse;
                            aktKontakt.PostleitzahlID = k.PostleitzahlID;
                            aktKontakt.AltersgruppeID = k.AltersgruppeID;
                            aktKontakt.SozialgruppeID = k.SozialgruppeID;
                            aktKontakt.StaatsbuergerschaftID = k.StaatsbuergerschaftID;
                        }
                    }

                    pass.KontaktID = aktKontakt;
                    pass.PassNr = textBoxPassNr.Text;
                    pass.PassBeginn = dateTimePickerPassBeginn.Value;
                    pass.PassEnde = dateTimePickerPassEnde.Value;

                    var request1 = new RestRequest("paesse", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(pass);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void passHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Kontakt kontakt = new Kontakt();
            Pass pass = new Pass();

            pass.PassNr = textBoxPassNr.Text;
            pass.PassBeginn = dateTimePickerPassBeginn.Value;
            pass.PassEnde = dateTimePickerPassEnde.Value;

            var request1 = new RestRequest("kontakte", Method.GET);

            request1.AddHeader("Content-Type", "application/json");
            var response1 = client.Execute<List<Kontakt>>(request1);



            foreach (Kontakt k in response1.Data)
            {
                if (k.KontaktID.ToString().Equals(textBoxPassKontaktID.Text))
                {
                    kontakt.KontaktID = k.KontaktID;
                    kontakt.TitelID = k.TitelID;
                    kontakt.Vorname = k.Vorname;
                    kontakt.Nachname = k.Nachname;
                    kontakt.SVNr = k.SVNr;
                    kontakt.Geschlecht = k.Geschlecht;
                    kontakt.Familienstand = k.Familienstand;
                    kontakt.Email = k.Email;
                    kontakt.Telefonnummer = k.Telefonnummer;
                    kontakt.Strasse = k.Strasse;
                    kontakt.PostleitzahlID = k.PostleitzahlID;
                    kontakt.AltersgruppeID = k.AltersgruppeID;
                    kontakt.SozialgruppeID = k.SozialgruppeID;
                    kontakt.StaatsbuergerschaftID = k.StaatsbuergerschaftID;
                }
            }

            pass.KontaktID = kontakt;

            var request = new RestRequest("paesse", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(pass);
            var response = client.Execute(request);
        }

        private void sozialgruppeHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Sozialgruppe sozialgruppe = new Sozialgruppe();
            sozialgruppe.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

            var request = new RestRequest("sozialgruppen", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(sozialgruppe);
            var response = client.Execute(request);
        }

        private void kurskategorieHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Kurskategorie kurskategorie = new Kurskategorie();
            kurskategorie.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

            var request = new RestRequest("kurskategorien", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kurskategorie);
            var response = client.Execute(request);
        }

        private void altersgruppeHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Altersgruppe altersgruppe = new Altersgruppe();
            altersgruppe.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

            var request = new RestRequest("altersgruppen", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(altersgruppe);
            var response = client.Execute(request);
        }

        private void buttonKontaktAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAbbrechenTitel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titelHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Titel titel = new Titel();
            titel.Bezeichnung = textBoxBezeichnungTitel.Text;
            bool vorgestellt = true;
            if (checkBoxVorgestellt.Checked == true)
            {
                vorgestellt = true;
            }
            else
            {
                vorgestellt = false;
            }
            titel.Vorgestellt = vorgestellt;

            var request = new RestRequest("titel", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(titel);
            var response = client.Execute(request);
        }

        private void schluesselHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Schluessel schluessel = new Schluessel();
            schluessel.Bezeichnung = textBoxSchluesselBezeichnung.Text;
            schluessel.Code = textBoxSchluesselCode.Text;
            schluessel.Platz = textBoxSchluesselPlatz.Text;
            schluessel.Anmerkung = textBoxSchluesselAnmerkung.Text;
            bool aktiv = true;
            if (checkBoxSchluesselAktiv.Checked == true)
            {
                aktiv = true;
            }
            else
            {
                aktiv = false;
            }
            schluessel.Aktiv = aktiv;

            var request = new RestRequest("schluessel", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(schluessel);
            var response = client.Execute(request);
        }

        private void gutscheinHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Gutschein gutschein = new Gutschein();
            gutschein.Bezeichnung = textBoxGutscheinBezeichnung.Text;
            gutschein.Betrag = Convert.ToDouble(textBoxGutscheinBetrag.Text);

            var request = new RestRequest("gutscheine", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(gutschein);
            var response = client.Execute(request);
        }

        private void mitgliedschaftHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Mitgliedschaft mitgliedschaft = new Mitgliedschaft();
            mitgliedschaft.Bezeichnung = textBoxMitgliedschaftBezeichnung.Text;
            mitgliedschaft.Mitgliedsbeitrag = Convert.ToDouble(textBoxMitgliedschaftMitgliedsbeitrag.Text);
            mitgliedschaft.Ermaessigung = Convert.ToDouble(textBoxMitgliedschaftErmaessigung.Text);

            var request = new RestRequest("mitgliedschaften", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(mitgliedschaft);
            var response = client.Execute(request);
        }

        private void buttonSpeichernTitel_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Titel bearbeiten"))
            {
                titelBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Titel anlegen"))
            {
                titelHinzufügen();
                this.Close();
            }
        }

        private void labelBearbeitenSubItem8_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxKontaktPostleitzahl_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxKontaktPostleitzahl_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void einlesenOrt()
        {
            comboBoxKontaktOrt.Items.Clear();
            comboBoxKursortOrt.Items.Clear();
            var client = new RestClient("http://localhost:8888");

            var requestPlz = new RestRequest("postleitzahlen", Method.GET);
            requestPlz.AddHeader("Content-Type", "application/json");
            var responsePlz = client.Execute<List<Postleitzahl>>(requestPlz);

            if(panelKursort.Visible ==true)
            {
                foreach (Postleitzahl p in responsePlz.Data)
                {
                    if (comboBoxKursortPlz.Text.Equals(p.Plz))
                    {
                        comboBoxKursortOrt.Items.Add(p.Ort.ToString());
                    }
                }
            }

            if (panelKontakt.Visible == true)
            {
                foreach (Postleitzahl p in responsePlz.Data)
                { 
                    if (comboBoxKontaktPostleitzahl.Text.Equals(p.Plz))
                    {
                        comboBoxKontaktOrt.Items.Add(p.Ort.ToString());
                    }
                }
            }
        }

        private void comboBoxKontaktPostleitzahl_Leave(object sender, EventArgs e)
        {
            comboBoxKontaktOrt.Items.Clear();
            einlesenOrt();
        }

        private void comboBoxKontaktOrt_Leave(object sender, EventArgs e)
        {

        }

        private void buttonKursAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBankverbindungAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKursSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Kurs bearbeiten"))
            {
                //kursBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Kurs anlegen"))
            {
                kursHinzufügen();
                this.Close();
            }

        }

        private void kursHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Kurs kurs = new Kurs();
            Kurskategorie kurskategorie = new Kurskategorie();
            Kursort kursort = new Kursort();

            var requestKurskategorie = new RestRequest("kurskategorien", Method.GET);
            requestKurskategorie.AddHeader("Content-Type", "application/json");
            var responseKurskategorie = client.Execute<List<Kurskategorie>>(requestKurskategorie);

            var requestKursort = new RestRequest("kursorte", Method.GET);
            requestKursort.AddHeader("Content-Type", "application/json");
            var responseKursort = client.Execute<List<Kursort>>(requestKursort);


            kurs.Bezeichnung = textBoxKursBezeichnung.Text;
            kurs.Preis = Convert.ToDouble(textBoxKursPreis.Text);
            kurs.MinTeilnehmer = Convert.ToInt32(textBoxKursMinTeilnehmer.Text);
            kurs.MaxTeilnehmer = Convert.ToInt32(textBoxMaxTeilnehmer.Text);
            kurs.AnzEinheiten = Convert.ToInt32(textBoxKursAnzEinheit.Text);

            if (comboBoxKursVerbindklichkeit.Text.Equals("ja"))
                kurs.Verbindlichkeit = true;

            else
                kurs.Verbindlichkeit = false;

            kurs.Foerderung = comboBoxKursFoerderung.Text;
            kurs.Status = textBoxKursStatus.Text;
            kurs.Beschreibung = textBoxKursBeschreibung.Text;
            kurs.ZeitVon = dateTimePickerKursZeitVon.Value;
            kurs.ZeitBis = dateTimePickerKursZeitBis.Value;
            kurs.DatumVon = dateTimePickerKursDatumVon.Value;
            kurs.DatumBis = dateTimePickerKursDatumBis.Value;
            kurs.Seminarnummer = textBoxKursSeminarnummer.Text;

            foreach (Kurskategorie k in responseKurskategorie.Data)
            {
                if (k.Bezeichnung.ToString().Equals(comboBoxKursKurskategorie.Text))
                {
                    kurskategorie.KurskategorieID = k.KurskategorieID;
                    kurskategorie.Bezeichnung = k.Bezeichnung;
                }
            }
            kurs.KurskategorieID = kurskategorie;

            foreach (Kursort k in responseKursort.Data)
            {
                if (k.Bezeichnung.ToString().Equals(comboBoxKursKursort.Text))
                {
                    kursort.KursortID = k.KursortID;
                    kursort.Bezeichnung = k.Bezeichnung;
                }
            }
            kurs.KursortID = kursort;

            kurs.Anmeldeschluss = dateTimePickerKursAnmeldeschluss.Value;
            kurs.Anmerkung = textBoxKursAnmerkung.Text;

            if (checkBoxKursAnzeigen.Checked == true)
                kurs.Anzeigen = true;

            else
                kurs.Anzeigen = false;

            var request = new RestRequest("kurse", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kurs);
            var response = client.Execute(request);

        }

        private void buttonBankverbindungSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Bankverbindung bearbeiten"))
            {
                bankverbindungBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Bankverbindung anlegen"))
            {
                bankverbindungHinzufügen();
                this.Close();
            }
        }

        private void gutscheinBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Gutschein gutschein = new Gutschein();

            var request = new RestRequest("gutscheine", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Gutschein>>(request);

            foreach (Gutschein g in response.Data)
            {
                if (g.GutscheinID == Convert.ToInt32(labelID.Text))
                {
                    gutschein.GutscheinID = Convert.ToInt32(labelID.Text);
                    gutschein.Bezeichnung = textBoxGutscheinBezeichnung.Text;
                    gutschein.Betrag = Convert.ToDouble(textBoxGutscheinBetrag.Text);

                    var request1 = new RestRequest("gutscheine", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(gutschein);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }

        }

        private void schluesselBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Schluessel schluessel = new Schluessel();

            var request = new RestRequest("schluessel", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Schluessel>>(request);

            foreach (Schluessel s in response.Data)
            {
                if (s.SchluesselID == Convert.ToInt32(labelID.Text))
                {
                    schluessel.SchluesselID = Convert.ToInt32(labelID.Text);
                    schluessel.Bezeichnung = textBoxSchluesselBezeichnung.Text;
                    schluessel.Code = textBoxSchluesselCode.Text;
                    schluessel.Platz = textBoxSchluesselPlatz.Text;
                    schluessel.Anmerkung = textBoxSchluesselAnmerkung.Text;
                    bool aktiv = true;
                    if (checkBoxSchluesselAktiv.Checked == true)
                    {
                        aktiv = true;
                    }
                    else
                    {
                        aktiv = false;
                    }
                    schluessel.Aktiv = aktiv;

                    var request1 = new RestRequest("schluessel", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(schluessel);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }

        }

        private void mitgliedschaftBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Mitgliedschaft mitgliedschaft = new Mitgliedschaft();

            var request = new RestRequest("mitgliedschaften", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Mitgliedschaft>>(request);

            foreach (Mitgliedschaft m in response.Data)
            {
                if (m.MitgliedschaftID == Convert.ToInt32(labelID.Text))
                {
                    mitgliedschaft.MitgliedschaftID = Convert.ToInt32(labelID.Text);
                    mitgliedschaft.Bezeichnung = textBoxMitgliedschaftBezeichnung.Text;
                    mitgliedschaft.Mitgliedsbeitrag = Convert.ToDouble(textBoxMitgliedschaftMitgliedsbeitrag.Text);
                    mitgliedschaft.Ermaessigung = Convert.ToDouble(textBoxMitgliedschaftErmaessigung.Text);

                    var request1 = new RestRequest("mitgliedschaften", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(mitgliedschaft);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }

        }

        private void kontaktHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Kontakt kontakt = new Kontakt();
            Titel titel = new Titel();
            Postleitzahl postleitzahl = new Postleitzahl();
            Altersgruppe altersgruppe = new Altersgruppe();
            Sozialgruppe sozialgruppe = new Sozialgruppe();
            Staatsbuergerschaft staatsbuergerschaft = new Staatsbuergerschaft();

            var requestTitel = new RestRequest("titel", Method.GET);
            requestTitel.AddHeader("Content-Type", "application/json");
            var responseTitel = client.Execute<List<Titel>>(requestTitel);

            var requestPostleitzahl = new RestRequest("postleitzahlen", Method.GET);
            requestPostleitzahl.AddHeader("Content-Type", "application/json");
            var responsePostleitzahl = client.Execute<List<Postleitzahl>>(requestPostleitzahl);

            var requestAltersgruppe = new RestRequest("altersgruppen", Method.GET);
            requestAltersgruppe.AddHeader("Content-Type", "application/json");
            var responseAltersgruppe = client.Execute<List<Altersgruppe>>(requestAltersgruppe);

            var requestSozialgruppe = new RestRequest("sozialgruppen", Method.GET);
            requestSozialgruppe.AddHeader("Content-Type", "application/json");
            var responseSozialgruppe = client.Execute<List<Sozialgruppe>>(requestSozialgruppe);

            var requestStaatsbuergerschaft = new RestRequest("staatsbuergerschaften", Method.GET);
            requestStaatsbuergerschaft.AddHeader("Content-Type", "application/json");
            var responseStaatsbuergerschaft = client.Execute<List<Staatsbuergerschaft>>(requestStaatsbuergerschaft);

            foreach (Titel t in responseTitel.Data)
            {
                if (t.Bezeichnung.ToString().Equals(comboBoxTitel.Text))
                {
                    titel.TitelID = t.TitelID;
                    titel.Bezeichnung = t.Bezeichnung;
                    titel.Vorgestellt = t.Vorgestellt;
                }
            }
            kontakt.TitelID = titel;

            kontakt.Vorname = textBoxVorname.Text;
            kontakt.Nachname = textBoxNachname.Text;
            kontakt.SVNr = textBoxSVNr.Text;
            kontakt.Geschlecht = comboBoxGeschlecht.Text;
            kontakt.Familienstand = comboBoxFamilienstand.Text;
            kontakt.Email = textBoxEMail.Text;
            kontakt.Telefonnummer = textBoxTelefonnummer.Text;

            foreach (Postleitzahl p in responsePostleitzahl.Data)
            {
                if ((p.Plz.ToString().Equals(comboBoxKontaktPostleitzahl.Text)) && (p.Ort.ToString().Equals(comboBoxKontaktOrt.Text)))
                {
                    postleitzahl.PostleitzahlID = p.PostleitzahlID;
                    postleitzahl.Plz = p.Plz;
                    postleitzahl.Ort = p.Ort;
                }
            }
            kontakt.PostleitzahlID = postleitzahl;

            kontakt.Strasse = textBoxKontaktStrasse.Text;

            foreach (Altersgruppe a in responseAltersgruppe.Data)
            {
                if (a.Bezeichnung.ToString().Equals(comboBoxAltersgruppe.Text))
                {
                    altersgruppe.AltersgruppeID = a.AltersgruppeID;
                    altersgruppe.Bezeichnung = a.Bezeichnung;
                }
            }
            kontakt.AltersgruppeID = altersgruppe;

            foreach (Sozialgruppe s in responseSozialgruppe.Data)
            {
                if (s.Bezeichnung.ToString().Equals(comboBoxSozialgruppe.Text))
                {
                    sozialgruppe.SozialgruppeID = s.SozialgruppeID;
                    sozialgruppe.Bezeichnung = s.Bezeichnung;
                }
            }
            kontakt.SozialgruppeID = sozialgruppe;

            foreach (Staatsbuergerschaft s in responseStaatsbuergerschaft.Data)
            {
                if (s.Staat.ToString().Equals(comboBoxStaatsbuergerschaft.Text))
                {
                    staatsbuergerschaft.StaatsbuergerschaftID = s.StaatsbuergerschaftID;
                    staatsbuergerschaft.Staat = s.Staat;
                }
            }
            kontakt.StaatsbuergerschaftID = staatsbuergerschaft;

            var request = new RestRequest("kontakte", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kontakt);
            var response = client.Execute(request);
        }

        private void kontaktBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Kontakt kontakt = new Kontakt();
            Titel titel = new Titel();
            Postleitzahl postleitzahl = new Postleitzahl();
            Altersgruppe altersgruppe = new Altersgruppe();
            Sozialgruppe sozialgruppe = new Sozialgruppe();
            Staatsbuergerschaft staatsbuergerschaft = new Staatsbuergerschaft();

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            var requestTitel = new RestRequest("titel", Method.GET);
            requestTitel.AddHeader("Content-Type", "application/json");
            var responseTitel = client.Execute<List<Titel>>(requestTitel);

            var requestPostleitzahl = new RestRequest("postleitzahlen", Method.GET);
            requestPostleitzahl.AddHeader("Content-Type", "application/json");
            var responsePostleitzahl = client.Execute<List<Postleitzahl>>(requestPostleitzahl);

            var requestAltersgruppe = new RestRequest("altersgruppen", Method.GET);
            requestAltersgruppe.AddHeader("Content-Type", "application/json");
            var responseAltersgruppe = client.Execute<List<Altersgruppe>>(requestAltersgruppe);

            var requestSozialgruppe = new RestRequest("sozialgruppen", Method.GET);
            requestSozialgruppe.AddHeader("Content-Type", "application/json");
            var responseSozialgruppe = client.Execute<List<Sozialgruppe>>(requestSozialgruppe);

            var requestStaatsbuergerschaft = new RestRequest("staatsbuergerschaften", Method.GET);
            requestStaatsbuergerschaft.AddHeader("Content-Type", "application/json");
            var responseStaatsbuergerschaft = client.Execute<List<Staatsbuergerschaft>>(requestStaatsbuergerschaft);

            foreach (Kontakt k in responseKontakt.Data)
            {
                if (k.KontaktID == Convert.ToInt32(labelID.Text))
                {
                    kontakt.KontaktID = Convert.ToInt32(labelID.Text);

                    foreach (Titel t in responseTitel.Data)
                    {
                        if (t.Bezeichnung.ToString().Equals(comboBoxTitel.Text))
                        {
                            titel.TitelID = t.TitelID;
                            titel.Bezeichnung = t.Bezeichnung;
                            titel.Vorgestellt = t.Vorgestellt;
                        }
                    }
                    kontakt.TitelID = titel;

                    kontakt.Vorname = textBoxVorname.Text;
                    kontakt.Nachname = textBoxNachname.Text;
                    kontakt.SVNr = textBoxSVNr.Text;
                    kontakt.Geschlecht = comboBoxGeschlecht.Text;
                    kontakt.Familienstand = comboBoxFamilienstand.Text;
                    kontakt.Email = textBoxEMail.Text;
                    kontakt.Telefonnummer = textBoxTelefonnummer.Text;

                    foreach (Postleitzahl p in responsePostleitzahl.Data)
                    {
                        if ((p.Plz.ToString().Equals(comboBoxKontaktPostleitzahl.Text)) && (p.Ort.ToString().Equals(comboBoxKontaktOrt.Text)))
                        {
                            postleitzahl.PostleitzahlID = p.PostleitzahlID;
                            postleitzahl.Plz = p.Plz;
                            postleitzahl.Ort = p.Ort;
                        }
                    }
                    kontakt.PostleitzahlID = postleitzahl;

                    kontakt.Strasse = textBoxKontaktStrasse.Text;

                    foreach (Altersgruppe a in responseAltersgruppe.Data)
                    {
                        if (a.Bezeichnung.ToString().Equals(comboBoxAltersgruppe.Text))
                        {
                            altersgruppe.AltersgruppeID = a.AltersgruppeID;
                            altersgruppe.Bezeichnung = a.Bezeichnung;
                        }
                    }
                    kontakt.AltersgruppeID = altersgruppe;

                    foreach (Sozialgruppe s in responseSozialgruppe.Data)
                    {
                        if (s.Bezeichnung.ToString().Equals(comboBoxSozialgruppe.Text))
                        {
                            sozialgruppe.SozialgruppeID = s.SozialgruppeID;
                            sozialgruppe.Bezeichnung = s.Bezeichnung;
                        }
                    }
                    kontakt.SozialgruppeID = sozialgruppe;

                    foreach (Staatsbuergerschaft s in responseStaatsbuergerschaft.Data)
                    {
                        if (s.Staat.ToString().Equals(comboBoxStaatsbuergerschaft.Text))
                        {
                            staatsbuergerschaft.StaatsbuergerschaftID = s.StaatsbuergerschaftID;
                            staatsbuergerschaft.Staat = s.Staat;
                        }
                    }
                    kontakt.StaatsbuergerschaftID = staatsbuergerschaft;

                    var request1 = new RestRequest("kontakte", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kontakt);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void bankverbindungBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Bankverbindung bankverbindung = new Bankverbindung();
            Kontakt aktKontakt = new Kontakt();

            var requestBankverbindung = new RestRequest("bankverbindungen", Method.GET);
            requestBankverbindung.AddHeader("Content-Type", "application/json");
            var responseBankverbindung = client.Execute<List<Bankverbindung>>(requestBankverbindung);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            foreach (Bankverbindung b in responseBankverbindung.Data)
            {
                if (b.BankverbindungID == Convert.ToInt32(labelID.Text))
                {
                    bankverbindung.BankverbindungID = Convert.ToInt32(labelID.Text);
                    bankverbindung.IBAN = textBoxBankverbindungIBAN.Text;
                    bankverbindung.Kontoinhaber = textBoxBankverbindungKontoinhaber.Text;

                    foreach (Kontakt k in responseKontakt.Data)
                    {
                        if (k.KontaktID.ToString().Equals(textBoxBankverbindungKontaktID.Text))
                        {
                            aktKontakt.KontaktID = k.KontaktID;
                            aktKontakt.TitelID = k.TitelID;
                            aktKontakt.Vorname = k.Vorname;
                            aktKontakt.Nachname = k.Nachname;
                            aktKontakt.SVNr = k.SVNr;
                            aktKontakt.Geschlecht = k.Geschlecht;
                            aktKontakt.Familienstand = k.Familienstand;
                            aktKontakt.Email = k.Email;
                            aktKontakt.Telefonnummer = k.Telefonnummer;
                            aktKontakt.Strasse = k.Strasse;
                            aktKontakt.PostleitzahlID = k.PostleitzahlID;
                            aktKontakt.AltersgruppeID = k.AltersgruppeID;
                            aktKontakt.SozialgruppeID = k.SozialgruppeID;
                            aktKontakt.StaatsbuergerschaftID = k.StaatsbuergerschaftID;
                        }
                    }
                    bankverbindung.KontaktID = aktKontakt;

                    var request1 = new RestRequest("bankverbindungen", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(bankverbindung);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void bankverbindungHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Bankverbindung bankverbindung = new Bankverbindung();
            bankverbindung.IBAN = textBoxBankverbindungIBAN.Text;
            bankverbindung.Kontoinhaber = textBoxBankverbindungKontoinhaber.Text;

            var request1 = new RestRequest("kontakte", Method.GET);

            request1.AddHeader("Content-Type", "application/json");
            var response1 = client.Execute<List<Kontakt>>(request1);

            Kontakt kontakt = new Kontakt();

            foreach (Kontakt k in response1.Data)
            {
                if (k.KontaktID.ToString().Equals(textBoxBankverbindungKontaktID.Text))
                {
                    kontakt.KontaktID = k.KontaktID;
                    kontakt.TitelID = k.TitelID;
                    kontakt.Vorname = k.Vorname;
                    kontakt.Nachname = k.Nachname;
                    kontakt.SVNr = k.SVNr;
                    kontakt.Geschlecht = k.Geschlecht;
                    kontakt.Familienstand = k.Familienstand;
                    kontakt.Email = k.Email;
                    kontakt.Telefonnummer = k.Telefonnummer;
                    kontakt.Strasse = k.Strasse;
                    kontakt.PostleitzahlID = k.PostleitzahlID;
                    kontakt.AltersgruppeID = k.AltersgruppeID;
                    kontakt.SozialgruppeID = k.SozialgruppeID;
                    kontakt.StaatsbuergerschaftID = k.StaatsbuergerschaftID;
                }
            }

            bankverbindung.KontaktID = kontakt;

            var request = new RestRequest("bankverbindungen", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(bankverbindung);
            var response = client.Execute(request);
        }

        private void linkLabelKontakteAnzeigen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listViewKontakt.Items.Clear();
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("kontakte", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kontakt>>(request);

            foreach (Kontakt k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KontaktID.ToString());
                lvItem.SubItems.Add(k.TitelID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Vorname.ToString());
                lvItem.SubItems.Add(k.Nachname.ToString());
                lvItem.SubItems.Add(k.PostleitzahlID.Plz.ToString());
                lvItem.SubItems.Add(k.PostleitzahlID.Ort.ToString());
                lvItem.SubItems.Add(k.Strasse.ToString());
                lvItem.SubItems.Add(k.SVNr.ToString());
                lvItem.SubItems.Add(k.Geschlecht.ToString());
                lvItem.SubItems.Add(k.Familienstand.ToString());

                listViewKontakt.Items.Add(lvItem);
            }
            panelBankverbindung.Visible = false;
            panelKontaktSuche.Visible = true;
        }

        private void listViewKontakt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((labelÜberschrift.Text.Equals("Bankverbindung bearbeiten")) || (labelÜberschrift.Text.Equals("Bankverbindung anlegen")))
            {
                textBoxBankverbindungKontaktID.Text = listViewKontakt.SelectedItems[0].SubItems[0].Text;
                panelBankverbindung.Visible = true;
                panelKontaktSuche.Visible = false;
            }
            if ((labelÜberschrift.Text.Equals("Pass bearbeiten")) || (labelÜberschrift.Text.Equals("Pass anlegen")))
            {
                textBoxPassKontaktID.Text = listViewKontakt.SelectedItems[0].SubItems[0].Text;
                panelPass.Visible = true;
                panelKontaktSuche.Visible = false;
            }
        }

        private void panelKurs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBankverbindung_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPass_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabelKontaktAnzeigen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listViewKontakt.Items.Clear();
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("kontakte", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kontakt>>(request);

            foreach (Kontakt k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KontaktID.ToString());
                lvItem.SubItems.Add(k.TitelID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Vorname.ToString());
                lvItem.SubItems.Add(k.Nachname.ToString());
                lvItem.SubItems.Add(k.SVNr.ToString());
                lvItem.SubItems.Add(k.Geschlecht.ToString());
                lvItem.SubItems.Add(k.Familienstand.ToString());

                listViewKontakt.Items.Add(lvItem);
            }
            panelPass.Visible = false;
            panelKontaktSuche.Visible = true;
        }

        private void einlesenKontaktinListView()
        {
            listViewKontakt.Items.Clear();
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("kontakte", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kontakt>>(request);

            foreach (Kontakt k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KontaktID.ToString());
                lvItem.SubItems.Add(k.TitelID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Vorname.ToString());
                lvItem.SubItems.Add(k.Nachname.ToString());
                lvItem.SubItems.Add(k.SVNr.ToString());
                lvItem.SubItems.Add(k.Geschlecht.ToString());
                lvItem.SubItems.Add(k.Familienstand.ToString());

                listViewKontakt.Items.Add(lvItem);
            }
            panelPass.Visible = false;
            panelKontaktSuche.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Pass bearbeiten"))
            {
                passBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Pass anlegen"))
            {
                passHinzufügen();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Schlüssel bearbeiten"))
            {
                schluesselBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Schlüssel anlegen"))
            {
                schluesselHinzufügen();
                this.Close();
            }
        }

        private void buttonGutscheinAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKontaktSpeichern_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonGutscheinSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Gutschein bearbeiten"))
            {
                gutscheinBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Gutschein anlegen"))
            {
                gutscheinHinzufügen();
                this.Close();
            }
        }

        private void buttonMitgliedschaftAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMitgliedschaftSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Mitgliedschaft bearbeiten"))
            {
                mitgliedschaftBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Mitgliedschaft anlegen"))
            {
                mitgliedschaftHinzufügen();
                this.Close();
            }
        }

        




        private void buttonKontaktSuchen_Click(object sender, EventArgs e)
        {
            listViewKontakt.Items.Clear();

            string vorname = textBoxKontaktSucheVorname.Text;
            string nachname = textBoxKontaktSucheNachname.Text;

            int vornL = textBoxKontaktSucheVorname.Text.Length;
            int nachL = textBoxKontaktSucheNachname.Text.Length;

            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("kontakte", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kontakt>>(request);



            foreach (Kontakt k in response.Data)
            {
                if ((k.Vorname.ToLower().Substring(0, vornL).Equals(vorname)) && (k.Nachname.ToLower().Substring(0, nachL).Equals(nachname)))
                {
                    ListViewItem lvItem = new ListViewItem(k.KontaktID.ToString());
                    lvItem.SubItems.Add(k.TitelID.Bezeichnung.ToString());
                    lvItem.SubItems.Add(k.Vorname.ToString());
                    lvItem.SubItems.Add(k.Nachname.ToString());
                    lvItem.SubItems.Add(k.SVNr.ToString());
                    lvItem.SubItems.Add(k.Geschlecht.ToString());
                    lvItem.SubItems.Add(k.Familienstand.ToString());

                    listViewKontakt.Items.Add(lvItem);
                }
                else if ((k.Vorname.Substring(0, vornL).Equals(vorname)) && (k.Nachname.Substring(0, nachL).Equals(nachname)))
                {
                    ListViewItem lvItem = new ListViewItem(k.KontaktID.ToString());
                    lvItem.SubItems.Add(k.TitelID.Bezeichnung.ToString());
                    lvItem.SubItems.Add(k.Vorname.ToString());
                    lvItem.SubItems.Add(k.Nachname.ToString());
                    lvItem.SubItems.Add(k.SVNr.ToString());
                    lvItem.SubItems.Add(k.Geschlecht.ToString());
                    lvItem.SubItems.Add(k.Familienstand.ToString());

                    listViewKontakt.Items.Add(lvItem);
                }
            }
        }

        private void comboBoxKontaktPostleitzahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            einlesenOrt();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Kontakt bearbeiten"))
            {
                kontaktBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Kontakt anlegen"))
            {
                kontaktHinzufügen();
                this.Close();
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {

        }

        private void buttonKursortAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKursortSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Kursort bearbeiten"))
            {
                kursortBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Kursort anlegen"))
            {
                kursortHinzufügen();
                this.Close();
            }
        }

        private void kursortBearbeiten()
        {
            var client = new RestClient("http://localhost:8888")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };

            Kursort kursort = new Kursort();
            Postleitzahl postleitzahl = new Postleitzahl();

            var requestKursort = new RestRequest("kursorte", Method.GET);
            requestKursort.AddHeader("Content-Type", "application/json");
            var responseKursort = client.Execute<List<Kursort>>(requestKursort);

            var requestPlz = new RestRequest("postleitzahlen", Method.GET);
            requestPlz.AddHeader("Content-Type", "application/json");
            var responsePlz = client.Execute<List<Postleitzahl>>(requestPlz);

            foreach (Kursort k in responseKursort.Data)
            {
                if (k.KursortID == Convert.ToInt32(labelID.Text))
                {
                    kursort.KursortID = Convert.ToInt32(labelID.Text);
                    kursort.Bezeichnung = textBoxKursortBezeichnung.Text;
                    kursort.Beschreibung = textBoxKursortBeschreibung.Text;

                    foreach (Postleitzahl p in responsePlz.Data)
                    {
                        if ((p.Plz.ToString().Equals(comboBoxKursortPlz.Text)) && (p.Ort.ToString().Equals(comboBoxKursortOrt.Text)))
                        {
                            postleitzahl.PostleitzahlID = p.PostleitzahlID;
                            postleitzahl.Plz = p.Plz;
                            postleitzahl.Ort = p.Ort;
                        }
                    }

                    kursort.PostleitzahlID = postleitzahl;
                    kursort.Strasse = textBoxKursortStrasse.Text;

                    var request1 = new RestRequest("kursorte", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kursort);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erfolgreich geändert!");
                    }
                }
            }
        }

        private void kursortHinzufügen()
        {
            var client = new RestClient("http://localhost:8888");

            Kursort kursort = new Kursort();
            Postleitzahl postleitzahl = new Postleitzahl();

            var requestPlz = new RestRequest("postleitzahlen", Method.GET);
            requestPlz.AddHeader("Content-Type", "application/json");
            var responsePlz = client.Execute<List<Postleitzahl>>(requestPlz);

            kursort.Bezeichnung = textBoxKursortBezeichnung.Text;
            kursort.Beschreibung = textBoxKursortBeschreibung.Text;

            foreach (Postleitzahl p in responsePlz.Data)
            {
                if ((p.Plz.ToString().Equals(comboBoxKursortPlz.Text)) && (p.Ort.ToString().Equals(comboBoxKursortOrt.Text)))
                {
                    postleitzahl.PostleitzahlID = p.PostleitzahlID;
                    postleitzahl.Plz = p.Plz;
                    postleitzahl.Ort = p.Ort;
                }
            }

            kursort.PostleitzahlID = postleitzahl;
            kursort.Strasse = textBoxKursortStrasse.Text;

            var request = new RestRequest("kursorte", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kursort);
            var response = client.Execute(request);

        }

        private void comboBoxKursortPlz_SelectedIndexChanged(object sender, EventArgs e)
        {
            einlesenOrt();
        }

        private void comboBoxKursortPlz_Leave(object sender, EventArgs e)
        {
            einlesenOrt();
        }

        private void btnKassabuchAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKassabuchkontoAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRechnungAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
