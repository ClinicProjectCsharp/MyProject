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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            mnDepartment.Visible = false;
            mnEmployee.Visible = false;
            mnMoalgat.Visible = false;
            mnSetting.Visible = false;
            mnSick.Visible = false;
            mnUser.Visible = false;
       
            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnEmployees.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = false;
            Notification.Visible = false;
          
        }
        public frmHome(int a)
        {
            InitializeComponent();
    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void Loading(object sender, EventArgs e)
        {
            String[] arr = model.Users.GetInfoOfServeses(frmLoginScreen.Permission);
           bool d= arr[0] == "1" ? mnDepartment.Visible = true : mnDepartment.Visible = false;
           bool d1= arr[1] == "1" ? mnLogin.Visible = true : mnLogin.Visible = false;
            bool d2 = arr[2] == "1" ? mnEmployee.Visible = true : mnEmployee.Visible = false;
            bool d3 = arr[3] == "1" ? mnSick.Visible = true : mnSick.Visible = false;
            bool d4= arr[4] == "1" ? mnMoalgat.Visible = true : mnMoalgat.Visible = false;
            bool d5 = arr[5] == "1" ? mnUser.Visible = true : mnUser.Visible = false;
            bool d6 = arr[6] == "1" ? mnSetting.Visible = true : mnSetting.Visible = false;
            bool d9 = arr[9] == "1" ? Notification.Visible = true : Notification.Visible = false;

            mnDepartments.Visible = false;
     
            mnLogo.Visible = false;
            mnEmployees.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = false;
        }
       

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.frmLoginScreen f = new frmLoginScreen();
            f.NewDele += Loading;
            f.Show();
        }

        private void mnDepartment_Click(object sender, EventArgs e)
        {

            mnDepartments.Visible = true;
            mnLogo.Visible = false;
            mnEmployees.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = false;
        }

        private void mnLogin_Click(object sender, EventArgs e)
        {

            mnDepartments.Visible = false;
            mnLogo.Visible = true;
            mnEmployees.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = false;

        }

        private void تسجيلالدخولToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login.views.frmLoginScreen f = new frmLoginScreen();
            f.NewDele += Loading;
            f.Show();
        }

        private void mnEmployee_Click(object sender, EventArgs e)
        {
            mnEmployees.Visible = true;
            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnUsers.Visible = false;
        }

        private void mnSick_Click(object sender, EventArgs e)
        {
            mnEmployees.Visible = false;
            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnDiseases.Visible = true;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = false;
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
        DialogResult r=    MessageBox.Show("هل انت متاكد من عملية الخروج ", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void mnMoalgat_Click(object sender, EventArgs e)
        {
            mnEmployees.Visible = false;
            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = true;
            mnUsers.Visible = false;
            mnSettings.Visible = false;
        }

        private void mnUser_Click(object sender, EventArgs e)
        {
            mnEmployees.Visible = false;
            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = true;
            mnSettings.Visible = false;
        }

        private void mnSetting_Click(object sender, EventArgs e)
        {
            mnEmployees.Visible = false;
            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = true;
        }

        private void أضافةمستخدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.ViewUsers.frmUsers f = new ViewUsers.frmUsers();
            f.Show();

        }

        private void صلاحياتالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.ViewUsers.frmPermissions f = new ViewUsers.frmPermissions();
            f.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            pcMain.ImageLocation = model.Setting.GitPictureMain();
            String language = model.Setting.GetLanguage();
            if (language.Equals("Arabi"))
            {
                ChangeToArabiLanguage();
            }
            else
            {
                ChangeToEnglishLanguage();
            }
        }

        private void الدخولبمستخدماخرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnDepartment.Visible = false;
            mnEmployee.Visible = false;
            mnMoalgat.Visible = false;
            mnSetting.Visible = false;
            mnSick.Visible = false;
            mnUser.Visible = false;

            mnLogo.Visible = false;
            mnDepartments.Visible = false;
            mnEmployees.Visible = false;
            mnDiseases.Visible = false;
            mnMoalegats.Visible = false;
            mnUsers.Visible = false;
            mnSettings.Visible = false;
            Notification.Visible = false;
            Login.views.frmLoginScreen f = new frmLoginScreen();
            f.NewDele += Loading;
            f.ShowDialog();

        }

        private void المستخدمالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.ViewUsers.frmCurrentUser f = new ViewUsers.frmCurrentUser(model.Users.GetInfoOfServeses(model.Users.GetPerimissionOfUserNameAndPassword(frmLoginScreen.UserName,frmLoginScreen.Password)));
            f.Show();
        }

        private void الاعداداتالاساسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.Setting.frmSettingBase f = new Setting.frmSettingBase();
            f.Show();
        }

        public void UpdatePictureMain(object sender, EventArgs e)
        {
            pcMain.ImageLocation = model.Setting.GitPictureMain();
        }
        private void اعداداتالصوروالمضهرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.Setting.frmSettingImge f = new Setting.frmSettingImge();
            f.NewDele += UpdatePictureMain;
            f.Show();
        }

        private void اعداداتالكشوفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.Setting.frmSettingStatements f = new Setting.frmSettingStatements();
            f.Show();
        }





        public void ChangeToEnglishLanguage()
        {
          
     
            //mnMain.RightToLeft = RightToLeft.Yes;
       
            //mnMoalegats.RightToLeft = RightToLeft.No;
            //mnSettings.RightToLeft = RightToLeft.No;
            //mnUsers.RightToLeft = RightToLeft.No;
            //mnLogo.RightToLeft = RightToLeft.No;
            //mnEmployees.RightToLeft = RightToLeft.No;
            //mnDiseases.RightToLeft = RightToLeft.No;
            //mnDepartments.RightToLeft = RightToLeft.No;
            lbReport.Text = "Report";
            mnMoalgat.Text = "Treaments";
            mnDepartment.Text = "Department";
            mnLogin.Text = "Login";
            mnSetting.Text = "Setting";
            mnSick.Text = "Sick";
            mnEmployee.Text = "Employees";
            mnUser.Text = "Users";
            ////
            ///
            ManagerDepart.Text = "Manager Departments";
            Login.Text = "Login";
            Logout.Text = "Logout";
            ManagerDoctor.Text = " Doctor Management";
            ManagerEmployee.Text = " Employees Management";
            ManagerSick.Text = " Sick Management";
            ManagerMawaeed.Text = "Appointment Management";
            ManagerMoalegat.Text = "Processing Management";
            ManagerStatment.Text = "Statments Management";
            Users.Text = "Users";
            Perimision.Text = "Perimisson Management";
            CurrentUser.Text = "Current User";
            LogoOfAnutherUser.Text = "Sign Out";
            SettingBase.Text = "Basic Settings";
            SettingImge.Text = "Photo Settinga And Appearances";
            SettingStatments.Text = "Setting The Statments";
            SettingLanguage.Text = "Language Settings";
            backUp.Text = "Back Up";

        }
        public void ChangeToArabiLanguage()
        {
            mnMain.RightToLeft = RightToLeft.Yes;
            mnMoalegats.RightToLeft = RightToLeft.Yes;
            mnSettings.RightToLeft = RightToLeft.Yes;
            mnUsers.RightToLeft = RightToLeft.Yes;
            mnLogo.RightToLeft = RightToLeft.Yes;
            mnEmployees.RightToLeft = RightToLeft.Yes;
            mnDiseases.RightToLeft = RightToLeft.Yes;
            mnDepartments.RightToLeft = RightToLeft.Yes;
            lbReport.Text = "التقارير";
            mnMoalgat.Text = "المعالجات";
            mnDepartment.Text = "الاقسام";
            mnLogin.Text = "تسجيل الدخول";
            mnSetting.Text = "الاعدادات";
            mnSick.Text = "المرضئ";
            mnEmployee.Text = "الموضفين";
            mnUser.Text = "المستخدمين";
            ///

            ManagerDepart.Text = "ادارة الاقسام";
            Login.Text = "تسجيل الدخول";
            Logout.Text = "تسجيل الخروج";
            ManagerDoctor.Text = " ادارة الاطباء";
            ManagerEmployee.Text = " ادارة الموضفين";
            ManagerSick.Text = " ادارة المرضئ";
            ManagerMawaeed.Text = "ادارة المواعيد";
            ManagerMoalegat.Text = "ادارة المعالجات";
            ManagerStatment.Text = "الكشوفات الصحية";
            Users.Text = "المستخدمين";
            Perimision.Text = "ادارة الصلاحيات";
            CurrentUser.Text = "المستخدم الحالي";
            LogoOfAnutherUser.Text = "تسجيل بحساب اخر";
            SettingBase.Text = "الاعدادات الاساسية";
            SettingImge.Text = "اعدادات الصور والمضهر";
            SettingStatments.Text = "اعدادات الكشوفات";
            SettingLanguage.Text = "اعدادات اللغة";
            backUp.Text = "النسخ الاحتياطي";
        }

        private void اعداداتاللغةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.views.Setting.Form1 f = new Setting.Form1();
            f.NewDele += frmHome_Load;
            f.Show();
        }

        private void mnMain_DragDrop(object sender, DragEventArgs e)
        {
         
        }

        private void mnMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void النسخالاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            views.Setting.BackUpDatabase f = new Setting.BackUpDatabase();
            f.Show();
        }

        private void اعادةتعينكلمةالسرToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if(  MessageBox.Show("هل تريد مسح تذكرات كلمة السر جميعا"," مسح تذكر كلمة السر", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)==DialogResult.Yes){


                model.Setting.DeletePasswordRemember();

                MessageBox.Show("تم اعادة تعيين كلمات السر المحفوظة");

            }
        }

        private void ManagerDepart_Click(object sender, EventArgs e)
        {
            views.Department.frmDepartment f = new Department.frmDepartment();
            f.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            views.Notifications.frmNotification f = new Notifications.frmNotification();
            f.Show();
        }

        private void pcPoint_Click(object sender, EventArgs e)
        {
            views.Notifications.frmNotification f = new Notifications.frmNotification();
            f.Show();
        }

        private void ManagerEmployee_Click(object sender, EventArgs e)
        {
            views.Employee.frmEmployee f = new Employee.frmEmployee();
            f.Show();
        }

        private void ManagerSick_Click(object sender, EventArgs e)
        {
            views.ills.frmill f = new ills.frmill();
            f.Show();
        }

        private void ManagerMawaeed_Click(object sender, EventArgs e)
        {
            views.ills.frmMawaeed f = new ills.frmMawaeed();
            f.Show();
        }

        private void ManagerDoctor_Click(object sender, EventArgs e)
        {
            views.Employee.frmDoctor f = new Employee.frmDoctor();
            f.Show();
        }

        private void ManagerStatment_Click(object sender, EventArgs e)
        {
            Cashf f = new Cashf();
            f.Show();
        }

        private void ManagerMoalegat_Click(object sender, EventArgs e)
        {
            views.Moalegat.frmMoalegat f = new Moalegat.frmMoalegat();
            f.Show();
        }
    }
}
