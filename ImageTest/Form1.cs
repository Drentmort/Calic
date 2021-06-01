using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageTest
{
    public partial class MainForm : Form
    {
        private Image origin;
        private Bitmap changedImage;
        private MotionForm motionModalWin;

        public MainForm()
        {
            InitializeComponent();
        }

        public void MotionImage(bool isVer, bool isHor, int horSpeed, int vertSpeed)
        {
            
            if (changedImage == null)
                return;
            double[,] core;
            if (isHor)
            {
                ImageEffects effects = new ImageEffects(changedImage);
                core = new double[horSpeed, 1];
                for (int i = 0; i < horSpeed; i++)
                    core[i, 0] = 1;

                effects.Convolution(core);
                changedImage = effects.RefreshSource();
            }

            if (isVer)
            {
                ImageEffects effects = new ImageEffects(changedImage);
                core = new double[1,vertSpeed];
                for (int j = 0; j < vertSpeed; j++)
                    core[0,j] = 1;
                effects.Convolution(core);
                changedImage = effects.RefreshSource();
            }


            OutputImage.Invalidate();
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            if (OpenImageDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = OpenImageDialog.FileName;

            origin = new Bitmap(filename);
            changedImage = (Bitmap)origin.Clone();
            OutputImage.Invalidate();

        }

        private void OutputImage_Paint(object sender, PaintEventArgs e)
        {
            if (origin == null) return;

            Bitmap temp = new Bitmap(OutputImage.Width, OutputImage.Height);
            using(Graphics g = Graphics.FromImage(temp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(changedImage, 0, 0, OutputImage.Width, OutputImage.Height);
            }

            e.Graphics.DrawImage(temp, OutputImage.Location);
        }

        private void MotionBlurButton_Click(object sender, EventArgs e)
        {
            if (motionModalWin == null || motionModalWin.IsDisposed == true) 
                motionModalWin = new MotionForm(this);
            motionModalWin.Show();
        }

        private void SepiaButton_Click(object sender, EventArgs e)
        {
            if (changedImage != null)
            {
                ImageEffects effects = new ImageEffects(changedImage);
                effects.Sepia();
                effects.RefreshSource();
                OutputImage.Invalidate();
            }

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if (!motionModalWin.IsDisposed && motionModalWin != null)
                motionModalWin.Dispose();
            if (changedImage != null)
            {
                changedImage = (Bitmap)origin.Clone();
                OutputImage.Invalidate();
            }
        }

        private void PosterImageButton_Click(object sender, EventArgs e)
        {
            if (changedImage != null)
            {
                ImageEffects effects = new ImageEffects(changedImage);
                effects.Poster(3);
                effects.RefreshSource();
                OutputImage.Invalidate();
            }
        }

        private void GrayScale_Click(object sender, EventArgs e)
        {
            if (changedImage != null)
            {
                ImageEffects effects = new ImageEffects(changedImage);
                effects.GrayScale();
                effects.RefreshSource();
                OutputImage.Invalidate();
            }
        }

        private void GaussBlurButton_Click(object sender, EventArgs e)
        {
            if (changedImage != null)
            {
                double[,] core = { { 0.000789, 0.006581, 0.013347, 0.000789, 0.006581 }, 
                    { 0.006581, 0.54901, 0.111345, 0.006581, 0.54901 }, 
                    { 0.013347,0.111345,0.225821, 0.013347, 0.11134 }, 
                    { 0.006581, 0.54901, 0.111345, 0.006581, 0.54901 }, 
                    { 0.000789, 0.006581, 0.013347, 0.000789, 0.006581 } };
                ImageEffects effects = new ImageEffects(changedImage);
                effects.Convolution(core);
                changedImage = effects.RefreshSource();
                OutputImage.Invalidate();
            }
        }
    }
}
