using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.Login.views.ills
{
    public partial class frmill : Form
    {
        public frmill()
        {
            InitializeComponent();
        }



        private void AddDoctors()
        {
            try
            {
                // قراءة القيم من الحقول
                string Name = txtName.Text;
                string Date = txtDate.Text;
                string email = txtEmail.Text;
                string address = txtAddres.Text;
                string phone = txtPhoen.Text;
                string notes = txtNotes.Text;
                string gender = rdoMale.Checked ? "Male" : "Female";


                // التحقق من إدخال القيم الإلزامية
                if (string.IsNullOrEmpty(txtNum.Text) || string.IsNullOrEmpty(txtAge.Text))
                {
                    MessageBox.Show("يرجى ملء جميع الحقول الإلزامية.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحويل القيم الرقمية
                int ID = int.Parse(txtNum.Text);
                int age = int.Parse(txtAge.Text);

                // سلسلة الاتصال
                //  string connectionString = "Server=localhost;Port=3306;Database=PatientManagement;User ID=root;Password=root;";

                // using (MySqlConnection connection = new MySqlConnection(connectionString))
                SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen");

                {

                    // استعلام SQL للإضافة
                    string query = "INSERT INTO Patients (ID,PatientName,Age,Gender,Address,PhoneNumber,Email,Date,Notes) " +
                                   "VALUES (@ID,@PatientName,@Age,@Gender,@Address,@PhoneNumber,@Email,@Date,@Notes)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // تمرير القيم إلى الاستعلام
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@PatientName", Name);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@PhoneNumber", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@Notes", notes);
                        con.Open();
                        // تنفيذ الاستعلام
                        command.ExecuteNonQuery();
                        con.Close();
                        // تحديث البيانات في الجدول 
                        LoadAddDoctors();                        // إظهار رسالة نجاح
                        MessageBox.Show("تمت إضافة الدكتور بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAddDoctors()
        {// تتعمل معا الجدول 
         // string connectionString = "Server=localhost;Port=3307;Database=employee_management;Uid=root;Pwd=;";
         //using (MySqlConnection connection = new MySqlConnection(connectionString))

            //string connectionString = "Server=localhost;Port=3306;Database=employee_management;User ID=root;Password=root;";
            // using (MySqlConnection connection = new MySqlConnection(connectionString))

            SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen");

            {
                try
                {
                    // connection.Open();

                    con.Open();
                    string query = "SELECT * FROM Patients"; // استعلام جلب البيانات
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
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = " التاريخ   ", DataPropertyName = "Date" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "البريد ", DataPropertyName = "Email" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Gender", HeaderText = "النوع", DataPropertyName = "Gender" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PhoneNumber", HeaderText = "رقم الهاتف", DataPropertyName = "PhoneNumber" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", HeaderText = "العنوان", DataPropertyName = "Address" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Age", HeaderText = "العمر", DataPropertyName = "Age" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PatientName", HeaderText = "اسم المريض", DataPropertyName = "PatientName" });
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "الرقم ", DataPropertyName = "ID" });

                        // ربط الجدول بالبيانات
                        dataGridView1.DataSource = table;


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

        private void DeleteAllDoctors()
        {//دالة التفريغ 
            SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen");
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
                string query = "DELETE FROM Patients";

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
            catch (SqlException ex)
            {
                MessageBox.Show($"خطأ قاعدة البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateDoctors()
        {
            string gender = rdoMale.Checked ? "Male" : "Female";

            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("يرجى تحديد موظف لتعديله!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen"))
            {
                try
                {
                    con.Open();

                    string query = @"UPDATE Patients 
                             SET PatientName = @name, 
                                 Age = @age, 
                                 Address = @address, 
                                 PhoneNumber = @phone, 
                                 Email = @email, 
                                 Gender = @gender,
                                 Date = @date,
                                 Notes = @notes
                             WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // تمرير القيم من الحقول
                        command.Parameters.AddWithValue("@id", txtNum.Text);
                        command.Parameters.AddWithValue("@name", txtName.Text);
                        command.Parameters.AddWithValue("@age", int.TryParse(txtAge.Text, out var age) ? age : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@address", txtAddres.Text);
                        command.Parameters.AddWithValue("@phone", txtPhoen.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@date", DateTime.TryParse(txtDate.Text, out var date) ? date.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@notes", txtNotes.Text);

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
                catch (SqlException ex)
                {
                    MessageBox.Show($"خطأ أثناء تعديل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoungTabele()
        {     //هاذي تسبر الجدول

            // تخصيص الرأس
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                //    BackColor = Color.Navy,       // لون خلفية الرأس
                //    ForeColor = Color.White,      // لون النص في الرأس
                //    Font = new Font("Tahoma", 12, FontStyle.Bold), // الخط المستخدم في الرأس
                //    Alignment = DataGridViewContentAlignment.MiddleCenter // محاذاة النص في المنتصف

                BackColor = Color.Navy,
                ForeColor = Color.White,
                Font = new Font("Tahoma", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
        }

        private void btnClearFromDB()
        {  // دالة الحذف

            // تحقق إذا كان المستخدم قد أدخل رقم الموظف
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("يرجى إدخال رقم الموظف لحذفه!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // الاتصال بقاعدة البيانات
            SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen");
            {
                try
                {
                    con.Open();

                    // استعلام الحذف بناءً على EmployeeID
                    string query = "DELETE FROM Patients WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", txtNum.Text);

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
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حذف البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButAdd_Click_1(object sender, EventArgs e)
        {

            AddDoctors();


        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadAddDoctors();
            LoungTabele();

        }

        private void New_Click(object sender, EventArgs e)
        {
            DeleteAllDoctors();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDoctors();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnClearFromDB();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //    Form3 secondForm = new Form3();
            // secondForm.Show(); // لعرض النافذة الثانية
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            AddDoctors();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UpdateDoctors();
        }

        private void butRegs_Click(object sender, EventArgs e)
        {

        }

        private void New_Click_1(object sender, EventArgs e)
        {
            DeleteAllDoctors();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            {
                btnClearFromDB();
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmill_Load(object sender, EventArgs e)
        {
            LoadAddDoctors();
            LoungTabele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
