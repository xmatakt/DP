﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExceptionHandler;
using EZKO.UserControls.FlatControls;
using EZKO.Controllers;
using DatabaseCommunicator.Controllers;
using EZKO.Enums;
using DatabaseCommunicator.Model;
using System.Collections.Generic;

namespace EZKO.UserControls.Dashboard
{
    public partial class VisitUserControl : UserControl
    {
        private DateTime? eventStartDateTime = null;
        private EzkoController ezkoController;
        private WorkingTypeEnum workingType = WorkingTypeEnum.Editing;

        #region Private properties
        private Patient patient { get { return patientNameTextBox.Tag as Patient; } }
        private bool isNew
        {
            get { return newPatientCheckBox.Checked; }
            set { newPatientCheckBox.Checked = value; }
        }
        private string patientName
        {
            get
            {
                string result = newPatientNameTextBox.Text.Trim();
                return (result != "") ? result : null;
            }
        }
        private string patientSurame
        {
            get
            {
                string result = newPatientSurnameTextBox.Text.Trim();
                return (result != "") ? result : null;
            }
        }
        private string patientEmail
        {
            get
            {
                string result = newPatientEmailTextBox.Text.Trim();
                return (result != "") ? result : null;
            }
        }
        private string patientPhone
        {
            get
            {
                string result = newPatientPhoneTextBox.Text.Trim();
                return (result != "") ? result : null;
            }
        }
        private List<User> doctors
        {
            get
            {
                List<User> result = new List<User>();
                foreach (var item in doctorsCheckBoxComboBox.Items)
                {
                    if(item is User doctor)
                    {
                        if (doctorsCheckBoxComboBox.CheckBoxItems[doctor.ToString()].Checked)
                            result.Add(doctor);
                    }
                }
                return result;
            }
        }
        private decimal eventDuration
        {
            get { return durationNumericUpDown.Value; }
            set { durationNumericUpDown.Value = value; }
        }
        private List<string> notificationEmails
        {
            get
            {
                var splittedText = emailsRichTextBox.Text.Split(new[] { ',' });
                return splittedText.Select(x => x.Trim()).ToList();
            }
        }
        private string eventNote
        {
            get
            {
                string note = eventNoteRichTextBox.Text.Trim();
                return (note != "") ? note : null;
            }
        }
        private List<DatabaseCommunicator.Model.Action> plannedActions
        {
            get
            {
                List<DatabaseCommunicator.Model.Action> result = new List<DatabaseCommunicator.Model.Action>();
                foreach (var item in plannedActionsComboBox.Items)
                {
                    if (item is DatabaseCommunicator.Model.Action action)
                    {
                        if (plannedActionsComboBox.CheckBoxItems[action.ToString()].Checked)
                            result.Add(action);
                    }
                }
                return result;
            }
        }
        private string plannedText
        {
            get
            {
                string result = planedTextTextBox.Text.Trim();
                return (result != "") ? result : null;
            }
        }
        private List<Classes.DoneActionNotePair> doneActions
        {
            get
            {
                List<Classes.DoneActionNotePair> result = new List<Classes.DoneActionNotePair>();
                Control[] controls = doneActionsTablePanel.Controls.Find("flatRichTextBox", true);

                foreach (var item in controls)
                {
                    if (item is FlatRichTextBox frtbItem)
                    {
                        if(frtbItem.Tag is DatabaseCommunicator.Model.Action action)
                        {
                            string actionNote = frtbItem.Text;
                            result.Add(new Classes.DoneActionNotePair()
                            {
                                DoneAction = action,
                                ActionNote = actionNote
                            });
                        }
                    }
                }
                return result;
            }
        }
        private string doneText
        {
            get
            {
                string result = doneTextTextBox.Text.Trim();
                return (result != "") ? result : null;
            }
        }
        private EventState eventState { get { return eventStateComboBox.SelectedItem as EventState; } }
        #endregion

        public VisitUserControl()
        {
            InitializeComponent();

            SetDoneActionsPanelForTabelPanelVisibility(false);
            durationInfoLabel.Visible = false;
            patientNamePanel.Visible = true;
            newPatientPanel.Visible = false;
            doneActionsTablePanel.RowCount = 0;

            //Sets only vertical scroll to be available (doesn't seems to work)
            mainFlowLayoutPanel.HorizontalScroll.Maximum = 0;
            mainFlowLayoutPanel.AutoScroll = false;
            mainFlowLayoutPanel.VerticalScroll.Visible = false;
            mainFlowLayoutPanel.AutoScroll = true;
            //----

            SetPanelElementsProperties();
        }

