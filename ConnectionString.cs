using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DentalClinic
{
    class ConnectionString
    {
        public SqlConnection Getcon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gauri\OneDrive\Documents\Dentaldb.mdf;Integrated Security=True;Connect Timeout=30";
            return Con;
        }
    }
}
