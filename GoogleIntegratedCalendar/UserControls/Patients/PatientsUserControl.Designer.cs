namespace EZKO.UserControls.Patients
{
    partial class PatientsUserControl
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.topMenuFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newPatientMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.exportMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.importMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.titleLabel = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterLabel = new System.Windows.Forms.Label();
            this.findButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.topPanel.SuspendLayout();
            this.topMenuFlowPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.topPanel.Controls.Add(this.topMenuFlowPanel);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1027, 53);
            this.topPanel.TabIndex = 0;
            // 
            // topMenuFlowPanel
            // 
            this.topMenuFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topMenuFlowPanel.AutoSize = true;
            this.topMenuFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topMenuFlowPanel.Controls.Add(this.newPatientMenuItem);
            this.topMenuFlowPanel.Controls.Add(this.exportMenuItem);
            this.topMenuFlowPanel.Controls.Add(this.importMenuItem);
            this.topMenuFlowPanel.Location = new System.Drawing.Point(586, 10);
            this.topMenuFlowPanel.Name = "topMenuFlowPanel";
            this.topMenuFlowPanel.Size = new System.Drawing.Size(441, 31);
            this.topMenuFlowPanel.TabIndex = 3;
            // 
            // newPatientMenuItem
            // 
            this.newPatientMenuItem.AutoSize = true;
            this.newPatientMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.newPatientMenuItem.Location = new System.Drawing.Point(2, 2);
            this.newPatientMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newPatientMenuItem.MenuItemImage = global::EZKO.Properties.Resources.new_patient_white_32;
            this.newPatientMenuItem.MenuItemText = "Nový pacient";
            this.newPatientMenuItem.Name = "newPatientMenuItem";
            this.newPatientMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.new_patient_black_32;
            this.newPatientMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.newPatientMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.new_patient_white_32;
            this.newPatientMenuItem.Size = new System.Drawing.Size(141, 27);
            this.newPatientMenuItem.TabIndex = 0;
            this.newPatientMenuItem.TextForeColor = System.Drawing.Color.White;
            this.newPatientMenuItem.TransparentPanelMouseClick += new System.Windows.Forms.MouseEventHandler(this.newPatientMenuItem_TransparentPanelMouseClick);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.AutoSize = true;
            this.exportMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.exportMenuItem.Location = new System.Drawing.Point(147, 2);
            this.exportMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exportMenuItem.MenuItemImage = global::EZKO.Properties.Resources.export_data_white_32;
            this.exportMenuItem.MenuItemText = "Export (*.csv)";
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.export_data_black_32;
            this.exportMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.exportMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.export_data_white_32;
            this.exportMenuItem.Size = new System.Drawing.Size(144, 27);
            this.exportMenuItem.TabIndex = 1;
            this.exportMenuItem.TextForeColor = System.Drawing.Color.White;
            // 
            // importMenuItem
            // 
            this.importMenuItem.AutoSize = true;
            this.importMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.importMenuItem.Location = new System.Drawing.Point(295, 2);
            this.importMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importMenuItem.MenuItemImage = global::EZKO.Properties.Resources.import_data_white_32;
            this.importMenuItem.MenuItemText = "Import (*.csv)";
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.import_data_black_32;
            this.importMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.importMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.import_data_white_32;
            this.importMenuItem.Size = new System.Drawing.Size(144, 27);
            this.importMenuItem.TabIndex = 2;
            this.importMenuItem.TextForeColor = System.Drawing.Color.White;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(191, 53);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Zoznam pacientov";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(5, 23);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(329, 20);
            this.filterTextBox.TabIndex = 1;
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.filterPanel.Controls.Add(this.filterTextBox);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Controls.Add(this.findButton);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 53);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1027, 53);
            this.filterPanel.TabIndex = 3;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(2, 7);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(300, 13);
            this.filterLabel.TabIndex = 3;
            this.filterLabel.Text = "Zadajte ID pacienta, časť mena, priezviska, emailu alebo ulice";
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.findButton.FlatAppearance.BorderSize = 0;
            this.findButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.findButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.findButton.ForeColor = System.Drawing.Color.White;
            this.findButton.Location = new System.Drawing.Point(340, 23);
            this.findButton.Name = "findButton";
            this.findButton.Radius = 5;
            this.findButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.findButton.Size = new System.Drawing.Size(56, 20);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Hľadať";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 106);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1027, 424);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // PatientsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "PatientsUserControl";
            this.Size = new System.Drawing.Size(1027, 530);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.topMenuFlowPanel.ResumeLayout(false);
            this.topMenuFlowPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel topMenuFlowPanel;
        private Dashboard.MenuItem newPatientMenuItem;
        private Dashboard.MenuItem exportMenuItem;
        private Dashboard.MenuItem importMenuItem;
        private System.Windows.Forms.TextBox filterTextBox;
        private FlatControls.RoundButton findButton;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}
