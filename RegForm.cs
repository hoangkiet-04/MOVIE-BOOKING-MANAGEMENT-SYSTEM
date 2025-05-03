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
    public partial class RegForm : Form
    {
        private UserBL userBL = new UserBL();

        public RegForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void reg_showPass_CheckedChanged(object sender, EventArgs e)
        {
            reg_password.PasswordChar = reg_showPass.Checked ? '\0' : '*';
            reg_cPassword.PasswordChar = reg_showPass.Checked ? '\0' : '*';
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            if (reg_username.Text == "" || reg_password.Text == "" || reg_cPassword.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reg_password.Text != reg_cPassword.Text)
            {
                MessageBox.Show("Password does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reg_password.Text.Length < 8)
            {
                MessageBox.Show("Invalid Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (userBL.CheckUsernameExists(reg_username.Text.Trim()))
                {
                    MessageBox.Show(reg_username.Text.Substring(0, 1).ToUpper() + reg_username.Text.Substring(1) + " is taken already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    UserDTO user = new UserDTO
                    {
                        Username = reg_username.Text.Trim(),
                        Password = reg_password.Text.Trim(),
                        Role = "Staff",
                        Status = "Active",
                        DateReg = DateTime.Today
                    };
                    userBL.RegisterUser(user);
                    MessageBox.Show("Registered Successful", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 loginForm = new Form1();
                    loginForm.Show();
                    this.Hide();
                }
            }
        }
    }
}