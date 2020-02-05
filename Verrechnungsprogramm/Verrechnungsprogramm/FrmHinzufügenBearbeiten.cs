using System;
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
        RestClient client;
        HttpBasicAuthenticator Authenticator;
        public FrmHinzufügenBearbeiten()
        {
            InitializeComponent();
            //client = new RestClient("http://localhost:8888")
            client = new RestClient("http://vhs-mistelbach.projects.hakmistelbach.ac.at:20218")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };
        }



        public string titel, altersgruppe, sozialgruppe, ort;

        private void FrmHinzufügenBearbeiten_Load(object sender, EventArgs e)
        {

            var requestTitel = new RestRequest("titel", Method.GET);
            requestTitel.AddHeader("Content-Type", "application/json");
            var responseTitel = client.Execute<List<Titel>>(requestTitel);

            var requestPlz = new RestRequest("postleitzahlen", Method.GET);
            requestPlz.AddHeader("Content-Type", "application/json");
            var responsePlz = client.Execute<List<Postleitzahl>>(requestPlz);

            var requestAltersgruppe = new RestRequest("altersgruppen", Method.GET);
            requestAltersgruppe.AddHeader("Content-Type", "application/json");
            var responseAltersgruppe = client.Execute<List<Altersgruppe>>(requestAltersgruppe);

            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);

            var requestSozialgruppe = new RestRequest("sozialgruppen", Method.GET);
            requestSozialgruppe.AddHeader("Content-Type", "application/json");
            var responseSozialgruppe = client.Execute<List<Sozialgruppe>>(requestSozialgruppe);

            var requestStaatsbuergerschaft = new RestRequest("staatsbuergerschaften", Method.GET);
            requestStaatsbuergerschaft.AddHeader("Content-Type", "application/json");
            var responseStaatsbuergerschaft = client.Execute<List<Staatsbuergerschaft>>(requestStaatsbuergerschaft);

            var requestKurskategorie = new RestRequest("kurskategorien", Method.GET);
            requestKurskategorie.AddHeader("Content-Type", "application/json");
            var responseKurskategorie = client.Execute<List<Kurskategorie>>(requestKurskategorie);

            var requestKassabuchkonto = new RestRequest("kassabuchkonten", Method.GET);
            requestKassabuchkonto.AddHeader("Content-Type", "application/json");
            var responseKassabuchkonto = client.Execute<List<Kassabuchkonto>>(requestKassabuchkonto);

            var requestKassabuch = new RestRequest("kassabuecher", Method.GET);
            requestKassabuch.AddHeader("Content-Type", "application/json");
            var responseKassabuch = client.Execute<List<Kassabuch>>(requestKassabuch);

            var requestRechnung = new RestRequest("rechnungen", Method.GET);
            requestRechnung.AddHeader("Content-Type", "application/json");
            var responseRechnung = client.Execute<List<Rechnung>>(requestRechnung);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);


            var requestKursort = new RestRequest("kursorte", Method.GET);
            requestKursort.AddHeader("Content-Type", "application/json");
            var responseKursort = client.Execute<List<Kursort>>(requestKursort);

            foreach (Titel t in responseTitel.Data)
            {
                comboBoxTitel.Items.Add(t.Bezeichnung.ToString());
            }

            foreach (Kassabuchkonto k in responseKassabuchkonto.Data)
            {
                comboBoxKassabuchkontoID.Items.Add(k.KassabuchkontoID.ToString() + " " + k.Kontobezeichnung.ToString());
            }

            foreach (Kontakt kk in responseKontakt.Data)
            {
                comboBoxKontaktID.Items.Add(kk.KontaktID.ToString() + " " + kk.Nachname.ToString());
            }

            foreach (Kontakt rk in responseKontakt.Data)
            {
                comboBoxRechnungKontaktID.Items.Add(rk.KontaktID.ToString() + " " + rk.Nachname.ToString());
            }

            foreach (Kurs rkk in responseKurs.Data)
            {
                comboBoxRechnungKursID.Items.Add(rkk.KursID.ToString() + " " + rkk.Bezeichnung.ToString());
            }

            foreach (Postleitzahl p in responsePlz.Data)
            {
                comboBoxKontaktPostleitzahl.Items.Add(p.Plz.ToString());
                comboBoxKursortPlz.Items.Add(p.Plz.ToString());
            }

            foreach (Postleitzahl p in responsePlz.Data)
            {
                if (comboBoxKursortPlz.Text.Equals(p.Plz))
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
                comboBoxKursSucheKurskategorie.Items.Add(kk.Bezeichnung.ToString());
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
            listViewKurs.FullRowSelect = true;
            listViewKursleiter.FullRowSelect = true;

            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Altersgruppe"))
            {
                panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
                this.Height = 290;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelAltersgruppeSozialgruppeKurskategorie.Location = new Point(10, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Titel"))
            {
                panelTitel.Visible = true;
                this.Height = 300;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelTitel.Location = new Point(0, 45);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Sozialgruppe"))
            {
                panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
                this.Height = 290;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelAltersgruppeSozialgruppeKurskategorie.Location = new Point(10, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kontakt"))
            {
                panelKontakt.Visible = true;
                this.Height = 750;
                this.Width = 500;
                this.Location = new Point(400, 50);
                panelKontakt.Location = new Point(10, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kurskategorie"))
            {
                panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
                this.Height = 290;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelAltersgruppeSozialgruppeKurskategorie.Location = new Point(10, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kurs"))
            {
                panelKurs.Visible = true;
                this.Height = 565;
                this.Width = 1420;
                this.Location = new Point(70, 120);
                panelKurs.Location = new Point(0, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Bankverbindung"))
            {
                panelBankverbindung.Visible = true;
                this.Height = 320;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelBankverbindung.Location = new Point(5, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Pass"))
            {
                panelPass.Visible = true;
                this.Height = 340;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelPass.Location = new Point(5, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Schlüssel"))
            {
                panelSchluessel.Visible = true;
                this.Height = 400;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelSchluessel.Location = new Point(0, 70);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Gutschein"))
            {
                panelGutschein.Visible = true;
                this.Height = 300;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelGutschein.Location = new Point(5, 70);
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
                this.Height = 410;
                this.Width = 460;
                this.Location = new Point(200, 150);
                panelKursort.Location = new Point(0, 50);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Mitgliedschaft"))
            {
                panelMitgliedschaft.Visible = true;
                this.Height = 325;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelMitgliedschaft.Location = new Point(0, 50);
            }
            if (labelÜberschrift.Text.Substring(0, Convert.ToInt32(labelÜberschrift.Text.IndexOf(" "))).Equals("Kursleiter"))
            {
                panelKontaktSuche.Visible = true;
                this.Height = 450;
                this.Width = 800;
                this.Location = new Point(200, 150);
                panelKontaktSuche.Location = new Point(0, 60);
            }
            if (labelÜberschrift.Text.Equals("neue Kursbuchung"))
            {
                panelKursbuchung.Visible = true;
                this.Height = 450;
                this.Width = 630;
                this.Location = new Point(200, 150);
                panelKursbuchung.Location = new Point(-15, 60);
            }
            if (labelÜberschrift.Text.Equals("Kursbuchung bearbeiten"))
            {
                panelKursbuchung.Visible = true;
                this.Height = 450;
                this.Width = 630;
                this.Location = new Point(200, 150);
                panelKursbuchung.Location = new Point(-15, 60);
            }



        }

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

            Sozialgruppe sozialgruppe = new Sozialgruppe();
            sozialgruppe.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

            var request = new RestRequest("sozialgruppen", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(sozialgruppe);
            var response = client.Execute(request);
        }

        private void kurskategorieHinzufügen()
        {

            Kurskategorie kurskategorie = new Kurskategorie();
            kurskategorie.Bezeichnung = textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text;

            var request = new RestRequest("kurskategorien", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kurskategorie);
            var response = client.Execute(request);
        }

        private void altersgruppeHinzufügen()
        {

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

            var requestPlz = new RestRequest("postleitzahlen", Method.GET);
            requestPlz.AddHeader("Content-Type", "application/json");
            var responsePlz = client.Execute<List<Postleitzahl>>(requestPlz);

            if (panelKursort.Visible == true)
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
                kursBearbeiten();
                this.Close();
            }

            if (labelÜberschrift.Text.Equals("Kurs anlegen"))
            {
                kursHinzufügen();
                this.Close();
            }

        }

        public void kursBearbeiten()
        {

            Kurs kurs = new Kurs();
            Kurskategorie kurskategorie = new Kurskategorie();
            Kursort kursort = new Kursort();

            var requestKurskategorie = new RestRequest("kurskategorien", Method.GET);
            requestKurskategorie.AddHeader("Content-Type", "application/json");
            var responseKurskategorie = client.Execute<List<Kurskategorie>>(requestKurskategorie);

            var requestKursort = new RestRequest("kursorte", Method.GET);
            requestKursort.AddHeader("Content-Type", "application/json");
            var responseKursort = client.Execute<List<Kursort>>(requestKursort);

            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);

            foreach (Kurs k in responseKurs.Data)
            {
                if (k.KursID == Convert.ToInt32(labelID.Text))
                {
                    kurs.KursID = Convert.ToInt32(labelID.Text);
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

                    foreach (Kurskategorie kk in responseKurskategorie.Data)
                    {
                        if (kk.Bezeichnung.ToString().Equals(comboBoxKursKurskategorie.Text))
                        {
                            kurskategorie.KurskategorieID = kk.KurskategorieID;
                            kurskategorie.Bezeichnung = kk.Bezeichnung;
                        }
                    }
                    kurs.KurskategorieID = kurskategorie;

                    foreach (Kursort ko in responseKursort.Data)
                    {
                        if (ko.Bezeichnung.ToString().Equals(comboBoxKursKursort.Text))
                        {
                            kursort.KursortID = ko.KursortID;
                            kursort.Bezeichnung = ko.Bezeichnung;
                        }
                    }
                    kurs.KursortID = kursort;

                    kurs.Anmeldeschluss = dateTimePickerKursAnmeldeschluss.Value;
                    kurs.Anmerkung = textBoxKursAnmerkung.Text;

                    if (comboBoxKursAnzeigen.Text.Equals("ja"))
                        kurs.Anzeigen = true;

                    else
                        kurs.Anzeigen = false;

                    var request1 = new RestRequest("kurse", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kurs);
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

        private void kursHinzufügen()
        {

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

            if (comboBoxKursAnzeigen.Text.Equals("ja"))
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
            this.Height = 450;
            this.Width = 800;
            this.Location = new Point(200, 150);
            panelKontaktSuche.Location = new Point(0, 60);
        }

        private void listViewKontakt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((labelÜberschrift.Text.Equals("Bankverbindung bearbeiten")) || (labelÜberschrift.Text.Equals("Bankverbindung anlegen")))
            {
                textBoxBankverbindungKontaktID.Text = listViewKontakt.SelectedItems[0].SubItems[0].Text;
                panelBankverbindung.Visible = true;
                panelKontaktSuche.Visible = false;
                this.Height = 320;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelBankverbindung.Location = new Point(5, 70);
            }
            if ((labelÜberschrift.Text.Equals("Pass bearbeiten")) || (labelÜberschrift.Text.Equals("Pass anlegen")))
            {
                textBoxPassKontaktID.Text = listViewKontakt.SelectedItems[0].SubItems[0].Text;
                panelPass.Visible = true;
                panelKontaktSuche.Visible = false;
                this.Height = 340;
                this.Width = 500;
                this.Location = new Point(200, 150);
                panelPass.Location = new Point(5, 70);
            }
            if (labelÜberschrift.Text.Equals("Kursleiter bearbeiten"))
            {
                kursleiterBearbeiten();
                this.Close();
            }
            if (labelÜberschrift.Text.Equals("Kursleiter anlegen"))
            {
                kursleiterHinzufügen();
                FrmHaupt fHaupt = new FrmHaupt();
                fHaupt.kursleiterEinlesen();
                this.Close();
            }
            if ((labelÜberschrift.Text.Equals("neue Kursbuchung")) || (labelÜberschrift.Text.Equals("Kursbuchung bearbeiten")))
            {
                labelKursbuchungKontaktID.Text = listViewKontakt.SelectedItems[0].SubItems[0].Text + "";
                textBoxKursbuchungKontakt.Text = listViewKontakt.SelectedItems[0].SubItems[2].Text + " " + listViewKontakt.SelectedItems[0].SubItems[3].Text;
                panelKursbuchung.Visible = true;
                panelKontaktSuche.Visible = false;
                this.Height = 450;
                this.Width = 630;
                this.Location = new Point(200, 150);
                panelKursbuchung.Location = new Point(-15, 60);
            }

        }

        private void kursleiterBearbeiten()
        {
            Kursleiter kursleiter = new Kursleiter();
            Kontakt aktKontakt = new Kontakt();

            var requestKursleiter = new RestRequest("kursleiter", Method.GET);
            requestKursleiter.AddHeader("Content-Type", "application/json");
            var responseKursleiter = client.Execute<List<Kursleiter>>(requestKursleiter);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            foreach (Kursleiter kl in responseKursleiter.Data)
            {
                if (kl.KursleiterID == Convert.ToInt32(labelID.Text))
                {
                    kursleiter.KursleiterID = Convert.ToInt32(labelID.Text);
                    foreach (Kontakt k in responseKontakt.Data)
                    {
                        if (k.KontaktID.ToString().Equals(listViewKontakt.SelectedItems[0].SubItems[0].Text))
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
                    kursleiter.KontaktID = aktKontakt;

                    var request1 = new RestRequest("kursleiter", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kursleiter);
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

        private void kursleiterHinzufügen()
        {
            Kursleiter kursleiter = new Kursleiter();
            Kontakt aktKontakt = new Kontakt();

            var requestKursleiter = new RestRequest("kursleiter", Method.GET);
            requestKursleiter.AddHeader("Content-Type", "application/json");
            var responseKursleiter = client.Execute<List<Kursleiter>>(requestKursleiter);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            foreach (Kontakt k in responseKontakt.Data)
            {
                if (k.KontaktID.ToString().Equals(listViewKontakt.SelectedItems[0].SubItems[0].Text))
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
            kursleiter.KontaktID = aktKontakt;

            var request = new RestRequest("kursleiter", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kursleiter);
            var response = client.Execute(request);
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
            panelPass.Visible = false;
            panelKontaktSuche.Visible = true;
            this.Height = 450;
            this.Width = 800;
            this.Location = new Point(200, 150);
            panelKontaktSuche.Location = new Point(0, 60);
        }

        private void einlesenKontaktinListView()
        {
            listViewKontakt.Items.Clear();

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
                    lvItem.SubItems.Add(k.PostleitzahlID.Plz.ToString());
                    lvItem.SubItems.Add(k.PostleitzahlID.Ort.ToString());
                    lvItem.SubItems.Add(k.Strasse.ToString());
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
                    lvItem.SubItems.Add(k.PostleitzahlID.Plz.ToString());
                    lvItem.SubItems.Add(k.PostleitzahlID.Ort.ToString());
                    lvItem.SubItems.Add(k.Strasse.ToString());
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



        private void kassabuchkontoHinzufügen()
        {

            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();

            kassabuchkonto.Kontonummer = textBoxKontonummer.Text;
            kassabuchkonto.Kontobezeichnung = textBoxKontobezeichnung.Text;
            kassabuchkonto.Kontostand = Convert.ToDouble(textBoxKontostand.Text);



            var request = new RestRequest("kassabuchkonten", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kassabuchkonto);
            var response = client.Execute(request);

            MessageBox.Show("Das Kassabuchkonto wurde erfolgreich hinzugefügt");
        }

        private void kassabuchkontoBearbeiten()
        {

            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();

            var request = new RestRequest("kassabuchkonten", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kassabuchkonto>>(request);

            int inde = textBoxKontostand.Text.Length - 2;

            foreach (Kassabuchkonto k in response.Data)
            {
                if (k.KassabuchkontoID == Convert.ToInt32(labelID.Text))
                {
                    kassabuchkonto.KassabuchkontoID = Convert.ToInt32(labelID.Text);
                    kassabuchkonto.Kontonummer = textBoxKontonummer.Text;
                    kassabuchkonto.Kontobezeichnung = textBoxKontobezeichnung.Text;
                    kassabuchkonto.Kontostand = Convert.ToDouble(textBoxKontostand.Text.Substring(2, inde));



                    var request1 = new RestRequest("kassabuchkonten", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kassabuchkonto);
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




        private void btnKassabuchkontoSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Kassabuchkonto bearbeiten"))
            {
                kassabuchkontoBearbeiten();
                this.Close();
            }
            else
            {
                kassabuchkontoHinzufügen();
                this.Close();
            }


        }



        private void kassabuchHinzufügen()
        {

            Kassabuch kassabuch = new Kassabuch();
            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();

            var request1 = new RestRequest("kontakte", Method.GET);
            request1.AddHeader("Content-Type", "application/json");
            var response1 = client.Execute<List<Kontakt>>(request1);




            Kontakt kontakt = new Kontakt();

            foreach (Kontakt k in response1.Data)
            {
                if (k.KontaktID.ToString().Equals(comboBoxKontaktID.Text))
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

            kassabuch.KontaktID = kontakt;


            var requestKassabuchkonto = new RestRequest("kassabuchkonten", Method.GET);
            requestKassabuchkonto.AddHeader("Content-Type", "application/json");
            var responseKassabuchkonto = client.Execute<List<Kassabuchkonto>>(requestKassabuchkonto);



            foreach (Kassabuchkonto k in responseKassabuchkonto.Data)
            {
                if (k.KassabuchkontoID.ToString().Equals(comboBoxKassabuchkontoID.Text))
                {
                    kassabuchkonto.KassabuchkontoID = k.KassabuchkontoID;
                    kassabuchkonto.Kontonummer = k.Kontonummer;
                    kassabuchkonto.Kontobezeichnung = k.Kontobezeichnung;
                    kassabuchkonto.Kontostand = k.Kontostand;
                }
            }

            kassabuch.KassabuchkontoID = kassabuchkonto;




            kassabuch.Datum = dateTimePickerKassabuch.Value;



            kassabuch.Buchungstext = textBoxBuchungstext.Text;
            kassabuch.Betrag = Convert.ToDouble(textBoxBetrag.Text);

            int inde = comboBoxKontaktID.Text.IndexOf(" ");
            int id = Convert.ToInt32(comboBoxKontaktID.Text.Substring(0, inde));

            kassabuch.KontaktID.KontaktID = id;

            int inde2 = comboBoxKassabuchkontoID.Text.IndexOf(" ");
            int id2 = Convert.ToInt32(comboBoxKassabuchkontoID.Text.Substring(0, inde2));

            kassabuch.KassabuchkontoID.KassabuchkontoID = id2;


            geldeinzahlenhinzufügen();

            var request = new RestRequest("kassabuecher", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kassabuch);
            var response = client.Execute(request);



            MessageBox.Show("Das Kassabuch wurde erfolgreich hinzugefügt");
        }

        private void geldeinzahlenhinzufügen()
        {
            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();

            var request = new RestRequest("kassabuchkonten", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kassabuchkonto>>(request);

            Kassabuch kassabuch = new Kassabuch();

            var requestkassabuch = new RestRequest("kassabuecher", Method.GET);
            requestkassabuch.AddHeader("Content-Type", "application/json");
            var responsekassabuch = client.Execute<List<Kassabuch>>(requestkassabuch);

            int inde = comboBoxKassabuchkontoID.Text.IndexOf(" ");


            foreach (Kassabuchkonto k in response.Data)
            {
                if (k.KassabuchkontoID == Convert.ToInt32(comboBoxKassabuchkontoID.Text.Substring(0, inde)))
                {
                    kassabuchkonto.KassabuchkontoID = k.KassabuchkontoID;
                    kassabuchkonto.Kontonummer = k.Kontonummer;
                    kassabuchkonto.Kontobezeichnung = k.Kontobezeichnung;
                    kassabuchkonto.Kontostand = k.Kontostand + Convert.ToDouble(textBoxBetrag.Text);



                    var request1 = new RestRequest("kassabuchkonten", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kassabuchkonto);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void geldeinzahlenbearbeiten()
        {
            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();

            var request = new RestRequest("kassabuchkonten", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kassabuchkonto>>(request);

            Kassabuch kassabuch = new Kassabuch();

            var requestkassabuch = new RestRequest("kassabuecher", Method.GET);
            requestkassabuch.AddHeader("Content-Type", "application/json");
            var responsekassabuch = client.Execute<List<Kassabuch>>(requestkassabuch);

            int inde = comboBoxKassabuchkontoID.Text.IndexOf(" ");

            int inde2 = textBoxBetrag.Text.Length - 2;

            foreach (Kassabuchkonto k in response.Data)
            {
                if (k.KassabuchkontoID == Convert.ToInt32(comboBoxKassabuchkontoID.Text.Substring(0, inde)))
                {
                    kassabuchkonto.KassabuchkontoID = k.KassabuchkontoID;
                    kassabuchkonto.Kontonummer = k.Kontonummer;
                    kassabuchkonto.Kontobezeichnung = k.Kontobezeichnung;
                    kassabuchkonto.Kontostand = k.Kontostand + Convert.ToDouble(textBoxBetrag.Text.Substring(2, inde2));



                    var request1 = new RestRequest("kassabuchkonten", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kassabuchkonto);
                    var response1 = client.Execute(request1);

                    if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("An error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        private void kassabuchBearbeiten()
        {

            Kassabuch kassabuch = new Kassabuch();
            Kassabuchkonto kassabuchkonto = new Kassabuchkonto();
            Kontakt kontakt = new Kontakt();

            var requestKassabuch = new RestRequest("kassabuecher", Method.GET);
            requestKassabuch.AddHeader("Content-Type", "application/json");
            var responseKassabuch = client.Execute<List<Kassabuch>>(requestKassabuch);



            var requestKassabuchkonto = new RestRequest("kassabuchkonten", Method.GET);
            requestKassabuchkonto.AddHeader("Content-Type", "application/json");
            var responseKassabuchkonto = client.Execute<List<Kassabuchkonto>>(requestKassabuchkonto);



            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);



            foreach (Kassabuch k in responseKassabuch.Data)
            {


                if (k.KassabuchID == Convert.ToInt32(labelID.Text))
                {
                    kassabuch.KassabuchID = Convert.ToInt32(labelID.Text);

                    kassabuch.Buchungstext = textBoxBuchungstext.Text;
                    kassabuch.Betrag = Convert.ToDouble(textBoxBetrag.Text.Substring(2, 5));






                    int inde = comboBoxKontaktID.Text.IndexOf(" ");


                    foreach (Kontakt kk in responseKontakt.Data)
                    {



                        if (kk.KontaktID.ToString().Equals(Convert.ToInt32(comboBoxKontaktID.Text.Substring(0, inde))))
                        {
                            kontakt.KontaktID = kk.KontaktID;
                            kontakt.TitelID = kk.TitelID;
                            kontakt.Vorname = kk.Vorname;
                            kontakt.Nachname = kk.Nachname;
                            kontakt.SVNr = kk.SVNr;
                            kontakt.Geschlecht = kk.Geschlecht;
                            kontakt.Familienstand = kk.Familienstand;
                            kontakt.Email = kk.Email;
                            kontakt.Telefonnummer = kk.Telefonnummer;
                            kontakt.Strasse = kk.Strasse;
                            kontakt.PostleitzahlID = kk.PostleitzahlID;
                            kontakt.AltersgruppeID = kk.AltersgruppeID;
                            kontakt.SozialgruppeID = kk.SozialgruppeID;
                            kontakt.StaatsbuergerschaftID = kk.StaatsbuergerschaftID;
                        }
                    }





                    kassabuch.KontaktID = kontakt;

                    int inde2 = comboBoxKontaktID.Text.IndexOf(" ");

                    foreach (Kassabuchkonto kkk in responseKassabuchkonto.Data)
                    {
                        if (kkk.KassabuchkontoID.ToString().Equals(Convert.ToInt32(comboBoxKassabuchkontoID.Text.Substring(0, inde2))))
                        {
                            kassabuchkonto.KassabuchkontoID = kkk.KassabuchkontoID;
                            kassabuchkonto.Kontonummer = kkk.Kontonummer;
                            kassabuchkonto.Kontobezeichnung = kkk.Kontobezeichnung;
                            kassabuchkonto.Kontostand = kkk.Kontostand;

                        }
                    }

                    kassabuch.KassabuchkontoID = kassabuchkonto;




                    int inde3 = comboBoxKontaktID.Text.IndexOf(" ");
                    int id = Convert.ToInt32(comboBoxKontaktID.Text.Substring(0, inde3));

                    kassabuch.KontaktID.KontaktID = id;



                    int inde4 = comboBoxKassabuchkontoID.Text.IndexOf(" ");
                    int id2 = Convert.ToInt32(comboBoxKassabuchkontoID.Text.Substring(0, inde4));

                    kassabuch.KassabuchkontoID.KassabuchkontoID = id2;



                    kassabuch.Datum = dateTimePickerKassabuch.Value;



                    geldeinzahlenbearbeiten();


                    var request1 = new RestRequest("kassabuecher", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kassabuch);
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

        private void buttonKassabuchSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Kassabuch bearbeiten"))
            {
                kassabuchBearbeiten();
                this.Close();
            }
            else
            {
                kassabuchHinzufügen();
                this.Close();
            }
        }

        private void buttonKursSuchen_Click(object sender, EventArgs e)
        {
            listViewKurs.Items.Clear();

            string bezeichnung = textBoxKursSucheBezeichnung.Text;
            string kurskategorie = comboBoxKursSucheKurskategorie.Text;
            int bezL = textBoxKursSucheBezeichnung.Text.Length;
            int kurskatL = comboBoxKursSucheKurskategorie.Text.Length;

            var request = new RestRequest("kurse", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kurs>>(request);

            foreach (Kurs k in response.Data)
            {
                if ((k.Bezeichnung.ToLower().Substring(0, bezL).Equals(bezeichnung)) && (k.KurskategorieID.Bezeichnung.ToLower().Substring(0, kurskatL).Equals(kurskategorie)))
                {
                    ListViewItem lvItem = new ListViewItem(k.KursID.ToString());
                    lvItem.SubItems.Add(k.Bezeichnung.ToString());
                    lvItem.SubItems.Add(k.KurskategorieID.Bezeichnung.ToString());
                    lvItem.SubItems.Add(k.Seminarnummer.ToString());
                    listViewKurs.Items.Add(lvItem);
                }
                else if ((k.Bezeichnung.Substring(0, bezL).Equals(bezeichnung)) && (k.KurskategorieID.Bezeichnung.Substring(0, kurskatL).Equals(kurskategorie)))
                {
                    ListViewItem lvItem = new ListViewItem(k.KursID.ToString());
                    lvItem.SubItems.Add(k.Bezeichnung.ToString());
                    lvItem.SubItems.Add(k.KurskategorieID.Bezeichnung.ToString());
                    lvItem.SubItems.Add(k.Seminarnummer.ToString());
                    listViewKurs.Items.Add(lvItem);
                }
            }
        }

        private void buttonKursleiterSuchen_Click(object sender, EventArgs e)
        {
            listViewKursleiter.Items.Clear();
            string vorname = textBoxKursleiterSucheVorname.Text;
            string nachname = textBoxKursleiterSucheNachname.Text;

            int vornL = textBoxKursleiterSucheVorname.Text.Length;
            int nachL = textBoxKursleiterSucheNachname.Text.Length;

            var request = new RestRequest("kursleiter", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kursleiter>>(request);



            foreach (Kursleiter k in response.Data)
            {
                if ((k.KontaktID.Vorname.ToLower().Substring(0, vornL).Equals(vorname)) && (k.KontaktID.Nachname.ToLower().Substring(0, nachL).Equals(nachname)))
                {
                    ListViewItem lvItem = new ListViewItem(k.KursleiterID.ToString());
                    lvItem.SubItems.Add(k.KontaktID.Vorname.ToString());
                    lvItem.SubItems.Add(k.KontaktID.Nachname.ToString());
                    lvItem.SubItems.Add(k.KontaktID.PostleitzahlID.Plz.ToString());
                    lvItem.SubItems.Add(k.KontaktID.PostleitzahlID.Ort.ToString());
                    lvItem.SubItems.Add(k.KontaktID.Strasse.ToString());
                    listViewKursleiter.Items.Add(lvItem);
                }
                else if ((k.KontaktID.Vorname.Substring(0, vornL).Equals(vorname)) && (k.KontaktID.Nachname.Substring(0, nachL).Equals(nachname)))
                {
                    ListViewItem lvItem = new ListViewItem(k.KursleiterID.ToString());
                    lvItem.SubItems.Add(k.KontaktID.Vorname.ToString());
                    lvItem.SubItems.Add(k.KontaktID.Nachname.ToString());
                    lvItem.SubItems.Add(k.KontaktID.PostleitzahlID.Plz.ToString());
                    lvItem.SubItems.Add(k.KontaktID.PostleitzahlID.Ort.ToString());
                    lvItem.SubItems.Add(k.KontaktID.Strasse.ToString());
                    listViewKursleiter.Items.Add(lvItem);
                }
            }
        }

        private void linkLabelKursleiterAuswaehlen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelKursleiterSuche.Visible = true;
            panelKurs.Visible = false;

            listViewKursleiter.Items.Clear();

            var request = new RestRequest("kursleiter", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kursleiter>>(request);

            foreach (Kursleiter k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KursleiterID.ToString());
                lvItem.SubItems.Add(k.KontaktID.Vorname.ToString());
                lvItem.SubItems.Add(k.KontaktID.Nachname.ToString());
                lvItem.SubItems.Add(k.KontaktID.PostleitzahlID.Plz.ToString());
                lvItem.SubItems.Add(k.KontaktID.PostleitzahlID.Ort.ToString());
                lvItem.SubItems.Add(k.KontaktID.Strasse.ToString());
                listViewKursleiter.Items.Add(lvItem);
            }
        }

        private void linkLabelKontaktAuswaehlen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelKontaktSuche.Visible = true;
            panelKursbuchung.Visible = false;

            listViewKontakt.Items.Clear();

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

            panelKontaktSuche.Visible = true;
            this.Height = 450;
            this.Width = 800;
            this.Location = new Point(200, 150);
            panelKontaktSuche.Location = new Point(0, 60);

        }

        private void linkLabelKursAuswaehlen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelKursSuche.Visible = false;
            panelKursbuchung.Visible = false;

            listViewKurs.Items.Clear();

            var request = new RestRequest("kurse", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kurs>>(request);

            foreach (Kurs k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KursID.ToString());
                lvItem.SubItems.Add(k.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.KurskategorieID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Seminarnummer.ToString());
                listViewKurs.Items.Add(lvItem);
            }

            panelKursSuche.Visible = true;
            this.Height = 450;
            this.Width = 950;
            this.Location = new Point(200, 150);
            panelKursSuche.Location = new Point(0, 60);
        }

        private void listViewKursleiter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKursleiter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxKursleiterName.Text = listViewKursleiter.SelectedItems[0].SubItems[1].Text.ToString() + " " + listViewKursleiter.SelectedItems[0].SubItems[2].Text.ToString();
            labelKursleiterID.Text = listViewKursleiter.SelectedItems[0].SubItems[0].Text.ToString();
            panelKursleiterSuche.Visible = false;
            panelKurs.Visible = true;
        }

        private void listViewKurs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            labelKursbuchungKursID.Text = listViewKurs.SelectedItems[0].SubItems[0].Text;
            textBoxKursbuchungKurs.Text = listViewKurs.SelectedItems[0].SubItems[1].Text;
            panelKursbuchung.Visible = true;
            panelKursSuche.Visible = false;
            this.Height = 450;
            this.Width = 630;
            this.Location = new Point(200, 150);
            panelKursbuchung.Location = new Point(-15, 60);
        }

        private void textBoxKursbuchungKontakt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxKursbuchungKurs_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxKursbuchungBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKursbuchungBonus.Text.Equals("ja"))
            {
                textBoxKursbuchungPreis.Text = (Convert.ToDouble(labelKursbuchungPreisOhneAbzug.Text) / 100 * (100 - Convert.ToDouble(labelKursbuchungProzent.Text))).ToString();
            }
            else
            {
                textBoxKursbuchungPreis.Text = labelKursbuchungPreisOhneAbzug.Text;
            }
        }

        private void buttonKursbuchungAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKursbuchungSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("neue Kursbuchung"))
            {
                //kursbuchungHinzufügen();
                this.Close();
            }
            if (labelÜberschrift.Text.Equals("Kursbuchung bearbeiten"))
            {
                //kursbuchungBearbeiten();
                this.Close();
            }
        }

        private void kursbuchungHinzufügen()
        {
            KontaktKurs kontaktKurs = new KontaktKurs();
            Kontakt kontakt = new Kontakt();
            Kurs kurs = new Kurs();

            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            kontaktKurs.Buchungsdatum = dateTimePickerKursbuchungDatum.Value;
            //kontaktKurs.Bezahlt = 
            kontaktKurs.NeuerPreis = Convert.ToDouble(textBoxKursbuchungPreis.Text);

            foreach (Kontakt k in responseKontakt.Data)
            {
                if (k.KontaktID.ToString().Equals(labelKursbuchungKontaktID.Text))
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

            kontaktKurs.KontakID = kontakt;

            foreach(Kurs k in responseKurs.Data)
            {
                if(k.KursortID.ToString().Equals(labelKursbuchungKursID.Text))
                {
                    kurs.KursID = k.KursID;
                    kurs.Bezeichnung = k.Bezeichnung;
                    kurs.Preis = k.Preis;
                    kurs.MinTeilnehmer = k.MinTeilnehmer;
                    kurs.MaxTeilnehmer = k.MaxTeilnehmer;
                    kurs.AnzEinheiten = k.AnzEinheiten;
                    kurs.Verbindlichkeit = k.Verbindlichkeit;
                    kurs.Foerderung = k.Foerderung;
                    kurs.Status = k.Status;
                    kurs.Beschreibung = k.Beschreibung;
                    kurs.ZeitVon = k.ZeitVon;
                    kurs.ZeitBis = k.ZeitBis;
                    kurs.DatumVon = k.DatumVon;
                    kurs.DatumBis = k.DatumBis;
                    kurs.Seminarnummer = k.Seminarnummer;
                    kurs.KurskategorieID = k.KurskategorieID;
                    kurs.KursortID = k.KursortID;
                    kurs.Anmeldeschluss = k.Anmeldeschluss;
                    kurs.Anmerkung = k.Anmerkung;
                    kurs.Anzeigen = k.Anzeigen;
                }
            }
            kontaktKurs.KursID = kurs;

            var request = new RestRequest("kontaktKurse", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(kontaktKurs);
            var response = client.Execute(request);
        }

        private void kursbuchungBearbeiten()
        {
            KontaktKurs kontaktKurs = new KontaktKurs();
            Kontakt kontakt = new Kontakt();
            Kurs kurs = new Kurs();

            var requestKontaktKurs = new RestRequest("kontaktKurse", Method.GET);
            requestKontaktKurs.AddHeader("Content-Type", "application/json");
            var responseKontaktKurs = client.Execute<List<KontaktKurs>>(requestKontaktKurs);

            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            foreach(KontaktKurs kk in responseKontaktKurs.Data)
            {
                if(kk.KontaktKursID.ToString().Equals(labelID.Text))
                {
                    kontaktKurs.KontaktKursID = Convert.ToInt32(labelID.Text);
                    kontaktKurs.Buchungsdatum = dateTimePickerKursbuchungDatum.Value;
                    //kontaktKurs.Bezahlt = 
                    kontaktKurs.NeuerPreis = Convert.ToDouble(textBoxKursbuchungPreis.Text);
                    
                    foreach(Kontakt k in responseKontakt.Data)
                    {
                        if(k.KontaktID.ToString().Equals(labelKursbuchungKontaktID.Text))
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

                    kontaktKurs.KontakID = kontakt;

                    foreach (Kurs k in responseKurs.Data)
                    {
                        if (k.KursortID.ToString().Equals(labelKursbuchungKursID.Text))
                        {
                            kurs.KursID = k.KursID;
                            kurs.Bezeichnung = k.Bezeichnung;
                            kurs.Preis = k.Preis;
                            kurs.MinTeilnehmer = k.MinTeilnehmer;
                            kurs.MaxTeilnehmer = k.MaxTeilnehmer;
                            kurs.AnzEinheiten = k.AnzEinheiten;
                            kurs.Verbindlichkeit = k.Verbindlichkeit;
                            kurs.Foerderung = k.Foerderung;
                            kurs.Status = k.Status;
                            kurs.Beschreibung = k.Beschreibung;
                            kurs.ZeitVon = k.ZeitVon;
                            kurs.ZeitBis = k.ZeitBis;
                            kurs.DatumVon = k.DatumVon;
                            kurs.DatumBis = k.DatumBis;
                            kurs.Seminarnummer = k.Seminarnummer;
                            kurs.KurskategorieID = k.KurskategorieID;
                            kurs.KursortID = k.KursortID;
                            kurs.Anmeldeschluss = k.Anmeldeschluss;
                            kurs.Anmerkung = k.Anmerkung;
                            kurs.Anzeigen = k.Anzeigen;
                        }
                    }
                    kontaktKurs.KursID = kurs;

                    var request1 = new RestRequest("kontaktKurse", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(kontaktKurs);
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

        private void labelKursbuchungKursID_TextChanged(object sender, EventArgs e)
        {
            Kurs kurs = new Kurs();

            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);

            foreach (Kurs k in responseKurs.Data)
            {
                if (k.KursID.ToString().Equals(labelKursbuchungKursID.Text))
                {
                    textBoxKursbuchungPreis.Text = k.Preis.ToString();
                    labelKursbuchungPreisOhneAbzug.Text = k.Preis.ToString();
                }
            }
        }

        private void labelKursbuchungKontaktID_TextChanged(object sender, EventArgs e)
        {
            MitgliedschaftKontakt mitgliedschaftKontakt = new MitgliedschaftKontakt();

            var request1 = new RestRequest("mitgliedschaftKontakte", Method.GET);
            request1.AddHeader("Content-Type", "application/json");
            var response1 = client.Execute<List<MitgliedschaftKontakt>>(request1);

            foreach (MitgliedschaftKontakt mk in response1.Data)
            {
                if (labelKursbuchungKontaktID.Text.Equals(mk.KontaktID.KontaktID.ToString()))
                {
                    labelKursbuchungProzent.Text = mk.MitgliedschaftID.Ermaessigung.ToString();
                    textBoxKursbuchungMitglied.Text = "ja";
                }
                else
                {
                    textBoxKursbuchungMitglied.Text = "nein";
                }
            }

            if (textBoxKursbuchungMitglied.Text.Equals("ja"))
            {
                comboBoxKursbuchungBonus.Visible = true;
            }
            else
            {
                comboBoxKursbuchungBonus.Visible = false;
            }
        }

        private void rechnungHinzufügen()
        {

            Rechnung rechnung = new Rechnung();
            Kurs kurs = new Kurs();

            var request1 = new RestRequest("kontakte", Method.GET);
            request1.AddHeader("Content-Type", "application/json");
            var response1 = client.Execute<List<Kontakt>>(request1);




            Kontakt kontakt = new Kontakt();

            foreach (Kontakt k in response1.Data)
            {
                if (k.KontaktID.ToString().Equals(comboBoxRechnungKontaktID.Text))
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

            rechnung.KontaktID = kontakt;


            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);



            foreach (Kurs rk in responseKurs.Data)
            {
                if (rk.KursID.ToString().Equals(comboBoxRechnungKursID.Text))
                {
                    kurs.KursID = rk.KursID;
                    

                }
            }

            rechnung.KursID = kurs;


            rechnung.Rechnungsdatum = dateTimePickerRechnungsdatum.Value;



            rechnung.Rechnungsnummer = textBoxRechnungsnummer.Text;
            

            int inde = comboBoxRechnungKontaktID.Text.IndexOf(" ");
            int id = Convert.ToInt32(comboBoxRechnungKontaktID.Text.Substring(0, inde));

            rechnung.KontaktID.KontaktID = id;

            int inde2 = comboBoxRechnungKursID.Text.IndexOf(" ");
            int id2 = Convert.ToInt32(comboBoxRechnungKursID.Text.Substring(0, inde2));

            rechnung.KursID.KursID = id2;


            var request = new RestRequest("rechnungen", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(rechnung);
            var response = client.Execute(request);



            MessageBox.Show("Die Rechnung wurde erfolgreich hinzugefügt");
        }

        private void rechnungBearbeiten()
        {

            Rechnung rechnung = new Rechnung();
            Kurs kurs = new Kurs();
            Kontakt kontakt = new Kontakt();

            var requestRechnung = new RestRequest("rechnungen", Method.GET);
            requestRechnung.AddHeader("Content-Type", "application/json");
            var responseRechnung = client.Execute<List<Rechnung>>(requestRechnung);



            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);



            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);



            foreach (Rechnung r in responseRechnung.Data)
            {


                if (r.RechnungID == Convert.ToInt32(labelID.Text))
                {
                    rechnung.RechnungID = Convert.ToInt32(labelID.Text);

                    rechnung.Rechnungsnummer = textBoxRechnungsnummer.Text;
                    






                    int inde = comboBoxRechnungKontaktID.Text.IndexOf(" ");


                    foreach (Kontakt kk in responseKontakt.Data)
                    {



                        if (kk.KontaktID.ToString().Equals(Convert.ToInt32(comboBoxRechnungKontaktID.Text.Substring(0, inde))))
                        {
                            kontakt.KontaktID = kk.KontaktID;
                            kontakt.TitelID = kk.TitelID;
                            kontakt.Vorname = kk.Vorname;
                            kontakt.Nachname = kk.Nachname;
                            kontakt.SVNr = kk.SVNr;
                            kontakt.Geschlecht = kk.Geschlecht;
                            kontakt.Familienstand = kk.Familienstand;
                            kontakt.Email = kk.Email;
                            kontakt.Telefonnummer = kk.Telefonnummer;
                            kontakt.Strasse = kk.Strasse;
                            kontakt.PostleitzahlID = kk.PostleitzahlID;
                            kontakt.AltersgruppeID = kk.AltersgruppeID;
                            kontakt.SozialgruppeID = kk.SozialgruppeID;
                            kontakt.StaatsbuergerschaftID = kk.StaatsbuergerschaftID;
                        }
                    }




                    rechnung.KontaktID = kontakt;

                    int inde2 = comboBoxRechnungKursID.Text.IndexOf(" ");

                    foreach (Kurs rk in responseKurs.Data)
                    {
                        if (rk.KursID.ToString().Equals(Convert.ToInt32(comboBoxRechnungKursID.Text.Substring(0, inde2))))
                        {
                            kurs.KursID = rk.KursID;

                        }
                    }

                    rechnung.KursID = kurs;




                    int inde3 = comboBoxRechnungKontaktID.Text.IndexOf(" ");
                    int id = Convert.ToInt32(comboBoxRechnungKontaktID.Text.Substring(0, inde3));

                    rechnung.KontaktID.KontaktID = id;



                    int inde4 = comboBoxRechnungKursID.Text.IndexOf(" ");
                    int id2 = Convert.ToInt32(comboBoxRechnungKursID.Text.Substring(0, inde4));

                    rechnung.KursID.KursID = id2;



                    rechnung.Rechnungsdatum = dateTimePickerRechnungsdatum.Value;






                    var request1 = new RestRequest("rechnungen", Method.PUT);
                    request1.AddHeader("Content-Type", "application/json");
                    request1.AddJsonBody(rechnung);
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

        private void btnRechnungSpeichern_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Rechnung bearbeiten"))
            {
                rechnungBearbeiten();
                this.Close();
            }
            else
            {
                rechnungHinzufügen();
                this.Close();
            }
        }

    }
}
