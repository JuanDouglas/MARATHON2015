using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marathon_Skills_2015.Forms
{
    public partial class Interactive_Map : Form
    {
        public Interactive_Map()
        {
            InitializeComponent();
            AllPanelInvisible();
        }
        private void picPoint_Click(object sender,EventArgs e) {
            PictureBox picture = (PictureBox)sender;
            Panel panel = null;
            Point point = new Point(529, 70);
            int test = testAllPanel();
            if (test != 0)
            {
                point = new Point(529, 70 + test * 10*2);
            }
            switch (picture.Name) {
                case "picPoint1":
                    panel = panelCheck1;
                    break;
                case "picPoint2":
                    panel = panelCheck2;
                    break;
                case "picPoint3":
                    panel = panelCheck3;
                    break;
                case "picPoint4":
                    panel = panelCheck4;
                    break;
                case "picPoint5":
                    panel = panelCheck5;
                    break;
                case "picPoint6":
                    panel = panelCheck6;
                    break;
                case "picPoint7":
                    panel = panelCheck7;
                    break;
                case "picPoint8":
                    panel = panelCheck8;
                    break;
            }
            if (panel.Visible)
            { 
                panel.Visible = false;
            }
            else
            {
                panel.Location = point;
                panel.Visible = true;
                panel.BringToFront();
            }
        }
        private void btnExit_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            Panel panel = null;
            switch (btn.Name.ToString())
            {
                case "btnExitCheck1":
                    panel = panelCheck1;
                    break;
                case "btnExitCheck2":
                    panel = panelCheck2;
                    break;
                case "btnExitCheck3":
                    panel = panelCheck3;
                    break;
                case "btnExitCheck4":
                    panel = panelCheck4;
                    break;
                case "btnExitCheck5":
                    panel = panelCheck5;
                    break;
                case "btnExitCheck6":
                    panel = panelCheck6;
                    break;
                case "btnExitCheck7":
                    panel = panelCheck7;
                    break;
                case "btnExitCheck8":
                    panel = panelCheck8;
                    break;
            }
            panel.Visible = false;
        }

        private int testAllPanel() {
            int checkeds=0;
            if (panelCheck1.Visible) 
                checkeds++;
            if (panelCheck2.Visible)
                checkeds++;
            if (panelCheck3.Visible)
                checkeds++;
            if (panelCheck4.Visible)
                checkeds++;
            if (panelCheck5.Visible)
                checkeds++;
            if (panelCheck6.Visible)
                checkeds++;
            if (panelCheck7.Visible)
                checkeds++;
            if (panelCheck8.Visible)
                checkeds++;
            return checkeds;
        }
        private void AllPanelInvisible() {
            panelCheck1.Visible = false;
            panelCheck2.Visible = false;
            panelCheck3.Visible = false;
            panelCheck4.Visible = false;
            panelCheck5.Visible = false;
            panelCheck6.Visible = false;
            panelCheck7.Visible = false;
            panelCheck8.Visible = false;
        }
    }
}