        #region Public methods
        public void SetControlWorkingType(WorkingTypeEnum workingType)
        {
            this.workingType = workingType;
            SetControlWorkingBehavior();
        }

        public void SetEzkoController(EzkoController ezkoController)
        {
            this.ezkoController = ezkoController;

            InitializeFormElements();
        }

        public void SetMaximumHeight(int height)
        {
            mainFlowLayoutPanel.MaximumSize = new Size(0, height);
        }
        #endregion

        #region Private methods

        private void InitializeFormElements()
        {
            InitializePatientNameTextBox();
            InitializeDoctorsComboBox();
            InitializePlannedActionsComboBox();
            InitializeDoneActionsTextBox();
            InitializeEventStateComboBox();
            InitializeEmailsRichTextBox();

            SetControlWorkingBehavior();
        }

        private void InitializePatientNameTextBox()
        {
            Patient[] values = ezkoController.GetPatients().ToArray();
            patientNameTextBox.AcceptsTab = true;
            patientNameTextBox.Values = values;
        }

        private void InitializeDoctorsComboBox()
        {
            var doctors = ezkoController.GetDoctors();
            foreach (var doctor in doctors)
            {
                int index = doctorsCheckBoxComboBox.Items.Add(doctor);
                if (GlobalSettings.User == null)
                    continue;

                if (doctor.ID == GlobalSettings.User.ID)
                {
                    doctorsCheckBoxComboBox.CheckBoxItems[doctor.Login].Checked = true;
                }
            }
        }

        private void InitializePlannedActionsComboBox()
        {
            var actions = ezkoController.GetActions();
            foreach (var action in actions)
                plannedActionsComboBox.Items.Add(action);
        }

        private void InitializeDoneActionsTextBox()
        {
            DatabaseCommunicator.Model.Action[] values = ezkoController.GetActions().ToArray();
            doneActionTextBox.AcceptsTab = true;
            doneActionTextBox.Values = values;
        }

        private void InitializeEventStateComboBox()
        {
            var states = ezkoController.GetEventStates();
            foreach (var state in states)
                eventStateComboBox.Items.Add(state);
        }

        private void InitializeEmailsRichTextBox()
        {
            if (GlobalSettings.User != null)
                emailsRichTextBox.Text = GlobalSettings.User.Email + ", ";
            emailsRichTextBox.Text += "sangreazul@3Dent.sk, ";
            emailsRichTextBox.Text += "EMAILNAPACIENTA@BODKAESKA.com";
        }

        private void SetControlWorkingBehavior()
        {
            switch (workingType)
            {
                case WorkingTypeEnum.Creating:
                    SetCreatingControlBeahvior();
                    break;
                case WorkingTypeEnum.Editing:
                    SetEditingControlBehavior();
                    break;
                case WorkingTypeEnum.Recreating:
                    SetRecreatingControlBehavior();
                    break;
                default:
                    break;
            }
        }

