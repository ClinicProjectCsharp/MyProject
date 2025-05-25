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
    namespace Dacto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Tiam.Text = DateTime.Now.ToString("yyy_MM-dd     hh:mm:ss");

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

            // تكبير عرض عمود "اسم الدكتور"
            dataGridView1.Columns["DoctorName"].Width = 150; // عرض أكبر (يمكنك تعديل الرقم حسب الحاجة)

            // تصغير عرض عمود "رقم"
            dataGridView1.Columns["ID"].Width = 40; // عرض أصغر (يمكنك تعديل الرقم حسب الحاجة)

            Tiam.Text = DateTime.Now.ToString("yyy_MM-dd     hh:mm:ss");



        }

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
                    }
                }
                catch (Exception ex)
                {
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

        }


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
            ClearFields();
        }


        private void btnClearFromDB()
        {  // دالة الحذف

            // تحقق إذا كان المستخدم قد أدخل رقم الموظف
            if (string.IsNullOrWhiteSpace(txtNumberID.Text))
            {
                MessageBox.Show("يرجى إدخال رقم الموظف لحذفه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // الاتصال بقاعدة البيانات
            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
            {
                try
                {
                    con.Open();

                    // استعلام الحذف بناءً على EmployeeID
                    string query = "DELETE FROM Doctors WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", txtNumberID.Text);

                        // تنفيذ الاستعلام
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("تم حذف بيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAddDoctors(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على  لحذف!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حذف البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        { // زر الحذف
            btnClearFromDB();
            // مسح الحقول بعد الحذف
            ClearFields();
        }

        private void SearchByName()
        {     //دالة البحث
            string searchQuery = txtSearch.Text.Trim(); // أخذ النص المدخل من TextBox

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("يرجى إدخال اسم الدكتور للبحث!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection("Server=.;Database=employee_management;Integrated Security=True;");
            {
                try
                {
                    con.Open();

                    // الاستعلام للبحث عن الموظفين باستخدام الاسم
                    string query = "SELECT * FROM Doctors WHERE DoctorName LIKE @ID";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@ID", "%" + searchQuery + "%");

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
                                MessageBox.Show("لم يتم العثور على أي الموظف بهذا الاسم.", "نتيجة البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {   //زر البحث
            SearchByName();
            // مسح الحقول بعد الإضافة
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
        {  //  زر المعلومات
            SecondForm();
        }
        private void dataGridVeW(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // نتأكد أن السطر صحيح وليس رأس الجدول
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
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
                else if (gender == "Female" || gender == "أنثى")
                    Checked.Checked = true;
                else
                {
                    rdoMale.Checked = false;
                    Checked.Checked = false;
                }
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {     //عند الضغط يتعي الصنديق  الذي تحت 
             dataGridVeW(e);

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
            rdoMale.Checked = false; // مثال على إعادة تعيين أزرار الراديو
            Checked.Checked = false;
        }



    }

}
