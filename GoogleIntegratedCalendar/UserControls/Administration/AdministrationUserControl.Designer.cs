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
            this.panel1 = new System.Windows.Forms.Panel();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.userLoginLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.editLoggedUserButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.usersMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.insuranceCompaniesMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.actionsMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.infrastructureMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.ezkoSectionsMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.budgetsMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.formularsMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.ezkoFieldsMenuItem = new EZKO.UserControls.Administration.AdminMenuItem();
            this.controlNamePanel.SuspendLayout();
            this.adminToolsFlowPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // controlNamePanel
            // 
            this.controlNamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlNamePanel.Controls.Add(this.controlNameLabel);
            this.controlNamePanel.Location = new System.Drawing.Point(2, 2);
            this.controlNamePanel.Margin = new System.Windows.Forms.Padding(2);
            this.controlNamePanel.Name = "controlNamePanel";
            this.controlNamePanel.Size = new System.Drawing.Size(220, 45);
            this.controlNamePanel.TabIndex = 2;
            // 
            // controlNameLabel
            // 
            this.controlNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.controlNameLabel.Location = new System.Drawing.Point(0, 0);
            this.controlNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.controlNameLabel.Name = "controlNameLabel";
            this.controlNameLabel.Size = new System.Drawing.Size(220, 45);
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
            this.adminToolsFlowPanel.Controls.Add(this.panel1);
            this.adminToolsFlowPanel.Controls.Add(this.usersMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.insuranceCompaniesMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.actionsMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.infrastructureMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.ezkoSectionsMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.budgetsMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.formularsMenuItem);
            this.adminToolsFlowPanel.Controls.Add(this.ezkoFieldsMenuItem);
            this.adminToolsFlowPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.adminToolsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.adminToolsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.adminToolsFlowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.adminToolsFlowPanel.Name = "adminToolsFlowPanel";
            this.adminToolsFlowPanel.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.adminToolsFlowPanel.Size = new System.Drawing.Size(227, 567);
            this.adminToolsFlowPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.userPictureBox);
            this.panel1.Controls.Add(this.editLoggedUserButton);
            this.panel1.Controls.Add(this.userLoginLabel);
            this.panel1.Location = new System.Drawing.Point(3, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 205);
            this.panel1.TabIndex = 1;
            // 
            // userPictureBox
            // 
            this.userPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userPictureBox.Image = global::EZKO.Properties.Resources.noUserImage;
            this.userPictureBox.Location = new System.Drawing.Point(10, -2);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(199, 155);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPictureBox.TabIndex = 0;
            this.userPictureBox.TabStop = false;
            // 
            // userLoginLabel
            // 
            this.userLoginLabel.AutoSize = true;
            this.userLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLoginLabel.ForeColor = System.Drawing.Color.White;
            this.userLoginLabel.Location = new System.Drawing.Point(3, 156);
            this.userLoginLabel.Name = "userLoginLabel";
            this.userLoginLabel.Size = new System.Drawing.Size(51, 20);
            this.userLoginLabel.TabIndex = 1;
            this.userLoginLabel.Text = "label1";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(227, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(672, 567);
            this.mainPanel.TabIndex = 1;
            // 
            // editLoggedUserButton
            // 
            this.editLoggedUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editLoggedUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.editLoggedUserButton.FlatAppearance.BorderSize = 0;
            this.editLoggedUserButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.editLoggedUserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.editLoggedUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editLoggedUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.editLoggedUserButton.ForeColor = System.Drawing.Color.White;
            this.editLoggedUserButton.Location = new System.Drawing.Point(4, 179);
            this.editLoggedUserButton.Name = "editLoggedUserButton";
            this.editLoggedUserButton.Radius = 5;
            this.editLoggedUserButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.editLoggedUserButton.Size = new System.Drawing.Size(211, 23);
            this.editLoggedUserButton.TabIndex = 2;
            this.editLoggedUserButton.Text = "Moje konto";
            this.editLoggedUserButton.UseVisualStyleBackColor = false;
            this.editLoggedUserButton.Click += new System.EventHandler(this.editLoggedUserButton_Click);
            // 
            // usersMenuItem
            // 
            this.usersMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersMenuItem.AutoSize = true;
            this.usersMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usersMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.usersMenuItem.Location = new System.Drawing.Point(0, 263);
            this.usersMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.usersMenuItem.MenuItemImage = ((System.Drawing.Image)(resources.GetObject("usersMenuItem.MenuItemImage")));
            this.usersMenuItem.MenuItemText = "Používatelia";
            this.usersMenuItem.Name = "usersMenuItem";
            this.usersMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.people_black_32;
            this.usersMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.usersMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.people_32;
            this.usersMenuItem.Size = new System.Drawing.Size(224, 29);
            this.usersMenuItem.TabIndex = 4;
            this.usersMenuItem.TextForeColor = System.Drawing.Color.White;
            this.usersMenuItem.TooltipText = "Pridávajte a modifikujte používateľské kontá";
            this.usersMenuItem.ListButtonClick += new System.EventHandler(this.usersMenuItem_ListButtonClick);
            this.usersMenuItem.AddButtonClick += new System.EventHandler(this.usersMnuItem_AddButtonClick);
            // 
            // insuranceCompaniesMenuItem
            // 
            this.insuranceCompaniesMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insuranceCompaniesMenuItem.AutoSize = true;
            this.insuranceCompaniesMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.insuranceCompaniesMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.insuranceCompaniesMenuItem.Location = new System.Drawing.Point(0, 298);
            this.insuranceCompaniesMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.insuranceCompaniesMenuItem.MenuItemImage = global::EZKO.Properties.Resources.insuranceCompany_white_32;
            this.insuranceCompaniesMenuItem.MenuItemText = "Poisťovne";
            this.insuranceCompaniesMenuItem.Name = "insuranceCompaniesMenuItem";
            this.insuranceCompaniesMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.insuranceCompany_black_32;
            this.insuranceCompaniesMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.insuranceCompaniesMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.insuranceCompany_white_32;
            this.insuranceCompaniesMenuItem.Size = new System.Drawing.Size(224, 29);
            this.insuranceCompaniesMenuItem.TabIndex = 5;
            this.insuranceCompaniesMenuItem.TextForeColor = System.Drawing.Color.White;
            this.insuranceCompaniesMenuItem.TooltipText = "Správa poisťovní ";
            this.insuranceCompaniesMenuItem.ListButtonClick += new System.EventHandler(this.insuranceCompaniesMenuItem_ListButtonClick);
            this.insuranceCompaniesMenuItem.AddButtonClick += new System.EventHandler(this.insuranceCompaniesMenuItem_AddButtonClick);
            // 
            // actionsMenuItem
            // 
            this.actionsMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsMenuItem.AutoSize = true;
            this.actionsMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.actionsMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.actionsMenuItem.Location = new System.Drawing.Point(0, 333);
            this.actionsMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.actionsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.action_white_32;
            this.actionsMenuItem.MenuItemText = "Výkony";
            this.actionsMenuItem.Name = "actionsMenuItem";
            this.actionsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.action_black_32;
            this.actionsMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.actionsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.action_white_32;
            this.actionsMenuItem.Size = new System.Drawing.Size(224, 29);
            this.actionsMenuItem.TabIndex = 6;
            this.actionsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.actionsMenuItem.TooltipText = "Správa výkonov ";
            this.actionsMenuItem.ListButtonClick += new System.EventHandler(this.actionsMenuItem_ListButtonClick);
            this.actionsMenuItem.AddButtonClick += new System.EventHandler(this.actionsMenuItem_AddButtonClick);
            // 
            // infrastructureMenuItem
            // 
            this.infrastructureMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infrastructureMenuItem.AutoSize = true;
            this.infrastructureMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.infrastructureMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.infrastructureMenuItem.Location = new System.Drawing.Point(0, 368);
            this.infrastructureMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.infrastructureMenuItem.MenuItemImage = global::EZKO.Properties.Resources.dentist_chair_white_32;
            this.infrastructureMenuItem.MenuItemText = "Infraštruktúra";
            this.infrastructureMenuItem.Name = "infrastructureMenuItem";
            this.infrastructureMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.dentist_chair_black_32;
            this.infrastructureMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.infrastructureMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.dentist_chair_white_32;
            this.infrastructureMenuItem.Size = new System.Drawing.Size(224, 29);
            this.infrastructureMenuItem.TabIndex = 7;
            this.infrastructureMenuItem.TextForeColor = System.Drawing.Color.White;
            this.infrastructureMenuItem.TooltipText = "Administrácie kresiel kliniky";
            this.infrastructureMenuItem.ListButtonClick += new System.EventHandler(this.infrastructureMenuItem_ListButtonClick);
            this.infrastructureMenuItem.AddButtonClick += new System.EventHandler(this.infrastructureMenuItem_AddButtonClick);
            // 
            // ezkoSectionsMenuItem
            // 
            this.ezkoSectionsMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ezkoSectionsMenuItem.AutoSize = true;
            this.ezkoSectionsMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ezkoSectionsMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ezkoSectionsMenuItem.Location = new System.Drawing.Point(0, 403);
            this.ezkoSectionsMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ezkoSectionsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.list_white_16;
            this.ezkoSectionsMenuItem.MenuItemText = "Sekcie EZKO";
            this.ezkoSectionsMenuItem.Name = "ezkoSectionsMenuItem";
            this.ezkoSectionsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.list_black_16;
            this.ezkoSectionsMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.ezkoSectionsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.list_white_16;
            this.ezkoSectionsMenuItem.Size = new System.Drawing.Size(224, 29);
            this.ezkoSectionsMenuItem.TabIndex = 8;
            this.ezkoSectionsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.ezkoSectionsMenuItem.TooltipText = "Polia ezko do sekcií EZKO. Spravujte ich.";
            this.ezkoSectionsMenuItem.ListButtonClick += new System.EventHandler(this.ezkoSectionsMenuItem_ListButtonClick);
            this.ezkoSectionsMenuItem.AddButtonClick += new System.EventHandler(this.ezkoSectionsMenuItem_AddButtonClick);
            // 
            // budgetsMenuItem
            // 
            this.budgetsMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.budgetsMenuItem.AutoSize = true;
            this.budgetsMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.budgetsMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.budgetsMenuItem.Location = new System.Drawing.Point(0, 438);
            this.budgetsMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.budgetsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.budget_white_24;
            this.budgetsMenuItem.MenuItemText = "Rozpočty";
            this.budgetsMenuItem.Name = "budgetsMenuItem";
            this.budgetsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.budget_black_24;
            this.budgetsMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.budgetsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.budget_white_24;
            this.budgetsMenuItem.Size = new System.Drawing.Size(224, 29);
            this.budgetsMenuItem.TabIndex = 9;
            this.budgetsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.budgetsMenuItem.TooltipText = "Správa rozpočtov pre pacientov";
            this.budgetsMenuItem.ListButtonClick += new System.EventHandler(this.budgetsMenuItem_ListButtonClick);
            this.budgetsMenuItem.AddButtonClick += new System.EventHandler(this.budgetsMenuItem_AddButtonClick);
            // 
            // formularsMenuItem
            // 
            this.formularsMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formularsMenuItem.AutoSize = true;
            this.formularsMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formularsMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.formularsMenuItem.Location = new System.Drawing.Point(0, 473);
            this.formularsMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.formularsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.formular_white_24;
            this.formularsMenuItem.MenuItemText = "Formuláre";
            this.formularsMenuItem.Name = "formularsMenuItem";
            this.formularsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.formular_black_24;
            this.formularsMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.formularsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.formular_white_24;
            this.formularsMenuItem.Size = new System.Drawing.Size(224, 29);
            this.formularsMenuItem.TabIndex = 10;
            this.formularsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.formularsMenuItem.TooltipText = "Anamnestické formuláre môžete tvoriť z polí Ezko.";
            this.formularsMenuItem.ListButtonClick += new System.EventHandler(this.formularsMenuItem_ListButtonClick);
            this.formularsMenuItem.AddButtonClick += new System.EventHandler(this.formularsMenuItem_AddButtonClick);
            // 
            // ezkoFieldsMenuItem
            // 
            this.ezkoFieldsMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ezkoFieldsMenuItem.AutoSize = true;
            this.ezkoFieldsMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ezkoFieldsMenuItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ezkoFieldsMenuItem.Location = new System.Drawing.Point(0, 508);
            this.ezkoFieldsMenuItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ezkoFieldsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.fields_white_24;
            this.ezkoFieldsMenuItem.MenuItemText = "Polia EZKO";
            this.ezkoFieldsMenuItem.Name = "ezkoFieldsMenuItem";
            this.ezkoFieldsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.fields_black_24;
            this.ezkoFieldsMenuItem.OnHoverTextForeColor = System.Drawing.Color.Black;
            this.ezkoFieldsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.fields_white_24;
            this.ezkoFieldsMenuItem.Size = new System.Drawing.Size(224, 29);
            this.ezkoFieldsMenuItem.TabIndex = 11;
            this.ezkoFieldsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.ezkoFieldsMenuItem.TooltipText = "Spravujte elektronickú kartu pacienta. Pridávajte do nej nové polia.";
            this.ezkoFieldsMenuItem.ListButtonClick += new System.EventHandler(this.ezkoFieldsMenuItem_ListButtonClick);
            this.ezkoFieldsMenuItem.AddButtonClick += new System.EventHandler(this.ezkoFieldsMenuItem_AddButtonClick);
            // 
            // AdministrationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.adminToolsFlowPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdministrationUserControl";
            this.Size = new System.Drawing.Size(899, 567);
            this.Load += new System.EventHandler(this.AdministrationUserControl_Load);
            this.controlNamePanel.ResumeLayout(false);
            this.adminToolsFlowPanel.ResumeLayout(false);
            this.adminToolsFlowPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label userLoginLabel;
        private System.Windows.Forms.PictureBox userPictureBox;
        private FlatControls.RoundButton editLoggedUserButton;
        private System.Windows.Forms.Panel mainPanel;
        private AdminMenuItem infrastructureMenuItem;
        private AdminMenuItem ezkoSectionsMenuItem;
        private AdminMenuItem budgetsMenuItem;
        private AdminMenuItem formularsMenuItem;
        private AdminMenuItem ezkoFieldsMenuItem;
    }
}
