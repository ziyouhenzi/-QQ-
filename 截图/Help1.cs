using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace ImageClassLib
{
    public class ImageCut1
    {
        #region 剪裁图片方法
        /// <summary> 
        /// 剪裁 -- 用GDI+ 
        /// </summary> 
        /// <param name="b">原始Bitmap,即需要裁剪的图片</param> 
        /// <param name="StartX">开始坐标X</param> 
        /// <param name="StartY">开始坐标Y</param> 
        /// <param name="iWidth">宽度</param> 
        /// <param name="iHeight">高度</param> 
        /// <returns>剪裁后的Bitmap</returns> 
        public Bitmap KiCut1(Bitmap b)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (X >= w || Y >= h)
            {
                return null;
            }

            if (X + Width > w)
            {
                Width = w - X;
            }

            if (Y + Height > h)
            {
                Height = h - Y;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                // Create rectangle for displaying image.
                Rectangle destRect = new Rectangle(0, 0, Width, Height);        //所画的矩形正确，它指定所绘制图像的位置和大小。 将图像进行缩放以适合该矩形。

                // Create rectangle for source image.
                Rectangle srcRect = new Rectangle(X, Y, Width, Height);      //srcRect参数指定要绘制的 image 对象的矩形部分。 将此部分进行缩放以适合 destRect 参数所指定的矩形。

                g.DrawImage(b, destRect, srcRect, GraphicsUnit.Pixel);
                //resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region ImageCut1类的构造函数
        public int X;
        public int Y;
        public int Width;
        public int Height;
        /// <summary>
        /// ImageCut1类的构造函数，ImageCut1类用来获取鼠标在pictureBox1控件所画矩形内的图像
        /// </summary>
        /// <param name="x表示鼠标在pictureBox1控件上按下时的横坐标"></param>
        /// <param name="y表示鼠标在pictureBox1控件上按下时的纵坐标"></param>
        /// <param name="width表示鼠标在pictureBox1控件上松开鼠标的宽度"></param>
        /// <param name="heigth表示鼠标在pictureBox1控件上松开鼠标的高度"></param>
        public ImageCut1(int x, int y, int width, int heigth)
        {
            X = x;
            Y = y;
            Width = width;
            Height = heigth;
        }
        #endregion
    }
}