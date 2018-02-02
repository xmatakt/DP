using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using EZKO.Controllers;
using EZKO.Forms.PatientForms;
using ExceptionHandler;
using EZKO.Forms.AdministrationForms;

namespace EZKO.UserControls.Patients
{
    public partial class PatientsUserControl : UserControl
    {
        private EzkoController ezkoController;
        public PatientsUserControl()
        {
            InitializeComponent();

            ezkoController = GlobalSettings.EzkoController;
            InitializeDataGridView();
            FillDataGridView(ezkoController.GetPatients());
        }

        #region Public methods
        #endregion

        #region Private methods
        private void InitializeDataGridView()
        {
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

            DataGridViewTextBoxColumn userIDColumn = new DataGridViewTextBoxColumn()
            {
                Name = "ID",
                HeaderText = "ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            userIDColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns.Add(userIDColumn);

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn()
            {
                Name = "Image",
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.Stretch,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 50
            };
            dataGridView.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "PatientName",
                HeaderText = "Pacient",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25,
            };
            dataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Phone",
                HeaderText = "Telefón",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25,
            };
            dataGridView.Columns.Add(phoneColumn);

            DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Email",
                HeaderText = "Email",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25,
            };
            dataGridView.Columns.Add(emailColumn);

            DataGridViewTextBoxColumn addressColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Address",
                HeaderText = "Ulica, mesto, štát",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25,
            };
            dataGridView.Columns.Add(addressColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 50,
            };
            dataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            editColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorBlue;
            editColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorBlue;
            dataGridView.Columns.Add(editColumn);

            DataGridViewButtonColumn pdfColumn = new DataGridViewButtonColumn()
            {
                Name = "PdfExport",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            pdfColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorLightBlue;
            pdfColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorLightBlue;
            dataGridView.Columns.Add(pdfColumn);

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

        private void FillDataGridView(IQueryable<Patient> patients)
        {
            dataGridView.Rows.Clear();

            foreach (var item in patients)
            {
                int rowIndex = dataGridView.Rows.Add(new object[]
                { item.ID, DirectoriesController.GetImage(item.AvatarImagePath, Properties.Resources.noUserImage), item.FullName, item.Contact.Phone,
                    item.Contact.Email, item.Address?.FullAddress ?? "Nezadané" ,"", "EZKO", "PDF", "Zmazať" });
                dataGridView.Rows[rowIndex].Tag = item;
            }
        }

        private void EditItem(Patient item)
        {
            EditPatientForm form = new EditPatientForm(item);
            if (form.ShowDialog() == DialogResult.OK)
                FillDataGridView(ezkoController.GetPatients());
        }

        private void RemoveItem(Patient item)
        {
            if (MessageBox.Show("Naozaj si želáte odstrániť pacienta " + item.FullName, "?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!ezkoController.RemovePatient(item))
                {
                    BasicMessagesHandler.ShowErrorMessage("Pacienta sa nepodarilo odstrániť");
                }
                else
                    FillDataGridView(ezkoController.GetPatients());
            }
        }
        #endregion

        #region UI events
        private void findButton_Click(object sender, EventArgs e)
        {
            FillDataGridView(ezkoController.GetPatients(filterTextBox.Text.Trim()));
        }

        private void newPatientMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            NewPatientForm form = new NewPatientForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                FillDataGridView(ezkoController.GetPatients());
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Patient item = senderGrid.Rows[e.RowIndex].Tag as Patient;
                if (senderGrid.Columns[e.ColumnIndex].Name == "Edit")
                    EditItem(item);
               else if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                    RemoveItem(item);
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                Patient item = senderGrid.Rows[e.RowIndex].Tag as Patient;
                EditItem(item);
            }
        }
        #endregion
    }
}
