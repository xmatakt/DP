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
        private Section lastPickedSection = null;

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
                {
                    sectionsTextBox.Text = value.Name;
                    lastPickedSection = value;
                }
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

        public EditFormularForm()
        {
            InitializeComponent();

            try
            {
                toolTip.InitialDelay = 100;
                fieldsLabelText = "Všetky sekcie";
                ezkoController = GlobalSettings.EzkoController;
                workingType = WorkingTypeEnum.Creating;

                InitializeSectionsTextBox();
                InitializeDataGridViews();
                formEditor.SetEditFormularForm(this);
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
                InitializeFormular();
                InitializeDataGridViews();
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas inicializácie okna pre editáciu formulárov sa vyskytla chyba", ex);
            }
        }

        #region Public methods
        public void EditField(Field item)
        {
            try
            {
                EditFieldForm form = new EditFieldForm(item);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //if (formular != null)
                    //{
                    //    //FieldForm fieldForm = formular.FieldForms.FirstOrDefault(x => x.Field.ID == item.ID);
                    //    //if (fieldForm != null)
                    //    //    formEditor.UpdateFieldForm(fieldForm);
                    //    //else
                    //    //    formEditor.RemoveField(item.ID);
                    //}
                    //else
                    formEditor.AddOrUpdateField(item, true, false);

                    FillFieldDataGridView(item.Section.Fields);
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
        #endregion

        #region Private methods
        private void InitializeFormular()
        {
            if (formular != null)
            {
                name = formular.Name;
                formEditor.LoadFormular(formular);
            }
            formEditor.SetEditFormularForm(this);
        }

        private void InitializeSectionsTextBox()
        {
            Section[] values = ezkoController.GetSections().ToArray();
            sectionsTextBox.AcceptsTab = true;
            sectionsTextBox.Values = values;
        }

        private void InitializeDataGridViews()
        {
            InitializeFieldsDataGridView();
            InitializeSectionsDataGridView();
        }

        private void InitializeFieldsDataGridView()
        {
            fieldsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fieldsDataGridView.GridColor = Color.White;
            fieldsDataGridView.AllowUserToResizeRows = false;
            fieldsDataGridView.AllowUserToResizeColumns = true;
            fieldsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            fieldsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            fieldsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            fieldsDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            fieldsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            fieldsDataGridView.BackgroundColor = Color.White;
            fieldsDataGridView.EnableHeadersVisualStyles = false;
            fieldsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            fieldsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            fieldsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            fieldsDataGridView.MultiSelect = false;
            fieldsDataGridView.RowHeadersVisible = false;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Názov poľa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            fieldsDataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn sectionColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Section",
                HeaderText = "Sekcia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            fieldsDataGridView.Columns.Add(sectionColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            fieldsDataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewImageColumn editColumn = new DataGridViewImageColumn()
            {
                Name = "Edit",
                HeaderText = "Upraviť pole",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ImageLayout = DataGridViewImageCellLayout.Normal,
            };
            //editColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorGreen;
            //editColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorGreen;
            fieldsDataGridView.Columns.Add(editColumn);

            DataGridViewImageColumn addColumn = new DataGridViewImageColumn()
            {
                Name = "Add",
                HeaderText = "Pridať do formulára",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ImageLayout = DataGridViewImageCellLayout.Normal,

            };
            //addColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorGreen;
            //addColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorGreen;
            fieldsDataGridView.Columns.Add(addColumn);

            FillFieldDataGridView(ezkoController.GetFields());
        }

        private void InitializeSectionsDataGridView()
        {
            sectionsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sectionsDataGridView.GridColor = Color.White;
            sectionsDataGridView.AllowUserToResizeRows = false;
            sectionsDataGridView.AllowUserToResizeColumns = true;
            sectionsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            sectionsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            sectionsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            sectionsDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            sectionsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            sectionsDataGridView.BackgroundColor = Color.White;
            sectionsDataGridView.EnableHeadersVisualStyles = false;
            sectionsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            sectionsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            sectionsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            sectionsDataGridView.MultiSelect = false;
            sectionsDataGridView.RowHeadersVisible = false;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Názov sekcie",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            sectionsDataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            sectionsDataGridView.Columns.Add(fillEmptySpaceColumn);

            FillSectionsDataGridView(ezkoController.GetSections());
        }

        private void FillFieldDataGridView(IEnumerable<Field> fields)
        {
            try
            {
                fieldsDataGridView.Rows.Clear();

                foreach (var item in fields)
                {
                    int rowIndex = fieldsDataGridView.Rows.Add(new object[]
                    {item.Name, item.Section.Name, "", Properties.Resources.edit_black_16, Properties.Resources.right_arrow_16});
                    fieldsDataGridView.Rows[rowIndex].Tag = item;
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas napĺňania prehľadu polí EZKO sa vyskytla chyba", ex);
            }
        }

        private void FillSectionsDataGridView(IEnumerable<Section> sections)
        {
            try
            {
                sectionsDataGridView.Rows.Clear();

                foreach (var item in sections)
                {
                    int rowIndex = sectionsDataGridView.Rows.Add(new object[]
                    {item.Name, ""});
                    sectionsDataGridView.Rows[rowIndex].Tag = item;
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas napĺňania prehľadu sekcií sa vyskytla chyba", ex);
            }
        }

        private void SelectRow(Field item)
        {
            if (item == null) return;

            foreach (DataGridViewRow row in fieldsDataGridView.Rows)
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

        private bool ValidateData(List<FieldForm> formFields)
        {
            bool result = true;

            try
            {
                if (formFields == null)
                    result = false;
                else if (name == null)
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
                List<FieldForm> formFields = formEditor.FormFields;
                if (ValidateData(formFields))
                {
                    if (ezkoController.CreateFormular(name, formFields))
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
                List<FieldForm> formFields = formEditor.FormFields;
                if (ValidateData(formFields))
                {
                    if (ezkoController.EditFormular(formular, name, formFields))
                    {
                        BasicMessagesHandler.ShowInformationMessage("Formulár bol úspešne upravený");
                        DialogResult = DialogResult.None;
                    }
                    else
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy formulára sa vyskytla chyba");
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

        private void AddToFormular(Field item)
        {
            try
            {
                if (formEditor.AddOrUpdateField(item, false, true))
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
                card.Enabled = false;
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
                FillFieldDataGridView(item.Fields.Where(x => !x.IsDeleted));
                fieldsLabelText = item.Name;
            }
        }

        private void editSectionButton_Click(object sender, EventArgs e)
        {
            string newSectionName = sectionsTextBox.Text.Trim();
            Section item = ezkoController.GetSectionByName(newSectionName);
            //Section item = section;
            if (item == null && lastPickedSection != null)
            {
                if(MessageBox.Show("Naozaj si želáte premenovať existuj[cu sekciu " + lastPickedSection.Name + " na " + newSectionName + "?",
                    "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(ezkoController.EditSection(lastPickedSection, newSectionName))
                    {
                        InitializeSectionsTextBox();
                        sectionsTextBox.Text = newSectionName;
                        fieldsLabelText = newSectionName;
                        FillFieldDataGridView(lastPickedSection.Fields);
                        FillSectionsDataGridView(ezkoController.GetSections());
                    }
                    else
                        BasicMessagesHandler.ShowErrorMessage("Pri editácií sekcie sa vyskytla chyba");
                }
            }
        }

        private void formularFieldsButton_Click(object sender, EventArgs e)
        {
            section = null;
            fieldsLabelText = "Polia použité vo formulári";
            FillFieldDataGridView(formEditor.GetFields());
        }

        private void allSectionsButton_Click(object sender, EventArgs e)
        {
            section = null;
            fieldsLabelText = "Všetky sekcie";
            FillFieldDataGridView(ezkoController.GetFields());
        }

        private void formularSectionsButton_Click(object sender, EventArgs e)
        {
            FillSectionsDataGridView(formEditor.GetSections());
        }

        private void allSectionsButton2_Click(object sender, EventArgs e)
        {
            FillSectionsDataGridView(ezkoController.GetSections());
        }

        private void addFiledButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditFieldForm form = new EditFieldForm();
                if(form.ShowDialog() == DialogResult.OK)
                {
                    section = null;
                    fieldsLabelText = "Všetky sekcie";
                    FillFieldDataGridView(ezkoController.GetFields());

                    //if new field was added into edited formular
                    if (formular != null)
                    {
                        foreach (var item in formular.FieldForms.Where(x => !x.Field.IsDeleted))
                        {
                            if (formular.FieldForms.Any(x => x.Field.ID == item.Field.ID))
                                formEditor.UpdateFieldForm(item);
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
            if (fieldsDataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
            {
                Field item = fieldsDataGridView.Rows[e.RowIndex].Tag as Field;
                if (fieldsDataGridView.Columns[e.ColumnIndex].Name == "Edit")
                    EditField(item);
                else if (fieldsDataGridView.Columns[e.ColumnIndex].Name == "Add")
                    AddToFormular(item);
            }
            else if (e.RowIndex >= 0)
            {
                Field item = fieldsDataGridView.Rows[e.RowIndex].Tag as Field;
                ShowPreview(item);
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int colIndex = fieldsDataGridView["Last", e.RowIndex].ColumnIndex;
                if (e.ColumnIndex <= colIndex)
                {
                    Field item = fieldsDataGridView.Rows[e.RowIndex].Tag as Field;
                    if (e.ColumnIndex == fieldsDataGridView.Columns["Section"].Index)
                        section = item.Section;
                    else
                        EditField(item);
                }
            }
        }
        private void sectionsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int colIndex = sectionsDataGridView["Last", e.RowIndex].ColumnIndex;
                if (e.ColumnIndex <= colIndex)
                {
                    Section item = sectionsDataGridView.Rows[e.RowIndex].Tag as Section;
                    //if (e.ColumnIndex == fieldsDataGridView.Columns["Section"].Index)
                        section = item;
                }
            }
        }

        private void addSectionButton_Click(object sender, EventArgs e)
        {
            string sectionName = sectionsTextBox.Text.Trim();
            Section existingSection = ezkoController.GetSectionByName(sectionName);

            if(existingSection != null)
                BasicMessagesHandler.ShowInformationMessage("Sekcia s daným názvom už existuje");
            else
            {
                if (MessageBox.Show("Naozaj si želáte vytvoriť novú sekciu " + sectionName + "?",
                    "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ezkoController.CreateSection(sectionName))
                    {
                        existingSection = ezkoController.GetSectionByName(sectionName);
                        InitializeSectionsTextBox();
                        sectionsTextBox.Text = sectionName;
                        fieldsLabelText = sectionName;
                        FillFieldDataGridView(existingSection.Fields);
                        lastPickedSection = existingSection;
                        FillSectionsDataGridView(ezkoController.GetSections());
                    }
                    else
                        BasicMessagesHandler.ShowInformationMessage("Pri vytváraní sekcie sa vyskytla chyba");
                }
            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Field item = fieldsDataGridView.Rows[e.RowIndex].Tag as Field;
                ShowPreview(item);
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            formEditor.ChangeFormularName(name);
        }

        private void editSectionButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Upraviť sekciu", editSectionButton);
        }

        private void backToLastSectionButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Naposledy vybraná sekcia", backToLastSectionButton);
        }

        private void formularFieldsButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Polia z formulára", formularFieldsButton);
        }

        private void allSectionsButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Všetky sekcie", allSectionsButton);
        }

        private void addSectionButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Vytvoriť sekciu", addSectionButton);
        }

        private void formularSectionsButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Sekcie z formulára", formularSectionsButton);
        }

        private void allSectionsButton2_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Všetky sekcie", allSectionsButton2);
        }

        private void sectionsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    if (sectionsTextBox.Tag is Section item)
                        lastPickedSection = item;
                    break;
            }
        }

        private void backToLastSectionButton_Click(object sender, EventArgs e)
        {
            if(lastPickedSection != null)
            {
                section = lastPickedSection;
                //FillDataGridView(lastPickedSection.ields);
            }
        }

        private void EditFormularForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && BasicMessagesHandler.ShowWarningMessage("Vykonané zmeny nebudú uložené, želáte si pokračovať?") != DialogResult.Yes)
                e.Cancel = true;
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
