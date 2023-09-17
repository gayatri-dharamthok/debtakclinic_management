using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DentalClinic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin log = new AdminLogin();
            log.Show();
            this.Hide();
        }
        ConnectionString MyConnection = new ConnectionString();
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = MyConnection.Getcon();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where uname='" + Uname.Text + "' and Upass='" + Upassword.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                Patient Pa = new Patient();
                Pa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password");
                Uname.Text = "";
                Upassword.Text = "";
            }
            Con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        
    }
}
