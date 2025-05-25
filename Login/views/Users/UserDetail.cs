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
    public partial class UserDetail : Form
    {
        public UserDetail(int Number,String Name,String UserName,String Password,String Active,String Email,String Perission,String Imge)
        {
            InitializeComponent();
            lbNumber.Text = Number.ToString();
            lbName.Text = Name;
            button1.Text = Name;
            lbUserName.Text = UserName;
            lbPassword.Text = Password;
            lbPermission.Text = Perission;
            lbEmail.Text = Email;
            if (Active.Equals( "Active"))
            {
                lbActive.Text = "نشط";
                lbActive.ForeColor = Color.Green;
            }
            else
            {
                lbActive.Text = "غير نشط";
                lbActive.ForeColor = Color.Red;
            }
            pcUser.ImageLocation = Imge;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
