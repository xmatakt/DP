using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.Forms.Dashboard
{
    public partial class AddItemToBillingForm : Form
    {
        public string ItemName { get; private set; }
        public int Count { get; private set; }
        public decimal Price { get; private set; }

        #region Private properties
        private string itemName
        {
            get
            {
                string result = itemNameTextBox.Text.Trim();

                if (result.Length == 0)
                    result = null;

                return result;
            }
            set { itemNameTextBox.Text = value; }
        }

        private int count
        {
            get { return (int)countUpDown.Value; }
            set { countUpDown.Value = value; }
        }

        private decimal price
        {
            get { return priceUpDown.Value; }
            set { priceUpDown.Value = value; }
        }
        #endregion

        public AddItemToBillingForm()
        {
            InitializeComponent();

            countUpDown.Maximum = int.MaxValue;
            priceUpDown.Maximum = decimal.MaxValue;
        }

        #region Private methods
        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if (itemName == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať názov položky");
                    itemNameTextBox.Focus();
                    result = false;
                }
                else if(count <= 0)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať kladný počet");
                    countUpDown.Focus();
                    result = false;
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        private void AddBillingItem()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    ItemName = itemName;
                    Count = count;
                    Price = price;
                }
                else
                    DialogResult = DialogResult.None;
            
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            Cursor = Cursors.Default;
        }
        #endregion

        #region MainPannelDragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topMenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region HandleCloseButtonEvents
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            closeFormPictureBox.Image = Properties.Resources.closeForm_active_32;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            closeFormPictureBox.Image = Properties.Resources.closeForm_32;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region UI Events
        private void addButton_Click(object sender, EventArgs e)
        {
            AddBillingItem();
        }
        #endregion
    }
}
