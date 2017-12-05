using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.UserControls.FlatControls
{
    public partial class FlatRichTextBox : UserControl
    {
        public FlatRichTextBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return flatRtb.Text; }
            set => flatRtb.Text = value;
        }

        private void flatRtb_MouseEnter(object sender, EventArgs e)
        {
            flatRtb.BackColor = Colors.FlatRtbMouseEnterColor;
        }

        private void flatRtb_MouseLeave(object sender, EventArgs e)
        {
            if(!flatRtb.Focused)
                flatRtb.BackColor = Colors.FlatRtbMouseLeaveColor;
        }

        private void flatRtb_Leave(object sender, EventArgs e)
        {
            flatRtb.BackColor = Colors.FlatRtbMouseLeaveColor;
            this.Invalidate();
        }

        private void FlatRichTextBox_Paint(object sender, PaintEventArgs e)
        {
            if(flatRtb.Focused)
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Colors.FlatRtbFocusedBorderColor, ButtonBorderStyle.Solid);
        }

        private void FlatRichTextBox_Resize(object sender, EventArgs e)
        {
            flatRtb.Size = new Size(this.Width - 6, this.Height - 6);

            flatRtb.Location = new Point(1, 1);
        }

        private void flatRtb_Enter(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
