using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.Login.views
{
    public partial class frmLoginScreen : Form
    {
        public static String UserName;
        public static String Password;
        public static String Name;

        public static int Permission;
        List<model.Users.Remember> m;
        AutoCompleteStringCollection users = new AutoCompleteStringCollection();
        public delegate void NewDelegete(object sender, EventArgs e);
        public event NewDelegete NewDele;
        public frmLoginScreen()
        {
            
            InitializeComponent();
            txtUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            m = model.Users.GetRemembers();


        }
       public void Enter(object sender, EventArgs e)
        {
           
            String[] temp = model.Users.GetUserNameAndPasswordAndActive(txtUserName.Text);
            if (temp[2] == "1" && temp[1].Equals(txtPassword.Text))
            {


                if (chRemember.Checked)
                {

                    foreach (model.Users.Remember r in m)
                    {

                        if (txtUserName.Text.ToUpper() == r.UserName.ToUpper() && txtPassword.Text.ToUpper() == r.Password.ToUpper())
                        {
                            UserName = txtUserName.Text;
                            Password = txtPassword.Text;
                            Name = model.Users.GetNameByUserNameAndPassword(UserName, Password);
                   Permission=      model.Users.GetPerimissionOfUserNameAndPassword(UserName, Password);
                            model.Users.AddNotification(model.Users.GetUserIDByUserName(txtUserName.Text, txtPassword.Text).ToString(), " بعملية تسجيل دخول " + txtUserName.Text + " :قام المستخدم", DateTime.Now);
                            NewDele?.Invoke(this, e);
                            this.Close();


                            return;
                        }

                    }
                    model.Users.AddRemember(txtUserName.Text, txtPassword.Text);
                    MessageBox.Show("تم حفظ عمليه تسجيل الدخول بنجاح");
                    UserName = txtUserName.Text;
                    Password = txtPassword.Text;
                    Name = model.Users.GetNameByUserNameAndPassword(UserName, Password);
                    Permission = model.Users.GetPerimissionOfUserNameAndPassword(UserName, Password);
                    model.Users.AddNotification(model.Users.GetUserIDByUserName(txtUserName.Text, txtPassword.Text).ToString(), " بعملية تسجيل دخول " + txtUserName.Text + " :قام المستخدم", DateTime.Now);

                    NewDele?.Invoke(this, e);
                    this.Close();

                }
                else
                {
                    UserName = txtUserName.Text;
                    Password = txtPassword.Text;
                    Name = model.Users.GetNameByUserNameAndPassword(UserName, Password);
                    Permission = model.Users.GetPerimissionOfUserNameAndPassword(UserName, Password);
                    model.Users.AddNotification(model.Users.GetUserIDByUserName(txtUserName.Text, txtPassword.Text).ToString(),  " بعملية تسجيل دخول " +txtUserName.Text+" :قام المستخدم",DateTime.Now);

                    NewDele?.Invoke(this, e);
                    this.Close();
                }
            }
            else
            {
                lbError.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Enter(sender,e);
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            pcLogin.ImageLocation = model.Setting.GitPictureLogin();

            txtUserName.Focus();
            List<model.Users.Remember> m = model.Users.GetRemembers();
            foreach (model.Users.Remember r in m)
            {
                users.Add(r.UserName);
            }


            txtUserName.AutoCompleteCustomSource = users;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            foreach (model.Users.Remember r in m)
            {

                if (txtUserName.Text.ToUpper() == r.UserName.ToUpper())
                {
                    txtPassword.Text = r.Password;
                }
            }

        }

        private void frmLoginScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pcPassword.Tag == "0")
            {
                pcPassword.Tag = "1";
                pcPassword.ImageLocation = "E:\\SE3Level2\\C#\\ProjectCsharp\\Login\\Picture\\eye.png";
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                pcPassword.Tag = "0";
                pcPassword.ImageLocation = "E:\\SE3Level2\\C#\\ProjectCsharp\\Login\\Picture\\invisible.png";
                txtPassword.PasswordChar = '*';
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login.views.Users.frmSendEmail f = new Users.frmSendEmail();
            f.Show();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void frmLoginScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                Enter(sender, e);
            }
        }
    }
}
