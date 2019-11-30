using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ImageClassLib;

namespace KJBL
{
    public partial class frmMainClib : Form
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
        public frmMainClib()
        {
            InitializeComponent();
            FormInit();
        }
        public void CopyScreen()
        {
            //将屏幕图像复制到位图中
            Graphics_ScreenBitmap.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
            Zoom_Graphics_ScreenBitmap.DrawImage(Bitmap_Screen, 0, 0, Width * 2, Height * 2);
            Bi = Bitmap_Screen;
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
        #region 缩放、裁剪图像用到的变量
        /// <summary>
        /// 
        /// </summary>
        int x1;     //鼠标按下时横坐标
        int y1;     //鼠标按下时纵坐标
        int width;  //所打开的图像的宽
        int heigth; //所打开的图像的高
        bool HeadImageBool = false;    // 此布尔变量用来判断pictureBox1控件是否有图片
        #endregion
        #region 画矩形使用到的变量
        Point p1;   //定义鼠标按下时的坐标点
        Point p2;   //定义移动鼠标时的坐标点
        Point p3;   //定义松开鼠标时的坐标点
        #endregion
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
            this.p1 = new Point(e.X, e.Y);
            x1 = e.X;
            y1 = e.Y;
            if (this.pictureBox1.Image != null)
            {
                HeadImageBool = true;
            }
            else
            {
                HeadImageBool = false;
            }
        }

        //随手画或者绘橡皮筋效果
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                this.p2 = new Point(e.X, e.Y);
                if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) > 0)     //当鼠标从左上角向开始移动时P3坐标
                {
                    this.p3 = new Point(p1.X, p1.Y);
                }
                if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) > 0)     //当鼠标从右上角向左下方向开始移动时P3坐标
                {
                    this.p3 = new Point(p2.X, p1.Y);
                }
                if ((p2.X - p1.X) > 0 && (p2.Y - p1.Y) < 0)     //当鼠标从左下角向上开始移动时P3坐标
                {
                    this.p3 = new Point(p1.X, p2.Y);
                }
                if ((p2.X - p1.X) < 0 && (p2.Y - p1.Y) < 0)     //当鼠标从右下角向左方向上开始移动时P3坐标
                {
                    this.p3 = new Point(p2.X, p2.Y);
                }
                this.pictureBox1.Invalidate();  //使控件的整个图面无效，并导致重绘控件
            }
        }
        ImageCut1 IC1;  //定义所画矩形的图像对像
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (HeadImageBool)
            {
                width = this.pictureBox1.Image.Width;
                heigth = this.pictureBox1.Image.Height;
                if ((e.X - x1) > 0 && (e.Y - y1) > 0)   //当鼠标从左上角向右下方向开始移动时发生
                {
                    IC1 = new ImageCut1(x1, y1, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));    //实例化ImageCut1类
                }
                if ((e.X - x1) < 0 && (e.Y - y1) > 0)   //当鼠标从右上角向左下方向开始移动时发生
                {
                    IC1 = new ImageCut1(e.X, y1, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));   //实例化ImageCut1类
                }
                if ((e.X - x1) > 0 && (e.Y - y1) < 0)   //当鼠标从左下角向右上方向开始移动时发生
                {
                    IC1 = new ImageCut1(x1, e.Y, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));   //实例化ImageCut1类
                }
                if ((e.X - x1) < 0 && (e.Y - y1) < 0)   //当鼠标从右下角向左上方向开始移动时发生
                {
                    IC1 = new ImageCut1(e.X, e.Y, Math.Abs(e.X - x1), Math.Abs(e.Y - y1));      //实例化ImageCut1类
                }
                //this.pictureBox2.Width = (IC1.KiCut1((Bitmap)(this.pictureBox1.Image))).Width;
                //this.pictureBox2.Height = (IC1.KiCut1((Bitmap)(this.pictureBox1.Image))).Height;
                Image img  = IC1.KiCut1((Bitmap)(this.pictureBox1.Image));
                Clipboard.SetImage(img);
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.Hide();
                    break;
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

        #region 重新绘制pictureBox1控件，即移动鼠标画矩形
        Bitmap Bi;  //定义位图对像
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (HeadImageBool)
            {
                Pen p = new Pen(Color.Black, 1);//画笔
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                //Bitmap bitmap = new Bitmap(strHeadImagePath);
                Bitmap bitmap = Bi;
                Rectangle rect = new Rectangle(p3, new Size(System.Math.Abs(p2.X - p1.X), System.Math.Abs(p2.Y - p1.Y)));
                e.Graphics.DrawRectangle(p, rect);
            }
            else
            {

            }
        }
        #endregion
    }
}
