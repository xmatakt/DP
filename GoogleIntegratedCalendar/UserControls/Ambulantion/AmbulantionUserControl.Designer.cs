namespace EZKO.UserControls.Ambulantion
{
    partial class AmbulantionUserControl
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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.middleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.eventsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.filterEventUserControl = new EZKO.UserControls.Ambulantion.FilterEventUserControl();
            this.visitUserControl = new EZKO.UserControls.Dashboard.VisitUserControl();
            this.mainTableLayoutPanel.SuspendLayout();
            this.leftTableLayoutPanel.SuspendLayout();
            this.middleTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 395F));
            this.mainTableLayoutPanel.Controls.Add(this.leftTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.middleTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.visitUserControl, 2, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1378, 869);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // leftTableLayoutPanel
            // 
            this.leftTableLayoutPanel.ColumnCount = 1;
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.Controls.Add(this.monthView, 0, 0);
            this.leftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            this.leftTableLayoutPanel.RowCount = 2;
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftTableLayoutPanel.Size = new System.Drawing.Size(284, 863);
            this.leftTableLayoutPanel.TabIndex = 0;
            // 
            // monthView
            // 
            this.monthView.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthView.EventsCountByDate = null;
            this.monthView.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView.Location = new System.Drawing.Point(3, 3);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(278, 425);
            this.monthView.TabIndex = 0;
            this.monthView.Text = "monthView1";
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
            // 
            // middleTableLayoutPanel
            // 
            this.middleTableLayoutPanel.ColumnCount = 1;
            this.middleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.middleTableLayoutPanel.Controls.Add(this.eventsFlowLayoutPanel, 0, 1);
            this.middleTableLayoutPanel.Controls.Add(this.filterEventUserControl, 0, 0);
            this.middleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleTableLayoutPanel.Location = new System.Drawing.Point(293, 3);
            this.middleTableLayoutPanel.Name = "middleTableLayoutPanel";
            this.middleTableLayoutPanel.RowCount = 2;
            this.middleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleTableLayoutPanel.Size = new System.Drawing.Size(687, 863);
            this.middleTableLayoutPanel.TabIndex = 1;
            // 
            // eventsFlowLayoutPanel
            // 
            this.eventsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsFlowLayoutPanel.AutoScroll = true;
            this.eventsFlowLayoutPanel.Location = new System.Drawing.Point(3, 91);
            this.eventsFlowLayoutPanel.Name = "eventsFlowLayoutPanel";
            this.eventsFlowLayoutPanel.Size = new System.Drawing.Size(681, 769);
            this.eventsFlowLayoutPanel.TabIndex = 1;
            // 
            // filterEventUserControl
            // 
            this.filterEventUserControl.AutoSize = true;
            this.filterEventUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterEventUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterEventUserControl.Location = new System.Drawing.Point(3, 3);
            this.filterEventUserControl.Name = "filterEventUserControl";
            this.filterEventUserControl.Size = new System.Drawing.Size(681, 82);
            this.filterEventUserControl.TabIndex = 2;
            // 
            // visitUserControl
            // 
            this.visitUserControl.AutoScroll = true;
            this.visitUserControl.BackColor = System.Drawing.Color.White;
            this.visitUserControl.Location = new System.Drawing.Point(986, 2);
            this.visitUserControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.visitUserControl.Name = "visitUserControl";
            this.visitUserControl.Size = new System.Drawing.Size(389, 865);
            this.visitUserControl.TabIndex = 2;
            // 
            // AmbulantionUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "AmbulantionUserControl";
            this.Size = new System.Drawing.Size(1378, 869);
            this.Resize += new System.EventHandler(this.AmbulantionUserControl_Resize);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.leftTableLayoutPanel.ResumeLayout(false);
            this.middleTableLayoutPanel.ResumeLayout(false);
            this.middleTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel leftTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel middleTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel eventsFlowLayoutPanel;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private Dashboard.VisitUserControl visitUserControl;
        private FilterEventUserControl filterEventUserControl;
    }
}
