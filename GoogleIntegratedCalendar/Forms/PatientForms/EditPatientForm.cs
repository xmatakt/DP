using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Enums;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using EZKO.Classes;
using EZKO.Controllers;
using EZKO.Enums;
using EZKO.Forms.AdministrationForms;
using EZKO.Forms.PatientForms;
using EZKO.UserControls;
using EZKO.UserControls.FlatControls;
using PDFCreator.EZKODocumentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.Forms.PatientForms
{
    public partial class EditPatientForm : System.Windows.Forms.Form
    {
        private WorkingTypeEnum workingType;
        private EzkoController ezkoController;
        private Patient patient;
        private bool expandNodes = true;
        private bool resizeForm = true;

        #region Private properties
        #region Personal info tab

        private string avatarImagePath_ = null;
        private string avatarImagePath
        {
            get { return avatarImagePath_; }
            set
            {
                avatarPictureBox.Image = DirectoriesController.GetImage(value, Properties.Resources.noUserImage_white);
                avatarImagePath_ = value;
            }
        }
        string name
        {
            get
            {
                string val = nameTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { nameTextBox.Text = value; }
        }

        string surname
        {
            get
            {
                string val = surnameTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { surnameTextBox.Text = value; }
        }

        DateTime? birthDate
        {
            get{ return birthDatePicker.Tag as DateTime?; }
            set
            {
                if (value.HasValue)
                {
                    birthDatePicker.Format = DateTimePickerFormat.Custom;
                    birthDatePicker.CustomFormat = "dd.MM.yyyy";
                    birthDatePicker.Value = value.Value;
                    birthDatePicker.Tag = value.Value;
                }
                else
                {
                    birthDatePicker.Format = DateTimePickerFormat.Custom;
                    birthDatePicker.CustomFormat = " ";
                    birthDatePicker.Tag = null;
                }
            }
        }

        string BIFO
        {
            get
            {
                string val = bifoTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { bifoTextBox.Text = value ?? ""; }
        }

        string legalRepresentative
        {
            get
            {
                string val = representativeTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { representativeTextBox.Text = value ?? ""; }
        }

        string titleBefore
        {
            get
            {
                string val = firstTitleTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { firstTitleTextBox.Text = value ?? ""; }
        }

        string titleAfter
        {
            get
            {
                string val = secondTitleTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { secondTitleTextBox.Text = value ?? ""; }
        }

        string birthNumber
        {
            get
            {
                string val = birthNumberTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { birthNumberTextBox.Text = value ?? ""; }
        }

        InsuranceCompany insuranceCompany
        {
            get { return insuranceCompanyComboBox.SelectedItem as InsuranceCompany; }
            set
            {
                if (value == null)
                    insuranceCompanyComboBox.SelectedIndex = 0;
                else
                    insuranceCompanyComboBox.SelectedItem = value;
            }
        }

        SexEnum sex
        {
            get
            {
                if (manRadioButton.Checked)
                    return SexEnum.Man;
                else if (womanRadioButton.Checked)
                    return SexEnum.Woman;
                else
                    return SexEnum.Unknown;
            }
            set
            {
                //sex = value;
                switch (value)
                {
                    case SexEnum.Woman:
                        womanRadioButton.Checked = true;
                        break;
                    case SexEnum.Man:
                        manRadioButton.Checked = true;
                        break;
                    case SexEnum.Unknown:
                        manRadioButton.Checked = false;
                        womanRadioButton.Checked = false;
                        break;
                    default:
                        break;
                }
            }
        }

        string street
        {
            get
            {
                string val = streetTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { streetTextBox.Text = value ?? ""; }
        }

        string streetNumber
        {
            get
            {
                string val = streetNumberTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { streetNumberTextBox.Text = value ?? ""; }
        }

        string city
        {
            get
            {
                string val = cityTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { cityTextBox.Text = value ?? ""; }
        }

        string zip
        {
            get
            {
                string val = zipTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { zipTextBox.Text = value ?? ""; }
        }

        string country
        {
            get
            {
                string val = countryTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { countryTextBox.Text = value ?? ""; }
        }

        string email
        {
            get
            {
                return emailTextBox.Text.Trim();
            }
            set { emailTextBox.Text = value ?? ""; }
        }

        string alternativeEmail
        {
            get
            {
                string val = alternativeEmailTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { alternativeEmailTextBox.Text = value ?? ""; }
        }

        string phone
        {
            get
            {

                return phoneTextBox.Text.Trim();
            }
            set { phoneTextBox.Text = value ?? ""; }
        }

        string alternativePhone
        {
            get
            {
                string val = alternativePhoneTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { alternativePhoneTextBox.Text = value ?? ""; }
        }

        string facebook
        {
            get
            {
                string val = fbTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { fbTextBox.Text = value ?? ""; }
        }

        string employment
        {
            get
            {
                string val = employmentRichTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { employmentRichTextBox.Text = value ?? ""; }
        }

        string note
        {
            get
            {
                string val = noteRichTextBox.Text.Trim();
                if (val.Length > 0)
                    return val;
                else
                    return null;
            }
            set { noteRichTextBox.Text = value ?? ""; }
        }
        #endregion
        #endregion

        public EditPatientForm(Patient patient)
        {
            InitializeComponent();

            workingType = WorkingTypeEnum.Editing;
            ezkoController = GlobalSettings.EzkoController;
            this.patient = patient;
            formTitleLabel.Text += " " + patient.FullName;

            InitializeForm();
        }

        #region Private methods
        private void InitializeForm()
        {
            try
            {
                InitializeInsuranceCompanies();
                InitializePersonalInfoTab();
                InitializeTreeViewTab();
                InitializeTextDocumentationTab();
                InitializeDocumentsTab();
                InitializeVisitsTab();
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas načítavania údajov o pacientovi sa vyskytla chyba", ex);
            }
        }

        private void InitializeInsuranceCompanies()
        {
            insuranceCompanyComboBox.Items.Add("[ Vybrať ]");
            foreach (var item in ezkoController.GetInsuranceCompanies())
                insuranceCompanyComboBox.Items.Add(item);

            insuranceCompanyComboBox.SelectedIndex = 0;
        }

        private void InitializePersonalInfoTab()
        {
            if (patient != null)
            {
                avatarImagePath = patient.AvatarImagePath;
                idTextBox.Text = patient.ID.ToString();
                name = patient.Name;
                surname = patient.Surname;
                birthDate = patient.BirthDate;
                BIFO = patient.BIFO;
                legalRepresentative = patient.LegalRepresentative;
                titleBefore = patient.TitleBefore;
                titleAfter = patient.TitleAfter;
                birthNumber = patient.BirthNumber;
                insuranceCompany = patient.InsuranceCompany;
                if (patient.SexID == null)
                    sex = SexEnum.Unknown;
                else
                    sex = (patient.SexID == 1) ? SexEnum.Woman : SexEnum.Man;
                street = patient.Address?.Street;
                streetNumber = patient.Address?.StreetNumber;
                city = patient.Address?.City;
                zip = patient.Address?.PostNumber;
                country = patient.Address?.Country;
                phone = patient.Contact.Phone;
                alternativePhone = patient.Contact.AlternativePhone;
                email = patient.Contact.Email;
                alternativeEmail = patient.Contact.AlternativeEmail;
                facebook = patient.Contact.Facebook;
                employment = patient.Employment;
                note = patient.Note;
            }
        }

        private void InitializeTreeViewTab()
        {
            //treeView.Nodes.Clear();

            if (patient != null && patient.RootDirectoryPath != null)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(patient.RootDirectoryPath);
                BuildTree(directoryInfo, treeView.Nodes);
            }

            if(expandNodes)
            {
                expandNodes = false;
                treeView.ExpandAll();
            }

            RemoveDeletedFilesFromTree(treeView.Nodes);
        }

        private void InitializeTextDocumentationTab()
        {
            FormGenerator.GenerateOverview(patient.ID, GlobalSettings.User.ID, doctorsFlowPanel, patientsFlowPanel, ezkoController.GetFields().ToList());
        }

        private void InitializeDocumentsTab()
        {
            InitializeDocumentsGrid();
            InitializeBudgetsGrid();

            FillDocumentsGrid();
            FillBudgetsGrid();
        }

        private void InitializeDocumentsGrid()
        {
            documentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            documentsDataGridView.GridColor = Color.White;
            documentsDataGridView.AllowUserToResizeRows = false;
            documentsDataGridView.AllowUserToResizeColumns = true;
            documentsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            documentsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            documentsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            documentsDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            documentsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            documentsDataGridView.BackgroundColor = Color.White;
            documentsDataGridView.EnableHeadersVisualStyles = false;
            documentsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            documentsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            documentsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            documentsDataGridView.RowHeadersVisible = false;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Názov",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            documentsDataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            documentsDataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn showColumn = new DataGridViewButtonColumn()
            {
                Name = "Show",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            showColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorGreen;
            showColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorGreen;
            documentsDataGridView.Columns.Add(showColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn()
            {
                Name = "Remove",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            removeColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorRed;
            removeColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorRed;
            documentsDataGridView.Columns.Add(removeColumn);
        }

        private void InitializeBudgetsGrid()
        {
            budgetsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            budgetsDataGridView.GridColor = Color.White;
            budgetsDataGridView.AllowUserToResizeRows = false;
            budgetsDataGridView.AllowUserToResizeColumns = true;
            budgetsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            budgetsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            budgetsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            budgetsDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            budgetsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            budgetsDataGridView.BackgroundColor = Color.White;
            budgetsDataGridView.EnableHeadersVisualStyles = false;
            budgetsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            budgetsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            budgetsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            budgetsDataGridView.RowHeadersVisible = false;

            DataGridViewTextBoxColumn IDColumn = new DataGridViewTextBoxColumn()
            {
                Name = "ID",
                HeaderText = "ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            IDColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            budgetsDataGridView.Columns.Add(IDColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Názov",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            budgetsDataGridView.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            budgetsDataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn pdfColumn = new DataGridViewButtonColumn()
            {
                Name = "Pdf",
                HeaderText = "Akcie",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            pdfColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorLightBlue;
            pdfColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorLightBlue;
            budgetsDataGridView.Columns.Add(pdfColumn);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            editColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorBlue;
            editColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorBlue;
            budgetsDataGridView.Columns.Add(editColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn()
            {
                Name = "Remove",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            removeColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorRed;
            removeColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorRed;
            budgetsDataGridView.Columns.Add(removeColumn);
        }

        private void InitializeVisitsTab()
        {
            visitsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            visitsDataGridView.GridColor = Color.White;
            visitsDataGridView.AllowUserToResizeRows = false;
            visitsDataGridView.AllowUserToResizeColumns = true;
            visitsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            visitsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            visitsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            visitsDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            visitsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            visitsDataGridView.BackgroundColor = Color.White;
            visitsDataGridView.EnableHeadersVisualStyles = false;
            visitsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            visitsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            visitsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            visitsDataGridView.RowHeadersVisible = false;
            visitsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Status",
                HeaderText = "Status",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            statusColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            visitsDataGridView.Columns.Add(statusColumn);

            DataGridViewTextBoxColumn doctorColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Doctor",
                HeaderText = "Doktor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            doctorColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            visitsDataGridView.Columns.Add(doctorColumn);

            DataGridViewTextBoxColumn nurseColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Nurse",
                HeaderText = "Sestra",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            nurseColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            visitsDataGridView.Columns.Add(nurseColumn);

            DataGridViewTextBoxColumn startColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Start",
                HeaderText = "Začiatok",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            visitsDataGridView.Columns.Add(startColumn);

            DataGridViewTextBoxColumn endColumn = new DataGridViewTextBoxColumn()
            {
                Name = "End",
                HeaderText = "Koniec",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            visitsDataGridView.Columns.Add(endColumn);

            DataGridViewTextBoxColumn plannedActionsColumn = new DataGridViewTextBoxColumn()
            {
                Name = "PlannedActions",
                HeaderText = "Plánované výkony",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            plannedActionsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            visitsDataGridView.Columns.Add(plannedActionsColumn);

            DataGridViewTextBoxColumn doneActionsColumn = new DataGridViewTextBoxColumn()
            {
                Name = "DoneActions",
                HeaderText = "Vykonané výkony",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            doneActionsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            visitsDataGridView.Columns.Add(doneActionsColumn);

            DataGridViewTextBoxColumn infrastructureColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Infrastructure",
                HeaderText = "Infraštruktúra",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            visitsDataGridView.Columns.Add(infrastructureColumn);

            DataGridViewTextBoxColumn noteColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Note",
                HeaderText = "Poznámka",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            visitsDataGridView.Columns.Add(noteColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "TotalPrice",
                HeaderText = "Celková cena",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            };
            visitsDataGridView.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn fillEmptySpaceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "Last",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };
            visitsDataGridView.Columns.Add(fillEmptySpaceColumn);

            DataGridViewButtonColumn pdfColumn = new DataGridViewButtonColumn()
            {
                Name = "Pdf",
                HeaderText = "Doklad",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            pdfColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorLightBlue;
            pdfColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorLightBlue;
            visitsDataGridView.Columns.Add(pdfColumn);

            DataGridViewButtonColumn viewColumn = new DataGridViewButtonColumn()
            {
                Name = "View",
                HeaderText = "Náhľad",
                FlatStyle = FlatStyle.Flat,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            viewColumn.CellTemplate.Style.BackColor = Colors.FlatButtonColorBlue;
            viewColumn.CellTemplate.Style.SelectionBackColor = Colors.FlatButtonColorBlue;
            visitsDataGridView.Columns.Add(viewColumn);

            FillVisitsGrid();
        }

        private void FillDocumentsGrid()
        {
            documentsDataGridView.Rows.Clear();
            string path = DirectoriesController.GetPatientDocumentsFolder(patient);

            if (!Directory.Exists(path))
                return;

            foreach (var item in new DirectoryInfo(path).GetFiles())
            {
                int rowIndex = documentsDataGridView.Rows.Add(new object[]
                { item.Name, "", "Náhľad", "Odstrániť", " " });

                documentsDataGridView.Rows[rowIndex].Tag = item.FullName;
            }
        }

        private void FillBudgetsGrid()
        {
            budgetsDataGridView.Rows.Clear();

            foreach (var item in ezkoController.GetBudgets(patient))
            {
                int rowIndex = budgetsDataGridView.Rows.Add(new object[]
                { item.ID, item.Name, "", "PDF", "Upraviť", "Zmazať", " " });

                budgetsDataGridView.Rows[rowIndex].Tag = item;
            }
        }

        private void FillVisitsGrid()
        {
            if (patient == null)
                return;

            visitsDataGridView.Rows.Clear();

            foreach (var item in ezkoController.GetEvents(patient.ID))
            {
                if(MatchesFilter(item))
                {
                    int rowIndex = visitsDataGridView.Rows.Add(new object[]
                { item.EventState.ToString().ToLower(), GetItems(item.Users.Where(x => x.RoleID == (int)UserRoleEnum.Doctor).ToList()),
                    GetItems(item.Users.Where(x => x.RoleID == (int)UserRoleEnum.Nurse).ToList()), item.StartDate, item.EndDate,
                    GetItems(item.Actions), GetItems(item.CalendarEventExecutedActions), GetItems(item.Infrastructures), item.Description,
                    item.CalendarEventExecutedActions.Select(x => x.Action).Sum(x => x.Costs + x.Margin).ToString("0.00 €"),
                    "", "Pdf", "Náhľad"});

                    visitsDataGridView.Rows[rowIndex].Tag = item;

                    Color? cellColor = GetEventStateColor(item.StateID);
                    if (cellColor.HasValue)
                        visitsDataGridView[0, rowIndex].Style.BackColor = cellColor.Value;
                }
            }

            if(resizeForm)
            {
                resizeForm = false;
                ResizeForm();
            }
        }

        private bool MatchesFilter(CalendarEvent item)
        {
            bool result = false;
            string filterValue = searchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(filterValue))
                result = true;
            else
            {
                if (
                    item.EventState.ToString().ToLower().Contains(filterValue) ||
                    (item.Description != null && item.Description.Contains(filterValue)) ||
                    item.Users.Any(x => x.Login.Contains(filterValue)) ||
                    item.StartDate.ToString().Contains(filterValue) ||
                    item.EndDate.ToString().Contains(filterValue) ||
                    item.Actions.Any(x => x.Name.Contains(filterValue)) ||
                    item.CalendarEventExecutedActions.Any(x => x.Action.Name.Contains(filterValue)) ||
                    item.Infrastructures.Any(x => x.Name.Contains(filterValue))
                    )
                    result = true;
            }

            return result;
        }

        private void ResizeForm()
        {
            if (visitsDataGridView.RowCount <= 0)
                return;

            int newFormWidth = 50;
            for (int i = 0; i < visitsDataGridView.ColumnCount; i++)
                newFormWidth += visitsDataGridView[i, 0].Size.Width;

            if(newFormWidth > Screen.FromControl(this).Bounds.Width)
                newFormWidth = Screen.FromControl(this).Bounds.Width;

            if (newFormWidth > Width)
            {
                float ratio = Height / (float)Width;
                float newFormHeight = (newFormWidth * Height) / (float)Width;
                Size = new Size(newFormWidth, (int)newFormHeight);
            }
        }

        private Color? GetEventStateColor(int stateID)
        {
            switch (stateID)
            {
                case (int)EventStateEnum.Planned:
                    return Colors.FlatButtonColorLightBlue;
                case (int)EventStateEnum.Done:
                    return Colors.FlatButtonColorGreen;
                case (int)EventStateEnum.Payed:
                    return Colors.FlatButtonColorOrange;
                case (int)EventStateEnum.Cancelled:
                    return Colors.FlatButtonColorGray;

                default:
                    return null;
            }
        }

        private string GetItems<T>(ICollection<T> collection)
        {
            if (collection == null || collection.Count == 0)
                return " ";
            else if (collection.Count == 1)
            {
                T item = collection.First();
                if (item is CalendarEventExecutedAction)
                {
                    CalendarEventExecutedAction action = item as CalendarEventExecutedAction;
                    return action.Action.ToString();
                }
                else
                    return item.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in collection)
                {
                    if (item is CalendarEventExecutedAction)
                    {
                        CalendarEventExecutedAction action = item as CalendarEventExecutedAction;
                        sb.AppendLine(action.Action.ToString());
                    }
                    else
                        sb.AppendLine(item.ToString());
                }

                return sb.ToString();
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Find(directoryInfo.FullName, false).FirstOrDefault();
            if (curNode == null)
                curNode = addInMe.Add(directoryInfo.FullName, directoryInfo.Name);

            if(curNode != null)
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (curNode.Nodes.Find(file.FullName, false).Count() == 0)
                        curNode.Nodes.Add(file.FullName, file.Name);
                }
                foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                {
                    BuildTree(subdir, curNode.Nodes);
                }
            }
        }

        private void RemoveDeletedFilesFromTree(TreeNodeCollection nodes)
        {
            foreach (TreeNode item in nodes)
            {
                FileInfo fileInfo = new FileInfo(item.Name);
                if (!string.IsNullOrEmpty(fileInfo.Extension))
                    if (!File.Exists(item.Name))
                        treeView.Nodes.Remove(item);

                RemoveDeletedFilesFromTree(item.Nodes);
            }
        }

        private bool ValidateData()
        {
            bool result = true;

            try
            {
                if (name == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať meno pacienta");
                    nameTextBox.Focus();
                    result = false;
                }
                else if (surname == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať priezvisko pacienta");
                    surnameTextBox.Focus();
                    result = false;
                }
                else if (BIFO != null && BIFO.Length != 10)
                {
                    BasicMessagesHandler.ShowInformationMessage("BIFO musí byť 10 znakový kód");
                    bifoTextBox.Focus();
                    result = false;
                }
                else if(string.IsNullOrEmpty(phone))
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať telefón pacienta");
                    phoneTextBox.Focus();
                    result = false;
                }
                else if (string.IsNullOrEmpty(email))
                {
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať email pacienta");
                    emailTextBox.Focus();
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

        private void UpdateData()
        {
            try
            {
                DialogResult = DialogResult.None;
                Cursor = Cursors.WaitCursor;
                if (ValidateData())
                {
                    string fileName = System.IO.Path.GetFileName(avatarImagePath);
                    string patientAvatarImagePath = DirectoriesController.GetPatientImageFolder(patient) + @"\" + fileName;

                    if (!ezkoController.EditPatient(patient, name, surname, birthDate, BIFO, legalRepresentative, titleBefore, titleAfter, birthNumber,
                        insuranceCompany, sex, street, streetNumber, city, zip, country, phone, alternativePhone, email, alternativeEmail,
                        facebook, employment, note, patientAvatarImagePath))
                    {
                        BasicMessagesHandler.ShowErrorMessage("Počas úpravy pacienta sa vyskytla chyba");
                    }
                    else
                    {
                        SaveFieldsOverview();
                        if (avatarImagePath != null)
                        {
                            // iba docasne!!
                            DirectoriesController.CreatePatientFolderStructure(patient);
                            //
                            DirectoriesController.CopyFile(avatarImagePath, patientAvatarImagePath);
                        }

                        BasicMessagesHandler.ShowInformationMessage("Zmeny boli úspešne uložené");
                    }
                }
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
            }

            Cursor = Cursors.Default;
        }

        private void SaveFieldsOverview()
        {
            ezkoController.DeleteFilledFields(patient, GlobalSettings.User);

            List<FilledField> filledFields = new List<FilledField>();
            try
            {
                foreach (Control item in doctorsFlowPanel.Controls)
                {
                    if (item is TextBox textBox && textBox.Text.Trim() != "")
                    {
                        Field field = textBox.Tag as Field;
                        FieldAnswer answer = new FieldAnswer() { TextValue = textBox.Text.Trim() };
                        FilledField filledField = new FilledField()
                        {
                            Field = field,
                            Patient = patient,
                            User = GlobalSettings.User,
                            FieldAnswer = answer
                        };
                        filledFields.Add(filledField);
                    }
                    else if (item is FlatRichTextBox richTextBox && richTextBox.Text.Trim() != "")
                    {
                        Field field = richTextBox.Tag as Field;
                        FieldAnswer answer = new FieldAnswer() { TextValue = richTextBox.Text.Trim() };
                        FilledField filledField = new FilledField()
                        {
                            Field = field,
                            Patient = patient,
                            User = GlobalSettings.User,
                            FieldAnswer = answer
                        };
                        filledFields.Add(filledField);
                    }
                    else if (item is RadioButton radioButton)
                    {
                        if (!radioButton.Checked)
                            continue;

                        FieldValue fieldValue = radioButton.Tag as FieldValue;
                        FilledField filledField = filledFields.FirstOrDefault(x => x.Field.ID == fieldValue.Field.ID);
                        FieldValueAnswer answer = new FieldValueAnswer() { FieldValue = fieldValue, IsChecked = radioButton.Checked };

                        if (filledField != null)
                            filledField.FieldValueAnswers.Add(answer);
                        else
                        {
                            filledField = new FilledField()
                            {
                                Field = fieldValue.Field,
                                Patient = patient,
                                User = GlobalSettings.User,
                            };
                            filledField.FieldValueAnswers.Add(answer);
                            filledFields.Add(filledField);
                        }
                    }
                    else if (item is CheckBox checkBox)
                    {
                        if (!checkBox.Checked)
                            continue;

                        FieldValue fieldValue = checkBox.Tag as FieldValue;
                        FilledField filledField = filledFields.FirstOrDefault(x => x.Field.ID == fieldValue.Field.ID);
                        FieldValueAnswer answer = new FieldValueAnswer() { FieldValue = fieldValue, IsChecked = checkBox.Checked };

                        if (filledField != null)
                            filledField.FieldValueAnswers.Add(answer);
                        else
                        {
                            filledField = new FilledField()
                            {
                                Field = fieldValue.Field,
                                Patient = patient,
                                User = GlobalSettings.User,
                            };
                            filledField.FieldValueAnswers.Add(answer);
                            filledFields.Add(filledField);
                        }
                    }
                    else if (item is ComboBox comboBox)
                    {
                        FieldValue fieldValue = comboBox.SelectedItem as FieldValue;
                        if (fieldValue != null)
                        {
                            FilledField filledField = filledFields.FirstOrDefault(x => x.Field.ID == fieldValue.Field.ID);
                            FieldValueAnswer answer = new FieldValueAnswer() { FieldValue = fieldValue, IsChecked = true };

                            if (filledField != null)
                                filledField.FieldValueAnswers.Add(answer);
                            else
                            {
                                filledField = new FilledField()
                                {
                                    Field = fieldValue.Field,
                                    Patient = patient,
                                    User = GlobalSettings.User,
                                };
                                filledField.FieldValueAnswers.Add(answer);
                                filledFields.Add(filledField);
                            }
                        }
                    }
                }

                if (!ezkoController.CreateFilledFields(filledFields))
                    BasicMessagesHandler.ShowErrorMessage("Počas ukladania zmien vo vyplnení EZKO polí sa vyskytla chyba!");
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Počas ukladania zmien vo vyplnení EZKO polí sa vyskytla chyba!", ex);
            }
        }

        private void CloseWindow()
        {
            if (BasicMessagesHandler.ShowWarningMessage("Vykonané zmeny nebudú uložené.\n Želáte si pokračovať?") == DialogResult.Yes)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.None;
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
            CloseWindow();
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
        private void changeAvatarButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                avatarImagePath = openFileDialog.FileName;
        }

        private void EditPatientForm_Load(object sender, EventArgs e)
        {
            nameTextBox.MaxLength = 30;
            surnameTextBox.MaxLength = 30;
            birthDatePicker.MaxDate = DateTime.Now;
            bifoTextBox.MaxLength = 10;
            representativeTextBox.MaxLength = 80;
            firstTitleTextBox.MaxLength = 20;
            secondTitleTextBox.MaxLength = 20;
            birthNumberTextBox.MaxLength = 11;
            streetTextBox.MaxLength = 80;
            streetNumberTextBox.MaxLength = 20;
            cityTextBox.MaxLength = 40;
            zipTextBox.MaxLength = 10;
            countryTextBox.MaxLength = 40;
            emailTextBox.MaxLength = 80;
            alternativeEmailTextBox.MaxLength = 80;
            phoneTextBox.MaxLength = 20;
            alternativePhoneTextBox.MaxLength = 20;
            fbTextBox.MaxLength = 80;
            idTextBox.TextAlign = HorizontalAlignment.Right;
        }

        private void birthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            birthDatePicker.Tag = birthDatePicker.Value;
            
            if (birthDatePicker.Tag is DateTime)
            {
                birthDatePicker.Format = DateTimePickerFormat.Custom;
                birthDatePicker.CustomFormat = "dd.MM.yyyy";
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void generatePdfButton_Click(object sender, EventArgs e)
        {
            string path = DirectoriesController.GetPatientDocumentsFolder(patient) + @"\" + patient.FullName + "_EZKO.pdf";
            EhrToPDF ehrToPdf = new EhrToPDF(path, patient, GlobalSettings.User, ezkoController);
            if (ehrToPdf.CreatePdf())
                System.Diagnostics.Process.Start(path);
            else
                BasicMessagesHandler.ShowInformationMessage("Pri vytváraní PDF dokumentácie sa vyskytla chyba");
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Node.Name);
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa neznáma chyba!", ex);
            }
        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            patientsFlowPanel.VerticalScroll.Value = doctorsFlowPanel.VerticalScroll.Value;
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;

            if (panel != null)
            {
                foreach (Control item in panel.Controls)
                {
                    item.Width = panel.Width - FormGenerator.Value;
                }
            }
        }

        private void documentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Rows[e.RowIndex].Tag is string path && File.Exists(path))
                {
                    if (senderGrid.Columns[e.ColumnIndex].Name == "Show")
                        System.Diagnostics.Process.Start(path);
                    else if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                    {
                        if (MessageBox.Show("Naozaj si želáte odstrániť súbor " + path, "?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (!DirectoriesController.RemoveFile(path))
                            {
                                BasicMessagesHandler.ShowInformationMessage("Súbor sa nepodarilo odstrániť.\n" +
                                    "Skontrolujte prosím, či nie je otvorený v inom programe.");
                            }
                            else
                                FillDocumentsGrid();
                        }
                    }
                }

            }
        }

        private void documentsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                if (senderGrid.Rows[e.RowIndex].Tag is string path && File.Exists(path))
                    System.Diagnostics.Process.Start(path);
            }
        }

        private void budgetsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Budget item = senderGrid.Rows[e.RowIndex].Tag as Budget;
                if (senderGrid.Columns[e.ColumnIndex].Name == "Edit")
                {
                    EditBudgetForm form = new EditBudgetForm(item);
                    if (form.ShowDialog() == DialogResult.OK)
                        FillBudgetsGrid();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Remove")
                {
                    if (MessageBox.Show("Naozaj si želáte odstrániť rozpočet " + item.Name, "?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ezkoController.RemoveBudget(item))
                            BasicMessagesHandler.ShowErrorMessage("Rozpočet sa nepodarilo odstrániť");
                        else
                            FillBudgetsGrid();
                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Pdf")
                {
                    string path = DirectoriesController.GetPatientDocumentsFolder(item.Patient) + @"\" + item.PdfFile();
                    BudgetToPDF budgetToPdf = new BudgetToPDF(path, item);
                    if (budgetToPdf.CreatePdf())
                    {
                        System.Diagnostics.Process.Start(path);
                        FillDocumentsGrid();
                    }
                    else
                        BasicMessagesHandler.ShowInformationMessage("Pri vytváraní PDF súboru sa vyskytla chyba");
                }
            }
        }

        private void budgetsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                Budget item = senderGrid.Rows[e.RowIndex].Tag as Budget;
                EditBudgetForm form = new EditBudgetForm(item);
                if (form.ShowDialog() == DialogResult.OK)
                    FillBudgetsGrid();
            }
        }

        private void addDocumentButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All files (*.*) | *.*;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!DirectoriesController.CopyToDocumentsFolder(patient, openFileDialog.FileName))
                    BasicMessagesHandler.ShowInformationMessage("Súbor sa nepodarilo nahrať do priečinku pacienta.\n" +
                                    "Skontrolujte prosím, či nie je súbor otvorený v inom programe.");
                else
                    FillDocumentsGrid();
            }
        }

        private void newBudgetButton_Click(object sender, EventArgs e)
        {
            var form = new EditBudgetForm(WorkingTypeEnum.Creating, patient);
            if (form.ShowDialog() == DialogResult.OK)
                FillBudgetsGrid();
        }

        private void visitsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    CalendarEvent item = senderGrid.Rows[e.RowIndex].Tag as CalendarEvent;
                    if (senderGrid.Columns[e.ColumnIndex].Name == "Pdf")
                    {
                        string path = DirectoriesController.GetPatientDocumentsFolder(item.Patient) + @"\" + item.Patient.FullName + "_navsteva_" + item.ID + ".pdf";
                        EventToPDF eventToPdf = new EventToPDF(path, item);
                        if (eventToPdf.CreatePdf())
                            System.Diagnostics.Process.Start(path);
                    }
                    else if (senderGrid.Columns[e.ColumnIndex].Name == "View")
                    {
                        EventOverviewForm overviewForm = new EventOverviewForm(item);
                        if (overviewForm.ShowDialog() == DialogResult.OK)
                            FillVisitsGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri pokuse o odstránenie položky sa vyskytla chyba", ex);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == (int)SelectedTabEnum.ImageDocumentationTab)
            {
                InitializeTreeViewTab();
            }
            else if (tabControl.SelectedIndex == (int)SelectedTabEnum.DocumentsTab)
            {
                FillDocumentsGrid();
                FillBudgetsGrid();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            FillVisitsGrid();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            FillDocumentsGrid();
        }

        private void refreshButton2_Click(object sender, EventArgs e)
        {
            InitializeTreeViewTab();
        }
        #endregion
    }

    enum SelectedTabEnum
    {
        PersonalInfoTab = 0,
        ImageDocumentationTab = 1,
        TextDocumentationTab = 2,
        DocumentsTab = 3,
        VisitsTab = 4
    }
}
