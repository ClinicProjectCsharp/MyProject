using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectCsharp.Login.views.Setting
{
    public partial class frmSettingImge : Form
    {

        String PathMain;
        String PathLogin;
        String PathIcon;
        String BeforePathMain;
        String BeforePathLogin;
        String BeforePathIcon;

        public delegate void NewDelegete(object sender, EventArgs e);
        public event NewDelegete NewDele;
        public frmSettingImge()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            openFileDialog3.Filter = "Imge Files (*.jpg;*png;*jpeg)|*.jpg;*png;*jpeg";
            openFileDialog3.Title = "اختر صورة";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                String SelectImgePath = openFileDialog3.FileName;
                String Directory = "E:\\SE3Level2\\C#\\ProjectCsharp\\MyPicture";

                String NewFileNew = Guid.NewGuid().ToString() + Path.GetExtension(SelectImgePath);
                String NewImgePath = Path.Combine(Directory, NewFileNew);
                pcIcon.ImageLocation = NewImgePath;
                PathIcon = NewImgePath;
                try
                {


                    File.Copy(SelectImgePath, NewImgePath);
                }
                catch (Exception)
                {


                }
            }
        }

     

        private void UpdateLoginClic(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Imge Files (*.jpg;*png;*jpeg)|*.jpg;*png;*jpeg";
            openFileDialog2.Title = "اختر صورة";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                String SelectImgePath = openFileDialog2.FileName;
                String Directory = "E:\\SE3Level2\\C#\\ProjectCsharp\\MyPicture";

                String NewFileNew = Guid.NewGuid().ToString() + Path.GetExtension(SelectImgePath);
                String NewImgePath = Path.Combine(Directory, NewFileNew);
                pcLogin.ImageLocation = NewImgePath;
                PathLogin = NewImgePath;
                try
                {


                    File.Copy(SelectImgePath, NewImgePath);
                }
                catch (Exception)
                {


                }
            }
        }

        private void UpdateMainScreenClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imge Files (*.jpg;*png;*jpeg)|*.jpg;*png;*jpeg";
            openFileDialog1.Title = "اختر صورة";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String SelectImgePath = openFileDialog1.FileName;
                String Directory = "E:\\SE3Level2\\C#\\ProjectCsharp\\MyPicture";

                String NewFileNew = Guid.NewGuid().ToString() + Path.GetExtension(SelectImgePath);
                String NewImgePath = Path.Combine(Directory, NewFileNew);
                pcMain.ImageLocation = NewImgePath;
                PathMain = NewImgePath;
               
                try
                {


                    File.Copy(SelectImgePath, NewImgePath);
                }catch(Exception )
                {


                }
            }

        }
        private void DeleteImgeFromFolder(String[] arr)
        {
           


        }
        private void frmSettingImge_Load(object sender, EventArgs e)
        {
       
                 BeforePathMain= model.Setting.GitPictureMain();
            pcMain.ImageLocation = BeforePathMain;
          
           BeforePathLogin= model.Setting.GitPictureLogin();
            pcLogin.ImageLocation = BeforePathLogin;
          
                BeforePathIcon= model.Setting.GitPictureIcon();
            pcIcon.ImageLocation = BeforePathIcon;
          PathIcon = pcIcon.ImageLocation;
            PathLogin = pcLogin.ImageLocation;
            PathMain = pcMain.ImageLocation;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BeforePathMain != PathMain)
            {
                File.Delete(BeforePathMain);
                model.Setting.UpdatePictureMain(PathMain);
            }
      if(BeforePathLogin!= PathLogin)
            {
                File.Delete(BeforePathLogin);

                model.Setting.UpdatePictureLogin(PathLogin);

            }
      if(BeforePathIcon!= PathIcon)
            {
                File.Delete(BeforePathIcon);

                model.Setting.UpdatePictureIcon(PathIcon);

            }
            MessageBox.Show("تم تحديث الصور بنجاح","‘UpdateImge",MessageBoxButtons.OK,MessageBoxIcon.Information);
            NewDele?.Invoke(this, e);
        }
    }
}
