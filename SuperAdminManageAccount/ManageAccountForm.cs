using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authenti_Gate.SuperAdminManageAccount.ManageAccount;
using Authenti_Gate.SuperAdminManageAccount.SecurityPersonnel;

namespace Authenti_Gate.SuperAdminManageAccount
{
    public partial class ManageAccountForm : Form
    {
        public ManageAccountForm()
        {
            InitializeComponent();

            ManageAdminForm admin = new ManageAdminForm();
            managePanel.Controls.Clear();
            admin.TopLevel = false;
            managePanel.Controls.Add(admin);
            admin.Dock = DockStyle.Fill;
            admin.Show();


            adminBtn.BackColor = Color.White;
            adminBtn.ForeColor = Color.DarkGreen;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            ManageAdminForm admin = new ManageAdminForm();
            managePanel.Controls.Clear();
            admin.TopLevel = false;
            managePanel.Controls.Add(admin);
            admin.Dock = DockStyle.Fill;
            admin.Show();


            adminBtn.BackColor = Color.White;
            superAdminBtn.BackColor = Color.DarkGreen;
            roundedButton1.BackColor = Color.DarkGreen;

            adminBtn.ForeColor = Color.DarkGreen;
            superAdminBtn.ForeColor = Color.White;
            roundedButton1.ForeColor = Color.White;
        }

        private void superAdminBtn_Click(object sender, EventArgs e)
        {
            ManageSuperAdminForm superadmin = new ManageSuperAdminForm();
            managePanel.Controls.Clear();
            superadmin.TopLevel = false;
            managePanel.Controls.Add(superadmin);
            superadmin.Dock = DockStyle.Fill;
            superadmin.Show();


            adminBtn.BackColor = Color.DarkGreen;
            superAdminBtn.BackColor = Color.White;
            roundedButton1.BackColor = Color.DarkGreen;

            adminBtn.ForeColor = Color.White;
            superAdminBtn.ForeColor = Color.DarkGreen;
            roundedButton1.ForeColor = Color.White;
        }

        private void ManageAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {

            ManageSecuPersonnelForm sec = new ManageSecuPersonnelForm();
            managePanel.Controls.Clear();
            sec.TopLevel = false;
            managePanel.Controls.Add(sec);
            sec.Dock = DockStyle.Fill;
            sec.Show();

            adminBtn.BackColor = Color.DarkGreen;
            superAdminBtn.BackColor = Color.DarkGreen;
            roundedButton1.BackColor = Color.White;

            adminBtn.ForeColor = Color.White;
            superAdminBtn.ForeColor = Color.White;
            roundedButton1.ForeColor = Color.DarkGreen;
        }
    }
}
