using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using EZKO.Forms.AdministrationForms;
using ExceptionHandler;

namespace EZKO.UserControls.Administration
{
    public partial class FormularsControlPanel : UserControl
    {
        private EzkoController ezkoController;
        private DatabaseCommunicator.Model.Form formular;

        public FormularsControlPanel()
        {
            InitializeComponent();
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

            ezkoController = GlobalSettings.EzkoController;

            InitializeDataGridView();
            FillDataGridView();
        }

        #region Public methods
        public void UpdateControl()
        {
            FillDataGridView();
        }
        #endregion

        #region Private methods
        private void InitializeDataGridView()
        {
            DataGridViewTextBoxColumn IDColumn = new DataGridViewTextBoxColumn()
            {
                Name = "ID",
                HeaderText = "ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            IDColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add(IDColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Názov",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            dataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            dataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn fillColumn = new DataGridViewButtonColumn()
            {
                Name = "Fill",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            fillColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorGreen;
            fillColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorGreen;
            dataGridView.Columns.Add(fillColumn);

            DataGridViewButtonColumn pdfColumn = new DataGridViewButtonColumn()
            {
                Name = "Pdf",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            pdfColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorLightBlue;
            pdfColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorLightBlue;
            dataGridView.Columns.Add(pdfColumn);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            editColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorBlue;
            editColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorBlue;
            dataGridView.Columns.Add(editColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn()
            {
                Name = "Remove",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            removeColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorRed;
            removeColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorRed;
            dataGridView.Columns.Add(removeColumn);
        }

        private void FillDataGridView()
        {
            dataGridView.Rows.Clear();

            foreach (var item in ezkoController.GetFormulars())
            {
                int rowIndex = dataGridView.Rows.Add(new object[]
                { item.ID, item.Name, "", "Vyplniť","PDF", "Upraviť", "Zmazať"});

                dataGridView.Rows[rowIndex].Tag = item;
            }
        }

        private void EditItem(DatabaseCommunicator.Model.Form item)
        {
            EditFormularForm form = new EditFormularForm(item);
            if (form.ShowDialog() == DialogResult.OK)
                FillDataGridView();
        }

        private void RemoveItem(DatabaseCommunicator.Model.Form item)
        {
            if (MessageBox.Show("Naozaj si želáte odstrániť formulár " + item.Name, "?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!ezkoController.RemoveFormular(item))
                    BasicMessagesHandler.ShowErrorMessage("Formulár sa nepodarilo odstrániť");
                else
                    FillDataGridView();
            }
        }
        #endregion

        #region UI events
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DatabaseCommunicator.Model.Form item = senderGrid.Rows[e.RowIndex].Tag as DatabaseCommunicator.Model.Form;
                if (senderGrid.Columns[e.ColumnIndex].Name == "Edit")
                    EditItem(item);
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                    RemoveItem(item);
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Fill")
                    BasicMessagesHandler.ShowInformationMessage("Timo dorob to!");
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Pdf")
                    BasicMessagesHandler.ShowInformationMessage("Timo dorob to!");
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                DatabaseCommunicator.Model.Form item = senderGrid.Rows[e.RowIndex].Tag as DatabaseCommunicator.Model.Form;
                EditItem(item);
            }
        }
        #endregion
    }
}
