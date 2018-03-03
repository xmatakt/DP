using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.UserControls.Administration
{
    public partial class AdminMenuItem : UserControl
    {
        private Image onLeaveMenuItemImage;
        private Image onHoverMenuItemImage;
        private Color onHoverTextForeColor = Color.Black;
        private Color textForeColor = Color.White;
        private Color backColor;

        #region CustomEventHandlers
        public event EventHandler ListButtonClick;
        public event EventHandler AddButtonClick;
        #endregion

        #region PublicSettings
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

        public Color TextForeColor
        {
            get
            { return textForeColor; }
            set
            {
                textForeColor = value;
                descriptionLabel.ForeColor = textForeColor;
            }
        }

        public Color OnHoverTextForeColor
        {
            get { return onHoverTextForeColor; }
            set { onHoverTextForeColor = value; }
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

        public Color AdminItemBackColor
        {
            get
            { return backColor; }
            set
            {
                backColor = value;
                BackColor = backColor;
            }
        }

        public string TooltipText
        {
            get { return toolTip.GetToolTip(descriptionLabel); }
            set { toolTip.SetToolTip(descriptionLabel, value); }
        }
        #endregion

        public AdminMenuItem()
        {
            InitializeComponent();
            showListButton.Click += showListButton_Click;
            backColor = BackColor;
        }

        #region Events
        private void MenuItem_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
            descriptionLabel.ForeColor = onHoverTextForeColor;
            Cursor = Cursors.Hand;
            if (onHoverMenuItemImage == null)
                return;

            MenuItemImage = onHoverMenuItemImage;
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = backColor;
            descriptionLabel.ForeColor = textForeColor;
            Cursor = Cursors.Default;
            if (onLeaveMenuItemImage == null)
                return;

            MenuItemImage = onLeaveMenuItemImage;
        }

        protected void showListButton_Click(object sender, EventArgs e)
        {
            if (ListButtonClick != null)
                ListButtonClick(this, e);
        }
        #endregion

        private void addButton_Click(object sender, EventArgs e)
        {
            if (AddButtonClick != null)
                AddButtonClick(this, e);
        }
    }
}
