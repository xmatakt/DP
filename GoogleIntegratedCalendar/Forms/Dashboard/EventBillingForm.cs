using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Enums;
using EZKO.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Model;

namespace EZKO.Forms.Dashboard
{
    public partial class EventBillingForm : System.Windows.Forms.Form
    {
        private EzkoController ezkoController;
        private CalendarEvent calendarEvent;
        ICollection<DatabaseCommunicator.Model.Action> executedActions;
        private int countSum = 0;
        private decimal priceSum = 0m;
        private decimal discountSum = 0m;

        #region Private properties
        private string name
        {
            get { return itemNameTextBox.Text.Trim(); }
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

        private decimal discount
        {
            get { return discountUpDown.Value; }
            set { discountUpDown.Value = value; }
        }
        #endregion

        public EventBillingForm(CalendarEvent calendarEvent, ICollection<DatabaseCommunicator.Model.Action> executedActions)
        {
            InitializeComponent();

            countUpDown.Minimum = 1;
            countUpDown.Maximum = int.MaxValue;
            priceUpDown.Maximum = decimal.MaxValue;
            discountUpDown.Maximum = decimal.MaxValue;

            this.executedActions = executedActions;
            this.calendarEvent = calendarEvent;
            ezkoController = GlobalSettings.EzkoController;
            InitializeGrid();
            FillGrid();
        }

        #region Private methods
        private void InitializeGrid()
        {
            billingItemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            billingItemsGridView.GridColor = Color.White;
            billingItemsGridView.AllowUserToResizeRows = false;
            billingItemsGridView.AllowUserToResizeColumns = true;
            billingItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            billingItemsGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            billingItemsGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            billingItemsGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            billingItemsGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            billingItemsGridView.BackgroundColor = Color.White;
            billingItemsGridView.EnableHeadersVisualStyles = false;
            billingItemsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            billingItemsGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            billingItemsGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            billingItemsGridView.RowHeadersVisible = false;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Položka",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            billingItemsGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn countColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Count",
                HeaderText = "Počet",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            billingItemsGridView.Columns.Add(countColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Price",
                HeaderText = "Jedn. cena",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            billingItemsGridView.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn discountColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Discount",
                HeaderText = "Zľava",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            billingItemsGridView.Columns.Add(discountColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            fillEmptySpaceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            billingItemsGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn()
            {
                Name = "Remove",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            removeColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorRed;
            removeColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorRed;
            billingItemsGridView.Columns.Add(removeColumn);


            // add and format sum row
            int index = billingItemsGridView.Rows.Add(new object[]
               { "Spolu", GetCountString(countSum), GetPriceString(priceSum), GetPriceString(discountSum), "Cena so zľavou:", ""}
            );

            billingItemsGridView.Rows[index].DefaultCellStyle.BackColor = Color.Black;
            billingItemsGridView.Rows[index].DefaultCellStyle.ForeColor = Color.White;
            billingItemsGridView.Rows[index].Cells["Remove"] = new DataGridViewTextBoxCell();
            billingItemsGridView.Rows[index].Cells["Remove"].Value = GetPriceString(priceSum - discountSum);
        }

        private void FillGrid()
        {
            foreach (var action in executedActions)
            {
                int index = billingItemsGridView.Rows.Count - 1;
                billingItemsGridView.Rows.Insert(index, new object[]
                { action.Name, GetCountString(1), GetPriceString(action.Costs + action.Margin), GetPriceString(0m), "", "x"});

                billingItemsGridView.ClearSelection();
                billingItemsGridView.Rows[index].Selected = true;
                billingItemsGridView.Rows[index].Tag = action;

                //disable removing done actions
                //billingItemsGridView.Rows[index].Cells["Remove"].Enabled = true;

                countSum += 1;
                priceSum += (action.Costs + action.Margin);

                UpdateSumRow();
            }
        }

        private void UpdateSumRow()
        {
            int sumRowIndex = billingItemsGridView.Rows.Count - 1;

            DataGridViewRow sumRow = billingItemsGridView.Rows[sumRowIndex];
            sumRow.Cells["Count"].Value = GetCountString(countSum);
            sumRow.Cells["Price"].Value = GetPriceString(priceSum);
            sumRow.Cells["Discount"].Value = GetPriceString(discountSum);
            sumRow.Cells["Remove"].Value = GetPriceString(priceSum - discountSum);
            sumRow.Cells["Last"].Style.ForeColor = Colors.FlatButtonColorGreen;
            sumRow.Cells["Remove"].Style.ForeColor = Colors.FlatButtonColorOrange;
        }

        private string GetPriceString(decimal value)
        {
            return value.ToString("0.00 €");
        }
        private string GetCountString(int value)
        {
            return value + " ks";
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if (priceSum < 0)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Hodnota výsledného účtu nesmie byť záporná!");
                }
                else if (calendarEvent == null)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Nepodarilo sa načítať návštevu");
                }
            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }

        private List<EventBillItem> GetBillItems()
        {
            List<EventBillItem> result = new List<EventBillItem>();
            try
            {
                for (int row = 0; row < billingItemsGridView.RowCount - 1; row++)
                {
                    DataGridViewRow gridRow = billingItemsGridView.Rows[row];
                    EventBillItem billItem = new EventBillItem()
                    {
                        Name = gridRow.Cells["Name"].Value.ToString().Trim(),
                        Count = int.Parse(gridRow.Cells["Count"].Value.ToString().Split(new[] { ' ' })[0]),
                        UnitPrice = decimal.Parse(gridRow.Cells["Price"].Value.ToString().Split(new[] { ' ' })[0]),
                        Discount = decimal.Parse(gridRow.Cells["Discount"].Value.ToString().Split(new[] { ' ' })[0])
                    };
                    result.Add(billItem);
                }
            }
            catch (Exception ex)
            {
                result = null;
                BasicMessagesHandler.ShowErrorMessage("Počas vytvárania položiek účtu sa vyskytla chyba!", ex);
            }

            return result;
        }

        private void CreateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    List<EventBillItem> billItems = GetBillItems();

                    if (billItems == null)
                        DialogResult = DialogResult.None;
                    else
                    {
                        if(!ezkoController.CreateEventBill(calendarEvent, billItems))
                        {
                            DialogResult = DialogResult.None;
                            BasicMessagesHandler.ShowErrorMessage("Účet sa nepodarilo vytvoriť");
                        }
                    }
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

        private void UpdateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {

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

        #region HandleMaximizeButtonEvents
        private void maximizeFormPictureBox_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_32;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_32;
            }
        }

        private void maximizeFormPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_active_32;
            else
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_active_32;
        }

