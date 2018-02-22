using DatabaseCommunicator.Controllers;
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

namespace EZKO.Forms.AdministrationForms
{
    public partial class EditBudgetForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private Budget budget;
        private int countSum = 0;
        private decimal priceSum = 0m;

        #region Private properties
        private string name
        {
            get
            {
                string val = nameTextBox.Text.Trim();
                if (val.Length < 1)
                    val = null;

                return val;
            }
            set { nameTextBox.Text = value; }
        }

        private Patient patient
        {
            get { return patientTextBox.Tag as Patient; }
            set
            {
                patientTextBox.Tag = value;
                patientTextBox.Text = value.FullName;
            }
        }

        private string itemName
        {
            get
            {
                string val = itemNameTextBox.Text.Trim();
                if (val.Length < 1)
                    val = null;

                return val;
            }
            set { itemNameTextBox.Text = value; }
        }

        private int count
        {
            get{ return (int)countUpDown.Value; }
            set { countUpDown.Value = value; }
        }

        private decimal price
        {
            get { return priceUpDown.Value; }
            set { priceUpDown.Value = value; }
        }
        #endregion

        public EditBudgetForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            this.workingType = workingType;
            patientTextBox.Values = ezkoController.GetPatients().ToArray();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.White;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.RowHeadersVisible = false;

            InitializeDataGridView();
        }

        public EditBudgetForm(WorkingTypeEnum workingType, Patient patient) : this(workingType)
        {
            this.patient = patient;
            patientTextBox.Enabled = false;
        }

        public EditBudgetForm(Budget budget)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.budget = budget;
            patientTextBox.ReadOnly = true;
            patientTextBox.Values = ezkoController.GetPatients().ToArray();
            addButton.Text = "Upraviť rozpočet";

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.White;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.RowHeadersVisible = false;

            InitializeDataGridView();

            InitializeForm();
        }

        #region Private methods

        private void InitializeForm()
        {
            if(budget != null)
            {
                name = budget.Name;
                patient = budget.Patient;

                foreach (var item in budget.BudgetItems)
                {
                    int index = dataGridView.Rows.Count - 1;
                    dataGridView.Rows.Insert(index, new object[]
                    { item.Name, GetCountString(item.Count), GetPriceString(item.UnitPrice), "", "x"});

                    dataGridView.ClearSelection();
                    dataGridView.Rows[index].Selected = true;

                    countSum += item.Count;
                    priceSum += (item.Count * item.UnitPrice);
                }

                UpdateSumRow();
            }
        }

        private void InitializeDataGridView()
        {
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Položka",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            dataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn countColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Count",
                HeaderText = "Počet",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            dataGridView.Columns.Add(countColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Price",
                HeaderText = "Cena",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            dataGridView.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            dataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn()
            {
                Name = "Remove",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            removeColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorRed;
            removeColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorRed;
            dataGridView.Columns.Add(removeColumn);

            int index = dataGridView.Rows.Add(new object[]
               { "Spolu", GetCountString(), GetPriceString(), "", ""});

            dataGridView.Rows[index].DefaultCellStyle.BackColor = Color.Black;
            dataGridView.Rows[index].DefaultCellStyle.ForeColor = Color.White;
            dataGridView.Rows[index].Cells["Remove"] = new DataGridViewTextBoxCell();
        }

        private void CreateOrUpdate()
        {
            switch (workingType)
            {
                case WorkingTypeEnum.Creating:
                    CreateData();
                    break;
                case WorkingTypeEnum.Editing:
                    UpdateData();
                    break;
                default:
                    break;
            }
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if (name == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať názov rozpočtu");
                    nameTextBox.Focus();
                    result = false;
                }
                else if (patient == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte vybrať pacienta");
                    patientTextBox.Focus();
                    result = false;
                }
                else if (dataGridView.Rows.Count <= 1)
                {
                    BasicMessagesHandler.ShowInformationMessage("Rozpočet musí obsahovať aspoň jednu položku");
                    patientTextBox.Focus();
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

        private void CreateData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    List<BudgetItem> budgetItems = GetBudgetItems();
                    if (budgetItems != null && ezkoController.CreateBudget(name, patient, budgetItems))
                        BasicMessagesHandler.ShowInformationMessage("Rozpočet bol úspešne vytvorený");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas vytvárania rozpočtu sa vyskytla chyba");
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
                    List<BudgetItem> budgetItems = GetBudgetItems();
                    if (budgetItems == null || !ezkoController.EditBudget(budget, name, budgetItems))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy rozpočtu sa vyskytla chyba");
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

        private void UpdateSumRow()
        {
            int sumRowIndex = dataGridView.Rows.Count - 1;

            DataGridViewRow sumRow = dataGridView.Rows[sumRowIndex];
            sumRow.Cells["Count"].Value = GetCountString(countSum);
            sumRow.Cells["Price"].Value = GetPriceString(priceSum);
        }

        private string GetPriceString(decimal? value = null)
        {
            if(value == null)
                return price.ToString("0.00 €");
            else
                return value.Value.ToString("0.00 €");
        }
        private string GetCountString(int? value = null)
        {
            if(value == null)
                return count + " ks";
            else
                return value + " ks";
        }

        private List<BudgetItem> GetBudgetItems()
        {
            List<BudgetItem> result = new List<BudgetItem>();
            try
            {
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    DataGridViewRow gridRow = dataGridView.Rows[i];
                    BudgetItem budgetItem = new BudgetItem()
                    {
                        Name = gridRow.Cells["Name"].Value.ToString(),
                        Count = int.Parse(gridRow.Cells["Count"].Value.ToString().Split(new[] { ' ' })[0]),
                        UnitPrice = decimal.Parse(gridRow.Cells["Price"].Value.ToString().Split(new[] { ' ' })[0]),
                    };
                    result.Add(budgetItem);
                }

            }
            catch(Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Po4as vytvárania rozpočtu sa vyskytla chyba", ex);
                result = null;
            }

            return result;
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
        private void EditBudgetForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 1000;
            itemNameTextBox.MaxLength = 255;
            countUpDown.Maximum = int.MaxValue;
            priceUpDown.Maximum = decimal.MaxValue;
        }

        private void addBudgetItemButton_Click(object sender, EventArgs e)
        {
            countSum += count;
            priceSum += (count * price);

            if (itemName != null)
            {
                int index = dataGridView.Rows.Count - 1;
                dataGridView.Rows.Insert(index, new object[]
                { itemName, GetCountString(), GetPriceString(), "", "x"});

                dataGridView.ClearSelection();
                dataGridView.Rows[index].Selected = true;

                //dataGridView.Rows.Insert(0, new object[]
                //{ itemName, GetCountString(), GetPriceString(), "", "x"});

                UpdateSumRow();
            }
            else
            {
                BasicMessagesHandler.ShowInformationMessage("Musíte zadať názov položky");
                itemNameTextBox.Focus();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                    {
                        DataGridViewRow clickedRow = senderGrid.Rows[e.RowIndex];
                        int countToRemove = int.Parse(clickedRow.Cells["Count"].Value.ToString().Split(new[] { ' ' })[0]);
                        decimal priceToRemove = decimal.Parse(clickedRow.Cells["Price"].Value.ToString().Split(new[] { ' ' })[0]);

                        countSum -= countToRemove;
                        priceSum -= (countToRemove * priceToRemove);

                        senderGrid.Rows.RemoveAt(e.RowIndex);

                        UpdateSumRow();
                    }
            }
            catch(Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri pokuse o odstránenie položky sa vyskytla chyba", ex);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        #endregion
    }
}
