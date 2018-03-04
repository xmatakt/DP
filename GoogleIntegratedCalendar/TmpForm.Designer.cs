namespace EZKO
{
    partial class TmpForm
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
            this.formEditorControl1 = new EZKO.UserControls.Formulars.FormEditorControl();
            this.SuspendLayout();
            // 
            // formEditorControl1
            // 
            this.formEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.formEditorControl1.Name = "formEditorControl1";
            this.formEditorControl1.Size = new System.Drawing.Size(874, 736);
            this.formEditorControl1.TabIndex = 0;
            // 
            // TmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(874, 736);
            this.Controls.Add(this.formEditorControl1);
            this.Name = "TmpForm";
            this.Text = "TmpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Formulars.FormEditorControl formEditorControl1;
    }
}