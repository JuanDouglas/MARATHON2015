using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Media;

namespace Marathon_Skills_2015.Forms
{
    public partial class Login_Screen : Form
    {
        public Login_Screen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "test" && txtPassword.Text == "admin")
            {
                new Test.Test().Show();
            }
            else {
                if (true)
                {
                    new Pos_Login().ShowDialog();
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible = false;
            new Main_Screen().Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                txtEmail.Text = null;
                txtPassword.Text = null;
            }
            else {
                btnBack_Click(null, null);
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter your email adress") {
                txtEmail.Text = null;
                txtEmail.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void txtPassword_Click(object sender, EventArgs e) {
            if (txtPassword.Text == "Enter your passsword") {
                txtPassword.Text = null;
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
