namespace MemoireBoy2013
{
    partial class UersForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rechercheBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.CreerButt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.mdpBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 188);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(432, 186);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // rechercheBox
            // 
            this.rechercheBox.Location = new System.Drawing.Point(12, 49);
            this.rechercheBox.Name = "rechercheBox";
            this.rechercheBox.Size = new System.Drawing.Size(432, 20);
            this.rechercheBox.TabIndex = 1;
            this.rechercheBox.TextChanged += new System.EventHandler(this.rechercheBox_TextChanged);
            this.rechercheBox.MouseLeave += new System.EventHandler(this.rechercheBox_MouseLeave);
            this.rechercheBox.MouseHover += new System.EventHandler(this.rechercheBox_MouseHover);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ADMINISTRATEUR",
            "UTILISATEUR"});
            this.comboBox1.Location = new System.Drawing.Point(12, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(432, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseHover += new System.EventHandler(this.comboBox1_MouseHover);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(331, 386);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 37);
            this.button3.TabIndex = 29;
            this.button3.Text = "Fermer";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CreerButt
            // 
            this.CreerButt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreerButt.Location = new System.Drawing.Point(171, 386);
            this.CreerButt.Name = "CreerButt";
            this.CreerButt.Size = new System.Drawing.Size(113, 37);
            this.CreerButt.TabIndex = 28;
            this.CreerButt.Text = "Créer";
            this.CreerButt.Click += new System.EventHandler(this.CreerButt_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(432, 18);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "avant de créer un user Créez une Personne";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(12, 121);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(201, 20);
            this.loginBox.TabIndex = 33;
            this.loginBox.MouseHover += new System.EventHandler(this.loginBox_MouseHover);
            // 
            // mdpBox
            // 
            this.mdpBox.Location = new System.Drawing.Point(243, 121);
            this.mdpBox.Name = "mdpBox";
            this.mdpBox.PasswordChar = '*';
            this.mdpBox.Size = new System.Drawing.Size(201, 20);
            this.mdpBox.TabIndex = 34;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox2.Location = new System.Drawing.Point(12, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(432, 18);
            this.textBox2.TabIndex = 35;
            this.textBox2.Text = "liste des personnes";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 449);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.mdpBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CreerButt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.rechercheBox);
            this.Controls.Add(this.listBox1);
            this.Name = "UersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GESTIONNAIRE DES UTILISATEURS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UersForm_FormClosing);
            this.Load += new System.EventHandler(this.UersForm_Load);
            this.MouseHover += new System.EventHandler(this.UersForm_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox rechercheBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CreerButt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox mdpBox;
        private System.Windows.Forms.TextBox textBox2;
    }
}