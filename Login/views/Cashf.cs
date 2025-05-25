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

namespace ProjectCsharp.Login.views
{
    public partial class Cashf : Form
    {
        SqlConnection connection = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen");

        public Cashf()
        {
            InitializeComponent();
        }


        //  تحميل البيانات إلى DataGridView
        private void LoadData()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"SELECT id, patient_name, doctor_name, examination_type, 
                                 ISNULL(examination_date, '') AS examination_date, 
                                 ISNULL(examination_time, '00:00:00') AS examination_time, 
                                 results, notes 
                                 FROM patients_examinations";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = null; // تأكد من إعادة تحميل البيانات بشكل نظيف
                dataGridView1.DataSource = dt;
                CustomizeGridView();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //  دالة إغلاق الاتصال بعد كل عملية
        private void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        //  دالة إضافة بيانات جديدة
        private void AddRecord()
        {
            if (!ValidateInputs()) return;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"INSERT INTO patients_examinations 
                                 (patient_name, doctor_name, examination_type, examination_date, examination_time, results, notes) 
                                 VALUES (@name, @doctor, @examination, @date, @time, @results, @notes)";



                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", txtPatient_name.Text);
                cmd.Parameters.AddWithValue("@doctor", cmbDoctor_name.Text);
                cmd.Parameters.AddWithValue("@examination", cmbexamination_type.Text);
                cmd.Parameters.AddWithValue("@date", cmbdateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@time", string.IsNullOrWhiteSpace(cmbExaminationtime.Text) ? (object)DBNull.Value : cmbExaminationtime.Text);
                cmd.Parameters.AddWithValue("@results", txtresults.Text);
                cmd.Parameters.AddWithValue("@notes", AreaNotes.Text);


                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("تمت الإضافة بنجاح!");
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("لم يتم إدخال أي بيانات!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الإضافة: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        //  دالة تعديل بيانات المريض
        private void UpdateRecord()
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("يجب تحديد صف لتعديله!");
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = @"UPDATE patients_examinations 
                                 SET patient_name=@name, doctor_name=@doctor, examination_type=@examination, 
                                     examination_date=@date, examination_time=@time, results=@results, notes=@notes 
                                 WHERE id=@id";


                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", txtnoumber.Text);
                cmd.Parameters.AddWithValue("@name", txtPatient_name.Text);
                cmd.Parameters.AddWithValue("@doctor", cmbDoctor_name.Text);
                cmd.Parameters.AddWithValue("@examination", cmbexamination_type.Text);
                cmd.Parameters.AddWithValue("@date", cmbdateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@time", string.IsNullOrWhiteSpace(cmbExaminationtime.Text) ? (object)DBNull.Value : cmbExaminationtime.Text);
                cmd.Parameters.AddWithValue("@results", txtresults.Text);
                cmd.Parameters.AddWithValue("@notes", AreaNotes.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("تم التعديل بنجاح!");
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("لم يتم تعديل أي بيانات!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء التعديل: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // ✅ دالة حذف مريض
        private void DeleteRecord()
        {
            if (string.IsNullOrWhiteSpace(txtnoumber.Text))
            {
                MessageBox.Show("يجب تحديد صف للحذف!");
                return;
            }

            DialogResult result = MessageBox.Show("هل تريد حذف هذا السجل؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "DELETE FROM patients_examinations WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", txtnoumber.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("تم الحذف بنجاح!");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الحذف: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }



        // ✅ التحقق من المدخلات (عدم ترك الحقول فارغة)
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPatient_name.Text) ||
                string.IsNullOrWhiteSpace(cmbexamination_type.Text) ||
                string.IsNullOrWhiteSpace(cmbDoctor_name.Text) ||
                string.IsNullOrWhiteSpace(txtresults.Text))
            {
                MessageBox.Show("يجب ملء جميع الحقول!");
                return false;
            }
            return true;
        }


        // ✅ تفريغ الحقول
        private void ClearFields()
        {
            txtnoumber.Clear();
            txtPatient_name.Clear();
            cmbDoctor_name.SelectedIndex = -1;
            cmbexamination_type.SelectedIndex = -1;
            cmbdateTimePicker1.Value = DateTime.Today;
            cmbExaminationtime.Clear();
            txtresults.Clear();
            AreaNotes.Clear();
        }


        ////////##########///////////


        //  دالة التحقق من تحديد صف
        private bool IsRowSelected()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("يجب تحديد صف!", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void SearchPatient(string searchText)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT * FROM  patients_examinations WHERE id LIKE @search OR patient_name LIKE @search";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // تحديث `DataGridView`
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                CustomizeGridView();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء البحث: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                MessageBox.Show($"تم اختيار الصف: {e.RowIndex}");

                txtnoumber.Text = row.Cells["id"].Value?.ToString() ?? "";
                txtPatient_name.Text = row.Cells["patient_name"].Value?.ToString() ?? "";
                cmbDoctor_name.Text = row.Cells["doctor_name"].Value?.ToString() ?? "";
                cmbexamination_type.Text = row.Cells["examination_type"].Value?.ToString() ?? "";
                txtresults.Text = row.Cells["results"].Value?.ToString() ?? "";
                AreaNotes.Text = row.Cells["notes"].Value?.ToString() ?? "";


                /*

                if (row.Cells["treatment_date"].Value != DBNull.Value && row.Cells["treatment_date"].Value != null)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["treatment_date"].Value);
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Today;
                }

                if (row.Cells["treatment_time"].Value != DBNull.Value && row.Cells["treatment_time"].Value != null)
                {
                    txtTimeProcess.Text = row.Cells["treatment_time"].Value.ToString();
                }
                else
                {
                    txtTimeProcess.Text = "";
                }
                */
            }
        }

        ///////###########///////////////////



        // دوال التحكم في جدول DataGridView



        private void CustomizeGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                // تغيير أسماء الأعمدة
                dataGridView1.Columns["id"].HeaderText = "رقم المريض";
                dataGridView1.Columns["patient_name"].HeaderText = "اسم المريض";
                dataGridView1.Columns["doctor_name"].HeaderText = "اسم الدكتور";
                dataGridView1.Columns["examination_type"].HeaderText = "نوع الفحص ";
                dataGridView1.Columns["examination_date"].HeaderText = "تاريخ الفحص ";
                dataGridView1.Columns["examination_time"].HeaderText = "وقت الفحص";
                dataGridView1.Columns["results"].HeaderText = "النتائج";
                dataGridView1.Columns["notes"].HeaderText = "الملاحظات";


                // تحديد عرض الأعمدة
                dataGridView1.Columns["id"].Width = 100;
                dataGridView1.Columns["patient_name"].Width = 150;
                dataGridView1.Columns["doctor_name"].Width = 150;
                dataGridView1.Columns["examination_type"].Width = 150;
                dataGridView1.Columns["examination_date"].Width = 120;
                dataGridView1.Columns["examination_time"].Width = 100;
                dataGridView1.Columns["results"].Width = 100;
                dataGridView1.Columns["notes"].Width = 200;

                // تثبيت أول عمود (عدم تحريكه عند التمرير)
                dataGridView1.Columns["id"].Frozen = true;
            }
        }


        private void StyleGridView()
        {
            // لون خلفية الجدول بالكامل
            dataGridView1.BackgroundColor = Color.LightGray;

            // لون رأس الأعمدة
            dataGridView1.EnableHeadersVisualStyles = false; // يسمح بتغيير اللون
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightCoral;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            // لون الصفوف بالتناوب (ألوان مختلفة لكل صف)
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // لون الصف العادي
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void FormatTextInGridView()
        {
            // تنسيق نصوص جميع الأعمدة
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
              col.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // محاذاة وسط
            }

            // تنسيق عمود معين (مثال: اسم المريض)
            dataGridView1.Columns["id"].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView1.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // محاذاة يمين
        }



        private void HighlightSelectedRow()
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue; // خلفية عند التحديد
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;     // لون النص عند التحديد
        }



        private void CustomizeGridViewAll()
        {
            CustomizeGridView();   // أسماء الأعمدة وأحجامها
            StyleGridView();       // الألوان والخلفيات
            FormatTextInGridView(); // تنسيق النصوص
            HighlightSelectedRow(); // تحديد لون الصف

        }


        //////###########//////////////////




        // دالة تفريغ الجدول بدون حذف العناوين
        private void ClearTable()
        {
          
        }

        private void btuAdd_Click(object sender, EventArgs e)
        {
         
        }

        private void btuUpData_Click(object sender, EventArgs e)
        {
          
        }

        private void btuDelete_Click(object sender, EventArgs e)
        {
       
        }

        private void btuDischarge_Click(object sender, EventArgs e)
        {
            ClearTable();
        }

        private void butsearch_Click(object sender, EventArgs e)
        {
          
            // CustomizeGridViewAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txttimedate.Text = DateTime.Now.ToString("yyyy_MM-dd     HH:mm:ss");
        }

        //  استدعاء تحميل البيانات عند فتح النموذج
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void frmMoalegat_Load(object sender, EventArgs e)
        {

            LoadData();
            CustomizeGridViewAll();
            txttimedate.Text = DateTime.Now.ToString("yyyy_MM-dd     HH:mm:ss");
        }

        private void btuAdd_Click_1(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btuUpData_Click_1(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void btuDelete_Click_1(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void btuDischarge_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                dt.Clear();
            }
        }

        private void btuInformation_Click(object sender, EventArgs e)
        {

        }

        private void butsearch_Click_1(object sender, EventArgs e)
        {
            SearchPatient(textsearch.Text);
        }

   
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                MessageBox.Show($"تم اختيار الصف: {e.RowIndex}");

                txtnoumber.Text = row.Cells["id"].Value?.ToString() ?? "";
                txtPatient_name.Text = row.Cells["patient_name"].Value?.ToString() ?? "";
                cmbDoctor_name.Text = row.Cells["doctor_name"].Value?.ToString() ?? "";
                cmbexamination_type.Text = row.Cells["examination_type"].Value?.ToString() ?? "";
                txtresults.Text = row.Cells["results"].Value?.ToString() ?? "";
                AreaNotes.Text = row.Cells["notes"].Value?.ToString() ?? "";


                /*

                if (row.Cells["treatment_date"].Value != DBNull.Value && row.Cells["treatment_date"].Value != null)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["treatment_date"].Value);
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Today;
                }

                if (row.Cells["treatment_time"].Value != DBNull.Value && row.Cells["treatment_time"].Value != null)
                {
                    txtTimeProcess.Text = row.Cells["treatment_time"].Value.ToString();
                }
                else
                {
                    txtTimeProcess.Text = "";
                }
                */
            }
        }
    }
}
