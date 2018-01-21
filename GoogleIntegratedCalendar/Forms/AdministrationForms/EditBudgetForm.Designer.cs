namespace EZKO.Forms.AdministrationForms
{
    partial class EditBudgetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBudgetForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.maximizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.patientLabel = new System.Windows.Forms.Label();
            this.patientTextBox = new EZKO.UserControls.Other.AutoCompleteTextBox();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.countLabel = new System.Windows.Forms.Label();
            this.countUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.priceUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.priceLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addBudgetItemButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.topMenuPanel.Size = new System.Drawing.Size(465, 36);
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
            this.formTitleLabel.Size = new System.Drawing.Size(139, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Editácia rozpočtov";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(389, 8);
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
            this.maximizeFormPictureBox.Location = new System.Drawing.Point(413, 8);
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
            this.closeFormPictureBox.Location = new System.Drawing.Point(437, 8);
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
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 451);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(465, 36);
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
            this.cancelButton.Location = new System.Drawing.Point(407, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Radius = 5;
            this.cancelButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatOrange;
            this.cancelButton.Size = new System.Drawing.Size(50, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Zrušiť";
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
            this.addButton.Location = new System.Drawing.Point(278, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Radius = 5;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addButton.Size = new System.Drawing.Size(125, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "+ Vytvoriť rozpočet";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(13, 47);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(48, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Názov*";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(16, 64);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(430, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLabel.Location = new System.Drawing.Point(13, 89);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(55, 13);
            this.patientLabel.TabIndex = 2;
            this.patientLabel.Text = "Pacient*";
            // 
            // patientTextBox
            // 
            this.patientTextBox.Location = new System.Drawing.Point(16, 106);
            this.patientTextBox.Name = "patientTextBox";
            this.patientTextBox.Size = new System.Drawing.Size(430, 20);
            this.patientTextBox.TabIndex = 4;
            this.patientTextBox.Values = null;
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNameLabel.Location = new System.Drawing.Point(13, 145);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(135, 13);
            this.itemNameLabel.TabIndex = 2;
            this.itemNameLabel.Text = "Nová položka - názov:";
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(16, 161);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(213, 20);
            this.itemNameTextBox.TabIndex = 3;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(238, 146);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(44, 13);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "Počet:";
            // 
            // countUpDown
            // 
            this.countUpDown.LabelText = "ks";
            this.countUpDown.Location = new System.Drawing.Point(241, 162);
            this.countUpDown.Name = "countUpDown";
            this.countUpDown.Size = new System.Drawing.Size(75, 20);
            this.countUpDown.TabIndex = 5;
            // 
            // priceUpDown
            // 
            this.priceUpDown.DecimalPlaces = 2;
            this.priceUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.priceUpDown.LabelText = "€";
            this.priceUpDown.Location = new System.Drawing.Point(325, 162);
            this.priceUpDown.Name = "priceUpDown";
            this.priceUpDown.Size = new System.Drawing.Size(82, 20);
            this.priceUpDown.TabIndex = 5;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(322, 145);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(40, 13);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Cena:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(16, 200);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(430, 240);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // addBudgetItemButton
            // 
            this.addBudgetItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.addBudgetItemButton.BackgroundImage = global::EZKO.Properties.Resources.add_white_16;
            this.addBudgetItemButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addBudgetItemButton.FlatAppearance.BorderSize = 0;
            this.addBudgetItemButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addBudgetItemButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addBudgetItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBudgetItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.addBudgetItemButton.ForeColor = System.Drawing.Color.White;
            this.addBudgetItemButton.Location = new System.Drawing.Point(413, 160);
            this.addBudgetItemButton.Name = "addBudgetItemButton";
            this.addBudgetItemButton.Radius = 5;
            this.addBudgetItemButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.addBudgetItemButton.Size = new System.Drawing.Size(32, 24);
            this.addBudgetItemButton.TabIndex = 7;
            this.addBudgetItemButton.UseVisualStyleBackColor = false;
            this.addBudgetItemButton.Click += new System.EventHandler(this.addBudgetItemButton_Click);
            // 
            // EditBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(465, 487);
            this.ControlBox = false;
            this.Controls.Add(this.addBudgetItemButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.priceUpDown);
            this.Controls.Add(this.countUpDown);
            this.Controls.Add(this.patientTextBox);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditBudgetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EditBudgetForm_Load);
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
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
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label patientLabel;
        private UserControls.Other.AutoCompleteTextBox patientTextBox;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.Label countLabel;
        private UserControls.Other.LabeledNumericUpDown countUpDown;
        private UserControls.Other.LabeledNumericUpDown priceUpDown;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private UserControls.FlatControls.RoundButton addBudgetItemButton;
    }
}