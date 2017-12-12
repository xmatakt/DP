namespace EZKO.UserControls.Ambulantion
{
    partial class CalendarEventCard
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
            this.patientLabel = new System.Windows.Forms.Label();
            this.patientNameLabel = new System.Windows.Forms.Label();
            this.patientIamgePictureBox = new System.Windows.Forms.PictureBox();
            this.rightBorderPanel = new System.Windows.Forms.Panel();
            this.leftBorderPanel = new System.Windows.Forms.Panel();
            this.bottomBorderPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientIamgePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.topPanel.Controls.Add(this.patientNameLabel);
            this.topPanel.Controls.Add(this.patientLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(521, 45);
            this.topPanel.TabIndex = 0;
            this.topPanel.Click += new System.EventHandler(this.CalendarEventCard_Click);
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLabel.Location = new System.Drawing.Point(3, 14);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(78, 20);
            this.patientLabel.TabIndex = 0;
            this.patientLabel.Text = "Pacient:";
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.AutoSize = true;
            this.patientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientNameLabel.Location = new System.Drawing.Point(87, 14);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new System.Drawing.Size(67, 20);
            this.patientNameLabel.TabIndex = 0;
            this.patientNameLabel.Text = "timusko";
            // 
            // patientIamgePictureBox
            // 
            this.patientIamgePictureBox.Location = new System.Drawing.Point(18, 60);
            this.patientIamgePictureBox.Name = "patientIamgePictureBox";
            this.patientIamgePictureBox.Size = new System.Drawing.Size(97, 90);
            this.patientIamgePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.patientIamgePictureBox.TabIndex = 1;
            this.patientIamgePictureBox.TabStop = false;
            // 
            // rightBorderPanel
            // 
            this.rightBorderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightBorderPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorderPanel.Location = new System.Drawing.Point(520, 45);
            this.rightBorderPanel.Name = "rightBorderPanel";
            this.rightBorderPanel.Size = new System.Drawing.Size(1, 261);
            this.rightBorderPanel.TabIndex = 2;
            // 
            // leftBorderPanel
            // 
            this.leftBorderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftBorderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorderPanel.Location = new System.Drawing.Point(0, 45);
            this.leftBorderPanel.Name = "leftBorderPanel";
            this.leftBorderPanel.Size = new System.Drawing.Size(1, 261);
            this.leftBorderPanel.TabIndex = 3;
            // 
            // bottomBorderPanel
            // 
            this.bottomBorderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bottomBorderPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBorderPanel.Location = new System.Drawing.Point(1, 305);
            this.bottomBorderPanel.Name = "bottomBorderPanel";
            this.bottomBorderPanel.Size = new System.Drawing.Size(519, 1);
            this.bottomBorderPanel.TabIndex = 4;
            // 
            // CalendarEventCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomBorderPanel);
            this.Controls.Add(this.leftBorderPanel);
            this.Controls.Add(this.rightBorderPanel);
            this.Controls.Add(this.patientIamgePictureBox);
            this.Controls.Add(this.topPanel);
            this.Name = "CalendarEventCard";
            this.Size = new System.Drawing.Size(521, 306);
            this.Click += new System.EventHandler(this.CalendarEventCard_Click);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientIamgePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox patientIamgePictureBox;
        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Panel rightBorderPanel;
        private System.Windows.Forms.Panel leftBorderPanel;
        private System.Windows.Forms.Panel bottomBorderPanel;
    }
}
