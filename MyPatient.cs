using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DentalClinic
{
    class MyPatient
    {
        public void AddPatient(String Query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.Getcon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        public void DeletePatient(String Query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.Getcon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        public void UpdatePatient(String Query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.Getcon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        public DataSet ShowPatient(String Query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.Getcon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = Query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
    }
}
