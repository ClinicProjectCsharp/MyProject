using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.model
{
   
    class Setting
    {

        static string ConectionString = "Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen";
        public static String[] GetInfo()
        {
           
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select ClinicInfoName,ClinicInfoPhone,ClinicInfoEmail,ClinicInfoNumberRecord,ClinicInfoAddress,ClinicInfoWorkStart,ClinicInfoWorkFinish from ClinicInfo";
            SqlCommand Command = new SqlCommand(query, connection);
            String[] arr = new String[7];

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                arr[0] = reader[0].ToString();
                arr[1] = reader[1].ToString();
                arr[2] = reader[2].ToString();
                arr[3] = reader[3].ToString();
                arr[4] = reader[4].ToString();
                arr[5] = reader[5].ToString();
                arr[6] = reader[6].ToString();
          
           
               








                connection.Close();
                reader.Close();
                return arr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static Boolean UpdateInfo(String ClinicInfoName, String ClinicInfoPhone, String ClinicInfoEmail, String ClinicInfoNumberRecord, String ClinicInfoAddress, String ClinicInfoWorkStart, String ClinicInfoWorkFinish)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update ClinicInfo set ClinicInfoName=@ClinicInfoName,ClinicInfoPhone=@ClinicInfoPhone,ClinicInfoEmail=@ClinicInfoEmail,ClinicInfoNumberRecord=@ClinicInfoNumberRecord,ClinicInfoAddress=@ClinicInfoAddress,ClinicInfoWorkStart=@ClinicInfoWorkStart,ClinicInfoWorkFinish=@ClinicInfoWorkFinish from ClinicInfo";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ClinicInfoName", ClinicInfoName);
            Command.Parameters.AddWithValue("@ClinicInfoPhone", ClinicInfoPhone);
            Command.Parameters.AddWithValue("@ClinicInfoEmail", ClinicInfoEmail);
            Command.Parameters.AddWithValue("@ClinicInfoNumberRecord", ClinicInfoNumberRecord);
            Command.Parameters.AddWithValue("@ClinicInfoAddress", ClinicInfoAddress);
            Command.Parameters.AddWithValue("@ClinicInfoWorkStart", ClinicInfoWorkStart);
            Command.Parameters.AddWithValue("@ClinicInfoWorkFinish", ClinicInfoWorkFinish);

            try
            {
                connection.Open();
                 Command.ExecuteNonQuery();
             











                connection.Close();
              
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }

        public static String GitPictureLogin()
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  ClinicInfoPictureURL from ClinicPicture where ClinicInfoPictureID=2";
            SqlCommand Command = new SqlCommand(query, connection);

            String Path="";
            try
            {
                connection.Open();
      SqlDataReader reader   =   Command.ExecuteReader();
                reader.Read();
                Path = reader[0].ToString();


                connection.Close();

                return Path;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static String GitPictureMain()
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  ClinicInfoPictureURL from ClinicPicture where ClinicInfoPictureID=1";
            SqlCommand Command = new SqlCommand(query, connection);

            String Path = "";
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                Path = reader[0].ToString();


                connection.Close();

                return Path;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static Boolean UpdatePictureMain(String ClinicInfoPictureURL)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update ClinicPicture set   ClinicInfoPictureURL=@ClinicInfoPictureURL  where ClinicInfoPictureID=1";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ClinicInfoPictureURL", ClinicInfoPictureURL);
         
            try
            {
                connection.Open();
              Command.ExecuteNonQuery();
             


                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+"Hi");

                connection.Close();
                return false;
            }

        }
        public static Boolean UpdatePictureLogin(String ClinicInfoPictureURL)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update ClinicPicture set   ClinicInfoPictureURL=@ClinicInfoPictureURL  where ClinicInfoPictureID=2";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ClinicInfoPictureURL", ClinicInfoPictureURL);

            try
            {
                connection.Open();
                Command.ExecuteNonQuery();



                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static Boolean UpdatePictureIcon(String ClinicInfoPictureURL)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update ClinicPicture set   ClinicInfoPictureURL=@ClinicInfoPictureURL  where ClinicInfoPictureID=3";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ClinicInfoPictureURL", ClinicInfoPictureURL);

            try
            {
                connection.Open();
                Command.ExecuteNonQuery();



                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static String GitPictureIcon()
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  ClinicInfoPictureURL from ClinicPicture where ClinicInfoPictureID=3";
            SqlCommand Command = new SqlCommand(query, connection);

            String Path = "";
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                Path = reader[0].ToString();


                connection.Close();

                return Path;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static String[] GetStatement()
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select StatementsPrice ,AfterStatementsRate,StatementsDiscounts from Statements";
            SqlCommand Command = new SqlCommand(query, connection);
            String[] arr = new String[3];

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                arr[0] = reader[0].ToString();
                arr[1] = reader[1].ToString();
                arr[2] = reader[2].ToString();
              











                connection.Close();
                reader.Close();
                return arr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static Boolean UpdateStatement(float StatementsPrice, float AfterStatementsRate,float StatementsDiscounts)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update Statements  set StatementsPrice=@StatementsPrice,AfterStatementsRate=@AfterStatementsRate,StatementsDiscounts=@StatementsDiscounts ";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@StatementsPrice", StatementsPrice);
            Command.Parameters.AddWithValue("@AfterStatementsRate", AfterStatementsRate);
            Command.Parameters.AddWithValue("@StatementsDiscounts", StatementsDiscounts);
 

            try
            {
                connection.Open();
                Command.ExecuteNonQuery();












                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static String GetLanguage()
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  LanguagesName from Languages ";
            SqlCommand Command = new SqlCommand(query, connection);

            String Path = "";
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                Path = reader[0].ToString();


                connection.Close();

                return Path;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static Boolean UpdateLanguage(String LanguagesName)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update  Languages set LanguagesName=@LanguagesName ";
            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@LanguagesName", LanguagesName);
            try
            {
                connection.Open();
                Command.ExecuteNonQuery();
          

                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }

        public static Boolean BackUp(String Path)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "backup database ClinicDatabase to disk = @Path with differential";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@Path", Path);


            try
            {
                connection.Open();
               Command.ExecuteNonQuery();
               


                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static Boolean RestoreBackUp(String Path)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "restore database ClinicDatabase from disk =@Path; ";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@Path", Path);


            try
            {
                connection.Open();
                Command.ExecuteNonQuery();



                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static Boolean DeletePasswordRemember()
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Delete from RememberLogin ";
            SqlCommand Command = new SqlCommand(query, connection);
          


            try
            {
                connection.Open();
                Command.ExecuteNonQuery();



                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
    }
}
