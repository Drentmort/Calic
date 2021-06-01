using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
//using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Calcil
{
    
    public class TestButton : Control
    {
        int textSize = 20;
        Brush fill = Brushes.WhiteSmoke;


        public TestButton()
        {
            Size = new Size(100, 100);

            Font = new Font("Verdana", 8.25F, FontStyle.Regular);
            Cursor = Cursors.Hand;

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);

            DoubleBuffered = true;

            BackColor = Color.Transparent;

        }

        public event Action<string> ButtonHasPressed;

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

        protected override void OnMouseEnter(EventArgs e)
        {
            fill = Brushes.LightGray;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {            
            fill = Brushes.WhiteSmoke;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            ButtonHasPressed.Invoke(Text);
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ButtonHasPressed.Invoke(Text);
            base.OnMouseDoubleClick(e);
        }
    }
}
