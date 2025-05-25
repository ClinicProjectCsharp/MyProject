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
    public partial class frmSettingBase : Form
    {
        public frmSettingBase()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmSettingBase_Load(object sender, EventArgs e)
        {
       String [] arr=     model.Setting.GetInfo();

            txtName.Text = arr[0];
            txtPhone.Text = arr[1];
            txtEmail.Text = arr[2];
            txtNumber.Text = arr[3];
            txtAddress.Text = arr[4];
            txtStart.Text = arr[5].Substring(0, arr[5].Length - 1);
            txtFinsh.Text = arr[6].Substring(0,arr[6].Length-1);
            if (arr[5].Substring(arr[5].Length - 1) == "ص")
            {
                cbStart.SelectedIndex = 0;
            }
            else
            {
                cbStart.SelectedIndex = 1;

            }
            if (arr[6].Substring(arr[6].Length - 1) == "ص")
            {
                cbFinsh.SelectedIndex = 0;
            }
            else
            {
                cbFinsh.SelectedIndex = 1;

            }




        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.Setting.UpdateInfo(txtName.Text, txtPhone.Text, txtEmail.Text, txtNumber.Text, txtAddress.Text, txtStart.Text + cbStart.SelectedItem.ToString(), txtFinsh.Text + cbFinsh.SelectedItem.ToString());
            MessageBox.Show("تم الحفظ بنجاح","تم الحفظ");
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
