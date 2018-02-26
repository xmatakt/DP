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
            this.patientNameLabel = new System.Windows.Forms.Label();
            this.patientLabel = new System.Windows.Forms.Label();
            this.rightBorderPanel = new System.Windows.Forms.Panel();
            this.leftBorderPanel = new System.Windows.Forms.Panel();
            this.bottomBorderPanel = new System.Windows.Forms.Panel();
            this.noteLabel = new System.Windows.Forms.Label();
            this.infrastructureLabel = new System.Windows.Forms.Label();
            this.actionsLabel = new System.Windows.Forms.Label();
            this.plannedActionsPanel = new System.Windows.Forms.Panel();
            this.plannedActionsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.infrastructureFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.infrastructurePanel = new System.Windows.Forms.Panel();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.notePanel = new System.Windows.Forms.Panel();
            this.noteTextLabel = new System.Windows.Forms.Label();
            this.patientIamgePictureBox = new System.Windows.Forms.PictureBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startTextLabel = new System.Windows.Forms.Label();
            this.endTextLabel = new System.Windows.Forms.Label();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.nurseLabel = new System.Windows.Forms.Label();
            this.doctorTextLabel = new System.Windows.Forms.Label();
            this.nurseTextLabel = new System.Windows.Forms.Label();
            this.imageLabel = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            this.plannedActionsPanel.SuspendLayout();
            this.infrastructurePanel.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.notePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientIamgePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.topPanel.Controls.Add(this.imageLabel);
            this.topPanel.Controls.Add(this.patientNameLabel);
            this.topPanel.Controls.Add(this.patientLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(191, 37);
            this.topPanel.TabIndex = 0;
            this.topPanel.Click += new System.EventHandler(this.CalendarEventCard_Click);
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.AutoSize = true;
            this.patientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientNameLabel.Location = new System.Drawing.Point(65, 11);
            this.patientNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new System.Drawing.Size(56, 17);
            this.patientNameLabel.TabIndex = 0;
            this.patientNameLabel.Text = "timusko";
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLabel.Location = new System.Drawing.Point(2, 11);
            this.patientLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(67, 17);
            this.patientLabel.TabIndex = 0;
            this.patientLabel.Text = "Pacient:";
            // 
            // rightBorderPanel
            // 
            this.rightBorderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightBorderPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorderPanel.Location = new System.Drawing.Point(190, 37);
            this.rightBorderPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rightBorderPanel.Name = "rightBorderPanel";
            this.rightBorderPanel.Size = new System.Drawing.Size(1, 163);
            this.rightBorderPanel.TabIndex = 2;
            // 
            // leftBorderPanel
            // 
            this.leftBorderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftBorderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorderPanel.Location = new System.Drawing.Point(0, 37);
            this.leftBorderPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.leftBorderPanel.Name = "leftBorderPanel";
            this.leftBorderPanel.Size = new System.Drawing.Size(1, 163);
            this.leftBorderPanel.TabIndex = 3;
            // 
            // bottomBorderPanel
            // 
            this.bottomBorderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bottomBorderPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBorderPanel.Location = new System.Drawing.Point(1, 199);
            this.bottomBorderPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bottomBorderPanel.Name = "bottomBorderPanel";
            this.bottomBorderPanel.Size = new System.Drawing.Size(189, 1);
            this.bottomBorderPanel.TabIndex = 4;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLabel.Location = new System.Drawing.Point(2, 4);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(84, 16);
            this.noteLabel.TabIndex = 13;
            this.noteLabel.Text = "Poznámka:";
            // 
            // infrastructureLabel
            // 
            this.infrastructureLabel.AutoSize = true;
            this.infrastructureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infrastructureLabel.Location = new System.Drawing.Point(5, 3);
            this.infrastructureLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.infrastructureLabel.Name = "infrastructureLabel";
            this.infrastructureLabel.Size = new System.Drawing.Size(101, 16);
            this.infrastructureLabel.TabIndex = 9;
            this.infrastructureLabel.Text = "Infraštruktúra:";
            // 
            // actionsLabel
            // 
            this.actionsLabel.AutoSize = true;
            this.actionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionsLabel.Location = new System.Drawing.Point(3, 7);
            this.actionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.actionsLabel.Name = "actionsLabel";
            this.actionsLabel.Size = new System.Drawing.Size(139, 16);
            this.actionsLabel.TabIndex = 10;
            this.actionsLabel.Text = "Plánované výkony:";
            // 
            // plannedActionsPanel
            // 
            this.plannedActionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plannedActionsPanel.AutoSize = true;
            this.plannedActionsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plannedActionsPanel.Controls.Add(this.plannedActionsFlowLayoutPanel);
            this.plannedActionsPanel.Controls.Add(this.actionsLabel);
            this.plannedActionsPanel.Location = new System.Drawing.Point(2, 2);
            this.plannedActionsPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plannedActionsPanel.Name = "plannedActionsPanel";
            this.plannedActionsPanel.Size = new System.Drawing.Size(170, 26);
            this.plannedActionsPanel.TabIndex = 15;
            // 
            // plannedActionsFlowLayoutPanel
            // 
            this.plannedActionsFlowLayoutPanel.AutoSize = true;
            this.plannedActionsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plannedActionsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.plannedActionsFlowLayoutPanel.Location = new System.Drawing.Point(5, 24);
            this.plannedActionsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plannedActionsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(0, 49);
            this.plannedActionsFlowLayoutPanel.Name = "plannedActionsFlowLayoutPanel";
            this.plannedActionsFlowLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.plannedActionsFlowLayoutPanel.TabIndex = 11;
            // 
            // infrastructureFlowLayoutPanel
            // 
            this.infrastructureFlowLayoutPanel.AutoSize = true;
            this.infrastructureFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.infrastructureFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.infrastructureFlowLayoutPanel.Location = new System.Drawing.Point(8, 19);
            this.infrastructureFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.infrastructureFlowLayoutPanel.MaximumSize = new System.Drawing.Size(0, 49);
            this.infrastructureFlowLayoutPanel.Name = "infrastructureFlowLayoutPanel";
            this.infrastructureFlowLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.infrastructureFlowLayoutPanel.TabIndex = 16;
            // 
            // infrastructurePanel
            // 
            this.infrastructurePanel.AutoSize = true;
            this.infrastructurePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.infrastructurePanel.Controls.Add(this.infrastructureLabel);
            this.infrastructurePanel.Controls.Add(this.infrastructureFlowLayoutPanel);
            this.infrastructurePanel.Location = new System.Drawing.Point(2, 32);
            this.infrastructurePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.infrastructurePanel.Name = "infrastructurePanel";
            this.infrastructurePanel.Size = new System.Drawing.Size(108, 21);
            this.infrastructurePanel.TabIndex = 17;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.AutoSize = true;
            this.mainTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.notePanel, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.infrastructurePanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.plannedActionsPanel, 0, 0);
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(2, 119);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(174, 79);
            this.mainTableLayoutPanel.TabIndex = 18;
            // 
            // notePanel
            // 
            this.notePanel.AutoSize = true;
            this.notePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.notePanel.Controls.Add(this.noteTextLabel);
            this.notePanel.Controls.Add(this.noteLabel);
            this.notePanel.Location = new System.Drawing.Point(2, 57);
            this.notePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.notePanel.Name = "notePanel";
            this.notePanel.Size = new System.Drawing.Size(170, 20);
            this.notePanel.TabIndex = 19;
            // 
            // noteTextLabel
            // 
            this.noteTextLabel.AutoSize = true;
            this.noteTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTextLabel.Location = new System.Drawing.Point(70, 3);
            this.noteTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noteTextLabel.Name = "noteTextLabel";
            this.noteTextLabel.Size = new System.Drawing.Size(98, 17);
            this.noteTextLabel.TabIndex = 14;
            this.noteTextLabel.Text = "noteTextLabel";
            // 
            // patientIamgePictureBox
            // 
            this.patientIamgePictureBox.Location = new System.Drawing.Point(8, 41);
            this.patientIamgePictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.patientIamgePictureBox.Name = "patientIamgePictureBox";
            this.patientIamgePictureBox.Size = new System.Drawing.Size(73, 73);
            this.patientIamgePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.patientIamgePictureBox.TabIndex = 6;
            this.patientIamgePictureBox.TabStop = false;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(85, 41);
            this.startLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(72, 16);
            this.startLabel.TabIndex = 19;
            this.startLabel.Text = "Začiatok:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Koniec:";
            // 
            // startTextLabel
            // 
            this.startTextLabel.AutoSize = true;
            this.startTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTextLabel.Location = new System.Drawing.Point(143, 41);
            this.startTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startTextLabel.Name = "startTextLabel";
            this.startTextLabel.Size = new System.Drawing.Size(46, 17);
            this.startTextLabel.TabIndex = 20;
            this.startTextLabel.Text = "label2";
            // 
            // endTextLabel
            // 
            this.endTextLabel.AutoSize = true;
            this.endTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTextLabel.Location = new System.Drawing.Point(143, 61);
            this.endTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.endTextLabel.Name = "endTextLabel";
            this.endTextLabel.Size = new System.Drawing.Size(46, 17);
            this.endTextLabel.TabIndex = 20;
            this.endTextLabel.Text = "label2";
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorLabel.Location = new System.Drawing.Point(85, 81);
            this.doctorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(51, 16);
            this.doctorLabel.TabIndex = 19;
            this.doctorLabel.Text = "Lekár:";
            // 
            // nurseLabel
            // 
            this.nurseLabel.AutoSize = true;
            this.nurseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nurseLabel.Location = new System.Drawing.Point(85, 102);
            this.nurseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nurseLabel.Name = "nurseLabel";
            this.nurseLabel.Size = new System.Drawing.Size(57, 16);
            this.nurseLabel.TabIndex = 19;
            this.nurseLabel.Text = "Sestra:";
            // 
            // doctorTextLabel
            // 
            this.doctorTextLabel.AutoSize = true;
            this.doctorTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorTextLabel.Location = new System.Drawing.Point(143, 80);
            this.doctorTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doctorTextLabel.Name = "doctorTextLabel";
            this.doctorTextLabel.Size = new System.Drawing.Size(46, 17);
            this.doctorTextLabel.TabIndex = 20;
            this.doctorTextLabel.Text = "label2";
            // 
            // nurseTextLabel
            // 
            this.nurseTextLabel.AutoSize = true;
            this.nurseTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nurseTextLabel.Location = new System.Drawing.Point(143, 101);
            this.nurseTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nurseTextLabel.Name = "nurseTextLabel";
            this.nurseTextLabel.Size = new System.Drawing.Size(46, 17);
            this.nurseTextLabel.TabIndex = 20;
            this.nurseTextLabel.Text = "label2";
            // 
            // imageLabel
            // 
            this.imageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageLabel.BackgroundImage = global::EZKO.Properties.Resources.euro_sign2_black_16;
            this.imageLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageLabel.Location = new System.Drawing.Point(160, 11);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(16, 16);
            this.imageLabel.TabIndex = 1;
            this.imageLabel.TabStop = false;
            // 
            // CalendarEventCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.nurseTextLabel);
            this.Controls.Add(this.doctorTextLabel);
            this.Controls.Add(this.endTextLabel);
            this.Controls.Add(this.startTextLabel);
            this.Controls.Add(this.nurseLabel);
            this.Controls.Add(this.doctorLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.patientIamgePictureBox);
            this.Controls.Add(this.bottomBorderPanel);
            this.Controls.Add(this.leftBorderPanel);
            this.Controls.Add(this.rightBorderPanel);
            this.Controls.Add(this.topPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CalendarEventCard";
            this.Size = new System.Drawing.Size(191, 200);
            this.Click += new System.EventHandler(this.CalendarEventCard_Click);
            this.Resize += new System.EventHandler(this.CalendarEventCard_Resize);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.plannedActionsPanel.ResumeLayout(false);
            this.plannedActionsPanel.PerformLayout();
            this.infrastructurePanel.ResumeLayout(false);
            this.infrastructurePanel.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.notePanel.ResumeLayout(false);
            this.notePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientIamgePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Panel rightBorderPanel;
        private System.Windows.Forms.Panel leftBorderPanel;
        private System.Windows.Forms.Panel bottomBorderPanel;
        private System.Windows.Forms.Label actionsLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label infrastructureLabel;
        private System.Windows.Forms.Panel plannedActionsPanel;
        private System.Windows.Forms.FlowLayoutPanel plannedActionsFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel infrastructureFlowLayoutPanel;
        private System.Windows.Forms.Panel infrastructurePanel;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel notePanel;
        private System.Windows.Forms.PictureBox patientIamgePictureBox;
        private System.Windows.Forms.Label noteTextLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label startTextLabel;
        private System.Windows.Forms.Label endTextLabel;
        private System.Windows.Forms.Label doctorLabel;
        private System.Windows.Forms.Label nurseLabel;
        private System.Windows.Forms.Label doctorTextLabel;
        private System.Windows.Forms.Label nurseTextLabel;
        private System.Windows.Forms.PictureBox imageLabel;
    }
}
