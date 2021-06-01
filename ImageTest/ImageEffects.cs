using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageTest
{
    interface IImageData
    {
        byte[] GetPixel(int i, int j);
        void ConvolutionPixel(int i, int j, double[,] mask);
        void SetPixel(byte[] pixel, int i, int j);
        void PixelToGrayScale(int i, int j);
        void PixelToSepia(int i, int j);
        void PixelToPoster(int i, int j, int count);

    }

    public class ImageData
    {
        public Bitmap Source;
        protected byte[] bytes;
        protected BitmapData data;
        protected PixelFormat format;

        public void SetImage(Bitmap bitmap)
        {
            format = bitmap.PixelFormat;
            Source = bitmap;
            data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            bytes = new byte[Math.Abs(data.Stride) * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        }

        public void GetResultImage()
        {
            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
            Source.UnlockBits(data);
        }
    }  
    
    public class ImageData24 : ImageData, IImageData
    {
        public void ConvolutionPixel(int x, int y, double[,] kernel)
        {
            byte[] result = new byte[3];
            int width = data.Width;
            int height = data.Height;

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);

            double rSum = 0, gSum = 0, bSum = 0, kSum = 0;

            for (int i = 0; i < kernelWidth; i++)
                for (int j = 0; j < kernelHeight; j++)
                {
                    int pixelPosX = x + (i - (kernelWidth / 2));
                    int pixelPosY = y + (j - (kernelHeight / 2));
                    if ((pixelPosX < 0) ||
                      (pixelPosX >= width) ||
                      (pixelPosY < 0) ||
                      (pixelPosY >= height)) continue;                 

                    double kernelVal = kernel[i, j];
                    byte[] pixel = GetPixel(pixelPosX, pixelPosY);
                    rSum += pixel[0] * kernelVal;
                    gSum += pixel[1] * kernelVal;
                    bSum += pixel[2] * kernelVal;

                    kSum += kernelVal;
                }

            if (kSum <= 0) kSum = 1;

            //Контролируем переполнения переменных
            rSum /= kSum;
            if (rSum < 0) rSum = 0;
            if (rSum > 255) rSum = 255;

            gSum /= kSum;
            if (gSum < 0) gSum = 0;
            if (gSum > 255) gSum = 255;

            bSum /= kSum;
            if (bSum < 0) bSum = 0;
            if (bSum > 255) bSum = 255;

            result[0] = (byte)rSum;
            result[1] = (byte)gSum;
            result[2] = (byte)bSum;

            SetPixel(result, x, y);
        }
        public byte[] GetPixel(int i, int j)
        {
            byte[] pixel = new byte[3];
            pixel[0] = bytes[3 * (data.Width * j + i) + 2];
            pixel[1] = bytes[3 * (data.Width * j + i) + 1];
            pixel[2] = bytes[3 * (data.Width * j + i) + 0];
            return pixel;
        }
        public void SetPixel(byte[] pixel, int i, int j)
        {
            bytes[3 * (data.Width * j + i) + 2] = pixel[0];
            bytes[3 * (data.Width * j + i) + 1] = pixel[1];
            bytes[3 * (data.Width * j + i) ] = pixel[2];

        }
        public void PixelToGrayScale(int i, int j)
        {
            byte[] pixel = GetPixel(i, j);
            int r = pixel[0];
            int g = pixel[1];
            int b = pixel[2];
            pixel[0] = (byte)((r + g + b) / 3);
            pixel[1] = (byte)((r + g + b) / 3);
            pixel[2] = (byte)((r + g + b) / 3);
            SetPixel(pixel,i, j);
        }
        public void PixelToSepia(int i, int j)
        {
            byte[] pixel = GetPixel(i, j);
            int r = pixel[0];
            int g = pixel[1];
            int b = pixel[2];

            //calculate temp value
            int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
            int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
            int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

            //set new RGB value
            pixel[0] = (byte)(tr > 255 ? 255 : tr);
            pixel[1] = (byte)(tg > 255 ? 255 : tg);
            pixel[2] = (byte)(tb > 255 ? 255 : tb);

            //set the new RGB value in image pixel
            SetPixel(pixel, i, j);
        }
        public void PixelToPoster(int i, int j, int count)
        {
            byte[] pixel = GetPixel(i, j);
            int r = pixel[0];
            int g = pixel[1];
            int b = pixel[2];

            for (int k = 0; k < count; k++)
            {
                double X1 = 255 * k / (double)count;
                double X2 = 255 * (k + 1) / (double)count;
                if (r >= X1 && r < X2) r = (int)((X2 + X1) / 2.0);
                if (g >= X1 && g < X2) g = (int)((X2 + X1) / 2.0);
                if (b >= X1 && b < X2) b = (int)((X2 + X1) / 2.0);
            }


            pixel[0] = (byte)(r > 255 ? 255 : r);
            pixel[1] = (byte)(g > 255 ? 255 : g);
            pixel[2] = (byte)(b > 255 ? 255 : b);

            //set the new RGB value in image pixel
            SetPixel(pixel, i, j);
        }

    }

    public class ImageData16 : ImageData, IImageData
    {
        public void ConvolutionPixel(int x, int y, double[,] kernel)
        {
            byte[] result = new byte[2];
            int width = data.Width;
            int height = data.Height;

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);

            double rSum = 0, gSum = 0, kSum = 0;

            for (int i = 0; i < kernelWidth; i++)
                for (int j = 0; j < kernelHeight; j++)
                {
                    int pixelPosX = x + (i - (kernelWidth / 2));
                    int pixelPosY = y + (j - (kernelHeight / 2));
                    if ((pixelPosX < 0) ||
                      (pixelPosX >= width) ||
                      (pixelPosY < 0) ||
                      (pixelPosY >= height)) continue;

                    byte[] pixel = GetPixel(x, y);

                    double kernelVal = kernel[i, j];

                    rSum += pixel[0] * kernelVal;
                    gSum += pixel[1] * kernelVal;

                    kSum += kernelVal;
                }

            if (kSum <= 0) kSum = 1;

            //Контролируем переполнения переменных
            rSum /= kSum;
            if (rSum < 0) rSum = 0;
            if (rSum > 255) rSum = 255;

            gSum /= kSum;
            if (gSum < 0) gSum = 0;
            if (gSum > 255) gSum = 255;


            result[0] = (byte)rSum;
            result[1] = (byte)gSum;

            SetPixel(result, x, y);
        }
        public byte[] GetPixel(int i, int j)
        {
            byte[] pixel = new byte[2];
            pixel[0] = bytes[2 * (data.Width * j + i)];
            pixel[1] = bytes[2 * (data.Width * j + i) + 1];
            return pixel;
        }
        public void SetPixel(byte[] pixel, int i, int j)
        {
            bytes[2 * (data.Width * j + i)] = pixel[0];
            bytes[2 * (data.Width * j + i) + 1] = pixel[1];
        }
        public void PixelToGrayScale(int i, int j)
        {
            byte[] pixel = GetPixel(i, j);
            int r = pixel[0];
            pixel[0] = (byte)r;

            SetPixel(pixel, i, j);
        }
        public void PixelToSepia(int i, int j)
        {
            
        }
        public void PixelToPoster(int i, int j, int count)
        {

        }
    }

    public class ImageData8 : ImageData, IImageData
    {
        public void ConvolutionPixel(int x, int y, double[,] kernel)
        {
            byte[] result = new byte[1];
            int width = data.Width;
            int height = data.Height;

            int kernelWidth = kernel.GetLength(0);
            int kernelHeight = kernel.GetLength(1);

            double rSum = 0, kSum = 0;

            for (int i = 0; i < kernelWidth; i++)
                for (int j = 0; j < kernelHeight; j++)
                {
                    int pixelPosX = x + (i - (kernelWidth / 2));
                    int pixelPosY = y + (j - (kernelHeight / 2));
                    if ((pixelPosX < 0) ||
                      (pixelPosX >= width) ||
                      (pixelPosY < 0) ||
                      (pixelPosY >= height)) continue;

                    byte[] pixel = GetPixel(x, y);

                    double kernelVal = kernel[i, j];

                    rSum += pixel[0] * kernelVal;

                    kSum += kernelVal;
                }

            if (kSum <= 0) kSum = 1;

            //Контролируем переполнения переменных
            rSum /= kSum;
            if (rSum < 0) rSum = 0;
            if (rSum > 255) rSum = 255;

            result[0] = (byte)rSum;

            SetPixel(result, x, y);
        }
        public byte[] GetPixel(int i, int j)
        {
            byte[] pixel = new byte[1];
            pixel[0] = bytes[data.Width * j + i];
            return pixel;
        }
        public void SetPixel(byte[] pixel, int i, int j)
        {
            bytes[data.Width * j + i] = pixel[0];
        }
        public void PixelToGrayScale(int i, int j)
        {
            byte[] pixel = GetPixel(i, j);
            int r = pixel[0];
            pixel[0] = (byte)r;

            SetPixel(pixel, i, j);
        }
        public void PixelToSepia(int i, int j)
        {

        }
        public void PixelToPoster(int i, int j, int count)
        {
           
        }
    }

    public class ImageEffects
    {
        ImageData data;

        public ImageEffects(Bitmap image)
        {
            if(image.PixelFormat == PixelFormat.Format8bppIndexed)
                data = new ImageData8();
                
            else if (image.PixelFormat == PixelFormat.Format16bppGrayScale)
                data = new ImageData16();

            else if (image.PixelFormat == PixelFormat.Format24bppRgb)
                data = new ImageData24();
            else
            data = new ImageData();

            data.SetImage(image);
        }

        public void Convolution(double[,] kernel)
        {
            IImageData temp = (IImageData)data;
            for(int i = 0; i < data.Source.Width; i++)
            {
                for (int j = 0; j < data.Source.Height; j++)
                {
                    temp.ConvolutionPixel(i, j, kernel);
                }
            }
        }

        public void Sepia()
        {
          if(data is ImageData24)
            {
                IImageData temp = (IImageData)data;
                for (int i = 0; i < data.Source.Width; i++)
                {
                    for (int j = 0; j < data.Source.Height; j++)
                    {
                        temp.PixelToSepia(i, j);
                    }
                }
                    
           }
            
        }

        public  void Poster(int count)
        {
            if (data is ImageData24)
            {
                IImageData temp = (IImageData)data;
                for (int i = 0; i < data.Source.Width; i++)
                {
                    for (int j = 0; j < data.Source.Height; j++)
                    {
                        temp.PixelToPoster(i, j, count);
                    }
                }

            }
        }

        public void GrayScale()
        {
            IImageData temp = (IImageData)data;
            for (int i = 0; i < data.Source.Width; i++)
                for (int j = 0; j < data.Source.Height; j++)
                {
                        temp.PixelToGrayScale(i, j);
                }
        }

        public Bitmap RefreshSource()
        {
            data.GetResultImage();
            return data.Source;
        }

    }

}