using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authenti_Gate.CustomMsgBox;
using Authenti_Gate.Home;
using Authenti_Gate.Logins;
using Authenti_Gate.SuperAdminManageAccount;
using Authenti_Gate.SuperAdminReports;
using Authenti_Gate.SuperAdminTransaction;
using MySqlConnector;

namespace Authenti_Gate.Dashboards
{
    public partial class SuperAdminDashboardForm : Form
    {
        public void Logout()
        {
            string cs = @"server=localhost;userid=root;password=;database=authentigate";
            var con = new MySqlConnection(cs);

            try
            {
                con.Open();
                string cm = "UPDATE acclogs_table SET Logout_Time = '" + DateTime.Now.ToString("hh:mm tt") + "' WHERE Username = '" + "SuperAdmin" + "' AND Log_Date = '" + DateTime.Now.ToString("MM/dd/yyyy") + "'AND Logout_Time = '"+" "+"' ";
                var cmd = new MySqlCommand(cm, con);
                cmd.ExecuteNonQuery();
                SuperAdminLoginForm loginForm = new SuperAdminLoginForm();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        public SuperAdminDashboardForm()
        {
            InitializeComponent();

            homeBtn.BackColor = Color.White;
            homeBtn.ForeColor = Color.Green;
            homeBtn.BackgroundImage = Properties.Resources.HomeWhite;
            homeBtn.BackgroundImageLayout = ImageLayout.Zoom;

            

            HomeForm superAdminHome = new HomeForm();
            mainPanel.Controls.Clear();
            superAdminHome.TopLevel = false;
            mainPanel.Controls.Add(superAdminHome);
            superAdminHome.Dock = DockStyle.Fill;
            superAdminHome.Show();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            mainPanel.Controls.Clear();
            home.TopLevel = false;
            mainPanel.Controls.Add(home);
            home.Dock = DockStyle.Fill;
            home.Show();

            homeBtn.BackColor = Color.White;
            transacBtn.BackColor = Color.Green;
            reportsBtn.BackColor = Color.Green;
            manageAccBtn.BackColor = Color.Green;

            homeBtn.ForeColor = Color.Green;
            transacBtn.ForeColor = Color.White;
            reportsBtn.ForeColor = Color.White;
            manageAccBtn.ForeColor = Color.White;

            homeBtn.BackgroundImage = Properties.Resources.HomeWhite;
            transacBtn.BackgroundImage = Properties.Resources.TransactionGreen;
            reportsBtn.BackgroundImage = Properties.Resources.ReportsGreen;
            manageAccBtn.BackgroundImage = Properties.Resources.MangeAccGreen;
        }

        private void transacBtn_Click(object sender, EventArgs e)
        {
            TransactionForm superAdminTransaction = new TransactionForm();
            mainPanel.Controls.Clear();
            superAdminTransaction.TopLevel = false;
            mainPanel.Controls.Add(superAdminTransaction);
            superAdminTransaction.Dock = DockStyle.Fill;
            superAdminTransaction.Show();

            homeBtn.BackColor = Color.Green;
            transacBtn.BackColor = Color.White;
            reportsBtn.BackColor = Color.Green;
            manageAccBtn.BackColor = Color.Green;

            homeBtn.ForeColor = Color.White;
            transacBtn.ForeColor = Color.Green;
            reportsBtn.ForeColor = Color.White;
            manageAccBtn.ForeColor = Color.White;

            homeBtn.BackgroundImage = Properties.Resources.HomeGreen;
            transacBtn.BackgroundImage = Properties.Resources.TransactionWhite;
            reportsBtn.BackgroundImage = Properties.Resources.ReportsGreen;
            manageAccBtn.BackgroundImage = Properties.Resources.MangeAccGreen;
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            SuperAdminReportsForm superAdminReports = new SuperAdminReportsForm();
            mainPanel.Controls.Clear();
            superAdminReports.TopLevel = false;
            mainPanel.Controls.Add(superAdminReports);
            superAdminReports.Dock = DockStyle.Fill;
            superAdminReports.Show();

            homeBtn.BackColor = Color.Green;
            transacBtn.BackColor = Color.Green;
            reportsBtn.BackColor = Color.White;
            manageAccBtn.BackColor = Color.Green;

            homeBtn.ForeColor = Color.White;
            transacBtn.ForeColor = Color.White;
            reportsBtn.ForeColor = Color.Green;
            manageAccBtn.ForeColor = Color.White;

            homeBtn.BackgroundImage = Properties.Resources.HomeGreen;
            transacBtn.BackgroundImage = Properties.Resources.TransactionGreen;
            reportsBtn.BackgroundImage = Properties.Resources.ReportsWhite;
            manageAccBtn.BackgroundImage = Properties.Resources.MangeAccGreen;
        }

        private void manageAccBtn_Click(object sender, EventArgs e)
        {
            ManageAccountForm superAdminManageAcc = new ManageAccountForm();
            mainPanel.Controls.Clear();
            superAdminManageAcc.TopLevel = false;
            mainPanel.Controls.Add(superAdminManageAcc);
            superAdminManageAcc.Dock = DockStyle.Fill;
            superAdminManageAcc.Show();

            homeBtn.BackColor = Color.Green;
            transacBtn.BackColor = Color.Green;
            reportsBtn.BackColor = Color.Green;
            manageAccBtn.BackColor = Color.White;

            homeBtn.ForeColor = Color.White;
            transacBtn.ForeColor = Color.White;
            reportsBtn.ForeColor = Color.White;
            manageAccBtn.ForeColor = Color.Green;

            homeBtn.BackgroundImage = Properties.Resources.HomeGreen;
            transacBtn.BackgroundImage = Properties.Resources.TransactionGreen;
            reportsBtn.BackgroundImage = Properties.Resources.ReportsGreen;
            manageAccBtn.BackgroundImage = Properties.Resources.MangeAccWhite;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            using (logoutMsgBox logoutBox = new logoutMsgBox())
            {
                
                DialogResult result = logoutBox.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    Logout();  
                }
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            using (logoutMsgBox logoutBox = new logoutMsgBox())
            {

                DialogResult result = logoutBox.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    Logout();
                }
            }
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SuperAdminDashboardForm_Load(object sender, EventArgs e)
        {
            labelMonth.Text = DateTime.Now.ToString("MMM").ToUpper();
            labelDay.Text = DateTime.Now.ToString("dd");
            labelYear.Text = DateTime.Now.ToString("yyyy");
            labelTime.Text = DateTime.Now.ToString("hh:mm tt").ToUpper();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm tt").ToUpper();
            timer1.Start();
        }

        private void labelMonth_Click(object sender, EventArgs e)
        {

        }
    }
}
