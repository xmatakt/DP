using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Controllers;
using EZKO.Enums;
using EZKO.Forms;
using EZKO.UserControls.Administration;
using EZKO.UserControls.Ambulantion;
using EZKO.UserControls.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable

namespace EZKO
{
    public partial class MainForm : Form
    {
        //  Panels
        private UserControls.Dashboard.GoogleIntegratedCalendarControl dashboardPanel = null;
        private AdministrationUserControl administrationPanel = null;
        private AmbulantionUserControl ambulantionPanel = null;
        private PatientsUserControl patientsPanel = null;
        private GoogleCalendarSynchronizer.GoogleCalendarSynchronizer calendarSynchronizer;


        // enum to hold the information which panel has to be shown to the user
        private PanelLoadingEnum workingInfoEnum;
        // holds the EzkoController, which will be shared between the application (panels)
        private EzkoController ezkoController;
        // form to show informations about long term running operations
        WorkingInfoForm workingInfoForm;

        #region MainPannelDragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topMenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                var workingArea = Screen.FromHandle(Handle).WorkingArea;
                MaximizedBounds = new Rectangle(-8, -8, workingArea.Width + 16, workingArea.Height + 16);
            }
        }
        #endregion

        public MainForm()
        {
            try
            {
                GlobalSettings.Load();
                BasicMessagesHandler.SetLogFilePath(GlobalSettings.LogFilePath);

                ezkoController = GlobalSettings.EzkoController;
                //ezkoController.CreateFirstUser();

                //loggin in the user
                if (new LoginForm(ezkoController).ShowDialog() == DialogResult.OK)
                {
                    //Set language for GUI items
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(GlobalSettings.LanguagePrefix);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;

                    InitializeComponent();

                    var workingArea = Screen.FromHandle(Handle).WorkingArea;
                    MaximizedBounds = new Rectangle(-8, -8, workingArea.Width + 16, workingArea.Height + 16);
                    userNameLabel.Text += " " + GlobalSettings.User.Login;

                    LoadPanels();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa neočakávaná chyba!", ex);
            }
        }

        /// <summary>
        /// Loads the working panels
        /// </summary>
        private void LoadPanels()
        {
            workingInfoEnum = PanelLoadingEnum.LoadAll;

            // Configure a BackgroundWorker to perform your long running operation.
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            workingInfoForm = new WorkingInfoForm(LanguageController.GetText(StringKeys.Working),
                  LanguageController.GetText(StringKeys.PreparingSystem));
            workingInfoForm.ShowDialog();
        }

        #region HandleCloseButtonEvents
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            closeFormPictureBox.Image = Properties.Resources.closeForm_active_32;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            closeFormPictureBox.Image = Properties.Resources.closeForm_32;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region HandleMaximizeButtonEvents
        private void maximizeFormPictureBox_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_32;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_32;
            }
        }

        private void maximizeFormPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_active_32;
            else
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_active_32;
        }

        private void maximizeFormPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                maximizeFormPictureBox.Image = Properties.Resources.maximizeForm_32;
            else
                maximizeFormPictureBox.Image = Properties.Resources.minimizeForm_32;
        }
        #endregion

        #region HandleMinimizeButtonEvents
        private void minimizeFormPictureBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void minimizeFormPictureBox_MouseEnter(object sender, EventArgs e)
        {
            minimizeFormPictureBox.Image = Properties.Resources.toTaskbar_active_32;
        }

        private void minimizeFormPictureBox_MouseLeave(object sender, EventArgs e)
        {
            minimizeFormPictureBox.Image = Properties.Resources.toTaskbar_32;
        }
        #endregion

        /// <summary>
        /// Loads the panels in the separated thread to be able to show WorkingInfoForm
        /// to the user
        /// </summary>
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (workingInfoEnum)
            {
                case PanelLoadingEnum.LoadingDashboardPanel:
                    if (dashboardPanel == null)
                        dashboardPanel = new UserControls.Dashboard.GoogleIntegratedCalendarControl(ref calendarSynchronizer);
                    break;
                case PanelLoadingEnum.LoadingAmbulantionPanel:
                    if(ambulantionPanel == null)
                        ambulantionPanel = new AmbulantionUserControl(calendarSynchronizer);
                    break;
                case PanelLoadingEnum.LoadingPatientsPanel:
                    if (patientsPanel == null)
                        patientsPanel = new PatientsUserControl();
                    break;
                case PanelLoadingEnum.LoadingAdministrationPanel:
                    if (administrationPanel == null)
                        administrationPanel = new AdministrationUserControl();
                    break;
                case PanelLoadingEnum.LoadAll:
                    if (dashboardPanel == null)
                        dashboardPanel = new UserControls.Dashboard.GoogleIntegratedCalendarControl(ref calendarSynchronizer);
                    if (ambulantionPanel == null)
                        ambulantionPanel = new AmbulantionUserControl(calendarSynchronizer);
                    if (patientsPanel == null)
                        patientsPanel = new PatientsUserControl();
                    if (administrationPanel == null)
                        administrationPanel = new AdministrationUserControl();
                    break;
                default:
                    break;
            }
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mainPanel.Controls.Clear();
            switch (workingInfoEnum)
            {
                case PanelLoadingEnum.LoadingDashboardPanel:
                    if (dashboardPanel != null)
                    {
                        calendarSynchronizer.SynchronizeEvents(ezkoController);
                        mainPanel.Controls.Add(dashboardPanel);
                        dashboardPanel.Dock = DockStyle.Fill;
                        dashboardPanel.UpdateControl();
                    }
                    break;
                case PanelLoadingEnum.LoadingAmbulantionPanel:
                    if(ambulantionPanel != null)
                    {
                        calendarSynchronizer.SynchronizeEvents(ezkoController);
                        mainPanel.Controls.Add(ambulantionPanel);
                        ambulantionPanel.Dock = DockStyle.Fill;
                        ambulantionPanel.UpdateControl();
                        ambulantionPanel.LoadEvents();
                    }
                    break;
                case PanelLoadingEnum.LoadingPatientsPanel:
                    if (patientsPanel != null)
                    {
                        mainPanel.Controls.Add(patientsPanel);
                        patientsPanel.Dock = DockStyle.Fill;
                    }
                    break;
                case PanelLoadingEnum.LoadingAdministrationPanel:
                    if (administrationPanel != null)
                    {
                        mainPanel.Controls.Add(administrationPanel);
                        administrationPanel.Dock = DockStyle.Fill;
                    }
                    break;
                case PanelLoadingEnum.LoadAll:
                    if (dashboardPanel != null)
                    {
                        mainPanel.Controls.Add(dashboardPanel);
                        dashboardPanel.Dock = DockStyle.Fill;
                    }
                    if (ambulantionPanel != null)
                    {
                        mainPanel.Controls.Add(ambulantionPanel);
                        ambulantionPanel.Dock = DockStyle.Fill;
                    }
                    if (patientsPanel != null)
                    {
                        mainPanel.Controls.Add(patientsPanel);
                        patientsPanel.Dock = DockStyle.Fill;
                    }
                    if (administrationPanel != null)
                    {
                        mainPanel.Controls.Add(administrationPanel);
                        administrationPanel.Dock = DockStyle.Fill;
                    }
                    break;
                default:
                    break;
            }

            workingInfoForm.Close();
        }

        private void dashboardMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            workingInfoEnum = PanelLoadingEnum.LoadingDashboardPanel;

            // Configure a BackgroundWorker to perform your long running operation.
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            if (dashboardPanel == null)
            {
                workingInfoForm = new WorkingInfoForm(LanguageController.GetText(StringKeys.LoadingDataTitle),
                    LanguageController.GetText(StringKeys.LoadingDashboardPanel));
                workingInfoForm.ShowDialog();
            }
        }

        private void ambulantionMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            workingInfoEnum = PanelLoadingEnum.LoadingAmbulantionPanel;

            // Configure a BackgroundWorker to perform your long running operation.
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            if (ambulantionPanel == null)
            {
                workingInfoForm = new WorkingInfoForm(LanguageController.GetText(StringKeys.Working),
                    LanguageController.GetText(StringKeys.LoadingDataTitle));
                workingInfoForm.ShowDialog();
            }
        }
        private void patientsMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            workingInfoEnum = PanelLoadingEnum.LoadingPatientsPanel;

            // Configure a BackgroundWorker to perform your long running operation.
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            if (patientsPanel == null)
            {
                workingInfoForm = new WorkingInfoForm(LanguageController.GetText(StringKeys.Working),
                    LanguageController.GetText(StringKeys.LoadingDataTitle));
                workingInfoForm.ShowDialog();
            }
        }

        private void administrationMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            workingInfoEnum = PanelLoadingEnum.LoadingAdministrationPanel;

            // Configure a BackgroundWorker to perform your long running operation.
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            if (administrationPanel == null)
            {
                workingInfoForm = new WorkingInfoForm(LanguageController.GetText(StringKeys.Working),
                    LanguageController.GetText(StringKeys.LoadingDataTitle));
                workingInfoForm.ShowDialog();
            }
        }

        private void administrationMenuItem_Load(object sender, EventArgs e)
        {
            dashboardMenuItem.MenuItemText = LanguageController.GetText(StringKeys.Dashboard);
            ambulantionMenuItem.MenuItemText = LanguageController.GetText(StringKeys.Ambulantion);
            patientsMenuItem.MenuItemText = LanguageController.GetText(StringKeys.Patients);
            administrationMenuItem.MenuItemText = LanguageController.GetText(StringKeys.Administration);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            var workingArea = Screen.FromHandle(Handle).WorkingArea;
            MaximizedBounds = new Rectangle(-8, -8, workingArea.Width + 16, workingArea.Height + 16);
        }
    }
}
