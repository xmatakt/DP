namespace EZKO.UserControls.Dashboard
{
    partial class MenuItem
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
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.menuItemPictureBox = new System.Windows.Forms.PictureBox();
            this.transparentPanel = new EZKO.UserControls.Other.TransparentPanel();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.White;
            this.descriptionLabel.Location = new System.Drawing.Point(41, 10);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.descriptionLabel.Size = new System.Drawing.Size(99, 29);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "label1";
            // 
            // menuItemPictureBox
            // 
            this.menuItemPictureBox.Image = global::EZKO.Properties.Resources.closeForm_32;
            this.menuItemPictureBox.Location = new System.Drawing.Point(3, 10);
            this.menuItemPictureBox.Name = "menuItemPictureBox";
            this.menuItemPictureBox.Size = new System.Drawing.Size(32, 29);
            this.menuItemPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuItemPictureBox.TabIndex = 1;
            this.menuItemPictureBox.TabStop = false;
            // 
            // transparentPanel
            // 
            this.transparentPanel.AutoSize = true;
            this.transparentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentPanel.Location = new System.Drawing.Point(0, 0);
            this.transparentPanel.Name = "transparentPanel";
            this.transparentPanel.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.transparentPanel.Size = new System.Drawing.Size(143, 47);
            this.transparentPanel.TabIndex = 2;
            this.transparentPanel.MouseLeave += new System.EventHandler(this.MenuItem_MouseLeave);
            this.transparentPanel.MouseHover += new System.EventHandler(this.MenuItem_MouseHover);
            // 
            // MenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.transparentPanel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.menuItemPictureBox);
            this.Name = "MenuItem";
            this.Size = new System.Drawing.Size(143, 47);
            ((System.ComponentModel.ISupportInitialize)(this.menuItemPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.PictureBox menuItemPictureBox;
        private Other.TransparentPanel transparentPanel;
    }
}
