using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Authenti_Gate.Home
{
    public partial class HomeForm : Form
    {
        int stCount = 0;
        public HomeForm()
        {
            InitializeComponent();

            vision miss = new vision();
            missionVisionPanel.Controls.Clear();
            miss.TopLevel = false;
            missionVisionPanel.Controls.Add(miss);
            miss.Dock = DockStyle.Fill;
            miss.Show();

            roundedButton2.BackColor = Color.White;
            roundedButton2.ForeColor = Color.MidnightBlue;
        }
        public void TotStud()
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();
                    string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

                    //BSA Students ------------------------------

                    int bsaOne = GetStudentCountInside(con,"1", "BSA", currentDate);
                    int bsaOneTot = GetTotalStudentCount(con,"1", "BSA");
                    bsa1.Text = $"{bsaOne}/{bsaOneTot}";

                    int bsaTwo = GetStudentCountInside(con, "2", "BSA", currentDate);
                    int bsaTwoTot = GetTotalStudentCount(con, "2", "BSA");
                    bsa2.Text = $"{bsaTwo}/{bsaTwoTot}";

                    int bsaThree = GetStudentCountInside(con, "3", "BSA", currentDate);
                    int bsaThreeTot = GetTotalStudentCount(con, "3", "BSA");
                    bsa3.Text = $"{bsaThree}/{bsaThreeTot}";

                    int bsaFour = GetStudentCountInside(con, "4", "BSA", currentDate);
                    int bsaFourTot = GetTotalStudentCount(con, "4", "BSA");
                    bsa4.Text = $"{bsaFour}/{bsaFourTot}";

                    //DAT Students ------------------------------

                    int datOne = GetStudentCountInside(con,"1", "DAT", currentDate);
                    int datOneTot = GetTotalStudentCount(con,"1", "DAT");
                    dat1.Text = $"{datOne}/{datOneTot}";

                    int datTwo = GetStudentCountInside(con, "2", "DAT", currentDate);
                    int datTwoTot = GetTotalStudentCount(con, "2", "DAT");
                    dat2.Text = $"{datTwo}/{datTwoTot}";

                    int datThree = GetStudentCountInside(con, "3", "DAT", currentDate);
                    int datThreeTot = GetTotalStudentCount(con, "3", "DAT");
                    dat3.Text = $"{datThree}/{datThreeTot}";

                    int datFour = GetStudentCountInside(con, "4", "DAT", currentDate);
                    int datFourTot = GetTotalStudentCount(con, "4", "DAT");
                    dat4.Text = $"{datFour}/{datFourTot}";

                    //BSA -Animal Science Students ------------------------------

                    int bsaasOne = GetStudentCountInside(con, "1", "BSA-AS", currentDate);
                    int bsaasOneTot = GetTotalStudentCount(con, "1", "BSA-AS");
                    bsaas1.Text = $"{bsaasOne}/{bsaasOneTot}";

                    int bsaasTwo = GetStudentCountInside(con, "2", "BSA-AS", currentDate);
                    int bsaasTwoTot = GetTotalStudentCount(con, "2", "BSA-AS");
                    bsaas2.Text = $"{bsaasTwo}/{bsaasTwoTot}";

                    int bsaasThree = GetStudentCountInside(con, "3", "BSA-AS", currentDate);
                    int bsaasThreeTot = GetTotalStudentCount(con, "3", "BSA-AS");
                    bsaas3.Text = $"{bsaasThree}/{bsaasThreeTot}";

                    int bsaasFour = GetStudentCountInside(con, "4", "BSA-AS", currentDate);
                    int bsaasFourTot = GetTotalStudentCount(con, "4", "BSA-AS");
                    bsaas4.Text = $"{bsaasFour}/{bsaasFourTot}";

                    //BSA - Crop Science Students ------------------------------

                    int bsacsOne = GetStudentCountInside(con, "1", "BSA-CS", currentDate);
                    int bsacsOneTot = GetTotalStudentCount(con, "1", "BSA-CS");
                    bsacs1.Text = $"{bsacsOne}/{bsacsOneTot}";

                    int bsacsTwo = GetStudentCountInside(con, "2", "BSA-CS", currentDate);
                    int bsacsTwoTot = GetTotalStudentCount(con, "2", "BSA-CS");
                    bsacs2.Text = $"{bsacsTwo}/{bsacsTwoTot}";

                    int bsacsThree = GetStudentCountInside(con, "3", "BSA-CS", currentDate);
                    int bsacsThreeTot = GetTotalStudentCount(con, "3", "BSA-CS");
                    bsacs3.Text = $"{bsacsThree}/{bsacsThreeTot}";

                    int bsacsFour = GetStudentCountInside(con, "4", "BSA-CS", currentDate);
                    int bsacsFourTot = GetTotalStudentCount(con, "4", "BSA-CS");
                    bsacs4.Text = $"{bsacsFour}/{bsacsFourTot}";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetTotalStudentCount(MySqlConnection con, string year, string program)
        {
            string query = @"SELECT COUNT(*) FROM studinfo_table WHERE Year = @year AND Program = @Program";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Program", program);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetStudentCountInside(MySqlConnection con, string year , string program, string logDate)
        {
            string query = @"SELECT COUNT(*) FROM studlogs_table WHERE Year = @year AND Program = @Program AND Login_date = @LogDate AND Time_out = '"+" "+"'";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Program", program);
                cmd.Parameters.AddWithValue("@LogDate", logDate);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void Student() 
        {
            try 
            {
                string cs = @"server=localhost;userid=root;password=;database=coacolscdb";
                var con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM studinfo_table WHERE Year = '" + 1 + "'", con);
                var count = cmd.ExecuteScalar();
                stCount = count.GetHashCode();
                labelStud.Text = stCount.ToString();

                MySqlCommand cmdd = new MySqlCommand("SELECT COUNT(*) FROM studinfo_table WHERE Year = '" + 2 + "'", con);
                var countt = cmdd.ExecuteScalar();
                int stud2 = countt.GetHashCode();
                labelStud2.Text = stud2.ToString();

                MySqlCommand cmdds = new MySqlCommand("SELECT COUNT(*) FROM studinfo_table WHERE Year = '" + 3 + "'", con);
                var counttt = cmdds.ExecuteScalar();
                int stud3 = counttt.GetHashCode();
                labelStud3.Text = stud3.ToString();

                MySqlCommand cmdss = new MySqlCommand("SELECT COUNT(*) FROM studinfo_table WHERE Year = '" + 4 + "'", con);
                var counts = cmdss.ExecuteScalar();
                int stud4 = counts.GetHashCode();
                labelStud4.Text = stud4.ToString();
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            SearchEntriesForm searchEntriesForm = new SearchEntriesForm();
            searchEntriesForm.Show();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            mission miss = new mission();
            missionVisionPanel.Controls.Clear();
            miss.TopLevel = false;
            missionVisionPanel.Controls.Add(miss);
            miss.Dock = DockStyle.Fill;
            miss.Show();

            roundedButton1.BackColor = Color.White;
            roundedButton1.ForeColor = Color.DarkGreen;

            roundedButton2.BackColor = Color.DarkGreen;
            roundedButton2.ForeColor = Color.White;
        }


        private void roundedButton2_Click(object sender, EventArgs e)
        {
            vision vis = new vision();
            missionVisionPanel.Controls.Clear();
            vis.TopLevel = false;
            missionVisionPanel.Controls.Add(vis);
            vis.Dock = DockStyle.Fill;
            vis.Show();

            roundedButton2.BackColor = Color.White;
            roundedButton2.ForeColor = Color.DarkGreen;

            roundedButton1.BackColor = Color.DarkGreen;
            roundedButton1.ForeColor = Color.White;
        }

        private void ctedFacTotLbl_Click(object sender, EventArgs e)
        {

        }

       
        

        private void HomeForm_Load(object sender, EventArgs e)
        {
            TotStud();

            Student();
        }

        
    }
}
