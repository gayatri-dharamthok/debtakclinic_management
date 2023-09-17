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

namespace DentalClinic
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        ConnectionString Mycon = new ConnectionString();
        private void FillPatient()
        {
            SqlConnection Con = Mycon.Getcon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PatName from PatientTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatName", typeof(string));
            dt.Load(rdr);
            PatientCb.ValueMember = "PatName";
            PatientCb.DataSource = dt;
            Con.Close();
        }
        private void FillTreatment()
        {
            SqlConnection Con = Mycon.Getcon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TreatName from TreatmentTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TreatName", typeof(string));
            dt.Load(rdr);
            TreatmentCb.ValueMember = "TreatName";
            TreatmentCb.DataSource = dt;
            Con.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            FillPatient();
            FillTreatment();
            populate();
        }
        void populate()
        {
            MyPatient pat = new MyPatient();
            string Query = "Select * from AppointmentTbl";
            DataSet ds = pat.ShowPatient(Query);
            AppointmentDGV.DataSource = ds.Tables[0];

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into AppointmentTbl values('" + PatientCb.SelectedValue.ToString() + "','" + TreatmentCb.SelectedValue.ToString() + "','" +Date.Value.ToString("dd-MM-yyyy") + "','" + textBox1.Text + "')";

            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Appointment Successfully Recorded");
                populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void AppointmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientCb.SelectedValue = AppointmentDGV.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentCb.SelectedValue = AppointmentDGV.SelectedRows[0].Cells[2].Value.ToString();
            Date.Text = AppointmentDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBox1.Text = AppointmentDGV.SelectedRows[0].Cells[4].Value.ToString();
            string pat = AppointmentDGV.SelectedRows[0].Cells[2].Value.ToString();

            if (pat == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AppointmentDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPatient pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Appointment");
            }
            else
            {
                try
                {
                    string Query = "Delete from AppointmentTbl where ApId=" + key + "";
                    pat.DeletePatient(Query);
                    MessageBox.Show("Appointment Successfully Cancelled");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyPatient pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Appointment");
            }
            else
            {
                try
                {
                    string Query = "Update AppointmentTbl set Patient='" + PatientCb.SelectedValue.ToString() + "',Treatment ='" + TreatmentCb.SelectedValue.ToString() + "',ApDate ='" +Date.Value.Date+ "', ApTime='" + textBox1.Text + "'where ApId=" + key + ";";

                    pat.DeletePatient(Query);
                    MessageBox.Show("Appointment Successfully Updated");
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Treatment Treat = new Treatment();
            Treat.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
