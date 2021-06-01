using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTest
{
    public partial class MotionForm : Form
    {
        bool horizontal = false;
        bool vertical = false;
        int horSpeed = 4;
        int verSpeed = 4;
        MainForm source;

        public MotionForm(MainForm source)
        {
            InitializeComponent();
            this.source = source;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                horSpeed = int.Parse(textBox1.Text);
            }
            catch (Exception) { }
            source.MotionImage(vertical, horizontal, horSpeed, verSpeed);
            source.Invalidate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                horSpeed = int.Parse(textBox2.Text);
            }
            catch (Exception) { }
            source.MotionImage(vertical, horizontal, horSpeed, verSpeed);
            source.Invalidate();
        }

        private void Horizontal_Click(object sender, EventArgs e)
        {
            source.MotionImage(false, true, horSpeed, verSpeed);
            source.Invalidate();
        }

        private void Vertical_Click(object sender, EventArgs e)
        {
            source.MotionImage(true, false, horSpeed, verSpeed);
            source.Invalidate();
        }


        //BlurPower = trackBar1.Value;
        //double[,] core = { {0,-1,0}, { -1,5,-1 }, { 0, -1, 0 } };
        //
    }
}
