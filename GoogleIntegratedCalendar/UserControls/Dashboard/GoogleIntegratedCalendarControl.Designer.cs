namespace EZKO.UserControls.Dashboard
{
    partial class GoogleIntegratedCalendarControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.middleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.findEventUserControl = new EZKO.UserControls.Dashboard.FindEventUserControl();
            this.calendar = new System.Windows.Forms.Calendar.Calendar();
            this.leftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.leftBottomPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.visitUserControl = new EZKO.UserControls.Dashboard.VisitUserControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.monthviewSettingsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timeIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteInterval5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteInterval10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteInterval15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteInterval30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteInterval60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel.SuspendLayout();
            this.middleTableLayoutPanel.SuspendLayout();
            this.leftTableLayoutPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.monthviewSettingsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.AutoScroll = true;
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 395F));
            this.mainTableLayoutPanel.Controls.Add(this.middleTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.leftTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.rightPanel, 2, 0);
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1289, 761);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // middleTableLayoutPanel
            // 
            this.middleTableLayoutPanel.ColumnCount = 1;
            this.middleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.middleTableLayoutPanel.Controls.Add(this.findEventUserControl, 0, 0);
            this.middleTableLayoutPanel.Controls.Add(this.calendar, 0, 1);
            this.middleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleTableLayoutPanel.Location = new System.Drawing.Point(293, 3);
            this.middleTableLayoutPanel.Name = "middleTableLayoutPanel";
            this.middleTableLayoutPanel.RowCount = 2;
            this.middleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.middleTableLayoutPanel.Size = new System.Drawing.Size(598, 755);
            this.middleTableLayoutPanel.TabIndex = 2;
            // 
            // findEventUserControl
            // 
            this.findEventUserControl.AutoSize = true;
            this.findEventUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.findEventUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findEventUserControl.Location = new System.Drawing.Point(2, 2);
            this.findEventUserControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findEventUserControl.Name = "findEventUserControl";
            this.findEventUserControl.Size = new System.Drawing.Size(594, 72);
            this.findEventUserControl.TabIndex = 0;
            // 
            // calendar
            // 
            this.calendar.AllowNew = false;
            this.calendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar.Location = new System.Drawing.Point(3, 79);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(592, 673);
            this.calendar.TabIndex = 0;
            this.calendar.Text = "calendar1";
            this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
            this.calendar.DayHeaderClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(this.calendar_DayHeaderClick);
            this.calendar.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar_ItemCreated);
            this.calendar.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDeleted);
            this.calendar.ItemTextEdited += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar_ItemTextEdited);
            this.calendar.ItemDatesChanged += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDatesChanged);
            this.calendar.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemClick);
            this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_ItemDoubleClick);
            this.calendar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.calendar_MouseClick);
            // 
            // leftTableLayoutPanel
            // 
            this.leftTableLayoutPanel.ColumnCount = 1;
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftTableLayoutPanel.Controls.Add(this.monthView, 0, 0);
            this.leftTableLayoutPanel.Controls.Add(this.leftBottomPanel, 0, 1);
            this.leftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            this.leftTableLayoutPanel.RowCount = 2;
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftTableLayoutPanel.Size = new System.Drawing.Size(284, 755);
            this.leftTableLayoutPanel.TabIndex = 3;
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
            this.monthView.EventsDurationByDate = null;
            this.monthView.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView.Location = new System.Drawing.Point(3, 3);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(278, 371);
            this.monthView.TabIndex = 0;
            this.monthView.Text = "monthView1";
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
            // 
            // leftBottomPanel
            // 
            this.leftBottomPanel.Location = new System.Drawing.Point(3, 380);
            this.leftBottomPanel.Name = "leftBottomPanel";
            this.leftBottomPanel.Size = new System.Drawing.Size(278, 372);
            this.leftBottomPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.AutoScroll = true;
            this.rightPanel.AutoSize = true;
            this.rightPanel.Controls.Add(this.visitUserControl);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(897, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(389, 755);
            this.rightPanel.TabIndex = 4;
            // 
            // visitUserControl
            // 
            this.visitUserControl.AutoScroll = true;
            this.visitUserControl.BackColor = System.Drawing.Color.White;
            this.visitUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visitUserControl.Location = new System.Drawing.Point(0, 0);
            this.visitUserControl.Margin = new System.Windows.Forms.Padding(2);
            this.visitUserControl.Name = "visitUserControl";
            this.visitUserControl.Size = new System.Drawing.Size(389, 755);
            this.visitUserControl.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // monthviewSettingsMenuStrip
            // 
            this.monthviewSettingsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.monthviewSettingsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeIntervalToolStripMenuItem});
            this.monthviewSettingsMenuStrip.Name = "monthviewSettingsMenuStrip";
            this.monthviewSettingsMenuStrip.Size = new System.Drawing.Size(155, 26);
            // 
            // timeIntervalToolStripMenuItem
            // 
            this.timeIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minuteInterval5ToolStripMenuItem,
            this.minuteInterval10ToolStripMenuItem,
            this.minuteInterval15ToolStripMenuItem,
            this.minuteInterval30ToolStripMenuItem,
            this.minuteInterval60ToolStripMenuItem});
            this.timeIntervalToolStripMenuItem.Name = "timeIntervalToolStripMenuItem";
            this.timeIntervalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.timeIntervalToolStripMenuItem.Text = "Časový interval";
            // 
            // minuteInterval5ToolStripMenuItem
            // 
            this.minuteInterval5ToolStripMenuItem.Name = "minuteInterval5ToolStripMenuItem";
            this.minuteInterval5ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.minuteInterval5ToolStripMenuItem.Text = "5 minút";
            this.minuteInterval5ToolStripMenuItem.Click += new System.EventHandler(this.minuteInterval5ToolStripMenuItem_Click);
            // 
            // minuteInterval10ToolStripMenuItem
            // 
            this.minuteInterval10ToolStripMenuItem.Name = "minuteInterval10ToolStripMenuItem";
            this.minuteInterval10ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.minuteInterval10ToolStripMenuItem.Text = "10 minút";
            this.minuteInterval10ToolStripMenuItem.Click += new System.EventHandler(this.minuteInterval10ToolStripMenuItem_Click);
            // 
            // minuteInterval15ToolStripMenuItem
            // 
            this.minuteInterval15ToolStripMenuItem.Name = "minuteInterval15ToolStripMenuItem";
            this.minuteInterval15ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.minuteInterval15ToolStripMenuItem.Text = "15 minút";
            this.minuteInterval15ToolStripMenuItem.Click += new System.EventHandler(this.minuteInterval15ToolStripMenuItem_Click);
            // 
            // minuteInterval30ToolStripMenuItem
            // 
            this.minuteInterval30ToolStripMenuItem.Name = "minuteInterval30ToolStripMenuItem";
            this.minuteInterval30ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.minuteInterval30ToolStripMenuItem.Text = "30 minút";
            this.minuteInterval30ToolStripMenuItem.Click += new System.EventHandler(this.minuteInterval30ToolStripMenuItem_Click);
            // 
            // minuteInterval60ToolStripMenuItem
            // 
            this.minuteInterval60ToolStripMenuItem.Name = "minuteInterval60ToolStripMenuItem";
            this.minuteInterval60ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.minuteInterval60ToolStripMenuItem.Text = "60 minút";
            this.minuteInterval60ToolStripMenuItem.Click += new System.EventHandler(this.minuteInterval60ToolStripMenuItem_Click);
            // 
            // GoogleIntegratedCalendarControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "GoogleIntegratedCalendarControl";
            this.Size = new System.Drawing.Size(1289, 761);
            this.Resize += new System.EventHandler(this.GoogleIntegratedCalendarControl_Resize);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.middleTableLayoutPanel.ResumeLayout(false);
            this.middleTableLayoutPanel.PerformLayout();
            this.leftTableLayoutPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.monthviewSettingsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Calendar.Calendar calendar;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel middleTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel leftTableLayoutPanel;
        private System.Windows.Forms.Panel leftBottomPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FindEventUserControl findEventUserControl;
        private System.Windows.Forms.Panel rightPanel;
        private VisitUserControl visitUserControl;
        private System.Windows.Forms.ContextMenuStrip monthviewSettingsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem timeIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteInterval5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteInterval10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteInterval15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteInterval30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteInterval60ToolStripMenuItem;
    }
}
