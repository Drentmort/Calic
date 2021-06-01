using System.Windows.Forms;
using System.Drawing;

namespace Calcil
{
    public class FocusBuffer:Control
    {
        private ControlCollection buttons;
        public FocusBuffer()
        {
            Size = new Size(100, 100);

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
        }

        public void SetButtons(ControlCollection controls)
        {
            buttons = controls;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            foreach(Control button in buttons)
            {
                if (button is TestButton)
                {
                    if (button.Text.Contains(e.KeyChar.ToString()))
                    {
                        button.Focus();
                    }
                }
                   
            }
        }

    }
}
