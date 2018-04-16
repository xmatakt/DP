namespace EZKO.Forms
{
    partial class DateTimePickerForm
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.hourNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hourNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(9, 10);
            this.datePicker.Margin = new System.Windows.Forms.Padding(2);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(151, 20);
            this.datePicker.TabIndex = 0;
            // 
            // hourNumericUpDown
            // 
            this.hourNumericUpDown.Location = new System.Drawing.Point(164, 10);
            this.hourNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.hourNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hourNumericUpDown.Name = "hourNumericUpDown";
            this.hourNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.hourNumericUpDown.TabIndex = 1;
            // 
            // minuteNumericUpDown
            // 
            this.minuteNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minuteNumericUpDown.Location = new System.Drawing.Point(211, 10);
            this.minuteNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.minuteNumericUpDown.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.minuteNumericUpDown.Name = "minuteNumericUpDown";
            this.minuteNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.minuteNumericUpDown.TabIndex = 2;
            this.minuteNumericUpDown.ValueChanged += new System.EventHandler(this.minuteNumericUpDown_ValueChanged);
            this.minuteNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.minuteNumericUpDown_KeyUp);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.ForeColor = System.Drawing.Color.Red;
            this.infoLabel.Location = new System.Drawing.Point(98, 30);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(162, 13);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "Číslo musí byť násobkom čísla 5";
            // 
            // DateTimePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(266, 44);
            this.ControlBox = false;
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.minuteNumericUpDown);
            this.Controls.Add(this.hourNumericUpDown);
            this.Controls.Add(this.datePicker);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(282, 60);
            this.MinimumSize = new System.Drawing.Size(282, 60);
            this.Name = "DateTimePickerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DateTimePickerForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTimePickerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.hourNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.NumericUpDown hourNumericUpDown;
        private System.Windows.Forms.NumericUpDown minuteNumericUpDown;
        private System.Windows.Forms.Label infoLabel;
    }
}