        private void maximizeFormPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_32;
            else
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_32;
        }
        #endregion

        #region HandleMinimizeButtonEvents
        private void minimizeFormPictureBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void minimizeFormPictureBox_MouseEnter(object sender, EventArgs e)
        {
            minimizeFormPictureBox.Image = Properties.Resources.toTaskbar_active_32;
        }

        private void minimizeFormPictureBox_MouseLeave(object sender, EventArgs e)
        {
            minimizeFormPictureBox.Image = Properties.Resources.toTaskbar_32;
        }
        #endregion

        #region UI Events
        private void addItemButton_Click(object sender, EventArgs e)
        {
            AddItemToBillingForm form = new AddItemToBillingForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                countSum += form.Count;
                priceSum += form.Price * form.Count;

                int index = billingItemsGridView.Rows.Count - 1;
                billingItemsGridView.Rows.Insert(index, new object[]
                { form.ItemName, GetCountString(form.Count), GetPriceString(form.Price), GetPriceString(0m), " ", "x"});

                billingItemsGridView.ClearSelection();
                billingItemsGridView.Rows[index].Selected = true;

                UpdateSumRow();
            }
        }

        private void billingItemsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;
                DataGridViewRow clickedRow = senderGrid.Rows[e.RowIndex];
                int lastRowIndex = senderGrid.RowCount - 1;

                if (!(e.RowIndex >= 0 && e.RowIndex != lastRowIndex))
                    return;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                    {
                        //don't allow to remove action rows
                        if (clickedRow.Tag is DatabaseCommunicator.Model.Action)
                        {
                            BasicMessagesHandler.ShowInformationMessage("Riadok nemožno odstrániť");
                            return;
                        }

                        int countToRemove = int.Parse(clickedRow.Cells["Count"].Value.ToString().Split(new[] { ' ' })[0]);
                        decimal priceToRemove = decimal.Parse(clickedRow.Cells["Price"].Value.ToString().Split(new[] { ' ' })[0]);
                        decimal discountToRemove = decimal.Parse(clickedRow.Cells["Discount"].Value.ToString().Split(new[] { ' ' })[0]);

                        countSum -= countToRemove;
                        priceSum -= (countToRemove * priceToRemove);
                        discountSum -= discountToRemove;

                        senderGrid.Rows.RemoveAt(e.RowIndex);

                        UpdateSumRow();
                    }
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri pokuse o odstránenie položky sa vyskytla chyba", ex);
            }
        }

        private void billingItemsGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                itemNameTextBox.ReadOnly = false;
                priceUpDown.ReadOnly = false;
                DataGridView senderGrid = (DataGridView)sender;
                DataGridViewRow clickedRow = senderGrid.Rows[e.RowIndex];
                int lastRowIndex = senderGrid.RowCount - 1;

                if (e.RowIndex == lastRowIndex)
                {
                    ClearUpdateElements();
                }
                else
                {
                    itemNameTextBox.Tag = clickedRow;
                    name = clickedRow.Cells["Name"].Value.ToString().Trim();
                    count = int.Parse(clickedRow.Cells["Count"].Value.ToString().Split(new[] { ' ' })[0]);
                    price = decimal.Parse(clickedRow.Cells["Price"].Value.ToString().Split(new[] { ' ' })[0]);
                    discount = decimal.Parse(clickedRow.Cells["Discount"].Value.ToString().Split(new[] { ' ' })[0]);

                    if (clickedRow.Tag is DatabaseCommunicator.Model.Action)
                    {
                        itemNameTextBox.ReadOnly = true;
                        priceUpDown.ReadOnly = true;
                        countUpDown.Focus();
                    }
                    else
                        itemNameTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Nepodarilo sa načítať riadok", ex);
            }
        }

        private void ClearUpdateElements()
        {
            itemNameTextBox.Tag = null;
            name = "";
            count = 1;
            price = 0;
            discount = 0;
        }

        private void addBudgetItemButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow gridRow = itemNameTextBox.Tag as DataGridViewRow;

            if (gridRow != null)
            {
                string oldName = gridRow.Cells["Name"].Value.ToString().Trim();
                int oldCount = int.Parse(gridRow.Cells["Count"].Value.ToString().Split(new[] { ' ' })[0]);
                decimal oldPrice = decimal.Parse(gridRow.Cells["Price"].Value.ToString().Split(new[] { ' ' })[0]);
                decimal oldDiscount = decimal.Parse(gridRow.Cells["Discount"].Value.ToString().Split(new[] { ' ' })[0]);

                countSum += count - oldCount;
                priceSum -= oldCount * oldPrice;
                priceSum += count * price;
                discountSum += discount - oldDiscount;

                gridRow.Cells["Name"].Value = name;
                gridRow.Cells["Count"].Value = GetCountString(count);
                gridRow.Cells["Price"].Value = GetPriceString(price);
                gridRow.Cells["Discount"].Value = GetPriceString(discount);

                ClearUpdateElements();
                UpdateSumRow();
            }
        }

        private void countUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update maximum discount value to don't allow to make negative total bill sum
            decimal maxDiscount = count * price;

            if (discount > maxDiscount)
                discount = maxDiscount;

            discountUpDown.Maximum = maxDiscount;
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            CreateData();
        }
        #endregion
    }
}
