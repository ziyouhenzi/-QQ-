using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJBL
{
    public partial class frmMain : Form
    {
        public Graphics Graphics_PictureBox;  //图片框Graphics对象
        public Bitmap Bitmap_Screen;//保存屏幕内容的位图对象
        public Graphics Graphics_ScreenBitmap;//Bitmap_Screen的Graphics
        public Bitmap Zoom_Bitmap_Screen;//放大时的屏幕位图对象
        public Graphics Zoom_Graphics_ScreenBitmap;//Zoom_Bitmap_Screen的Graphics
        public Boolean ScreenZoom;
        public Boolean frmShow;

        public Bitmap CurrentBitmap;  //当前正使用的位图 取值为Bitmap_Screen和Zoom_Bitmap_Screen之一
        public Graphics CurrentGraphics;//CurrentBitmap的Graphics

        bool IsSpacePressed;        //是否按下了空格键


        int StartX;//绘画画笔起点X坐标 
        int StartY;//绘画画笔起点Y坐标


        public Pen pen;//采用画笔

        public enum DrawStyle
        {
            FreeHand, Line, Rectangle, Circle,
        }
        public DrawStyle drawStyle;  //绘制图形类型
        public frmMain()
        {
            InitializeComponent();
            FormInit();
        }
        public void CopyScreen()
        {
            //将屏幕图像复制到位图中
            Graphics_ScreenBitmap.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
            Zoom_Graphics_ScreenBitmap.DrawImage(Bitmap_Screen, 0, 0, Width * 2, Height * 2);
        }

        //窗体载入，bitmap,graphics变量初始化， 窗体和图片框大小初始化，画笔初始化
        private void FormInit()
        {
            //设置窗体和图片框的大小和位置
            this.Top = 0;
            this.Left = 0;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            pictureBox1.Top = 0;
            pictureBox1.Left = 0;
            pictureBox1.Size = Size;
            ScreenZoom = false;
            frmShow = false;

            //默认绘图类型
            drawStyle = DrawStyle.FreeHand;

            //创建默认画笔
            pen = new Pen(Color.Red, 5);  //默认画笔为红色 宽度5像素

            //创建用来保存屏幕图像的位图及其Graphics对象
            Bitmap_Screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics_ScreenBitmap = Graphics.FromImage(Bitmap_Screen);

            //创建用来保存放大时的屏幕图像的位图及其Graphics对象
            Zoom_Bitmap_Screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width * 2, Screen.PrimaryScreen.Bounds.Height * 2);
            Zoom_Graphics_ScreenBitmap = Graphics.FromImage(Zoom_Bitmap_Screen);

            //设置当前要使用的位图及其Graphics对象
            CurrentBitmap = Bitmap_Screen;
            CurrentGraphics = Graphics_ScreenBitmap;

            //指定图片框中要显示的图像
            pictureBox1.Image = CurrentBitmap;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        //记住绘画起点
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//判断是否按下左键
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }

        //随手画或者绘橡皮筋效果
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;

            if (e.Button != MouseButtons.Left)  //不是鼠标左键，退出
                return;
            if (IsSpacePressed && ScreenZoom)                        //按下了空格键，为图像漫游
            {                   //改变图片框的位置
                if (pictureBox1.Left + (X - StartX) > 0)
                    pictureBox1.Left = 0;
                else if (pictureBox1.Left + (X - StartX) < Width - pictureBox1.Width)
                    pictureBox1.Left = Width - pictureBox1.Width;
                else
                    pictureBox1.Left = pictureBox1.Left + (X - StartX);

                if (pictureBox1.Top + (Y - StartY) > 0)
                    pictureBox1.Top = 0;
                else if (pictureBox1.Top + (Y - StartY) < Height - pictureBox1.Height)
                    pictureBox1.Top = Height - pictureBox1.Height;
                else
                    pictureBox1.Top = pictureBox1.Top + (Y - StartY);

                return;
            }

            Graphics_PictureBox = pictureBox1.CreateGraphics();
            switch (drawStyle)
            {
                case DrawStyle.FreeHand:  //随手画
                    {
                        CurrentGraphics.DrawLine(pen, StartX, StartY, X, Y);//画直线
                        StartX = X;              //将当前点设为下一条直线的起点  
                        StartY = Y;
                        //刷新以显示刚绘制的内容   
                        pictureBox1.Refresh();
                        break;
                    }
                case DrawStyle.Line:
                    {
                        //刷新清除上一条临时直线   
                        pictureBox1.Refresh();
                        //绘制直线
                        Graphics_PictureBox.DrawLine(pen, StartX, StartY, e.X, e.Y);
                        break;
                    }
                case DrawStyle.Rectangle:
                    {
                        Refresh();
                        Graphics_PictureBox.DrawRectangle(pen, StartX, StartY, e.X - StartX, e.Y - StartY);
                        break;
                    }
                case DrawStyle.Circle:
                    {
                        pictureBox1.Refresh();
                        Graphics_PictureBox.DrawEllipse(pen, StartX, StartY, e.X - StartX, e.Y - StartY);
                        break;
                    }
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;  //不是左键，退出
            int X = e.X;
            int Y = e.Y;
            switch (drawStyle)
            {

                case DrawStyle.Line:
                    {
                        CurrentGraphics.DrawLine(pen, StartX, StartY, X, Y);
                        //Graphics_PictureBox.DrawImage(Bitmap_Screen, new Point(0, 0));
                        break;
                    }
                case DrawStyle.Rectangle:
                    {
                        CurrentGraphics.DrawRectangle(pen, StartX, StartY, X - StartX, Y - StartY);
                        break;
                    }
                case DrawStyle.Circle:
                    {
                        CurrentGraphics.DrawEllipse(pen, StartX, StartY, X - StartX, Y - StartY);
                        break;
                    }
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    IsSpacePressed = true;
                    break;
                case Keys.Escape:
                    if (ScreenZoom)
                    {
                        ZoomScreen(false);
                    }
                    else
                    {
                        this.Hide();
                        frmShow = false;
                    }
                    break;
                case Keys.H:
                    drawStyle = DrawStyle.FreeHand;
                    break;
                case Keys.L:
                    drawStyle = DrawStyle.Line;
                    break;
                case Keys.R:
                    drawStyle = DrawStyle.Rectangle;
                    break;
                case Keys.C:
                    drawStyle = DrawStyle.Circle;
                    break;
                case Keys.D1:
                    pen.Color=Color.Red;
                    break;
                case Keys.D2:
                    pen.Color = Color.Blue;
                    break;
                case Keys.D3:
                    pen.Color=Color.Green;
                    break;
                case Keys.D4:
                    pen.Color=Color.Gold;
                    break;
                case Keys.D5:
                    pen.Color = Color.White;
                    break;
                case Keys.D6:
                    pen.Color = Color.Black;
                    break;
                case Keys.F1:
                    Help hlp = new Help();
                    hlp.ShowDialog();
                    break;
            }

        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            IsSpacePressed = false;
        }

        public void ZoomScreen(bool zoom)
        {
            ScreenZoom = zoom;
            if (zoom)
            {
                pictureBox1.Width = pictureBox1.Width * 2;
                pictureBox1.Height = pictureBox1.Height * 2;
                pictureBox1.Top = (this.Height - pictureBox1.Height) / 4;
                pictureBox1.Left = (this.Width - pictureBox1.Width) / 4;

                CurrentGraphics = Zoom_Graphics_ScreenBitmap;
                CurrentBitmap = Zoom_Bitmap_Screen;
                CurrentGraphics.DrawImage(Bitmap_Screen, 0, 0, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = CurrentBitmap;
            }
            else
            {
                pictureBox1.Width = this.Width;
                pictureBox1.Height = this.Height;
                pictureBox1.Top = 0;
                pictureBox1.Left = 0;
                CurrentGraphics = Graphics_ScreenBitmap;
                CurrentBitmap = Bitmap_Screen;
                CurrentGraphics.DrawImage(Zoom_Bitmap_Screen, 0, 0, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = CurrentBitmap;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ScreenZoom = !ScreenZoom;
            ZoomScreen(ScreenZoom);
        }
    }
}
