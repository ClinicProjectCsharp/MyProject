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
    public partial class Form1 : Form
    {
        AutoCompleteStringCollection users = new AutoCompleteStringCollection();
        public delegate void NewDelegete(object sender, EventArgs e);
        public event NewDelegete NewDele;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rba.Checked)
            {
                model.Setting.UpdateLanguage("Arabi");
            }
            else
            {
                model.Setting.UpdateLanguage("English");
            }
            //MessageBox.Show("تم تحديث اللغه بنجاح");
            NewDele?.Invoke(this, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String language = model.Setting.GetLanguage();
            if (language.Equals("Arabi"))
            {
                rba.Checked = true;
            }
            else
            {
                rbe.Checked = true;
            }
        }
    }
}
