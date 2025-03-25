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
using Authenti_Gate.Dashboards;
using Authenti_Gate.Logins;
using MySqlConnector;

namespace Authenti_Gate.SuperAdminManageAccount.ManageAccount
{
    public partial class ManageSuperAdminForm : Form
    {
        public ManageSuperAdminForm()
        {
            InitializeComponent();
        }
        private void clear() 
        {
            tbOldPass.Text = string.Empty;
            tbNewPass.Text = string.Empty;
            tbCNewPass.Text = string.Empty;
        }
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
            var con = new MySqlConnection(cs);
            try
            {
                con.Open();
                string cm = "Select Password from account_table WHERE Password=@Password AND Number=1";
                var cmd = new MySqlCommand(cm, con);
                cmd.Parameters.AddWithValue("@Password", tbOldPass.Text);
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                myReader.Close();
                if (count == 1)
                {
                    if (tbNewPass.Text.Equals(tbCNewPass.Text))
                    {
                        string cmm = "UPDATE account_table SET Password='" + tbNewPass.Text + "' WHERE Number = 1";
                        var cmds = new MySqlCommand(cmm, con);
                        cmds.ExecuteNonQuery();
                        //MessageBox.Show("Password Changed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (changePassSuccessMsgBox success = new changePassSuccessMsgBox())
                        {
                            DialogResult result = success.ShowDialog();
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Please confirm if the new password is matched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (updatePasswordMsgBox updateError = new updatePasswordMsgBox())
                        {
                            DialogResult result = updateError.ShowDialog();
                        }
                    }
                    clear();
                }
                else
                {
                    //MessageBox.Show(this, "Incorrect old password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (updatePasswordMsgBox updateError = new updatePasswordMsgBox())
                    {
                        DialogResult result = updateError.ShowDialog();
                    }
                    clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void pbOldPass_Click(object sender, EventArgs e)
        {
            if (tbOldPass.UseSystemPasswordChar)
            {
                tbOldPass.UseSystemPasswordChar = false;
                pbOldPass.Image = Properties.Resources.show_password_icon;
            }
            else
            {
                tbOldPass.UseSystemPasswordChar = true;
                pbOldPass.Image = Properties.Resources.hide_password_icon;
            }
        }

        private void pbNewPass_Click(object sender, EventArgs e)
        {
            if (tbNewPass.UseSystemPasswordChar)
            {
                tbNewPass.UseSystemPasswordChar = false;
                pbNewPass.Image = Properties.Resources.show_password_icon;
            }
            else
            {
                tbNewPass.UseSystemPasswordChar = true;
                pbNewPass.Image = Properties.Resources.hide_password_icon;
            }
        }

        private void pbConNewPass_Click(object sender, EventArgs e)
        {
            if (tbCNewPass.UseSystemPasswordChar)
            {
                tbCNewPass.UseSystemPasswordChar = false;
                pbConNewPass.Image = Properties.Resources.show_password_icon;
            }
            else
            {
                tbCNewPass.UseSystemPasswordChar = true;
                pbConNewPass.Image = Properties.Resources.hide_password_icon;
            }
        }
    }
}
