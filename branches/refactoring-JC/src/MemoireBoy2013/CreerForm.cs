using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemoireBoy2013
{
    public partial class CreerForm : Form
    {

        Users SuperUser = null;
        public CreerForm(Users SuperU, Form precedant)
        {
            InitializeComponent();

            this.formulaire_precedant = precedant;
            this.TacheAcreer = new Taches();
            this.SuperUser = SuperU;
        }

        public CreerForm(Form precedant)
        {
            InitializeComponent();

            this.formulaire_precedant = precedant;
            this.TacheAcreer = new Taches();
        }


        public CreerForm(Users SuperU, Form precedant, Taches taModifier)
        {
            InitializeComponent();

            this.ModeModif = true;
            this.formulaire_precedant = precedant;
            this.TacheCouranteAmodifier = taModifier;
            this.CreerButt.Text = "Modifier";
            this.SuperUser = SuperU;
        }

        Form formulaire_precedant;
        bool ModeModif = false;
        Taches TacheCouranteAmodifier;
        Taches TacheAcreer;
        private void CreerForm_Load(object sender, EventArgs e)
        {
            try
            {
                string app = Application.StartupPath;
                app = app + @"\images\MBoy.ico";
                this.Icon = new Icon(app);

                this.ChargerLesTitres();
                this.ChargerLesUsers();
                this.HeureBox.Text = DateTime.Now.ToShortTimeString();
                this.heureBox2.Text = DateTime.Now.AddHours(1).ToShortTimeString();



                if (this.ModeModif)
                {

                    int o = BDGestionAccess2013.UserCount();


                    this.dateTimePicker1.Value = DateTime.Parse(this.TacheCouranteAmodifier.Datdeb);
                    this.dateTimePicker2.Value = DateTime.Parse(this.TacheCouranteAmodifier.Datfin);
                    this.checkBox1.Checked = this.TacheCouranteAmodifier.Archive;

                    if (o > 0)
                    {
                        PersonneClass pepe = BDGestionAccess2013.GET_PERSONNEBY(this.TacheCouranteAmodifier.DestinatId);
                        if (pepe != null)
                        {
                            this.destCombo.SelectedItem = pepe.prenom + " " + pepe.nom;
                        }
                    }
                }
                else
                {
                    if (this.SuperUser != null)
                    {
                        PersonneClass meme = BDGestionAccess2013.GET_PERSONNEBY(this.SuperUser.persUserId);
                        if (meme != null)
                        {
                            this.destCombo.SelectedItem = meme.prenom + " " + meme.nom;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("erreur pepe " + "\r\n" + ex.Message);
            }
        
        }

        private List<PersonneClass> tp = null; 
        private void ChargerLesUsers()
        {

            try
            {
                string requete = "select * from personnes,users where personnes.idpers = users.persuserid";

                tp = BDGestionAccess2013.REQUETEUR_PERSONNES(requete);

                foreach (PersonneClass pers in tp)
                {
                    this.destCombo.Items.Add(pers.prenom + " " + pers.nom);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void ChargerLesTitres()
        {
            string req = "select distinct(titret) from taches";

            List<string> tabstr = BDGestionAccess2013.REQUETEUR_TITRES_TACHES(req);


            foreach (string t in tabstr)
            {
                if (this.ModeModif) { if (this.TacheCouranteAmodifier.Titre != t) { this.titreBox.Items.Add(t); } }
                else
                {
                    this.titreBox.Items.Add(t);
                }
                
            }

            if (this.ModeModif)
            {
                this.titreBox.Text = this.TacheCouranteAmodifier.Titre;
                this.descripBox.Text = this.TacheCouranteAmodifier.Description;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.formulaire_precedant.Show();
        }

        private int destinataireDeLaTache = 0;
        private void CreerButt_Click(object sender, EventArgs e)
        {
            if (!this.ModeModif)
            {
                //this.TacheAcreer.TacheID = null;
                this.TacheAcreer.Titre = this.titreBox.Text.Replace("'","''");
                this.TacheAcreer.Description = this.descripBox.Text.Replace("'", "''");
                this.TacheAcreer.Datdeb = this.dateTimePicker1.Value.ToShortDateString();
                this.TacheAcreer.Datfin = this.dateTimePicker2.Value.ToShortDateString(); 
                this.TacheAcreer.Heuredeb = this.HeureBox.Text;
                this.TacheAcreer.Heurefin = this.heureBox2.Text;
                this.TacheAcreer.Datcrea = DateTime.Today.ToShortTimeString();
                this.TacheAcreer.Heurecrea = DateTime.Now.ToShortTimeString();
                this.TacheAcreer.AuteurId = 0; // defaut
                this.TacheAcreer.DestinatId = this.destinataireDeLaTache; // defaut
                this.TacheAcreer.Archive = false;

                if (this.titreBox.Text != "")
                {
                    BDGestionAccess2013.CREA_TACHE(this.TacheAcreer);
                    this.InfoLabCrea.Text = "LA TACHE A ETE CREE";
                }
                else
                {
                    this.CreerButt.BackColor = Color.Red;
                    this.InfoLabCrea.Text = "DEFINIR UN TITRE POUR LA TACHE";
                }
            }
            else
            {
                if (this.titreBox.Text != "")
                {
                    BDGestionAccess2013.MODIFIE_TACHE(this.TacheCouranteAmodifier);
                    this.InfoLabCrea.Text = "LA TACHE A ETE MODIFIEE";
                }
                else
                {
                    this.CreerButt.BackColor = Color.Red;
                    this.InfoLabCrea.Text = "DEFINIR UN TITRE POUR LA TACHE";
                }
            }

        }

        private void titreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModeModif)
            {
                this.TacheCouranteAmodifier.Titre = this.titreBox.Text;
            }
        }

        private void descripBox_TextChanged(object sender, EventArgs e)
        {
            if (ModeModif)
            {
                this.TacheCouranteAmodifier.Description = this.descripBox.Text;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (ModeModif)
            {
                this.TacheCouranteAmodifier.Datdeb = this.dateTimePicker1.Value.ToShortDateString();
            }
        }

        private void HeureBox_TextChanged(object sender, EventArgs e)
        {
            if (ModeModif)
            {
                this.TacheCouranteAmodifier.Heuredeb = this.HeureBox.Text;
            }
        }

        private void CreerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            button3_Click(sender, e);
        }

        private void titreBox_TextChanged(object sender, EventArgs e)
        {
            if (ModeModif) { this.TacheCouranteAmodifier.Titre = this.titreBox.Text; }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (ModeModif)
            {
                this.TacheCouranteAmodifier.Datfin = this.dateTimePicker2.Value.ToShortDateString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ModeModif)
            {
                if (this.checkBox1.Checked)
                {
                    this.TacheCouranteAmodifier.Archive = true;
                }

                if (!this.checkBox1.Checked)
                {
                    this.TacheCouranteAmodifier.Archive = false;
                }

            }
            else
            {
                if (this.checkBox1.Checked)
                {
                    this.TacheAcreer.Archive = true;
                }

                if (!this.checkBox1.Checked)
                {
                    this.TacheAcreer.Archive = false;
                }
            }
        }


        private void destCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.destCombo.SelectedIndex != -1)
                {
                    PersonneClass p = this.tp[this.destCombo.SelectedIndex];

                    if (this.ModeModif)
                    {
                        this.TacheCouranteAmodifier.DestinatId = p.idPers;
                        this.TacheCouranteAmodifier.AuteurId = this.SuperUser.persUserId;
                    }
                    else
                    {
                        this.destinataireDeLaTache = p.idPers;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.descripBox.Text = "";

        }

        private void titreBox_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void CreerButt_MouseHover(object sender, EventArgs e)
        {
            this.CreerButt.BackColor = Control.DefaultBackColor;
        }
    }
}
