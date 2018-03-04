namespace EZKO.UserControls.Formulars
{
    partial class FormFieldCard
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
            this.mainFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.removeButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.downButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.upButton = new EZKO.UserControls.FlatControls.RoundButton();
            this.mainFlowPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFlowPanel
            // 
            this.mainFlowPanel.AutoSize = true;
            this.mainFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainFlowPanel.BackColor = System.Drawing.SystemColors.Info;
            this.mainFlowPanel.Controls.Add(this.topPanel);
            this.mainFlowPanel.Controls.Add(this.questionTextBox);
            this.mainFlowPanel.Controls.Add(this.flowPanel);
            this.mainFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFlowPanel.Name = "mainFlowPanel";
            this.mainFlowPanel.Size = new System.Drawing.Size(485, 68);
            this.mainFlowPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.topPanel.Controls.Add(this.removeButton);
            this.topPanel.Controls.Add(this.downButton);
            this.topPanel.Controls.Add(this.upButton);
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(479, 29);
            this.topPanel.TabIndex = 5;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseEnter += new System.EventHandler(this.topPanel_MouseEnter);
            this.topPanel.MouseLeave += new System.EventHandler(this.topPanel_MouseLeave);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // questionTextBox
            // 
            this.questionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionTextBox.Location = new System.Drawing.Point(3, 38);
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(479, 20);
            this.questionTextBox.TabIndex = 3;
            this.questionTextBox.Text = "Otázka do formulára";
            this.questionTextBox.Enter += new System.EventHandler(this.questionTextBox_Enter);
            this.questionTextBox.Leave += new System.EventHandler(this.questionTextBox_Leave);
            // 
            // flowPanel
            // 
            this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.AutoSize = true;
            this.flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(3, 64);
            this.flowPanel.MinimumSize = new System.Drawing.Size(479, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(479, 0);
            this.flowPanel.TabIndex = 4;
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.removeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.removeButton.ForeColor = System.Drawing.Color.White;
            this.removeButton.Location = new System.Drawing.Point(3, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Radius = 5;
            this.removeButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatRed;
            this.removeButton.Size = new System.Drawing.Size(29, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "X";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.downButton.BackgroundImage = global::EZKO.Properties.Resources.down_arrow_16;
            this.downButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.downButton.FlatAppearance.BorderSize = 0;
            this.downButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.downButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.downButton.ForeColor = System.Drawing.Color.White;
            this.downButton.Location = new System.Drawing.Point(447, 2);
            this.downButton.Name = "downButton";
            this.downButton.Radius = 5;
            this.downButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.downButton.Size = new System.Drawing.Size(29, 23);
            this.downButton.TabIndex = 1;
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.upButton.BackgroundImage = global::EZKO.Properties.Resources.up_arrow_16;
            this.upButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.upButton.FlatAppearance.BorderSize = 0;
            this.upButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.upButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(157)))), ((int)(((byte)(68)))));
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.upButton.ForeColor = System.Drawing.Color.White;
            this.upButton.Location = new System.Drawing.Point(415, 2);
            this.upButton.Name = "upButton";
            this.upButton.Radius = 5;
            this.upButton.RoundButtonStyle = EZKO.UserControls.RoundButtonStylesEnum.FlatGreen;
            this.upButton.Size = new System.Drawing.Size(29, 23);
            this.upButton.TabIndex = 1;
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // FormFieldCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.mainFlowPanel);
            this.MinimumSize = new System.Drawing.Size(2, 70);
            this.Name = "FormFieldCard";
            this.Size = new System.Drawing.Size(485, 68);
            this.SizeChanged += new System.EventHandler(this.FormFieldCard_SizeChanged);
            this.Enter += new System.EventHandler(this.FormFieldCard_Enter);
            this.Leave += new System.EventHandler(this.FormFieldCard_Leave);
            this.mainFlowPanel.ResumeLayout(false);
            this.mainFlowPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlowPanel;
        private System.Windows.Forms.Panel topPanel;
        private FlatControls.RoundButton removeButton;
        private FlatControls.RoundButton downButton;
        private FlatControls.RoundButton upButton;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
    }
}
