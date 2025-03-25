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
using MySqlConnector;

namespace Authenti_Gate.SuperAdminManageAccount.SecurityPersonnel
{
    public partial class ManageSecuPersonnelForm : Form
    {
        public ManageSecuPersonnelForm()
        {
            InitializeComponent();
            LoadDefaultData();

        }

        successAdded success = new successAdded();
        fillAllFieldsMsgBox fillAllFields = new fillAllFieldsMsgBox();
        sucessfullyDeleted sucessfullyDeleted = new sucessfullyDeleted();
        successful successful = new successful();

        public void LoadDefaultData()
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    string query = "SELECT secnames, security_password FROM secunames_table";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                  
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["secnames"].Value != null)
            {
                
                string selectedName = dataGridView1.Rows[e.RowIndex].Cells["secnames"].Value.ToString();
                string selectedPassword = dataGridView1.Rows[e.RowIndex].Cells["security_password"].Value.ToString();

                
                selectedSecuName.Text = selectedName;
                selectedSecuPassword.Text = selectedPassword;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(secuNames.Text) || string.IsNullOrWhiteSpace(secuPassword.Text))
            {
                using(fillAllFieldsMsgBox fillAllFields = new fillAllFieldsMsgBox())
                {
                    DialogResult result = fillAllFields.ShowDialog();
                }
/*                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
*/                return;
            }

            string name = secuNames.Text.Trim();
            string password = secuPassword.Text.Trim();
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    
                    string query = "INSERT INTO secunames_table (secnames, security_password) VALUES (@name, @password)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();

                    
                    LoadDefaultData();

                    
                    secuNames.Clear();
                    secuPassword.Clear();

                    using(successAdded success = new successAdded())
                    {
                        DialogResult result = success.ShowDialog();
                    }
                    /*MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(selectedSecuName.Text))
            {
                MessageBox.Show("Please select a record to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = selectedSecuName.Text.Trim();
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    
                    string query = "DELETE FROM secunames_table WHERE secnames = @name";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();

                    
                    LoadDefaultData();

                    
                    selectedSecuName.Clear();
                    selectedSecuPassword.Clear();
                    using(sucessfullyDeleted success = new sucessfullyDeleted())
                    {
                        DialogResult result = success.ShowDialog();
                    }

                    /*                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    */
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(selectedSecuName.Text) || string.IsNullOrWhiteSpace(selectedSecuPassword.Text))
            {
               
                MessageBox.Show("Please select a record and provide updated details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = selectedSecuName.Text.Trim();
            string password = selectedSecuPassword.Text.Trim();
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    
                    string query = "UPDATE secunames_table SET security_password = @password WHERE secnames = @name";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();

                    
                    LoadDefaultData();
                    using(successful success = new successful())
                    {
                        DialogResult result = success.ShowDialog();
                    }
                    /* MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               */
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
