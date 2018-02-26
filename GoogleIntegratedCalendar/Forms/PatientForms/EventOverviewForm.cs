using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using DatabaseCommunicator.Model;
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

namespace EZKO.Forms.PatientForms
{
    public partial class EventOverviewForm : System.Windows.Forms.Form
    {
        private EzkoController ezkoController;
        private CalendarEvent calendarEvent;
        private DateTime? paymentDateDate = null;

        #region Private properties
        string patientName { set { patientLabel.Text = value; } }
        string eventDate { set { dateLabel.Text = value; } }
        string state { set { stateLabel.Text = value; } }
        string paymentDate { set { paymentDateLabel.Text = value; } }
        string doneText
        {
            get { return doneActionsRichTextBox.Text.ToString(); }
            set { doneActionsRichTextBox.Text = value; }
        }
        #endregion

        public EventOverviewForm(CalendarEvent calendarEvent)
        {
            InitializeComponent();

            try
            {
                ezkoController = GlobalSettings.EzkoController;
                this.calendarEvent = calendarEvent;

                patientName = calendarEvent.Patient.FullName;
                eventDate = calendarEvent.StartDate.ToString("dd.MM.yyyy HH:mm");
                state = calendarEvent.EventState.ToString().ToLower();
                if (calendarEvent.PaymentDate.HasValue)
                {
                    paymentDateLabel.Font = new Font(paymentDateLabel.Font, FontStyle.Regular);
                    paymentDate = calendarEvent.PaymentDate.Value.ToString("dd.MM.yyyy HH:mm");
                    payEventButton.Visible = false;
                }
                else if(calendarEvent.StateID != (int)EventStateEnum.Done)
                    payEventButton.Visible = false;

                doneText = calendarEvent.ExecutedActionText;

                InitializeDoneActionsGrid();
                InitializeBillingGrid();
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri načítaní podrobností o návšteve sa vyskytla chyba", ex);
            }
        }

        #region Private methods
        private void InitializeDoneActionsGrid()
        {
            actionsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            actionsDataGridView.GridColor = Color.White;
            actionsDataGridView.AllowUserToResizeRows = false;
            actionsDataGridView.AllowUserToResizeColumns = true;
            actionsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            actionsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            actionsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            actionsDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            actionsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            actionsDataGridView.BackgroundColor = Color.White;
            actionsDataGridView.EnableHeadersVisualStyles = false;
            actionsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            actionsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            actionsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            actionsDataGridView.RowHeadersVisible = false;
            actionsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            DataGridViewTextBoxColumn actionColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Action",
                HeaderText = "Výkon",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
                FillWeight = 40f,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            actionsDataGridView.Columns.Add(actionColumn);

            DataGridViewTextBoxColumn outputColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Note",
                HeaderText = "Výstup",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 60f,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            outputColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            actionsDataGridView.Columns.Add(outputColumn);

            FillActionsGrid();
        }

        private void InitializeBillingGrid()
        {
            billingDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            billingDataGridView.GridColor = Color.White;
            billingDataGridView.AllowUserToResizeRows = false;
            billingDataGridView.AllowUserToResizeColumns = true;
            billingDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            billingDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            billingDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            billingDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            billingDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            billingDataGridView.BackgroundColor = Color.White;
            billingDataGridView.EnableHeadersVisualStyles = false;
            billingDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            billingDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            billingDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            billingDataGridView.RowHeadersVisible = false;
            billingDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            DataGridViewTextBoxColumn itemsColumn = new DataGridViewTextBoxColumn()
            {
                Name = "ItemName",
                HeaderText = "Položka",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            billingDataGridView.Columns.Add(itemsColumn);

            DataGridViewTextBoxColumn countColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Count",
                HeaderText = "Počet",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            billingDataGridView.Columns.Add(countColumn);

            DataGridViewTextBoxColumn discountColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Discount",
                HeaderText = "Zľava",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            };
            billingDataGridView.Columns.Add(discountColumn);


            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Price",
                HeaderText = "Jedn. cena",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            priceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            billingDataGridView.Columns.Add(priceColumn);

            FillBillingGrid();
        }

        private void FillActionsGrid()
        {
            actionsDataGridView.Rows.Clear();

            foreach (var item in calendarEvent.CalendarEventExecutedActions)
            {
                int rowIndex = actionsDataGridView.Rows.Add(new object[]
                { item.Action.Name, item.ExecutedActionNote.Note });

                actionsDataGridView.Rows[rowIndex].Tag = item;
                if (!item.Action.HasSpecification)
                {
                    actionsDataGridView.Rows[rowIndex].ReadOnly = true;
                    actionsDataGridView.Rows[rowIndex].Cells["Note"].Value = "výkon nemá špecifikáciu";
                }
            }
        }

        private void FillBillingGrid()
        {
            EventBill bill = calendarEvent.EventBills.FirstOrDefault();
            if (bill == null)
                return;

            billingDataGridView.Rows.Clear();

            foreach (var item in bill.EventBillItems)
            {
                int rowIndex = billingDataGridView.Rows.Add(new object[]
                { item.Name, item.Count.ToString("0 ks"), item.Discount.ToString("0.00 €"), item.UnitPrice.ToString("0.00 €") });
            }

            int lastRowIndex = billingDataGridView.Rows.Add(new object[]
                { "Spolu:",
                    bill.EventBillItems.Sum(x => x.Count).ToString("0 ks"),
                    "Cena so zľavou:",
                    bill.EventBillItems.Sum(x => x.Count *  x.UnitPrice - x.Discount).ToString("0.00 €")
                });
            billingDataGridView.Rows[lastRowIndex].DefaultCellStyle.ForeColor = Color.White;
            billingDataGridView.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.Black;
            billingDataGridView.Rows[lastRowIndex].Cells["Price"].Style.ForeColor = Colors.FlatButtonColorGreen;
            billingDataGridView.Rows[lastRowIndex].Cells["Discount"].Style.ForeColor = Colors.FlatButtonColorOrange;
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {

            }
            catch (Exception e)
            {
                result = false;
                BasicMessagesHandler.LogException(e);
            }

            return result;
        }
        private void UpdateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    calendarEvent.ExecutedActionText = doneText.Trim();
                    for (int row = 0; row < actionsDataGridView.RowCount; row++)
                    {
                        CalendarEventExecutedAction action = actionsDataGridView.Rows[row].Tag as CalendarEventExecutedAction;

                        if(action != null && action.Action.HasSpecification)
                            action.ExecutedActionNote.Note = actionsDataGridView.Rows[row].Cells["Note"].Value.ToString().Trim();
                    }

                    if(paymentDateDate.HasValue)
                    {
                        calendarEvent.StateID = (int)DatabaseCommunicator.Enums.EventStateEnum.Payed;
                        calendarEvent.PaymentDate = paymentDateDate;
                    }

                    if(!ezkoController.SaveChanges())
                        BasicMessagesHandler.ShowErrorMessage("Pri ukladaní zmien sa vyskytla chyba!");
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
        private void payEventButton_Click(object sender, EventArgs e)
        {
            payEventButton.Visible = false;
            paymentDateDate = DateTime.Now;
            paymentDate = paymentDateDate.Value.ToString("dd.MM.yyyy HH:mm");
            paymentDateLabel.Font = new Font(paymentDateLabel.Font, FontStyle.Regular);
            state = ezkoController.GetEventState(DatabaseCommunicator.Enums.EventStateEnum.Payed).ToString().ToLower();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        #endregion
    }
}
