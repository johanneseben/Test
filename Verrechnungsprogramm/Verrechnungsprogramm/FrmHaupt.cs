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

        public FrmHaupt()
        {
           
            InitializeComponent();
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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            listViewKurs.Items.Clear();
            var client = new RestClient("http://localhost:8888");

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
                lvItem.SubItems.Add(k.Verbindlichkeit.ToString());
                lvItem.SubItems.Add(k.Foerderung.ToString());
                lvItem.SubItems.Add(k.Status.ToString());
                lvItem.SubItems.Add(k.Beschreibung.ToString());
                lvItem.SubItems.Add(k.ZeitVon.ToShortTimeString());
                lvItem.SubItems.Add(k.ZeitBis.ToShortTimeString());
                lvItem.SubItems.Add(k.DatumVon.ToShortDateString());
                lvItem.SubItems.Add(k.DatumBis.ToShortDateString());
                lvItem.SubItems.Add(k.Seminarnummer.ToString());
                lvItem.SubItems.Add(k.KurskategorieID.Bezeichnung.ToString());
                lvItem.SubItems.Add(k.KursortID.KursortID.ToString());
                lvItem.SubItems.Add(k.Anmeldeschluss.ToString());
                lvItem.SubItems.Add(k.Anmerkung.ToString());

                listViewKurs.Items.Add(lvItem);
            }
        }

        public void altersgruppenEinlesen()
        {
            listViewAltersgruppe.Items.Clear();
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("kassabuecher", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Kassabuch>>(request);

            foreach (Kassabuch k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.KassabuchID.ToString());
                lvItem.SubItems.Add(k.Datum.ToString());
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
            fHinzuBea.dateTimePickerKassabuch.Text = listViewKassabuch.SelectedItems[0].SubItems[1].Text;
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
            RechnungEinlesen();
        }

        private void RechnungEinlesen()
        {
            listViewRechnung.Items.Clear();
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("rechnungen", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Rechnung>>(request);

            foreach (Rechnung k in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(k.RechnungID.ToString());
                lvItem.SubItems.Add(k.Rechnungsnummer.ToString());
                lvItem.SubItems.Add(k.Rechnungsdatum.ToString());
                lvItem.SubItems.Add(k.KontaktID.KontaktID.ToString("c2"));
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
            
            fHinzuBea.textBoxRechnungsnummer.Text = listViewRechnung.SelectedItems[0].SubItems[1].Text;
            fHinzuBea.textBoxRechnungsdatum.Text = listViewRechnung.SelectedItems[0].SubItems[2].Text;
            fHinzuBea.txtKontaktID.Text = listViewRechnung.SelectedItems[0].SubItems[3].Text;
            fHinzuBea.textBoxKursID.Text = listViewRechnung.SelectedItems[0].SubItems[4].Text;
     

            fHinzuBea.ShowDialog();
            RechnungEinlesen();
        }

        private void buttonKursort_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Kursort";
            listViewKursort.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtKursort.Visible = true;
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
            buttonHinzufügen.Visible = true;
            buttonBearbeiten.Visible = true;
            kursleiterEinlesen();
        }

        private void kursleiterEinlesen()
        {
            listViewKursleiter.Items.Clear();
            var client = new RestClient("http://localhost:8888");

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
            var client = new RestClient("http://localhost:8888");

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
            labelKurs.Visible = true;
            comboBoxKursTeilnehmer.Visible = true;

            comboBoxKursTeilnehmer.Items.Clear();
            var client = new RestClient("http://localhost:8888");
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
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("kontaktKurse", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<KontaktKurs>>(request);

            foreach (KontaktKurs kk in response.Data)
            {
                if(comboBoxKursTeilnehmer.Text.Equals(kk.KursID.Bezeichnung))
                {
                ListViewItem lvItem = new ListViewItem(kk.KontakID.Vorname.ToString());
                lvItem.SubItems.Add(kk.KontakID.Nachname.ToString());
                listViewTeilnehmer.Items.Add(lvItem);
                }
            }
        }

        private void buttonOffenePosten_Click(object sender, EventArgs e)
        {
            allesVisibleFalseSetzen();
            labelÜberschrift.Text = "Offene Rechnungen";
            listViewOffeneRechnung.Visible = true;
            tableLayoutPanelKursTermin.Visible = true;
            labelBtOffeneRechnungen.Visible = true;
            offenePostenEinlesen();
        }

        private void offenePostenEinlesen()
        {
            listViewOffeneRechnung.Items.Clear();
            var client = new RestClient("http://localhost:8888");

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
    }
}
