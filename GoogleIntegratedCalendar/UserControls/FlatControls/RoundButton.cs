using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.UserControls.FlatControls
{
    public class RoundButton : Button
    {
        public event EventHandler RoundButtonStyleChanged;
        protected virtual void OnRoundButtonStyleChanged()
        {
            RoundButtonStyleChanged?.Invoke(this, EventArgs.Empty);
        }

        private RoundButtonStylesEnum roundButtonStyle = RoundButtonStylesEnum.FlatBlue;
        public RoundButtonStylesEnum RoundButtonStyle
        {
            get { return roundButtonStyle; }
            set
            {
                if(roundButtonStyle != value)
                {
                    roundButtonStyle = value;
                    SetButtonStyle();
                }
            }
        }
        public int Radius{ get; set; }

        public RoundButton()
        {
            
            RoundButtonStyle = RoundButtonStylesEnum.FlatBlue;
            Radius = 5;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            ForeColor = Color.White;
            Font = new Font(Font, FontStyle.Bold);

            SetButtonStyle();
        }

        public void SetButtonStyle()
        {
            switch (roundButtonStyle)
            {
                case RoundButtonStylesEnum.FlatBlue:
                    BackColor = Colors.FlatButtonColorBlue;
                    FlatAppearance.MouseDownBackColor = Colors.MouseDownFlatButtonColorBlue;
                    FlatAppearance.MouseOverBackColor = Colors.MouseDownFlatButtonColorBlue;
                    break;
                case RoundButtonStylesEnum.FlatRed:
                    BackColor = Colors.FlatButtonColorRed;
                    FlatAppearance.MouseDownBackColor = Colors.MouseDownFlatButtonColorRed;
                    FlatAppearance.MouseOverBackColor = Colors.MouseDownFlatButtonColorRed;
                    break;
                case RoundButtonStylesEnum.FlatGreen:
                    BackColor = Colors.FlatButtonColorGreen;
                    FlatAppearance.MouseDownBackColor = Colors.MouseDownFlatButtonColorGreen;
                    FlatAppearance.MouseOverBackColor = Colors.MouseDownFlatButtonColorGreen;
                    break;
                case RoundButtonStylesEnum.FlatOrange:
                    BackColor = Colors.FlatButtonColorOrange;
                    FlatAppearance.MouseDownBackColor = Colors.MouseDownFlatButtonColorOrange;
                    FlatAppearance.MouseOverBackColor = Colors.MouseDownFlatButtonColorOrange;
                    break;
                case RoundButtonStylesEnum.FlatLightBlue:
                    BackColor = Colors.FlatButtonColorLightBlue;
                    FlatAppearance.MouseDownBackColor = Colors.MouseDownFlatButtonColorLightBlue;
                    FlatAppearance.MouseOverBackColor = Colors.MouseDownFlatButtonColorLightBlue;
                    break;
                default:
                    break;
            }

            //Invalidate();
        }

        GraphicsPath GetRoundPath(RectangleF Rect)
        {
            float r2 = Radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            //GraphPath.AddArc(Rect.X, Rect.Y, Radius, Radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            ////GraphPath.AddArc(Rect.X + Rect.Width - Radius, Rect.Y, Radius, Radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            ////GraphPath.AddArc(Rect.X + Rect.Width - Radius,
            ////Rect.Y + Rect.Height - Radius, Radius, Radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            ////GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - Radius, Radius, Radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

            GraphPath.CloseFigure();

            return GraphPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, Width, Height);
            GraphicsPath GraphPath = GetRoundPath(Rect);

            Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.Transparent, 5))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, GraphPath);
            }
        }
    }
}
