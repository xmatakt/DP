﻿namespace EZKO.Forms.PatientForms
{
    partial class NewPatientForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPatientForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.personalInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.insuranceCompanyComboBox = new System.Windows.Forms.ComboBox();
            this.womanRadioButton = new System.Windows.Forms.RadioButton();
            this.manRadioButton = new System.Windows.Forms.RadioButton();
            this.sexLabel = new System.Windows.Forms.Label();
            this.insuranceCompanyLabel = new System.Windows.Forms.Label();
            this.birthNumberTextBox = new System.Windows.Forms.TextBox();
            this.birthNumberLabel = new System.Windows.Forms.Label();
            this.secondTitleTextBox = new System.Windows.Forms.TextBox();
            this.secondTitleLabel = new System.Windows.Forms.Label();
            this.firstTitleTextBox = new System.Windows.Forms.TextBox();
            this.firstTitleLabel = new System.Windows.Forms.Label();
            this.representativeTextBox = new System.Windows.Forms.TextBox();
            this.representativeLabel = new System.Windows.Forms.Label();
            this.bifoTextBox = new System.Windows.Forms.TextBox();
            this.bifoLabel = new System.Windows.Forms.Label();
            this.dateOfBirthLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addressGroupBox = new System.Windows.Forms.GroupBox();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.zipLabel = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.streetNumberTextBox = new System.Windows.Forms.TextBox();
            this.streetNumberLabel = new System.Windows.Forms.Label();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.streetLabel = new System.Windows.Forms.Label();
            this.contactGroupBox = new System.Windows.Forms.GroupBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            this.personalInfoGroupBox.SuspendLayout();
            this.addressGroupBox.SuspendLayout();
            this.contactGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuPanel
            // 
            this.topMenuPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topMenuPanel.Controls.Add(this.formTitleLabel);
            this.topMenuPanel.Controls.Add(this.minimizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.closeFormPictureBox);
            this.topMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.topMenuPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(593, 36);
            this.topMenuPanel.TabIndex = 0;
            this.topMenuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topMenuPanel_MouseDown);
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.formTitleLabel.Location = new System.Drawing.Point(8, 8);
            this.formTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(99, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Nový pacient";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(541, 8);
            this.minimizeFormPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.minimizeFormPictureBox.Name = "minimizeFormPictureBox";
            this.minimizeFormPictureBox.Size = new System.Drawing.Size(20, 19);
            this.minimizeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimizeFormPictureBox.TabIndex = 1;
            this.minimizeFormPictureBox.TabStop = false;
            this.minimizeFormPictureBox.Click += new System.EventHandler(this.minimizeFormPictureBox_Click);
            this.minimizeFormPictureBox.MouseEnter += new System.EventHandler(this.minimizeFormPictureBox_MouseEnter);
            this.minimizeFormPictureBox.MouseLeave += new System.EventHandler(this.minimizeFormPictureBox_MouseLeave);
            // 
            // closeFormPictureBox
            // 
            this.closeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeFormPictureBox.Image = global::EZKO.Properties.Resources.closeForm_32;
            this.closeFormPictureBox.Location = new System.Drawing.Point(565, 8);
            this.closeFormPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.closeFormPictureBox.Name = "closeFormPictureBox";
            this.closeFormPictureBox.Size = new System.Drawing.Size(20, 19);
            this.closeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeFormPictureBox.TabIndex = 3;
            this.closeFormPictureBox.TabStop = false;
            this.closeFormPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.closeFormPictureBox.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.closeFormPictureBox.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // bottomFlowPanel
            // 
            this.bottomFlowPanel.AutoSize = true;
            this.bottomFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bottomFlowPanel.Controls.Add(this.cancelButton);
            this.bottomFlowPanel.Controls.Add(this.addButton);
            this.bottomFlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 364);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(593, 36);
            this.bottomFlowPanel.TabIndex = 1;
            // 
            // personalInfoGroupBox
            // 
            this.personalInfoGroupBox.Controls.Add(this.birthDatePicker);
            this.personalInfoGroupBox.Controls.Add(this.insuranceCompanyComboBox);
            this.personalInfoGroupBox.Controls.Add(this.womanRadioButton);
            this.personalInfoGroupBox.Controls.Add(this.manRadioButton);
            this.personalInfoGroupBox.Controls.Add(this.sexLabel);
            this.personalInfoGroupBox.Controls.Add(this.insuranceCompanyLabel);
            this.personalInfoGroupBox.Controls.Add(this.birthNumberTextBox);
            this.personalInfoGroupBox.Controls.Add(this.birthNumberLabel);
            this.personalInfoGroupBox.Controls.Add(this.secondTitleTextBox);
            this.personalInfoGroupBox.Controls.Add(this.secondTitleLabel);
            this.personalInfoGroupBox.Controls.Add(this.firstTitleTextBox);
            this.personalInfoGroupBox.Controls.Add(this.firstTitleLabel);
            this.personalInfoGroupBox.Controls.Add(this.representativeTextBox);
            this.personalInfoGroupBox.Controls.Add(this.representativeLabel);
            this.personalInfoGroupBox.Controls.Add(this.bifoTextBox);
            this.personalInfoGroupBox.Controls.Add(this.bifoLabel);
            this.personalInfoGroupBox.Controls.Add(this.dateOfBirthLabel);
            this.personalInfoGroupBox.Controls.Add(this.surnameTextBox);
            this.personalInfoGroupBox.Controls.Add(this.surnameLabel);
            this.personalInfoGroupBox.Controls.Add(this.nameTextBox);
            this.personalInfoGroupBox.Controls.Add(this.nameLabel);
            this.personalInfoGroupBox.Location = new System.Drawing.Point(12, 41);
            this.personalInfoGroupBox.Name = "personalInfoGroupBox";
            this.personalInfoGroupBox.Size = new System.Drawing.Size(283, 309);
            this.personalInfoGroupBox.TabIndex = 2;
            this.personalInfoGroupBox.TabStop = false;
            this.personalInfoGroupBox.Text = "Osobné informácie";
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.Location = new System.Drawing.Point(123, 72);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(148, 20);
            this.birthDatePicker.TabIndex = 2;
            this.birthDatePicker.ValueChanged += new System.EventHandler(this.birthDatePicker_ValueChanged);
            // 
            // insuranceCompanyComboBox
            // 
            this.insuranceCompanyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.insuranceCompanyComboBox.FormattingEnabled = true;
            this.insuranceCompanyComboBox.Location = new System.Drawing.Point(123, 228);
            this.insuranceCompanyComboBox.Name = "insuranceCompanyComboBox";
            this.insuranceCompanyComboBox.Size = new System.Drawing.Size(148, 21);
            this.insuranceCompanyComboBox.TabIndex = 8;
            // 
            // womanRadioButton
            // 
            this.womanRadioButton.AutoSize = true;
            this.womanRadioButton.Location = new System.Drawing.Point(174, 257);
            this.womanRadioButton.Name = "womanRadioButton";
            this.womanRadioButton.Size = new System.Drawing.Size(50, 17);
            this.womanRadioButton.TabIndex = 10;
            this.womanRadioButton.TabStop = true;
            this.womanRadioButton.Text = "Žena";
            this.womanRadioButton.UseVisualStyleBackColor = true;
            // 
            // manRadioButton
            // 
            this.manRadioButton.AutoSize = true;
            this.manRadioButton.Location = new System.Drawing.Point(123, 257);
            this.manRadioButton.Name = "manRadioButton";
            this.manRadioButton.Size = new System.Drawing.Size(45, 17);
            this.manRadioButton.TabIndex = 9;
            this.manRadioButton.TabStop = true;
            this.manRadioButton.Text = "Muž";
            this.manRadioButton.UseVisualStyleBackColor = true;
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexLabel.Location = new System.Drawing.Point(8, 257);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(60, 13);
            this.sexLabel.TabIndex = 0;
            this.sexLabel.Text = "Pohlavie:";
            // 
            // insuranceCompanyLabel
            // 
            this.insuranceCompanyLabel.AutoSize = true;
            this.insuranceCompanyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insuranceCompanyLabel.Location = new System.Drawing.Point(8, 231);
            this.insuranceCompanyLabel.Name = "insuranceCompanyLabel";
            this.insuranceCompanyLabel.Size = new System.Drawing.Size(68, 13);
            this.insuranceCompanyLabel.TabIndex = 0;
            this.insuranceCompanyLabel.Text = "Poisťovňa:";
            // 
            // birthNumberTextBox
            // 
            this.birthNumberTextBox.Location = new System.Drawing.Point(123, 202);
            this.birthNumberTextBox.Name = "birthNumberTextBox";
            this.birthNumberTextBox.Size = new System.Drawing.Size(148, 20);
            this.birthNumberTextBox.TabIndex = 7;
            // 
            // birthNumberLabel
            // 
            this.birthNumberLabel.AutoSize = true;
            this.birthNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthNumberLabel.Location = new System.Drawing.Point(8, 205);
            this.birthNumberLabel.Name = "birthNumberLabel";
            this.birthNumberLabel.Size = new System.Drawing.Size(80, 13);
            this.birthNumberLabel.TabIndex = 0;
            this.birthNumberLabel.Text = "Rodné číslo:";
            // 
            // secondTitleTextBox
            // 
            this.secondTitleTextBox.Location = new System.Drawing.Point(123, 176);
            this.secondTitleTextBox.Name = "secondTitleTextBox";
            this.secondTitleTextBox.Size = new System.Drawing.Size(65, 20);
            this.secondTitleTextBox.TabIndex = 6;
            // 
            // secondTitleLabel
            // 
            this.secondTitleLabel.AutoSize = true;
            this.secondTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondTitleLabel.Location = new System.Drawing.Point(8, 179);
            this.secondTitleLabel.Name = "secondTitleLabel";
            this.secondTitleLabel.Size = new System.Drawing.Size(87, 13);
            this.secondTitleLabel.TabIndex = 0;
            this.secondTitleLabel.Text = "Titul za meno:";
            // 
            // firstTitleTextBox
            // 
            this.firstTitleTextBox.Location = new System.Drawing.Point(123, 150);
            this.firstTitleTextBox.Name = "firstTitleTextBox";
            this.firstTitleTextBox.Size = new System.Drawing.Size(65, 20);
            this.firstTitleTextBox.TabIndex = 5;
            // 
            // firstTitleLabel
            // 
            this.firstTitleLabel.AutoSize = true;
            this.firstTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstTitleLabel.Location = new System.Drawing.Point(8, 153);
            this.firstTitleLabel.Name = "firstTitleLabel";
            this.firstTitleLabel.Size = new System.Drawing.Size(108, 13);
            this.firstTitleLabel.TabIndex = 0;
            this.firstTitleLabel.Text = "Titul pred menom:";
            // 
            // representativeTextBox
            // 
            this.representativeTextBox.Location = new System.Drawing.Point(123, 124);
            this.representativeTextBox.Name = "representativeTextBox";
            this.representativeTextBox.Size = new System.Drawing.Size(148, 20);
            this.representativeTextBox.TabIndex = 4;
            // 
            // representativeLabel
            // 
            this.representativeLabel.AutoSize = true;
            this.representativeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.representativeLabel.Location = new System.Drawing.Point(8, 127);
            this.representativeLabel.Name = "representativeLabel";
            this.representativeLabel.Size = new System.Drawing.Size(115, 13);
            this.representativeLabel.TabIndex = 0;
            this.representativeLabel.Text = "Zákonný zástupca:";
            // 
            // bifoTextBox
            // 
            this.bifoTextBox.Location = new System.Drawing.Point(123, 98);
            this.bifoTextBox.Name = "bifoTextBox";
            this.bifoTextBox.Size = new System.Drawing.Size(148, 20);
            this.bifoTextBox.TabIndex = 3;
            // 
            // bifoLabel
            // 
            this.bifoLabel.AutoSize = true;
            this.bifoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bifoLabel.Location = new System.Drawing.Point(8, 101);
            this.bifoLabel.Name = "bifoLabel";
            this.bifoLabel.Size = new System.Drawing.Size(39, 13);
            this.bifoLabel.TabIndex = 0;
            this.bifoLabel.Text = "BIFO:";
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfBirthLabel.Location = new System.Drawing.Point(8, 75);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(107, 13);
            this.dateOfBirthLabel.TabIndex = 0;
            this.dateOfBirthLabel.Text = "Dátum narodenia:";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(123, 46);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(148, 20);
            this.surnameTextBox.TabIndex = 1;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameLabel.Location = new System.Drawing.Point(8, 49);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(74, 13);
            this.surnameLabel.TabIndex = 0;
            this.surnameLabel.Text = "Priezvisko*:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(123, 20);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(148, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(8, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(47, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Meno*:";
            // 
            // addressGroupBox
            // 
            this.addressGroupBox.Controls.Add(this.countryTextBox);
            this.addressGroupBox.Controls.Add(this.countryLabel);
            this.addressGroupBox.Controls.Add(this.zipTextBox);
            this.addressGroupBox.Controls.Add(this.zipLabel);
            this.addressGroupBox.Controls.Add(this.cityTextBox);
            this.addressGroupBox.Controls.Add(this.cityLabel);
            this.addressGroupBox.Controls.Add(this.streetNumberTextBox);
            this.addressGroupBox.Controls.Add(this.streetNumberLabel);
            this.addressGroupBox.Controls.Add(this.streetTextBox);
            this.addressGroupBox.Controls.Add(this.streetLabel);
            this.addressGroupBox.Location = new System.Drawing.Point(301, 41);
            this.addressGroupBox.Name = "addressGroupBox";
            this.addressGroupBox.Size = new System.Drawing.Size(280, 196);
            this.addressGroupBox.TabIndex = 3;
            this.addressGroupBox.TabStop = false;
            this.addressGroupBox.Text = "Adresa";
            // 
            // countryTextBox
            // 
            this.countryTextBox.Location = new System.Drawing.Point(121, 124);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(148, 20);
            this.countryTextBox.TabIndex = 4;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(6, 127);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(50, 13);
            this.countryLabel.TabIndex = 0;
            this.countryLabel.Text = "Krajina:";
            // 
            // zipTextBox
            // 
            this.zipTextBox.Location = new System.Drawing.Point(121, 98);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(148, 20);
            this.zipTextBox.TabIndex = 3;
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipLabel.Location = new System.Drawing.Point(6, 101);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(35, 13);
            this.zipLabel.TabIndex = 0;
            this.zipLabel.Text = "PSČ:";
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(121, 72);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(148, 20);
            this.cityTextBox.TabIndex = 2;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(6, 75);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(45, 13);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "Mesto:";
            // 
            // streetNumberTextBox
            // 
            this.streetNumberTextBox.Location = new System.Drawing.Point(121, 46);
            this.streetNumberTextBox.Name = "streetNumberTextBox";
            this.streetNumberTextBox.Size = new System.Drawing.Size(148, 20);
            this.streetNumberTextBox.TabIndex = 1;
            // 
            // streetNumberLabel
            // 
            this.streetNumberLabel.AutoSize = true;
            this.streetNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streetNumberLabel.Location = new System.Drawing.Point(6, 49);
            this.streetNumberLabel.Name = "streetNumberLabel";
            this.streetNumberLabel.Size = new System.Drawing.Size(40, 13);
            this.streetNumberLabel.TabIndex = 0;
            this.streetNumberLabel.Text = "Číslo:";
            // 
            // streetTextBox
            // 
            this.streetTextBox.Location = new System.Drawing.Point(121, 20);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(148, 20);
            this.streetTextBox.TabIndex = 0;
            // 
            // streetLabel
            // 
            this.streetLabel.AutoSize = true;
            this.streetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streetLabel.Location = new System.Drawing.Point(6, 23);
            this.streetLabel.Name = "streetLabel";
            this.streetLabel.Size = new System.Drawing.Size(36, 13);
            this.streetLabel.TabIndex = 0;
            this.streetLabel.Text = "Ulica";
            // 
            // contactGroupBox
            // 
            this.contactGroupBox.Controls.Add(this.phoneTextBox);
            this.contactGroupBox.Controls.Add(this.phoneLabel);
            this.contactGroupBox.Controls.Add(this.emailTextBox);
            this.contactGroupBox.Controls.Add(this.emailLabel);
            this.contactGroupBox.Location = new System.Drawing.Point(301, 243);
            this.contactGroupBox.Name = "contactGroupBox";
            this.contactGroupBox.Size = new System.Drawing.Size(280, 107);
            this.contactGroupBox.TabIndex = 4;
            this.contactGroupBox.TabStop = false;
            this.contactGroupBox.Text = "Kontakt";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(121, 52);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(148, 20);
            this.phoneTextBox.TabIndex = 1;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.Location = new System.Drawing.Point(6, 55);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(54, 13);
            this.phoneLabel.TabIndex = 0;
            this.phoneLabel.Text = "Telefón:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(121, 26);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(148, 20);
            this.emailTextBox.TabIndex = 0;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(6, 29);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(41, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Email:";
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(31)))));
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(151)))), ((int)(((byte)(31)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(523, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Radius = 5;
            this.cancelButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatOrange;
            this.cancelButton.Size = new System.Drawing.Size(62, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Zatvoriť";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(458, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Radius = 5;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addButton.Size = new System.Drawing.Size(61, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Vytvoriť";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // NewPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 400);
            this.ControlBox = false;
            this.Controls.Add(this.contactGroupBox);
            this.Controls.Add(this.addressGroupBox);
            this.Controls.Add(this.personalInfoGroupBox);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.NewPatientForm_Load);
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            this.personalInfoGroupBox.ResumeLayout(false);
            this.personalInfoGroupBox.PerformLayout();
            this.addressGroupBox.ResumeLayout(false);
            this.addressGroupBox.PerformLayout();
            this.contactGroupBox.ResumeLayout(false);
            this.contactGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topMenuPanel;
        private System.Windows.Forms.PictureBox minimizeFormPictureBox;
        private System.Windows.Forms.PictureBox closeFormPictureBox;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.FlowLayoutPanel bottomFlowPanel;
        private UserControls.FlatControls.RoundButton addButton;
        private UserControls.FlatControls.RoundButton cancelButton;
        private System.Windows.Forms.GroupBox personalInfoGroupBox;
        private System.Windows.Forms.RadioButton womanRadioButton;
        private System.Windows.Forms.RadioButton manRadioButton;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label insuranceCompanyLabel;
        private System.Windows.Forms.TextBox birthNumberTextBox;
        private System.Windows.Forms.Label birthNumberLabel;
        private System.Windows.Forms.TextBox secondTitleTextBox;
        private System.Windows.Forms.Label secondTitleLabel;
        private System.Windows.Forms.TextBox firstTitleTextBox;
        private System.Windows.Forms.Label firstTitleLabel;
        private System.Windows.Forms.TextBox representativeTextBox;
        private System.Windows.Forms.Label representativeLabel;
        private System.Windows.Forms.TextBox bifoTextBox;
        private System.Windows.Forms.Label bifoLabel;
        private System.Windows.Forms.Label dateOfBirthLabel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.DateTimePicker birthDatePicker;
        private System.Windows.Forms.ComboBox insuranceCompanyComboBox;
        private System.Windows.Forms.GroupBox addressGroupBox;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox streetNumberTextBox;
        private System.Windows.Forms.Label streetNumberLabel;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.Label streetLabel;
        private System.Windows.Forms.GroupBox contactGroupBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
    }
}