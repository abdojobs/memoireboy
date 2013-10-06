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
    public partial class quiForm : Form
    {
        private Form precedente = null;
        public quiForm(Form prece)
        {
            InitializeComponent();
            this.precedente = prece;
        }

        private void quiForm_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Stéphane Varloteaux\r\n\r\ncontact@memoireboy.fr\r\n\r\nVersion Beta";

        }

        private void quiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.precedente.Show();
        }
    }
}
