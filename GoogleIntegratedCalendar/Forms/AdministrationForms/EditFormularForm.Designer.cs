﻿namespace EZKO.Forms.AdministrationForms
{
    partial class EditFormularForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFormularForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.maximizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fieldsLabel = new System.Windows.Forms.Label();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.sectionsDataGridView = new System.Windows.Forms.DataGridView();
            this.formCardFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.fieldsDataGridView = new System.Windows.Forms.DataGridView();
            this.sectionsTextBox = new EZKO.UserControls.Other.AutoCompleteTextBox();
            this.backToLastSectionButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.formularSectionsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.formularFieldsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.allSectionsButton2 = new EZKO.UserControls.FlatControls.RoundButton();
            this.allSectionsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addFiledButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addSectionButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.editSectionButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.previewLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.formEditor = new EZKO.UserControls.Formulars.FormEditorControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsDataGridView)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuPanel
            // 
            this.topMenuPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topMenuPanel.Controls.Add(this.maximizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.formTitleLabel);
            this.topMenuPanel.Controls.Add(this.minimizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.closeFormPictureBox);
            this.topMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.topMenuPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(1060, 36);
            this.topMenuPanel.TabIndex = 1;
            this.topMenuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topMenuPanel_MouseDown);
            // 
            // maximizeFormPictureBox
            // 
            this.maximizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeFormPictureBox.Image = global::EZKO.Properties.Resources.minimizeForm_32;
            this.maximizeFormPictureBox.Location = new System.Drawing.Point(1007, 8);
            this.maximizeFormPictureBox.Name = "maximizeFormPictureBox";
            this.maximizeFormPictureBox.Size = new System.Drawing.Size(20, 20);
            this.maximizeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maximizeFormPictureBox.TabIndex = 6;
            this.maximizeFormPictureBox.TabStop = false;
            this.maximizeFormPictureBox.Click += new System.EventHandler(this.maximizeFormPictureBox_Click);
            this.maximizeFormPictureBox.MouseEnter += new System.EventHandler(this.maximizeFormPictureBox_MouseEnter);
            this.maximizeFormPictureBox.MouseLeave += new System.EventHandler(this.maximizeFormPictureBox_MouseLeave);
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.AutoSize = true;
            this.formTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.formTitleLabel.Location = new System.Drawing.Point(8, 8);
            this.formTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(144, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Editácia formulárov";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(982, 9);
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
            this.closeFormPictureBox.Location = new System.Drawing.Point(1032, 8);
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
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 738);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(1060, 36);
            this.bottomFlowPanel.TabIndex = 1;
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
            this.cancelButton.Location = new System.Drawing.Point(990, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Radius = 5;
            this.cancelButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatOrange;
            this.cancelButton.Size = new System.Drawing.Size(62, 23);
            this.cancelButton.TabIndex = 7;
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
            this.addButton.Location = new System.Drawing.Point(865, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Radius = 5;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addButton.Size = new System.Drawing.Size(121, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "+ Vytvoriť formulár";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 29);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(412, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // fieldsLabel
            // 
            this.fieldsLabel.AutoSize = true;
            this.fieldsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldsLabel.Location = new System.Drawing.Point(9, 220);
            this.fieldsLabel.Name = "fieldsLabel";
            this.fieldsLabel.Size = new System.Drawing.Size(141, 13);
            this.fieldsLabel.TabIndex = 8;
            this.fieldsLabel.Text = "Polia zo sekcie SEKCIA";
            // 
            // sectionLabel
            // 
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionLabel.Location = new System.Drawing.Point(9, 52);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.Size = new System.Drawing.Size(46, 13);
            this.sectionLabel.TabIndex = 9;
            this.sectionLabel.Text = "Sekcia";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(9, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(48, 13);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Názov*";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.sectionsDataGridView);
            this.leftPanel.Controls.Add(this.formCardFlowPanel);
            this.leftPanel.Controls.Add(this.fieldsDataGridView);
            this.leftPanel.Controls.Add(this.sectionsTextBox);
            this.leftPanel.Controls.Add(this.backToLastSectionButton);
            this.leftPanel.Controls.Add(this.formularSectionsButton);
            this.leftPanel.Controls.Add(this.formularFieldsButton);
            this.leftPanel.Controls.Add(this.allSectionsButton2);
            this.leftPanel.Controls.Add(this.allSectionsButton);
            this.leftPanel.Controls.Add(this.addFiledButton);
            this.leftPanel.Controls.Add(this.addSectionButton);
            this.leftPanel.Controls.Add(this.nameLabel);
            this.leftPanel.Controls.Add(this.editSectionButton);
            this.leftPanel.Controls.Add(this.sectionLabel);
            this.leftPanel.Controls.Add(this.previewLabel);
            this.leftPanel.Controls.Add(this.fieldsLabel);
            this.leftPanel.Controls.Add(this.nameTextBox);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 36);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(440, 702);
            this.leftPanel.TabIndex = 0;
            // 
            // sectionsDataGridView
            // 
            this.sectionsDataGridView.AllowUserToAddRows = false;
            this.sectionsDataGridView.AllowUserToDeleteRows = false;
            this.sectionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sectionsDataGridView.Location = new System.Drawing.Point(12, 95);
            this.sectionsDataGridView.Name = "sectionsDataGridView";
            this.sectionsDataGridView.ReadOnly = true;
            this.sectionsDataGridView.Size = new System.Drawing.Size(412, 111);
            this.sectionsDataGridView.TabIndex = 6;
            this.sectionsDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sectionsDataGridView_CellMouseDoubleClick);
            // 
            // formCardFlowPanel
            // 
            this.formCardFlowPanel.AutoScroll = true;
            this.formCardFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.formCardFlowPanel.Location = new System.Drawing.Point(12, 452);
            this.formCardFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.formCardFlowPanel.Name = "formCardFlowPanel";
            this.formCardFlowPanel.Size = new System.Drawing.Size(418, 238);
            this.formCardFlowPanel.TabIndex = 16;
            // 
            // fieldsDataGridView
            // 
            this.fieldsDataGridView.AllowUserToAddRows = false;
            this.fieldsDataGridView.AllowUserToDeleteRows = false;
            this.fieldsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.fieldsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldsDataGridView.Location = new System.Drawing.Point(12, 236);
            this.fieldsDataGridView.Name = "fieldsDataGridView";
            this.fieldsDataGridView.ReadOnly = true;
            this.fieldsDataGridView.Size = new System.Drawing.Size(412, 173);
            this.fieldsDataGridView.TabIndex = 15;
            this.fieldsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.fieldsDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            this.fieldsDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowEnter);
            // 
            // sectionsTextBox
            // 
            this.sectionsTextBox.Location = new System.Drawing.Point(12, 68);
            this.sectionsTextBox.Name = "sectionsTextBox";
            this.sectionsTextBox.Size = new System.Drawing.Size(276, 20);
            this.sectionsTextBox.TabIndex = 1;
            this.sectionsTextBox.Values = null;
            this.sectionsTextBox.TextChanged += new System.EventHandler(this.sectionsTextBox_TextChanged);
            this.sectionsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sectionsTextBox_KeyDown);
            // 
            // backToLastSectionButton
            // 
            this.backToLastSectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.backToLastSectionButton.BackgroundImage = global::EZKO.Properties.Resources.back_arrow_black_16;
            this.backToLastSectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backToLastSectionButton.FlatAppearance.BorderSize = 0;
            this.backToLastSectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.backToLastSectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.backToLastSectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToLastSectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.backToLastSectionButton.ForeColor = System.Drawing.Color.White;
            this.backToLastSectionButton.Location = new System.Drawing.Point(328, 213);
            this.backToLastSectionButton.Name = "backToLastSectionButton";
            this.backToLastSectionButton.Radius = 5;
            this.backToLastSectionButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.backToLastSectionButton.Size = new System.Drawing.Size(28, 20);
            this.backToLastSectionButton.TabIndex = 7;
            this.backToLastSectionButton.UseVisualStyleBackColor = false;
            this.backToLastSectionButton.Click += new System.EventHandler(this.backToLastSectionButton_Click);
            this.backToLastSectionButton.MouseHover += new System.EventHandler(this.backToLastSectionButton_MouseHover);
            // 
            // formularSectionsButton
            // 
            this.formularSectionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.formularSectionsButton.BackgroundImage = global::EZKO.Properties.Resources.formular_black_24;
            this.formularSectionsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.formularSectionsButton.FlatAppearance.BorderSize = 0;
            this.formularSectionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.formularSectionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.formularSectionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formularSectionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.formularSectionsButton.ForeColor = System.Drawing.Color.White;
            this.formularSectionsButton.Location = new System.Drawing.Point(362, 69);
            this.formularSectionsButton.Name = "formularSectionsButton";
            this.formularSectionsButton.Radius = 5;
            this.formularSectionsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.formularSectionsButton.Size = new System.Drawing.Size(28, 20);
            this.formularSectionsButton.TabIndex = 4;
            this.formularSectionsButton.UseVisualStyleBackColor = false;
            this.formularSectionsButton.Click += new System.EventHandler(this.formularSectionsButton_Click);
            this.formularSectionsButton.MouseHover += new System.EventHandler(this.formularSectionsButton_MouseHover);
            // 
            // formularFieldsButton
            // 
            this.formularFieldsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.formularFieldsButton.BackgroundImage = global::EZKO.Properties.Resources.formular_black_24;
            this.formularFieldsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.formularFieldsButton.FlatAppearance.BorderSize = 0;
            this.formularFieldsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.formularFieldsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.formularFieldsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formularFieldsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.formularFieldsButton.ForeColor = System.Drawing.Color.White;
            this.formularFieldsButton.Location = new System.Drawing.Point(362, 213);
            this.formularFieldsButton.Name = "formularFieldsButton";
            this.formularFieldsButton.Radius = 5;
            this.formularFieldsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.formularFieldsButton.Size = new System.Drawing.Size(28, 20);
            this.formularFieldsButton.TabIndex = 8;
            this.formularFieldsButton.UseVisualStyleBackColor = false;
            this.formularFieldsButton.Click += new System.EventHandler(this.formularFieldsButton_Click);
            this.formularFieldsButton.MouseHover += new System.EventHandler(this.formularFieldsButton_MouseHover);
            // 
            // allSectionsButton2
            // 
            this.allSectionsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.allSectionsButton2.BackgroundImage = global::EZKO.Properties.Resources.list_black_16;
            this.allSectionsButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.allSectionsButton2.FlatAppearance.BorderSize = 0;
            this.allSectionsButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.allSectionsButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.allSectionsButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allSectionsButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.allSectionsButton2.ForeColor = System.Drawing.Color.White;
            this.allSectionsButton2.Location = new System.Drawing.Point(396, 69);
            this.allSectionsButton2.Name = "allSectionsButton2";
            this.allSectionsButton2.Radius = 5;
            this.allSectionsButton2.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.allSectionsButton2.Size = new System.Drawing.Size(28, 20);
            this.allSectionsButton2.TabIndex = 5;
            this.allSectionsButton2.UseVisualStyleBackColor = false;
            this.allSectionsButton2.Click += new System.EventHandler(this.allSectionsButton2_Click);
            this.allSectionsButton2.MouseHover += new System.EventHandler(this.allSectionsButton2_MouseHover);
            // 
            // allSectionsButton
            // 
            this.allSectionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.allSectionsButton.BackgroundImage = global::EZKO.Properties.Resources.list_black_16;
            this.allSectionsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.allSectionsButton.FlatAppearance.BorderSize = 0;
            this.allSectionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.allSectionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.allSectionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allSectionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.allSectionsButton.ForeColor = System.Drawing.Color.White;
            this.allSectionsButton.Location = new System.Drawing.Point(396, 213);
            this.allSectionsButton.Name = "allSectionsButton";
            this.allSectionsButton.Radius = 5;
            this.allSectionsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.allSectionsButton.Size = new System.Drawing.Size(28, 20);
            this.allSectionsButton.TabIndex = 9;
            this.allSectionsButton.UseVisualStyleBackColor = false;
            this.allSectionsButton.Click += new System.EventHandler(this.allSectionsButton_Click);
            this.allSectionsButton.MouseHover += new System.EventHandler(this.allSectionsButton_MouseHover);
            // 
            // addFiledButton
            // 
            this.addFiledButton.AutoSize = true;
            this.addFiledButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.addFiledButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addFiledButton.FlatAppearance.BorderSize = 0;
            this.addFiledButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addFiledButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addFiledButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFiledButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.addFiledButton.ForeColor = System.Drawing.Color.White;
            this.addFiledButton.Location = new System.Drawing.Point(262, 415);
            this.addFiledButton.Name = "addFiledButton";
            this.addFiledButton.Radius = 5;
            this.addFiledButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.addFiledButton.Size = new System.Drawing.Size(162, 23);
            this.addFiledButton.TabIndex = 10;
            this.addFiledButton.Text = "Vytvoriť nové pole EZKO";
            this.addFiledButton.UseVisualStyleBackColor = false;
            this.addFiledButton.Click += new System.EventHandler(this.addFiledButton_Click);
            // 
            // addSectionButton
            // 
            this.addSectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.addSectionButton.BackgroundImage = global::EZKO.Properties.Resources.add_black_16;
            this.addSectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addSectionButton.FlatAppearance.BorderSize = 0;
            this.addSectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addSectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addSectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.addSectionButton.ForeColor = System.Drawing.Color.White;
            this.addSectionButton.Location = new System.Drawing.Point(328, 68);
            this.addSectionButton.Name = "addSectionButton";
            this.addSectionButton.Radius = 5;
            this.addSectionButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.addSectionButton.Size = new System.Drawing.Size(28, 20);
            this.addSectionButton.TabIndex = 3;
            this.addSectionButton.UseVisualStyleBackColor = false;
            this.addSectionButton.Click += new System.EventHandler(this.addSectionButton_Click);
            this.addSectionButton.MouseHover += new System.EventHandler(this.addSectionButton_MouseHover);
            // 
            // editSectionButton
            // 
            this.editSectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.editSectionButton.BackgroundImage = global::EZKO.Properties.Resources.edit_black_16;
            this.editSectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editSectionButton.FlatAppearance.BorderSize = 0;
            this.editSectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.editSectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.editSectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editSectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.editSectionButton.ForeColor = System.Drawing.Color.White;
            this.editSectionButton.Location = new System.Drawing.Point(294, 68);
            this.editSectionButton.Name = "editSectionButton";
            this.editSectionButton.Radius = 5;
            this.editSectionButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatRed;
            this.editSectionButton.Size = new System.Drawing.Size(28, 20);
            this.editSectionButton.TabIndex = 2;
            this.editSectionButton.UseVisualStyleBackColor = false;
            this.editSectionButton.Click += new System.EventHandler(this.editSectionButton_Click);
            this.editSectionButton.MouseHover += new System.EventHandler(this.editSectionButton_MouseHover);
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewLabel.Location = new System.Drawing.Point(12, 439);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(49, 13);
            this.previewLabel.TabIndex = 8;
            this.previewLabel.Text = "Náhľad";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.formEditor);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(440, 36);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(620, 702);
            this.mainPanel.TabIndex = 16;
            // 
            // formEditor
            // 
            this.formEditor.Commands = null;
            this.formEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formEditor.Location = new System.Drawing.Point(0, 0);
            this.formEditor.Name = "formEditor";
            this.formEditor.Size = new System.Drawing.Size(620, 702);
            this.formEditor.TabIndex = 0;
            // 
            // EditFormularForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 774);
            this.ControlBox = false;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditFormularForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditFormularForm_FormClosing);
            this.Load += new System.EventHandler(this.EditFormularForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditFormularForm_KeyDown);
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsDataGridView)).EndInit();
            this.mainPanel.ResumeLayout(false);
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
        private UserControls.FlatControls.RoundButton addSectionButton;
        private UserControls.FlatControls.RoundButton editSectionButton;
        private UserControls.Other.AutoCompleteTextBox sectionsTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label fieldsLabel;
        private System.Windows.Forms.Label sectionLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel mainPanel;
        private UserControls.Formulars.FormEditorControl formEditor;
        private System.Windows.Forms.DataGridView fieldsDataGridView;
        private System.Windows.Forms.FlowLayoutPanel formCardFlowPanel;
        private System.Windows.Forms.PictureBox maximizeFormPictureBox;
        private System.Windows.Forms.Label previewLabel;
        private UserControls.FlatControls.RoundButton allSectionsButton;
        private UserControls.FlatControls.RoundButton addFiledButton;
        private System.Windows.Forms.ToolTip toolTip;
        private UserControls.FlatControls.RoundButton backToLastSectionButton;
        private UserControls.FlatControls.RoundButton formularFieldsButton;
        private System.Windows.Forms.DataGridView sectionsDataGridView;
        private UserControls.FlatControls.RoundButton formularSectionsButton;
        private UserControls.FlatControls.RoundButton allSectionsButton2;
    }
}