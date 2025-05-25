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
           dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // توسيط النص في رؤوس الأعمدة
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }

        
        
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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }


        private void button4_Click(object sender, EventArgs e)
        {    //زر الاضافه
            AddEmployee();
            ClearFields();
        }


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
                return;
            }

            // الاتصال بقاعدة البيانات
            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");


            {
                try
                {
                    con.Open();

                    // استعلام الحذف بناءً على EmployeeID
                    string query = "DELETE FROM employees WHERE EmployeeID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", TextEmployeeID.Text);

                        // تنفيذ الاستعلام
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("تم حذف بيانات الموظف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على الموظف لتفريغه!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حذف البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        
        private void btnClearFromDB_Click(object sender, EventArgs e)
        {     //زر الحذف
            btnClearFromDBs();
            ClearFields();
        }

        private void SearchByName()
        {     //دالة البحث
            string searchQuery = txtSearch.Text.Trim(); // أخذ النص المدخل من TextBox

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("يرجى إدخال اسم الموظف للبحث!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))

            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
            {
                try
                {
                    con.Open();

                    // الاستعلام للبحث عن الموظفين باستخدام الاسم
                    string query = "SELECT * FROM employees WHERE EmployeeName LIKE @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", "%" + searchQuery + "%");

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
                                MessageBox.Show("لم يتم العثور على أي موظف بهذا الاسم.", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
         
        private void button5_Click(object sender, EventArgs e)
        {   // زر البحث
            SearchByName();
            ClearFields();
        }
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
        private void button3_Click(object sender, EventArgs e)
        {    // زر المعلومات

            SecondForm();

        }

        private void dataGridVeW(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // نتأكد أن السطر صحيح وليس رأس الجدول
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
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
                else if (gender == "Female" || gender == "أنثى")
                    Checked.Checked = true;
                else
                {
                    rdoMale.Enabled = false;
                    Checked.Checked = false;
                }
            }

        }

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
          
        }

    }
}
