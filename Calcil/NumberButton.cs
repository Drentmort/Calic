using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Calcil
{
    public class NumberButton : Control
    {
        Label label1;
        Label label2;
        static string num1;
        static int pointNum1=0;
        static string num2;
        static int pointNum2=0;
        int numNum = 1;

        int textSize = 20;
        Brush fill = Brushes.WhiteSmoke;

        public NumberButton(Label label1, Label label2)
        {
            this.label1 = label1;
            this.label2 = label2;

            Size = new Size(100, 100);
            
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.SupportsTransparentBackColor | 
                ControlStyles.UserPaint, true);

            DoubleBuffered = true;

            Font = new Font("Verdana", 8.25F, FontStyle.Regular);
            Cursor = Cursors.Hand;

            BackColor = Color.Transparent;
            //ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            Rectangle rounding = new Rectangle(1, 1, Size.Width / 10, Size.Height / 10);
            GraphicsPath border = new GraphicsPath();
            border.AddArc(rounding, -180, 90);
            border.AddArc(new Rectangle(Size.Width - rounding.Width-1, rounding.Top, Size.Width / 10, Size.Height / 10), 270, 90);
            border.AddArc(new Rectangle(Size.Width - rounding.Width-1, Size.Height - rounding.Height-1, Size.Width / 10, Size.Height / 10), 0,90);
            border.AddArc(new Rectangle(rounding.Left, Size.Height - rounding.Height-1, Size.Width / 10, Size.Height / 10), 90, 90);
            border.CloseFigure();
         
            e.Graphics.FillPath(fill, border);
            e.Graphics.DrawPath(Pens.Black, border);
            Point location = new Point(Size.Width/2 - Text.Length/2 * textSize, Size.Height/2 - 4);
            e.Graphics.DrawString(Text, new Font(FontFamily.GenericSansSerif, textSize , FontStyle.Bold), Brushes.Black,location);

        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            fill = Brushes.LightGray;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            fill = Brushes.WhiteSmoke;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (numNum == 1)
            {
                if (Text.Contains("."))
                    pointNum1++;
                
                if(pointNum1 > 1&& Text.Contains("."))
                {
                    Focus();
                    return;
                }

                num1 += Text;
                if (num1.Length > 5)
                    label1.Text = num1.Substring(num1.Length - 5);
                else
                    label1.Text = num1;
            }

            else
            {
                if (Text.Contains("."))
                    pointNum2++;

                if (pointNum2 > 1 && Text.Contains("."))
                {
                    Focus();
                    return;
                }

                num2 += Text;
                if (num2.Length > 5)
                    label2.Text = num1.Substring(num1.Length - 5);
                else
                    label2.Text = num1;
            }
                base.OnMouseClick(e);
            Focus();
        }
    }
}
