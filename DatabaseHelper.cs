<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace Empl
{
    public class DatabaseHelper
    {
        SqlConnection conn = new SqlConnection();

        public DatabaseHelper()
        {
            conn.ConnectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;\"";
            conn.Open();

        }
        public String DatabaseHel(string m)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = m;
                comm.Connection = conn;
                if (conn.State == 0)
                    conn.Open();
                comm.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception ex)
            {
                return "Error" + ex;
            }

        }
        public DataTable RunSearch(string m)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = m;
                comm.Connection = conn;
                if (conn.State == 0)
                    conn.Open();
                DataTable t = new DataTable();
                t.Load(comm.ExecuteReader());
                return t;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    } 
   
}


=======
﻿using System.Data.SqlClient;

public static class DatabaseHelper
{
    public static SqlConnection GetConnection()
    {
        // سلسلة الاتصال — تأكد من أن القاعدة موجودة والمسار صحيح
        //string connectionString = "Server=.\\SQLEXPRESS;Database = employee_managements; Trusted_Connection = True;";

        string connectionString = "Server=.;Database=employee_managements;Integrated Security=True;";
        // string connectionString = "Server=DESKTOP-BHG3RFN\\DELL;Database=employee_managements//;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open(); // فتح الاتصال
        return connection;
    }
}
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
