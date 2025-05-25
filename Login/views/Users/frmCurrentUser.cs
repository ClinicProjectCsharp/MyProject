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
    public partial class frmCurrentUser : Form
    {
        String[] arr = new String[9];
        public frmCurrentUser(String []arr)
        {
            InitializeComponent();
            this.arr = arr;
        }

        private void frmCurrentUser_Load(object sender, EventArgs e)
        {
            lbName.Text = frmLoginScreen.Name;
            lbUserName.Text = frmLoginScreen.UserName;
            lbPassword.Text = frmLoginScreen.Password;
            pcUser.ImageLocation = model.Users.GetImgeUserByUserID(model.Users.GetUserIDByUserName(frmLoginScreen.UserName, frmLoginScreen.Password));
            if (arr[0] == "1")
            {
                lbDepartment.Text = "نعم";
                lbDepartment.ForeColor = Color.Green;
            }
            else {
                lbDepartment.Text = "لا";
                lbDepartment.ForeColor = Color.Red;
            }
            if (arr[1] == "1")
            {
                lbLogin.Text = "نعم";
                lbLogin.ForeColor = Color.Green;
            }
            else
            {
                lbLogin.Text = "لا";
                lbLogin.ForeColor = Color.Red;
            }
            if (arr[2] == "1")
            {
                lbEmployee.Text = "نعم";
                lbEmployee.ForeColor = Color.Green;
            }
            else
            {
                lbEmployee.Text = "لا";
                lbEmployee.ForeColor = Color.Red;
            }
            if (arr[3] == "1")
            {
                lbSick.Text = "نعم";
                lbSick.ForeColor = Color.Green;
            }
            else
            {
                lbSick.Text = "لا";
                lbSick.ForeColor = Color.Red;
            }


            if (arr[4] == "1")
            {
                lbMoalegat.Text = "نعم";
                lbMoalegat.ForeColor = Color.Green;
            }
            else
            {
                lbMoalegat.Text = "لا";
                lbMoalegat.ForeColor = Color.Red;
            }

            if (arr[5] == "1")
            {
                lbUsers.Text = "نعم";
                lbUsers.ForeColor = Color.Green;
            }
            else
            {
                lbUsers.Text = "لا";
                lbUsers.ForeColor = Color.Red;
            }

            if (arr[6] == "1")
            {
                lbSetting.Text = "نعم";
                lbSetting.ForeColor = Color.Green;
            }
            else
            {
                lbSetting.Text = "لا";
                lbSetting.ForeColor = Color.Red;
            }

            if (arr[7] == "1")
            {
                lbAnalyst.Text = "نعم";
                lbAnalyst.ForeColor = Color.Green;
            }
            else
            {
                lbAnalyst.Text = "لا";
                lbAnalyst.ForeColor = Color.Red;
            }
            if (arr[8] == "1")
            {
                lbReport.Text = "نعم";
                lbReport.ForeColor = Color.Green;
            }
            else
            {
                lbReport.Text = "لا";
                lbReport.ForeColor = Color.Red;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
