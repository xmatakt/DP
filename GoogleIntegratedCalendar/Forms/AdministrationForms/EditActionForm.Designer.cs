namespace EZKO.Forms.AdministrationForms
{
    partial class EditActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditActionForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.actionNameLabel = new System.Windows.Forms.Label();
            this.actionNameTextBox = new System.Windows.Forms.TextBox();
            this.actionShortcutLabel = new System.Windows.Forms.Label();
            this.actionShortcutTextBox = new System.Windows.Forms.TextBox();
            this.longNameLabel = new System.Windows.Forms.Label();
            this.longNameTextBox = new System.Windows.Forms.TextBox();
            this.materialLabel = new System.Windows.Forms.Label();
            this.recommendedLengthLabel = new System.Windows.Forms.Label();
            this.costsLabel = new System.Windows.Forms.Label();
            this.costsUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.recommendedLengthUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.materialRichTextBox = new EZKO.UserControls.FlatControls.FlatRichTextBox();
            this.marginUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.marginLabel = new System.Windows.Forms.Label();
            this.companyMarginUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.companyMrginLabel = new System.Windows.Forms.Label();
            this.companyCodeLabel = new System.Windows.Forms.Label();
            this.ezkoFieldLabel = new System.Windows.Forms.Label();
            this.hasSpecificationCheckBox = new System.Windows.Forms.CheckBox();
            this.companyCodeComboBox = new System.Windows.Forms.ComboBox();
            this.ezkoFieldComboBox = new System.Windows.Forms.ComboBox();
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recommendedLengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marginUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyMarginUpDown)).BeginInit();
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
            this.topMenuPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(567, 36);
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
            this.formTitleLabel.Size = new System.Drawing.Size(126, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Editácia výkonov";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(515, 8);
            this.minimizeFormPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.closeFormPictureBox.Location = new System.Drawing.Point(539, 8);
            this.closeFormPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 277);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(567, 40);
            this.bottomFlowPanel.TabIndex = 20;
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
            this.cancelButton.Location = new System.Drawing.Point(493, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Radius = 5;
            this.cancelButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatOrange;
            this.cancelButton.Size = new System.Drawing.Size(66, 27);
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
            this.addButton.Location = new System.Drawing.Point(375, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addButton.Name = "addButton";
            this.addButton.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addButton.Radius = 5;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addButton.Size = new System.Drawing.Size(114, 27);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "+ Vytvoriť výkon";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // actionNameLabel
            // 
            this.actionNameLabel.AutoSize = true;
            this.actionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionNameLabel.Location = new System.Drawing.Point(8, 46);
            this.actionNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.actionNameLabel.Name = "actionNameLabel";
            this.actionNameLabel.Size = new System.Drawing.Size(130, 13);
            this.actionNameLabel.TabIndex = 0;
            this.actionNameLabel.Text = "Názov (1-30 znakov)*";
            // 
            // actionNameTextBox
            // 
            this.actionNameTextBox.Location = new System.Drawing.Point(11, 62);
            this.actionNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.actionNameTextBox.Name = "actionNameTextBox";
            this.actionNameTextBox.Size = new System.Drawing.Size(292, 20);
            this.actionNameTextBox.TabIndex = 1;
            // 
            // actionShortcutLabel
            // 
            this.actionShortcutLabel.AutoSize = true;
            this.actionShortcutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionShortcutLabel.Location = new System.Drawing.Point(8, 84);
            this.actionShortcutLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.actionShortcutLabel.Name = "actionShortcutLabel";
            this.actionShortcutLabel.Size = new System.Drawing.Size(138, 13);
            this.actionShortcutLabel.TabIndex = 0;
            this.actionShortcutLabel.Text = "Skratka (1-12 znakov)*";
            // 
            // actionShortcutTextBox
            // 
            this.actionShortcutTextBox.Location = new System.Drawing.Point(11, 99);
            this.actionShortcutTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.actionShortcutTextBox.Name = "actionShortcutTextBox";
            this.actionShortcutTextBox.Size = new System.Drawing.Size(292, 20);
            this.actionShortcutTextBox.TabIndex = 2;
            // 
            // longNameLabel
            // 
            this.longNameLabel.AutoSize = true;
            this.longNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longNameLabel.Location = new System.Drawing.Point(8, 120);
            this.longNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.longNameLabel.Name = "longNameLabel";
            this.longNameLabel.Size = new System.Drawing.Size(70, 13);
            this.longNameLabel.TabIndex = 2;
            this.longNameLabel.Text = "Dlhý názov";
            // 
            // longNameTextBox
            // 
            this.longNameTextBox.Location = new System.Drawing.Point(11, 135);
            this.longNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.longNameTextBox.Name = "longNameTextBox";
            this.longNameTextBox.Size = new System.Drawing.Size(292, 20);
            this.longNameTextBox.TabIndex = 3;
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel.Location = new System.Drawing.Point(9, 162);
            this.materialLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(105, 13);
            this.materialLabel.TabIndex = 2;
            this.materialLabel.Text = "Potrebný materiál";
            // 
            // recommendedLengthLabel
            // 
            this.recommendedLengthLabel.AutoSize = true;
            this.recommendedLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recommendedLengthLabel.Location = new System.Drawing.Point(9, 246);
            this.recommendedLengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recommendedLengthLabel.Name = "recommendedLengthLabel";
            this.recommendedLengthLabel.Size = new System.Drawing.Size(116, 13);
            this.recommendedLengthLabel.TabIndex = 2;
            this.recommendedLengthLabel.Text = "Odporúčaná dĺžka*";
            // 
            // costsLabel
            // 
            this.costsLabel.AutoSize = true;
            this.costsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costsLabel.Location = new System.Drawing.Point(323, 46);
            this.costsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.costsLabel.Name = "costsLabel";
            this.costsLabel.Size = new System.Drawing.Size(58, 13);
            this.costsLabel.TabIndex = 2;
            this.costsLabel.Text = "Náklady*";
            // 
            // costsUpDown
            // 
            this.costsUpDown.LabelText = "€";
            this.costsUpDown.Location = new System.Drawing.Point(325, 61);
            this.costsUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.costsUpDown.Name = "costsUpDown";
            this.costsUpDown.Size = new System.Drawing.Size(141, 20);
            this.costsUpDown.TabIndex = 6;
            this.costsUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // recommendedLengthUpDown
            // 
            this.recommendedLengthUpDown.LabelText = "minút";
            this.recommendedLengthUpDown.Location = new System.Drawing.Point(130, 244);
            this.recommendedLengthUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.recommendedLengthUpDown.Name = "recommendedLengthUpDown";
            this.recommendedLengthUpDown.Size = new System.Drawing.Size(172, 20);
            this.recommendedLengthUpDown.TabIndex = 5;
            this.recommendedLengthUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // materialRichTextBox
            // 
            this.materialRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialRichTextBox.Location = new System.Drawing.Point(11, 178);
            this.materialRichTextBox.Name = "materialRichTextBox";
            this.materialRichTextBox.Size = new System.Drawing.Size(291, 56);
            this.materialRichTextBox.TabIndex = 4;
            // 
            // marginUpDown
            // 
            this.marginUpDown.LabelText = "€";
            this.marginUpDown.Location = new System.Drawing.Point(325, 99);
            this.marginUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.marginUpDown.Name = "marginUpDown";
            this.marginUpDown.Size = new System.Drawing.Size(141, 20);
            this.marginUpDown.TabIndex = 7;
            this.marginUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marginLabel.Location = new System.Drawing.Point(323, 84);
            this.marginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(46, 13);
            this.marginLabel.TabIndex = 7;
            this.marginLabel.Text = "Marža*";
            // 
            // companyMarginUpDown
            // 
            this.companyMarginUpDown.LabelText = "€";
            this.companyMarginUpDown.Location = new System.Drawing.Point(325, 135);
            this.companyMarginUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.companyMarginUpDown.Name = "companyMarginUpDown";
            this.companyMarginUpDown.Size = new System.Drawing.Size(141, 20);
            this.companyMarginUpDown.TabIndex = 8;
            this.companyMarginUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // companyMrginLabel
            // 
            this.companyMrginLabel.AutoSize = true;
            this.companyMrginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyMrginLabel.Location = new System.Drawing.Point(323, 120);
            this.companyMrginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.companyMrginLabel.Name = "companyMrginLabel";
            this.companyMrginLabel.Size = new System.Drawing.Size(123, 13);
            this.companyMrginLabel.TabIndex = 9;
            this.companyMrginLabel.Text = "Marža pre poisťovňu";
            // 
            // companyCodeLabel
            // 
            this.companyCodeLabel.AutoSize = true;
            this.companyCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyCodeLabel.Location = new System.Drawing.Point(323, 163);
            this.companyCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.companyCodeLabel.Name = "companyCodeLabel";
            this.companyCodeLabel.Size = new System.Drawing.Size(89, 13);
            this.companyCodeLabel.TabIndex = 11;
            this.companyCodeLabel.Text = "Kód poisťovne";
            // 
            // ezkoFieldLabel
            // 
            this.ezkoFieldLabel.AutoSize = true;
            this.ezkoFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ezkoFieldLabel.Location = new System.Drawing.Point(323, 201);
            this.ezkoFieldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ezkoFieldLabel.Name = "ezkoFieldLabel";
            this.ezkoFieldLabel.Size = new System.Drawing.Size(69, 13);
            this.ezkoFieldLabel.TabIndex = 13;
            this.ezkoFieldLabel.Text = "Pole EZKO";
            // 
            // hasSpecificationCheckBox
            // 
            this.hasSpecificationCheckBox.AutoSize = true;
            this.hasSpecificationCheckBox.Location = new System.Drawing.Point(325, 244);
            this.hasSpecificationCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hasSpecificationCheckBox.Name = "hasSpecificationCheckBox";
            this.hasSpecificationCheckBox.Size = new System.Drawing.Size(100, 17);
            this.hasSpecificationCheckBox.TabIndex = 11;
            this.hasSpecificationCheckBox.Text = "Má špecifikáciu";
            this.hasSpecificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // companyCodeComboBox
            // 
            this.companyCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companyCodeComboBox.FormattingEnabled = true;
            this.companyCodeComboBox.Location = new System.Drawing.Point(325, 178);
            this.companyCodeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.companyCodeComboBox.Name = "companyCodeComboBox";
            this.companyCodeComboBox.Size = new System.Drawing.Size(235, 21);
            this.companyCodeComboBox.TabIndex = 9;
            // 
            // ezkoFieldComboBox
            // 
            this.ezkoFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ezkoFieldComboBox.FormattingEnabled = true;
            this.ezkoFieldComboBox.Location = new System.Drawing.Point(325, 215);
            this.ezkoFieldComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ezkoFieldComboBox.Name = "ezkoFieldComboBox";
            this.ezkoFieldComboBox.Size = new System.Drawing.Size(235, 21);
            this.ezkoFieldComboBox.TabIndex = 10;
            // 
            // EditActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 317);
            this.ControlBox = false;
            this.Controls.Add(this.ezkoFieldComboBox);
            this.Controls.Add(this.companyCodeComboBox);
            this.Controls.Add(this.hasSpecificationCheckBox);
            this.Controls.Add(this.ezkoFieldLabel);
            this.Controls.Add(this.companyCodeLabel);
            this.Controls.Add(this.companyMarginUpDown);
            this.Controls.Add(this.companyMrginLabel);
            this.Controls.Add(this.marginUpDown);
            this.Controls.Add(this.marginLabel);
            this.Controls.Add(this.costsUpDown);
            this.Controls.Add(this.recommendedLengthUpDown);
            this.Controls.Add(this.materialRichTextBox);
            this.Controls.Add(this.longNameTextBox);
            this.Controls.Add(this.costsLabel);
            this.Controls.Add(this.recommendedLengthLabel);
            this.Controls.Add(this.materialLabel);
            this.Controls.Add(this.longNameLabel);
            this.Controls.Add(this.actionShortcutTextBox);
            this.Controls.Add(this.actionShortcutLabel);
            this.Controls.Add(this.actionNameTextBox);
            this.Controls.Add(this.actionNameLabel);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditActionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EditActionForm_Load);
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recommendedLengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marginUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyMarginUpDown)).EndInit();
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
        private System.Windows.Forms.Label actionNameLabel;
        private System.Windows.Forms.TextBox actionNameTextBox;
        private System.Windows.Forms.Label actionShortcutLabel;
        private System.Windows.Forms.TextBox actionShortcutTextBox;
        private System.Windows.Forms.Label longNameLabel;
        private System.Windows.Forms.TextBox longNameTextBox;
        private System.Windows.Forms.Label materialLabel;
        private UserControls.FlatControls.FlatRichTextBox materialRichTextBox;
        private System.Windows.Forms.Label recommendedLengthLabel;
        private UserControls.Other.LabeledNumericUpDown recommendedLengthUpDown;
        private System.Windows.Forms.Label costsLabel;
        private UserControls.Other.LabeledNumericUpDown costsUpDown;
        private UserControls.Other.LabeledNumericUpDown marginUpDown;
        private System.Windows.Forms.Label marginLabel;
        private UserControls.Other.LabeledNumericUpDown companyMarginUpDown;
        private System.Windows.Forms.Label companyMrginLabel;
        private System.Windows.Forms.Label companyCodeLabel;
        private System.Windows.Forms.Label ezkoFieldLabel;
        private System.Windows.Forms.CheckBox hasSpecificationCheckBox;
        private System.Windows.Forms.ComboBox companyCodeComboBox;
        private System.Windows.Forms.ComboBox ezkoFieldComboBox;
    }
}