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
    public partial class UersForm : Form
    {
        public PersonneClass PERS = null;

        private Form PrecedenteForm = null;
        private List<PersonneClass> tabpers;

        public UersForm(Form precedente)
        {

            InitializeComponent();

            this.PrecedenteForm = precedente;
        }

        private void UersForm_Load(object sender, EventArgs e)
        {
            string app = Application.StartupPath;
            app = app + @"\images\MBoy.ico";
            this.Icon = new Icon(app);

            this.listBox1.Items.Clear();

            string req = "select * from personnes";

            //if (this.tabpers != null) { this.tabpers.Clear(); }
            tabpers = BDGestionAccess2013.REQUETEUR_PERSONNES(req);

            foreach (PersonneClass p in tabpers)
            {
                this.listBox1.Items.Add(p.AffichagePersonne);
            }

            this.comboBox1.SelectedItem = "UTILISATEUR";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {

                this.PERS = this.tabpers[this.listBox1.SelectedIndex];  
            }
        }

        private void rechercheBox_TextChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();

            string req = "select * from personnes where nompers like '" + this.rechercheBox.Text + "%' or prenompers like '"+this.rechercheBox.Text+"%'";

            List<PersonneClass> tabpers = BDGestionAccess2013.REQUETEUR_PERSONNES(req);

            foreach (PersonneClass p in tabpers)
            {
                this.listBox1.Items.Add(p.AffichagePersonne);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.PrecedenteForm.Show();

        }

        private void rechercheBox_MouseHover(object sender, EventArgs e)
        {
            this.textBox1.Text = "RECHERCHE : Tapez les premières lettres d'un nom";
        }

        private void rechercheBox_MouseLeave(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void CreerButt_Click(object sender, EventArgs e)
        {
            int droits = 0;
            string login = this.loginBox.Text;
            string passw = this.mdpBox.Text;

            if (this.comboBox1.SelectedItem.ToString() == "ADMINISTRATEUR")
            {
                droits = 1;
            }

            if (this.PERS != null)
            {
                if ((this.mdpBox.Text != "") || (this.loginBox.Text != ""))
                {
                    Users lol = BDGestionAccess2013.REQUETEUR_USERS(this.loginBox.Text, this.mdpBox.Text);
                    if (lol == null)
                    {
                        BDGestionAccess2013.CREA_USER(this.PERS, droits, 0, login, passw);
                        this.textBox1.Text = "L'utilisateur a été créé. Redémarrez le logiciel..";
                    }
                    else
                    {
                        this.textBox1.Text = "Cet Utilisateur/Administrateur existe déjà !";
                    }
                }
                else
                {
                    this.textBox1.Text = "remplir les login|mot de passe";
                }
            }
            else
            {
                this.textBox1.Text = "Choisir une personne dans la liste";
            }

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mdpBox_MouseHover(object sender, EventArgs e)
        {
            this.textBox1.Text = "champ pour le mot de passe choisi";
        }

        private void loginBox_MouseHover(object sender, EventArgs e)
        {
            this.textBox1.Text = "champ pour le login/pseudo choisi";
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            this.textBox1.Text = "choisir entre administrateur ou utilisateur";
        }

        private void UersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.PrecedenteForm.Show();
        }

        private void RechargerUsers()
        {
            this.listBox1.Items.Clear();

            string req = "select * from personnes";

            tabpers = BDGestionAccess2013.REQUETEUR_PERSONNES(req);

            foreach (PersonneClass p in tabpers)
            {
                this.listBox1.Items.Add(p.AffichagePersonne);
            }
        }




        private void UersForm_MouseHover(object sender, EventArgs e)
        {
            this.textBox1.Text = "avant de créer un user Créez une Personne";
        }
    }
}
