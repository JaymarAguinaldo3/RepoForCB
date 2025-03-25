using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using Authenti_Gate.CustomMsgBox;
using MySqlConnector;

namespace Authenti_Gate.SuperAdminTransaction.Transactions.Add
{
    public partial class AddStudentForm : Form
    {
        
        private Color _borderColor = Color.Black;
        private int _borderThickness = 1;
        private StudentTransacForm stform;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public AddStudentForm(StudentTransacForm stform)
        {
            InitializeComponent();

            this.Paint += border_Paint;
            this.stform = stform;
        }

        private void border_Paint(object sender, PaintEventArgs e)
        {
            // Draw a simple rectangular border
            using (GraphicsPath path = new GraphicsPath())
            {
                // Define a rectangle for the border
                int width = this.Width - _borderThickness;
                int height = this.Height - _borderThickness;

                // Add the rectangle to the path
                path.AddRectangle(new Rectangle(0, 0, width, height));

                // Draw the border with the specified color and thickness
                using (Pen pen = new Pen(_borderColor, _borderThickness))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Redraw the border on resize
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            string fullname = tbLname.Text + ", " + tbFname.Text + " " + tbMname.Text + tbSuffix.Text;

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] img = ms.ToArray();

            

            string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
            var con = new MySqlConnection(cs);
            con.Open();
            try
            {
                if (string.IsNullOrWhiteSpace(tbRFID.Text) ||
                    string.IsNullOrWhiteSpace(tbStudID.Text) ||
                    string.IsNullOrWhiteSpace(tbLname.Text) ||
                    string.IsNullOrWhiteSpace(tbFname.Text) ||
                    string.IsNullOrWhiteSpace(tbMname.Text) ||
                    cbProgram.SelectedIndex == -1 ||
                    cbYear.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(tbSection.Text) ||
                    string.IsNullOrWhiteSpace(tbPhoneNumber.Text) ||
                    tbPhoneNumber.TextLength != 10 ||
                    tbRFID.TextLength != 10)
                {
                    //MessageBox.Show("Please fill all the required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    using (fillAllFieldsMsgBox fillAllFields = new fillAllFieldsMsgBox())
                    {
                        DialogResult result = fillAllFields.ShowDialog();
                    }
                }
                else
                {
                    string cmm = "INSERT into studinfo_table (RFID_tag, ID_Number, Full_Name, Program, Year, Section, Role, GuardianConNumber, Picture) VALUES(@RFID_tag, @ID_Number, @Full_Name, @Program, @Year, @Section, @Role, @GuardianConNumber, @Picture)";
                    var cmds = new MySqlCommand(cmm, con);
                    cmds.Parameters.AddWithValue("@RFID_tag", tbRFID.Text);
                    cmds.Parameters.AddWithValue("@ID_Number", tbStudID.Text);
                    cmds.Parameters.AddWithValue("@Full_Name", fullname);
                    cmds.Parameters.AddWithValue("@Program", cbProgram.SelectedItem);
                    cmds.Parameters.AddWithValue("@Year", cbYear.SelectedItem);
                    cmds.Parameters.AddWithValue("@Section", tbSection.Text.ToUpper());
                    cmds.Parameters.AddWithValue("@Role", "Student");
                    cmds.Parameters.AddWithValue("@GuardianConNumber", tbPhoneNumber.Text);
                    cmds.Parameters.AddWithValue("@Picture", img);
                    cmds.ExecuteNonQuery();

                    //MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (successAdded success = new successAdded())
                    {
                        DialogResult result = success.ShowDialog();
                    }
                    if (stform.name == " ")
                    {
                        stform.FilldataAll();
                    }
                    else 
                    {
                        stform.Filldata(stform.name, stform.name2);
                    }
                    tbRFID.Text = null;
                    tbStudID.Text = null;
                    tbLname.Text = null;
                    tbFname.Text = null;
                    tbMname.Text = null;
                    tbSuffix.Text = null;
                    cbProgram.SelectedIndex = -1;
                    cbYear.SelectedIndex = -1;
                    tbSection.Text = null;
                    tbPhoneNumber.Text = null;
                    pictureBox1.Image = Properties.Resources.AgriLogo_removebg_preview__1_;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
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

        private void btnStartCamera_Click_1(object sender, EventArgs e)
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

        private void btnCapturePhoto_Click_1(object sender, EventArgs e)
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

        private void tbRFID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddStudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
