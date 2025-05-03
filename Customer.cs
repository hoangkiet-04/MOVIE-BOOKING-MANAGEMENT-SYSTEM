using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MovieTicketManagementSystem.BusinessLayer;
using MovieTicketManagementSystem.TransferObject;
namespace MovieTicketManagementSystem.PresentationLayer
{
    public partial class customerForm : UserControl
    {
        public customerForm()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            customerData cData = new customerData();
            List<customerData> list = cData.GetCustomerList(); 
            customerGridView.DataSource = list;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            LoadCustomerData();
        }
    }
}



