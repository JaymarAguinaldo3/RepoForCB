namespace Authenti_Gate.Dashboards
{
    partial class SuperAdminDashboardForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminDashboardForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.roundedButton3 = new Authenti_Gate.CustomControls.RoundedButton();
            this.roundedButton1 = new Authenti_Gate.CustomControls.RoundedButton();
            this.roundedPanel1 = new Authenti_Gate.CustomControls.RoundedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.roundedPanel2 = new Authenti_Gate.CustomControls.RoundedPanel();
            this.labelTime = new System.Windows.Forms.Label();
            this.logoutBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.manageAccBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.reportsBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.transacBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.homeBtn = new Authenti_Gate.CustomControls.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(245, -1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1010, 773);
            this.mainPanel.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // roundedButton3
            // 
            this.roundedButton3.BackColor = System.Drawing.Color.Green;
            this.roundedButton3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedButton3.BorderRadius = 22;
            this.roundedButton3.BorderSize = 0;
            this.roundedButton3.FlatAppearance.BorderSize = 0;
            this.roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton3.ForeColor = System.Drawing.Color.White;
            this.roundedButton3.Location = new System.Drawing.Point(1194, 12);
            this.roundedButton3.Name = "roundedButton3";
            this.roundedButton3.Size = new System.Drawing.Size(22, 22);
            this.roundedButton3.TabIndex = 31;
            this.roundedButton3.UseVisualStyleBackColor = false;
            this.roundedButton3.Click += new System.EventHandler(this.roundedButton3_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.Red;
            this.roundedButton1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedButton1.BorderRadius = 22;
            this.roundedButton1.BorderSize = 0;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Location = new System.Drawing.Point(1222, 12);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(22, 22);
            this.roundedButton1.TabIndex = 30;
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.Black;
            this.roundedPanel1.BorderRadius = 20;
            this.roundedPanel1.BorderSize = 0;
            this.roundedPanel1.Controls.Add(this.panel1);
            this.roundedPanel1.Controls.Add(this.labelYear);
            this.roundedPanel1.Controls.Add(this.labelDay);
            this.roundedPanel1.Controls.Add(this.labelMonth);
            this.roundedPanel1.Location = new System.Drawing.Point(13, 428);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(224, 101);
            this.roundedPanel1.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.panel1.Location = new System.Drawing.Point(94, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 69);
            this.panel1.TabIndex = 35;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Britannic Bold", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.labelYear.Location = new System.Drawing.Point(106, 26);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(108, 48);
            this.labelYear.TabIndex = 32;
            this.labelYear.Text = "YYYY";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("Britannic Bold", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDay.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.labelDay.Location = new System.Drawing.Point(17, 15);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(71, 44);
            this.labelDay.TabIndex = 33;
            this.labelDay.Text = "DD";
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonth.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.labelMonth.Location = new System.Drawing.Point(22, 60);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(66, 27);
            this.labelMonth.TabIndex = 34;
            this.labelMonth.Text = "MMM";
            this.labelMonth.Click += new System.EventHandler(this.labelMonth_Click);
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.Black;
            this.roundedPanel2.BorderRadius = 20;
            this.roundedPanel2.BorderSize = 0;
            this.roundedPanel2.Controls.Add(this.labelTime);
            this.roundedPanel2.Location = new System.Drawing.Point(10, 547);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(224, 67);
            this.roundedPanel2.TabIndex = 33;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Britannic Bold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.labelTime.Location = new System.Drawing.Point(41, 19);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(143, 33);
            this.labelTime.TabIndex = 35;
            this.labelTime.Text = "00:00 AM";
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.OliveDrab;
            this.logoutBtn.BackgroundImage = global::Authenti_Gate.Properties.Resources.Logout;
            this.logoutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoutBtn.BorderColor = System.Drawing.Color.Black;
            this.logoutBtn.BorderRadius = 40;
            this.logoutBtn.BorderSize = 0;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.Location = new System.Drawing.Point(10, 708);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(224, 40);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // manageAccBtn
            // 
            this.manageAccBtn.BackColor = System.Drawing.Color.Green;
            this.manageAccBtn.BackgroundImage = global::Authenti_Gate.Properties.Resources.MangeAccGreen;
            this.manageAccBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.manageAccBtn.BorderColor = System.Drawing.Color.Black;
            this.manageAccBtn.BorderRadius = 40;
            this.manageAccBtn.BorderSize = 0;
            this.manageAccBtn.FlatAppearance.BorderSize = 0;
            this.manageAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageAccBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageAccBtn.ForeColor = System.Drawing.Color.White;
            this.manageAccBtn.Location = new System.Drawing.Point(13, 326);
            this.manageAccBtn.Name = "manageAccBtn";
            this.manageAccBtn.Size = new System.Drawing.Size(212, 50);
            this.manageAccBtn.TabIndex = 4;
            this.manageAccBtn.UseVisualStyleBackColor = false;
            this.manageAccBtn.Click += new System.EventHandler(this.manageAccBtn_Click);
            // 
            // reportsBtn
            // 
            this.reportsBtn.BackColor = System.Drawing.Color.Green;
            this.reportsBtn.BackgroundImage = global::Authenti_Gate.Properties.Resources.ReportsGreen;
            this.reportsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.reportsBtn.BorderColor = System.Drawing.Color.Black;
            this.reportsBtn.BorderRadius = 40;
            this.reportsBtn.BorderSize = 0;
            this.reportsBtn.FlatAppearance.BorderSize = 0;
            this.reportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsBtn.ForeColor = System.Drawing.Color.White;
            this.reportsBtn.Location = new System.Drawing.Point(13, 271);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(212, 50);
            this.reportsBtn.TabIndex = 3;
            this.reportsBtn.UseVisualStyleBackColor = false;
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // transacBtn
            // 
            this.transacBtn.BackColor = System.Drawing.Color.Green;
            this.transacBtn.BackgroundImage = global::Authenti_Gate.Properties.Resources.TransactionGreen;
            this.transacBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.transacBtn.BorderColor = System.Drawing.Color.Black;
            this.transacBtn.BorderRadius = 40;
            this.transacBtn.BorderSize = 0;
            this.transacBtn.FlatAppearance.BorderSize = 0;
            this.transacBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transacBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transacBtn.ForeColor = System.Drawing.Color.White;
            this.transacBtn.Location = new System.Drawing.Point(13, 216);
            this.transacBtn.Name = "transacBtn";
            this.transacBtn.Size = new System.Drawing.Size(212, 50);
            this.transacBtn.TabIndex = 2;
            this.transacBtn.UseVisualStyleBackColor = false;
            this.transacBtn.Click += new System.EventHandler(this.transacBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Green;
            this.homeBtn.BackgroundImage = global::Authenti_Gate.Properties.Resources.HomeGreen;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.homeBtn.BorderColor = System.Drawing.Color.Black;
            this.homeBtn.BorderRadius = 40;
            this.homeBtn.BorderSize = 0;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.ForeColor = System.Drawing.Color.White;
            this.homeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeBtn.Location = new System.Drawing.Point(13, 161);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.homeBtn.Size = new System.Drawing.Size(212, 50);
            this.homeBtn.TabIndex = 1;
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Authenti_Gate.Properties.Resources.Screenshot_2025_02_03_155332;
            this.pictureBox1.Location = new System.Drawing.Point(-5, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SuperAdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1261, 777);
            this.Controls.Add(this.roundedButton3);
            this.Controls.Add(this.manageAccBtn);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.reportsBtn);
            this.Controls.Add(this.transacBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuperAdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperAdminDashboardForm";
            this.Load += new System.EventHandler(this.SuperAdminDashboardForm_Load);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private CustomControls.RoundedButton logoutBtn;
        private CustomControls.RoundedButton manageAccBtn;
        private CustomControls.RoundedButton reportsBtn;
        private CustomControls.RoundedButton transacBtn;
        private CustomControls.RoundedButton homeBtn;
        private CustomControls.RoundedButton roundedButton3;
        private CustomControls.RoundedPanel roundedPanel2;
        private CustomControls.RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        public CustomControls.RoundedButton roundedButton1;
    }
}