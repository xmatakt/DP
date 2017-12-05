using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.UserControls.Dashboard
{
    /// <summary>
    /// User control used in MainForm on the main menu panel
    /// </summary>
    public partial class MenuItem : UserControl
    {
        private Image onLeaveMenuItemImage;
        private Image onHoverMenuItemImage;
        private Color onHoverTextForeColor = Colors.MouseHoverMenuItemColor;
        private Color textForeColor = Color.White;

        public event MouseEventHandler TransparentPanelMouseClick;

        protected void TransparentPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //https://stackoverflow.com/questions/7880850/how-do-i-make-an-event-in-the-usercontrol-and-have-it-handeled-in-the-main-form
            //bubble the event up to the parent
            if (TransparentPanelMouseClick != null)
                TransparentPanelMouseClick(this, e);
        }

        public Color TextForeColor
        {
            get { return textForeColor; }
            set { textForeColor = value; }
        }

        public Color OnHoverTextForeColor
        {
            get { return onHoverTextForeColor; }
            set { onHoverTextForeColor = value; }
        }

        public string MenuItemText
        {
            get { return descriptionLabel.Text; }
            set { descriptionLabel.Text = value; }
        }

        public Image MenuItemImage
        {
            get { return menuItemPictureBox.Image; }
            set { menuItemPictureBox.Image = value; }
        }

        public Image OnLeaveMenuItemImage
        {
            get { return onLeaveMenuItemImage; }
            set { onLeaveMenuItemImage = value; }
        }

        public Image OnHoverMenuItemImage
        {
            get { return onHoverMenuItemImage; }
            set { onHoverMenuItemImage = value; }
        }

        public MenuItem()
        {
            InitializeComponent();
            transparentPanel.MouseClick += TransparentPanel_MouseClick;
        }

        private void MenuItem_MouseHover(object sender, EventArgs e)
        {
            descriptionLabel.ForeColor = onHoverTextForeColor;
            Cursor = Cursors.Hand;
            if (onHoverMenuItemImage == null)
                return;

            MenuItemImage = onHoverMenuItemImage;
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            descriptionLabel.ForeColor = textForeColor;
            Cursor = Cursors.Default;
            if (onLeaveMenuItemImage == null)
                return;

            MenuItemImage = onLeaveMenuItemImage;
        }
    }
}
