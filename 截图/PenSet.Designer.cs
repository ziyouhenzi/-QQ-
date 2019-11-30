namespace KJBL
{
    partial class PenSet
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.bColor = new System.Windows.Forms.Button();
            this.udWidth = new System.Windows.Forms.DomainUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "颜色";
            // 
            // bColor
            // 
            this.bColor.BackColor = System.Drawing.Color.Red;
            this.bColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bColor.Location = new System.Drawing.Point(61, 4);
            this.bColor.Name = "bColor";
            this.bColor.Size = new System.Drawing.Size(57, 23);
            this.bColor.TabIndex = 1;
            this.bColor.UseVisualStyleBackColor = false;
            this.bColor.Click += new System.EventHandler(this.bColor_Click);
            // 
            // udWidth
            // 
            this.udWidth.Items.Add("1");
            this.udWidth.Items.Add("2");
            this.udWidth.Items.Add("3");
            this.udWidth.Items.Add("4");
            this.udWidth.Items.Add("5");
            this.udWidth.Items.Add("6");
            this.udWidth.Items.Add("8");
            this.udWidth.Items.Add("10");
            this.udWidth.Items.Add("15");
            this.udWidth.Items.Add("20");
            this.udWidth.Items.Add("30");
            this.udWidth.Location = new System.Drawing.Point(190, 4);
            this.udWidth.Name = "udWidth";
            this.udWidth.Size = new System.Drawing.Size(59, 21);
            this.udWidth.TabIndex = 2;
            this.udWidth.Text = "5";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(61, 46);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "实线";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(127, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "点线";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(190, 46);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "点划线";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "线宽";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "线型";
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(33, 83);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 8;
            this.bOK.Text = "确定";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancle
            // 
            this.bCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancle.Location = new System.Drawing.Point(157, 83);
            this.bCancle.Name = "bCancle";
            this.bCancle.Size = new System.Drawing.Size(75, 23);
            this.bCancle.TabIndex = 9;
            this.bCancle.Text = "取消";
            this.bCancle.UseVisualStyleBackColor = true;
            // 
            // PenSet
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancle;
            this.ClientSize = new System.Drawing.Size(258, 116);
            this.Controls.Add(this.bCancle);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.udWidth);
            this.Controls.Add(this.bColor);
            this.Controls.Add(this.label1);
            this.Name = "PenSet";
            this.Text = "PenSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancle;
        public System.Windows.Forms.Button bColor;
        public System.Windows.Forms.DomainUpDown udWidth;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton3;
    }
}