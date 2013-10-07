using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;

namespace MemoireBoy2013
{
    public partial class MBoyMain : Form
    {
        Users SuperUser = null;

        public MBoyMain(Users US)
        {
            InitializeComponent();

            this.SuperUser = US;
        }

        public MBoyMain()
        {
            InitializeComponent();
        }

        private void EtablirConnexion()
        {
            bool bol = BDGestionAccess2013.OUVRIRconnexionBD();

        }


        bool EncryptBool = true;
        private DateTime DateCourante;

        private List<Taches> ttab;
        private List<Taches> ttab2; // pour bolder les dates
        private void ChargerLesTaches()
        {
            try
            {
                this.monthCalendar1.SetDate(this.DateCourante);
                this.listDesTaches.Items.Clear();


                string req = "";
                string req2 = "";

                if (this.SuperUser != null)
                {
                    if (this.SuperUser.droitsuser == 0) { req = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "' and archive=false" + " and destinatt=" + this.SuperUser.persUserId; }
                    else { req = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "' and archive=false"; }

                    if (this.SuperUser.droitsuser == 0) { req2 = "select * from taches where archive=false" + " and destinatt=" + this.SuperUser.persUserId; }
                    else { req2 = "select * from taches where archive=false"; }


                }
                else
                {
                    req = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "' and archive=false";
                    req2 = "select * from taches where archive=false";
                }


                ttab = BDGestionAccess2013.REQUETEUR_TACHES(req);
                foreach (Taches t in ttab)
                {
                    this.listDesTaches.Items.Add(t.Description);
                }

                //###############################je bold les dates où il y a tache ##################################


                ttab2 = BDGestionAccess2013.REQUETEUR_TACHES(req2);
                dates = new DateTime[ttab2.Count];

                for (int i = 0; i < ttab2.Count; i++)
                {
                    dates[i] = DateTime.Parse(ttab2[i].Datdeb);
                }



                this.monthCalendar1.BoldedDates = dates;
              
                // ###########################################################################################################

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private string FormaterDateTO_EN(DateTime dt)
        {
              return dt.Month + "/" + dt.Day + "/" + dt.Year;
        }

        private string FormaterDateTO_FR(DateTime dt)
        {
            return dt.Day + "/" + dt.Month + "/" + dt.Year;
        }


        DateTime[] dates = null;
        private void ChargerLesTaches(string requete)
        {
            try
            {
                this.monthCalendar1.SetDate(this.DateCourante);
                this.listDesTaches.Items.Clear();

                string req = requete;

                ttab = BDGestionAccess2013.REQUETEUR_TACHES(req);
                foreach (Taches t in ttab)
                {
                    this.listDesTaches.Items.Add(t.Description);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void ChargementDesImages()
        {
            try
            {
                string app = Application.StartupPath;
                app = app + @"\images\MBoy.ico";
                this.Icon = new Icon(app);
                this.toolStripButton1.Image = Image.FromFile(Application.StartupPath + @"\images\rechercheContacts.bmp");
                this.toolStripButton2.Image = Image.FromFile(Application.StartupPath + @"\images\somebody.bmp");
                this.toolStripButton3.Image = Image.FromFile(Application.StartupPath + @"\images\ecrire.bmp");
                this.toolStripButton4.Image = Image.FromFile(Application.StartupPath + @"\images\supprimer.bmp");
                this.toolStripButton5.Image = Image.FromFile(Application.StartupPath + @"\images\modifier.bmp");
                this.toolStripButton6.Image = Image.FromFile(Application.StartupPath + @"\images\up.bmp");
                this.toolStripButton7.Image = Image.FromFile(Application.StartupPath + @"\images\down.bmp");
                this.toolStripButton8.Image = Image.FromFile(Application.StartupPath + @"\images\archivermoins.bmp");
                this.button12.Image = Image.FromFile(Application.StartupPath + @"\images\go.bmp");

                this.toolStripButton10.Image = Image.FromFile(Application.StartupPath + @"\images\cle.bmp");
                this.toolStripButton9.Image = Image.FromFile(Application.StartupPath + @"\images\ampoule.bmp");

                this.toolStripButton11.Image = Image.FromFile(Application.StartupPath + @"\images\archiver.bmp");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.Source);
            }
        }

        void ChargerLesTitres()
        {
            try
            {
                this.comboTrie.Items.Clear();

                string req = "select distinct(titret) from taches";

                List<string> tabstr = BDGestionAccess2013.REQUETEUR_TITRES_TACHES(req);

                this.comboTrie.Items.Add("TOUTES LES TACHES");

                foreach (string t in tabstr)
                {
                    this.comboTrie.Items.Add(t.ToUpper());
                }

                this.comboTrie.Text = "TOUTES LES TACHES";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void MiseAJour()
        {
            // ########## tjrs dans cet ordre ##############
            this.ChargerLesTaches();
            this.ChargerLesTitres();
            // #############################################

            this.MiseAJourDuJournal();

        }

        private void MiseAJourDuJournal()
        {
            string rq = "select * from journal where datej='" + this.DateCourante.ToShortDateString() + "'";
            string txt = BDGestionAccess2013.REQUETEUR_JOURNAL(rq);

            if (!this.EncryptBool)
            {
                if (txt != "")
                {
                    txt = Encrypt.DecryptString(txt);
                }
            }

                this.JOURNAL_box.Text = "";
                this.JOURNAL_box.Text = txt;



        }


        
        private void MBoyMain_Init()
        {
            this.DateCourante = DateTime.Today;
            this.statusBar1.Text = "";
           if(this.SuperUser!=null)
            {
                string ut = "UTILISATEUR : ";
                if (this.SuperUser.droitsuser == 1) { ut = "ADMINISTRATEUR : "; }
                PersonneClass p = BDGestionAccess2013.GET_PERSONNEBY(this.SuperUser.persUserId );
                if (p != null)
                {
                    this.statusBar1.Text = ut + p.prenom + " " + p.nom;
                }


            }
        }

        private void MBoyMain_Load(object sender, EventArgs e)
        {

            this.ChargementDesImages();
            this.MBoyMain_Init();

            this.EtablirConnexion();

            this.VerifierBaseJournal2013();
            this.JOURNAL_box.Enabled = false;

            this.MiseAJour();



        }



        private void VerifierBaseJournal2013()
        {
            bool ok = BDGestionAccess2013.TABLE_EXIST("journal");

            if (!ok) // je crée la table journal V2013 1.0.0
            {
                BDGestionAccess2013.CREATE_TABLE("CREATE TABLE journal ([idj] AUTOINCREMENT NOT NULL PRIMARY KEY , [textj] MEMO NULL, [datej] VARCHAR(20))");
            }


        }

        private void listDesTaches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listDesTaches.SelectedIndex != -1)
            {
                Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndex];

                ToolTip l_myToolTip = new ToolTip();
                l_myToolTip.AutoPopDelay = 10000;
                l_myToolTip.BackColor = Color.Black;
                l_myToolTip.ForeColor = Color.White;
                l_myToolTip.ToolTipTitle = SelectedTache.Titre;

                if (SelectedTache.Datdeb == SelectedTache.Datfin)
                {
                    l_myToolTip.SetToolTip(this.listDesTaches, SelectedTache.Datdeb +"\r\n\t(" + SelectedTache.Heuredeb + "->" + SelectedTache.Heurefin + ")");
                }
                else
                {
                    l_myToolTip.SetToolTip(this.listDesTaches, SelectedTache.Datdeb + "->" + SelectedTache.Datfin + "\r\n\t(" + SelectedTache.Heuredeb + "->" + SelectedTache.Heurefin + ")");
                }
            }
        }

        private void listDesTaches_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.listDesTaches.SelectedIndex != -1)
            {
                switch (e.KeyCode)
                {
                    case Keys.M: this.SelectedTacheModif = this.ttab[this.listDesTaches.SelectedIndex];  this.toolStripButton5_Click(sender, e); break; // modifier
                    case Keys.Delete: BDGestionAccess2013.SUPPRIME_TACHE(this.ttab[this.listDesTaches.SelectedIndex]); this.MiseAJour(); break; // supprimer
                    case Keys.A: this.toolStripButton11_Click(sender, e); break;
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.DateCourante = this.monthCalendar1.SelectionStart;

            this.ChargerLesTaches();
            this.InfoLab.Text = this.DateCourante.ToLongDateString();
            this.detailminibox.Text = "\r\nToutes les taches du " + this.DateCourante.ToShortDateString();
            this.MiseAJourDuJournal();
           
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.DateCourante = this.monthCalendar1. SelectionStart;
            
            this.ChargerLesTaches();
            this.InfoLab.Text = this.DateCourante.ToLongDateString();
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.SuperUser != null)
            {
                CreerForm creerForm = new CreerForm(this.SuperUser, this);
                this.Hide();
                creerForm.Show();
            }
            else // si il n'y a pas de user 
            {
                this.InfoLab.Text = "1.créez une personne !  2.Créez un administrateur !";
                this.detailminibox.Text = "\r\nPour ce faire cliquez sur le premier bouton à gauche !";
            }
       }

        private void MBoyMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool lob = BDGestionAccess2013.FERMERconnexionBD();
            Application.Exit();
        }


        private void listDesTaches_Click(object sender, EventArgs e)
        {
            if (this.listDesTaches.SelectedIndex != -1)
            {
                Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndex];

                this.InfoLab.Text = SelectedTache.Titre;

                this.detailminibox.Text = "\r\n" + SelectedTache.Description.ToString() + "\r\n" + "\r\n";
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.listDesTaches.SelectedIndex != -1)
            {
                Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndex];
                BDGestionAccess2013.SUPPRIME_TACHE(SelectedTache);
                this.MiseAJour();
            }
            else
            {
                this.detailminibox.Text = "\r\nSELECTIONNEZ D'ABORD UNE TACHE";
            }


        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.listDesTaches.SelectedIndex != -1)
            {
                CreerForm creerForm = new CreerForm(this.SuperUser, this, this.SelectedTacheModif);
                this.Hide();
                creerForm.Show();
            }
            else
            {
                this.detailminibox.Text = "\r\nSELECTIONNEZ D'ABORD UNE TACHE";
            }
        }

        private void rademain_Click(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1)&&(this.listDesTaches.SelectedIndices.Count!=0))
            {

                for (int i = 0; i < this.listDesTaches.SelectedIndices.Count; i++)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndices[i]];
                    BDGestionAccess2013.REPORT_A_DEMAIN(SelectedTache,this.DateCourante);
                }

                this.MiseAJour();
            }

        }


        private Taches SelectedTacheModif;
        private void listDesTaches_DoubleClick(object sender, EventArgs e)
        {
            if (this.listDesTaches.SelectedIndex != -1)
            {
                SelectedTacheModif = this.ttab[this.listDesTaches.SelectedIndex];

                this.detailminibox.Text = "\r\n" + SelectedTacheModif.Description.ToString() + "\r\n" + "\r\n";

                this.toolStripButton5_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1) && (this.listDesTaches.SelectedIndices.Count != 0))
            {

                for (int i = 0; i < this.listDesTaches.SelectedIndices.Count; i++)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndices[i]];
                    BDGestionAccess2013.REPORT_A_HIER(SelectedTache, this.DateCourante);
                }

                this.MiseAJour();
            }
        }

        private void comboTrie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rq ="";
            string complement = this.comboTrie.SelectedItem.ToString();
            if (complement == "TOUTES LES TACHES")
            {
                if (this.SuperUser != null)
                {
                    if (this.SuperUser.droitsuser == 0) { rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "'" + " and archive=false and destinatt=" + this.SuperUser.persUserId; }
                    else { rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "'" + " and archive=false"; }
                }
                else
                {
                    rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "'" + " and archive=false"; 
                }
            }
            else
            {
                if (this.SuperUser != null)
                {
                    if (this.SuperUser.droitsuser == 0) { rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "' and titret='" + complement + "'" + " and archive=false  and destinatt=" + this.SuperUser.persUserId; }
                    else { rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "' and titret='" + complement + "'" + " and archive=false"; }
                }
                else
                {
                    rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "' and titret='" + complement + "'" + " and archive=false"; 
                }
            }


            this.ChargerLesTaches(rq);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.MiseAJour();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nToutes les taches du " + this.DateCourante.ToShortDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void MBoyMain_Shown(object sender, EventArgs e)
        {
            this.MiseAJour();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1) && (this.listDesTaches.SelectedIndices.Count != 0))
            {

                for (int i = 0; i < this.listDesTaches.SelectedIndices.Count; i++)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndices[i]];
                    BDGestionAccess2013.REPORT_UNE_DATE(SelectedTache, this.dateTimePicker1.Value);
                    this.MiseAJour();
                }

            }
            else
            {
                this.detailminibox.Text = "\r\nChoisir une tache à reporter !";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string rq = "select * from taches where datdebt = '" + this.DateCourante.ToShortDateString() + "'" + " and archive=true";
            this.ChargerLesTaches(rq);
            this.InfoLab.Text = "ARCHIVES";
        }

        private void MBoyMain_Activated(object sender, EventArgs e)
        {
            this.MiseAJour();
        }

        private void toolStripButton3_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nCREER UNE TACHE";
        }


        private void toolStripButton4_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nSUPPRIMER UNE TACHE (ou utilisez touche suppr)";
        }

        private void toolStripButton5_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nMODIFIER UNE TACHE (ou double cliquez dessus)";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1) && (this.listDesTaches.SelectedIndices.Count != 0))
            {
                if (this.listDesTaches.SelectedIndex != 0)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndex];
                    Taches AvantSelectedTache = this.ttab[this.listDesTaches.SelectedIndex - 1];

                    BDGestionAccess2013.SUPPRIME_TACHE(AvantSelectedTache);
                    BDGestionAccess2013.SUPPRIME_TACHE(SelectedTache);
                    BDGestionAccess2013.CREA_TACHE(SelectedTache, AvantSelectedTache.TacheID);
                    BDGestionAccess2013.CREA_TACHE(AvantSelectedTache, SelectedTache.TacheID);               
                    this.MiseAJour();
                }
                    

            }




        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1) && (this.listDesTaches.SelectedIndices.Count != 0))
            {
                if (this.listDesTaches.SelectedIndex != this.listDesTaches.Items.Count-1)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndex];
                    Taches ApresSelectedTache = this.ttab[this.listDesTaches.SelectedIndex + 1];

                    BDGestionAccess2013.SUPPRIME_TACHE(ApresSelectedTache);
                    BDGestionAccess2013.SUPPRIME_TACHE(SelectedTache);

                    BDGestionAccess2013.CREA_TACHE(ApresSelectedTache, SelectedTache.TacheID);                    
                    BDGestionAccess2013.CREA_TACHE(SelectedTache, ApresSelectedTache.TacheID);
                    this.MiseAJour();
                }

            }



        }

        private void toolStripButton6_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nFaire remonter une tache dans la liste";
        }

        private void toolStripButton7_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nFaire descendre une tache dans la liste";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RechercheContactsForm rcf = new RechercheContactsForm(this.SuperUser, this);
            this.Hide();
            rcf.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.SuperUser != null)
            {
                if (this.SuperUser.droitsuser == 1)
                {
                    UersForm usersF = new UersForm(this);
                    this.Hide();
                    usersF.Show();
                }
                else
                {
                    this.detailminibox.Text = "\r\nVous devez vous connecter en tant qu'administrateur.";
                }
            }
            else
            {
                int o = BDGestionAccess2013.COUNT("users", "select count(*) from users");
                if (o ==0)
                {
                    UersForm usersF = new UersForm(this);
                    this.Hide();
                    usersF.Show();
                }
            }
        }

        private void toolStripButton2_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nCreer un utilisateur ou un administrateur";
        }

        private void toolStripButton1_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nCreer Modifier Rechercher Supprimer un Contact ou une Personne";
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1) && (this.listDesTaches.SelectedIndices.Count != 0))
            {

                for (int i = 0; i < this.listDesTaches.SelectedIndices.Count; i++)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndices[i]];
                    BDGestionAccess2013.MODIFIE_TACHE_ARCHIVEPLUS(SelectedTache);
                }

                this.MiseAJour();
            }

 
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if ((this.listDesTaches.SelectedIndex != -1) && (this.listDesTaches.SelectedIndices.Count != 0))
            {

                for (int i = 0; i < this.listDesTaches.SelectedIndices.Count; i++)
                {
                    Taches SelectedTache = this.ttab[this.listDesTaches.SelectedIndices[i]];
                    BDGestionAccess2013.MODIFIE_TACHE_ARCHIVEMOINS(SelectedTache);
                }

                this.MiseAJour();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (this.EncryptBool) { this.EncryptBool = false; this.JOURNAL_box.Enabled = true;  }
            else
            {
                if (!this.EncryptBool) { this.EncryptBool = true; this.JOURNAL_box.Enabled = false; }
            }
            this.MiseAJour();

        }

        private void toolStripButton10_MouseHover(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            this.detailminibox.Text = "";
        }

        private void toolStripButton8_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nSORTIR DES ARCHIVES !";
        }

        private void toolStripButton11_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nARCHIVER !";
        }

        private void toolStripButton8_MouseLeave(object sender, EventArgs e)
        {
            this.detailminibox.Text = "";
        }

        private void toolStripButton11_MouseLeave(object sender, EventArgs e)
        {
            this.detailminibox.Text = "";
        }

        private void toolStripButton2_MouseLeave(object sender, EventArgs e)
        {
            this.detailminibox.Text = "";
        }

        private void menuItem48_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void JourCreer_Click(object sender, EventArgs e)
        {
            if (this.JOURNAL_box.Text != "")
            {
                string txt = this.JOURNAL_box.Text.Replace("'", "''");
                txt = Encrypt.EncryptString(txt);
                BDGestionAccess2013.CREA_JOUR_DS_JOURNAL(txt, this.DateCourante.ToShortDateString());
                this.MiseAJourDuJournal();
            }
            else
            {
                this.detailminibox.Text = "\r\nSAISIR UN TEXTE !";
            }

 
        }

        private void JourModifier_Click(object sender, EventArgs e)
        {
            if (this.JOURNAL_box.Text != "")
            {
                string txt = this.JOURNAL_box.Text.Replace("'", "''");
                txt = Encrypt.EncryptString(txt);
                BDGestionAccess2013.MODIF_JOUR_DS_JOURNAL(txt, this.DateCourante.ToShortDateString());
            }

            this.MiseAJourDuJournal();
        }

        private void JourCreer_MouseHover(object sender, EventArgs e)
        {
            this.detailminibox.Text = "\r\nCréer à la date du " + this.DateCourante.ToShortDateString();
        }

        private void JourCreer_MouseLeave(object sender, EventArgs e)
        {
            this.detailminibox.Text = "";
        }

        private void JourSuppr_Click(object sender, EventArgs e)
        {
            BDGestionAccess2013.SUPPRIME_JOUR_DS_JOURNAL(this.DateCourante.ToShortDateString());
            this.MiseAJourDuJournal();
        }

        private void JourEfface_Click(object sender, EventArgs e)
        {
            this.JOURNAL_box.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {


            if(this.rechercheBox.Text!="")
            {
                string rech = this.rechercheBox.Text;
                ttab = BDGestionAccess2013.REQUETEUR_TACHES("select * from taches where descript like '%" + rech + "%'");

                this.listDesTaches.Items.Clear();
                foreach (Taches t in ttab)
                {
                    this.listDesTaches.Items.Add(t.Description);

                }

            }
        }

        private void menuItem53_Click(object sender, EventArgs e)
        {
            quiForm rcf = new quiForm(this);
            this.Hide();
            rcf.Show();
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }














    }
}
