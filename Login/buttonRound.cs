using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace ProjectCsharp.Login
{
    public class MultiBorderButton : Button
    {
        // ألوان الحدود لكل جهة
        public Color TopBorderColor { get; set; } = Color.Red;
        public Color BottomBorderColor { get; set; } = Color.Green;
        public Color RightBorderColor { get; set; } = Color.Blue;
        public Color LeftBorderColor { get; set; } = Color.Brown;

        // سمك الحدود لكل جهة
        public int TopBorderThickness { get; set; } = 2;
        public int BottomBorderThickness { get; set; } = 2;
        public int RightBorderThickness { get; set; } = 2;
        public int LeftBorderThickness { get; set; } = 2;

        // درجة تدوير الحواف (0-100%)
        public int RoundnessPercent { get; set; } = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // حساب نصف القطر للزوايا المقوسة
            int radius = (RoundnessPercent * Math.Min(Width, Height)) / 200;

            // إنشاء مسار للزر
            GraphicsPath path = new GraphicsPath();

            // رسم الزوايا المقوسة
            if (radius > 0)
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // أعلى يسار
                path.AddArc(Width - radius * 2, 0, radius * 2, radius * 2, 270, 90); // أعلى يمين
                path.AddArc(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2, 0, 90); // أسفل يمين
                path.AddArc(0, Height - radius * 2, radius * 2, radius * 2, 90, 90); // أسفل يسار
                path.CloseAllFigures();
                this.Region = new Region(path);
            }
            else
            {
                path.AddRectangle(ClientRectangle);
            }

            // رسم الحدود لكل جهة
            DrawBorder(e.Graphics, path, TopBorderColor, TopBorderThickness, BorderSide.Top);
            DrawBorder(e.Graphics, path, BottomBorderColor, BottomBorderThickness, BorderSide.Bottom);
            DrawBorder(e.Graphics, path, RightBorderColor, RightBorderThickness, BorderSide.Right);
            DrawBorder(e.Graphics, path, LeftBorderColor, LeftBorderThickness, BorderSide.Left);
        }

        private void DrawBorder(Graphics g, GraphicsPath path, Color color, int thickness, BorderSide side)
        {
            if (thickness <= 0) return;

            using (Pen pen = new Pen(color, thickness))
            {
                Rectangle rect = ClientRectangle;
                int halfThickness = thickness / 2;

                switch (side)
                {
                    case BorderSide.Top:
                        if (RoundnessPercent > 0)
                        {
                            // رسم الجزء المستقيم من الحد العلوي (بين الزوايا المقوسة)
                            g.DrawLine(pen,
                                new Point(rect.Left + halfThickness + (RoundnessPercent * rect.Width / 200), rect.Top + halfThickness),
                                new Point(rect.Right - halfThickness - (RoundnessPercent * rect.Width / 200), rect.Top + halfThickness));
                        }
                        else
                        {
                            g.DrawLine(pen,
                                new Point(rect.Left + halfThickness, rect.Top + halfThickness),
                                new Point(rect.Right - halfThickness, rect.Top + halfThickness));
                        }
                        break;

                    case BorderSide.Bottom:
                        if (RoundnessPercent > 0)
                        {
                            g.DrawLine(pen,
                                new Point(rect.Left + halfThickness + (RoundnessPercent * rect.Width / 200), rect.Bottom - halfThickness),
                                new Point(rect.Right - halfThickness - (RoundnessPercent * rect.Width / 200), rect.Bottom - halfThickness));
                        }
                        else
                        {
                            g.DrawLine(pen,
                                new Point(rect.Left + halfThickness, rect.Bottom - halfThickness),
                                new Point(rect.Right - halfThickness, rect.Bottom - halfThickness));
                        }
                        break;

                    case BorderSide.Left:
                        if (RoundnessPercent > 0)
                        {
                            g.DrawLine(pen,
                                new Point(rect.Left + halfThickness, rect.Top + halfThickness + (RoundnessPercent * rect.Height / 200)),
                                new Point(rect.Left + halfThickness, rect.Bottom - halfThickness - (RoundnessPercent * rect.Height / 200)));
                        }
                        else
                        {
                            g.DrawLine(pen,
                                new Point(rect.Left + halfThickness, rect.Top + halfThickness),
                                new Point(rect.Left + halfThickness, rect.Bottom - halfThickness));
                        }
                        break;

                    case BorderSide.Right:
                        if (RoundnessPercent > 0)
                        {
                            g.DrawLine(pen,
                                new Point(rect.Right - halfThickness, rect.Top + halfThickness + (RoundnessPercent * rect.Height / 200)),
                                new Point(rect.Right - halfThickness, rect.Bottom - halfThickness - (RoundnessPercent * rect.Height / 200)));
                        }
                        else
                        {
                            g.DrawLine(pen,
                                new Point(rect.Right - halfThickness, rect.Top + halfThickness),
                                new Point(rect.Right - halfThickness, rect.Bottom - halfThickness));
                        }
                        break;
                }
            }
        }

        private enum BorderSide { Top, Bottom, Left, Right }
    }
}

