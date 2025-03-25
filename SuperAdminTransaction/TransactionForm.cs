using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authenti_Gate.SuperAdminTransaction.Transactions;

namespace Authenti_Gate.SuperAdminTransaction
{
    public partial class TransactionForm : Form
    {
        public TransactionForm()
        {
            InitializeComponent();

            StudentTransacForm studTransac = new StudentTransacForm();
            transacPanel.Controls.Clear();
            studTransac.TopLevel = false;
            transacPanel.Controls.Add(studTransac);
            studTransac.Dock = DockStyle.Fill;
            studTransac.Show();

        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
