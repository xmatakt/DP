namespace EZKO.UserControls.Dashboard
{
    partial class FindEventUserControl
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
            this.doctorScheduleLabel = new System.Windows.Forms.Label();
            this.pickedDateTimeLabel = new System.Windows.Forms.Label();
            this.searchInEventsTextBox = new System.Windows.Forms.TextBox();
            this.searchInEventsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.SuspendLayout();
            // 
            // doctorScheduleLabel
            // 
            this.doctorScheduleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.doctorScheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorScheduleLabel.Location = new System.Drawing.Point(0, 0);
            this.doctorScheduleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doctorScheduleLabel.Name = "doctorScheduleLabel";
            this.doctorScheduleLabel.Size = new System.Drawing.Size(387, 26);
            this.doctorScheduleLabel.TabIndex = 0;
            this.doctorScheduleLabel.Text = "label1";
            // 
            // pickedDateTimeLabel
            // 
            this.pickedDateTimeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickedDateTimeLabel.Location = new System.Drawing.Point(0, 26);
            this.pickedDateTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pickedDateTimeLabel.Name = "pickedDateTimeLabel";
            this.pickedDateTimeLabel.Size = new System.Drawing.Size(387, 13);
            this.pickedDateTimeLabel.TabIndex = 1;
            this.pickedDateTimeLabel.Text = "label1";
            // 
            // searchInEventsTextBox
            // 
            this.searchInEventsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchInEventsTextBox.Location = new System.Drawing.Point(59, 50);
            this.searchInEventsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchInEventsTextBox.Name = "searchInEventsTextBox";
            this.searchInEventsTextBox.Size = new System.Drawing.Size(308, 20);
            this.searchInEventsTextBox.TabIndex = 2;
            // 
            // searchInEventsButton
            // 
            this.searchInEventsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.searchInEventsButton.BackgroundImage = global::EZKO.Properties.Resources.search_16;
            this.searchInEventsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchInEventsButton.FlatAppearance.BorderSize = 0;
            this.searchInEventsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.searchInEventsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(113)))), ((int)(((byte)(169)))));
            this.searchInEventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchInEventsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.searchInEventsButton.ForeColor = System.Drawing.Color.White;
            this.searchInEventsButton.Location = new System.Drawing.Point(10, 49);
            this.searchInEventsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchInEventsButton.Name = "searchInEventsButton";
            this.searchInEventsButton.Radius = 5;
            this.searchInEventsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.searchInEventsButton.Size = new System.Drawing.Size(45, 21);
            this.searchInEventsButton.TabIndex = 3;
            this.searchInEventsButton.UseVisualStyleBackColor = false;
            // 
            // FindEventUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.searchInEventsButton);
            this.Controls.Add(this.searchInEventsTextBox);
            this.Controls.Add(this.pickedDateTimeLabel);
            this.Controls.Add(this.doctorScheduleLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FindEventUserControl";
            this.Size = new System.Drawing.Size(387, 72);
            this.Load += new System.EventHandler(this.FindEventUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label doctorScheduleLabel;
        private System.Windows.Forms.Label pickedDateTimeLabel;
        private System.Windows.Forms.TextBox searchInEventsTextBox;
        private FlatControls.RoundButton searchInEventsButton;
    }
}
