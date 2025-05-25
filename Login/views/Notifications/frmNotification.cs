using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCsharp.Login.views.Notifications
{
    public partial class frmNotification : Form
    {
        Panel MainPanal = new Panel();
        TableLayoutPanel Notifications = new TableLayoutPanel();
        public frmNotification()
        {
            InitializeComponent();

           
            this.Controls.Add(MainPanal);
            Notifications.AutoScroll = false;
            Notifications.AutoSize = true;
            Notifications.ColumnCount = 1;
            Notifications.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            MainPanal.Controls.Add(Notifications);
            MainPanal.AutoSize = true;
            MainPanal.AutoScroll = true;
            Loading();
        }
        public void PrintCardNotification()
        {
           

        }
        public void AddNotification(TableLayoutPanel tempNotifications,String tempImge,String Detail,String tempDateTime,String tempTime,String ActiveTime,String ID,String Activ)
        {
            TableLayoutPanel Card = new TableLayoutPanel();
           
            Card.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            if (Activ == "0")
            {
                Card.BackColor = Color.LightBlue;
            }
            else
            {
                Card.BackColor = Color.White;

            }
            Card.Tag = ID;
            Card.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            Card.Dock = DockStyle.Fill;
            Card.MouseClick += (sender, e) =>
            {
                
                int NotificationID = int.Parse(((Control)sender).Tag.ToString());
                String[] temp = model.Users.GetNotificationsByID(NotificationID);
                if (temp[4] == "0")
                {
                    model.Users.UpdateNotification(NotificationID);
                    ((Control)sender).BackColor = Color.White;
                  
                    return;
                }
                else {
                    return;
                }
            };
            Card.ColumnCount = 2;
            Card.RowCount = 2;
            Card.Width = 550;
            Card.Height=110;
            Card.Margin = new Padding(10);
            PictureBox imge = new PictureBox();
            imge.Image = Image.FromFile(tempImge);
            imge.Tag = ID;
            imge.MouseClick += (sender, e) =>
            {

                int NotificationID = int.Parse(((Control)sender).Tag.ToString());
                String[] temp = model.Users.GetNotificationsByID(NotificationID);
                if (temp[4] == "0")
                {
                    model.Users.UpdateNotification(NotificationID);
                    if (((Control)sender).Parent is TableLayoutPanel Parent)
                    {
                        Parent.BackColor = Color.White;
                    }
                    return;
                }
                else
                {
                    return;
                }
            };
            imge.SizeMode = PictureBoxSizeMode.Zoom;
            imge.Size = new Size(60, 60);
            imge.Margin = new Padding(5, 5,10, 5);
            Card.SetRowSpan(imge, 2);
            Card.Controls.Add(imge, 1, 0);

            Label lb = new Label();
            lb.Size = new Size(400, 50);
            lb.Text = Detail;
            lb.Tag = ID;
          lb.MouseClick += (sender, e) =>
           {

               int NotificationID = int.Parse(((Control)sender).Tag.ToString());
               String[] temp = model.Users.GetNotificationsByID(NotificationID);
               if (temp[4] == "0")
               {
                   model.Users.UpdateNotification(NotificationID);
                 if(((Control)sender).Parent is TableLayoutPanel Parent)
                   {
                       Parent.BackColor = Color.White;
                   }
                   return;
               }
               else
               {
                   return;
               }
           };
            lb.TextAlign = ContentAlignment.TopRight;
            
            Font f = new Font("Arial", 10, FontStyle.Bold);
            lb.Font=f;
            lb.Margin = new Padding(0, 5, 0, 0);
            lb.Padding = new Padding(0, 5, 0, 0);
            Card.Controls.Add(lb,0,1);
            TableLayoutPanel DetailTime = new TableLayoutPanel();
            DetailTime.AutoSize = true;
            DetailTime.ColumnCount = 2;
            DetailTime.RowCount = 2;
            DetailTime.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            Label lbDate = new Label();
            lbDate.Text = tempDateTime;
            lbDate.TextAlign = ContentAlignment.MiddleCenter;
            lbDate.Font = f;

            Label lbTime = new Label();
            lbTime.Size = new Size(300, 20);

            lbTime.Text = "منذ "+tempTime+" "+ActiveTime;
            lbTime.TextAlign = ContentAlignment.TopLeft;
            lbTime.Font = f;
            DetailTime.Controls.Add(lbDate, 1, 0);
            DetailTime.Controls.Add(lbTime, 0, 0);
            Card.Controls.Add(DetailTime, 1, 1);
            tempNotifications.Controls.Add(Card);


        }

        public void Loading()
        {
            List<String[]> list = model.Users.GetNotifications();
            foreach (String[] m in list)
            {
                TimeSpan s = DateTime.Now - DateTime.Parse(m[1]);
                String Day = s.Days.ToString();
                String Hour = s.Hours.ToString();
                String Min = s.Minutes.ToString();
                String Second = s.Seconds.ToString();

                String Time="";
                String TimeString="";
                if (int.Parse(Day) > 0)
                {
                    Time = Day;
                    TimeString = "يوم";
                }else if (int.Parse(Hour)>0)
                {
                    Time = Hour;
                    TimeString = "ساعة";

                }
                else if (int.Parse(Min) > 0)
                {
                    Time = Min;
                    TimeString = "دقيقة";

                }
                else if (int.Parse(Second) > 0)
                {
                    Time ="";
                    TimeString = "الان";

                }
                String Imge = model.Users.GetImgeUserByUserID(int.Parse(m[3]));
                AddNotification(Notifications, Imge, m[2], m[1], Time, TimeString, m[0], m[4]);

            }
        }
        private void frmNotification_Load(object sender, EventArgs e)
        {
    

        }




    }
}
