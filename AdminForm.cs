using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketManagementSystem.PresentationLayer
{ 
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure you want to exit?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to logout?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboardForm2.Show();
            addStaffsForm1.Hide();
            addMovieForm1.Hide();
            customer1.Hide();

            dashboardForm dForm = dashboardForm1 as dashboardForm;

            if(dForm != null)
            {
                dForm.refreshData();
            }

        }

        private void addStaff_btn_Click(object sender, EventArgs e)
        {
            dashboardForm2.Hide();
            addStaffsForm1.Show();
            addMovieForm1.Hide();
            customer1.Hide();


            AddStaffsForm asForm = addStaffsForm1 as AddStaffsForm;

            if(asForm != null)
            {
                asForm.refreshData();
            }
        }

        private void addMovie_btn_Click(object sender, EventArgs e)
        {
            dashboardForm2.Hide();
            addStaffsForm1.Hide();
            addMovieForm1.Show();
            customer1.Hide();


            AddMovieForm amForm = addMovieForm1 as AddMovieForm;

            if(amForm != null)
            {
                amForm.refreshData();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dashboardForm2_Load(object sender, EventArgs e)
        {

        }

        private void addMovieForm1_Load(object sender, EventArgs e)
        {

        }

        private void dashboardForm2_Load_1(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            dashboardForm2.Hide();
            addStaffsForm1.Hide();
            addMovieForm1.Hide();
            customer1.Show();
            customerForm cForm = customer1 as customerForm;
                if (cForm != null)
                {
                    cForm.Refresh();
                }
            
        }

        private void customer1_Load(object sender, EventArgs e)
        {

        }
    }
}
