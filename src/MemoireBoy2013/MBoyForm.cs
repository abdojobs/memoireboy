using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MemoireBoy2013
{
    public partial class MBoyForm : Form
    {
        public MBoyForm()
        {
            InitializeComponent();
        }

        //TODO: Extraire les 2 méthodes ci-dessous dans une classe contrôleur à passer au constructeur

        /// <summary>
        /// Initialise l'IHM
        /// </summary>
        private void Initialize()
        {
            try
            {
                string app = Application.StartupPath;
                app = app + @"\images\MBoy.ico";
                Icon = new Icon(app);
                Text = "MEMOIREBOY";
                Image localimg = System.Drawing.Image.FromFile(Application.StartupPath + @"/images/" + "imgapp.bmp");
                BackgroundImage = localimg;
                ClientSize = new System.Drawing.Size(320, 320);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Tente de loguer un utilisateur avec un login et un mot de passe
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        private void LoginTry(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                BDGestionAccess2013.OUVRIRconnexionBD();
                Users us = BDGestionAccess2013.REQUETEUR_USERS(userName, password);

                if (us != null)
                {
                    MBoyMain mb = new MBoyMain(us);
                    Hide();
                    mb.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }


        private void MBoyForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TODO : éviter de sortir directement de l'application depuis cette ihm
            // NOTE : voir pour instancier et ouvrir cette IHM à partir de MBoyMain, plutôt que de les enchaîner (voir aussi méthode LoginTry à modifier)
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginTry(UserBox.Text, MdpBox.Text);
        }

        private void MdpBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                LoginTry(UserBox.Text, MdpBox.Text);
            }
        }    
    }
}
