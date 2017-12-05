namespace EZKO.UserControls.Dashboard
{
    partial class VisitUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newVisitPanel = new System.Windows.Forms.Panel();
            this.newVisitButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.newVisitLabel = new System.Windows.Forms.Label();
            this.patientNamePanel = new System.Windows.Forms.Panel();
            this.patientNameLabel = new System.Windows.Forms.Label();
            this.patientNameTextBox = new EZKO.UserControls.Other.AutoCompleteTextBox();
            this.newPatientCheckBox = new System.Windows.Forms.CheckBox();
            this.newPatientPanel = new System.Windows.Forms.Panel();
            this.newPatientEmailTextBox = new System.Windows.Forms.TextBox();
            this.newPatientEmailLabel = new System.Windows.Forms.Label();
            this.newPatientPhoneTextBox = new System.Windows.Forms.TextBox();
            this.newPatientPhoneLabel = new System.Windows.Forms.Label();
            this.newPatientSurnameTextBox = new System.Windows.Forms.TextBox();
            this.newPatientSurnameLabel = new System.Windows.Forms.Label();
            this.newPatientNameTextBox = new System.Windows.Forms.TextBox();
            this.newPatientNameLabel = new System.Windows.Forms.Label();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.doneActionsPanel = new System.Windows.Forms.Panel();
            this.doneActionTextBox = new EZKO.UserControls.Other.AutoCompleteTextBox();
            this.doneActionsLabel = new System.Windows.Forms.Label();
            this.addDoneActionButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.durationNumericUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.duration90Button = new EZKO.UserControls.FlatControls.RoundButton();
            this.duration60Button = new EZKO.UserControls.FlatControls.RoundButton();
            this.duration30Button = new EZKO.UserControls.FlatControls.RoundButton();
            this.duration15Button = new EZKO.UserControls.FlatControls.RoundButton();
            this.eventNoteRichTextBox = new EZKO.UserControls.FlatControls.FlatRichTextBox();
            this.emailsRichTextBox = new EZKO.UserControls.FlatControls.FlatRichTextBox();
            this.durationInfoLabel = new System.Windows.Forms.Label();
            this.doneActionsForTablePanel = new System.Windows.Forms.Panel();
            this.secondColumnLabel = new System.Windows.Forms.Label();
            this.doneActionsTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.firstColumnLabel = new System.Windows.Forms.Label();
            this.planedTextTextBox = new System.Windows.Forms.TextBox();
            this.plannedActionsComboBox = new PresentationControls.CheckBoxComboBox();
            this.planedTextLabel = new System.Windows.Forms.Label();
            this.planedActionsLabel = new System.Windows.Forms.Label();
            this.eventNoteLabel = new System.Windows.Forms.Label();
            this.emailsLabel = new System.Windows.Forms.Label();
            this.fastDurationLabel = new System.Windows.Forms.Label();
            this.eventDurationLabel = new System.Windows.Forms.Label();
            this.eventStartTextBox = new System.Windows.Forms.TextBox();
            this.eventStartLabel = new System.Windows.Forms.Label();
            this.doctorsCheckBoxComboBox = new PresentationControls.CheckBoxComboBox();
            this.doctorsLabel = new System.Windows.Forms.Label();
            this.plannedTextPanel = new System.Windows.Forms.Panel();
            this.doneTextLabel = new System.Windows.Forms.Label();
            this.doneTextTextBox = new System.Windows.Forms.TextBox();
            this.statePanel = new System.Windows.Forms.Panel();
            this.eventStateComboBox = new System.Windows.Forms.ComboBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.newEventButtonsPanel = new System.Windows.Forms.Panel();
            this.createEventButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.resetEventButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.updateEventPanel = new System.Windows.Forms.Panel();
            this.reorderButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.saveEventButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.deleteEventButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainFlowLayoutPanel.SuspendLayout();
            this.newVisitPanel.SuspendLayout();
            this.patientNamePanel.SuspendLayout();
            this.newPatientPanel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.doneActionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            this.doneActionsForTablePanel.SuspendLayout();
            this.plannedTextPanel.SuspendLayout();
            this.statePanel.SuspendLayout();
            this.newEventButtonsPanel.SuspendLayout();
            this.updateEventPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.AutoScroll = true;
            this.mainFlowLayoutPanel.AutoSize = true;
            this.mainFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainFlowLayoutPanel.Controls.Add(this.newVisitPanel);
            this.mainFlowLayoutPanel.Controls.Add(this.patientNamePanel);
            this.mainFlowLayoutPanel.Controls.Add(this.newPatientCheckBox);
            this.mainFlowLayoutPanel.Controls.Add(this.newPatientPanel);
            this.mainFlowLayoutPanel.Controls.Add(this.middlePanel);
            this.mainFlowLayoutPanel.Controls.Add(this.plannedTextPanel);
            this.mainFlowLayoutPanel.Controls.Add(this.statePanel);
            this.mainFlowLayoutPanel.Controls.Add(this.newEventButtonsPanel);
            this.mainFlowLayoutPanel.Controls.Add(this.updateEventPanel);
            this.mainFlowLayoutPanel.Controls.Add(this.panel1);
            this.mainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainFlowLayoutPanel.MaximumSize = new System.Drawing.Size(385, 800);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(385, 800);
            this.mainFlowLayoutPanel.TabIndex = 0;
            // 
            // newVisitPanel
            // 
            this.newVisitPanel.BackColor = System.Drawing.Color.White;
            this.newVisitPanel.Controls.Add(this.newVisitButton);
            this.newVisitPanel.Controls.Add(this.newVisitLabel);
            this.newVisitPanel.Location = new System.Drawing.Point(2, 2);
            this.newVisitPanel.Margin = new System.Windows.Forms.Padding(2);
            this.newVisitPanel.Name = "newVisitPanel";
            this.newVisitPanel.Size = new System.Drawing.Size(376, 34);
            this.newVisitPanel.TabIndex = 0;
            // 
            // newVisitButton
            // 
            this.newVisitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.newVisitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newVisitButton.FlatAppearance.BorderSize = 0;
            this.newVisitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.newVisitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.newVisitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newVisitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.newVisitButton.ForeColor = System.Drawing.Color.White;
            this.newVisitButton.Location = new System.Drawing.Point(0, 0);
            this.newVisitButton.Name = "newVisitButton";
            this.newVisitButton.Radius = 5;
            this.newVisitButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.newVisitButton.Size = new System.Drawing.Size(376, 34);
            this.newVisitButton.TabIndex = 2;
            this.newVisitButton.Text = "Nová návšteva";
            this.newVisitButton.UseVisualStyleBackColor = false;
            this.newVisitButton.Click += new System.EventHandler(this.newVisitButton_Click);
            // 
            // newVisitLabel
            // 
            this.newVisitLabel.AutoSize = true;
            this.newVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newVisitLabel.Location = new System.Drawing.Point(2, 6);
            this.newVisitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newVisitLabel.Name = "newVisitLabel";
            this.newVisitLabel.Size = new System.Drawing.Size(112, 20);
            this.newVisitLabel.TabIndex = 0;
            this.newVisitLabel.Text = "Nová návšteva";
            // 
            // patientNamePanel
            // 
            this.patientNamePanel.Controls.Add(this.patientNameLabel);
            this.patientNamePanel.Controls.Add(this.patientNameTextBox);
            this.patientNamePanel.Location = new System.Drawing.Point(2, 40);
            this.patientNamePanel.Margin = new System.Windows.Forms.Padding(2);
            this.patientNamePanel.Name = "patientNamePanel";
            this.patientNamePanel.Size = new System.Drawing.Size(266, 20);
            this.patientNamePanel.TabIndex = 1;
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.AutoSize = true;
            this.patientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientNameLabel.Location = new System.Drawing.Point(2, 2);
            this.patientNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new System.Drawing.Size(59, 13);
            this.patientNameLabel.TabIndex = 0;
            this.patientNameLabel.Text = "Pacient*:";
            // 
            // patientNameTextBox
            // 
            this.patientNameTextBox.Location = new System.Drawing.Point(66, 0);
            this.patientNameTextBox.Name = "patientNameTextBox";
            this.patientNameTextBox.Size = new System.Drawing.Size(199, 20);
            this.patientNameTextBox.TabIndex = 32;
            this.patientNameTextBox.Values = null;
            // 
            // newPatientCheckBox
            // 
            this.newPatientCheckBox.AutoSize = true;
            this.newPatientCheckBox.Location = new System.Drawing.Point(278, 40);
            this.newPatientCheckBox.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.newPatientCheckBox.Name = "newPatientCheckBox";
            this.newPatientCheckBox.Size = new System.Drawing.Size(89, 17);
            this.newPatientCheckBox.TabIndex = 2;
            this.newPatientCheckBox.Text = "Nový pacient";
            this.newPatientCheckBox.UseVisualStyleBackColor = true;
            this.newPatientCheckBox.CheckedChanged += new System.EventHandler(this.newPatientCheckBox_CheckedChanged);
            // 
            // newPatientPanel
            // 
            this.newPatientPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.newPatientPanel.Controls.Add(this.newPatientEmailTextBox);
            this.newPatientPanel.Controls.Add(this.newPatientEmailLabel);
            this.newPatientPanel.Controls.Add(this.newPatientPhoneTextBox);
            this.newPatientPanel.Controls.Add(this.newPatientPhoneLabel);
            this.newPatientPanel.Controls.Add(this.newPatientSurnameTextBox);
            this.newPatientPanel.Controls.Add(this.newPatientSurnameLabel);
            this.newPatientPanel.Controls.Add(this.newPatientNameTextBox);
            this.newPatientPanel.Controls.Add(this.newPatientNameLabel);
            this.newPatientPanel.Location = new System.Drawing.Point(2, 64);
            this.newPatientPanel.Margin = new System.Windows.Forms.Padding(2);
            this.newPatientPanel.Name = "newPatientPanel";
            this.newPatientPanel.Size = new System.Drawing.Size(376, 88);
            this.newPatientPanel.TabIndex = 3;
            // 
            // newPatientEmailTextBox
            // 
            this.newPatientEmailTextBox.Location = new System.Drawing.Point(193, 58);
            this.newPatientEmailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.newPatientEmailTextBox.Name = "newPatientEmailTextBox";
            this.newPatientEmailTextBox.Size = new System.Drawing.Size(163, 20);
            this.newPatientEmailTextBox.TabIndex = 7;
            // 
            // newPatientEmailLabel
            // 
            this.newPatientEmailLabel.AutoSize = true;
            this.newPatientEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPatientEmailLabel.Location = new System.Drawing.Point(190, 43);
            this.newPatientEmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newPatientEmailLabel.Name = "newPatientEmailLabel";
            this.newPatientEmailLabel.Size = new System.Drawing.Size(42, 13);
            this.newPatientEmailLabel.TabIndex = 6;
            this.newPatientEmailLabel.Text = "Email*";
            // 
            // newPatientPhoneTextBox
            // 
            this.newPatientPhoneTextBox.Location = new System.Drawing.Point(19, 58);
            this.newPatientPhoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.newPatientPhoneTextBox.Name = "newPatientPhoneTextBox";
            this.newPatientPhoneTextBox.Size = new System.Drawing.Size(163, 20);
            this.newPatientPhoneTextBox.TabIndex = 5;
            // 
            // newPatientPhoneLabel
            // 
            this.newPatientPhoneLabel.AutoSize = true;
            this.newPatientPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPatientPhoneLabel.Location = new System.Drawing.Point(17, 43);
            this.newPatientPhoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newPatientPhoneLabel.Name = "newPatientPhoneLabel";
            this.newPatientPhoneLabel.Size = new System.Drawing.Size(55, 13);
            this.newPatientPhoneLabel.TabIndex = 4;
            this.newPatientPhoneLabel.Text = "Telefón*";
            // 
            // newPatientSurnameTextBox
            // 
            this.newPatientSurnameTextBox.Location = new System.Drawing.Point(193, 21);
            this.newPatientSurnameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.newPatientSurnameTextBox.Name = "newPatientSurnameTextBox";
            this.newPatientSurnameTextBox.Size = new System.Drawing.Size(163, 20);
            this.newPatientSurnameTextBox.TabIndex = 3;
            // 
            // newPatientSurnameLabel
            // 
            this.newPatientSurnameLabel.AutoSize = true;
            this.newPatientSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPatientSurnameLabel.Location = new System.Drawing.Point(190, 6);
            this.newPatientSurnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newPatientSurnameLabel.Name = "newPatientSurnameLabel";
            this.newPatientSurnameLabel.Size = new System.Drawing.Size(70, 13);
            this.newPatientSurnameLabel.TabIndex = 2;
            this.newPatientSurnameLabel.Text = "Priezvisko*";
            // 
            // newPatientNameTextBox
            // 
            this.newPatientNameTextBox.Location = new System.Drawing.Point(19, 21);
            this.newPatientNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.newPatientNameTextBox.Name = "newPatientNameTextBox";
            this.newPatientNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.newPatientNameTextBox.TabIndex = 1;
            // 
            // newPatientNameLabel
            // 
            this.newPatientNameLabel.AutoSize = true;
            this.newPatientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPatientNameLabel.Location = new System.Drawing.Point(17, 6);
            this.newPatientNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newPatientNameLabel.Name = "newPatientNameLabel";
            this.newPatientNameLabel.Size = new System.Drawing.Size(43, 13);
            this.newPatientNameLabel.TabIndex = 0;
            this.newPatientNameLabel.Text = "Meno*";
            // 
            // middlePanel
            // 
            this.middlePanel.AutoSize = true;
            this.middlePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.middlePanel.Controls.Add(this.doneActionsPanel);
            this.middlePanel.Controls.Add(this.durationNumericUpDown);
            this.middlePanel.Controls.Add(this.duration90Button);
            this.middlePanel.Controls.Add(this.duration60Button);
            this.middlePanel.Controls.Add(this.duration30Button);
            this.middlePanel.Controls.Add(this.duration15Button);
            this.middlePanel.Controls.Add(this.eventNoteRichTextBox);
            this.middlePanel.Controls.Add(this.emailsRichTextBox);
            this.middlePanel.Controls.Add(this.durationInfoLabel);
            this.middlePanel.Controls.Add(this.doneActionsForTablePanel);
            this.middlePanel.Controls.Add(this.planedTextTextBox);
            this.middlePanel.Controls.Add(this.plannedActionsComboBox);
            this.middlePanel.Controls.Add(this.planedTextLabel);
            this.middlePanel.Controls.Add(this.planedActionsLabel);
            this.middlePanel.Controls.Add(this.eventNoteLabel);
            this.middlePanel.Controls.Add(this.emailsLabel);
            this.middlePanel.Controls.Add(this.fastDurationLabel);
            this.middlePanel.Controls.Add(this.eventDurationLabel);
            this.middlePanel.Controls.Add(this.eventStartTextBox);
            this.middlePanel.Controls.Add(this.eventStartLabel);
            this.middlePanel.Controls.Add(this.doctorsCheckBoxComboBox);
            this.middlePanel.Controls.Add(this.doctorsLabel);
            this.middlePanel.Location = new System.Drawing.Point(2, 156);
            this.middlePanel.Margin = new System.Windows.Forms.Padding(2);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(379, 377);
            this.middlePanel.TabIndex = 4;
            // 
            // doneActionsPanel
            // 
            this.doneActionsPanel.Controls.Add(this.doneActionTextBox);
            this.doneActionsPanel.Controls.Add(this.doneActionsLabel);
            this.doneActionsPanel.Controls.Add(this.addDoneActionButton);
            this.doneActionsPanel.Location = new System.Drawing.Point(6, 281);
            this.doneActionsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.doneActionsPanel.Name = "doneActionsPanel";
            this.doneActionsPanel.Size = new System.Drawing.Size(369, 46);
            this.doneActionsPanel.TabIndex = 34;
            // 
            // doneActionTextBox
            // 
            this.doneActionTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.doneActionTextBox.Location = new System.Drawing.Point(2, 19);
            this.doneActionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.doneActionTextBox.Name = "doneActionTextBox";
            this.doneActionTextBox.Size = new System.Drawing.Size(321, 20);
            this.doneActionTextBox.TabIndex = 30;
            this.doneActionTextBox.Values = null;
            // 
            // doneActionsLabel
            // 
            this.doneActionsLabel.AutoSize = true;
            this.doneActionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneActionsLabel.Location = new System.Drawing.Point(-3, 5);
            this.doneActionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doneActionsLabel.Name = "doneActionsLabel";
            this.doneActionsLabel.Size = new System.Drawing.Size(111, 13);
            this.doneActionsLabel.TabIndex = 22;
            this.doneActionsLabel.Text = "Vykonané výkony:";
            // 
            // addDoneActionButton
            // 
            this.addDoneActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.addDoneActionButton.FlatAppearance.BorderSize = 0;
            this.addDoneActionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.addDoneActionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.addDoneActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDoneActionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.addDoneActionButton.ForeColor = System.Drawing.Color.White;
            this.addDoneActionButton.Location = new System.Drawing.Point(326, 17);
            this.addDoneActionButton.Margin = new System.Windows.Forms.Padding(2);
            this.addDoneActionButton.Name = "addDoneActionButton";
            this.addDoneActionButton.Radius = 5;
            this.addDoneActionButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addDoneActionButton.Size = new System.Drawing.Size(43, 22);
            this.addDoneActionButton.TabIndex = 31;
            this.addDoneActionButton.Text = "✓";
            this.addDoneActionButton.UseVisualStyleBackColor = false;
            this.addDoneActionButton.Click += new System.EventHandler(this.addDoneActionButton_Click);
            // 
            // durationNumericUpDown
            // 
            this.durationNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.durationNumericUpDown.LabelText = "minút";
            this.durationNumericUpDown.Location = new System.Drawing.Point(165, 47);
            this.durationNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.durationNumericUpDown.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.durationNumericUpDown.Name = "durationNumericUpDown";
            this.durationNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.durationNumericUpDown.TabIndex = 33;
            this.durationNumericUpDown.ValueChanged += new System.EventHandler(this.durationNumericUpDown_ValueChanged);
            // 
            // duration90Button
            // 
            this.duration90Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.duration90Button.FlatAppearance.BorderSize = 0;
            this.duration90Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration90Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration90Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duration90Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.duration90Button.ForeColor = System.Drawing.Color.White;
            this.duration90Button.Location = new System.Drawing.Point(341, 44);
            this.duration90Button.Margin = new System.Windows.Forms.Padding(2);
            this.duration90Button.Name = "duration90Button";
            this.duration90Button.Radius = 5;
            this.duration90Button.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.duration90Button.Size = new System.Drawing.Size(33, 22);
            this.duration90Button.TabIndex = 30;
            this.duration90Button.Text = "90";
            this.duration90Button.UseVisualStyleBackColor = false;
            this.duration90Button.Click += new System.EventHandler(this.duration90Button_Click);
            // 
            // duration60Button
            // 
            this.duration60Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.duration60Button.FlatAppearance.BorderSize = 0;
            this.duration60Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration60Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration60Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duration60Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.duration60Button.ForeColor = System.Drawing.Color.White;
            this.duration60Button.Location = new System.Drawing.Point(315, 44);
            this.duration60Button.Margin = new System.Windows.Forms.Padding(2);
            this.duration60Button.Name = "duration60Button";
            this.duration60Button.Radius = 5;
            this.duration60Button.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.duration60Button.Size = new System.Drawing.Size(33, 22);
            this.duration60Button.TabIndex = 29;
            this.duration60Button.Text = "60";
            this.duration60Button.UseVisualStyleBackColor = false;
            this.duration60Button.Click += new System.EventHandler(this.duration60Button_Click);
            // 
            // duration30Button
            // 
            this.duration30Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.duration30Button.FlatAppearance.BorderSize = 0;
            this.duration30Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration30Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration30Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duration30Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.duration30Button.ForeColor = System.Drawing.Color.White;
            this.duration30Button.Location = new System.Drawing.Point(289, 44);
            this.duration30Button.Margin = new System.Windows.Forms.Padding(2);
            this.duration30Button.Name = "duration30Button";
            this.duration30Button.Radius = 5;
            this.duration30Button.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.duration30Button.Size = new System.Drawing.Size(33, 22);
            this.duration30Button.TabIndex = 28;
            this.duration30Button.Text = "30";
            this.duration30Button.UseVisualStyleBackColor = false;
            this.duration30Button.Click += new System.EventHandler(this.duration30Button_Click);
            // 
            // duration15Button
            // 
            this.duration15Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.duration15Button.FlatAppearance.BorderSize = 0;
            this.duration15Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration15Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.duration15Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.duration15Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.duration15Button.ForeColor = System.Drawing.Color.White;
            this.duration15Button.Location = new System.Drawing.Point(263, 44);
            this.duration15Button.Margin = new System.Windows.Forms.Padding(2);
            this.duration15Button.Name = "duration15Button";
            this.duration15Button.Radius = 5;
            this.duration15Button.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.duration15Button.Size = new System.Drawing.Size(33, 22);
            this.duration15Button.TabIndex = 27;
            this.duration15Button.Text = "15";
            this.duration15Button.UseVisualStyleBackColor = false;
            this.duration15Button.Click += new System.EventHandler(this.duration15Button_Click);
            // 
            // eventNoteRichTextBox
            // 
            this.eventNoteRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventNoteRichTextBox.Location = new System.Drawing.Point(6, 157);
            this.eventNoteRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eventNoteRichTextBox.Name = "eventNoteRichTextBox";
            this.eventNoteRichTextBox.Size = new System.Drawing.Size(369, 47);
            this.eventNoteRichTextBox.TabIndex = 26;
            // 
            // emailsRichTextBox
            // 
            this.emailsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailsRichTextBox.Location = new System.Drawing.Point(5, 91);
            this.emailsRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailsRichTextBox.Name = "emailsRichTextBox";
            this.emailsRichTextBox.Size = new System.Drawing.Size(369, 47);
            this.emailsRichTextBox.TabIndex = 26;
            // 
            // durationInfoLabel
            // 
            this.durationInfoLabel.AutoSize = true;
            this.durationInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.durationInfoLabel.Location = new System.Drawing.Point(176, 68);
            this.durationInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.durationInfoLabel.Name = "durationInfoLabel";
            this.durationInfoLabel.Size = new System.Drawing.Size(191, 13);
            this.durationInfoLabel.TabIndex = 12;
            this.durationInfoLabel.Text = "Zadaná hodnota musí byť násobkom 5";
            // 
            // doneActionsForTablePanel
            // 
            this.doneActionsForTablePanel.AutoScroll = true;
            this.doneActionsForTablePanel.AutoSize = true;
            this.doneActionsForTablePanel.Controls.Add(this.secondColumnLabel);
            this.doneActionsForTablePanel.Controls.Add(this.doneActionsTablePanel);
            this.doneActionsForTablePanel.Controls.Add(this.firstColumnLabel);
            this.doneActionsForTablePanel.Location = new System.Drawing.Point(5, 322);
            this.doneActionsForTablePanel.Margin = new System.Windows.Forms.Padding(2);
            this.doneActionsForTablePanel.MaximumSize = new System.Drawing.Size(370, 107);
            this.doneActionsForTablePanel.Name = "doneActionsForTablePanel";
            this.doneActionsForTablePanel.Size = new System.Drawing.Size(370, 53);
            this.doneActionsForTablePanel.TabIndex = 25;
            // 
            // secondColumnLabel
            // 
            this.secondColumnLabel.AutoSize = true;
            this.secondColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondColumnLabel.Location = new System.Drawing.Point(157, 8);
            this.secondColumnLabel.Name = "secondColumnLabel";
            this.secondColumnLabel.Size = new System.Drawing.Size(45, 13);
            this.secondColumnLabel.TabIndex = 26;
            this.secondColumnLabel.Text = "Výstup";
            // 
            // doneActionsTablePanel
            // 
            this.doneActionsTablePanel.AutoSize = true;
            this.doneActionsTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.doneActionsTablePanel.ColumnCount = 3;
            this.doneActionsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.46729F));
            this.doneActionsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.53271F));
            this.doneActionsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.doneActionsTablePanel.Location = new System.Drawing.Point(0, 23);
            this.doneActionsTablePanel.Margin = new System.Windows.Forms.Padding(2);
            this.doneActionsTablePanel.MinimumSize = new System.Drawing.Size(350, 28);
            this.doneActionsTablePanel.Name = "doneActionsTablePanel";
            this.doneActionsTablePanel.RowCount = 1;
            this.doneActionsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doneActionsTablePanel.Size = new System.Drawing.Size(350, 28);
            this.doneActionsTablePanel.TabIndex = 27;
            // 
            // firstColumnLabel
            // 
            this.firstColumnLabel.AutoSize = true;
            this.firstColumnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstColumnLabel.Location = new System.Drawing.Point(3, 8);
            this.firstColumnLabel.Name = "firstColumnLabel";
            this.firstColumnLabel.Size = new System.Drawing.Size(42, 13);
            this.firstColumnLabel.TabIndex = 26;
            this.firstColumnLabel.Text = "Výkon";
            // 
            // planedTextTextBox
            // 
            this.planedTextTextBox.Location = new System.Drawing.Point(6, 260);
            this.planedTextTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.planedTextTextBox.Name = "planedTextTextBox";
            this.planedTextTextBox.Size = new System.Drawing.Size(370, 20);
            this.planedTextTextBox.TabIndex = 23;
            // 
            // plannedActionsComboBox
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plannedActionsComboBox.CheckBoxProperties = checkBoxProperties1;
            this.plannedActionsComboBox.DisplayMemberSingleItem = "";
            this.plannedActionsComboBox.FormattingEnabled = true;
            this.plannedActionsComboBox.Location = new System.Drawing.Point(5, 222);
            this.plannedActionsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.plannedActionsComboBox.Name = "plannedActionsComboBox";
            this.plannedActionsComboBox.Size = new System.Drawing.Size(369, 21);
            this.plannedActionsComboBox.TabIndex = 19;
            // 
            // planedTextLabel
            // 
            this.planedTextLabel.AutoSize = true;
            this.planedTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planedTextLabel.Location = new System.Drawing.Point(3, 245);
            this.planedTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.planedTextLabel.Name = "planedTextLabel";
            this.planedTextLabel.Size = new System.Drawing.Size(96, 13);
            this.planedTextLabel.TabIndex = 22;
            this.planedTextLabel.Text = "Plánované text:";
            // 
            // planedActionsLabel
            // 
            this.planedActionsLabel.AutoSize = true;
            this.planedActionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planedActionsLabel.Location = new System.Drawing.Point(2, 207);
            this.planedActionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.planedActionsLabel.Name = "planedActionsLabel";
            this.planedActionsLabel.Size = new System.Drawing.Size(115, 13);
            this.planedActionsLabel.TabIndex = 18;
            this.planedActionsLabel.Text = "Plánované výkony:";
            // 
            // eventNoteLabel
            // 
            this.eventNoteLabel.AutoSize = true;
            this.eventNoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventNoteLabel.Location = new System.Drawing.Point(2, 141);
            this.eventNoteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eventNoteLabel.Name = "eventNoteLabel";
            this.eventNoteLabel.Size = new System.Drawing.Size(143, 13);
            this.eventNoteLabel.TabIndex = 16;
            this.eventNoteLabel.Text = "Poznámka ku návšteve:";
            // 
            // emailsLabel
            // 
            this.emailsLabel.AutoSize = true;
            this.emailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailsLabel.Location = new System.Drawing.Point(2, 75);
            this.emailsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailsLabel.Name = "emailsLabel";
            this.emailsLabel.Size = new System.Drawing.Size(227, 13);
            this.emailsLabel.TabIndex = 13;
            this.emailsLabel.Text = "Notifikačné emaily (oddeľujte čiarkou):";
            // 
            // fastDurationLabel
            // 
            this.fastDurationLabel.AutoSize = true;
            this.fastDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastDurationLabel.Location = new System.Drawing.Point(258, 29);
            this.fastDurationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fastDurationLabel.Name = "fastDurationLabel";
            this.fastDurationLabel.Size = new System.Drawing.Size(116, 13);
            this.fastDurationLabel.TabIndex = 7;
            this.fastDurationLabel.Text = "Rýchle nastavenie:";
            // 
            // eventDurationLabel
            // 
            this.eventDurationLabel.AutoSize = true;
            this.eventDurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDurationLabel.Location = new System.Drawing.Point(162, 29);
            this.eventDurationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eventDurationLabel.Name = "eventDurationLabel";
            this.eventDurationLabel.Size = new System.Drawing.Size(59, 13);
            this.eventDurationLabel.TabIndex = 4;
            this.eventDurationLabel.Text = "Trvanie*:";
            // 
            // eventStartTextBox
            // 
            this.eventStartTextBox.Location = new System.Drawing.Point(5, 47);
            this.eventStartTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.eventStartTextBox.Name = "eventStartTextBox";
            this.eventStartTextBox.ReadOnly = true;
            this.eventStartTextBox.Size = new System.Drawing.Size(157, 20);
            this.eventStartTextBox.TabIndex = 3;
            this.eventStartTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.eventStartTextBox_MouseClick);
            // 
            // eventStartLabel
            // 
            this.eventStartLabel.AutoSize = true;
            this.eventStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventStartLabel.Location = new System.Drawing.Point(3, 29);
            this.eventStartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eventStartLabel.Name = "eventStartLabel";
            this.eventStartLabel.Size = new System.Drawing.Size(66, 13);
            this.eventStartLabel.TabIndex = 2;
            this.eventStartLabel.Text = "Začiatok*:";
            // 
            // doctorsCheckBoxComboBox
            // 
            checkBoxProperties2.AutoSize = true;
            checkBoxProperties2.FlatAppearanceBorderColor = System.Drawing.Color.Silver;
            checkBoxProperties2.FlatAppearanceCheckedBackColor = System.Drawing.Color.Red;
            checkBoxProperties2.FlatAppearanceMouseDownBackColor = System.Drawing.Color.Lime;
            checkBoxProperties2.FlatAppearanceMouseOverBackColor = System.Drawing.Color.Cyan;
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.doctorsCheckBoxComboBox.CheckBoxProperties = checkBoxProperties2;
            this.doctorsCheckBoxComboBox.DisplayMemberSingleItem = "";
            this.doctorsCheckBoxComboBox.FormattingEnabled = true;
            this.doctorsCheckBoxComboBox.Location = new System.Drawing.Point(62, 4);
            this.doctorsCheckBoxComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.doctorsCheckBoxComboBox.Name = "doctorsCheckBoxComboBox";
            this.doctorsCheckBoxComboBox.Size = new System.Drawing.Size(312, 21);
            this.doctorsCheckBoxComboBox.Sorted = true;
            this.doctorsCheckBoxComboBox.TabIndex = 1;
            // 
            // doctorsLabel
            // 
            this.doctorsLabel.AutoSize = true;
            this.doctorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorsLabel.Location = new System.Drawing.Point(2, 7);
            this.doctorsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doctorsLabel.Name = "doctorsLabel";
            this.doctorsLabel.Size = new System.Drawing.Size(49, 13);
            this.doctorsLabel.TabIndex = 0;
            this.doctorsLabel.Text = "Doktor:";
            // 
            // plannedTextPanel
            // 
            this.plannedTextPanel.AutoSize = true;
            this.plannedTextPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plannedTextPanel.Controls.Add(this.doneTextLabel);
            this.plannedTextPanel.Controls.Add(this.doneTextTextBox);
            this.plannedTextPanel.Location = new System.Drawing.Point(2, 537);
            this.plannedTextPanel.Margin = new System.Windows.Forms.Padding(2);
            this.plannedTextPanel.Name = "plannedTextPanel";
            this.plannedTextPanel.Size = new System.Drawing.Size(377, 37);
            this.plannedTextPanel.TabIndex = 26;
            // 
            // doneTextLabel
            // 
            this.doneTextLabel.AutoSize = true;
            this.doneTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneTextLabel.Location = new System.Drawing.Point(3, 0);
            this.doneTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doneTextLabel.Name = "doneTextLabel";
            this.doneTextLabel.Size = new System.Drawing.Size(92, 13);
            this.doneTextLabel.TabIndex = 24;
            this.doneTextLabel.Text = "Vykonané text:";
            // 
            // doneTextTextBox
            // 
            this.doneTextTextBox.Location = new System.Drawing.Point(5, 15);
            this.doneTextTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.doneTextTextBox.Name = "doneTextTextBox";
            this.doneTextTextBox.Size = new System.Drawing.Size(370, 20);
            this.doneTextTextBox.TabIndex = 25;
            // 
            // statePanel
            // 
            this.statePanel.AutoSize = true;
            this.statePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statePanel.Controls.Add(this.eventStateComboBox);
            this.statePanel.Controls.Add(this.stateLabel);
            this.statePanel.Location = new System.Drawing.Point(3, 579);
            this.statePanel.Name = "statePanel";
            this.statePanel.Size = new System.Drawing.Size(378, 27);
            this.statePanel.TabIndex = 27;
            // 
            // eventStateComboBox
            // 
            this.eventStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventStateComboBox.FormattingEnabled = true;
            this.eventStateComboBox.Location = new System.Drawing.Point(181, 3);
            this.eventStateComboBox.Name = "eventStateComboBox";
            this.eventStateComboBox.Size = new System.Drawing.Size(194, 21);
            this.eventStateComboBox.TabIndex = 27;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(5, 6);
            this.stateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(37, 13);
            this.stateLabel.TabIndex = 26;
            this.stateLabel.Text = "Stav:";
            // 
            // newEventButtonsPanel
            // 
            this.newEventButtonsPanel.Controls.Add(this.createEventButton);
            this.newEventButtonsPanel.Controls.Add(this.resetEventButton);
            this.newEventButtonsPanel.Location = new System.Drawing.Point(2, 611);
            this.newEventButtonsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.newEventButtonsPanel.Name = "newEventButtonsPanel";
            this.newEventButtonsPanel.Size = new System.Drawing.Size(383, 31);
            this.newEventButtonsPanel.TabIndex = 28;
            // 
            // createEventButton
            // 
            this.createEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.createEventButton.FlatAppearance.BorderSize = 0;
            this.createEventButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.createEventButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.createEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createEventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.createEventButton.ForeColor = System.Drawing.Color.White;
            this.createEventButton.Location = new System.Drawing.Point(233, 2);
            this.createEventButton.Margin = new System.Windows.Forms.Padding(2);
            this.createEventButton.Name = "createEventButton";
            this.createEventButton.Radius = 5;
            this.createEventButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.createEventButton.Size = new System.Drawing.Size(143, 27);
            this.createEventButton.TabIndex = 1;
            this.createEventButton.Text = "+ Vytvoriť návštevu";
            this.createEventButton.UseVisualStyleBackColor = false;
            this.createEventButton.Click += new System.EventHandler(this.createEventButton_Click);
            // 
            // resetEventButton
            // 
            this.resetEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.resetEventButton.FlatAppearance.BorderSize = 0;
            this.resetEventButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.resetEventButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.resetEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetEventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.resetEventButton.ForeColor = System.Drawing.Color.White;
            this.resetEventButton.Location = new System.Drawing.Point(5, 2);
            this.resetEventButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetEventButton.Name = "resetEventButton";
            this.resetEventButton.Radius = 5;
            this.resetEventButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatRed;
            this.resetEventButton.Size = new System.Drawing.Size(50, 27);
            this.resetEventButton.TabIndex = 0;
            this.resetEventButton.Text = "Reset";
            this.resetEventButton.UseVisualStyleBackColor = false;
            // 
            // updateEventPanel
            // 
            this.updateEventPanel.Controls.Add(this.reorderButton);
            this.updateEventPanel.Controls.Add(this.saveEventButton);
            this.updateEventPanel.Controls.Add(this.deleteEventButton);
            this.updateEventPanel.Location = new System.Drawing.Point(2, 646);
            this.updateEventPanel.Margin = new System.Windows.Forms.Padding(2);
            this.updateEventPanel.Name = "updateEventPanel";
            this.updateEventPanel.Size = new System.Drawing.Size(383, 31);
            this.updateEventPanel.TabIndex = 29;
            // 
            // reorderButton
            // 
            this.reorderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.reorderButton.FlatAppearance.BorderSize = 0;
            this.reorderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.reorderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.reorderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reorderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.reorderButton.ForeColor = System.Drawing.Color.White;
            this.reorderButton.Location = new System.Drawing.Point(176, 2);
            this.reorderButton.Margin = new System.Windows.Forms.Padding(2);
            this.reorderButton.Name = "reorderButton";
            this.reorderButton.Radius = 5;
            this.reorderButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.reorderButton.Size = new System.Drawing.Size(121, 27);
            this.reorderButton.TabIndex = 2;
            this.reorderButton.Text = "Znovu objednať";
            this.reorderButton.UseVisualStyleBackColor = false;
            // 
            // saveEventButton
            // 
            this.saveEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.saveEventButton.FlatAppearance.BorderSize = 0;
            this.saveEventButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.saveEventButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.saveEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveEventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.saveEventButton.ForeColor = System.Drawing.Color.White;
            this.saveEventButton.Location = new System.Drawing.Point(301, 2);
            this.saveEventButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveEventButton.Name = "saveEventButton";
            this.saveEventButton.Radius = 5;
            this.saveEventButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.saveEventButton.Size = new System.Drawing.Size(77, 27);
            this.saveEventButton.TabIndex = 1;
            this.saveEventButton.Text = "Uložiť";
            this.saveEventButton.UseVisualStyleBackColor = false;
            this.saveEventButton.Click += new System.EventHandler(this.saveEventButton_Click);
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.deleteEventButton.FlatAppearance.BorderSize = 0;
            this.deleteEventButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.deleteEventButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.deleteEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteEventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.deleteEventButton.ForeColor = System.Drawing.Color.White;
            this.deleteEventButton.Location = new System.Drawing.Point(5, 2);
            this.deleteEventButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Radius = 5;
            this.deleteEventButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatRed;
            this.deleteEventButton.Size = new System.Drawing.Size(74, 27);
            this.deleteEventButton.TabIndex = 0;
            this.deleteEventButton.Text = "Zmazať";
            this.deleteEventButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(2, 681);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 31;
            // 
            // VisitUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainFlowLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VisitUserControl";
            this.Size = new System.Drawing.Size(389, 800);
            this.Load += new System.EventHandler(this.VisitUserControl_Load);
            this.mainFlowLayoutPanel.ResumeLayout(false);
            this.mainFlowLayoutPanel.PerformLayout();
            this.newVisitPanel.ResumeLayout(false);
            this.newVisitPanel.PerformLayout();
            this.patientNamePanel.ResumeLayout(false);
            this.patientNamePanel.PerformLayout();
            this.newPatientPanel.ResumeLayout(false);
            this.newPatientPanel.PerformLayout();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.doneActionsPanel.ResumeLayout(false);
            this.doneActionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            this.doneActionsForTablePanel.ResumeLayout(false);
            this.doneActionsForTablePanel.PerformLayout();
            this.plannedTextPanel.ResumeLayout(false);
            this.plannedTextPanel.PerformLayout();
            this.statePanel.ResumeLayout(false);
            this.statePanel.PerformLayout();
            this.newEventButtonsPanel.ResumeLayout(false);
            this.updateEventPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
        private System.Windows.Forms.Panel newVisitPanel;
        private System.Windows.Forms.Label newVisitLabel;
        private System.Windows.Forms.Panel patientNamePanel;
        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.CheckBox newPatientCheckBox;
        private System.Windows.Forms.Panel newPatientPanel;
        private System.Windows.Forms.TextBox newPatientSurnameTextBox;
        private System.Windows.Forms.Label newPatientSurnameLabel;
        private System.Windows.Forms.TextBox newPatientNameTextBox;
        private System.Windows.Forms.Label newPatientNameLabel;
        private System.Windows.Forms.TextBox newPatientEmailTextBox;
        private System.Windows.Forms.Label newPatientEmailLabel;
        private System.Windows.Forms.TextBox newPatientPhoneTextBox;
        private System.Windows.Forms.Label newPatientPhoneLabel;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Label eventStartLabel;
        private PresentationControls.CheckBoxComboBox doctorsCheckBoxComboBox;
        private System.Windows.Forms.Label doctorsLabel;
        private System.Windows.Forms.TextBox eventStartTextBox;
        private System.Windows.Forms.Label eventDurationLabel;
        private System.Windows.Forms.Label durationInfoLabel;
        private System.Windows.Forms.Label fastDurationLabel;
        private System.Windows.Forms.Label emailsLabel;
        private System.Windows.Forms.Label eventNoteLabel;
        private PresentationControls.CheckBoxComboBox plannedActionsComboBox;
        private System.Windows.Forms.Label planedActionsLabel;
        private System.Windows.Forms.Label doneActionsLabel;
        private System.Windows.Forms.Panel doneActionsForTablePanel;
        private System.Windows.Forms.TableLayoutPanel doneActionsTablePanel;
        private System.Windows.Forms.Label secondColumnLabel;
        private System.Windows.Forms.Label firstColumnLabel;
        private System.Windows.Forms.TextBox planedTextTextBox;
        private System.Windows.Forms.Label planedTextLabel;
        private System.Windows.Forms.TextBox doneTextTextBox;
        private System.Windows.Forms.Label doneTextLabel;
        private FlatControls.FlatRichTextBox emailsRichTextBox;
        private FlatControls.FlatRichTextBox eventNoteRichTextBox;
        private FlatControls.RoundButton newVisitButton;
        private FlatControls.RoundButton duration90Button;
        private FlatControls.RoundButton duration60Button;
        private FlatControls.RoundButton duration30Button;
        private FlatControls.RoundButton duration15Button;
        private FlatControls.RoundButton addDoneActionButton;
        private Other.LabeledNumericUpDown durationNumericUpDown;
        private System.Windows.Forms.Panel doneActionsPanel;
        private System.Windows.Forms.Panel plannedTextPanel;
        private System.Windows.Forms.Panel statePanel;
        private System.Windows.Forms.ComboBox eventStateComboBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Panel newEventButtonsPanel;
        private FlatControls.RoundButton createEventButton;
        private FlatControls.RoundButton resetEventButton;
        private System.Windows.Forms.Panel updateEventPanel;
        private FlatControls.RoundButton reorderButton;
        private FlatControls.RoundButton saveEventButton;
        private FlatControls.RoundButton deleteEventButton;
        private Other.AutoCompleteTextBox doneActionTextBox;
        private System.Windows.Forms.Panel panel1;
        private Other.AutoCompleteTextBox patientNameTextBox;
    }
}
