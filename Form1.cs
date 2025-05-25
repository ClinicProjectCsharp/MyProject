using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Xml.Linq;
<<<<<<< HEAD

namespace Empl
{
    public partial class FormStartPosition : Form
    {
        public FormStartPosition()
        {
            
            InitializeComponent();
            Time.Text = DateTime.Now.ToString("yyyy_MM-dd    hh  :mm:ss");

        }

        private void DeleteAllEmployees()
        {//دالة التفريغ 
         //  string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";

            //string connectionString = "Server=localhost;Port=3307;Database=employee_management;User ID=root;Password=;";


            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات لحذفها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("هل أنت متأكد أنك تريد حذف جميع البيانات من الجدول؟",
                                                "تأكيد الحذف",
                                             MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            try
            {
                // اتصال قاعدة البيانات
                //using (MySqlConnection connection = new MySqlConnection(connectionString))
                SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");

                {
                    con.Open();

                    // استعلام الحذف
                    string query = "DELETE FROM employees";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // تحديث DataGridView
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("تم حذف جميع البيانات من الجدول بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("لا توجد بيانات لحذفها في قاعدة البيانات!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"خطأ قاعدة البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
 
        private void button2_Click(object sender, EventArgs e)
        {  // زر التفريغ
          DeleteAllEmployees();
            ClearFields();

        }


        private void UpdateEmployee()
        {  //  التعديل  الدالة
            string gender; 
            if (rdoMales.Checked)
            {
                gender = "ذكر";
            }
            else
            {
                gender = "أنثى";
            }


            if (string.IsNullOrWhiteSpace(TextEmployeeID.Text))
            {
                MessageBox.Show("يرجى تحديد موظف لتعديله!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");

            {
                try
                {
                    con.Open();

                    string query = @"UPDATE employees 
                      SET EmployeeName = @name, 
                          Age = @age, 
                          DepartmentID = @departmentId, 
                          Address = @address, 
                          PhoneNumber = @phone, 
                          Email = @email, 
                          Salary = @salary, 
                          WorkDays = @notes,
                          Gender = @gender
                      WHERE EmployeeID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", TextEmployeeID.Text);
                        command.Parameters.AddWithValue("@name", txtEmployeeName.Text);
                        command.Parameters.AddWithValue("@age", txtAge.Text);
                        command.Parameters.AddWithValue("@departmentId", txtDepartmentNumber.Text);
                        command.Parameters.AddWithValue("@address", txtAddress.Text);
                        command.Parameters.AddWithValue("@phone", txtPhone.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@salary", txtSalary.Text);
                        command.Parameters.AddWithValue("@notes", txtNotes.Text);
                        command.Parameters.AddWithValue("@gender", gender); // تمرير قيمة الجنس هنا

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("تم تعديل البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على الموظف لتحديثه!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"خطأ أثناء تعديل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {     // زر التعديل
             UpdateEmployee();
            ClearFields();

        }

        
        private void LoadEmployees()
        {// تتعمل معا الجدول 
         // string connectionString = "Server=localhost;Port=3307;Database=employee_management;Uid=root;Pwd=;";
         //using (MySqlConnection connection = new MySqlConnection(connectionString))

            //   string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");

            {
                try
                {
                    con.Open();

                    string query = "SELECT * FROM employees"; // استعلام جلب البيانات
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // التأكد من أن الجدول يحتوي على بيانات
                    if (table.Rows.Count > 0)
                    {
                        // إعداد الأعمدة يدويًا وترتيبها
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.Columns.Clear();

                        // إضافة الأعمدة مع الترتيب المطلوب
                        
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "WorkDays", HeaderText = " الملاحظات ", DataPropertyName = "WorkDays" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "البريد ", DataPropertyName = "Email" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Salary", HeaderText = "الراتب", DataPropertyName = "Salary" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DepartmentID", HeaderText = "رقم القسم", DataPropertyName = "DepartmentID" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Gender", HeaderText = "النوع", DataPropertyName = "Gender" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PhoneNumber", HeaderText = "رقم الهاتف", DataPropertyName = "PhoneNumber" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", HeaderText = "العنوان", DataPropertyName = "Address" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Age", HeaderText = "العمر", DataPropertyName = "Age" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmployeeName", HeaderText = "اسم الموظف", DataPropertyName = "EmployeeName" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmployeeID", HeaderText = "رقم ", DataPropertyName = "EmployeeID" });

                        // ربط الجدول بالبيانات
                        dataGridView1.DataSource = table;

                    }
                    else
                    {
                       // MessageBox.Show("لا توجد بيانات في الجدول.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

=======
    namespace Dacto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Tiam.Text = DateTime.Now.ToString("yyy_MM-dd     hh:mm:ss");

        }
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
        private void TableFormatting()
        {
            dataGridView1.ScrollBars = ScrollBars.Both; // لتفعيل الشريطين الأفقي والرأسي
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            // ضبط عرض الأعمدة
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // تحسين التصميم
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // تصميم الرؤوس
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 50;

            // تحسين خطوط الصفوف
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // إخفاء الحدود الزائدة
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;



            // توسيط النص في جميع خلايا الجدول
<<<<<<< HEAD
           dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
=======
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004

            // توسيط النص في رؤوس الأعمدة
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

<<<<<<< HEAD
=======
            // تكبير عرض عمود "اسم الدكتور"
            dataGridView1.Columns["DoctorName"].Width = 150; // عرض أكبر (يمكنك تعديل الرقم حسب الحاجة)

            // تصغير عرض عمود "رقم"
            dataGridView1.Columns["ID"].Width = 40; // عرض أصغر (يمكنك تعديل الرقم حسب الحاجة)

            Tiam.Text = DateTime.Now.ToString("yyy_MM-dd     hh:mm:ss");

>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004


        }

<<<<<<< HEAD
        
        
        private void Form1_Load(object sender, EventArgs e)
        {    // الاتنسيقات
            LoadEmployees();
            //تنسياق الجدول 
            TableFormatting();
        }

  
       private void AddEmployee()
        {
            // دالة الاضافه
            // قراءة القيم من الحقول
            //  int ID = int.Parse(TextEmployeeID.Text);
            string employeeName = txtEmployeeName.Text; // اسم الموظف
                                                        // int age = int.Parse(txtAge.Text);
                                                        // string gender = !rdoMales.Checked?"أنثي":"ذكر"; // النو
            string departmentNumber = txtDepartmentNumber.Text; // رقم القسم
            string email = txtEmail.Text;             // البريد الإلكتروني
            string salary = txtSalary.Text;           // الراتب
            string address = txtAddress.Text;         // العنوان
            string phone = txtPhone.Text;             // رقم الهاتف
            string notes = txtNotes.Text;             // الملاحظات
            string gender;
            if (!rdoMales.Checked)
            {
                gender = "أنثى";
            }
            else
            {
                gender = "ذكر";
            }


            // سلسلة الاتصال
            //string connectionString = "Server=localhost;Port=3307;Database=employee_management;Uid=root;Pwd=;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            // string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //// إنشاء الاتصال
            // using (MySqlConnection connection = new MySqlConnection(connectionString))
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");


            try
            {
                con.Open();
                    // استعلام SQL للإضافة
                    string query = "INSERT INTO employees (EmployeeID,EmployeeName, Age, Gender, Address, PhoneNumber, Email, Salary, WorkDays, DepartmentID) VALUES (@EmployeeID,@EmployeeName, @Age, @Gender, @Address, @PhoneNumber, @Email, @Salary, @WorkDays, @DepartmentID)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // تمرير القيم إلى الاستعلام
                        int ID = int.Parse(TextEmployeeID.Text);
                        command.Parameters.AddWithValue("@EmployeeID", ID);//الرقم
                        command.Parameters.AddWithValue("@EmployeeName", employeeName); //اسم_الموظف
                        int age = int.Parse(txtAge.Text);
                        command.Parameters.AddWithValue("@Age", age);       // العمر
                        command.Parameters.AddWithValue("@Gender", gender); //النوع
                        command.Parameters.AddWithValue("@DepartmentID", departmentNumber); //رقم_القسم
                        command.Parameters.AddWithValue("@Email", email); //البريد_الإلكتروني
                        command.Parameters.AddWithValue("@Salary", salary); //الراتب
                        command.Parameters.AddWithValue("@Address", address);// العنوان
                        command.Parameters.AddWithValue("@PhoneNumber", phone);//رقم_الهاتف
                        command.Parameters.AddWithValue("@WorkDays", notes);  //الملاحظات

                        // تنفيذ الاستعلام
                        command.ExecuteNonQuery();

                        // إظهار رسالة نجاح
                        MessageBox.Show("تمت إضافة الموظف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //  MessageBox.Show($"Gender: {gender}");

                        // تحديث الجدول
                        LoadEmployees();
=======
        private void AddDoctors()
        {
            try
            {
                // قراءة القيم من الحقول
                string DoctorName = txtDoctorName.Text;
                string departmentNumber = txtDepartmentNumber.Text;
                string email = txtEmail.Text;
                string salary = txtSalary.Text;
                string address = txtAddress.Text;
                string phone = txtPhoneNumber.Text;
                string notes = txtNotes.Text;
                string WorkDay = txtWorkDays.Text;
                string Specialization = txtSpecialization.Text;
                string gender = rdoMale.Checked ? "ذكر" : "أنثى";

                // التحقق من إدخال القيم الإلزامية
                if (string.IsNullOrEmpty(txtNumberID.Text) || string.IsNullOrEmpty(txtAge.Text))
                {
                    MessageBox.Show("يرجى ملء جميع الحقول الإلزامية.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحويل القيم الرقمية
                int ID = int.Parse(txtNumberID.Text);
                int age = int.Parse(txtAge.Text);

                SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
                {
                    string query = @"INSERT INTO Doctors 
                            (ID, DoctorName, Age, Gender, Address, PhoneNumber, Email, Salary, WorkDays, DepartmentID, Specialization, Notes) 
                            VALUES 
                            (@ID, @DoctorName, @Age, @Gender, @Address, @PhoneNumber, @Email, @Salary, @WorkDays, @DepartmentID, @Specialization, @Notes)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@DoctorName", DoctorName);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@PhoneNumber", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.Parameters.AddWithValue("@WorkDays", WorkDay);
                        command.Parameters.AddWithValue("@DepartmentID", departmentNumber);
                        command.Parameters.AddWithValue("@Specialization", Specialization);
                        command.Parameters.AddWithValue("@Notes", notes);
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                        LoadAddDoctors(); // تحديث الجدول
                        MessageBox.Show("تمت إضافة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LoadAddDoctors()
        {// تتعمل معا الجدول 
         // string connectionString = "Server=localhost;Port=3307;Database=employee_management;Uid=root;Pwd=;";
         //using (MySqlConnection connection = new MySqlConnection(connectionString))

            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            // using (MySqlConnection connection = new MySqlConnection(connectionString))

            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");

            {
                try
                {
                    // connection.Open();

                    con.Open();
                    string query = "SELECT * FROM Doctors"; // استعلام جلب البيانات
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                        DataTable table = new DataTable();
                    adapter.Fill(table);

                    // التأكد من أن الجدول يحتوي على بيانات
                    if (table.Rows.Count > 0)
                    {
                        // إعداد الأعمدة يدويًا وترتيبها
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.Columns.Clear();

                        // إضافة الأعمدة مع الترتيب المطلوب
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Notes", HeaderText = "  الملاحظات  ", DataPropertyName = "Notes" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "WorkDays", HeaderText = " ايام العمل  ", DataPropertyName = "WorkDays" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "البريد ", DataPropertyName = "Email" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Specialization", HeaderText = " التخصص  ", DataPropertyName = "Specialization" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Salary", HeaderText = "الراتب", DataPropertyName = "Salary" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DepartmentID", HeaderText = "رقم القسم", DataPropertyName = "DepartmentID" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Gender", HeaderText = "النوع", DataPropertyName = "Gender" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PhoneNumber", HeaderText = "رقم الهاتف", DataPropertyName = "PhoneNumber" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", HeaderText = "العنوان", DataPropertyName = "Address" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Age", HeaderText = "العمر", DataPropertyName = "Age" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DoctorName", HeaderText = "اسم الدكتور", DataPropertyName = "DoctorName" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "رقم ", DataPropertyName = "ID" });

                        // ربط الجدول بالبيانات
                        dataGridView1.DataSource = table;

                        //// تكبير عرض عمود "اسم الدكتور"
                        //dataGridView1.Columns["DoctorName"].Width = 150; // عرض أكبر (يمكنك تعديل الرقم حسب الحاجة)

                        //// تصغير عرض عمود "رقم"
                        //dataGridView1.Columns["ID"].Width = 20; // عرض أصغر (يمكنك تعديل الرقم حسب الحاجة)
                    }
                    else
                    {
                      //  MessageBox.Show("لا توجد بيانات في الجدول.", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
                    }
                }
                catch (Exception ex)
                {
<<<<<<< HEAD
                    MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
=======
                    MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {    // زر الاضافه
            AddDoctors();
            // مسح الحقول بعد الإضافة
            ClearFields();
        }
        private void Form1_Load(object sender, EventArgs e)
        {   //  الاضافه الواجهة
            LoadAddDoctors();
            // التنسيقات حق الجدوال
            TableFormatting();
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004

        }


<<<<<<< HEAD
        private void button4_Click(object sender, EventArgs e)
        {    //زر الاضافه
            AddEmployee();
=======
        private void DeleteAllDoctors()
        {//دالة التفريغ 
         //  string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");

            //string connectionString = "Server=localhost;Port=3307;Database=employee_management;User ID=root;Password=;";

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات لحذفها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("هل أنت متأكد أنك تريد حذف جميع البيانات من الجدول؟",
                                                "تأكيد الحذف",
                                             MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            try
            {
                // اتصال قاعدة البيانات
                
                    con.Open();

                    // استعلام الحذف
                    string query = "DELETE FROM Doctors";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // تحديث DataGridView
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("تم حذف جميع البيانات من الجدول بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("لا توجد بيانات لحذفها في قاعدة البيانات!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"خطأ قاعدة البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {   //زر التفريغ
            DeleteAllDoctors();
        }

        private void UpdateDoctors()
        {  //  التعديل  الدالة
           //string gender;
           //if (rdoMales.Checked)
           //{
           //    gender = "ذكر";
           //}
           //else
           //{
           //    gender = "أنثى";
           //}
            string gender = rdoMale.Checked ? "ذكر" : "أنثى";



            if (string.IsNullOrWhiteSpace(txtNumberID.Text))
            {
                MessageBox.Show("يرجى تحديد موظف لتعديله!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
            {
                try
                {
                    con.Open();

                    string query = @"UPDATE Doctors 
                      SET DoctorName = @name, 
                          Age = @age, 
                          DepartmentID = @departmentId, 
                          Address = @address, 
                          PhoneNumber = @phone, 
                          Email = @email, 
                          Salary = @salary, 
                          WorkDays = @WorkDay,
                          Gender = @gender,
                      Specialization = @Specia,
                            Notes =@Notess
                      WHERE ID = @id";

                  

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", txtNumberID.Text);
                        command.Parameters.AddWithValue("@name", txtDoctorName.Text);
                        command.Parameters.AddWithValue("@age", txtAge.Text);
                        command.Parameters.AddWithValue("@departmentId", txtDepartmentNumber.Text);
                        command.Parameters.AddWithValue("@address", txtAddress.Text);
                        command.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@salary", txtSalary.Text);
                        command.Parameters.AddWithValue("@WorkDay", txtWorkDays.Text);
                        command.Parameters.AddWithValue("@gender", gender); // تمرير قيمة الجنس هنا
                        command.Parameters.AddWithValue("@Specia", txtSpecialization.Text);
                        command.Parameters.AddWithValue("@Notess", txtNotes.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("تم تعديل البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAddDoctors(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على الموظف لتحديثه!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"خطأ أثناء تعديل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {  // زر التعديل
            UpdateDoctors();
            // مسح الحقول بعد التعديل
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
            ClearFields();
        }


<<<<<<< HEAD
        private void DataGridViewRow(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0) // تحقق من أن هناك صفًا محددًا
            //{
            //    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

            //    TextEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
            //    txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
            //    //txtAge.Text = row.Cells["Age"].Value.ToString();
            //    rdoMale.Text = row.Cells["Gender"].Value.ToString();
            //    txtAddress.Text = row.Cells["Address"].Value.ToString();
            //    txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
            //    txtEmail.Text = row.Cells["Email"].Value.ToString();
            //    txtSalary.Text = row.Cells["Salary"].Value.ToString();
            //    txtNotes.Text = row.Cells["WorkDays"].Value.ToString();
            //    txtDepartmentNumber.Text = row.Cells["DepartmentID"].Value.ToString();

           // }
        }
            

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow(sender, e);
            dataGridVeW(e);


        }


        private void btnClearFromDBs()
        {  // دالة الحذف
             
            // تحقق إذا كان المستخدم قد أدخل رقم الموظف
            if (string.IsNullOrWhiteSpace(TextEmployeeID.Text))
            {
                MessageBox.Show("يرجى إدخال رقم الموظف لتفريغه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
=======
        private void btnClearFromDB()
        {  // دالة الحذف

            // تحقق إذا كان المستخدم قد أدخل رقم الموظف
            if (string.IsNullOrWhiteSpace(txtNumberID.Text))
            {
                MessageBox.Show("يرجى إدخال رقم الموظف لحذفه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
                return;
            }

            // الاتصال بقاعدة البيانات
<<<<<<< HEAD
            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");


=======
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
            {
                try
                {
                    con.Open();

                    // استعلام الحذف بناءً على EmployeeID
<<<<<<< HEAD
                    string query = "DELETE FROM employees WHERE EmployeeID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", TextEmployeeID.Text);
=======
                    string query = "DELETE FROM Doctors WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", txtNumberID.Text);
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004

                        // تنفيذ الاستعلام
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
<<<<<<< HEAD
                            MessageBox.Show("تم حذف بيانات الموظف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على الموظف لتفريغه!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
=======
                            MessageBox.Show("تم حذف بيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAddDoctors(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على  لحذف!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حذف البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

<<<<<<< HEAD

        
        private void btnClearFromDB_Click(object sender, EventArgs e)
        {     //زر الحذف
            btnClearFromDBs();
=======
        private void btnDelete_Click(object sender, EventArgs e)
        { // زر الحذف
            btnClearFromDB();
            // مسح الحقول بعد الحذف
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
            ClearFields();
        }

        private void SearchByName()
        {     //دالة البحث
            string searchQuery = txtSearch.Text.Trim(); // أخذ النص المدخل من TextBox

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
<<<<<<< HEAD
                MessageBox.Show("يرجى إدخال اسم الموظف للبحث!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))

=======
                MessageBox.Show("يرجى إدخال اسم الدكتور للبحث!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
            {
                try
                {
                    con.Open();

                    // الاستعلام للبحث عن الموظفين باستخدام الاسم
<<<<<<< HEAD
                    string query = "SELECT * FROM employees WHERE EmployeeName LIKE @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", "%" + searchQuery + "%");
=======
                    string query = "SELECT * FROM Doctors WHERE DoctorName LIKE @ID";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@ID", "%" + searchQuery + "%");
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable; // عرض النتائج في DataGridView
                            }
                            else
                            {
<<<<<<< HEAD
                                MessageBox.Show("لم يتم العثور على أي موظف بهذا الاسم.", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
=======
                                MessageBox.Show("لم يتم العثور على أي الموظف بهذا الاسم.", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
                                dataGridView1.DataSource = null;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"خطأ أثناء البحث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
<<<<<<< HEAD
         
        private void button5_Click(object sender, EventArgs e)
        {   // زر البحث
            SearchByName();
            ClearFields();
        }
=======

        private void btnSearch_Click(object sender, EventArgs e)
        {   //زر البحث
            SearchByName();
            // مسح الحقول بعد الإضافة
            ClearFields();
        }

>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
        private void SecondForm()
        {    // واجهة المعلومات
            // الاتصال بي الوجهة الثانيه
            // إنشاء كائن للنموذج الثاني
            SecondForm secondForm = new SecondForm();

            // إخفاء النموذج الحالي (اختياري)
            this.Hide();

            // عرض النموذج الجديد
            secondForm.ShowDialog();

            // إظهار النموذج الحالي مرة أخرى بعد إغلاق الثاني (اختياري)
            this.Show();
        }
<<<<<<< HEAD
        private void button3_Click(object sender, EventArgs e)
        {    // زر المعلومات

            SecondForm();

        }

=======

        private void button3_Click(object sender, EventArgs e)
        {  //  زر المعلومات
            SecondForm();
        }
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
        private void dataGridVeW(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // نتأكد أن السطر صحيح وليس رأس الجدول
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
<<<<<<< HEAD
                TextEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString() ?? "";
                txtEmployeeName.Text = row.Cells["EmployeeName"].Value?.ToString() ?? "";
                txtAge.Text = row.Cells["Age"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? "";
                txtDepartmentNumber.Text = row.Cells["DepartmentID"].Value?.ToString() ?? "";
                txtSalary.Text = row.Cells["Salary"].Value?.ToString() ?? "";
              //  txtSpecialization.Text = row.Cells["Specialization"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                //txtWorkDays.Text = row.Cells["WorkDays"].Value?.ToString() ?? "";
                txtNotes.Text = row.Cells["DepartmentID"].Value?.ToString() ?? "";

                string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                if (gender == "Male" || gender == "ذكر") // ممكن تضع القيمة اللي تناسبك
                    rdoMale.Visible = true;
=======
                txtNumberID.Text = row.Cells["ID"].Value?.ToString() ?? "";
                txtDoctorName.Text = row.Cells["DoctorName"].Value?.ToString() ?? "";
                txtAge.Text = row.Cells["Age"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? "";
                txtDepartmentNumber.Text = row.Cells["DepartmentID"].Value?.ToString() ?? "";
                txtSalary.Text = row.Cells["Salary"].Value?.ToString() ?? "";
                txtSpecialization.Text = row.Cells["Specialization"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtWorkDays.Text = row.Cells["WorkDays"].Value?.ToString() ?? "";
                txtNotes.Text = row.Cells["Notes"].Value?.ToString() ?? "";

                string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                if (gender == "Male" || gender == "ذكر") // ممكن تضع القيمة اللي تناسبك
                    rdoMale.Checked = true;
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
                else if (gender == "Female" || gender == "أنثى")
                    Checked.Checked = true;
                else
                {
<<<<<<< HEAD
                    rdoMale.Enabled = false;
=======
                    rdoMale.Checked = false;
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
                    Checked.Checked = false;
                }
            }

        }
<<<<<<< HEAD
=======
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {     //عند الضغط يتعي الصنديق  الذي تحت 
             dataGridVeW(e);

        }
>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004

        private void ClearFields()
        {// مسح الصنديق الذي تحت يم بعد اي عمليه عملتوه
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1; // إعادة القائمة إلى الوضع الافتراضي
                }
            }
            txtDepartmentNumber.Text = string.Empty; // تفريغ حقل الملاحظات
            txtDepartmentNumber.SelectedIndex = -1; // 
            txtNotes.Text = string.Empty; // تفريغ حقل الملاحظات
            txtDepartmentNumber.SelectedIndex = -1; // 

            // إعادة تعيين القيم الافتراضية إذا لزم الأمر
<<<<<<< HEAD
          
        }

    }
=======
            rdoMale.Checked = false; // مثال على إعادة تعيين أزرار الراديو
            Checked.Checked = false;
        }



    }

>>>>>>> 03ad57bdd424fdd7c91b73008c93f4d9b6541004
}
