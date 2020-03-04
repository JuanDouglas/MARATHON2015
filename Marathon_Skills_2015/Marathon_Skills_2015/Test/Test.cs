using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marathon_Skills_2015.Test
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            comboBox1.Items.Add("About_Marathon");
            comboBox1.Items.Add("Interactive_Map");
            comboBox1.Items.Add("Login_Screen");
            comboBox1.Items.Add("Main_Screen");
            comboBox1.Items.Add("Pos_Login");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString()) {
                case "About_Marathon":
                    new Forms.About_marathon().Show(); 
                    break;
                case "Interactive_Map":
                    new Forms.Interactive_Map().Show();
                    break;
                case "Login_Screen":
                    new Forms.Login_Screen().Show();
                    break;
                case "Main_Scren":
                    new Main_Screen().Show();
                    break;
                case "Pos_Login":
                    new Forms.Pos_Login().ShowDialog();
                    break;
            }
            

        }
    }
}
