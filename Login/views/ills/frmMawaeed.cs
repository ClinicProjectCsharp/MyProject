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
    public partial class frmMawaeed : Form
    {
        public frmMawaeed()
        {
            InitializeComponent();
        }



        private void LoadAddDoctors()
        {
            SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen");

            try
            {
                con.Open();
                string query = "SELECT ID, DoctorName, PatientName, ServiceType, CaseStatus, VisitDate, VisitTime, Notes FROM Visits";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // إعداد الأعمدة يدويًا
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                // إضافة الأعمدة مع الترتيب المطلوب
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Notes", HeaderText = "الملاحظات", DataPropertyName = "Notes" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PatientName", HeaderText = "اسم المريض", DataPropertyName = "PatientName" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "DoctorName", HeaderText = "اسم الدكتور", DataPropertyName = "DoctorName" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "VisitTime", HeaderText = "وقت الزيارة", DataPropertyName = "VisitTime" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "VisitDate", HeaderText = "تاريخ الزيارة", DataPropertyName = "VisitDate" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "CaseStatus", HeaderText = "وضع الحالة", DataPropertyName = "CaseStatus" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ServiceType", HeaderText = "نوع الخدمة", DataPropertyName = "ServiceType" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "الرقم", DataPropertyName = "ID" });

                // ربط البيانات بـ DataGridView
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
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


        private void Addappointm()
        {
            try
            {
                string type = txtTyeb.Text;
                string status = txtStat.Text;
                string visit_date = txtDate.Text;
                string visit_time = txtTime.Text;
                string doctor_name = comDoc.Text;
                string patient_name = comPri.Text;
                string Notes = txtNot.Text;

                if (string.IsNullOrEmpty(txtNum.Text))
                {
                    MessageBox.Show("يرجى ملء جميع الحقول الإلزامية.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int appointment_id;
                if (!int.TryParse(txtNum.Text, out appointment_id))
                {
                    MessageBox.Show("يرجى إدخال رقم معرف صحيح!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen"))
                {
                    con.Open();

                    string query = @"INSERT INTO Visits 
                            (ID, DoctorName, PatientName, ServiceType, CaseStatus, VisitDate, VisitTime, Notes)
                            VALUES 
                            (@ID, @DoctorName, @PatientName, @ServiceType, @CaseStatus, @VisitDate, @VisitTime, @Notes)";

                    using (SqlCommand cmds = new SqlCommand(query, con))
                    {
                        cmds.Parameters.AddWithValue("@ID", appointment_id);
                        cmds.Parameters.AddWithValue("@DoctorName", doctor_name);
                        cmds.Parameters.AddWithValue("@PatientName", patient_name);
                        cmds.Parameters.AddWithValue("@ServiceType", type);
                        cmds.Parameters.AddWithValue("@CaseStatus", status);
                        cmds.Parameters.AddWithValue("@VisitDate", visit_date);
                        cmds.Parameters.AddWithValue("@VisitTime", visit_time);
                        cmds.Parameters.AddWithValue("@Notes", Notes);

                        cmds.ExecuteNonQuery();
                        LoadAddDoctors(); // افترض أن هذه الدالة تقوم بتحديث واجهة المستخدم
                        MessageBox.Show("تمت إضافة الزيارة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAllDoctors()
        {
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

            using (SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen"))
            {
                try
                {
                    con.Open();

                    // استعلام الحذف
                    string query = "DELETE FROM Visits"; // تأكد من أن اسم الجدول صحيح

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // تحديث DataGridView
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
                            MessageBox.Show($"تم حذف جميع البيانات ({rowsAffected} صف) من الجدول بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }


        private void UpdateVisits()
        {
            // التحقق من أن الرقم معرف
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("يرجى تحديد الزيارة لتعديلها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // التحقق من أن اسم المريض والدكتور موجودان
            if (string.IsNullOrWhiteSpace(comPri.Text) || string.IsNullOrWhiteSpace(comDoc.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المريض واسم الدكتور!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen"))
            {
                try
                {
                    con.Open();

                    string query = @"UPDATE Visits 
                             SET DoctorName = @doctorName, 
                                 PatientName = @patientName, 
                                 ServiceType = @serviceType, 
                                 CaseStatus = @caseStatus, 
                                 VisitDate = @visitDate, 
                                 VisitTime = @visitTime, 
                                 Notes = @notes
                             WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // تمرير القيم من الحقول مع التحقق
                        command.Parameters.AddWithValue("@id", txtNum.Text);
                        command.Parameters.AddWithValue("@doctorName", comDoc.Text);
                        command.Parameters.AddWithValue("@patientName", comPri.Text);
                        command.Parameters.AddWithValue("@serviceType", string.IsNullOrWhiteSpace(txtTyeb.Text) ? (object)DBNull.Value : txtTyeb.Text);
                        command.Parameters.AddWithValue("@caseStatus", string.IsNullOrWhiteSpace(txtStat.Text) ? (object)DBNull.Value : txtStat.Text);
                        command.Parameters.AddWithValue("@visitDate", DateTime.TryParse(txtDate.Text, out DateTime visitDate) ? visitDate.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@visitTime", string.IsNullOrWhiteSpace(txtTime.Text) ? (object)DBNull.Value : txtTime.Text);
                        command.Parameters.AddWithValue("@notes", string.IsNullOrWhiteSpace(txtNot.Text) ? (object)DBNull.Value : txtNot.Text);

                        // تنفيذ الاستعلام
                        int rowsAffected = command.ExecuteNonQuery();

                        // التحقق من نتيجة التنفيذ
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("تم تعديل بيانات الزيارة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAddDoctors(); // تحديث بيانات DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على الزيارة لتحديثها!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"خطأ أثناء تعديل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnClearFromDB()
        {
            // تحقق إذا كان المستخدم قد أدخل رقم الزيارة
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("يرجى إدخال رقم الزيارة لحذفها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // الاتصال بقاعدة البيانات
            using (SqlConnection con = new SqlConnection("Server=.;Database=ClinicDatabase;User=azadeenalsabai;Password=azadeen"))
            {
                try
                {
                    con.Open();

                    // استعلام الحذف بناءً على ID
                    string query = "DELETE FROM Visits WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@id", txtNum.Text);

                        // تنفيذ الاستعلام
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("تم حذف بيانات الزيارة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAddDoctors(); // تحديث البيانات في DataGridView
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على الزيارة لحذفها!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حذف البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadAddDoctors();
            LoungTabele();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            Addappointm();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // LoadAddDoctors();
            // LoungTabele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteAllDoctors();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateVisits();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnClearFromDB();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void comPri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butReg2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtNot_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTyeb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void butAdd_Click_1(object sender, EventArgs e)
        {
            Addappointm();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UpdateVisits();
        }

        private void butReg2_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DeleteAllDoctors();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            btnClearFromDB();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void frmMawaeed_Load(object sender, EventArgs e)
        {

            LoadAddDoctors();
            LoungTabele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
