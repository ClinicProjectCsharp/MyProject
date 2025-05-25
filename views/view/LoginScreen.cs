using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.Login.view
{
    public partial class LoginScreen : Form
    {
        List<model.Users.Remember> m;
        AutoCompleteStringCollection users = new AutoCompleteStringCollection();
        public LoginScreen()
        {
            InitializeComponent();
            txtUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;
         m = model.Users.GetRemembers();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //    MessageBox.Show("hi");
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
         List< model.Users.Remember> m= model.Users.GetRemembers();
            foreach(model.Users.Remember r in m)
            {
                users.Add(r.UserName);
            }


            txtUserName.AutoCompleteCustomSource = users;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            foreach (model.Users.Remember r in m)
            {
             
                if ( txtUserName.Text.ToUpper()==r.UserName.ToUpper())
                {
                    txtPassword.Text = r.Password;
                }
            }
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
      String[]temp= model.Users.GetUserNameAndPasswordAndActive(txtUserName.Text);
            if (temp[2]=="1" && temp[1].Equals(txtPassword.Text))
            {
                MessageBox.Show("Succeffuly");
                if (chRemember.Checked)
                {
                    foreach (model.Users.Remember r in m)
                    {

                        if (txtUserName.Text.ToUpper() == r.UserName.ToUpper() && txtPassword.Text.ToUpper() == r.Password.ToUpper())
                        {
                            return;
                        }

                    }
                    model.Users.AddRemember(txtUserName.Text, txtPassword.Text);
                    MessageBox.Show("تم حفظ عمليه تسجيل الدخول بنجاح");
                }
            }
            else
            {
                lbError.Visible = true;
            }

        }
    }
}
