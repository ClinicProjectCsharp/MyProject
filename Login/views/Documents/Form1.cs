using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Diagnostics;

using Xceed.Words.NET;

namespace ProjectCsharp.Login.views.Document
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void Report(String Name,String Icon,String Email,String Phone,String Address,List<String[]>data)
        {
            DataGridView dgv = new DataGridView();
           

            String FullPath = @"E:\SE3Level2\C#\First.docx";
            if (File.Exists(FullPath))
            {
                File.Delete(FullPath);

            }


            using (DocX document1 = DocX.Create(FullPath))
            {
                DateTime t = DateTime.Now;
               
                Color c = Color.Blue;
                var imge = document1.AddImage(Icon);
                var Picture = imge.CreatePicture(50, 50);
                document1.InsertParagraph("_______________________________________________________________________").Alignment = Xceed.Document.NET.Alignment.center;
                document1.InsertParagraph(" ").Alignment = Xceed.Document.NET.Alignment.center;

                document1.InsertParagraph().AppendPicture(Picture).Alignment = Xceed.Document.NET.Alignment.center;
                document1.InsertParagraph(Name).FontSize(25).Font("Arial").Alignment = Xceed.Document.NET.Alignment.center;
                document1.InsertParagraph(" العنون: " + Address + "                                          " + "التاريخ : " + t).FontSize(12).Font("Arial").Alignment = Xceed.Document.NET.Alignment.both;
                document1.InsertParagraph(" رقم الهاتف:"+ Phone + "                                          " + Email + " :البريد ").FontSize(12).Font("Arial").Alignment = Xceed.Document.NET.Alignment.both;
                document1.InsertParagraph("_______________________________________________________________________").Alignment = Xceed.Document.NET.Alignment.center;
                document1.InsertParagraph("تقرير بالمستخدمين في النضام").Bold().Alignment = Xceed.Document.NET.Alignment.center;
                document1.InsertParagraph(" ").Alignment = Xceed.Document.NET.Alignment.center;

                int rows = data.Count;
                int cols = data[0].Length;
                var table = document1.AddTable(rows, cols);
                table.Design = Xceed.Document.NET.TableDesign.LightShadingAccent1;


                for (int col = 0; col < cols; col++)
                {
                    table.Rows[0].Cells[col].Paragraphs[0].Append(data[0][col]).Bold();

                }

                for (int row = 0; row < rows-1; row++)
                {


                    for (int col = 0; col < cols; col++)
                    {
                        table.Rows[row+1].Cells[col].Paragraphs[0].Append(data[row+1][col]);

                    }
                }

                document1.InsertTable(table);
                document1.InsertParagraph("_______________________________________________________________________").Alignment = Xceed.Document.NET.Alignment.center;

                document1.Save();
                Process.Start(FullPath);



            }

        }
       
 private void button1_Click(object sender, EventArgs e)
        {
            String[] arr = model.Setting.GetInfo();
            String picture = model.Setting.GitPictureIcon();
            Report(arr[0], picture, arr[2],arr[1],arr[4],model.Users.GetUserToPrint() );


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
