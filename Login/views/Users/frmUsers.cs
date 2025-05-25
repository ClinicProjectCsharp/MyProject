using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDatabase;
namespace ProjectCsharp.Login.views.ViewUsers
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
           
            
            dgvUsers.DataSource = model.Users.GetUser().DataSource;
            cbPermission.Items.Clear();

            List<String> ee = model.Users.GetPermission();
          
            foreach (String d in ee)
            {
                cbPermission.Items.Add(d);
              
            

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvUsers.DataSource =model.Users.GetUserSearchByText(txtSearch.Text).DataSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        public void FillFields()
        {
            btnNumber.Text = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
            txtUserName.Text = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();
            txtPassword.Text = dgvUsers.SelectedRows[0].Cells[3].Value.ToString();
            String Active= dgvUsers.SelectedRows[0].Cells[4].Value.ToString();
            if (Active == "0")
            {
                rbNonActive.Checked=true;
            }
            else
            {
                rbActive.Checked = true;
            }
            txtEmail.Text= dgvUsers.SelectedRows[0].Cells[5].Value.ToString();
            cbPermission.Items.Clear();
           
            List<String> e = model.Users.GetPermission();
            int i = 0;
            foreach(String d in e)
            {
                cbPermission.Items.Add(d);
                if (d == dgvUsers.SelectedRows[0].Cells[6].Value.ToString())
                {
                    cbPermission.SelectedIndex = i;
                }
                i++;

            }
            PathImgeUser = model.Users.GetImgeUserByUserID(int.Parse(btnNumber.Text));
            pcImgeUser.ImageLocation = PathImgeUser;


        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
          
          
        


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnNumber.Text = "";
            txtName.Text = "";
            txtUserName.Text ="";
            txtPassword.Text = "";
            txtEmail.Text = "";
                rbNonActive.Checked = false;
           
                rbActive.Checked = false;
            
            
            cbPermission.SelectedIndex=-1;
            PathImgeUser = "E:\\SE3Level2\\C#\\ProjectCsharp\\ImgeUsers\\office-man (1).png";
            pcImgeUser.ImageLocation = PathImgeUser;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
    int PermissionID=model.Users.GetPermissionIDByName(cbPermission.SelectedItem.ToString());
            int active;
            if (rbActive.Checked)
            {
                active = 1;
            }
            else { active = 0; }
            model.Users.AddUser(txtName.Text, txtUserName.Text, txtPassword.Text, active, PermissionID, txtEmail.Text, PathImgeUser);
         //   MyDataBase b = new MyDataBase(".", "azadeenalsabai", "azadeen", "ClinicDatabase");
         //   String query = "insert into Users(Name,UserName,Password,Active,PermissionID,Email,Imge) values(@Name,@UserName,@Password,@Active,@PermissionID,@Email,@Imge)";
         //   Object[] values = { txtName.Text, txtUserName.Text, txtPassword.Text, active, PermissionID, txtEmail.Text, PathImgeUser };
         //if(  ! b.ExecuteNonQuery(query,values ))
          
         //   {
         //       MessageBox.Show("خطا", "Adding Successfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
         //       return;
         //   }
            MessageBox.Show("تمت عملية الاضافة بنجاح", "Adding Successfuly",MessageBoxButtons.OK,MessageBoxIcon.Information);
            dgvUsers.DataSource = model.Users.GetUser().DataSource;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int PermissionID = model.Users.GetPermissionIDByName(cbPermission.SelectedItem.ToString());
            int active;
            if (rbActive.Checked)
            {
                active = 1;
            }
            else { active = 0; }
            model.Users.UpdateUser(int.Parse( btnNumber.Text),txtName.Text, txtUserName.Text, txtPassword.Text, active, PermissionID,txtEmail.Text,PathImgeUser);
            MessageBox.Show("تمت عملية التعديل بنجاح", "Adding Successfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvUsers.DataSource = model.Users.GetUser().DataSource;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                model.Users.DeleteUser(int.Parse(btnNumber.Text));
                dgvUsers.DataSource = model.Users.GetUser().DataSource;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            String Active = dgvUsers.SelectedRows[0].Cells[4].Value.ToString();
            if (Active == "1")
            {
                Active = "Active";
            }
            else
            {
                Active = "NonActive";
            }
           
            Login.views.ViewUsers.UserDetail d = new UserDetail(int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString()),
               dgvUsers.SelectedRows[0].Cells[1].Value.ToString(), dgvUsers.SelectedRows[0].Cells[2].Value.ToString(),
               dgvUsers.SelectedRows[0].Cells[3].Value.ToString(),Active, dgvUsers.SelectedRows[0].Cells[5].Value.ToString(), dgvUsers.SelectedRows[0].Cells[6].Value.ToString(),model.Users.GetImgeUserByUserID(int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString())));
            d.Show();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                dgvUsers.DataSource = model.Users.GetUser().DataSource;
            }
            else if(cbFilter.SelectedIndex == 1)
            {
                dgvUsers.DataSource = model.Users.FilterByActive().DataSource;
            }
            else if(cbFilter.SelectedIndex == 2)
            {
                dgvUsers.DataSource = model.Users.FilterByNonActive().DataSource;

            }
        }

        private void dgvUsers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FillFields();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String[] arr = model.Setting.GetInfo();
            String picture = model.Setting.GitPictureIcon();
           model.clsPrint.Report(arr[0], picture, arr[2], arr[1], arr[4], model.Users.GetUserToPrint());

        }
        String PathImgeUser= "E:\\SE3Level2\\C#\\ProjectCsharp\\ImgeUsers\\office-man (1).png";
        private void btnPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imge Files (*.jpg;*png;*jpeg)|*.jpg;*png;*jpeg";
            openFileDialog1.Title = "اختر صورة";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String SelectImgePath = openFileDialog1.FileName;
                String Directory = "E:\\SE3Level2\\C#\\ProjectCsharp\\ImgeUsers";

                String NewFileNew = Guid.NewGuid().ToString() + Path.GetExtension(SelectImgePath);
                String NewImgePath = Path.Combine(Directory, NewFileNew);
                pcImgeUser.ImageLocation = NewImgePath;
                PathImgeUser = NewImgePath;

                try
                {


                    File.Copy(SelectImgePath, NewImgePath);
                }
                catch (Exception)
                {


                }
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
