namespace Authenti_Gate.SuperAdminManageAccount
{
    partial class ManageAccountForm
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
            this.adminBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.superAdminBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.managePanel = new Authenti_Gate.CustomControls.RoundedPanel();
            this.roundedButton1 = new Authenti_Gate.CustomControls.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminBtn
            // 
            this.adminBtn.BackColor = System.Drawing.Color.Green;
            this.adminBtn.BorderColor = System.Drawing.Color.Black;
            this.adminBtn.BorderRadius = 40;
            this.adminBtn.BorderSize = 0;
            this.adminBtn.FlatAppearance.BorderSize = 0;
            this.adminBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminBtn.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminBtn.ForeColor = System.Drawing.Color.White;
            this.adminBtn.Location = new System.Drawing.Point(715, 42);
            this.adminBtn.Name = "adminBtn";
            this.adminBtn.Size = new System.Drawing.Size(119, 40);
            this.adminBtn.TabIndex = 3;
            this.adminBtn.Text = "Admin";
            this.adminBtn.UseVisualStyleBackColor = false;
            this.adminBtn.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // superAdminBtn
            // 
            this.superAdminBtn.BackColor = System.Drawing.Color.Green;
            this.superAdminBtn.BorderColor = System.Drawing.Color.Black;
            this.superAdminBtn.BorderRadius = 40;
            this.superAdminBtn.BorderSize = 0;
            this.superAdminBtn.FlatAppearance.BorderSize = 0;
            this.superAdminBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.superAdminBtn.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superAdminBtn.ForeColor = System.Drawing.Color.White;
            this.superAdminBtn.Location = new System.Drawing.Point(840, 42);
            this.superAdminBtn.Name = "superAdminBtn";
            this.superAdminBtn.Size = new System.Drawing.Size(147, 40);
            this.superAdminBtn.TabIndex = 2;
            this.superAdminBtn.Text = "Super Admin";
            this.superAdminBtn.UseVisualStyleBackColor = false;
            this.superAdminBtn.Click += new System.EventHandler(this.superAdminBtn_Click);
            // 
            // managePanel
            // 
            this.managePanel.BackColor = System.Drawing.Color.White;
            this.managePanel.BorderColor = System.Drawing.Color.White;
            this.managePanel.BorderRadius = 30;
            this.managePanel.BorderSize = 1;
            this.managePanel.Location = new System.Drawing.Point(12, 88);
            this.managePanel.Name = "managePanel";
            this.managePanel.Size = new System.Drawing.Size(986, 673);
            this.managePanel.TabIndex = 10;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.Green;
            this.roundedButton1.BorderColor = System.Drawing.Color.Black;
            this.roundedButton1.BorderRadius = 40;
            this.roundedButton1.BorderSize = 0;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Britannic Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Location = new System.Drawing.Point(519, 42);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(190, 40);
            this.roundedButton1.TabIndex = 11;
            this.roundedButton1.Text = "ColSc Officers";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Authenti_Gate.Properties.Resources.MangeAccGreen;
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ManageAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1010, 773);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.managePanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.adminBtn);
            this.Controls.Add(this.superAdminBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageAccountForm";
            this.Text = "ManageAccountForm";
            this.Load += new System.EventHandler(this.ManageAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.RoundedButton adminBtn;
        private CustomControls.RoundedButton superAdminBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RoundedPanel managePanel;
        private CustomControls.RoundedButton roundedButton1;
    }
}