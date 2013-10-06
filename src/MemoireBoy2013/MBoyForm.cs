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
                this.Icon = new Icon(app);
                this.Text = "MEMOIREBOY";
                Image localimg = System.Drawing.Image.FromFile(Application.StartupPath + @"/images/" + "imgapp.bmp");
                this.BackgroundImage = localimg;
                this.ClientSize = new System.Drawing.Size(320, 320);
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
            if ((this.UserBox.Text != "") && (this.MdpBox.Text != ""))
            {
                bool bol = BDGestionAccess2013.OUVRIRconnexionBD("memoireboy2013");
                Users us = BDGestionAccess2013.REQUETEUR_USERS(this.UserBox.Text, this.MdpBox.Text);

                if (us != null)
                {
                    MBoyMain mb = new MBoyMain(us);
                    this.Hide();
                    mb.Show();
                }
                else
                {
                    Application.Exit();
                }

            }
            
        }

        private void MBoyForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MdpBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}
