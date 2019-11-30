using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KJBL
{
    public partial class PenSet : Form
    {
        public PenSet()
        {
            InitializeComponent();
        }

        private void bColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)

                bColor.BackColor = colorDialog1.Color;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
           
        }
    }
}