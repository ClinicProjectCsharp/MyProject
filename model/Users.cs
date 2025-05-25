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
   
    class Users
    {
 public struct Remember
        {
           public String UserName;
           public int UserID;

            public String Password;
        }

        static string ConectionString = "Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen";
        public static DataGridView GetUsers()
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select u.UserID 'User ID',u.PersonID 'Person ID',p.FirstName+' '+p.SecondName+' '+p.ThirdName+' '+p.LastName 'Full Name',u.UserName 'UserName',u.Active 'Is Active' from Users u join Person p on(u.PersonID=p.PersonID)";
            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();
                return v;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return v;
            }

        }
        public static string[] GetUserNameAndPasswordAndActive(string UserName)
        {
            string[] temp = new string[3];
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select top(1) UserName,Password,Active from Users where UserName=@UserName";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    temp[0] = reader[0].ToString();
                    temp[1] = reader[1].ToString();
                    temp[2] = reader[2].ToString();

                }





                connection.Close();
                return temp;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return temp;
            }

        }
        public static List<String[]> GetNotifications()
        {
           
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select NotificationsID,NotificationsDate,NotificationsDetail,UserID,NotificationsReading from Notifications order by NotificationsID desc ";
            SqlCommand Command = new SqlCommand(query, connection);
            List<String[]> list = new List<string[]>();
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    string[] temp = new string[5];
                    temp[0] = reader[0].ToString();
                    temp[1] = reader[1].ToString();
                    temp[2] = reader[2].ToString();
                    temp[3] = reader[3].ToString();
                    temp[4] = reader[4].ToString();
                    list.Add(temp);

                }





                connection.Close();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static String[]GetNotificationsByID(int NotificationsID)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select NotificationsID,NotificationsDate,NotificationsDetail,UserID,NotificationsReading from Notifications where NotificationsID=@NotificationsID   ";
            SqlCommand Command = new SqlCommand(query, connection);
            string[] temp = new string[5];
            try
            {
                connection.Open();

                Command.Parameters.AddWithValue("@NotificationsID", NotificationsID);
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                 
                    temp[0] = reader[0].ToString();
                    temp[1] = reader[1].ToString();
                    temp[2] = reader[2].ToString();
                    temp[3] = reader[3].ToString();
                    temp[4] = reader[4].ToString();
                

                }





                connection.Close();
                return temp;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static Boolean UpdateNotification(int NotificationsID)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update Notifications set NotificationsReading=1 where NotificationsID=@NotificationsID";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@NotificationsID", NotificationsID);




            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                return reader.Read();
                connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static Boolean AddNotification(string UserID, string NotificationsDetail,DateTime NotificationsDate)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "insert into Notifications(UserID,NotificationsDetail,NotificationsDate) values ( @UserID ,@NotificationsDetail,@NotificationsDate)";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@NotificationsDetail", NotificationsDetail);
            Command.Parameters.AddWithValue("@NotificationsDate", NotificationsDate);
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
        public static Boolean AddRemember(string UserName, string Password)
        {

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "insert into RememberLogin(UserName,Password) values ( @UserName ,@Password)";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
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
        public static List<Remember> GetRemembers()
        {
            List<Remember> l = new List<Remember>();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select top(5) UserName,Password from RememberLogin order by RememberLoginID asc";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    Remember m = new Remember();

                   m.UserName= reader[0].ToString();
                  m.Password = reader[1].ToString();
                    l.Add(m);

                }






                connection.Close();
                reader.Close();

                return l;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static DataGridView GetUser()
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  u.UserID 'رقم المستخدم',u.Name 'الاسم',u.UserName 'اسم المستخدم',u.Password 'كلمة السر',u.Active 'النشاط',u.Email 'البريد الالكتروني',p.PermissionName 'الصلاحيات' from Users u join Permission p on(u.PermissionID=p.PermissionID) ";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();

                return v;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static List<String[]> GetUserToPrint()
        {
            List<String[]> data = new List<string[]>();
            
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  u.UserID 'رقم المستخدم',u.Name 'الاسم',u.UserName 'اسم المستخدم',u.Password 'كلمة السر',u.Active 'النشاط',u.Email 'الايميل',p.PermissionName 'الصلاحيات' from Users u join Permission p on(u.PermissionID=p.PermissionID) ";

            SqlCommand Command = new SqlCommand(query, connection);

            String[] arr = new String[7];
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                arr[0]= "رقم المستخدم";
                arr[1] = " الاسم";
                arr[2] = " اسم المستخدم";
                arr[3]= " كلمة السر";
                arr[4] = " النشاط";
                arr[5] = " البريد الالكتروني";
                arr[6] = " الصلاحية";
                data.Add(arr);
          
                while (reader.Read())
                {
                    String []datas = new String[7];
                    datas[0] = reader[0].ToString();
                    datas[1] = reader[1].ToString();
                    datas[2] = reader[2].ToString();
                    datas[3] = reader[3].ToString();
                    datas[4] = reader[4].ToString();
                    datas[5] = reader[5].ToString();
                    datas[6] = reader[6].ToString();
                    data.Add(datas);

                }






                connection.Close();
                reader.Close();

                return data;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static DataGridView GetUserSearchByText(String Text)
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  u.UserID 'رقم المستخدم',u.Name 'الاسم',u.UserName 'اسم المستخدم',u.Password 'كلمة السر',u.Active 'النشاط',p.PermissionName 'الصلاحيات' from Users u join Permission p on(u.PermissionID=p.PermissionID)  where u.UserName like N'"+Text+"%'";

            SqlCommand Command = new SqlCommand(query, connection);
    
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();

                return v;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static List<String> GetPermission()
        {
            List<String> l = new List<string>();
           
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select PermissionName from Permission";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    l.Add(reader[0].ToString());

                }






                connection.Close();
                reader.Close();

                return l;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static Boolean AddUser(String Name,String UserName,String Password,int Active ,int PermissionID,String Email,String Imge)
        {
         

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "insert into Users(Name,UserName,Password,Active,PermissionID,Email,Imge) values(@Name,@UserName,@Password,@Active,@PermissionID,@Email,@Imge)";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Active", Active);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);
            Command.Parameters.AddWithValue("@Imge",Imge);



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

        public static String GetNameByUserNameAndPassword( String UserName, String Password)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select Name from Users where UserName=@UserName and Password=@Password";

            SqlCommand Command = new SqlCommand(query, connection);
    
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);


            String Name;

            try
            {
                connection.Open();
       SqlDataReader reader=         Command.ExecuteReader();

                reader.Read();
                Name = reader[0].ToString();





                connection.Close();


                return Name;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static String GetImgeUserByUserID(int UserID)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select Imge from Users where UserID=@UserID ";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            String Name;

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                reader.Read();
                Name = reader[0].ToString();





                connection.Close();


                return Name;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static int GetPermissionIDByName(String PermissionName)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Select PermissionID from Permission where PermissionName=@PermissionName";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionName", PermissionName);

            int Id;


            try
            {
                connection.Open();
           SqlDataReader reader=     Command.ExecuteReader();
                reader.Read();


             Id=   int.Parse(reader[0].ToString());
                connection.Close();

             
                reader.Close();

                return Id;








            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return -1;
            }

        }
        public static Boolean IsEmail(String Email)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Select Email from Users where Email=@Email";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@Email", Email);

          


            try
            {
                connection.Open();
              SqlDataReader reader = Command.ExecuteReader();
              return   reader.Read();
                connection.Close();


            

              








            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return false;
            }

        }
        public static int GetUserIDByUserName(String UserName ,String Password)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Select UserID from Users where UserName=@UserName and Password=@Password";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);




            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                return int.Parse( reader[0].ToString());
                connection.Close();













            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return -1;
            }

        }

        public static Boolean ChangePasswordByEmail(String Email,String Password)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "update Users set Password=@Password where Email=@Email";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@Password", Password);

            Command.Parameters.AddWithValue("@Email", Email);
        



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


        public static Boolean UpdateUser(int UserID,String Name, String UserName, String Password, int Active, int PermissionID,String Email,String Imge)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update Users set Name=@Name,UserName=@UserName,Password=@Password,Active=@Active,PermissionID=@PermissionID,Email=@Email,Imge=@Imge   where UserID=@UserID";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Active", Active);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Imge", Imge);



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


        public static Boolean DeleteUser(int UserID)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "delete from Users where UserID=@UserID";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserID", UserID);



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


        public static DataGridView FilterByActive()
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  u.UserID 'رقم المستخدم',u.Name 'الاسم',u.UserName 'اسم المستخدم',u.Password 'كلمة السر',u.Active 'النشاط',p.PermissionName 'الصلاحيات' from Users u join Permission p on(u.PermissionID=p.PermissionID) where u.Active=1 ";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();

                return v;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }


        public static DataGridView FilterByNonActive()
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select  u.UserID 'رقم المستخدم',u.Name 'الاسم',u.UserName 'اسم المستخدم',u.Password 'كلمة السر',u.Active 'النشاط',p.PermissionName 'الصلاحيات' from Users u join Permission p on(u.PermissionID=p.PermissionID) where u.Active=0 ";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();

                return v;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static Boolean AddPerimission(String PermissionName,String PermissionDetail)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "insert into Permission(PermissionName,PermissionDetail) values(@PermissionName,@PermissionDetail)";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionName", PermissionName);
            Command.Parameters.AddWithValue("@PermissionDetail", PermissionDetail);
       



            try
            {
                connection.Open();
                Command.ExecuteNonQuery();







                connection.Close();


                return true;


            }
            catch (Exception e)
            {
          

                connection.Close();
                return false;
            }

        }


        public static Boolean AddPerimissionAndServeces(int PermissionID, int []array)
        {
           

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "insert into PermissionAndServeces(PermissionID,ServecesID,PermissionAndServecesActive) " +
                "values(@PermissionID,1,@A1),(@PermissionID,2,@A2),(@PermissionID,3,@A3),(@PermissionID,4,@A4),(@PermissionID,5,@A5),(@PermissionID,6,@A6)," +
                "(@PermissionID,7,@A7),(@PermissionID,8,@A8),(@PermissionID,9,@A9),(@PermissionID,10,@A10)";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);
            Command.Parameters.AddWithValue("@A1", array[0]);
            Command.Parameters.AddWithValue("@A2", array[1]);
            Command.Parameters.AddWithValue("@A3", array[2]);
            Command.Parameters.AddWithValue("@A4", array[3]);
            Command.Parameters.AddWithValue("@A5", array[4]);
            Command.Parameters.AddWithValue("@A6", array[5]);
            Command.Parameters.AddWithValue("@A7", array[6]);
            Command.Parameters.AddWithValue("@A8", array[7]);
            Command.Parameters.AddWithValue("@A9", array[8]);
            Command.Parameters.AddWithValue("@A10", array[9]);




            try
            {
                connection.Open();
                Command.ExecuteNonQuery();







                connection.Close();


                return true;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+"hi ");

                connection.Close();
                return false;
            }

        }

        public static DataGridView GetPerimissons()
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select p.PermissionID 'رقم الصلاحية',p.PermissionName 'اسم الصلاحية',p.PermissionDetail 'ملاحضات', (count(s.PermissionAndServecesID)/10.0)*100 'نسبة الصلاحية' from Permission p join PermissionAndServeces s on(p.PermissionID=s.PermissionID) where s.PermissionAndServecesActive=1   group by p.PermissionID,p.PermissionName,p.PermissionDetail  order by count(s.PermissionAndServecesID)";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();

                return v;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }
        public static DataGridView GetPerimissonsOfSearch(String text)
        {
            DataGridView v = new DataGridView();
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select p.PermissionID 'رقم الصلاحية',p.PermissionName 'اسم الصلاحية',p.PermissionDetail 'ملاحضات', (count(s.PermissionAndServecesID)/9.0)*100 'نسبة الصلاحية' from Permission p join PermissionAndServeces s on(p.PermissionID=s.PermissionID) where s.PermissionAndServecesActive=1  and p.PermissionName like N'"+text+"%'  group by p.PermissionID,p.PermissionName,p.PermissionDetail   order by count(s.PermissionAndServecesID)";

            SqlCommand Command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                v.DataSource = t;






                connection.Close();
                reader.Close();

                return v;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+"أه");

                connection.Close();
                return null;
            }

        }
        public static  String[] GetInfoOfPermission( int PermissionID)
        {

            String[] arr = new string[3];
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Select PermissionID,PermissionName,PermissionDetail from Permission where PermissionID=@PermissionID";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);



            try
            {
                connection.Open();
           SqlDataReader reader=  Command.ExecuteReader();
                while (reader.Read())
                {
                    arr[0] = reader[0].ToString();
                    arr[1] = reader[1].ToString();
                    arr[2] = reader[2].ToString();



                }






                connection.Close();


                return arr;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static String[] GetInfoOfServeses(int PermissionID)
        {

            String[] arr = new string[10];
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select PermissionAndServecesActive from PermissionAndServeces where PermissionID=@PermissionID";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);



            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    arr[i] = reader[0].ToString();

                    i++;


                }






                connection.Close();


                return arr;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return null;
            }

        }

        public static Boolean UpdatePerimisiion(int PermissionID,String PermissionName,String PermissionDetail)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = " update   Permission set PermissionName=@PermissionName,PermissionDetail=@PermissionDetail where PermissionID=@PermissionID";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionName", PermissionName);
            Command.Parameters.AddWithValue("@PermissionDetail", PermissionDetail);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);




            try
            {
                connection.Open();
                Command.ExecuteNonQuery();







                connection.Close();


                return true;


            }
            catch (Exception e)
            {


                connection.Close();
                return false;
            }

        }

        public static Boolean UpdatePerimissionAndServeces(int PermissionID, int array,int idex)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Update  PermissionAndServeces set  PermissionAndServecesActive=@A1 where PermissionID=@PermissionID and PermissionAndServecesID=@B1";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);
            Command.Parameters.AddWithValue("@A1", array);
            Command.Parameters.AddWithValue("@B1", idex);
       




            try
            {
                connection.Open();
                Command.ExecuteNonQuery();







                connection.Close();


                return true;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "hi ");

                connection.Close();
                return false;
            }

        }

        public static int[] GetIndexofServesesAndPermission(int PermissionID)
        {
            int[] arr = new int[10];

            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "Select PermissionAndServecesID from PermissionAndServeces where PermissionID=@PermissionID ";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);
           





            try
            {
                connection.Open();
            SqlDataReader reader=    Command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    arr[i] =int.Parse( reader[0].ToString());
                    i++;

                }






                connection.Close();


                return arr;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "hi ");

                connection.Close();
                return null;
            }

        }
        public static Boolean DeletePerimission( int PermissionID)
        {


            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "delete from Permission where PermissionID=@PermissionID ";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@PermissionID", PermissionID);
          




            try
            {
                connection.Open();
                Command.ExecuteNonQuery();







                connection.Close();


                return true;


            }
            catch (Exception e)
            {


                connection.Close();
                return false;
            }

        }
        public static int GetPerimissionOfUserNameAndPassword(String UserName,String Password)
        {

            
            SqlConnection connection = new SqlConnection(ConectionString);
            string query = "select PermissionID from Users where UserName=@UserName and Password=@Password";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);


            String PermissionName = "";
            try
            {
                
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
             
                while (reader.Read())
                {
                    PermissionName= reader[0].ToString();

                  


                }






                connection.Close();


                return int.Parse(PermissionName);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                connection.Close();
                return -1;
            }

        }

        
    }

}
