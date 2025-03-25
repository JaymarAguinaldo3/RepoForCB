using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AForge.Video.DirectShow;
using AForge.Video;
using Authenti_Gate.CustomMsgBox;
using Authenti_Gate.SuperAdminTransaction.Transactions.Add;
using MySqlConnector;
using Microsoft.Reporting.WinForms;
using Authenti_Gate.SuperAdminReports.Logs;
using Authenti_Gate.SuperAdminReports;

namespace Authenti_Gate.SuperAdminTransaction.Transactions
{
    public partial class StudentTransacForm : Form
    {
        int Count = 0;
        string StudID = "", nameee;
        public string name = "";
        public string name2 = "";
        

        ReportDataSource rs = new ReportDataSource();

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public void DelStud()
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
            var con = new MySqlConnection(cs);
            try
            {
                con.Open();
                string cm = "DELETE FROM studinfo_table WHERE RFID_tag = '" + tbRFID.Text + "'";
                var cmd = new MySqlCommand(cm, con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (sucessfullyDeleted deleted = new sucessfullyDeleted())
                {
                    DialogResult result = deleted.ShowDialog();
                }
                disable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        public void UpdateStudent()
        {
            byte[] img = null;
            bool isImageChanged = false; // Flag to track if a new image is selected

            

            if (pictureBox1.Image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {

                        using (Bitmap cloneImage = new Bitmap(pictureBox1.Image))
                        {
                            cloneImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img = ms.ToArray();
                        }
                    }

                    isImageChanged = true; // Assume the user has updated the image
                }
                catch (ExternalException ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();
                    string cm = "UPDATE studinfo_table SET RFID_tag = @RFID_tag, ID_Number = @ID_Number, Full_Name = @Full_Name, " +
                                "Program = @Program, Year = @Year, Section = @Section, GuardianConNumber = @GuardianConNumber";

                    if (isImageChanged && img != null)
                    {
                        cm += ", Picture = @Picture";
                    }

                    cm += " WHERE ID_Number = @StudID";

                    using (var cmd = new MySqlCommand(cm, con))
                    {
                        // Set common parameters
                        cmd.Parameters.AddWithValue("@RFID_tag", tbRFID.Text);
                        cmd.Parameters.AddWithValue("@ID_Number", tbStudID.Text);
                        cmd.Parameters.AddWithValue("@Full_Name", tbFullName.Text);
                        cmd.Parameters.AddWithValue("@Program", cbProgram.SelectedItem?.ToString()); // Handle nullable
                        cmd.Parameters.AddWithValue("@Year", cbYear.SelectedItem?.ToString());       // Handle nullable
                        cmd.Parameters.AddWithValue("@Section", tbSection.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@GuardianConNumber", tbPhone.Text);
                        cmd.Parameters.AddWithValue("@StudID", StudID);

                        // Only add image parameter if there is a new image
                        if (img != null)
                        {
                            cmd.Parameters.AddWithValue("@Picture", img); // Binary data for image
                        }

                        // Execute the update query
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (successful updated = new successful())
                        {
                            DialogResult result = updated.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void FilldataAll()
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Fetch all student info data
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM studinfo_table", con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Columns["RFID_tag"].HeaderText = "RFID Tag";
                    dataGridView1.Columns["ID_Number"].HeaderText = "ID Number";
                    dataGridView1.Columns["Full_Name"].HeaderText = "Full Name";
                    dataGridView1.Columns["GuardianConNumber"].HeaderText = "Phone Number";
                    // Safely handle the image column, if it exists
                    if (dataGridView1.Columns.Count > 8 && dataGridView1.Columns[8] is DataGridViewImageColumn imgCol)
                    {
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }

                    // Update total row count in the label
                    Count = dataGridView1.Rows.Count;
                    labelTot.Text = Count.ToString();
                }
                catch (Exception ex)
                {
                    // Catch any exceptions and display error message
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string Filldata(string condition, string condition2)
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Use a parameterized query to prevent SQL injection
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM studinfo_table WHERE Program = @Program OR Program = @Program2", con);
                    cmd.Parameters.AddWithValue("@Program", condition);
                    cmd.Parameters.AddWithValue("@Program2", condition2);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Columns["RFID_tag"].HeaderText = "RFID Tag";
                    dataGridView1.Columns["ID_Number"].HeaderText = "ID Number";
                    dataGridView1.Columns["Full_Name"].HeaderText = "Full Name";
                    dataGridView1.Columns["GuardianConNumber"].HeaderText = "Phone Number";

                    // Safely handle the image column, if it exists
                    if (dataGridView1.Columns.Count > 8 && dataGridView1.Columns[8] is DataGridViewImageColumn imgCol)
                    {
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }

                    // Update total row count in the label
                    Count = dataGridView1.Rows.Count;
                    labelTot.Text = Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return condition;
        }

        public string FilldataAllSearch(string value)
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM studinfo_table WHERE CONCAT (`RFID_tag`, `ID_Number`, `Full_Name`, `Year`, `Section`) LIKE '%" + value + "%'", con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Columns["RFID_tag"].HeaderText = "RFID Tag";
                    dataGridView1.Columns["ID_Number"].HeaderText = "ID Number";
                    dataGridView1.Columns["Full_Name"].HeaderText = "Full Name";
                    dataGridView1.Columns["GuardianConNumber"].HeaderText = "Phone Number";

                    // Safely handle the image column, if it exists
                    if (dataGridView1.Columns.Count > 8 && dataGridView1.Columns[8] is DataGridViewImageColumn imgCol)
                    {
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }

                    // Update total row count in the label
                    Count = dataGridView1.Rows.Count;
                    labelTot.Text = Count.ToString();
                }
                catch (Exception ex)
                {
                    // Catch any exceptions and display error message
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return value;
        }

        public string FilldataSearch(string value, string condition, string condition2)
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";

            using (var con = new MySqlConnection(cs))
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM studinfo_table WHERE CONCAT (`RFID_tag`, `ID_Number`, `Full_Name`, `Year`, `Section`) LIKE '%" + value + "%' AND Program = @Program AND Program = @Program2", con);
                    cmd.Parameters.AddWithValue("@Program", condition);
                    cmd.Parameters.AddWithValue("@Program2", condition2);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Columns["RFID_tag"].HeaderText = "RFID Tag";
                    dataGridView1.Columns["ID_Number"].HeaderText = "ID Number";
                    dataGridView1.Columns["Full_Name"].HeaderText = "Full Name";
                    dataGridView1.Columns["GuardianConNumber"].HeaderText = "Phone Number";

                    // Safely handle the image column, if it exists
                    if (dataGridView1.Columns.Count > 8 && dataGridView1.Columns[8] is DataGridViewImageColumn imgCol)
                    {
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }

                    // Update total row count in the label
                    Count = dataGridView1.Rows.Count;
                    labelTot.Text = Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return condition;
        }

        public void disable() 
        {
            tbRFID.Enabled = false;
            tbStudID.Enabled = false;
            tbFullName.Enabled = false;
            cbProgram.Enabled = false;
            cbYear.Enabled = false;
            tbSection.Enabled = false;
            tbPhone.Enabled = false;
            btnCapturePhoto.Enabled = false;
            btnStartCamera.Enabled = false;
            updateBtn.Enabled = false;
            btnUpload.Enabled = false;
            pictureBox1.Image = Properties.Resources.AgriLogo_removebg_preview__1_;

            tbRFID.Text = null;
            tbStudID.Text = null;
            tbFullName.Text = null;
            cbProgram.SelectedIndex = -1;
            cbYear.SelectedIndex = -1;
            tbSection.Text = null;
            tbPhone.Text = null;

        }
        public void enable()
        {
            tbRFID.Enabled = true;
            tbStudID.Enabled = true;
            tbFullName.Enabled = true;
            cbProgram.Enabled = true;
            cbYear.Enabled = true;
            tbSection.Enabled = true;
            tbPhone.Enabled = true;
            btnCapturePhoto.Enabled = true;
            btnStartCamera.Enabled = true;
            updateBtn.Enabled = true;
            btnUpload .Enabled = true;
        }
        public StudentTransacForm()
        {
            InitializeComponent();

            allBtn.BackColor = Color.DarkGreen;
            allBtn.ForeColor = Color.White;
            name = " ";
            name2 = " ";
        }

        private void allBtn_Click(object sender, EventArgs e)
        {
            allBtn.BackColor = Color.DarkGreen;
            cicsBtn.BackColor = Color.White;
            chmBtn.BackColor = Color.White;
            ctedBtn.BackColor = Color.White;
            coaBtn.BackColor = Color.White;

            allBtn.ForeColor = Color.White;
            cicsBtn.ForeColor = Color.DarkGreen;
            chmBtn.ForeColor = Color.DarkGreen;
            ctedBtn.ForeColor = Color.DarkGreen;
            coaBtn.ForeColor = Color.DarkGreen;
            name = " ";
            name2 = " ";
            FilldataAll();
        }

        private void cicsBtn_Click(object sender, EventArgs e)
        {
            allBtn.BackColor = Color.White;
            cicsBtn.BackColor = Color.DarkGreen;
            chmBtn.BackColor = Color.White;
            ctedBtn.BackColor = Color.White;
            coaBtn.BackColor = Color.White;

            allBtn.ForeColor = Color.DarkGreen;
            cicsBtn.ForeColor = Color.White;
            chmBtn.ForeColor = Color.DarkGreen;
            ctedBtn.ForeColor = Color.DarkGreen;
            coaBtn.ForeColor = Color.DarkGreen;
            name = "BSA";
            name2 = "BSA";
            Filldata(name,name2);
        }

        private void chmBtn_Click(object sender, EventArgs e)
        {
            allBtn.BackColor = Color.White;
            cicsBtn.BackColor = Color.White;
            chmBtn.BackColor = Color.DarkGreen;
            ctedBtn.BackColor = Color.White;
            coaBtn.BackColor = Color.White;

            allBtn.ForeColor = Color.   DarkGreen;
            cicsBtn.ForeColor = Color.DarkGreen;
            chmBtn.ForeColor = Color.White;
            ctedBtn.ForeColor = Color.DarkGreen;
            coaBtn.ForeColor = Color.DarkGreen;
            name = "DAT";
            name2 = "DAT";
            Filldata(name, name2);
        }

        private void ctedBtn_Click(object sender, EventArgs e)
        {
            allBtn.BackColor = Color.White;
            cicsBtn.BackColor = Color.White;
            chmBtn.BackColor = Color.White;
            ctedBtn.BackColor = Color.DarkGreen;
            coaBtn.BackColor = Color.White;

            allBtn.ForeColor = Color.DarkGreen;
            cicsBtn.ForeColor = Color.DarkGreen;
            chmBtn.ForeColor = Color.DarkGreen;
            ctedBtn.ForeColor = Color.White;
            coaBtn.ForeColor = Color.DarkGreen;
            name = "BSA-AS";
            name2 = "BSA-AS";
            Filldata(name, name2);
        }

        private void coaBtn_Click(object sender, EventArgs e)
        {
            allBtn.BackColor = Color.White;
            cicsBtn.BackColor = Color.White;
            chmBtn.BackColor = Color.White;
            ctedBtn.BackColor = Color.White;
            coaBtn.BackColor = Color.DarkGreen;

            allBtn.ForeColor = Color.DarkGreen;
            cicsBtn.ForeColor = Color.DarkGreen;
            chmBtn.ForeColor = Color.DarkGreen;
            ctedBtn.ForeColor = Color.DarkGreen;
            coaBtn.ForeColor = Color.White;
            name = "BSA-CS";
            name2 = "BSA-CS";
            Filldata(name, name2);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm(this);
            addStudentForm.Show();
        }

        private void StudentTransacForm_Load(object sender, EventArgs e)
        {
            FilldataAll();
            disable();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString); // Automatically use the first device
            }
            else
            {
                MessageBox.Show("No camera devices found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the current row is not null
                if (dataGridView1.CurrentRow != null)
                {
                    // Safely extract data from cells
                    tbRFID.Text = dataGridView1.CurrentRow.Cells[0]?.Value?.ToString() ?? "";
                    tbStudID.Text = dataGridView1.CurrentRow.Cells[1]?.Value?.ToString() ?? "";
                    tbFullName.Text = dataGridView1.CurrentRow.Cells[2]?.Value?.ToString() ?? "";
                    cbProgram.SelectedItem = dataGridView1.CurrentRow.Cells[3]?.Value?.ToString() ?? "";
                    cbYear.SelectedItem = dataGridView1.CurrentRow.Cells[4]?.Value?.ToString() ?? "";
                    tbSection.Text = dataGridView1.CurrentRow.Cells[5]?.Value?.ToString() ?? "";
                    tbPhone.Text = dataGridView1.CurrentRow.Cells[7]?.Value?.ToString() ?? "";

                    // Try to process the image column (assuming it's at index 8)
                    if (dataGridView1.CurrentRow.Cells[8]?.Value is byte[] img)
                    {
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Clear the image if no valid image data is found
                        pictureBox1.Image = null;
                    }

                    // Store the Student ID for further use
                    StudID = tbStudID.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing row data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (tbPhone.TextLength != 10 || tbRFID.TextLength != 10)
            {
                using (fillAllFieldsMsgBox fillAllFields = new fillAllFieldsMsgBox())
                {
                    DialogResult result = fillAllFields.ShowDialog();
                }
            }
            else 
            {
                UpdateStudent();
                disable();
                pictureBox1.Image = Properties.Resources.AgriLogo_removebg_preview__1_;
                if (name == "BSIT")
                {
                    Filldata(name, name2);
                }
                else if (name == "BSHM")
                {
                    Filldata(name, name2);
                }
                else if (name == "BSED")
                {
                    Filldata(name, name2);
                }
                else if (name == "BSA")
                {
                    Filldata(name, name2);
                }
                FilldataAll();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            enable();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

            
            if (tbRFID.Text.Length <= 0)
            {
                MessageBox.Show("Select a record from the table", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tbRFID.Text.Length > 0)
            {
                //DialogResult dlgR = MessageBox.Show("Do you really want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                using (deleteMsgBox deleteBox = new deleteMsgBox())
                {

                    DialogResult result = deleteBox.ShowDialog();

                    if (result == DialogResult.Yes)
                    {
                        
                            DelStud();
                            if (name == "BSIT")
                            {
                                Filldata(name, name2);
                            }
                            else if (name == "BSHM")
                            {
                                Filldata(name, name2);
                            }
                            else if (name == "BSED")
                            {
                                Filldata(name, name2);
                            }
                            else if (name == "BSA")
                            {
                                Filldata(name, name2);
                            }
                            FilldataAll();
                        
                    }
                }
               
            }

        }

        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void tbRFID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No camera devices found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapturePhoto_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop(); // Stop capturing
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No photo captured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame; // Display the captured frame
        }

        private void StudentTransacForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose Image(*.JPG;*.PNG;*.GIF;*.JPEG)|*.jpg;*.png;*.gif;*.jpeg;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (name == "BSIT")
            {
                FilldataSearch(tbSearch.Text, name, name2);
            }
            else if (name == "BSHM")
            {
                FilldataSearch(tbSearch.Text, name, name2);
            }
            else if (name == "BSED")
            {
                FilldataSearch(tbSearch.Text, name, name2);
            }
            else if (name == "BSA")
            {
                FilldataSearch(tbSearch.Text, name, name2);
            }
            else
            {
                FilldataAllSearch(tbSearch.Text);
            }
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
            using (var con = new MySqlConnection(cs))
            {

                try
                {
                    con.Open();
                    string query = "SELECT SecName FROM acclogs_table WHERE Log_Date = @Log_Date AND Logout_Time = @Logout_Time";
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Log_Date", DateTime.Now.ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@Logout_Time", " ");
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nameee = reader["SecName"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            List<StudentRec> list = new List<StudentRec>();
            list.Clear();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                list.Add(new StudentRec
                {
                    rfid = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    IDnum = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    fullname = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    prog = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    year = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                    sec = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                    contactNum = dataGridView1.Rows[i].Cells[7].Value.ToString(),
                    Secname = nameee.ToUpper()
                });
            }
            rs.Name = "DataSet1";
            rs.Value = list;
            FormReport fr = new FormReport();
            fr.reportViewer1.LocalReport.DataSources.Clear();
            fr.reportViewer1.LocalReport.DataSources.Add(rs);
            fr.reportViewer1.LocalReport.ReportEmbeddedResource = "Authenti_Gate.SuperAdminTransaction.Transactions.Records.StudentRec.rdlc";
            fr.ShowDialog();
        }
    }
    public class StudentRec 
    {
        public string rfid { get; set; }
        public string IDnum { get; set; }
        public string fullname { get; set; }
        public string prog { get; set; }
        public string year { get; set; }
        public string sec { get; set; }
        public string contactNum { get; set; }
        public string Secname { get; set; }
    }
}
