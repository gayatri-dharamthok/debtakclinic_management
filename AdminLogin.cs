using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AdminPass.Text=="")
            {
                MessageBox.Show("Enter the Admin Password");
            }
            else if(AdminPass.Text=="Password")
            {
                User U = new User();
                U.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Password. Contact The Admin");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