        private void SetCreatingControlBeahvior()
        {
            doneActionsPanel.Visible = false;
            doneActionsForTablePanel.Visible = false;
            updateEventPanel.Visible = false;
            plannedTextPanel.Visible = false;
            newEventButtonsPanel.Visible = true;

            foreach (EventState item in eventStateComboBox.Items)
            {
                if (item.ID == (int)DatabaseCommunicator.Enums.EventStateEnum.Planned)
                {
                    eventStateComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void SetEditingControlBehavior()
        {
            doneActionsPanel.Visible = true;
            //doneActionsForTablePanel.Visible = false;
            newEventButtonsPanel.Visible = false;
            updateEventPanel.Visible = true;
            reorderButton.Visible = true;
            plannedTextPanel.Visible = true;
        }

        private void SetRecreatingControlBehavior()
        {
            doneActionsPanel.Visible = false;
            doneActionsForTablePanel.Visible = false;
            newEventButtonsPanel.Visible = false;
            updateEventPanel.Visible = true;
            reorderButton.Visible = false;
            plannedTextPanel.Visible = false;
        }

        /// <summary>
        /// Set UI element properties to match column properties from corresponding database tables
        /// </summary>
        private void SetPanelElementsProperties()
        {
            newPatientNameTextBox.MaxLength = 30;
            newPatientSurnameTextBox.MaxLength = 30;
            newPatientPhoneTextBox.MaxLength = 20;
            newPatientEmailTextBox.MaxLength = 80;
        }

        /// <summary>
        /// Allow only values divisible by 5 for duration
        /// </summary>
        private void ValidateValue()
        {
            int value = (int)durationNumericUpDown.Value;
            if ((value % 5) != 0)
                durationInfoLabel.Visible = true;
            else
                durationInfoLabel.Visible = false;
        }

        private void AddAction()
        {
            try
            {
                DatabaseCommunicator.Model.Action action = doneActionTextBox.Tag as DatabaseCommunicator.Model.Action;

                if (action == null)
                    return;

                if(doneActionsTablePanel.Controls.Find("flatRichTextBox", true).Select(x => (DatabaseCommunicator.Model.Action)x.Tag).Contains(action))
                    return;

                doneActionsTablePanel.Visible = false;
                int lastRowIndex = doneActionsTablePanel.RowCount;
                doneActionsTablePanel.RowCount++;

                SetDoneActionsPanelForTabelPanelVisibility(doneActionsTablePanel.RowCount > 0);

                var label = new Label()
                {
                    Text = doneActionTextBox.Text,
                    //Name = "label",
                    Name = doneActionTextBox.Text + "_label",
                    //Name = doneActionsTablePanel.Name + "_" + "label_" + lastRowIndex,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                };
                label.MaximumSize = new Size(label.MaximumSize.Width, 22);

                var textBox = new FlatRichTextBox()
                {
                    //Name = doneActionsTablePanel.Name + "_" + "txt_" + lastRowIndex,
                    Name = "flatRichTextBox",
                    Dock = DockStyle.Fill,
                    Height = 22,
                    Tag = action,
                    Enabled = action.HasSpecification,
                    //TextAlign = HorizontalAlignment.Right
                };
                textBox.MaximumSize = new Size(textBox.MaximumSize.Width, 22);

                var btn = new RoundButton()
                {
                    Name = doneActionsTablePanel.Name + "_" + "btn_" + lastRowIndex,
                    Text = "x",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    RoundButtonStyle = RoundButtonStylesEnum.FlatRed,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Radius = 0
                };
                btn.MaximumSize = new Size(btn.MaximumSize.Width, 22);
                btn.Click += Btn_Click;

                doneActionsTablePanel.Controls.Add(label, 0, lastRowIndex);
                doneActionsTablePanel.Controls.Add(textBox, 1, lastRowIndex);
                doneActionsTablePanel.Controls.Add(btn, 2, lastRowIndex);

                doneActionsTablePanel.Visible = true;
                doneActionTextBox.Text = "";
                doneActionTextBox.Tag = null;
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri pridávaní výkonu sa vyskytla neočakávaná chyba.", ex);
            }
        }

        /// <summary>
        /// Removes desired row from TableLayoutPanel
        /// </summary>
        /// <param name="panel">TableLayoutPanel from which has tu be row removed</param>
        /// <param name="rowIndex">Index of row which has to be removed</param>
        private void RemoveRow(TableLayoutPanel panel, int rowIndex)
        {
            try
            {
                panel.Visible = false;
                if (rowIndex >= panel.RowCount)
                    return;

                // delete all controls of row that we want to delete
                for (int i = 0; i < panel.ColumnCount; i++)
                {
                    var control = panel.GetControlFromPosition(i, rowIndex);
                    panel.Controls.Remove(control);
                }

                // move up row controls that comes after row we want to remove
                for (int i = rowIndex + 1; i < panel.RowCount; i++)
                {
                    for (int j = 0; j < panel.ColumnCount; j++)
                    {
                        var control = panel.GetControlFromPosition(j, i);
                        if (control != null)
                        {
                            panel.SetRow(control, i - 1);
                        }
                    }
                }

                // remove last row
                //panel.RowStyles.RemoveAt(panel.RowCount - 1);
                panel.RowCount--;
                panel.Visible = true;
                SetDoneActionsPanelForTabelPanelVisibility(panel.RowCount > 0);
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri odoberaní výkonu sa vyskytla neočakávaná chyba.", ex);
            }
        }

        private void SetDoneActionsPanelForTabelPanelVisibility(bool value)
        {
            doneActionsForTablePanel.Visible = value;
        }

        #region Reseting panel
        private void ResetVisitPanel()
        {
            eventStartDateTime = null;
            isNew = false;
            eventDuration = 0m;
            ResetTextFields();
            ResetComboBoxes();
            SetControlWorkingBehavior();
        }

        private void ResetTextFields()
        {
            patientNameTextBox.Text = "";
            newPatientNameTextBox.Text = "";
            newPatientSurnameTextBox.Text = "";
            newPatientEmailTextBox.Text = "";
            newPatientPhoneTextBox.Text = "";
            eventStartTextBox.Text = "";
            eventNoteRichTextBox.Text = "";
            doneTextTextBox.Text = "";
            doneActionTextBox.Text = "";
            planedTextTextBox.Text = "";
            InitializeEmailsRichTextBox();
        }

        private void ResetComboBoxes()
        {
            SetComboBoxCheckBoxValues(doctorsCheckBoxComboBox, false);
            SetComboBoxCheckBoxValues(plannedActionsComboBox, false);
            if (GlobalSettings.User != null)
                doctorsCheckBoxComboBox.CheckBoxItems[GlobalSettings.User.ToString()].Checked = true;
        }

        private void SetComboBoxCheckBoxValues(PresentationControls.CheckBoxComboBox control, bool value)
        {
            if (control == null)
                return;

            foreach(var item in control.Items)
                control.CheckBoxItems[item.ToString()].Checked = value;
        }
        #endregion

        private bool ValidateData()
        {
            bool result = true;

            if(isNew)
            {
                if(patientName == null)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať meno pacienta");
                    newPatientNameTextBox.Focus();
                }
                else if (patientSurame == null)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať priezvisko pacienta");
                    newPatientSurnameTextBox.Focus();
                }
                else if (patientPhone == null)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať telefón na pacienta");
                    newPatientPhoneTextBox.Focus();
                }
                else if (patientEmail == null)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Musíte zadať email na pacienta");
                    newPatientEmailTextBox.Focus();
                }
            }
            else
            {
                if(patient == null)
                {
                    result = false;
                    BasicMessagesHandler.ShowInformationMessage("Musíte zvoliť pacienta");
                    patientNameTextBox.Focus();
                }
            }

            if (!result)
                return result;

            if (eventStartDateTime == null)
            {
                result = false;
                BasicMessagesHandler.ShowInformationMessage("Musíte si zvoliť dátum začiatku návštevy");
                eventStartTextBox.Focus();
            }
            else if (eventDuration == 0)
            {
                result = false;
                BasicMessagesHandler.ShowInformationMessage("Musíte si zvoliť dĺžku návštevy");
                durationNumericUpDown.Focus();
            }
            else if(eventState == null)
            {
                result = false;
                BasicMessagesHandler.ShowInformationMessage("Musíte si vybrať stav návštevy");
                eventStateComboBox.Focus();
            }

            return result;
        }

