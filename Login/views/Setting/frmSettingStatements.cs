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
    public partial class frmSettingStatements : Form
    {
        public frmSettingStatements()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.Setting.UpdateStatement(float.Parse(txtPrice.Text),(float) NumberKhasm.Value,(float) NumberTakhfizat.Value);
            MessageBox.Show("تمت عمية الحفظ بنجاح","تم حفظ",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void frmSettingStatements_Load(object sender, EventArgs e)
        {
            String[] arr = model.Setting.GetStatement();
            txtPrice.Text = arr[0];
            NumberKhasm.Value =Decimal.Parse( arr[1]);
            NumberTakhfizat.Value =Decimal.Parse( arr[2]);

        }
    }
}
