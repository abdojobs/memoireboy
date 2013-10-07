namespace MemoireBoy2013
{
    partial class CreerForm
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
            this.InfoLabCrea = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.titreBox = new System.Windows.Forms.ComboBox();
            this.destCombo = new System.Windows.Forms.ComboBox();
            this.destLab = new System.Windows.Forms.Label();
            this.descripBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.heureBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HeureBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.CreerButt = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoLabCrea
            // 
            this.InfoLabCrea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InfoLabCrea.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabCrea.ForeColor = System.Drawing.Color.White;
            this.InfoLabCrea.Location = new System.Drawing.Point(10, 24);
            this.InfoLabCrea.MaximumSize = new System.Drawing.Size(388, 30);
            this.InfoLabCrea.MinimumSize = new System.Drawing.Size(388, 30);
            this.InfoLabCrea.Name = "InfoLabCrea";
            this.InfoLabCrea.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.InfoLabCrea.Size = new System.Drawing.Size(388, 30);
            this.InfoLabCrea.TabIndex = 29;
            this.InfoLabCrea.Text = "Tapez un titre pour votre tache";
            this.InfoLabCrea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(328, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 37);
            this.button3.TabIndex = 29;
            this.button3.Text = "Fermer";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 342);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.titreBox);
            this.tabPage1.Controls.Add(this.destCombo);
            this.tabPage1.Controls.Add(this.destLab);
            this.tabPage1.Controls.Add(this.descripBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(304, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tache";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // titreBox
            // 
            this.titreBox.Location = new System.Drawing.Point(24, 45);
            this.titreBox.Name = "titreBox";
            this.titreBox.Size = new System.Drawing.Size(256, 21);
            this.titreBox.TabIndex = 24;
            this.titreBox.SelectedIndexChanged += new System.EventHandler(this.titreBox_SelectedIndexChanged);
            this.titreBox.TextChanged += new System.EventHandler(this.titreBox_TextChanged);
            this.titreBox.MouseHover += new System.EventHandler(this.titreBox_MouseHover);
            // 
            // destCombo
            // 
            this.destCombo.Location = new System.Drawing.Point(24, 275);
            this.destCombo.Name = "destCombo";
            this.destCombo.Size = new System.Drawing.Size(256, 21);
            this.destCombo.TabIndex = 26;
            this.destCombo.SelectedIndexChanged += new System.EventHandler(this.destCombo_SelectedIndexChanged);
            // 
            // destLab
            // 
            this.destLab.BackColor = System.Drawing.Color.Black;
            this.destLab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destLab.ForeColor = System.Drawing.Color.White;
            this.destLab.Location = new System.Drawing.Point(24, 245);
            this.destLab.Name = "destLab";
            this.destLab.Size = new System.Drawing.Size(256, 22);
            this.destLab.TabIndex = 23;
            this.destLab.Text = "destinataire de la tâche";
            this.destLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descripBox
            // 
            this.descripBox.ForeColor = System.Drawing.Color.Black;
            this.descripBox.Location = new System.Drawing.Point(24, 104);
            this.descripBox.Name = "descripBox";
            this.descripBox.Size = new System.Drawing.Size(256, 134);
            this.descripBox.TabIndex = 25;
            this.descripBox.Text = "";
            this.descripBox.TextChanged += new System.EventHandler(this.descripBox_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "titre-thème de la tâche du message";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "description - message";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dateTimePicker2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.heureBox2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.HeureBox);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(304, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Date d\'exécution";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dateTimePicker2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(24, 85);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(256, 20);
            this.dateTimePicker2.TabIndex = 42;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "archivage";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(104, 283);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "ARCHIVER LA TACHE";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(104, 195);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 39;
            this.button4.Text = "heure fin";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // heureBox2
            // 
            this.heureBox2.Location = new System.Drawing.Point(214, 198);
            this.heureBox2.Name = "heureBox2";
            this.heureBox2.Size = new System.Drawing.Size(63, 20);
            this.heureBox2.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "heure debut";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "planning de la tache";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeureBox
            // 
            this.HeureBox.Location = new System.Drawing.Point(214, 163);
            this.HeureBox.Name = "HeureBox";
            this.HeureBox.Size = new System.Drawing.Size(63, 20);
            this.HeureBox.TabIndex = 33;
            this.HeureBox.TextChanged += new System.EventHandler(this.HeureBox_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(24, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(256, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(24, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "date debut - fin de tache";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(328, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 37);
            this.button2.TabIndex = 28;
            this.button2.Text = "Effacer";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreerButt
            // 
            this.CreerButt.BackColor = System.Drawing.SystemColors.Control;
            this.CreerButt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreerButt.Location = new System.Drawing.Point(328, 285);
            this.CreerButt.Name = "CreerButt";
            this.CreerButt.Size = new System.Drawing.Size(74, 37);
            this.CreerButt.TabIndex = 27;
            this.CreerButt.Text = "Créer";
            this.CreerButt.UseVisualStyleBackColor = false;
            this.CreerButt.Click += new System.EventHandler(this.CreerButt_Click);
            this.CreerButt.MouseHover += new System.EventHandler(this.CreerButt_MouseHover);
            // 
            // CreerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 436);
            this.Controls.Add(this.InfoLabCrea);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreerButt);
            this.MaximumSize = new System.Drawing.Size(428, 472);
            this.MinimumSize = new System.Drawing.Size(428, 472);
            this.Name = "CreerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreerForm_FormClosing);
            this.Load += new System.EventHandler(this.CreerForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label InfoLabCrea;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox titreBox;
        private System.Windows.Forms.ComboBox destCombo;
        private System.Windows.Forms.Label destLab;
        private System.Windows.Forms.RichTextBox descripBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox heureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HeureBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CreerButt;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}