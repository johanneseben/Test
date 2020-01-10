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
            //fHinzuBearb.lstTitel = client.Execute<List<Titel>>(request).Data;
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
                lvItem.SubItems.Add(k.ZeitVon.ToString());
                lvItem.SubItems.Add(k.ZeitBis.ToString());
                lvItem.SubItems.Add(k.DatumVon.ToString());
                lvItem.SubItems.Add(k.DatumBis.ToString());
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
        }

        private void buttonHinzufügen_Click(object sender, EventArgs e)
        {
            FrmHinzufügenBearbeiten fHinzuBea = new FrmHinzufügenBearbeiten();
            fHinzuBea.BackColor = this.BackColor;
            fHinzuBea.Text = buttonHinzufügen.Text;
            fHinzuBea.labelÜberschrift.Text = labelÜberschrift.Text + " " + buttonHinzufügen.Text;

            var client = new RestClient("http://localhost:8888");

            var requestTitel = new RestRequest("titel", Method.GET);
            requestTitel.AddHeader("Content-Type", "application/json");
            var responseTitel = client.Execute<List<Titel>>(requestTitel);

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


            if (labelÜberschrift.Text.Equals("Kontakt"))
            {
                foreach (Titel t in responseTitel.Data)
                {
                    fHinzuBea.comboBoxTitel.Items.Add(t.Bezeichnung.ToString());
                }

                foreach(Altersgruppe a in responseAltersgruppe.Data)
                {
                    fHinzuBea.comboBoxAltersgruppe.Items.Add(a.Bezeichnung.ToString());
                }

                foreach(Sozialgruppe s in responseSozialgruppe.Data)
                {
                    fHinzuBea.comboBoxSozialgruppe.Items.Add(s.Bezeichnung.ToString());
                }

                foreach(Staatsbuergerschaft s in responseStaatsbuergerschaft.Data)
                {
                    fHinzuBea.comboBoxStaatsbuergerschaft.Items.Add(s.Staat.ToString());
                }

            }

            if (labelÜberschrift.Text.Equals("Kurs"))
            {
                foreach (Kurskategorie kk in responseKurskategorie.Data)
                {
                    fHinzuBea.comboBoxKursKurskategorie.Items.Add(kk.Bezeichnung.ToString());
                }
            }

                fHinzuBea.ShowDialog();

            sozialgruppeEinlesen();
            altersgruppenEinlesen();
            titelEinlesen();
            kurseEinlesen();
            kontakteEinlesen();
            kurskategorieEinlesen();
            kurseEinlesen();
            bankverbindungEinlesen();
            passEinlesen();
            gutscheinEinlesen();
            schluesselEinlesen();
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
            if (listViewMitgliedschaft.SelectedItems.Count == 0)
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
            if(labelÜberschrift.Text.Equals("Titel"))
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
    }
}
