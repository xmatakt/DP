﻿namespace EZKO.UserControls.FlatControls
{
    partial class FlatRichTextBox
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
            this.flatRtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // flatRtb
            // 
            this.flatRtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flatRtb.Location = new System.Drawing.Point(0, 0);
            this.flatRtb.Name = "flatRtb";
            this.flatRtb.Size = new System.Drawing.Size(291, 26);
            this.flatRtb.TabIndex = 0;
            this.flatRtb.Text = "";
            this.flatRtb.Enter += new System.EventHandler(this.flatRtb_Enter);
            this.flatRtb.Leave += new System.EventHandler(this.flatRtb_Leave);
            this.flatRtb.MouseEnter += new System.EventHandler(this.flatRtb_MouseEnter);
            this.flatRtb.MouseLeave += new System.EventHandler(this.flatRtb_MouseLeave);
            // 
            // FlatRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flatRtb);
            this.Name = "FlatRichTextBox";
            this.Size = new System.Drawing.Size(291, 53);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlatRichTextBox_Paint);
            this.Resize += new System.EventHandler(this.FlatRichTextBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox flatRtb;
    }
}
