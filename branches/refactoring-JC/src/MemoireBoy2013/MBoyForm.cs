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

        private void MBoyForm_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginTry();
        }

        private void MdpBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                LoginTry();
            }
        }

        private void LoginTry()
        {
            if (!string.IsNullOrEmpty(UserBox.Text) && !string.IsNullOrEmpty(MdpBox.Text))
            {
                BDGestionAccess2013.OUVRIRconnexionBD();
                Users us = BDGestionAccess2013.REQUETEUR_USERS(UserBox.Text, MdpBox.Text);

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
    
    }
}
