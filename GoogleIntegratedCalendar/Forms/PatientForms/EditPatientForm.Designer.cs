namespace EZKO.Forms.AdministrationForms
{
    partial class EditPatientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPatientForm));
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.minimizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.maximizeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.closeFormPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.personalInformationTabPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.changeAvatarButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.roundButton1 = new EZKO.UserControls.FlatControls.RoundButton();
            this.topMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).BeginInit();
            this.bottomFlowPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.personalInformationTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
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
            this.topMenuPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(984, 36);
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
            this.formTitleLabel.Size = new System.Drawing.Size(131, 20);
            this.formTitleLabel.TabIndex = 5;
            this.formTitleLabel.Text = "Editácia pacienta";
            // 
            // minimizeFormPictureBox
            // 
            this.minimizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeFormPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("minimizeFormPictureBox.Image")));
            this.minimizeFormPictureBox.Location = new System.Drawing.Point(908, 8);
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
            // maximizeFormPictureBox
            // 
            this.maximizeFormPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeFormPictureBox.Image = global::EZKO.Properties.Resources.maximizeForm_32;
            this.maximizeFormPictureBox.Location = new System.Drawing.Point(932, 8);
            this.maximizeFormPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.closeFormPictureBox.Location = new System.Drawing.Point(956, 8);
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
            this.bottomFlowPanel.Location = new System.Drawing.Point(0, 508);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.bottomFlowPanel.Size = new System.Drawing.Size(984, 36);
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
            this.cancelButton.Location = new System.Drawing.Point(926, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.addButton.Location = new System.Drawing.Point(872, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addButton.Name = "addButton";
            this.addButton.Radius = 5;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.addButton.Size = new System.Drawing.Size(50, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Uložiť";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.personalInformationTabPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 36);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 472);
            this.tabControl.TabIndex = 2;
            // 
            // personalInformationTabPage
            // 
            this.personalInformationTabPage.Controls.Add(this.roundButton1);
            this.personalInformationTabPage.Controls.Add(this.idTextBox);
            this.personalInformationTabPage.Controls.Add(this.idLabel);
            this.personalInformationTabPage.Controls.Add(this.changeAvatarButton);
            this.personalInformationTabPage.Controls.Add(this.avatarPictureBox);
            this.personalInformationTabPage.Location = new System.Drawing.Point(4, 22);
            this.personalInformationTabPage.Name = "personalInformationTabPage";
            this.personalInformationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.personalInformationTabPage.Size = new System.Drawing.Size(976, 446);
            this.personalInformationTabPage.TabIndex = 0;
            this.personalInformationTabPage.Text = "Osobné údaje";
            this.personalInformationTabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Location = new System.Drawing.Point(9, 7);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(166, 162);
            this.avatarPictureBox.TabIndex = 0;
            this.avatarPictureBox.TabStop = false;
            // 
            // changeAvatarButton
            // 
            this.changeAvatarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.changeAvatarButton.FlatAppearance.BorderSize = 0;
            this.changeAvatarButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.changeAvatarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.changeAvatarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeAvatarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.changeAvatarButton.ForeColor = System.Drawing.Color.White;
            this.changeAvatarButton.Location = new System.Drawing.Point(9, 176);
            this.changeAvatarButton.Name = "changeAvatarButton";
            this.changeAvatarButton.Radius = 5;
            this.changeAvatarButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.changeAvatarButton.Size = new System.Drawing.Size(166, 23);
            this.changeAvatarButton.TabIndex = 1;
            this.changeAvatarButton.Text = "Zmeniť";
            this.changeAvatarButton.UseVisualStyleBackColor = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(9, 217);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(24, 13);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "ID:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(75, 214);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 3;
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.roundButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.roundButton1.ForeColor = System.Drawing.Color.White;
            this.roundButton1.Location = new System.Drawing.Point(12, 417);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Radius = 5;
            this.roundButton1.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.roundButton1.Size = new System.Drawing.Size(163, 23);
            this.roundButton1.TabIndex = 4;
            this.roundButton1.Text = "Generovať PDF";
            this.roundButton1.UseVisualStyleBackColor = false;
            // 
            // EditPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 544);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.topMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditPatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.topMenuPanel.ResumeLayout(false);
            this.topMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeFormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeFormPictureBox)).EndInit();
            this.bottomFlowPanel.ResumeLayout(false);
            this.bottomFlowPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.personalInformationTabPage.ResumeLayout(false);
            this.personalInformationTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage personalInformationTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private UserControls.FlatControls.RoundButton changeAvatarButton;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label idLabel;
        private UserControls.FlatControls.RoundButton roundButton1;
    }
}