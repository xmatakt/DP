namespace EZKO.UserControls.Formulars
{
    partial class FormEditorControl
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
            this.formNameLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.showToolsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.showToolsButton);
            this.topPanel.Controls.Add(this.formNameLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(543, 34);
            this.topPanel.TabIndex = 0;
            // 
            // formNameLabel
            // 
            this.formNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formNameLabel.Location = new System.Drawing.Point(0, 0);
            this.formNameLabel.Name = "formNameLabel";
            this.formNameLabel.Size = new System.Drawing.Size(543, 34);
            this.formNameLabel.TabIndex = 0;
            this.formNameLabel.Text = "Názov formulára";
            this.formNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.AutoSize = true;
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 34);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(543, 228);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Resize += new System.EventHandler(this.mainPanel_Resize);
            // 
            // showToolsButton
            // 
            this.showToolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showToolsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showToolsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.showToolsButton.BackgroundImage = global::EZKO.Properties.Resources.hide_black_16;
            this.showToolsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.showToolsButton.FlatAppearance.BorderSize = 0;
            this.showToolsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.showToolsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.showToolsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showToolsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.showToolsButton.ForeColor = System.Drawing.Color.White;
            this.showToolsButton.Location = new System.Drawing.Point(492, 5);
            this.showToolsButton.Name = "showToolsButton";
            this.showToolsButton.Radius = 5;
            this.showToolsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.showToolsButton.Size = new System.Drawing.Size(29, 23);
            this.showToolsButton.TabIndex = 1;
            this.showToolsButton.UseVisualStyleBackColor = false;
            this.showToolsButton.Click += new System.EventHandler(this.showToolsButton_Click);
            // 
            // FormEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "FormEditorControl";
            this.Size = new System.Drawing.Size(543, 262);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formNameLabel;
        private System.Windows.Forms.Panel mainPanel;
        private FlatControls.RoundButton showToolsButton;
    }
}
