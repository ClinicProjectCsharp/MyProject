using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.Login.views.ViewUsers
{
    public partial class frmPermissions : Form
    {
        public frmPermissions()
        {
            InitializeComponent();
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {
           
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked)
            {
                gbPrimission.Enabled = false;
            }
            else
            {
                gbPrimission.Enabled = true;
            }
        }

     
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int[] Array = new int[10];
            if (chbDepartment.Checked)
            {
                Array[0] = 1;
            }
            else
            {
                Array[0] = 0;

            }
            if (chbLogin.Checked)
            {
                Array[1] = 1;
            }
            else
            {
                Array[1] = 0;

            }
            if (chbEmployee.Checked)
            {
                Array[2] = 1;
            }
            else
            {
                Array[2] = 0;

            }

            if (chbSick.Checked)
            {
                Array[3] = 1;
            }
            else
            {
                Array[3] = 0;

            }
            if (chbMoalegat.Checked)
            {
                Array[4] = 1;
            }
            else
            {
                Array[4] = 0;

            }

            if (chbUsers.Checked)
            {
                Array[5] = 1;
            }
            else
            {
                Array[5] = 0;

            }


            if (chbSetting.Checked)
            {
                Array[6] = 1;
            }
            else
            {
                Array[6] = 0;

            }
            if (chbAnalyst.Checked)
            {
                Array[7] = 1;
            }
            else
            {
                Array[7] = 0;

            }
            if (chbReport.Checked)
            {
                Array[8] = 1;
            }
            else
            {
                Array[8] = 0;

            }
            if (chNotification.Checked)
            {
                Array[9] = 1;
            }
            else
            {
                Array[9] = 0;

            }
            if (chbAll.Checked)
            {
                int[] a = { 1, 1, 1, 1, 1, 1, 1, 1, 1,1 };
             if(   model.Users.AddPerimission(txtName.Text, txtDetail.Text))
                {
                    model.Users.AddPerimissionAndServeces(model.Users.GetPermissionIDByName(txtName.Text), a);
                    dgvPerimission.DataSource = model.Users.GetPerimissons().DataSource;
                }
                else
                {
                    MessageBox.Show("الصلاحية موجودة من قبل");
                }
               
            }
            else
            {
           if(model.Users.AddPerimission(txtName.Text, txtDetail.Text))
                {

                    model.Users.AddPerimissionAndServeces(model.Users.GetPermissionIDByName(txtName.Text), Array);

                    MessageBox.Show("تم اضافة الصلاحية بنجاح", " نجاح اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPerimission.DataSource = model.Users.GetPerimissons().DataSource;

                }
                else
                {
                    MessageBox.Show("الصلاحية موجودة من قبل");
                    return;
                }
            }


        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            dgvPerimission.DataSource = model.Users.GetPerimissons().DataSource;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvPerimission.DataSource = model.Users.GetPerimissonsOfSearch(txtSearch.Text).DataSource;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            btnNumber.Text = "";
            txtName.Text = "";
            txtDetail.Text = "";
            chbAll.Checked = false;
            chbAnalyst.Checked = false;
            chbDepartment.Checked = false;
            chbEmployee.Checked = false;
            chbLogin.Checked = false;
            chbReport.Checked = false;
            chbSetting.Checked = false;
            chbSick.Checked = false;
            chbMoalegat.Checked = false;
            chbUsers.Checked = false;
            chNotification.Checked = false;

        }

        private void dgvPerimission_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String[] arrInfo = model.Users.GetInfoOfPermission(int.Parse(dgvPerimission.SelectedRows[0].Cells[0].Value.ToString()));
            String[] arrServeses = model.Users.GetInfoOfServeses(int.Parse(dgvPerimission.SelectedRows[0].Cells[0].Value.ToString()));
            btnNumber.Text = arrInfo[0];
            txtName.Text = arrInfo[1];
            txtDetail.Text = arrInfo[2];
         bool b1=  ( arrServeses[0] == "1") ? chbDepartment.Checked = true : chbDepartment.Checked = false;
         bool b2=  ( arrServeses[1] == "1") ? chbLogin.Checked = true : chbLogin.Checked = false;
         bool b3= ( arrServeses[2] == "1") ? chbEmployee.Checked = true : chbEmployee.Checked = false;
         bool b4=  ( arrServeses[3] == "1") ? chbSick.Checked = true : chbSick.Checked = false;
         bool b5=  ( arrServeses[4] == "1") ? chbMoalegat.Checked = true : chbMoalegat.Checked = false;
         bool b6=  ( arrServeses[5] == "1") ? chbUsers.Checked = true : chbUsers.Checked = false;
         bool b7=  ( arrServeses[6] == "1") ? chbSetting.Checked = true : chbSetting.Checked = false;
         bool b8=  ( arrServeses[7] == "1") ? chbAnalyst.Checked = true : chbAnalyst.Checked = false;
         bool b9 = (arrServeses[8] == "1") ? chbReport.Checked = true : chbReport.Checked = false;
         bool b10 = (arrServeses[9] == "1") ? chNotification.Checked = true : chNotification.Checked = false;





        }

        private void dgvPerimission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int[] Array = new int[10];
            if (chbDepartment.Checked)
            {
                Array[0] = 1;
            }
            else
            {
                Array[0] = 0;

            }
            if (chbLogin.Checked)
            {
                Array[1] = 1;
            }
            else
            {
                Array[1] = 0;

            }
            if (chbEmployee.Checked)
            {
                Array[2] = 1;
            }
            else
            {
                Array[2] = 0;

            }

            if (chbSick.Checked)
            {
                Array[3] = 1;
            }
            else
            {
                Array[3] = 0;

            }
            if (chbMoalegat.Checked)
            {
                Array[4] = 1;
            }
            else
            {
                Array[4] = 0;

            }

            if (chbUsers.Checked)
            {
                Array[5] = 1;
            }
            else
            {
                Array[5] = 0;

            }


            if (chbSetting.Checked)
            {
                Array[6] = 1;
            }
            else
            {
                Array[6] = 0;

            }
            if (chbAnalyst.Checked)
            {
                Array[7] = 1;
            }
            else
            {
                Array[7] = 0;

            }
            if (chbReport.Checked)
            {
                Array[8] = 1;
            }
            else
            {
                Array[8] = 0;

            }
            if (chNotification.Checked)
            {
                Array[9] = 1;
            }
            else
            {
                Array[9] = 0;

            }
            if (chbAll.Checked)
            {
               for(int i = 0; i <= 9; i++)
                {
                    Array[i] = 1;
                }
            }
            if (model.Users.UpdatePerimisiion(int.Parse(btnNumber.Text), txtName.Text, txtDetail.Text)){
                int []arr = model.Users.GetIndexofServesesAndPermission(int.Parse(btnNumber.Text));
                for(int i = 0; i <= 9; i++)
                {

       model.Users.UpdatePerimissionAndServeces(int.Parse(btnNumber.Text), Array[i], arr[i]);
                }
                MessageBox.Show("تم التعديل بنجاح");
                dgvPerimission.DataSource = model.Users.GetPerimissons().DataSource;

            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                model.Users.DeletePerimission(int.Parse(btnNumber.Text));
                MessageBox.Show("تم الحذف بنجاح", "نجاح الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPerimission.DataSource = model.Users.GetPerimissons().DataSource;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            String []arr = new string[9];
            String []arr2 = new string[3];

            arr2[0] = dgvPerimission.SelectedRows[0].Cells[0].Value.ToString();
            arr = model.Users.GetInfoOfServeses(int.Parse(arr2[0]));

            arr2[1] = dgvPerimission.SelectedRows[0].Cells[1].Value.ToString();
            arr2[2] = dgvPerimission.SelectedRows[0].Cells[2].Value.ToString();
            Login.views.Setting.frmDetailPerimission f = new Setting.frmDetailPerimission(arr,arr2);
            f.Show();

        }
    }
}
