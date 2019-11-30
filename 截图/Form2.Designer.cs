namespace KJBL
{
    partial class Form2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbState = new System.Windows.Forms.ToolStripButton();
            this.tbDrawStyle = new System.Windows.Forms.ToolStripSplitButton();
            this.tmiFreeHand = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEllips = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPenSet = new System.Windows.Forms.ToolStripButton();
            this.tbBrushSet = new System.Windows.Forms.ToolStripButton();
            this.tbHelp = new System.Windows.Forms.ToolStripButton();
            this.tbClose = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbState,
            this.tbDrawStyle,
            this.tbPenSet,
            this.tbBrushSet,
            this.tbHelp,
            this.tbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(52, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Click += new System.EventHandler(this.toolStrip1_Click);
            this.toolStrip1.MouseEnter += new System.EventHandler(this.toolStrip1_MouseEnter);
            this.toolStrip1.MouseLeave += new System.EventHandler(this.toolStrip1_MouseLeave);
            // 
            // tbState
            // 
            this.tbState.CheckOnClick = true;
            this.tbState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbState.Image = global::KJBL.Properties.Resources.rectangle;
            this.tbState.ImageTransparentColor = System.Drawing.Color.White;
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(23, 29);
            this.tbState.CheckStateChanged += new System.EventHandler(this.toolStripButton1_CheckStateChanged);
            // 
            // tbDrawStyle
            // 
            this.tbDrawStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDrawStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFreeHand,
            this.tmiLine,
            this.tmiRectangle,
            this.tmiEllips});
            this.tbDrawStyle.Image = global::KJBL.Properties.Resources.freehand;
            this.tbDrawStyle.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbDrawStyle.Name = "tbDrawStyle";
            this.tbDrawStyle.Size = new System.Drawing.Size(32, 20);
            this.tbDrawStyle.Visible = false;
            // 
            // tmiFreeHand
            // 
            this.tmiFreeHand.Image = global::KJBL.Properties.Resources.freehand;
            this.tmiFreeHand.ImageTransparentColor = System.Drawing.Color.Black;
            this.tmiFreeHand.Name = "tmiFreeHand";
            this.tmiFreeHand.Size = new System.Drawing.Size(112, 22);
            this.tmiFreeHand.Text = "随手画";
            this.tmiFreeHand.Click += new System.EventHandler(this.tmiFreeHand_Click);
            // 
            // tmiLine
            // 
            this.tmiLine.Image = global::KJBL.Properties.Resources.line;
            this.tmiLine.ImageTransparentColor = System.Drawing.Color.Black;
            this.tmiLine.Name = "tmiLine";
            this.tmiLine.Size = new System.Drawing.Size(112, 22);
            this.tmiLine.Text = "直线";
            this.tmiLine.Click += new System.EventHandler(this.tmiLine_Click);
            // 
            // tmiRectangle
            // 
            this.tmiRectangle.Image = global::KJBL.Properties.Resources.rectangle;
            this.tmiRectangle.ImageTransparentColor = System.Drawing.Color.White;
            this.tmiRectangle.Name = "tmiRectangle";
            this.tmiRectangle.Size = new System.Drawing.Size(112, 22);
            this.tmiRectangle.Text = "矩形";
            this.tmiRectangle.Click += new System.EventHandler(this.tmiRectangle_Click);
            // 
            // tmiEllips
            // 
            this.tmiEllips.Image = global::KJBL.Properties.Resources.ellips;
            this.tmiEllips.ImageTransparentColor = System.Drawing.Color.Black;
            this.tmiEllips.Name = "tmiEllips";
            this.tmiEllips.Size = new System.Drawing.Size(112, 22);
            this.tmiEllips.Text = "椭圆";
            this.tmiEllips.Click += new System.EventHandler(this.tmiEllips_Click);
            // 
            // tbPenSet
            // 
            this.tbPenSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPenSet.Image = global::KJBL.Properties.Resources.颜色;
            this.tbPenSet.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPenSet.Name = "tbPenSet";
            this.tbPenSet.Size = new System.Drawing.Size(23, 20);
            this.tbPenSet.Visible = false;
            this.tbPenSet.Click += new System.EventHandler(this.tbPenSet_Click);
            // 
            // tbBrushSet
            // 
            this.tbBrushSet.CheckOnClick = true;
            this.tbBrushSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBrushSet.Image = global::KJBL.Properties.Resources.zoom;
            this.tbBrushSet.ImageTransparentColor = System.Drawing.Color.White;
            this.tbBrushSet.Name = "tbBrushSet";
            this.tbBrushSet.Size = new System.Drawing.Size(23, 20);
            this.tbBrushSet.Visible = false;
            this.tbBrushSet.CheckedChanged += new System.EventHandler(this.tbBrushSet_CheckStateChanged);
            // 
            // tbHelp
            // 
            this.tbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHelp.Image = global::KJBL.Properties.Resources.help1;
            this.tbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbHelp.Name = "tbHelp";
            this.tbHelp.Size = new System.Drawing.Size(23, 20);
            this.tbHelp.Text = "toolStripButton1";
            this.tbHelp.Visible = false;
            this.tbHelp.Click += new System.EventHandler(this.tbHelp_Click);
            // 
            // tbClose
            // 
            this.tbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClose.Image = global::KJBL.Properties.Resources.电电源按钮;
            this.tbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(23, 20);
            this.tbClose.Click += new System.EventHandler(this.tbClose_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(52, 32);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form2";
            this.Text = "Form2";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form2_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbState;
        private System.Windows.Forms.ToolStripSplitButton tbDrawStyle;
        private System.Windows.Forms.ToolStripMenuItem tmiFreeHand;
        private System.Windows.Forms.ToolStripMenuItem tmiLine;
        private System.Windows.Forms.ToolStripMenuItem tmiRectangle;
        private System.Windows.Forms.ToolStripMenuItem tmiEllips;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripButton tbClose;
        private System.Windows.Forms.ToolStripButton tbPenSet;
        private System.Windows.Forms.ToolStripButton tbBrushSet;
        private System.Windows.Forms.ToolStripButton tbHelp;
    }
}