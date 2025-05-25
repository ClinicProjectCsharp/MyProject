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
using System.Threading;

namespace ProjectCsharp.Login.views.Users
{
    public partial class frmSendEmail : Form
    {
        public frmSendEmail()
        {
            InitializeComponent();
        }
        int Code;
        private void button1_Click(object sender, EventArgs e)
        {
          if(!model.Users.IsEmail(txtEmail.Text))
            {
                MessageBox.Show("الايميل غير موجود بالنضام");
                return;
            }
           

            Random random = new Random();

            Code =random.Next(100000,999999);

            MailAddress from = new MailAddress("azadeenalsabai@gmail.com");


            MailAddress to = new MailAddress(txtEmail.Text);

            String Password = "ckmtsphecpbngajj";
            String Cod = Code.ToString();
            MailMessage message = new MailMessage(from, to);
            String Path = "E:\\SE3Level2\\C#\\SendEmail\\2019_11_22_3_18_23_300.jpg";
            Attachment a = new Attachment(Path);
            message.Attachments.Add(a);


            message.Subject = (" ** تحقق من البريد الإلكتروني لتغيير كلمة السر - عيادة الأسنان**");
            message.Body = "مرحباً ["+txtEmail.Text+" ]، \n" +
                " نأمل أن تكون بخير.  \n لقد تلقينا طلباً لتغيير كلمة السر الخاصة بحسابك في نظام إدارة عيادة الأسنان. لإكمال هذه العملية، يرجى استخدام رمز التحقق التالي:  \n" +
                "**رمز التحقق: [  "+Cod+ "]**  \n يرجى إدخال هذا الرمز في الصفحة المخصصة لتغيير كلمة السر. إذا لم تكن قد قمت بطلب تغيير كلمة السر، يرجى تجاهل هذه الرسالة أو التواصل معنا فوراً.  \n" +
                
"نحرص على حماية معلوماتك الشخصية، لذا لا تشارك هذا الرمز مع أي شخص.   \n" +
"شكراً لثقتك بنا، ونحن هنا لمساعدتك في أي استفسارات إضافية \n مع أطيب التحيات،  \n عزالدين عبدالسلام \n 776267578\n azadeenalsabai@gmail.com";
            SmtpClient stmp = new SmtpClient();
            stmp.Host = "smtp.gmail.com";

            stmp.Port = 587;
            stmp.Credentials = new NetworkCredential("azadeenalsabai@gmail.com", Password);
            stmp.EnableSsl = true;

            try
            {
               
                stmp.Send(message);
                pcLoading.Visible = false;

                MessageBox.Show("تم ارسال رمز التحقق بنجاح");
                btnCofing.Enabled = true;

                txtCheck.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("يرجي الاتصال بالانترنت");
                pcLoading.Visible = false;


            }




        }

        private void btnCofing_Click(object sender, EventArgs e)
        {
            if (txtCheck.Text.Equals(Code.ToString()))
            {


                frmChangePassword f = new frmChangePassword(txtEmail.Text);
                f.Show();
            }
            else
            {
                lbError.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pcLoading.Visible = true;
        }

        private void frmSendEmail_Load(object sender, EventArgs e)
        {

        }
    }
}
