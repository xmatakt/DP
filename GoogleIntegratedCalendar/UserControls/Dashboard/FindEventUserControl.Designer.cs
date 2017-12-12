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
            this.searchInEventsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.searchInEventsTextBox = new EZKO.UserControls.Other.AutoCompleteTextBox();
            this.SuspendLayout();
            // 
            // doctorScheduleLabel
            // 
            this.doctorScheduleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.doctorScheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorScheduleLabel.Location = new System.Drawing.Point(0, 0);
            this.doctorScheduleLabel.Name = "doctorScheduleLabel";
            this.doctorScheduleLabel.Size = new System.Drawing.Size(296, 32);
            this.doctorScheduleLabel.TabIndex = 0;
            this.doctorScheduleLabel.Text = "label1";
            // 
            // pickedDateTimeLabel
            // 
            this.pickedDateTimeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickedDateTimeLabel.Location = new System.Drawing.Point(0, 32);
            this.pickedDateTimeLabel.Name = "pickedDateTimeLabel";
            this.pickedDateTimeLabel.Size = new System.Drawing.Size(296, 16);
            this.pickedDateTimeLabel.TabIndex = 1;
            this.pickedDateTimeLabel.Text = "label1";
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
            this.searchInEventsButton.Location = new System.Drawing.Point(13, 60);
            this.searchInEventsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchInEventsButton.Name = "searchInEventsButton";
            this.searchInEventsButton.Radius = 5;
            this.searchInEventsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.searchInEventsButton.Size = new System.Drawing.Size(60, 26);
            this.searchInEventsButton.TabIndex = 3;
            this.searchInEventsButton.UseVisualStyleBackColor = false;
            // 
            // searchInEventsTextBox
            // 
            this.searchInEventsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchInEventsTextBox.Location = new System.Drawing.Point(79, 62);
            this.searchInEventsTextBox.Name = "searchInEventsTextBox";
            this.searchInEventsTextBox.Size = new System.Drawing.Size(190, 22);
            this.searchInEventsTextBox.TabIndex = 4;
            this.searchInEventsTextBox.Values = null;
            this.searchInEventsTextBox.TextChanged += new System.EventHandler(this.searchInEventsTextBox_TextChanged);
            // 
            // FindEventUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.searchInEventsTextBox);
            this.Controls.Add(this.searchInEventsButton);
            this.Controls.Add(this.pickedDateTimeLabel);
            this.Controls.Add(this.doctorScheduleLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FindEventUserControl";
            this.Size = new System.Drawing.Size(296, 88);
            this.Load += new System.EventHandler(this.FindEventUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label doctorScheduleLabel;
        private System.Windows.Forms.Label pickedDateTimeLabel;
        private FlatControls.RoundButton searchInEventsButton;
        private Other.AutoCompleteTextBox searchInEventsTextBox;
    }
}
