using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MovieTicketManagementSystem.BusinessLayer;
using MovieTicketManagementSystem.TransferObject;

namespace MovieTicketManagementSystem.PresentationLayer
{
    public partial class Form1 : Form
    {
        private UserBL userBL = new UserBL();

        public Form1()
        {
            InitializeComponent();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UserDTO user = userBL.AuthenticateUser(login_username.Text.Trim(), login_password.Text.Trim());
                if (user != null)
                {
                    if (user.Status == "Active")
                    {
                        MessageBox.Show("Login successful", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (user.Role == "Admin")
                        {
                            AdminForm aForm = new AdminForm();
                            aForm.Show();
                        }
                        else if (user.Role == "Staff")
                        {
                            staffForm sForm = new staffForm();
                            sForm.Show();
                        }
                        this.Hide();
                    }
                    else if (user.Status == "Inactive")
                    {
                        MessageBox.Show("Your account is inactive. Please contact admin.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username/password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
