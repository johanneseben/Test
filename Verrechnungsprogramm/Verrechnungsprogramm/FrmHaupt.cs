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
    public partial class FrmHaupt : Form
    {
        RestClient client;
        HttpBasicAuthenticator Authenticator;

        public FrmHaupt()
        {
            InitializeComponent();
            //client = new RestClient("http://localhost:8888")
            client = new RestClient("http://vhs-mistelbach.projects.hakmistelbach.ac.at:20218")
            {
                Authenticator = new HttpBasicAuthenticator("demo", "demo")
            };
        }

        private void frmHaupt_Load(object sender, EventArgs e)
        {
            listViewAltersgruppe.FullRowSelect = true;
            listViewSozialgruppe.FullRowSelect = true;
            listViewKontakt.FullRowSelect = true;
            listViewTitel.FullRowSelect = true;
            listViewKurs.FullRowSelect = true;
            listViewKurskategorie.FullRowSelect = true;
            listViewBankverbindung.FullRowSelect = true;
            listViewPass.FullRowSelect = true;
            listViewGutschein.FullRowSelect = true;
            listViewMitgliedschaft.FullRowSelect = true;
            listViewSchluessel.FullRowSelect = true;
            listViewKassabuchkonto.FullRowSelect = true;
            listViewKassabuch.FullRowSelect = true;
            listViewRechnung.FullRowSelect = true;
            listViewKursleiter.FullRowSelect = true;
            listViewKursort.FullRowSelect = true;
            listViewKursbuchung.FullRowSelect = true;
            listViewSchluesselverwaltung.FullRowSelect = true;

            listViewKursbuchung.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewKurs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Titel";
            labelBtTitel.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            listViewTitel.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            titelEinlesen();
        }

        private void titelEinlesen()
        {
            FrmHinzufügenBearbeiten fHinzuBearb = new FrmHinzufügenBearbeiten();
            listViewTitel.Items.Clear();

            var request = new RestRequest("titel", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Titel>>(request);

            foreach (Titel t in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(t.TitelID.ToString());
                lvItem.SubItems.Add(t.Bezeichnung.ToString());
                lvItem.SubItems.Add(t.Vorgestellt.ToString());
                listViewTitel.Items.Add(lvItem);
            }
        }

        private void sozialgruppeEinlesen()
        {
            listViewSozialgruppe.Items.Clear();

            var request = new RestRequest("sozialgruppen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Sozialgruppe>>(request);

            foreach (Sozialgruppe s in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(s.SozialgruppeID.ToString());
                lvItem.SubItems.Add(s.Bezeichnung.ToString());
                listViewSozialgruppe.Items.Add(lvItem);
            }
        }

        private void allesVisibleFalseSetzen()
        {
            labelBtKontakt.Visible = false;
            listViewAltersgruppe.Visible = false;
            labelBtAltersgruppe.Visible = false;
            labelBtTitel.Visible = false;
            listViewSozialgruppe.Visible = false;
            listViewTitel.Visible = false;
            tableLayoutPanelStammdaten.Visible = false;
            listViewKontakt.Visible = false;
            labelBtKontakt.Visible = false;
            labelBtTitel.Visible = false;
            buttonBearbeiten.Visible = false;
            buttonHinzufügen.Visible = false;
            labelBtSozialgruppe.Visible = false;
            labelBtKurs.Visible = false;
            labelBtKurskategorie.Visible = false;
            labelBtTermin.Visible = false;
            tableLayoutPanelKursTermin.Visible = false;
            listViewKurs.Visible = false;
            listViewKurskategorie.Visible = false;
            labelBtKursTermin.Visible = false;
            labelBtBankverbindung.Visible = false;
            listViewBankverbindung.Visible = false;
            labelBtPass.Visible = false;
            listViewPass.Visible = false;
            labelBtGutschein.Visible = false;
            listViewSchluessel.Visible = false;
            labelBtSchluessel.Visible = false;
            listViewGutschein.Visible = false;
            listViewMitgliedschaft.Visible = false;
            labelBtMitgliedschaft.Visible = false;
            labelBtSchluesselverwaltung.Visible = false;
            tableLayoutPanelFinanz.Visible = false;
            labelBtKassabuch.Visible = false;
            labelBtKassabuchkonto.Visible = false;
            labelBtRechnung.Visible = false;
            listViewKassabuchkonto.Visible = false;
            listViewKassabuch.Visible = false;
            listViewRechnung.Visible = false;
            labelBtKursbuchung.Visible = false;
            labelBtTeilnehmer.Visible = false;
            labelBtKursleiter.Visible = false;
            labelBtKursort.Visible = false;
            labelBtOffeneRechnungen.Visible = false;
            listViewTeilnehmer.Visible = false;
            listViewKursleiter.Visible = false;
            listViewOffeneRechnung.Visible = false;
            listViewKursort.Visible = false;
            comboBoxKursTeilnehmer.Visible = false;
            labelKurs.Visible = false;
            labelKursleiter.Visible = false;
            textBoxKursleiter.Visible = false;
            labelKursbuchungVon.Visible = false;
            labelKursbuchungBis.Visible = false;
            dateTimePickerKursbuchungBis.Visible = false;
            dateTimePickerKursbuchungVon.Visible = false;
            buttonKursbuchungSuchen.Visible = false;
            listViewKursbuchung.Visible = false;
            buttonNeueKursbuchung.Visible = false;
            buttonKursbuchungBearbeiten.Visible = false;
            btnRechnungdrucken.Visible = false;
            listViewSchluesselverwaltung.Visible = false;
        }

        private void buttonKontakt_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kontakt";
            listViewKontakt.Visible = true;
            labelBtKontakt.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            kontakteEinlesen();
        }

        private void kurskategorieEinlesen()
        {
            listViewKurskategorie.Items.Clear();

            var request = new RestRequest("kurskategorien", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kurskategorie>>(request);

            foreach (Kurskategorie kk in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(kk.KurskategorieID.ToString());
                lvItem.SubItems.Add(kk.Bezeichnung.ToString());

                listViewKurskategorie.Items.Add(lvItem);
            }
        }

        private void kurseEinlesen()
        {
            string neinja;
            listViewKurs.Items.Clear();

            var request = new RestRequest("kurse", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kurs>>(request);

            foreach (Kurs k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KursID.ToString());
                lvItem.SubItems.Add(k.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Preis.ToString());
                lvItem.SubItems.Add(k.MinTeilnehmer.ToString());
                lvItem.SubItems.Add(k.MaxTeilnehmer.ToString());
                lvItem.SubItems.Add(k.AnzEinheiten.ToString());
                if (k.Verbindlichkeit == true)
                    neinja = "ja";

                else
                    neinja = "nein";

                lvItem.SubItems.Add(neinja.ToString());
                lvItem.SubItems.Add(k.Foerderung.ToString());
                lvItem.SubItems.Add(k.Status.ToString());
                lvItem.SubItems.Add(k.Beschreibung.ToString());
                lvItem.SubItems.Add(k.ZeitVon.ToShortTimeString());
                lvItem.SubItems.Add(k.ZeitBis.ToShortTimeString());
                lvItem.SubItems.Add(k.DatumVon.ToShortDateString());
                lvItem.SubItems.Add(k.DatumBis.ToShortDateString());
                lvItem.SubItems.Add(k.Seminarnummer.ToString());
                lvItem.SubItems.Add(k.KurskategorieID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.KursortID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Anmeldeschluss.ToShortDateString());
                lvItem.SubItems.Add(k.Anmerkung.ToString());
                if (k.Anzeigen == true)
                    neinja = "ja";

                else
                    neinja = "nein";
                lvItem.SubItems.Add(neinja.ToString());

                listViewKurs.Items.Add(lvItem);
            }
        }

        public void altersgruppenEinlesen()
        {
            listViewAltersgruppe.Items.Clear();

            var request = new RestRequest("altersgruppen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Altersgruppe>>(request);

            foreach (Altersgruppe a in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(a.AltersgruppeID.ToString());
                lvItem.SubItems.Add(a.Bezeichnung.ToString());
                listViewAltersgruppe.Items.Add(lvItem);
            }
        }

        private void passEinlesen()
        {
            listViewPass.Items.Clear();

            var request = new RestRequest("paesse", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Pass>>(request);

            foreach (Pass p in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(p.PassID.ToString());
                lvItem.SubItems.Add(p.KontaktID.KontaktID.ToString());
                lvItem.SubItems.Add(p.PassNr.ToString());
                lvItem.SubItems.Add(p.PassBeginn.ToString());
                lvItem.SubItems.Add(p.PassEnde.ToString());
                listViewPass.Items.Add(lvItem);
            }
        }

        private void bankverbindungEinlesen()
        {
            listViewBankverbindung.Items.Clear();

            var request = new RestRequest("bankverbindungen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Bankverbindung>>(request);

            foreach (Bankverbindung b in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(b.BankverbindungID.ToString());
                lvItem.SubItems.Add(b.IBAN.ToString());
                lvItem.SubItems.Add(b.Kontoinhaber.ToString());
                lvItem.SubItems.Add(b.KontaktID.KontaktID.ToString());
                listViewBankverbindung.Items.Add(lvItem);
            }
        }

        private void kontakteEinlesen()
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
                lvItem.SubItems.Add(k.SVNr.ToString());
                lvItem.SubItems.Add(k.Geschlecht.ToString());
                lvItem.SubItems.Add(k.Familienstand.ToString());
                lvItem.SubItems.Add(k.Email.ToString());
                lvItem.SubItems.Add(k.Telefonnummer.ToString());
                lvItem.SubItems.Add(k.PostleitzahlID.Plz.ToString());
                lvItem.SubItems.Add(k.PostleitzahlID.Ort.ToString());
                lvItem.SubItems.Add(k.Strasse.ToString());
                lvItem.SubItems.Add(k.AltersgruppeID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.SozialgruppeID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.StaatsbuergerschaftID.Staat.ToString());

                listViewKontakt.Items.Add(lvItem);
            }
        }

        private void buttonStammdaten_Click(object sender, EventArgs e)
        {

        }

        private void buttonStammdaten_Click_1(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "VHS Mistelbach";
            labelBtStammdaten.Visible = true;
            labelBtKursTermin.Visible = false;
            labelBtFinanz.Visible = false;
            tableLayoutPanelStammdaten.Visible = true;
        }

        private void buttonKursTermin_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "VHS Mistelbach";
            labelBtStammdaten.Visible = false;
            labelBtKursTermin.Visible = true;
            labelBtFinanz.Visible = false;
            tableLayoutPanelKursTermin.Visible = true;
        }

        private void buttonKassabuch_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "VHS Mistelbach";
            labelBtStammdaten.Visible = false;
            labelBtKursTermin.Visible = false;
            labelBtFinanz.Visible = true;
            tableLayoutPanelFinanz.Visible = true;
        }

        private void buttonHinzufügen_Click(object sender, EventArgs e)
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonHinzufügen.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonHinzufügen.Text;

           

            fHinzuBea.ShowDialog();

            sozialgruppeEinlesen();
            altersgruppenEinlesen();
            titelEinlesen();
            kurseEinlesen();
            kontakteEinlesen();
            kurskategorieEinlesen();
            bankverbindungEinlesen();
            passEinlesen();
            gutscheinEinlesen();
            schluesselEinlesen();
            KassabuchkontoEinlesen();
            KassabuchEinlesen();
            RechnungEinlesen();
            kursortEinlesen();
            kursleiterEinlesen();
            SchluesselVerwaltungEinlesen();
        }


        private void buttonAltersgruppe_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Altersgruppe";
            listViewAltersgruppe.Visible = true;
            labelBtAltersgruppe.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            altersgruppenEinlesen();
        }

        private void buttonSozialgruppe_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Sozialgruppe";
            listViewSozialgruppe.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtSozialgruppe.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            sozialgruppeEinlesen();
        }

        private void titelBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewTitel.SelectedItems.Count == 0)
                return;
            
            if (listViewTitel.SelectedItems[0].SubItems[2].Text.Equals("False"))
                fHinzuBea.checkBoxVorgestellt.Checked = false;

            if (listViewTitel.SelectedItems[0].SubItems[2].Text.Equals("True"))
                fHinzuBea.checkBoxVorgestellt.Checked = true;

            fHinzuBea.panelTitel.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewTitel.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxBezeichnungTitel.Text = listViewTitel.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.ShowDialog();
            titelEinlesen();
        }

        private void altersgruppeBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewAltersgruppe.SelectedItems.Count == 0)
                return;

            fHinzuBea.panelAltersgruppeSozialgruppeKurskategorie.Visible = true;
            
            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewAltersgruppe.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text = "" +listViewAltersgruppe.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.ShowDialog();
            altersgruppenEinlesen();
        }

        private void kurskategorieBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewKurskategorie.SelectedItems.Count == 0)
                return;

            fHinzuBea.panelAltersgruppeSozialgruppeKurskategorie.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewKurskategorie.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text = "" + listViewKurskategorie.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.ShowDialog();
            kurskategorieEinlesen();
        }

        private void sozialgruppeBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewSozialgruppe.SelectedItems.Count == 0)
                return;

            fHinzuBea.panelAltersgruppeSozialgruppeKurskategorie.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewSozialgruppe.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxAltersgruppeSozialgruppeKurskategorieBezeichnung.Text = "" + listViewSozialgruppe.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.ShowDialog();
            sozialgruppeEinlesen();
        }

        private void kontaktBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if ((listViewKontakt.SelectedItems.Count == 0) || (listViewKontakt.SelectedItems.Count > 1))
                return;
            

            fHinzuBea.panelKontakt.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewKontakt.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.titel = listViewKontakt.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxVorname.Text = listViewKontakt.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxNachname.Text = listViewKontakt.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.textBoxSVNr.Text = listViewKontakt.SelectedItems[0].SubItems[4].Text;
            fHinzuBea.comboBoxGeschlecht.Text = listViewKontakt.SelectedItems[0].SubItems[5].Text;
            fHinzuBea.comboBoxFamilienstand.Text = listViewKontakt.SelectedItems[0].SubItems[6].Text;
            fHinzuBea.textBoxEMail.Text = listViewKontakt.SelectedItems[0].SubItems[7].Text;
            fHinzuBea.textBoxTelefonnummer.Text = listViewKontakt.SelectedItems[0].SubItems[8].Text;
            fHinzuBea.comboBoxKontaktPostleitzahl.Text = listViewKontakt.SelectedItems[0].SubItems[9].Text;
            fHinzuBea.ort = listViewKontakt.SelectedItems[0].SubItems[10].Text;
            fHinzuBea.textBoxKontaktStrasse.Text = listViewKontakt.SelectedItems[0].SubItems[11].Text;
            fHinzuBea.altersgruppe = listViewKontakt.SelectedItems[0].SubItems[12].Text;
            fHinzuBea.sozialgruppe = listViewKontakt.SelectedItems[0].SubItems[13].Text;
            fHinzuBea.comboBoxStaatsbuergerschaft.Text = listViewKontakt.SelectedItems[0].SubItems[14].Text;
            fHinzuBea.ShowDialog();
            kontakteEinlesen();
        }

        private void kursortBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if ((listViewKursort.SelectedItems.Count == 0) || (listViewKursort.SelectedItems.Count > 1))
                return;

            fHinzuBea.panelKursort.Visible = true;
            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewKursort.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxKursortBezeichnung.Text = listViewKursort.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxKursortBeschreibung.Text = listViewKursort.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.comboBoxKursortPlz.Text = listViewKursort.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.ort = listViewKursort.SelectedItems[0].SubItems[4].Text;
            fHinzuBea.textBoxKursortStrasse.Text = listViewKursort.SelectedItems[0].SubItems[5].Text;

            fHinzuBea.ShowDialog();
            kursortEinlesen();
        }

        private void passBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewPass.SelectedItems.Count == 0)
                return;

            fHinzuBea.panelPass.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewPass.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxPassKontaktID.Text = "" + listViewPass.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxPassNr.Text = "" + listViewPass.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.dateTimePickerPassBeginn.Value = Convert.ToDateTime(listViewPass.SelectedItems[0].SubItems[3].Text);
            fHinzuBea.dateTimePickerPassEnde.Value = Convert.ToDateTime(listViewPass.SelectedItems[0].SubItems[4].Text);
            fHinzuBea.ShowDialog();
            passEinlesen();
        }

        private void bankverbindungBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewBankverbindung.SelectedItems.Count == 0)
                return;
            fHinzuBea.panelBankverbindung.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewBankverbindung.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxBankverbindungIBAN.Text = "" + listViewBankverbindung.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxBankverbindungKontoinhaber.Text = "" + listViewBankverbindung.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxBankverbindungKontaktID.Text = "" + listViewBankverbindung.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.ShowDialog();
            bankverbindungEinlesen();
        }



        private void schluesselBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewSchluessel.SelectedItems.Count == 0)
                return;
            fHinzuBea.panelSchluessel.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewSchluessel.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxSchluesselBezeichnung.Text = listViewSchluessel.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxSchluesselCode.Text = listViewSchluessel.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxSchluesselPlatz.Text = listViewSchluessel.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.textBoxSchluesselAnmerkung.Text = listViewSchluessel.SelectedItems[0].SubItems[4].Text;

            if (listViewSchluessel.SelectedItems[0].SubItems[5].Text.Equals("False"))
                fHinzuBea.checkBoxSchluesselAktiv.Checked = false;

            if (listViewSchluessel.SelectedItems[0].SubItems[5].Text.Equals("True"))
                fHinzuBea.checkBoxSchluesselAktiv.Checked = true;

            fHinzuBea.ShowDialog();
            schluesselEinlesen();
        }

        private void gutscheinBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewGutschein.SelectedItems.Count == 0)
                return;
            fHinzuBea.panelGutschein.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewGutschein.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxGutscheinBezeichnung.Text = listViewGutschein.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxGutscheinBetrag.Text = listViewGutschein.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.ShowDialog();
            gutscheinEinlesen();
        }

        private void mitgliedschaftBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if ((listViewMitgliedschaft.SelectedItems.Count == 0) || (listViewMitgliedschaft.SelectedItems.Count > 1))
                return;
            fHinzuBea.panelMitgliedschaft.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewMitgliedschaft.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxMitgliedschaftBezeichnung.Text = listViewMitgliedschaft.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxMitgliedschaftMitgliedsbeitrag.Text = listViewMitgliedschaft.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxMitgliedschaftErmaessigung.Text = listViewMitgliedschaft.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.ShowDialog();
            mitgliedschaftEinlesen();
        }

        private void buttonBearbeiten_Click(object sender, EventArgs e)
        {
            if (labelÜberschrift.Text.Equals("Titel"))
            {
                titelBearbeiten();
            }
            if(labelÜberschrift.Text.Equals("Altersgruppe"))
            {
                altersgruppeBearbeiten();
            }
            if(labelÜberschrift.Text.Equals("Sozialgruppe"))
            {
                sozialgruppeBearbeiten();
            }
            if(labelÜberschrift.Text.Equals("Kurskategorie"))
            {
                kurskategorieBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Bankverbindung"))
            {
                bankverbindungBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Pass"))
            {
                passBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Gutschein"))
            {
                gutscheinBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Schlüssel"))
            {
                schluesselBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Mitgliedschaft"))
            {
                mitgliedschaftBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Kontakt"))
            {
                kontaktBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Kassabuchkonto"))
            {
                kassabuchkontoBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Kassabuch"))
            {
                kassabuchBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Rechnung"))
            {
                rechnungBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Kursort"))
            {
                kursortBearbeiten();
            }
            if(labelÜberschrift.Text.Equals("Kurs"))
            {
                kursBearbeiten();
            }
            if (labelÜberschrift.Text.Equals("Kursleiter"))
            {
                kursleiterBearbeiten();
            }

        }

        private void contextMenuStripTitel_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void contextMenuStripKontakt_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStripAltersgruppe_Opening(object sender, CancelEventArgs e)
        {
       
        }

        private void contextMenuStripSozialgruppe_Opening(object sender, CancelEventArgs e)
        {
        
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bearbeitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            titelBearbeiten();
        }

        private void bearbeitenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            altersgruppeBearbeiten();
        }

        private void bearbeitenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            sozialgruppeBearbeiten();
        }

        private void buttonKurs_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kurs";
            listViewKurs.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKurs.Visible = true;
            labelBtKursTermin.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            kurseEinlesen();
        }

        private void buttonKurskategorie_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kurskategorie";
            listViewKurskategorie.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKurskategorie.Visible = true;
            labelBtKursTermin.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            kurskategorieEinlesen();
        }

        private void bearbeitenToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            kurskategorieBearbeiten();
        }

        private void buttonBankverbindung_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Bankverbindung";
            listViewBankverbindung.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtBankverbindung.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            bankverbindungEinlesen();

        }

        private void contextMenuStripKurskategorie_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ändernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bankverbindungBearbeiten();
        }

        private void tableLayoutPanelStammdaten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Pass";
            listViewPass.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtPass.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            passEinlesen();
        }

        private void bearbeitenToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            passBearbeiten();
        }

        private void buttonSchluessel_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Schlüssel";
            listViewSchluessel.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtSchluessel.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            schluesselEinlesen();
        }

        private void buttonGutschein_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Gutschein";
            listViewGutschein.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtGutschein.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            gutscheinEinlesen();
        }

        private void schluesselEinlesen()
        {
            FrmHinzufügenBearbeiten fHinzuBearb = new FrmHinzufügenBearbeiten();
            listViewSchluessel.Items.Clear();

            var request = new RestRequest("schluessel", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Schluessel>>(request);

            foreach (Schluessel s in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(s.SchluesselID.ToString());
                lvItem.SubItems.Add(s.Bezeichnung.ToString());
                lvItem.SubItems.Add(s.Code.ToString());
                lvItem.SubItems.Add(s.Platz.ToString());
                lvItem.SubItems.Add(s.Anmerkung.ToString());
                lvItem.SubItems.Add(s.Aktiv.ToString());
                listViewSchluessel.Items.Add(lvItem);
            }
        }

        private void gutscheinEinlesen()
        {
            FrmHinzufügenBearbeiten fHinzuBearb = new FrmHinzufügenBearbeiten();
            listViewGutschein.Items.Clear();

            var request = new RestRequest("gutscheine", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Gutschein>>(request);

            foreach (Gutschein g in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(g.GutscheinID.ToString());
                lvItem.SubItems.Add(g.Bezeichnung.ToString());
                lvItem.SubItems.Add(g.Betrag.ToString());
                listViewGutschein.Items.Add(lvItem);
            }
        }

        private void mitgliedschaftEinlesen()
        {
            FrmHinzufügenBearbeiten fHinzuBearb = new FrmHinzufügenBearbeiten();
            listViewMitgliedschaft.Items.Clear();

            var request = new RestRequest("mitgliedschaften", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Mitgliedschaft>>(request);

            foreach (Mitgliedschaft m in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(m.MitgliedschaftID.ToString());
                lvItem.SubItems.Add(m.Bezeichnung.ToString());
                lvItem.SubItems.Add(m.Mitgliedsbeitrag.ToString());
                lvItem.SubItems.Add(m.Ermaessigung.ToString());
                listViewMitgliedschaft.Items.Add(lvItem);
            }
        }

        private void buttonMitgliedschaft_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Mitgliedschaft";
            listViewMitgliedschaft.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtMitgliedschaft.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            mitgliedschaftEinlesen();
        }

        private void listViewMitgliedschaft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ändernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mitgliedschaftBearbeiten();
        }

        private void bearbeitenToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            schluesselBearbeiten();
        }

        private void bearbeitenToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            gutscheinBearbeiten();
        }

        private void buttonKassabuchkonto_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kassabuchkonto";
            listViewKassabuchkonto.Visible = true;
            tableLayoutPanelFinanz.Visible = true;
            labelBtKassabuchkonto.Visible = true;
            labelBtFinanz.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            KassabuchkontoEinlesen();
        }

        private void KassabuchkontoEinlesen()
        {
            listViewKassabuchkonto.Items.Clear();

            var request = new RestRequest("kassabuchkonten", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kassabuchkonto>>(request);

            foreach (Kassabuchkonto k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KassabuchkontoID.ToString());
                lvItem.SubItems.Add(k.Kontonummer.ToString());
                lvItem.SubItems.Add(k.Kontobezeichnung.ToString());
                lvItem.SubItems.Add(k.Kontostand.ToString("c2"));
                listViewKassabuchkonto.Items.Add(lvItem);
            }

            
        }

        private void kursleiterBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewKursleiter.SelectedItems.Count == 0)
                return;
            fHinzuBea.panelKontaktSuche.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewKursleiter.SelectedItems[0].SubItems[0].Text;

            fHinzuBea.ShowDialog();
            kursleiterEinlesen();
        }

        private void kursBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if (listViewKurs.SelectedItems.Count == 0)
                return;
            fHinzuBea.panelKurs.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewKurs.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxKursBezeichnung.Text = listViewKurs.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxKursPreis.Text = listViewKurs.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxKursMinTeilnehmer.Text = listViewKurs.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.textBoxMaxTeilnehmer.Text = listViewKurs.SelectedItems[0].SubItems[4].Text;
            fHinzuBea.textBoxKursAnzEinheit.Text = listViewKurs.SelectedItems[0].SubItems[5].Text;
            fHinzuBea.comboBoxKursVerbindklichkeit.Text = listViewKurs.SelectedItems[0].SubItems[6].Text;
            fHinzuBea.comboBoxKursFoerderung.Text = listViewKurs.SelectedItems[0].SubItems[7].Text;
            fHinzuBea.textBoxKursStatus.Text = listViewKurs.SelectedItems[0].SubItems[8].Text;
            fHinzuBea.textBoxKursBeschreibung.Text = listViewKurs.SelectedItems[0].SubItems[9].Text;
            fHinzuBea.dateTimePickerKursZeitVon.Value = Convert.ToDateTime(listViewKurs.SelectedItems[0].SubItems[10].Text);
            fHinzuBea.dateTimePickerKursZeitBis.Value = Convert.ToDateTime(listViewKurs.SelectedItems[0].SubItems[11].Text);
            fHinzuBea.dateTimePickerKursDatumVon.Value = Convert.ToDateTime(listViewKurs.SelectedItems[0].SubItems[12].Text);
            fHinzuBea.dateTimePickerKursDatumBis.Value = Convert.ToDateTime(listViewKurs.SelectedItems[0].SubItems[13].Text);
            fHinzuBea.textBoxKursSeminarnummer.Text = listViewKurs.SelectedItems[0].SubItems[14].Text;
            fHinzuBea.comboBoxKursKurskategorie.Text = listViewKurs.SelectedItems[0].SubItems[15].Text;
            fHinzuBea.comboBoxKursKursort.Text = listViewKurs.SelectedItems[0].SubItems[16].Text;
            fHinzuBea.dateTimePickerKursAnmeldeschluss.Value = Convert.ToDateTime(listViewKurs.SelectedItems[0].SubItems[17].Text);
            fHinzuBea.textBoxKursAnmerkung.Text = listViewKurs.SelectedItems[0].SubItems[18].Text;
            fHinzuBea.comboBoxKursAnzeigen.Text = listViewKurs.SelectedItems[0].SubItems[19].Text;

            fHinzuBea.ShowDialog();
            kurseEinlesen();
        }

        private void kassabuchkontoBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if ((listViewKassabuchkonto.SelectedItems.Count == 0) || (listViewKassabuchkonto.SelectedItems.Count > 1))
            {
                MessageBox.Show("Bitte wählen Sie einen Datensatz aus");
                return;
            }
               

            fHinzuBea.panelKassabuchkonto.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;
            fHinzuBea.labelID.Text = listViewKassabuchkonto.SelectedItems[0].SubItems[0].Text;
            fHinzuBea.textBoxKontonummer.Text = listViewKassabuchkonto.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxKontobezeichnung.Text = listViewKassabuchkonto.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxKontostand.Text = listViewKassabuchkonto.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.ShowDialog();
            KassabuchkontoEinlesen();
        }



        

        private void buttonKassabuch_Click_1(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kassabuch";
            listViewKassabuch.Visible = true;
            tableLayoutPanelFinanz.Visible = true;
            labelBtKassabuch.Visible = true;
            labelBtFinanz.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            KassabuchEinlesen();
        }

        private void KassabuchEinlesen()
        {
            listViewKassabuch.Items.Clear();

            var request = new RestRequest("kassabuecher", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kassabuch>>(request);

           

            foreach (Kassabuch k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KassabuchID.ToString());
                lvItem.SubItems.Add(k.Datum.ToString("dd.MM.yyyy"));
                lvItem.SubItems.Add(k.Buchungstext.ToString());
                lvItem.SubItems.Add(k.Betrag.ToString("c2"));
                lvItem.SubItems.Add(k.KontaktID.KontaktID.ToString());
                lvItem.SubItems.Add(k.KassabuchkontoID.KassabuchkontoID.ToString());
                listViewKassabuch.Items.Add(lvItem);
            }

           


        }

        private void kassabuchBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if ((listViewKassabuch.SelectedItems.Count == 0) || (listViewKassabuch.SelectedItems.Count > 1))
            {
                MessageBox.Show("Bitte wählen Sie einen Datensatz aus");
                return;
            }


            fHinzuBea.panelKassabuch.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;

            fHinzuBea.labelID.Text = listViewKassabuch.SelectedItems[0].SubItems[0].Text;
            

            fHinzuBea.textBoxBuchungstext.Text = listViewKassabuch.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.textBoxBetrag.Text = listViewKassabuch.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.comboBoxKontaktID.Text = listViewKassabuch.SelectedItems[0].SubItems[4].Text;
            fHinzuBea.comboBoxKassabuchkontoID.Text = listViewKassabuch.SelectedItems[0].SubItems[5].Text;

            fHinzuBea.ShowDialog();
            KassabuchEinlesen();

            
            
        }

        private void buttonRechnung_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Rechnung";
            listViewRechnung.Visible = true;
            tableLayoutPanelFinanz.Visible = true;
            labelBtRechnung.Visible = true;
            labelBtFinanz.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            btnRechnungdrucken.Visible = true;
            RechnungEinlesen();
        }

        private void RechnungEinlesen()
        {
            listViewRechnung.Items.Clear();

            var request = new RestRequest("rechnungen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Rechnung>>(request);

            foreach (Rechnung k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.RechnungID.ToString());
                lvItem.SubItems.Add(k.Rechnungsnummer.ToString());
                lvItem.SubItems.Add(k.Rechnungsdatum.ToString("dd.MM.yyyy"));
                lvItem.SubItems.Add(k.KontaktID.KontaktID.ToString());
                lvItem.SubItems.Add(k.KursID.KursID.ToString());
                listViewRechnung.Items.Add(lvItem);
            }
        }

        private void rechnungBearbeiten()
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            if ((listViewRechnung.SelectedItems.Count == 0) || (listViewRechnung.SelectedItems.Count > 1))
            {
                MessageBox.Show("Bitte wählen Sie einen Datensatz aus");
                return;
            }


            fHinzuBea.panelRechnung.Visible = true;

            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonBearbeiten.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonBearbeiten.Text;

            fHinzuBea.labelID.Text = listViewRechnung.SelectedItems[0].SubItems[0].Text;

            fHinzuBea.textBoxRechnungsnummer.Text = listViewRechnung.SelectedItems[0].SubItems[1].Text;
            
            fHinzuBea.comboBoxRechnungKontaktID.Text = listViewRechnung.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.comboBoxRechnungKursID.Text = listViewRechnung.SelectedItems[0].SubItems[4].Text;
     

            fHinzuBea.ShowDialog();
            RechnungEinlesen();
        }

        private void btnRechnungdrucken_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
            if (wordapp == null)
            {
                MessageBox.Show("Es konnte keine Verbindung zu Word hergestellt werden!");
                return;
            }

            if ((listViewRechnung.SelectedItems.Count == 0) || (listViewRechnung.SelectedItems.Count > 1))
            {
                MessageBox.Show("Bitte wählen Sie einen Datensatz aus");
                return;
            }

            wordapp.Visible = true;
            wordapp.Documents.Open(System.Windows.Forms.Application.StartupPath + "\\VorlageRechnung.docx");


            
            Kontakt kontakt = new Kontakt();
            Rechnung rechnung = new Rechnung();
            Kurs kurs = new Kurs();
            

            var requestKontakt = new RestRequest("kontakte", Method.GET);
            requestKontakt.AddHeader("Content-Type", "application/json");
            var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            var requestRechnung = new RestRequest("rechnungen", Method.GET);
            requestRechnung.AddHeader("Content-Type", "application/json");
            var responseRechnung = client.Execute<List<Rechnung>>(requestRechnung);

            var requestKurs = new RestRequest("kurse", Method.GET);
            requestKurs.AddHeader("Content-Type", "application/json");
            var responseKurs = client.Execute<List<Kurs>>(requestKurs);



            foreach (Kontakt kk in responseKontakt.Data)
            {
                if (kk.KontaktID.ToString().Equals(listViewRechnung.SelectedItems[0].SubItems[3].Text))
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

                rechnung.KontaktID = kontakt;
            }

            foreach (Kurs k in responseKurs.Data)
            {
                if (k.KursID.ToString().Equals(listViewRechnung.SelectedItems[0].SubItems[4].Text))
                {
                    kurs.KursID = k.KursID;
                    kurs.Bezeichnung = k.Bezeichnung;
                    kurs.Preis = k.Preis;
                    kurs.MinTeilnehmer = k.MinTeilnehmer;
                    kurs.MaxTeilnehmer = k.MaxTeilnehmer;
                    kurs.AnzEinheiten = k.AnzEinheiten;
                    kurs.DatumVon = k.DatumVon;
                    kurs.ZeitVon = k.ZeitVon;
                    kurs.KursortID = k.KursortID;
                    kurs.Kursort1 = k.Kursort1;
                }

                rechnung.KursID = kurs;
            }





            string Rechnungsnummer = "Rechnungsnummer".ToString();
            //string Rechnungsdatum = "Rechnungsdatum".ToString();
            //string Kontaktvorname = "Kontaktvorname".ToString();
            string Kontaktnachname = "Kontaktnachname".ToString();
            //string Kontaktstrasse = "Kontaktstrasse".ToString();
            //string Kontaktort = "Kontaktort".ToString();
            //string Kontaktplz = "Kontaktplz".ToString();
            string Kursbezeichnung = "Kursbezeichnung".ToString();
            string Kurspreis = "Kurspreis".ToString();
            string Kontakttitel = "Kontakttitel".ToString();
            string Anrede = "Anrede".ToString();
            string Kursdatum = "Kursdatum".ToString();
            string Kursuhrzeit = "Kursuhrzeit".ToString();
            string Kursort = "Kursort".ToString();




            wordapp.ActiveDocument.FormFields[Rechnungsnummer].Result = listViewRechnung.SelectedItems[0].SubItems[1].Text;
            //wordapp.ActiveDocument.FormFields[Rechnungsdatum].Result = listViewRechnung.SelectedItems[0].SubItems[2].Text;
            //wordapp.ActiveDocument.FormFields[Kontaktvorname].Result = kontakt.Vorname.ToString();
            wordapp.ActiveDocument.FormFields[Kontaktnachname].Result = kontakt.Nachname.ToString() + (",");
            //wordapp.ActiveDocument.FormFields[Kontaktstrasse].Result = kontakt.Strasse.ToString();
            //wordapp.ActiveDocument.FormFields[Kontaktplz].Result = kontakt.PostleitzahlID.Plz.ToString();
            //wordapp.ActiveDocument.FormFields[Kontaktort].Result = kontakt.PostleitzahlID.Ort.ToString();
            wordapp.ActiveDocument.FormFields[Kursbezeichnung].Result = kurs.Bezeichnung.ToString();
            wordapp.ActiveDocument.FormFields[Kurspreis].Result = kurs.Preis.ToString("c2");
            wordapp.ActiveDocument.FormFields[Kontakttitel].Result = kontakt.TitelID.Bezeichnung.ToString();
            wordapp.ActiveDocument.FormFields[Kursdatum].Result = kurs.DatumVon.ToString().Substring(0, 10);
            wordapp.ActiveDocument.FormFields[Kursuhrzeit].Result = kurs.ZeitVon.ToString().Substring(11, 5);
            wordapp.ActiveDocument.FormFields[Kursort].Result = kurs.KursortID.Bezeichnung.ToString();

            if (wordapp.ActiveDocument.FormFields[Kontakttitel].Result == (""))
            {
                //wordapp.ActiveDocument.FormFields[Kontakttitel].Range.Font.Hidden = Convert.ToInt32(true);
                wordapp.ActiveDocument.FormFields[Kontakttitel].Result = kontakt.Nachname.ToString() + (",");
                wordapp.ActiveDocument.FormFields[Kontaktnachname].Range.Font.Hidden = Convert.ToInt32(true);

            }

            if (kontakt.Geschlecht.ToString() == ("m"))
            {
                wordapp.ActiveDocument.FormFields[Anrede].Result = ("Sehr geehrter Herr");
              

            }
            else if (kontakt.Geschlecht.ToString() == ("männlich"))
            {
                wordapp.ActiveDocument.FormFields[Anrede].Result = ("Sehr geehrter Herr");
               
            }
            else
            {
                wordapp.ActiveDocument.FormFields[Anrede].Result = ("Sehr geehrte Frau");
                
            }
           

            


        }

        private void buttonKursort_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kursort";
            listViewKursort.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKursort.Visible = true;
            labelBtKursTermin.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            kursortEinlesen();
        }

        private void listViewKursort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonKursleiter_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kursleiter";
            listViewKursleiter.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKursleiter.Visible = true;
            labelBtKursTermin.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            kursleiterEinlesen();
        }

        public void kursleiterEinlesen()
        {
            listViewKursleiter.Items.Clear();

            var request = new RestRequest("kursleiter", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kursleiter>>(request);

            foreach (Kursleiter k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KursleiterID.ToString());
                lvItem.SubItems.Add(k.KontaktID.Vorname.ToString());
                lvItem.SubItems.Add(k.KontaktID.Nachname.ToString());
                listViewKursleiter.Items.Add(lvItem);
            }
        }

        private void kursortEinlesen()
        {
            listViewKursort.Items.Clear();

            var request = new RestRequest("kursorte", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kursort>>(request);

            foreach (Kursort k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KursortID.ToString());
                lvItem.SubItems.Add(k.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.Beschreibung.ToString());
                lvItem.SubItems.Add(k.PostleitzahlID.Plz.ToString());
                lvItem.SubItems.Add(k.PostleitzahlID.Ort.ToString());
                lvItem.SubItems.Add(k.Strasse.ToString());
                listViewKursort.Items.Add(lvItem);
            }
        }

        private void buttonTeilnehmer_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Teilnehmer";
            listViewTeilnehmer.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtTeilnehmer.Visible = true;
            labelBtKursTermin.Visible = true;
            labelKurs.Visible = true;
            comboBoxKursTeilnehmer.Visible = true;
            labelKursleiter.Visible = true;
            buttonTeilnehmerDrucken.Visible = true;
            textBoxKursleiter.Visible = true;

            comboBoxKursTeilnehmer.Items.Clear();
            var request = new RestRequest("kurse", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kurs>>(request);

            foreach (Kurs k in response.Data)
            {
                comboBoxKursTeilnehmer.Items.Add(k.Bezeichnung.ToString());
            }
            
        }

        private void comboBoxKursTeilnehmer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewTeilnehmer.Items.Clear();

            var requestKontaktKurs = new RestRequest("kontaktKurse", Method.GET);
            requestKontaktKurs.AddHeader("Content-Type", "application/json");
            var responseKontaktKurs = client.Execute<List<KontaktKurs>>(requestKontaktKurs);

            var requestKursleiterKurs = new RestRequest("kursleiterKurse", Method.GET);
            requestKursleiterKurs.AddHeader("Content-Type", "application/json");
            var responseKursleiterKurs = client.Execute<List<KursleiterKurs>>(requestKursleiterKurs);


            foreach (KontaktKurs kk in responseKontaktKurs.Data)
            {
                if(comboBoxKursTeilnehmer.Text.Equals(kk.KursID.Bezeichnung))
                {
                    foreach(KursleiterKurs klk in responseKursleiterKurs.Data)
                    {
                        if(kk.KursID.KursID.ToString().Equals(klk.KursID.KursID.ToString()))
                        {
                            textBoxKursleiter.Text = klk.KursleiterID.KontaktID.Vorname.ToString() + " " + klk.KursleiterID.KontaktID.Nachname.ToString();
                        }
                    }
                ListViewItem lvItem = new ListViewItem(kk.KontakID.Vorname.ToString());
                lvItem.SubItems.Add(kk.KontakID.Nachname.ToString());
                listViewTeilnehmer.Items.Add(lvItem);
                }
                else
                {
                    textBoxKursleiter.Text = "";
                }

            }

            
        }

        private void buttonOffenePosten_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Offene Rechnungen";
            listViewOffeneRechnung.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKursTermin.Visible = true;
            labelBtOffeneRechnungen.Visible = true;
            offenePostenEinlesen();
        }

        private void offenePostenEinlesen()
        {
            listViewOffeneRechnung.Items.Clear();

            var request = new RestRequest("kontaktKurse", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<KontaktKurs>>(request);

            foreach (KontaktKurs kk in response.Data)
            {
                if (kk.Bezahlt == true)
                {
                    ListViewItem lvItem = new ListViewItem(kk.KontakID.Vorname.ToString());
                    lvItem.SubItems.Add(kk.KontakID.Nachname.ToString());
                    lvItem.SubItems.Add("nein");
                    lvItem.SubItems.Add(kk.KursID.Bezeichnung.ToString());
                    listViewOffeneRechnung.Items.Add(lvItem);
                }
            }

        }

        private void listViewTeilnehmer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelKurs_Click(object sender, EventArgs e)
        {

        }

        private void listViewOffeneRechnung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKursleiter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewRechnung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKassabuch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKassabuchkonto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewGutschein_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewSchluessel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewPass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewBankverbindung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKurskategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewSozialgruppe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewTitel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewAltersgruppe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKurs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewKontakt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonKursbuchung_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kursbuchungen";
            listViewKursbuchung.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKursbuchung.Visible = true;
            labelBtKursTermin.Visible = true;
            labelKursbuchungVon.Visible = true;
            labelKursbuchungBis.Visible = true;
            dateTimePickerKursbuchungBis.Visible = true;
            dateTimePickerKursbuchungVon.Visible = true;
            buttonKursbuchungSuchen.Visible = true;
            buttonNeueKursbuchung.Visible = true;
            buttonKursbuchungBearbeiten.Visible = true;
            kursbuchungEinlesen();
        }

        private void kursbuchungEinlesen()
        {
            listViewKursbuchung.Items.Clear();

            var requestKontaktKurs = new RestRequest("kontaktKurse", Method.GET);
            requestKontaktKurs.AddHeader("Content-Type", "application/json");
            var responseKontaktKurs = client.Execute<List<KontaktKurs>>(requestKontaktKurs);

            foreach (KontaktKurs kk in responseKontaktKurs.Data)
            {
                ListViewItem lvItem = new ListViewItem(kk.KontaktKursID.ToString());
                lvItem.SubItems.Add(kk.KontakID.Vorname.ToString());
                lvItem.SubItems.Add(kk.KontakID.Nachname.ToString());
                lvItem.SubItems.Add(kk.KursID.Bezeichnung.ToString());
                lvItem.SubItems.Add(kk.KursID.Seminarnummer.ToString());
                lvItem.SubItems.Add(kk.Buchungsdatum.ToShortDateString());
                lvItem.SubItems.Add(kk.Bezahlt.ToString());
                listViewKursbuchung.Items.Add(lvItem);
            }
        }

        private void buttonKursbuchungSuchen_Click(object sender, EventArgs e)
        {
            listViewKursbuchung.Items.Clear();

            var requestKontaktKurs = new RestRequest("kontaktKurse", Method.GET);
            requestKontaktKurs.AddHeader("Content-Type", "application/json");
            var responseKontaktKurs = client.Execute<List<KontaktKurs>>(requestKontaktKurs);

            foreach (KontaktKurs kk in responseKontaktKurs.Data)
            {
                if (dateTimePickerKursbuchungVon.Value <= kk.Buchungsdatum && dateTimePickerKursbuchungBis.Value >= kk.Buchungsdatum)
                {
                    ListViewItem lvItem = new ListViewItem(kk.KontaktKursID.ToString());
                    lvItem.SubItems.Add(kk.KontakID.Vorname.ToString());
                    lvItem.SubItems.Add(kk.KontakID.Nachname.ToString());
                    lvItem.SubItems.Add(kk.KursID.Bezeichnung.ToString());
                    lvItem.SubItems.Add(kk.KursID.Seminarnummer.ToString());
                    lvItem.SubItems.Add(kk.Buchungsdatum.ToShortDateString());
                    lvItem.SubItems.Add(kk.Bezahlt.ToString());
                    listViewKursbuchung.Items.Add(lvItem);
                }
            }
        }

        private void dateTimePickerKursbuchungBis_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerKursbuchungBis.Value < dateTimePickerKursbuchungVon.Value)
            {
                MessageBox.Show("Das Datum muss größer als " + dateTimePickerKursbuchungVon.Value.ToShortDateString() + " sein.");
            }
        }

        private void dateTimePickerKursbuchungVon_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerKursbuchungBis.Value < dateTimePickerKursbuchungVon.Value)
            {
                MessageBox.Show("Das Datum muss kleiner als " + dateTimePickerKursbuchungBis.Value.ToShortDateString() + " sein.");
            }
        }

        private void buttonNeueKursbuchung_Click(object sender, EventArgs e)
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonHinzufügen.Text;
            fHinzuBea.labelÜberschrift.Text = buttonNeueKursbuchung.Text;
            fHinzuBea.ShowDialog();

            kursbuchungEinlesen();
        }

        private void buttonKursbuchungBearbeiten_Click(object sender, EventArgs e)
        {
            if (listViewKursbuchung.SelectedItems.Count == 0 || listViewKursbuchung.SelectedItems.Count > 1)
                return;

            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            KontaktKurs kontaktKurs = new KontaktKurs();
            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonHinzufügen.Text;
            fHinzuBea.labelÜberschrift.Text = buttonKursbuchungBearbeiten.Text;

            var requestKontaktKurs = new RestRequest("kontaktKurse", Method.GET);
            requestKontaktKurs.AddHeader("Content-Type", "application/json");
            var responseKontaktKurs = client.Execute<List<KontaktKurs>>(requestKontaktKurs);

            fHinzuBea.labelID.Text = listViewKursbuchung.SelectedItems[0].SubItems[0].Text;
            foreach(KontaktKurs kk in responseKontaktKurs.Data)
            {
                if(kk.KontaktKursID.ToString().Equals(listViewKursbuchung.SelectedItems[0].SubItems[0].Text))
                {
                    fHinzuBea.textBoxKursbuchungKontakt.Text = kk.KontakID.Vorname.ToString() + " " + kk.KontakID.Nachname.ToString();
                    fHinzuBea.textBoxKursbuchungKurs.Text = kk.KursID.Bezeichnung.ToString();
                    fHinzuBea.labelKursbuchungKontaktID.Text = kk.KontakID.KontaktID.ToString();
                    fHinzuBea.labelKursbuchungKursID.Text = kk.KursID.KursID.ToString();
                    //fHinzuBea.comboBoxKursbuchungBonus.SelectedItem = "True";
                }
            }

            fHinzuBea.ShowDialog();

            kursbuchungEinlesen();
        }

        private void listViewKursbuchung_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            
        }

        private void buttonTermine_Click(object sender, EventArgs e)
        {
            //labelBtKursTermin.Visible = true;
        }

        private void buttonTeilnehmerDrucken_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
            if (wordapp == null)
            {
                MessageBox.Show("Es konnte keine Verbindung zu Word hergestellt werden!");
                return;
            }

            if(comboBoxKursTeilnehmer.Text.Equals(""))
            {
                MessageBox.Show("Wählen Sie einen Kurs aus!");
                return;
            }

            wordapp.Visible = true;
            wordapp.Documents.Open(System.Windows.Forms.Application.StartupPath + "\\VorlageTeilnehmerliste.docx");



            //Kontakt kontakt = new Kontakt();
            //KontaktKurs kontaktKurs = new KontaktKurs();
            //Kurs kurs = new Kurs();


            //var requestKontakt = new RestRequest("kontakte", Method.GET);
            //requestKontakt.AddHeader("Content-Type", "application/json");
            //var responseKontakt = client.Execute<List<Kontakt>>(requestKontakt);

            //var requestKontaktKurs = new RestRequest("kontaktKurse", Method.GET);
            //requestKontaktKurs.AddHeader("Content-Type", "application/json");
            //var responseKontaktKurs = client.Execute<List<KontaktKurs>>(requestKontaktKurs);

            //var requestKurs = new RestRequest("kurse", Method.GET);
            //requestKurs.AddHeader("Content-Type", "application/json");
            //var responseKurs = client.Execute<List<Kurs>>(requestKurs);


            

            string Vorname = "Vorname".ToString();
            string Nachname = "Nachachname".ToString();
            string Kursbezeichnung = "Kursbezeichnung".ToString();
            string Kursleiter = "Kursleiter".ToString();
            //string Kontakttitel = "Kontakttitel".ToString();

            //wordapp.ActiveDocument.FormFields[Kontakttitel].Result = kontakt.TitelID.Bezeichnung.ToString();


            wordapp.ActiveDocument.FormFields[Kursbezeichnung].Result = comboBoxKursTeilnehmer.Text;
            wordapp.ActiveDocument.FormFields[Kursleiter].Result = textBoxKursleiter.Text;

            for (int i = 0; i >= listViewKursbuchung.Items.Count; i++)
            {
                wordapp.ActiveDocument.FormFields[Vorname].Result = listViewTeilnehmer.Items[i].SubItems[0].Text;
                wordapp.ActiveDocument.FormFields[Nachname].Result = listViewTeilnehmer.Items[i].SubItems[1].Text;
            }
            //if (wordapp.ActiveDocument.FormFields[Kontakttitel].Result == (""))
            //{
            //    wordapp.ActiveDocument.FormFields[Kontakttitel].Range.Font.Hidden = Convert.ToInt32(true);
            //}
        }

        private void buttonSchluesselVerwaltung_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Schlüsselverwaltung";
            listViewSchluesselverwaltung.Visible = true;
            tableLayoutPanelStammdaten.Visible = true;
            labelBtSchluesselverwaltung.Visible = true;
            labelBtStammdaten.Visible = true;
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            SchluesselVerwaltungEinlesen();
        }

        private void SchluesselVerwaltungEinlesen()
        {
            listViewSchluesselverwaltung.Items.Clear();

            var request = new RestRequest("schluesselKontakte", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<SchluesselKontakt>>(request);



            foreach (SchluesselKontakt sk in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(sk.SchluesselKontaktID.ToString());
                lvItem.SubItems.Add(sk.SchluesselID.SchluesselID.ToString());
                lvItem.SubItems.Add(sk.KontaktID.KontaktID.ToString());
                lvItem.SubItems.Add(sk.SchluesselID.Bezeichnung.ToString());
                lvItem.SubItems.Add(sk.Herausgeber.ToString());
                lvItem.SubItems.Add(sk.AusgabeAm.ToString("dd.MM.yyyy"));
                lvItem.SubItems.Add(sk.RetourAm.ToString("dd.MM.yyyy"));         // erst durch Bearbeitung soll dort ein Datum stehen -> also erst wenn er den Schlüssel zurückgegeben hat

                listViewSchluesselverwaltung.Items.Add(lvItem);
            }
        }
    }
}
