namespace Marathon_Skills_2015.Forms
{
    partial class Pos_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button button2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pos_Login));
            this.label1 = new System.Windows.Forms.Label();
            this.lblText1 = new System.Windows.Forms.Label();
            this.btnRunner = new System.Windows.Forms.Button();
            this.btnCoordinator = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.BackColor = System.Drawing.Color.White;
            button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            button2.ForeColor = System.Drawing.Color.Red;
            button2.Name = "button2";
            button2.UseCompatibleTextRendering = true;
            button2.UseMnemonic = false;
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.label1.Name = "label1";
            // 
            // lblText1
            // 
            resources.ApplyResources(this.lblText1, "lblText1");
            this.lblText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblText1.Name = "lblText1";
            // 
            // btnRunner
            // 
            resources.ApplyResources(this.btnRunner, "btnRunner");
            this.btnRunner.Name = "btnRunner";
            this.btnRunner.UseVisualStyleBackColor = true;
            // 
            // btnCoordinator
            // 
            resources.ApplyResources(this.btnCoordinator, "btnCoordinator");
            this.btnCoordinator.Name = "btnCoordinator";
            this.btnCoordinator.UseVisualStyleBackColor = true;
            // 
            // btnAdmin
            // 
            resources.ApplyResources(this.btnAdmin, "btnAdmin");
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // PosLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnCoordinator);
            this.Controls.Add(this.btnRunner);
            this.Controls.Add(button2);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PosLogin";
            this.TransparencyKey = System.Drawing.Color.Cyan;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Button btnRunner;
        private System.Windows.Forms.Button btnCoordinator;
        private System.Windows.Forms.Button btnAdmin;
    }
}