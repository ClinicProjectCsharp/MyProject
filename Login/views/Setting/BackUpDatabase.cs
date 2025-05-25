using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.Login.views.Setting
{
    public partial class BackUpDatabase : Form
    {
        public BackUpDatabase()
        {
            InitializeComponent();
        }
        String PathBackUp="";
        private void btnUpdateIcon_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "اختر مجلد";
            
            saveFileDialog1.FileName = "Database";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathBackUp = saveFileDialog1.FileName;
              

            }
        }
        String PathRestore="";
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "اختر ملف قاعدة بيانات";
            saveFileDialog1.DefaultExt = "bak";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All Files(*.*)|*.*";
          
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               PathRestore = openFileDialog1.FileName;


            }
            else
            {
                PathRestore = "";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PathRestore != "")
            {
                model.Setting.BackUp(PathRestore);
                MessageBox.Show("تم استعادة نسخه احتياطية بنجاح");
            }
            if (PathBackUp != "" )
            {
                model.Setting.BackUp(PathBackUp);
                MessageBox.Show("تم عمل نسخه احتياطية بنجاح");

            }
          
        }
    }
}
