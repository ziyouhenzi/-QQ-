using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace KJBL
{
    public partial class Form2 : Form
    {
        private frmMainClib maimForm;


        private const int WM_HOTKEY = 0x312; //窗口消息-热键

        private const int WM_CREATE = 0x1; //窗口消息-创建

        private const int WM_DESTROY = 0x2; //窗口消息-销毁

        private const int Space = 0x3572; //热键ID

        protected override void WndProc(ref Message m)

        {

            base.WndProc(ref m);

            switch (m.Msg)

            {

                case WM_HOTKEY: //窗口消息-热键ID

                    switch (m.WParam.ToInt32())

                    {

                        case Space: //热键ID
                            tbState.Checked = false;
                            tbState.Checked = true;

                            break;

                        default:

                            break;

                    }

                    break;

                case WM_CREATE: //窗口消息-创建

                    AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.Ctrl | AppHotKey.KeyModifiers.Shift, Keys.A);

                    break;

                case WM_DESTROY: //窗口消息-销毁

                    AppHotKey.UnRegKey(Handle, Space); //销毁热键

                    break;

                default:

                    break;

            }

        }

        public Form2()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Top = -Height + 20;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - toolStrip1.Width) / 2;
            if (maimForm == null)
                maimForm = new frmMainClib();
        }

        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = false;
            toolStrip1.Focus();
        }

        private void toolStrip1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }
       private void timer1_Tick(object sender, EventArgs e)
        {
            if (Top > 20 - Height)
                this.Top-=4;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Top <= 0)
                this.Top+=4;
        }

        private void toolStripButton1_CheckStateChanged(object sender, EventArgs e)
        {
            if (tbState.Checked)
            {
                this.Visible = false;                
                maimForm.CopyScreen();
                maimForm.Show();
                maimForm.BringToFront();
                this.Visible = true;
            }
            else
            {
                maimForm.Hide();
            }
        }
      
        private void tmiFreeHand_Click(object sender, EventArgs e)
        {
            maimForm.drawStyle = frmMainClib.DrawStyle.FreeHand;
           // tbDrawStyle.Image = tmiFreeHand.Image;
        }

        private void tmiLine_Click(object sender, EventArgs e)
        {
            maimForm.drawStyle = frmMainClib.DrawStyle.Line;
           // tbDrawStyle.Image = tmiLine.Image;
        }

        private void tmiRectangle_Click(object sender, EventArgs e)
        {
            maimForm.drawStyle = frmMainClib.DrawStyle.Rectangle;
          //  tbDrawStyle.Image = tmiRectangle.Image;
        }

        private void tmiEllips_Click(object sender, EventArgs e)
        {
            maimForm.drawStyle = frmMainClib.DrawStyle.Circle;
          //  tbDrawStyle.Image = tmiEllips.Image;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPenSet_Click(object sender, EventArgs e)
        {
            if (maimForm == null) return;
            //创建画笔设置窗口
            PenSet penset = new PenSet();
            if (penset.ShowDialog() == DialogResult.OK)//如果画笔设置对话的框确定按钮被按下
            {
                //重新设置画笔颜色
                maimForm.pen.Color = penset.bColor.BackColor;
                //重新设置画笔宽度
                maimForm.pen.Width=int.Parse(penset.udWidth.Text);
                //根据设置窗口选项按钮值指定画笔线型
                if (penset.radioButton1.Checked)
                    maimForm.pen.DashStyle = DashStyle.Solid;
                if (penset.radioButton2.Checked)
                    maimForm.pen.DashStyle = DashStyle.Dot;
                if (penset.radioButton3.Checked)
                    maimForm.pen.DashStyle = DashStyle.DashDot;
            }
        }       

        private void tbBrushSet_CheckStateChanged(object sender, EventArgs e)
        {
            if (maimForm == null) return;

            if (tbBrushSet.Checked)
            {
                if (!tbState.Checked)
                    tbState.Checked = true;
                maimForm.ZoomScreen(true);
            }
            else
            {
                maimForm.ZoomScreen(false);
            }
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            if (!maimForm.Visible)
            {
                tbState.Checked = false;
                tbBrushSet.Checked = false;
            }
        }

        private void tbHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                tbState.Checked = false;
            
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
                

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Alt && e.Shift && e.KeyCode == Keys.A)
            //    tbState.Checked = true;
        }
    }
}