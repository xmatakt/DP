namespace EZKO.UserControls.Ambulantion
{
    partial class FilterEventUserControl
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.nurseLabel = new System.Windows.Forms.Label();
            this.infrastructureLabel = new System.Windows.Forms.Label();
            this.doctorComboBox = new System.Windows.Forms.ComboBox();
            this.nurseComboBox = new System.Windows.Forms.ComboBox();
            this.infrastructureComboBox = new System.Windows.Forms.ComboBox();
            this.searchInEventsButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(671, 32);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "label1";
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorLabel.Location = new System.Drawing.Point(80, 50);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(54, 16);
            this.doctorLabel.TabIndex = 6;
            this.doctorLabel.Text = "Doktor";
            // 
            // nurseLabel
            // 
            this.nurseLabel.AutoSize = true;
            this.nurseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nurseLabel.Location = new System.Drawing.Point(283, 50);
            this.nurseLabel.Name = "nurseLabel";
            this.nurseLabel.Size = new System.Drawing.Size(53, 16);
            this.nurseLabel.TabIndex = 6;
            this.nurseLabel.Text = "Sestra";
            // 
            // infrastructureLabel
            // 
            this.infrastructureLabel.AutoSize = true;
            this.infrastructureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infrastructureLabel.Location = new System.Drawing.Point(488, 50);
            this.infrastructureLabel.Name = "infrastructureLabel";
            this.infrastructureLabel.Size = new System.Drawing.Size(97, 16);
            this.infrastructureLabel.TabIndex = 6;
            this.infrastructureLabel.Text = "Infraštruktúra";
            // 
            // doctorComboBox
            // 
            this.doctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorComboBox.FormattingEnabled = true;
            this.doctorComboBox.Location = new System.Drawing.Point(80, 74);
            this.doctorComboBox.Name = "doctorComboBox";
            this.doctorComboBox.Size = new System.Drawing.Size(177, 24);
            this.doctorComboBox.TabIndex = 7;
            // 
            // nurseComboBox
            // 
            this.nurseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nurseComboBox.FormattingEnabled = true;
            this.nurseComboBox.Location = new System.Drawing.Point(286, 74);
            this.nurseComboBox.Name = "nurseComboBox";
            this.nurseComboBox.Size = new System.Drawing.Size(177, 24);
            this.nurseComboBox.TabIndex = 7;
            // 
            // infrastructureComboBox
            // 
            this.infrastructureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.infrastructureComboBox.FormattingEnabled = true;
            this.infrastructureComboBox.Location = new System.Drawing.Point(491, 74);
            this.infrastructureComboBox.Name = "infrastructureComboBox";
            this.infrastructureComboBox.Size = new System.Drawing.Size(177, 24);
            this.infrastructureComboBox.TabIndex = 7;
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
            this.searchInEventsButton.Location = new System.Drawing.Point(5, 74);
            this.searchInEventsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchInEventsButton.Name = "searchInEventsButton";
            this.searchInEventsButton.Radius = 5;
            this.searchInEventsButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatBlue;
            this.searchInEventsButton.Size = new System.Drawing.Size(69, 24);
            this.searchInEventsButton.TabIndex = 5;
            this.searchInEventsButton.UseVisualStyleBackColor = false;
            this.searchInEventsButton.Click += new System.EventHandler(this.searchInEventsButton_Click);
            // 
            // FilterEventUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.infrastructureComboBox);
            this.Controls.Add(this.nurseComboBox);
            this.Controls.Add(this.doctorComboBox);
            this.Controls.Add(this.infrastructureLabel);
            this.Controls.Add(this.nurseLabel);
            this.Controls.Add(this.doctorLabel);
            this.Controls.Add(this.searchInEventsButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "FilterEventUserControl";
            this.Size = new System.Drawing.Size(671, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatControls.RoundButton searchInEventsButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label doctorLabel;
        private System.Windows.Forms.Label nurseLabel;
        private System.Windows.Forms.Label infrastructureLabel;
        private System.Windows.Forms.ComboBox doctorComboBox;
        private System.Windows.Forms.ComboBox nurseComboBox;
        private System.Windows.Forms.ComboBox infrastructureComboBox;
    }
}
