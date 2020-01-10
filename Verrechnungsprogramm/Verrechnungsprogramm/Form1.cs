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




namespace Verrechnungsprogramm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:8888");

            var request = new RestRequest("benutzer", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Benutzer>>(request);

            
            foreach (Benutzer b in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(b.BenutzerID.ToString());
                lvItem.SubItems.Add(b.Benutzername.ToString());
                lvItem.SubItems.Add(b.Passwort.ToString());

                //listViewBenutzer.Items.Add(b.Benutzername);
                //MessageBox.Show(b.Benutzername);
                //MessageBox.Show(String.Join("", b.Benutzername));
                //MessageBox.Show(b..ToString());
                
            }

            

            var request2 = new RestRequest("benutzer/{id}", Method.GET);

            request2.AddUrlSegment("id", "11");
            request2.AddHeader("Content-Type", "application/json");
            var response2 = client.Execute<Benutzer>(request2);

           // MessageBox.Show(response2.Data.Author.ToString());
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            FrmHaupt fHaupt = new FrmHaupt();

            var client = new RestClient("http://localhost:8888");
            var request = new RestRequest("benutzer", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<List<Benutzer>>(request);
            bool richtig = false;

            foreach (Benutzer b in response.Data)
            {
                ListViewItem lvItem = new ListViewItem(b.BenutzerID.ToString());
                lvItem.SubItems.Add(b.Benutzername.ToString());
                lvItem.SubItems.Add(b.Passwort.ToString());

                if ((lvItem.SubItems[1].Text.ToString().Equals(tbBenutzername.Text.ToString())) && ((lvItem.SubItems[2].Text.ToString().Equals(tbPasswort.Text.ToString()))))
                {
                    richtig = true;
                }
            }
            if(richtig==true)
            {
                //MessageBox.Show("Erfolgreich angemeldet!");
                fHaupt.Location = new System.Drawing.Point(0, 0);
                fHaupt.BackColor = this.BackColor;
                fHaupt.ShowDialog();
                
                //this.Close();
                
            }
            else
            {
                MessageBox.Show("Benutzername oder Passwort ist falsch!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
