using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectCsharp.Login.views.Reports
{
    public partial class frmReportUser : Form
    {
        public frmReportUser()
        {
            InitializeComponent();
        }

        private void frmReportUser_Load(object sender, EventArgs e)
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            series.Points.AddXY("النشطين", 10);
            series.Points.AddXY("غير النشطين", 30);
            series.Points.AddXY("غير النشطين", 91);
            series.Points.AddXY("غير النشطين", 1);
            series.Points.AddXY("غير النشطين", 93);
            series.Points.AddXY("غير النشطين", 40);
            series.Points.AddXY("غير النشطين", 102);
            chart1.Series.Add(series);
            ///////
            Series series1 = new Series();
            series1.ChartType = SeriesChartType.Column;
            series1.Points.AddXY("النشطين", 10);
            series1.Points.AddXY("غير النشطين", 30);
            series1.Points.AddXY("غير النشطين", 91);
            series1.Points.AddXY("غير النشطين", 1);
            series1.Points.AddXY("غير النشطين", 93);
            series1.Points.AddXY("غير النشطين", 40);
            series1.Points.AddXY("غير النشطين", 102);
            chart2.Series.Add(series1);
            //////
            ///
         

        }
    }
}