        private void CreateEvent()
        {
            if (!ValidateData())
                return;

            Patient eventPatient = patient;
            if (isNew)
            {
                eventPatient = ezkoController.CreatePatient(patientName, patientSurame, patientEmail, patientPhone);
                if (eventPatient == null)
                {
                    BasicMessagesHandler.ShowInformationMessage("Nepodarilo sa vytvoriť nového pacienta");
                    return;
                }
            }

            if (ezkoController.CreateCalendarEvent(eventPatient, doctors, eventStartDateTime.Value, eventDuration, notificationEmails,
                    eventNote, plannedActions, plannedText, eventState))
            {
                //TODO: refresh calendar
            }
            else
                BasicMessagesHandler.ShowInformationMessage("Nepodarilo sa vytvoriť návštevu");
        }

        #endregion

        #region UI events
        private void newPatientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (newPatientCheckBox.Checked)
            {
                case true:
                    patientNamePanel.Visible = false;
                    newPatientPanel.Visible = true;
                    break;
                case false:
                    patientNamePanel.Visible = true;
                    newPatientPanel.Visible = false;
                    break;
            }
        }

        private void eventStartTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point locationOnForm = eventStartTextBox.PointToScreen(Point.Empty);
                var form = new Forms.DateTimePickerForm(eventStartDateTime);
                form.Deactivate += delegate
                {
                    form.Close();
                    eventStartDateTime = form.PickedDateTime;

                    string format = "";
                    if (DateTime.Now.Year == eventStartDateTime.Value.Year)
                        format = "dd.MM, HH:mm";
                    else
                        format = "dd.MM.yyyy, HH:mm";

                    eventStartTextBox.Text = eventStartDateTime.Value.ToString(format);
                };
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(locationOnForm.X - 2, locationOnForm.Y + eventStartTextBox.Bounds.Height);
                form.ShowInTaskbar = true;
                form.Show();
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Pri výbere termínu návštevy sa vyskytla neočakávaná chyba.", ex);
            }
        }

        private void durationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ValidateValue();
        }

        private void durationNumericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateValue();
        }

        private void duration15Button_Click(object sender, EventArgs e)
        {
            durationNumericUpDown.Value = 15;
        }

        private void duration30Button_Click(object sender, EventArgs e)
        {
            durationNumericUpDown.Value = 30;
        }

        private void duration60Button_Click(object sender, EventArgs e)
        {
            durationNumericUpDown.Value = 60;
        }

        private void duration90Button_Click(object sender, EventArgs e)
        {
            durationNumericUpDown.Value = 90;
        }

        private void addDoneActionButton_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            CreateEvent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int row = doneActionsTablePanel.GetRow(button);
            RemoveRow(doneActionsTablePanel, row);
        }

        //Set the form elements text according to selected specific culture info
        private void VisitUserControl_Load(object sender, EventArgs e)
        {
            newVisitButton.Text = LanguageController.GetText(StringKeys.NewVisit);
            patientNameLabel.Text = LanguageController.GetRequiredColonText(StringKeys.Patient);
            newPatientCheckBox.Text = LanguageController.GetText(StringKeys.NewPatient);
            newPatientNameLabel.Text = LanguageController.GetRequiredText(StringKeys.Name);
            newPatientSurnameLabel.Text = LanguageController.GetRequiredText(StringKeys.Surname);
            newPatientPhoneLabel.Text = LanguageController.GetRequiredText(StringKeys.Phone);
            newPatientEmailLabel.Text = LanguageController.GetRequiredText(StringKeys.Email);
            doctorsLabel.Text = LanguageController.GetColonText(StringKeys.Doctor);
            eventStartLabel.Text = LanguageController.GetRequiredColonText(StringKeys.Start);
            eventDurationLabel.Text = LanguageController.GetRequiredColonText(StringKeys.Duration);
            fastDurationLabel.Text = LanguageController.GetColonText(StringKeys.FastSettings);
            durationInfoLabel.Text = LanguageController.GetText(StringKeys.DivisibleBy5Error);
            emailsLabel.Text = LanguageController.GetColonText(StringKeys.NotificationEmails);
            eventNoteLabel.Text = LanguageController.GetColonText(StringKeys.VisitNote);
            planedActionsLabel.Text = LanguageController.GetColonText(StringKeys.PlannedActions);
            planedTextLabel.Text = LanguageController.GetColonText(StringKeys.PlannedText);
            doneActionsLabel.Text = LanguageController.GetColonText(StringKeys.DoneActions);
            firstColumnLabel.Text = LanguageController.GetText(StringKeys.Action);
            secondColumnLabel.Text = LanguageController.GetText(StringKeys.ActionOutput);
            doneTextLabel.Text = LanguageController.GetColonText(StringKeys.DoneActionsText);
            stateLabel.Text = LanguageController.GetColonText(StringKeys.EventState);
            resetEventButton.Text = LanguageController.GetText(StringKeys.Reset);
            createEventButton.Text = LanguageController.GetText(StringKeys.CreateEvent);
            deleteEventButton.Text = LanguageController.GetText(StringKeys.DeleteEvent);
            reorderButton.Text = LanguageController.GetText(StringKeys.ReorderEvent);
            saveEventButton.Text = LanguageController.GetText(StringKeys.SaveEvent);
        }

        private void newVisitButton_Click(object sender, EventArgs e)
        {
            workingType = WorkingTypeEnum.Creating;
            ResetVisitPanel();
        }
        private void resetEventButton_Click(object sender, EventArgs e)
        {
            ResetVisitPanel();
        }
        #endregion

        private void saveEventButton_Click(object sender, EventArgs e)
        {
            var tmp = plannedActions;
            //var tmp = doneActionsTablePanel.Controls.Find("flatRichTextBox", true);

            //foreach (FlatRichTextBox item in tmp)
            //{
            //    var action = (DatabaseCommunicator.Model.Action)item.Tag;
            //    var answer = item.Text;
            //}
        }
    }
}