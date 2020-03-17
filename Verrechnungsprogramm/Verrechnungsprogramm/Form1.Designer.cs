namespace Verrechnungsprogramm
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbText = new System.Windows.Forms.Label();
            this.tbPasswort = new System.Windows.Forms.TextBox();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.tbBenutzername = new System.Windows.Forms.TextBox();
            this.listViewBenutzer = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.lbText);
            this.panel1.Controls.Add(this.tbPasswort);
            this.panel1.Controls.Add(this.lb2);
            this.panel1.Controls.Add(this.lb1);
            this.panel1.Controls.Add(this.tbBenutzername);
            this.panel1.Location = new System.Drawing.Point(76, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 324);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(61, 210);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Visible = false;
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(342, 186);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(240, 46);
            this.btnlogin.TabIndex = 34;
            this.btnlogin.Text = "LOGIN";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(360, 260);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(200, 27);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zur Registrierung";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.Location = new System.Drawing.Point(55, 255);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(252, 32);
            this.lbText.TabIndex = 11;
            this.lbText.Text = "Neuer Benutzer? ->";
            this.lbText.Visible = false;
            // 
            // tbPasswort
            // 
            this.tbPasswort.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPasswort.Location = new System.Drawing.Point(342, 130);
            this.tbPasswort.Name = "tbPasswort";
            this.tbPasswort.PasswordChar = '*';
            this.tbPasswort.Size = new System.Drawing.Size(240, 40);
            this.tbPasswort.TabIndex = 10;
            this.tbPasswort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPasswort_KeyDown);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.Location = new System.Drawing.Point(54, 125);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(191, 42);
            this.lb2.TabIndex = 8;
            this.lb2.Text = "Passwort:";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(52, 75);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(284, 42);
            this.lb1.TabIndex = 7;
            this.lb1.Text = "Benutzername:";
            // 
            // tbBenutzername
            // 
            this.tbBenutzername.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBenutzername.Location = new System.Drawing.Point(342, 80);
            this.tbBenutzername.Name = "tbBenutzername";
            this.tbBenutzername.Size = new System.Drawing.Size(240, 40);
            this.tbBenutzername.TabIndex = 9;
            // 
            // listViewBenutzer
            // 
            this.listViewBenutzer.HideSelection = false;
            this.listViewBenutzer.Location = new System.Drawing.Point(97, 396);
            this.listViewBenutzer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewBenutzer.Name = "listViewBenutzer";
            this.listViewBenutzer.Size = new System.Drawing.Size(113, 45);
            this.listViewBenutzer.TabIndex = 9;
            this.listViewBenutzer.UseCompatibleStateImageBehavior = false;
            this.listViewBenutzer.View = System.Windows.Forms.View.Details;
            this.listViewBenutzer.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewBenutzer);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbText;
        internal System.Windows.Forms.TextBox tbPasswort;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        public System.Windows.Forms.TextBox tbBenutzername;
        private System.Windows.Forms.ListView listViewBenutzer;
    }
}

