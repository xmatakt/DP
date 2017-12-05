namespace EZKO.UserControls.Administration
{
    partial class AdminMenuItem
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
            this.components = new System.ComponentModel.Container();
            this.descriptionLabelPanel = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.showListButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.addButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.menuItemPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.descriptionLabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabelPanel
            // 
            this.descriptionLabelPanel.AutoSize = true;
            this.descriptionLabelPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.descriptionLabelPanel.Controls.Add(this.descriptionLabel);
            this.descriptionLabelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabelPanel.Location = new System.Drawing.Point(42, 0);
            this.descriptionLabelPanel.Name = "descriptionLabelPanel";
            this.descriptionLabelPanel.Size = new System.Drawing.Size(183, 43);
            this.descriptionLabelPanel.TabIndex = 4;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.White;
            this.descriptionLabel.Location = new System.Drawing.Point(7, 4);
            this.descriptionLabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Padding = new System.Windows.Forms.Padding(5);
            this.descriptionLabel.Size = new System.Drawing.Size(173, 39);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Anamnesticke";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.descriptionLabel, "TOOLTIP");
            // 
            // showListButton
            // 
            this.showListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.showListButton.BackgroundImage = global::EZKO.Properties.Resources.list_white_16;
            this.showListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.showListButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.showListButton.FlatAppearance.BorderSize = 0;
            this.showListButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.showListButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.showListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.showListButton.ForeColor = System.Drawing.Color.White;
            this.showListButton.Location = new System.Drawing.Point(225, 0);
            this.showListButton.Name = "showListButton";
            this.showListButton.Padding = new System.Windows.Forms.Padding(5);
            this.showListButton.Radius = 7;
            this.showListButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatRed;
            this.showListButton.Size = new System.Drawing.Size(58, 43);
            this.showListButton.TabIndex = 3;
            this.showListButton.UseVisualStyleBackColor = false;
            this.showListButton.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            this.showListButton.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.addButton.BackgroundImage = global::EZKO.Properties.Resources.add_white_16;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(283, 0);
            this.addButton.Name = "addButton";
            this.addButton.Padding = new System.Windows.Forms.Padding(5);
            this.addButton.Radius = 7;
            this.addButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.addButton.Size = new System.Drawing.Size(58, 43);
            this.addButton.TabIndex = 2;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.addButton.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            this.addButton.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
            // 
            // menuItemPictureBox
            // 
            this.menuItemPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuItemPictureBox.Image = global::EZKO.Properties.Resources.people_32;
            this.menuItemPictureBox.Location = new System.Drawing.Point(0, 0);
            this.menuItemPictureBox.Name = "menuItemPictureBox";
            this.menuItemPictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.menuItemPictureBox.Size = new System.Drawing.Size(42, 43);
            this.menuItemPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.menuItemPictureBox.TabIndex = 0;
            this.menuItemPictureBox.TabStop = false;
            // 
            // AdminMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.descriptionLabelPanel);
            this.Controls.Add(this.showListButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.menuItemPictureBox);
            this.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Name = "AdminMenuItem";
            this.Size = new System.Drawing.Size(341, 43);
            this.descriptionLabelPanel.ResumeLayout(false);
            this.descriptionLabelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox menuItemPictureBox;
        private FlatControls.RoundButton addButton;
        private FlatControls.RoundButton showListButton;
        private System.Windows.Forms.Panel descriptionLabelPanel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
