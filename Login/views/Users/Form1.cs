using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace ProjectCsharp.Login.views.Users
{
    public partial class frmChangePassword : Form
    { String Email;
        public frmChangePassword(String Email)
        {
            InitializeComponent();
            this.Email = Email;
        }


        public Boolean SendEmail()
        {


       

            MailAddress from = new MailAddress("azadeenalsabai@gmail.com");


            MailAddress to = new MailAddress(Email);

            String Password = "ckmtsphecpbngajj";
            
            MailMessage message = new MailMessage(from, to);
            String Path = "E:\\SE3Level2\\C#\\SendEmail\\6325247.jpg";
            Attachment a = new Attachment(Path);
            message.Attachments.Add(a);

            message.Subject = ("**تأكيد تغيير كلمة السر - عيادة الأسنان**");
            message.Body = "مرحباً ["+Email+"]، \n" +
                " نأمل أن تكون بخير.  \n نود إعلامك بأنه تم تغيير كلمة السر الخاصة بحسابك في نظام إدارة عيادة الأسنان بنجاح. إذا كنت أنت من قمت بهذا التغيير، فلا داعي لاتخاذ أي إجراء آخر.   \n" +
                "إذا لم تقم بتغيير كلمة السر، يرجى التواصل معنا فوراً على البريد الإلكتروني [  azadeenalsabai@gmail.com] أو الاتصال بنا على الرقم [ 776267578] لتأمين حسابك.      \n" +

"شكراً لثقتك بنا، ونحن هنا لمساعدتك في أي وقت.    \n" +
"مع أطيب التحيات،  \n عزالدين عبدالسلام \n 776267578\n azadeenalsabai@gmail.com";
            SmtpClient stmp = new SmtpClient();
            stmp.Host = "smtp.gmail.com";

            stmp.Port = 587;
            stmp.Credentials = new NetworkCredential("azadeenalsabai@gmail.com", Password);
            stmp.EnableSsl = true;

            try
            {
                stmp.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("يرجي الاتصال بالانترنت");
                return false;
            }


        }
        private void btnCHange_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(txtCofigPassword.Text))
            {
                if (SendEmail())
                {
                    model.Users.ChangePasswordByEmail(Email, txtPassword.Text);
                    MessageBox.Show("تم تغيير كلمة السر بنجاح");
                    frmLoginScreen f = new frmLoginScreen();
                    f.Show();

                }

            }
            else
            {
                lbError.Visible = true;
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
