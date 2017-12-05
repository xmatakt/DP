namespace EZKO.UserControls.Administration
{
    partial class AdministrationUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrationUserControl));
            this.controlNamePanel = new System.Windows.Forms.Panel();
            this.controlNameLabel = new System.Windows.Forms.Label();
            this.adminToolsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.usersMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.insuranceCompaniesMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.actionsMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.controlNamePanel.SuspendLayout();
            this.adminToolsFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlNamePanel
            // 
            this.controlNamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlNamePanel.Controls.Add(this.controlNameLabel);
            this.controlNamePanel.Location = new System.Drawing.Point(3, 3);
            this.controlNamePanel.Name = "controlNamePanel";
            this.controlNamePanel.Size = new System.Drawing.Size(314, 100);
            this.controlNamePanel.TabIndex = 2;
            // 
            // controlNameLabel
            // 
            this.controlNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.controlNameLabel.Location = new System.Drawing.Point(0, 0);
            this.controlNameLabel.Name = "controlNameLabel";
            this.controlNameLabel.Size = new System.Drawing.Size(314, 100);
            this.controlNameLabel.TabIndex = 0;
            this.controlNameLabel.Text = "Administrácia";
            this.controlNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminToolsFlowPanel
            // 
            this.adminToolsFlowPanel.AutoSize = true;
            this.adminToolsFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.adminToolsFlowPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.adminToolsFlowPanel.Controls.Add(this.controlNamePanel);
            this.adminToolsFlowPanel.Controls.Add(this.usersMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.insuranceCompaniesMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.actionsMenuItem);
            this.adminToolsFlowPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.adminToolsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.adminToolsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.adminToolsFlowPanel.Name = "adminToolsFlowPanel";
            this.adminToolsFlowPanel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.adminToolsFlowPanel.Size = new System.Drawing.Size(325, 761);
            this.adminToolsFlowPanel.TabIndex = 0;
            // 
            // usersMenuItem
            // 
            this.usersMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersMenuItem.AutoSize = true;
            this.usersMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usersMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.usersMenuItem.Location = new System.Drawing.Point(0, 111);
            this.usersMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.usersMenuItem.MenuItemImage = ((System.Drawing.Image)(resources.GetObject("usersMenuItem.MenuItemImage")));
            this.usersMenuItem.MenuItemText = "Používatelia";
            this.usersMenuItem.Name = "usersMenuItem";
            this.usersMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.people_black_32;
            this.usersMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.usersMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.people_32;
            this.usersMenuItem.Size = new System.Drawing.Size(320, 43);
            this.usersMenuItem.TabIndex = 4;
            this.usersMenuItem.TextForeColor = System.Drawing.Color.White;
            this.usersMenuItem.TooltipText = "TOOLTIP";
            this.usersMenuItem.AddButtonClick += new System.EventHandler(this.usersMnuItem_AddButtonClick);
            // 
            // insuranceCompaniesMenuItem
            // 
            this.insuranceCompaniesMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insuranceCompaniesMenuItem.AutoSize = true;
            this.insuranceCompaniesMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.insuranceCompaniesMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.insuranceCompaniesMenuItem.Location = new System.Drawing.Point(0, 164);
            this.insuranceCompaniesMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.insuranceCompaniesMenuItem.MenuItemImage = global::EZKO.Properties.Resources.insuranceCompany_white_32;
            this.insuranceCompaniesMenuItem.MenuItemText = "Poisťovne";
            this.insuranceCompaniesMenuItem.Name = "insuranceCompaniesMenuItem";
            this.insuranceCompaniesMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.insuranceCompany_black_32;
            this.insuranceCompaniesMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.insuranceCompaniesMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.insuranceCompany_white_32;
            this.insuranceCompaniesMenuItem.Size = new System.Drawing.Size(320, 43);
            this.insuranceCompaniesMenuItem.TabIndex = 5;
            this.insuranceCompaniesMenuItem.TextForeColor = System.Drawing.Color.White;
            this.insuranceCompaniesMenuItem.TooltipText = "Správa poisťovní ";
            this.insuranceCompaniesMenuItem.AddButtonClick += new System.EventHandler(this.insuranceCompaniesMenuItem_AddButtonClick);
            // 
            // actionsMenuItem
            // 
            this.actionsMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsMenuItem.AutoSize = true;
            this.actionsMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.actionsMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.actionsMenuItem.Location = new System.Drawing.Point(0, 217);
            this.actionsMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.actionsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.action_white_32;
            this.actionsMenuItem.MenuItemText = "Výkony";
            this.actionsMenuItem.Name = "actionsMenuItem";
            this.actionsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.action_black_32;
            this.actionsMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.actionsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.action_white_32;
            this.actionsMenuItem.Size = new System.Drawing.Size(320, 43);
            this.actionsMenuItem.TabIndex = 6;
            this.actionsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.actionsMenuItem.TooltipText = "Správa výkonov ";
            this.actionsMenuItem.AddButtonClick += new System.EventHandler(this.actionsMenuItem_AddButtonClick);
            // 
            // AdministrationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adminToolsFlowPanel);
            this.Name = "AdministrationUserControl";
            this.Size = new System.Drawing.Size(1289, 761);
            this.Load += new System.EventHandler(this.AdministrationUserControl_Load);
            this.controlNamePanel.ResumeLayout(false);
            this.adminToolsFlowPanel.ResumeLayout(false);
            this.adminToolsFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel controlNamePanel;
        private System.Windows.Forms.Label controlNameLabel;
        private System.Windows.Forms.FlowLayoutPanel adminToolsFlowPanel;
        private AdminMenuItem usersMenuItem;
        private AdminMenuItem insuranceCompaniesMenuItem;
        private AdminMenuItem actionsMenuItem;
    }
}
