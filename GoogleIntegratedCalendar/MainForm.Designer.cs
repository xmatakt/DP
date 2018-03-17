namespace EZKO
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.maximizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenuFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ezkoMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.dashboardMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.ambulantionMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.patientsMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.administrationMenuItem = new EZKO.UserControls.Dashboard.MenuItem();
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.userNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            this.mainMenuFlowPanel.SuspendLayout();
            this.topMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(0, 44);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1294, 747);
            this.mainPanel.TabIndex = 3;
            // 
            // closeFormPictureBox
            // 
            this.closeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeFormPictureBox.Image = global::EZKO.Properties.Resources.closeForm_32;
            this.closeFormPictureBox.Location = new System.Drawing.Point(1270, 9);
            this.closeFormPictureBox.Name = "closeFormPictureBox";
            this.closeFormPictureBox.Size = new System.Drawing.Size(20, 20);
            this.closeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeFormPictureBox.TabIndex = 0;
            this.closeFormPictureBox.TabStop = false;
            this.closeFormPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.closeFormPictureBox.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.closeFormPictureBox.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // maximizeFormPictureBox
            // 
            this.maximizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeFormPictureBox.Image = global::EZKO.Properties.Resources.minimizeForm_32;
            this.maximizeFormPictureBox.Location = new System.Drawing.Point(1244, 9);
            this.maximizeFormPictureBox.Name = "maximizeFormPictureBox";
            this.maximizeFormPictureBox.Size = new System.Drawing.Size(20, 20);
            this.maximizeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maximizeFormPictureBox.TabIndex = 0;
            this.maximizeFormPictureBox.TabStop = false;
            this.maximizeFormPictureBox.Click += new System.EventHandler(this.maximizeFormPictureBox_Click);
            this.maximizeFormPictureBox.MouseEnter += new System.EventHandler(this.maximizeFormPictureBox_MouseEnter);
            this.maximizeFormPictureBox.MouseLeave += new System.EventHandler(this.maximizeFormPictureBox_MouseLeave);
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(1218, 9);
            this.minimizeFormPictureBox.Name = "minimizeFormPictureBox";
            this.minimizeFormPictureBox.Size = new System.Drawing.Size(20, 20);
            this.minimizeFormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimizeFormPictureBox.TabIndex = 0;
            this.minimizeFormPictureBox.TabStop = false;
            this.minimizeFormPictureBox.Click += new System.EventHandler(this.minimizeFormPictureBox_Click);
            this.minimizeFormPictureBox.MouseEnter += new System.EventHandler(this.minimizeFormPictureBox_MouseEnter);
            this.minimizeFormPictureBox.MouseLeave += new System.EventHandler(this.minimizeFormPictureBox_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // mainMenuFlowPanel
            // 
            this.mainMenuFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainMenuFlowPanel.AutoSize = true;
            this.mainMenuFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMenuFlowPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainMenuFlowPanel.Controls.Add(this.ezkoMenuItem);
            this.mainMenuFlowPanel.Controls.Add(this.dashboardMenuItem);
            this.mainMenuFlowPanel.Controls.Add(this.ambulantionMenuItem);
            this.mainMenuFlowPanel.Controls.Add(this.patientsMenuItem);
            this.mainMenuFlowPanel.Controls.Add(this.administrationMenuItem);
            this.mainMenuFlowPanel.Location = new System.Drawing.Point(0, 3);
            this.mainMenuFlowPanel.Name = "mainMenuFlowPanel";
            this.mainMenuFlowPanel.Size = new System.Drawing.Size(706, 31);
            this.mainMenuFlowPanel.TabIndex = 3;
            // 
            // ezkoMenuItem
            // 
            this.ezkoMenuItem.AutoSize = true;
            this.ezkoMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ezkoMenuItem.Location = new System.Drawing.Point(2, 2);
            this.ezkoMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ezkoMenuItem.MenuItemImage = null;
            this.ezkoMenuItem.MenuItemText = "EZKO";
            this.ezkoMenuItem.Name = "ezkoMenuItem";
            this.ezkoMenuItem.OnHoverMenuItemImage = null;
            this.ezkoMenuItem.OnHoverTextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(240)))));
            this.ezkoMenuItem.OnLeaveMenuItemImage = null;
            this.ezkoMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.ezkoMenuItem.Size = new System.Drawing.Size(109, 27);
            this.ezkoMenuItem.TabIndex = 0;
            this.ezkoMenuItem.TextForeColor = System.Drawing.Color.White;
            // 
            // dashboardMenuItem
            // 
            this.dashboardMenuItem.AutoSize = true;
            this.dashboardMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dashboardMenuItem.Location = new System.Drawing.Point(115, 2);
            this.dashboardMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dashboardMenuItem.MenuItemImage = global::EZKO.Properties.Resources.dashboard_32;
            this.dashboardMenuItem.MenuItemText = "Dashboard";
            this.dashboardMenuItem.Name = "dashboardMenuItem";
            this.dashboardMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.dashboard_active_32;
            this.dashboardMenuItem.OnHoverTextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(240)))));
            this.dashboardMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.dashboard_32;
            this.dashboardMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.dashboardMenuItem.Size = new System.Drawing.Size(145, 27);
            this.dashboardMenuItem.TabIndex = 1;
            this.dashboardMenuItem.TextForeColor = System.Drawing.Color.White;
            this.dashboardMenuItem.TransparentPanelMouseClick += new System.Windows.Forms.MouseEventHandler(this.dashboardMenuItem_TransparentPanelMouseClick);
            // 
            // ambulantionMenuItem
            // 
            this.ambulantionMenuItem.AutoSize = true;
            this.ambulantionMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ambulantionMenuItem.Location = new System.Drawing.Point(264, 2);
            this.ambulantionMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ambulantionMenuItem.MenuItemImage = global::EZKO.Properties.Resources.formList_32;
            this.ambulantionMenuItem.MenuItemText = "Ambulancia";
            this.ambulantionMenuItem.Name = "ambulantionMenuItem";
            this.ambulantionMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.formList_active_32;
            this.ambulantionMenuItem.OnHoverTextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(240)))));
            this.ambulantionMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.formList_32;
            this.ambulantionMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.ambulantionMenuItem.Size = new System.Drawing.Size(149, 27);
            this.ambulantionMenuItem.TabIndex = 2;
            this.ambulantionMenuItem.TextForeColor = System.Drawing.Color.White;
            this.ambulantionMenuItem.TransparentPanelMouseClick += new System.Windows.Forms.MouseEventHandler(this.ambulantionMenuItem_TransparentPanelMouseClick);
            // 
            // patientsMenuItem
            // 
            this.patientsMenuItem.AutoSize = true;
            this.patientsMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.patientsMenuItem.Location = new System.Drawing.Point(417, 2);
            this.patientsMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.patientsMenuItem.MenuItemImage = global::EZKO.Properties.Resources.people_32;
            this.patientsMenuItem.MenuItemText = "Pacienti";
            this.patientsMenuItem.Name = "patientsMenuItem";
            this.patientsMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.people_active_32;
            this.patientsMenuItem.OnHoverTextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(240)))));
            this.patientsMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.people_32;
            this.patientsMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.patientsMenuItem.Size = new System.Drawing.Size(122, 27);
            this.patientsMenuItem.TabIndex = 4;
            this.patientsMenuItem.TextForeColor = System.Drawing.Color.White;
            this.patientsMenuItem.TransparentPanelMouseClick += new System.Windows.Forms.MouseEventHandler(this.patientsMenuItem_TransparentPanelMouseClick);
            // 
            // administrationMenuItem
            // 
            this.administrationMenuItem.AutoSize = true;
            this.administrationMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.administrationMenuItem.Location = new System.Drawing.Point(543, 2);
            this.administrationMenuItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.administrationMenuItem.MenuItemImage = global::EZKO.Properties.Resources.adminTools_32;
            this.administrationMenuItem.MenuItemText = "Administrácia";
            this.administrationMenuItem.Name = "administrationMenuItem";
            this.administrationMenuItem.OnHoverMenuItemImage = global::EZKO.Properties.Resources.adminTools_active_32;
            this.administrationMenuItem.OnHoverTextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(240)))));
            this.administrationMenuItem.OnLeaveMenuItemImage = global::EZKO.Properties.Resources.adminTools_32;
            this.administrationMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.administrationMenuItem.Size = new System.Drawing.Size(161, 27);
            this.administrationMenuItem.TabIndex = 3;
            this.administrationMenuItem.TextForeColor = System.Drawing.Color.White;
            this.administrationMenuItem.TransparentPanelMouseClick += new System.Windows.Forms.MouseEventHandler(this.administrationMenuItem_TransparentPanelMouseClick);
            this.administrationMenuItem.Load += new System.EventHandler(this.administrationMenuItem_Load);
            // 
            // topMenuPanel
            // 
            this.topMenuPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topMenuPanel.Controls.Add(this.userNameLabel);
            this.topMenuPanel.Controls.Add(this.mainMenuFlowPanel);
            this.topMenuPanel.Controls.Add(this.label1);
            this.topMenuPanel.Controls.Add(this.minimizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.maximizeFormPictureBox);
            this.topMenuPanel.Controls.Add(this.closeFormPictureBox);
            this.topMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(1294, 44);
            this.topMenuPanel.TabIndex = 0;
            this.topMenuPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topMenuPanel_MouseDown);
            // 
            // userNameLabel
            // 
            this.userNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userNameLabel.Location = new System.Drawing.Point(712, 9);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userNameLabel.Size = new System.Drawing.Size(484, 23);
            this.userNameLabel.TabIndex = 4;
            this.userNameLabel.Text = "Prihlásený používateľ:";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1294, 790);
            this.ControlBox = false;
            this.Controls.Add(this.topMenuPanel);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            this.mainMenuFlowPanel.ResumeLayout(false);
            this.mainMenuFlowPanel.PerformLayout();
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox closeFormPictureBox;
        private System.Windows.Forms.PictureBox maximizeFormPictureBox;
        private System.Windows.Forms.PictureBox minimizeFormPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel mainMenuFlowPanel;
        private UserControls.Dashboard.MenuItem ezkoMenuItem;
        private UserControls.Dashboard.MenuItem dashboardMenuItem;
        private UserControls.Dashboard.MenuItem ambulantionMenuItem;
        private UserControls.Dashboard.MenuItem patientsMenuItem;
        private UserControls.Dashboard.MenuItem administrationMenuItem;
        private System.Windows.Forms.Panel topMenuPanel;
        private System.Windows.Forms.Label userNameLabel;
    }
}