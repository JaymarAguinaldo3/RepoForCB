using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authenti_Gate.CustomMsgBox;
using MySqlConnector;
using Org.BouncyCastle.Utilities;

namespace Authenti_Gate.AdminScan
{
    public partial class ScanForm : Form
    {
        string number = "";
        string gNum = "XXXXXXXXXX";

        string id = " ",
                name = " ",
                position = " ",
                college = " ",
                year = " ",
                section = " ",
                date = " ",
                time = " ";
        public void CancelPerson()
        {
            try
            {
                labelID.Text = "########";
                labelName.Text = "Full Name";
                labelCollege.Text = "College/Program";
                labelPos.Text = "Position";
                tbPrfid.Text = null;
                labelYear.Text = "Year";
                labelSection.Text = "Section";
                labelDate.Text = "MMM DD YYYY";
                labelTime.Text = "00:00 AM";
                pictureBox1.Image = Properties.Resources.AgriLogo_removebg_preview__1_;
                progPanel.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void StudScan()
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Query to get details
                    string query = "SELECT ID_Number, Full_Name, Program, Year, Section, Role,GuardianConNumber, Picture FROM studinfo_table WHERE RFID_tag = @RFID_tag";
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RFID_tag", tbPrfid.Text);
                        using (var reader = cmd.ExecuteReader())
                        {

                            
                            if (reader.Read())
                            {
                                // Populate labels and image
                                labelID.Text = reader["ID_Number"].ToString();
                                labelName.Text = reader["Full_Name"].ToString();
                                labelCollege.Text = reader["Program"].ToString();
                                labelYear.Text = reader["Year"].ToString();
                                labelSection.Text = reader["Section"].ToString();
                                labelPos.Text = reader["Role"].ToString();
                                labelDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                                labelTime.Text = DateTime.Now.ToString("hh:mm tt");
                                gNum = reader["GuardianConNumber"].ToString();

                                name = labelName.Text;
                                string program = reader["Program"].ToString().ToLower();
                                switch (program)
                                {
                                    case "bsit":
                                        progPanel.BackColor = Color.Orange;
                                        break;
                                    case "bsed":
                                        progPanel.BackColor = Color.Blue;
                                        break;
                                    case "bsa":
                                        progPanel.BackColor = Color.Green;
                                        break;
                                    case "bshm":
                                        progPanel.BackColor = Color.Pink;
                                        break;
                                    default:
                                        progPanel.BackColor = Color.Gray; // Default color for unknown programs
                                        break;
                                }

                                if (reader["Picture"] != DBNull.Value)
                                {
                                    byte[] img = (byte[])reader["Picture"];
                                    using (var ms = new MemoryStream(img))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                            }

                            else
                            {
                               
                                return;
                            }
                         
                        }
                    }


                    // Check if a log exists for today
                    string logQuery = "SELECT * FROM studlogs_table WHERE ID_Number = @ID_Number AND Login_date = @Log_Date AND Time_out = @Time_out";
                    using (var cmdLog = new MySqlCommand(logQuery, con))
                    {
                        cmdLog.Parameters.AddWithValue("@ID_Number", labelID.Text);
                        cmdLog.Parameters.AddWithValue("@Log_Date", labelDate.Text);
                        cmdLog.Parameters.AddWithValue("@Time_out", " ");

                        using (var readerLog = cmdLog.ExecuteReader())
                        {
                            if (readerLog.Read())
                            {
                                // Update the Time_out if a log exists
                                readerLog.Close(); // Close reader before executing another command

                                string updateQuery = "UPDATE studlogs_table SET Time_out = @Time_out, Logout_date = @Logout_date WHERE ID_Number = @ID_Number AND Login_date = @Log_Date AND Time_out = @OldTime_out";
                                using (var cmdUpdate = new MySqlCommand(updateQuery, con))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@Time_out", labelTime.Text);
                                    cmdUpdate.Parameters.AddWithValue("@ID_Number", labelID.Text);
                                    cmdUpdate.Parameters.AddWithValue("@Log_Date", labelDate.Text);
                                    cmdUpdate.Parameters.AddWithValue("@Logout_date", labelDate.Text);
                                    cmdUpdate.Parameters.AddWithValue("@OldTime_out", " ");
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Insert a new log if no entry exists for today
                                readerLog.Close(); // Close reader before executing another command

                                string insertQuery = "INSERT into studlogs_table (ID_Number,Full_Name,Program,Year,Section,Login_date,Time_in) VALUES(@ID_Number,@Full_Name,@Program,@Year,@Section,@Log_date,@Time_in)";
                                using (var cmdInsert = new MySqlCommand(insertQuery, con))
                                {
                                    cmdInsert.Parameters.AddWithValue("@ID_Number", labelID.Text);
                                    cmdInsert.Parameters.AddWithValue("@Full_Name", labelName.Text);
                                    cmdInsert.Parameters.AddWithValue("@Program", labelCollege.Text);
                                    cmdInsert.Parameters.AddWithValue("@Year", labelYear.Text);
                                    cmdInsert.Parameters.AddWithValue("@Section", labelSection.Text);
                                    cmdInsert.Parameters.AddWithValue("@Log_date", labelDate.Text);
                                    cmdInsert.Parameters.AddWithValue("@Time_in", labelTime.Text);
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    await Task.Delay(1500);
                    //MessageBox.Show("Access Granted", "Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (accessGrantedMsgBox accessGranted = new accessGrantedMsgBox())
                    {
                        DialogResult result = accessGranted.ShowDialog();
                    }
                    CancelPerson();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        public ScanForm()
        {
            InitializeComponent();
            

            
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.White;
            btnCancel.TabStop = false;

            
            tbPrfid.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter) 
                {
                    btnCancel.PerformClick();
                    e.Handled = true;        
                    e.SuppressKeyPress = true; 
                }
            };


            btnCancel.Click += (sender, e) => tbPrfid.Clear();
        }

        private void ScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*CloseSerialPort(arduinoPort);*/
        }
        

        private void tbPrfid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }
        private void ScanForm_Load(object sender, EventArgs e)
        {
            tbPrfid.Focus();
        }
        private void tbPrfid_TextChanged(object sender, EventArgs e)
        {
            StudScan();
        }
    }
}
