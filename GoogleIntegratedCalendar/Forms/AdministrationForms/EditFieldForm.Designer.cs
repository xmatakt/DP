namespace EZKO.Forms.AdministrationForms
{
    partial class EditFieldForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFieldForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.maximizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.commonInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionRichTextBox = new EZKO.UserControls.FlatControls.FlatRichTextBox();
            this.sectionComboBox = new System.Windows.Forms.ComboBox();
            this.fieldTypeComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.valuesTextBox = new System.Windows.Forms.TextBox();
            this.snomedTextBox = new System.Windows.Forms.TextBox();
            this.valuesLabel = new System.Windows.Forms.Label();
            this.fieldTypeLabel = new System.Windows.Forms.Label();
            this.snomedLabel = new System.Windows.Forms.Label();
            this.standardNumberTextBox = new System.Windows.Forms.TextBox();
            this.standardNumberLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.valuesInfolabel = new System.Windows.Forms.Label();
            this.formularsGroupBox = new System.Windows.Forms.GroupBox();
            this.formularsTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.formularLabel = new System.Windows.Forms.Label();
            this.formularQuestionLabel = new System.Windows.Forms.Label();
            this.insightGroupBox = new System.Windows.Forms.GroupBox();
            this.insightFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.insightLabel = new System.Windows.Forms.Label();
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            this.commonInfoGroupBox.SuspendLayout();
            this.formularsGroupBox.SuspendLayout();
            this.insightGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuPanel
            // 
            this.topMenuPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topMenuPanel.Controls.Add(this.formTitleLabel);
            this.topMenuPanel.Controls.Add(this.minimizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.maximizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.closeFormPictureBox);
            this.topMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.topMenuPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(918, 36);
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
            this.formTitleLabel.Size = new System.Drawing.Size(141, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Editácia polí EZKO";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(842, 8);
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
            // maximizeFormPictureBox
            // 
            this.maximizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeFormPictureBox.Image = global::EZKO.Properties.Resources.maximizeForm_32;
            this.maximizeFormPictureBox.Location = new System.Drawing.Point(866, 8);
            this.maximizeFormPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.maximizeFormPictureBox.Name = "maximizeFormPictureBox";
            this.maximizeFormPictureBox.Size = new System.Drawing.Size(20, 19);
            this.maximizeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maximizeFormPictureBox.TabIndex = 2;
            this.maximizeFormPictureBox.TabStop = false;
            this.maximizeFormPictureBox.Click += new System.EventHandler(this.maximizeFormPictureBox_Click);
            this.maximizeFormPictureBox.MouseEnter += new System.EventHandler(this.maximizeFormPictureBox_MouseEnter);
            this.maximizeFormPictureBox.MouseLeave += new System.EventHandler(this.maximizeFormPictureBox_MouseLeave);
            // 
            // closeFormPictureBox
            // 
            this.closeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeFormPictureBox.Image = global::EZKO.Properties.Resources.closeForm_32;
            this.closeFormPictureBox.Location = new System.Drawing.Point(890, 8);
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
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 630);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(918, 36);
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
            this.cancelButton.Location = new System.Drawing.Point(848, 5);
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
            this.addButton.Location = new System.Drawing.Point(707, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Radius = 5;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addButton.Size = new System.Drawing.Size(137, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "+ Vytvoriť pole EZKO";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // commonInfoGroupBox
            // 
            this.commonInfoGroupBox.Controls.Add(this.descriptionRichTextBox);
            this.commonInfoGroupBox.Controls.Add(this.sectionComboBox);
            this.commonInfoGroupBox.Controls.Add(this.fieldTypeComboBox);
            this.commonInfoGroupBox.Controls.Add(this.descriptionLabel);
            this.commonInfoGroupBox.Controls.Add(this.sectionLabel);
            this.commonInfoGroupBox.Controls.Add(this.valuesTextBox);
            this.commonInfoGroupBox.Controls.Add(this.snomedTextBox);
            this.commonInfoGroupBox.Controls.Add(this.valuesLabel);
            this.commonInfoGroupBox.Controls.Add(this.fieldTypeLabel);
            this.commonInfoGroupBox.Controls.Add(this.snomedLabel);
            this.commonInfoGroupBox.Controls.Add(this.standardNumberTextBox);
            this.commonInfoGroupBox.Controls.Add(this.standardNumberLabel);
            this.commonInfoGroupBox.Controls.Add(this.nameTextBox);
            this.commonInfoGroupBox.Controls.Add(this.nameLabel);
            this.commonInfoGroupBox.Controls.Add(this.valuesInfolabel);
            this.commonInfoGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commonInfoGroupBox.Location = new System.Drawing.Point(12, 41);
            this.commonInfoGroupBox.Name = "commonInfoGroupBox";
            this.commonInfoGroupBox.Size = new System.Drawing.Size(443, 397);
            this.commonInfoGroupBox.TabIndex = 2;
            this.commonInfoGroupBox.TabStop = false;
            this.commonInfoGroupBox.Text = "Všeobecné";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionRichTextBox.Location = new System.Drawing.Point(7, 243);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(429, 90);
            this.descriptionRichTextBox.TabIndex = 7;
            // 
            // sectionComboBox
            // 
            this.sectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionComboBox.FormattingEnabled = true;
            this.sectionComboBox.Location = new System.Drawing.Point(6, 199);
            this.sectionComboBox.Name = "sectionComboBox";
            this.sectionComboBox.Size = new System.Drawing.Size(151, 21);
            this.sectionComboBox.TabIndex = 6;
            // 
            // fieldTypeComboBox
            // 
            this.fieldTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldTypeComboBox.FormattingEnabled = true;
            this.fieldTypeComboBox.Location = new System.Drawing.Point(6, 157);
            this.fieldTypeComboBox.Name = "fieldTypeComboBox";
            this.fieldTypeComboBox.Size = new System.Drawing.Size(151, 21);
            this.fieldTypeComboBox.TabIndex = 6;
            this.fieldTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.fieldTypeComboBox_SelectedIndexChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(3, 226);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(128, 13);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Rozšírený popis poľa";
            // 
            // sectionLabel
            // 
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionLabel.Location = new System.Drawing.Point(3, 183);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.Size = new System.Drawing.Size(46, 13);
            this.sectionLabel.TabIndex = 4;
            this.sectionLabel.Text = "Sekcia";
            // 
            // valuesTextBox
            // 
            this.valuesTextBox.Location = new System.Drawing.Point(6, 356);
            this.valuesTextBox.Name = "valuesTextBox";
            this.valuesTextBox.Size = new System.Drawing.Size(430, 20);
            this.valuesTextBox.TabIndex = 5;
            this.valuesTextBox.TextChanged += new System.EventHandler(this.valuesTextBox_TextChanged);
            // 
            // snomedTextBox
            // 
            this.snomedTextBox.Location = new System.Drawing.Point(6, 118);
            this.snomedTextBox.Name = "snomedTextBox";
            this.snomedTextBox.Size = new System.Drawing.Size(430, 20);
            this.snomedTextBox.TabIndex = 5;
            // 
            // valuesLabel
            // 
            this.valuesLabel.AutoSize = true;
            this.valuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valuesLabel.Location = new System.Drawing.Point(3, 340);
            this.valuesLabel.Name = "valuesLabel";
            this.valuesLabel.Size = new System.Drawing.Size(54, 13);
            this.valuesLabel.TabIndex = 4;
            this.valuesLabel.Text = "Hodnoty";
            // 
            // fieldTypeLabel
            // 
            this.fieldTypeLabel.AutoSize = true;
            this.fieldTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldTypeLabel.Location = new System.Drawing.Point(3, 141);
            this.fieldTypeLabel.Name = "fieldTypeLabel";
            this.fieldTypeLabel.Size = new System.Drawing.Size(58, 13);
            this.fieldTypeLabel.TabIndex = 4;
            this.fieldTypeLabel.Text = "Typ poľa";
            // 
            // snomedLabel
            // 
            this.snomedLabel.AutoSize = true;
            this.snomedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snomedLabel.Location = new System.Drawing.Point(3, 102);
            this.snomedLabel.Name = "snomedLabel";
            this.snomedLabel.Size = new System.Drawing.Size(129, 13);
            this.snomedLabel.TabIndex = 4;
            this.snomedLabel.Text = "Iné názvy / SNOMED";
            // 
            // standardNumberTextBox
            // 
            this.standardNumberTextBox.Location = new System.Drawing.Point(6, 77);
            this.standardNumberTextBox.Name = "standardNumberTextBox";
            this.standardNumberTextBox.Size = new System.Drawing.Size(430, 20);
            this.standardNumberTextBox.TabIndex = 5;
            // 
            // standardNumberLabel
            // 
            this.standardNumberLabel.AutoSize = true;
            this.standardNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.standardNumberLabel.Location = new System.Drawing.Point(3, 61);
            this.standardNumberLabel.Name = "standardNumberLabel";
            this.standardNumberLabel.Size = new System.Drawing.Size(189, 13);
            this.standardNumberLabel.TabIndex = 4;
            this.standardNumberLabel.Text = "Číslo v štandardnom názvosloví";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 35);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(430, 20);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(3, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(78, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Názov poľa*";
            // 
            // valuesInfolabel
            // 
            this.valuesInfolabel.AutoSize = true;
            this.valuesInfolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valuesInfolabel.Location = new System.Drawing.Point(3, 376);
            this.valuesInfolabel.Name = "valuesInfolabel";
            this.valuesInfolabel.Size = new System.Drawing.Size(129, 13);
            this.valuesInfolabel.TabIndex = 8;
            this.valuesInfolabel.Text = "Hodnoty oddeľujte čiarkou";
            // 
            // formularsGroupBox
            // 
            this.formularsGroupBox.Controls.Add(this.formularsTablePanel);
            this.formularsGroupBox.Controls.Add(this.formularLabel);
            this.formularsGroupBox.Controls.Add(this.formularQuestionLabel);
            this.formularsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formularsGroupBox.Location = new System.Drawing.Point(12, 445);
            this.formularsGroupBox.Name = "formularsGroupBox";
            this.formularsGroupBox.Size = new System.Drawing.Size(443, 180);
            this.formularsGroupBox.TabIndex = 3;
            this.formularsGroupBox.TabStop = false;
            this.formularsGroupBox.Text = "Anamnestické formuláre";
            // 
            // formularsTablePanel
            // 
            this.formularsTablePanel.AutoScroll = true;
            this.formularsTablePanel.AutoSize = true;
            this.formularsTablePanel.ColumnCount = 2;
            this.formularsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.formularsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.formularsTablePanel.Location = new System.Drawing.Point(7, 34);
            this.formularsTablePanel.MaximumSize = new System.Drawing.Size(430, 140);
            this.formularsTablePanel.Name = "formularsTablePanel";
            this.formularsTablePanel.RowCount = 1;
            this.formularsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formularsTablePanel.Size = new System.Drawing.Size(430, 10);
            this.formularsTablePanel.TabIndex = 0;
            // 
            // formularLabel
            // 
            this.formularLabel.AutoSize = true;
            this.formularLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formularLabel.Location = new System.Drawing.Point(6, 18);
            this.formularLabel.Name = "formularLabel";
            this.formularLabel.Size = new System.Drawing.Size(55, 13);
            this.formularLabel.TabIndex = 4;
            this.formularLabel.Text = "Formulár";
            // 
            // formularQuestionLabel
            // 
            this.formularQuestionLabel.AutoSize = true;
            this.formularQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formularQuestionLabel.Location = new System.Drawing.Point(135, 18);
            this.formularQuestionLabel.Name = "formularQuestionLabel";
            this.formularQuestionLabel.Size = new System.Drawing.Size(121, 13);
            this.formularQuestionLabel.TabIndex = 4;
            this.formularQuestionLabel.Text = "Otázka do formulára";
            // 
            // insightGroupBox
            // 
            this.insightGroupBox.Controls.Add(this.insightFlowPanel);
            this.insightGroupBox.Controls.Add(this.insightLabel);
            this.insightGroupBox.Location = new System.Drawing.Point(461, 41);
            this.insightGroupBox.Name = "insightGroupBox";
            this.insightGroupBox.Size = new System.Drawing.Size(449, 584);
            this.insightGroupBox.TabIndex = 4;
            this.insightGroupBox.TabStop = false;
            this.insightGroupBox.Text = "Náhľad pola EZKO";
            // 
            // insightFlowPanel
            // 
            this.insightFlowPanel.AutoScroll = true;
            this.insightFlowPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.insightFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.insightFlowPanel.Location = new System.Drawing.Point(9, 35);
            this.insightFlowPanel.Name = "insightFlowPanel";
            this.insightFlowPanel.Size = new System.Drawing.Size(433, 526);
            this.insightFlowPanel.TabIndex = 1;
            // 
            // insightLabel
            // 
            this.insightLabel.AutoSize = true;
            this.insightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insightLabel.Location = new System.Drawing.Point(6, 18);
            this.insightLabel.Name = "insightLabel";
            this.insightLabel.Size = new System.Drawing.Size(41, 13);
            this.insightLabel.TabIndex = 0;
            this.insightLabel.Text = "label1";
            // 
            // EditFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 666);
            this.ControlBox = false;
            this.Controls.Add(this.insightGroupBox);
            this.Controls.Add(this.formularsGroupBox);
            this.Controls.Add(this.commonInfoGroupBox);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditFieldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EditFieldForm_Load);
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            this.commonInfoGroupBox.ResumeLayout(false);
            this.commonInfoGroupBox.PerformLayout();
            this.formularsGroupBox.ResumeLayout(false);
            this.formularsGroupBox.PerformLayout();
            this.insightGroupBox.ResumeLayout(false);
            this.insightGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topMenuPanel;
        private System.Windows.Forms.PictureBox minimizeFormPictureBox;
        private System.Windows.Forms.PictureBox maximizeFormPictureBox;
        private System.Windows.Forms.PictureBox closeFormPictureBox;
        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.FlowLayoutPanel bottomFlowPanel;
        private UserControls.FlatControls.RoundButton addButton;
        private UserControls.FlatControls.RoundButton cancelButton;
        private System.Windows.Forms.GroupBox commonInfoGroupBox;
        private System.Windows.Forms.TextBox standardNumberTextBox;
        private System.Windows.Forms.Label standardNumberLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox snomedTextBox;
        private System.Windows.Forms.Label snomedLabel;
        private System.Windows.Forms.ComboBox sectionComboBox;
        private System.Windows.Forms.ComboBox fieldTypeComboBox;
        private System.Windows.Forms.Label sectionLabel;
        private System.Windows.Forms.Label fieldTypeLabel;
        private UserControls.FlatControls.FlatRichTextBox descriptionRichTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox valuesTextBox;
        private System.Windows.Forms.Label valuesLabel;
        private System.Windows.Forms.Label valuesInfolabel;
        private System.Windows.Forms.GroupBox formularsGroupBox;
        private System.Windows.Forms.TableLayoutPanel formularsTablePanel;
        private System.Windows.Forms.Label formularLabel;
        private System.Windows.Forms.Label formularQuestionLabel;
        private System.Windows.Forms.GroupBox insightGroupBox;
        private System.Windows.Forms.Label insightLabel;
        private System.Windows.Forms.FlowLayoutPanel insightFlowPanel;
    }
}