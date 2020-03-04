using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marathon_Skills_2015
{
    public partial class Main_Screen : Form
    {
        public Main_Screen()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Forms.Login_Screen login = new Forms.Login_Screen();
            login.Show();
        }
        public void AlterVisibilite() {
            if (this.Visible)
            {
                this.Visible = false;
            }
            else {
                Visible = true;
            }
        }

        private void btnIwant_Click(object sender, EventArgs e)
        {

        }
    }
}
