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
        public void Login(string email, string password)
        {
            var entities = new Data_Folder.MarathonSkillsEntities();
            var whereResult = entities.C_User.FirstOrDefault(x => x.Email == email);
            if (whereResult != null)
            {
                if (whereResult.C_Password == password)
                {
                    new Pos_Login().ShowDialog();
                }
                else
                {
                    throw new Exception.LoginException("This password or email is incorrect!");
                }
            }
            else
            {
               // throw new Exception.LoginException("This user does not exist!");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "test" && txtPassword.Text == "admin")
            {
                new Test.Test().Show();
            }
            else
            {
                Login(txtEmail.Text,txtPassword.Text);
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
                txtEmail_TextChanged(null, null);
                txtPassword_TextChanged(null, null);
            }
            else
            {
                btnBack_Click(null, null);
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter your email adress")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your passsword")
            {
                txtPassword.Text = null;
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = System.Drawing.Color.Black;
                txtPassword.Refresh();
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == null || txtEmail.Text == "")
            {
                txtEmail.Text = "Enter your email adress";
                txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == null || txtPassword.Text == "")
            {
                txtPassword.Refresh();
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Enter your passsword";
                txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            }
        }
        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == null || txtPassword.Text != "Enter your passsword" || txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = System.Drawing.Color.Black;
            }

        }
    }
}
