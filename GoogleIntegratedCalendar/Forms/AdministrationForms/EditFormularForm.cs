using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Enums;
using EZKO.UserControls;
using EZKO.UserControls.Formulars;
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
    public partial class EditFormularForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private DatabaseCommunicator.Model.Form formular;

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

        private Section section
        {
            get { return sectionsTextBox.Tag as Section; }
            set
            {
                sectionsTextBox.Tag = value;
                if (value != null)
                    sectionsTextBox.Text = value.Name;
                else
                    sectionsTextBox.Text = "";
            }
        }

        private string fieldsLabelText
        {
            set { fieldsLabel.Text = "Polia zo sekcie: " + value; }
        }

        private string previewLabelText
        {
            set { previewLabel.Text = "Náhľad poľa: " + value; }
        }
        #endregion

        public EditFormularForm(WorkingTypeEnum workingType)
        {
            InitializeComponent();

            try
            {
                fieldsLabelText = "Všetky sekcie";
                ezkoController = GlobalSettings.EzkoController;
                this.workingType = workingType;

                InitializeSectionsTextBox();
                InitializeDataGridView();
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas inicializácie okna pre editáciu formulárov sa vyskytla chyba", ex);
            }
        }

        public EditFormularForm(DatabaseCommunicator.Model.Form formular)
        {
            InitializeComponent();

            try
            {
                workingType = WorkingTypeEnum.Editing;
                ezkoController = GlobalSettings.EzkoController;
                this.formular = formular;
                addButton.Text = "Upraviť formulár";
                fieldsLabelText = "Všetky sekcie";

                InitializeSectionsTextBox();
                InitializeForm();
                InitializeDataGridView();
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas inicializácie okna pre editáciu formulárov sa vyskytla chyba", ex);
            }
        }

        #region Private methods
        private void InitializeForm()
        {
            if (formular != null)
            {
                name = formular.Name;
                formEditor.LoadFormular(formular);
            }
        }

        private void InitializeSectionsTextBox()
        {
            Section[] values = ezkoController.GetSections().ToArray();
            sectionsTextBox.AcceptsTab = true;
            sectionsTextBox.Values = values;
        }

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
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Názov poľa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            dataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn sectionColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Section",
                HeaderText = "Sekcia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            dataGridView.Columns.Add(sectionColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            dataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewImageColumn editColumn = new DataGridViewImageColumn()
            {
                Name = "Edit",
                HeaderText = "Akcie",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ImageLayout = DataGridViewImageCellLayout.Normal,
            };
            //editColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorGreen;
            //editColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorGreen;
            dataGridView.Columns.Add(editColumn);

            DataGridViewImageColumn addColumn = new DataGridViewImageColumn()
            {
                Name = "Add",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ImageLayout = DataGridViewImageCellLayout.Normal,

            };
            //addColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorGreen;
            //addColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorGreen;
            dataGridView.Columns.Add(addColumn);

            FillDataGridView(ezkoController.GetFields());
        }

        private void FillDataGridView(IEnumerable<Field> fields)
        {
            try
            {
                dataGridView.Rows.Clear();

                foreach (var item in fields)
                {
                    int rowIndex = dataGridView.Rows.Add(new object[]
                    {item.Name, item.Section.Name, "", Properties.Resources.edit_black_16, Properties.Resources.right_arrow_16});
                    dataGridView.Rows[rowIndex].Tag = item;
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas napĺňania prehľadu polí EZKO sa vyskytla chyba", ex);
            }
        }

        private void SelectRow(Field item)
        {
            if (item == null) return;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if(row.Tag is Field field && field.ID == item.ID)
                {
                    row.Selected = true;
                    ShowPreview(item);
                    break;
                }
            }
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
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať názov formulára");
                    nameTextBox.Focus();
                    result = false;
                }
                else if(name.Length < 3)
                {
                    BasicMessagesHandler.ShowInformationMessage("Názov formulára mussí mať aspoň 3 znaky");
                    nameTextBox.Focus();
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
                    if (ezkoController.CreateFormular(name))
                        BasicMessagesHandler.ShowInformationMessage("Anamnestický formulár bol úspešne vytvorený");
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas vytvárania anamnestického formulára sa vyskytla chyba");
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
                    if (!ezkoController.EditFormular(formular, name))
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy anamnestického formulára sa vyskytla chyba");
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

        private void EditField(Field item)
        {
            try
            {
                EditFieldForm form = new EditFieldForm(item);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (formular != null)
                    {
                        FieldForm fieldForm = formular.FieldForms.FirstOrDefault(x => x.Field.ID == item.ID);
                        if (fieldForm != null)
                            formEditor.UpdateField(fieldForm);
                        else
                            formEditor.RemoveField(item.ID);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }

                SelectRow(item);
                fieldsLabelText = item.Section.Name;
                section = item.Section;
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas editovania poľa EZKO sa vyskytla chyba", ex);
            }
        }

        private void AddToFormular(Field item)
        {
            try
            {
                if (formEditor.AddField(item))
                    BasicMessagesHandler.ShowInformationMessage("Toto pole sa už vo formulári nachádza");
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas pridávania poľa EZKO do formulára vyskytla chyba", ex);
            }
        }

        private void ShowPreview(Field item)
        {
            try
            {
                if (item == null) return;

                formCardFlowPanel.Controls.Clear();
                FormFieldCard card = new FormFieldCard(true) { CardWidth = formCardFlowPanel.Width - 14 };
                card.SetField(item);
                formCardFlowPanel.Controls.Add(card);
                previewLabelText = item.Name;
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas zobrazovania náhľadu poľa EZKO sa vyskytla chyba", ex);
            }
        }
        #endregion

        #region UI Events
        private void EditFormularForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            CreateOrUpdate();
        }
        private void sectionsTextBox_TextChanged(object sender, EventArgs e)
        {
            Section item = section;
            if (item != null)
            {
                FillDataGridView(item.Fields.Where(x => !x.IsDeleted));
                fieldsLabelText = item.Name;
            }
        }

        private void editSectionButton_Click(object sender, EventArgs e)
        {
            Section item = section;
            if (item != null)
            {
                EditSectionForm form = new EditSectionForm(section);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    InitializeSectionsTextBox();
                    sectionsTextBox.Text = item.Name;
                }
            }
        }

        private void allSectionsButton_Click(object sender, EventArgs e)
        {
            section = null;
            fieldsLabelText = "Všetky sekcie";
            FillDataGridView(ezkoController.GetFields());
        }

        private void addFiledButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditFieldForm form = new EditFieldForm(WorkingTypeEnum.Creating);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    section = null;
                    fieldsLabelText = "Všetky sekcie";
                    FillDataGridView(ezkoController.GetFields());

                    //if new field was added into edited formular
                    if (formular != null)
                    {
                        foreach (var item in formular.FieldForms.Where(x => !x.Field.IsDeleted))
                        {
                            if (formular.FieldForms.Any(x => x.Field.ID == item.Field.ID))
                                formEditor.UpdateField(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri vytváraní poľa EZKO sa vyskytla chyba", ex);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                Field item = dataGridView.Rows[e.RowIndex].Tag as Field;
                if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
                    EditField(item);
                else if (dataGridView.Columns[e.ColumnIndex].Name == "Add")
                    AddToFormular(item);
            }
            else if (e.RowIndex >= 0)
            {
                Field item = dataGridView.Rows[e.RowIndex].Tag as Field;
                ShowPreview(item);
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int colIndex = dataGridView["Last", e.RowIndex].ColumnIndex;
                if (e.ColumnIndex <= colIndex)
                {
                    Field item = dataGridView.Rows[e.RowIndex].Tag as Field;
                    EditField(item);
                }
            }
        }

        private void addSectionButton_Click(object sender, EventArgs e)
        {
            EditSectionForm form = new EditSectionForm();
            if (form.ShowDialog() == DialogResult.OK)
                InitializeSectionsTextBox();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Field item = dataGridView.Rows[e.RowIndex].Tag as Field;
                ShowPreview(item);
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            formEditor.ChangeFormularName(name);
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
    }
}
