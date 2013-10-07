using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MemoireBoy2013
{
    public partial class RechercheContactsForm : Form
    {
        Users SuperUser = null;
        Form precedente = null;
        bool modeModif = false;

        public RechercheContactsForm(Users SuperU,Form precedtForm)
        {
            InitializeComponent();
            this.SuperUser = SuperU;
            this.precedente = precedtForm;

        }

        List<PersonneClass> tabpers = null;
        List<string> Grps = null;
        private void RechercheContactsForm_Load(object sender, EventArgs e)
        {

            try
            {
                string app = Application.StartupPath;
                app = app + @"\images\MBoy.ico";
                this.Icon = new Icon(app);
                this.comboBox1.SelectedText = "M";

                this.listBox1.Items.Clear();

                string req = "select * from personnes where nompers like '" + this.rechercheBox.Text + "%' or prenompers like '" + this.rechercheBox.Text + "%'";

                tabpers = BDGestionAccess2013.REQUETEUR_PERSONNES(req);

                foreach (PersonneClass p in tabpers)
                {
                    this.listBox1.Items.Add(p.AffichagePersonne);
                }

                this.miseAjourGroupes();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void miseAjourGroupes()
        {
            string rq = "select * from groupes";
            Grps = BDGestionAccess2013.REQUETEUR_GROUPES(rq);


            this.comboGRP.Items.Clear();
            this.listBoxGRP_1.Items.Clear();
            this.comboBoxSupprGRP.Items.Clear();
            this.comboBoxSupprGRP.Text = "";

            if (!this.comboGRP.Items.Contains("TOUS LES GROUPES")) { this.comboGRP.Items.Add("TOUS LES GROUPES"); }


            foreach (string gg in Grps)
            {
                this.comboGRP.Items.Add(gg);
                this.comboBoxSupprGRP.Items.Add(gg);
                this.listBoxGRP_1.Items.Add(gg);
            }

            if (this.personneAmodifier != null)
            {
                string rqt = "select * from groupes,grppers,personnes where groupes.idgrp = grppers.grpid and grppers.persid = personnes.idpers and personnes.idpers = " + this.personneAmodifier.idPers;
                List<string> lstring = BDGestionAccess2013.REQUETEUR_GROUPES(rqt);

                this.listBoxGRP_2.Items.Clear();

                foreach (string gr in lstring)
                {
                    this.listBoxGRP_2.Items.Add(gr);
                    this.listBoxGRP_1.Items.Remove(gr);
                }
            }
        }

        private void RechargerContacts()
        {
            this.listBox1.Items.Clear();

            string req = "select * from personnes where nompers like '" + this.rechercheBox.Text + "%' or prenompers like '" + this.rechercheBox.Text + "%'";

            tabpers = BDGestionAccess2013.REQUETEUR_PERSONNES(req);

            foreach (PersonneClass p in tabpers)
            {
                this.listBox1.Items.Add(p.AffichagePersonne);
            }
        }

        private void AfficheContacts()
        {
            this.listBox1.Items.Clear();

            foreach (PersonneClass p in tabpers)
            {
                this.listBox1.Items.Add(p.AffichagePersonne);
            }
        }

        private void rechercheBox_TextChanged(object sender, EventArgs e)
        {
            this.RechargerContacts();
        }

        PersonneClass personneAmodifier = null;
        private void afficheDansFormulaire(PersonneClass person)
        {
                this.comboBox1.SelectedItem = person.civilite;
                this.textBoxpn.Text = person.prenom;
                this.textBoxNom.Text = person.nom;
                this.textBoxEmail.Text = person.e_mail;
                this.textBoxTelfixe.Text = person.telfixe;
                this.textBoxTelMob.Text = person.telportable;
                this.textBoxFax.Text = person.fax;

                this.textBoxAdr.Text = person.adresse;
                this.textBoxCP.Text = person.cp;
                this.textBoxVille.Text = person.ville;
                this.textBoxBP.Text = person.bp;

                this.textBoxImage.Text = person.adrImage;
                this.textBoxNote.Text = person.note;
                this.textBoxCV.Text = person.adrDocCV;
                this.textBoxSite.Text = person.site;
                this.textBoxActivite.Text = person.activite;
                this.dateTimePicker1.Value = DateTime.Parse(person.dateNaissance);

                if (person.adrImage != "")
                {
                    if (File.Exists(person.adrImage))
                    {
                        Image img = Image.FromFile(person.adrImage);
                        Bitmap bm = new Bitmap(img, new Size(184, 192));
                        this.pictureBox1.Image = (Image)bm;
                    }
                }
                else
                {
                    this.pictureBox1.Image = null;
                }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                this.CreerButt.Text = "MODIFIER";
                this.modeModif = true;
                PersonneClass person = this.tabpers[this.listBox1.SelectedIndex];
                this.personneAmodifier = person;
                this.afficheDansFormulaire(person);

                this.miseAjourGroupes();

            }
        }

        private void RechercheContactsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.precedente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.precedente.Show();
        }

        private void CreerButt_Click(object sender, EventArgs e)
        {
             PersonneClass p=null;

            if ((this.textBoxNom.Text != "") && (this.textBoxNom.Text != ""))
            {
                if (!modeModif)
                {
                    // A BETONNER
                    p = new PersonneClass();
                    p.civilite = this.comboBox1.Text;
                    p.prenom = this.textBoxpn.Text;
                    p.nom = this.textBoxNom.Text;
                    p.dateNaissance = this.dateTimePicker1.Value.ToShortDateString();
                    p.e_mail = this.textBoxEmail.Text;
                    p.telfixe = this.textBoxTelfixe.Text;
                    p.telportable = this.textBoxTelMob.Text;
                    p.fax = this.textBoxFax.Text;
                    p.adresse = this.textBoxAdr.Text;
                    p.cp = this.textBoxCP.Text;
                    p.ville = this.textBoxVille.Text;
                    p.bp = this.textBoxBP.Text;
                    p.adrImage = this.textBoxImage.Text;
                    p.note = this.textBoxNote.Text;
                    p.adrDocCV = this.textBoxCV.Text;
                    p.site = this.textBoxSite.Text;
                    p.activite = this.textBoxActivite.Text;


                    BDGestionAccess2013.CREA_PERSONNE(p);

                    this.InfoLab.Text = "La personne a été créée";
                }
                else
                {
                    p = this.personneAmodifier;
                    p.civilite = this.comboBox1.Text;
                    p.prenom = this.textBoxpn.Text;
                    p.nom = this.textBoxNom.Text;
                    p.dateNaissance = this.dateTimePicker1.Value.ToShortDateString();
                    p.e_mail = this.textBoxEmail.Text;
                    p.telfixe = this.textBoxTelfixe.Text;
                    p.telportable = this.textBoxTelMob.Text;
                    p.fax = this.textBoxFax.Text;
                    p.adresse = this.textBoxAdr.Text;
                    p.cp = this.textBoxCP.Text;
                    p.ville = this.textBoxVille.Text;
                    p.bp = this.textBoxBP.Text;
                    p.adrImage = this.textBoxImage.Text;
                    p.note = this.textBoxNote.Text;
                    p.adrDocCV = this.textBoxCV.Text;
                    p.site = this.textBoxSite.Text;
                    p.activite = this.textBoxActivite.Text;
                    BDGestionAccess2013.MODIFIE_PERSONNE(p);




                    this.InfoLab.Text = "La personne a été modifiée";
                }
            }
            else
            {
                this.InfoLab.Text = "Commencez à créer votre contact sur l'onglet [joindre rapidement]";
            }

                    foreach (string o in this.listBoxGRP_2.Items)
                    {
                        int idg = BDGestionAccess2013.GROUPES_GETIDBYLIB(o);
                        int idp = BDGestionAccess2013.PERSONNES_GETIDBYPERS(p);
                        BDGestionAccess2013.CREA_GRPPERS(idg, idp);
                    }

            this.RechargerContacts();
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.FileName = "";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                this.textBoxImage.Text = file;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FileName = "";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                this.textBoxCV.Text = file;
            }
        }

        private void InitialiserLesChamps()
        {
            this.comboBox1.Text = "";
            this.textBoxpn.Text = "";
            this.textBoxNom.Text = "";
            this.textBoxEmail.Text = "";
            this.textBoxTelfixe.Text = "";
            this.textBoxTelMob.Text = "";
            this.textBoxFax.Text = "";
            this.textBoxAdr.Text = "";
            this.textBoxCP.Text = "";
            this.textBoxVille.Text = "";
            this.textBoxBP.Text = "";
            this.textBoxImage.Text = "";
            this.textBoxNote.Text = "";
            this.textBoxCV.Text = "";
            this.textBoxSite.Text = "";
            this.textBoxActivite.Text = "";
            this.personneAmodifier = null;
            this.CreerButt.Text = "Créer";
            this.pictureBox1.Image = null;
            this.modeModif = false;
            this.listBox1.SelectedIndex = - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.InitialiserLesChamps();
        }

        private void supprButt_Click(object sender, EventArgs e)
        {
            if (this.personneAmodifier != null)
            {
                BDGestionAccess2013.SUPPRIME_PERSONNE(this.personneAmodifier);
                this.InitialiserLesChamps();
                this.RechargerContacts();
            }
        }

        private void infoGroupe_MouseHover(object sender, EventArgs e)
        {
            this.InfoLab.Text = "Information sur l'appartenance à un groupe";
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            this.InfoLab.Text = "Nommer votre nouveau groupe";
        }

        private void infoGroupe_MouseLeave(object sender, EventArgs e)
        {
            this.InfoLab.Text = "";
        }

        private void buttonCreerGRP_MouseHover(object sender, EventArgs e)
        {
            this.InfoLab.Text = "Créer votre nouveau groupe";
        }

        private void buttonCreerGRP_MouseLeave(object sender, EventArgs e)
        {
            this.InfoLab.Text = "";
        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            this.InfoLab.Text = "Sélection par groupe";
        }

        private void comboBox2_MouseLeave(object sender, EventArgs e)
        {
            this.InfoLab.Text = "";
        }

        private void comboGRP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboGRP.SelectedIndex != -1)
            {
                string rq = "";
                string group = this.comboGRP.SelectedItem.ToString();
                if (this.comboGRP.SelectedItem.ToString() == "TOUS LES GROUPES")
                {
                    rq = "select * from personnes";
                }
                else
                {
                    rq= "select * from personnes, grppers, groupes where groupes.libgrp = '" + group + "' and groupes.idgrp = grppers.grpid and grppers.persid = personnes.idpers ";
                }
                
                
                tabpers = BDGestionAccess2013.REQUETEUR_PERSONNES(rq);
                this.AfficheContacts();

            }

        }



        private void buttonCreerGRP_Click(object sender, EventArgs e)
        {
            if (this.textBoxGRPCrea.Text != "")
            {
                BDGestionAccess2013.CREA_GROUPES(this.textBoxGRPCrea.Text);
                miseAjourGroupes();
            }

            this.textBoxGRPCrea.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((this.listBoxGRP_1.SelectedIndex != -1)) 
            {
                this.listBoxGRP_2.Items.Add(this.listBoxGRP_1.SelectedItem);
                this.listBoxGRP_1.Items.Remove(this.listBoxGRP_1.SelectedItem);
            }
            else
            {
                this.InfoLab.Text = "Selectionnez un groupe dans la liste de gauche";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((this.listBoxGRP_2.SelectedIndex != -1)) 
            {
                string lib = this.listBoxGRP_2.SelectedItem.ToString();
                this.listBoxGRP_1.Items.Add(this.listBoxGRP_2.SelectedItem);
                this.listBoxGRP_2.Items.Remove(this.listBoxGRP_2.SelectedItem);

                int num = BDGestionAccess2013.GROUPES_GETIDBYLIB(lib);
                BDGestionAccess2013.DELETE_GRPPERS(num, personneAmodifier.idPers);
                
            }
            else
            {
                this.InfoLab.Text = "Selectionnez un groupe dans la liste de droite";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string g = "";

            if ((this.comboBoxSupprGRP.SelectedItem != null))
            {
                if (this.comboBoxSupprGRP.SelectedItem.ToString() != "")
                {
                    g = this.comboBoxSupprGRP.SelectedItem.ToString();
                    int num = BDGestionAccess2013.GROUPES_GETIDBYLIB(this.comboBoxSupprGRP.SelectedItem.ToString());
                    BDGestionAccess2013.DELETE_GROUPE(num);

                    this.InfoLab.Text = "Le groupe "+g+" a été supprimé";
                    this.miseAjourGroupes();
                }
            }
        }

        private void tabControl1_MouseHover(object sender, EventArgs e)
        {
            this.InfoLab.Text = "CREER UNE PERSONNE / CONSULTER";
        }

        private void tabControl1_MouseLeave(object sender, EventArgs e)
        {
            this.InfoLab.Text = "";
        }

        private void cvButt_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.textBoxCV.Text))
            {
  /*              System.Diagnostics.ProcessStartInfo myInfo = new System.Diagnostics.ProcessStartInfo();
                myInfo.FileName = "MonAppli.exe";
                myInfo.WorkingDirectory = "MonRepertoire";
                System.Diagnostics.Process.Start(myInfo); */
                try
                {
                    System.Diagnostics.Process.Start(this.textBoxCV.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
}
