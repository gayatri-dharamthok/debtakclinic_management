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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into PatientTbl values('" + PatNameTb.Text + "','" + PatPhoneTb.Text + "','" + AddressTb.Text + "','" + DOBDate.Value.Date + "','" + GenCb.SelectedItem.ToString() + "','" + AllergyTb.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Patient Successfully Added");
                populate();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void populate()
        {
            MyPatient pat = new MyPatient();
            string Query = "Select * from PatientTbl";
            DataSet ds = pat.ShowPatient(Query);
            PatientDGV.DataSource = ds.Tables[0];

        }
        private void Patient_Load(object sender, EventArgs e)
        {
            populate();
        }
       
       int key = 0;

        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void PatientDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            PatNameTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            PatPhoneTb.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenCb.SelectedItem = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            AllergyTb.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();
            if(PatNameTb.Text=="")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(PatientDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPatient pat = new MyPatient();
            if (key==0)
            {
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    string Query = "Delete from PatientTbl where PatId=" + key + "";
                    pat.DeletePatient(Query);
                    MessageBox.Show("Patient Successfully Deleted");
                    populate();
                }
                catch(Exception Ex)
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
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    string Query = "Update PatientTbl set PatName='"+PatNameTb.Text+"',PatPhone='"+PatPhoneTb.Text+"',PatAddress='"+AddressTb.Text+"',PatDOB='"+DOBDate.Value.Date+"',PatGender='"+GenCb.SelectedItem.ToString()+"',PatAllergies='"+AllergyTb.Text+"'where PatId="+key+";";




                    pat.DeletePatient(Query);
                    MessageBox.Show("Patient Successfully Updated");
                    populate();
                }





                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Prescription Presc = new Prescription();
            Presc.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Treatment Trest = new Treatment();
            Trest.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Appointment App = new Appointment();
            App.Show();
            this.Hide();
        }
    }
}
