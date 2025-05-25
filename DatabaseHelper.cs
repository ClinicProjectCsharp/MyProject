using System.Data.SqlClient;

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
