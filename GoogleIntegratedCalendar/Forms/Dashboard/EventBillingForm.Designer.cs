namespace EZKO.Forms.Dashboard
{
    partial class EventBillingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventBillingForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.maximizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.endButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.billingItemsGridView = new System.Windows.Forms.DataGridView();
            this.priceLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.addItemButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addBudgetItemButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.discountUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.priceUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.countUpDown = new EZKO.UserControls.Other.LabeledNumericUpDown();
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billingItemsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countUpDown)).BeginInit();
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
            this.topMenuPanel.Size = new System.Drawing.Size(616, 36);
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
            this.formTitleLabel.Size = new System.Drawing.Size(138, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Položky ku úhrade";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(540, 8);
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
            this.maximizeFormPictureBox.Location = new System.Drawing.Point(564, 8);
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
            this.closeFormPictureBox.Location = new System.Drawing.Point(588, 8);
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
            this.bottomFlowPanel.Controls.Add(this.endButton);
            this.bottomFlowPanel.Controls.Add(this.panel1);
            this.bottomFlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 376);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(616, 36);
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
            this.cancelButton.Location = new System.Drawing.Point(558, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Radius = 5;
            this.cancelButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatOrange;
            this.cancelButton.Size = new System.Drawing.Size(50, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Zrušiť";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // endButton
            // 
            this.endButton.AutoSize = true;
            this.endButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.endButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.endButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.endButton.FlatAppearance.BorderSize = 0;
            this.endButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.endButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.endButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.endButton.ForeColor = System.Drawing.Color.White;
            this.endButton.Location = new System.Drawing.Point(485, 5);
            this.endButton.Margin = new System.Windows.Forms.Padding(2);
            this.endButton.Name = "endButton";
            this.endButton.Radius = 5;
            this.endButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.endButton.Size = new System.Drawing.Size(69, 23);
            this.endButton.TabIndex = 6;
            this.endButton.Text = "Dokončiť";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(480, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 8;
            // 
            // billingItemsGridView
            // 
            this.billingItemsGridView.AllowUserToAddRows = false;
            this.billingItemsGridView.AllowUserToDeleteRows = false;
            this.billingItemsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.billingItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.billingItemsGridView.Location = new System.Drawing.Point(12, 97);
            this.billingItemsGridView.Name = "billingItemsGridView";
            this.billingItemsGridView.ReadOnly = true;
            this.billingItemsGridView.Size = new System.Drawing.Size(592, 245);
            this.billingItemsGridView.TabIndex = 3;
            this.billingItemsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.billingItemsGridView_CellContentClick);
            this.billingItemsGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.billingItemsGridView_RowEnter);
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(284, 53);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(40, 13);
            this.priceLabel.TabIndex = 8;
            this.priceLabel.Text = "Cena:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(203, 53);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(44, 13);
            this.countLabel.TabIndex = 9;
            this.countLabel.Text = "Počet:";
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNameLabel.Location = new System.Drawing.Point(12, 55);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(94, 13);
            this.itemNameLabel.TabIndex = 10;
            this.itemNameLabel.Text = "Názov položky:";
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(12, 71);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(188, 20);
            this.itemNameTextBox.TabIndex = 14;
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountLabel.Location = new System.Drawing.Point(372, 53);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(45, 13);
            this.discountLabel.TabIndex = 8;
            this.discountLabel.Text = "Zľava:";
            // 
            // addItemButton
            // 
            this.addItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.addItemButton.FlatAppearance.BorderSize = 0;
            this.addItemButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addItemButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.addItemButton.ForeColor = System.Drawing.Color.White;
            this.addItemButton.Location = new System.Drawing.Point(12, 348);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Radius = 5;
            this.addItemButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.addItemButton.Size = new System.Drawing.Size(98, 23);
            this.addItemButton.TabIndex = 15;
            this.addItemButton.Text = "Pridať položku";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // addBudgetItemButton
            // 
            this.addBudgetItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.addBudgetItemButton.BackgroundImage = global::EZKO.Properties.Resources.ok_mark_white_16;
            this.addBudgetItemButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addBudgetItemButton.FlatAppearance.BorderSize = 0;
            this.addBudgetItemButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addBudgetItemButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addBudgetItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBudgetItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.addBudgetItemButton.ForeColor = System.Drawing.Color.White;
            this.addBudgetItemButton.Location = new System.Drawing.Point(564, 71);
            this.addBudgetItemButton.Name = "addBudgetItemButton";
            this.addBudgetItemButton.Radius = 5;
            this.addBudgetItemButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.addBudgetItemButton.Size = new System.Drawing.Size(40, 20);
            this.addBudgetItemButton.TabIndex = 13;
            this.addBudgetItemButton.UseVisualStyleBackColor = false;
            this.addBudgetItemButton.Click += new System.EventHandler(this.addBudgetItemButton_Click);
            // 
            // discountUpDown
            // 
            this.discountUpDown.DecimalPlaces = 2;
            this.discountUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.discountUpDown.LabelText = "€";
            this.discountUpDown.Location = new System.Drawing.Point(375, 71);
            this.discountUpDown.Name = "discountUpDown";
            this.discountUpDown.Size = new System.Drawing.Size(82, 20);
            this.discountUpDown.TabIndex = 11;
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
            this.priceUpDown.Location = new System.Drawing.Point(287, 71);
            this.priceUpDown.Name = "priceUpDown";
            this.priceUpDown.Size = new System.Drawing.Size(82, 20);
            this.priceUpDown.TabIndex = 11;
            this.priceUpDown.ValueChanged += new System.EventHandler(this.countUpDown_ValueChanged);
            // 
            // countUpDown
            // 
            this.countUpDown.LabelText = "ks";
            this.countUpDown.Location = new System.Drawing.Point(206, 71);
            this.countUpDown.Name = "countUpDown";
            this.countUpDown.Size = new System.Drawing.Size(75, 20);
            this.countUpDown.TabIndex = 12;
            this.countUpDown.ValueChanged += new System.EventHandler(this.countUpDown_ValueChanged);
            // 
            // EventBillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 412);
            this.ControlBox = false;
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.addBudgetItemButton);
            this.Controls.Add(this.discountUpDown);
            this.Controls.Add(this.priceUpDown);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.countUpDown);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.billingItemsGridView);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EventBillingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billingItemsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countUpDown)).EndInit();
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
        private UserControls.FlatControls.RoundButton endButton;
        private UserControls.FlatControls.RoundButton cancelButton;
        private System.Windows.Forms.DataGridView billingItemsGridView;
        private UserControls.FlatControls.RoundButton addBudgetItemButton;
        private UserControls.Other.LabeledNumericUpDown priceUpDown;
        private UserControls.Other.LabeledNumericUpDown countUpDown;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.Panel panel1;
        private UserControls.FlatControls.RoundButton addItemButton;
        private System.Windows.Forms.Label discountLabel;
        private UserControls.Other.LabeledNumericUpDown discountUpDown;
    }
}