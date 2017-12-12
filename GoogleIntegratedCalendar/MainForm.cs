﻿using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using EZKO.Controllers;
using EZKO.Enums;
using EZKO.Forms;
using EZKO.UserControls.Administration;
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
            GlobalSettings.Load();
            ezkoController = new EzkoController(GlobalSettings.ConnectionString);
            //ezkoController.CreateFirstUser();

            //loggin in the user
            if (new LoginForm(ezkoController).ShowDialog() == DialogResult.OK)
            {
                InitializeComponent();

                var workingArea = Screen.FromHandle(Handle).WorkingArea;
                MaximizedBounds = new Rectangle(-8, -8, workingArea.Width + 16, workingArea.Height + 16);

                //Set language for GUI items
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(GlobalSettings.LanguagePrefix);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                LoadPanels();
            }
            else
            {
                Environment.Exit(0);
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

        private void dashboardMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            workingInfoEnum = PanelLoadingEnum.LoadingDashboardPanel;

            // Configure a BackgroundWorker to perform your long running operation.
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            // Start the worker.
            bg.RunWorkerAsync();

            if(dashboardPanel == null)
            {
                workingInfoForm = new WorkingInfoForm(LanguageController.GetText(StringKeys.LoadingDataTitle),
                    LanguageController.GetText(StringKeys.LoadingDashboardPanel));
                workingInfoForm.ShowDialog();
            }
        }

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
                        dashboardPanel = new UserControls.Dashboard.GoogleIntegratedCalendarControl(ezkoController);
                    break;
                case PanelLoadingEnum.LoadingAmbulantionPanel:
                    break;
                case PanelLoadingEnum.LoadingPatientsPanel:
                    break;
                case PanelLoadingEnum.LoadingAdministrationPanel:
                    if (administrationPanel == null)
                        administrationPanel = new AdministrationUserControl(ezkoController);
                    break;
                case PanelLoadingEnum.LoadAll:
                    if (dashboardPanel == null)
                        dashboardPanel = new UserControls.Dashboard.GoogleIntegratedCalendarControl(ezkoController);
                    if (administrationPanel == null)
                        administrationPanel = new AdministrationUserControl(ezkoController);
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
                        mainPanel.Controls.Add(dashboardPanel);
                        dashboardPanel.Dock = DockStyle.Fill;
                        dashboardPanel.UpdateControl();
                    }
                    break;
                case PanelLoadingEnum.LoadingAmbulantionPanel:
                    break;
                case PanelLoadingEnum.LoadingPatientsPanel:
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

        private void ambulantionMenuItem_TransparentPanelMouseClick(object sender, MouseEventArgs e)
        {
            var tmpform = new WorkingInfoForm("","");
            tmpform.Show();
             
            mainPanel.Controls.Clear();
            tmpform.Invalidate();
            var tmpPanel = new Panel();
            tmpPanel.BackColor = Color.Red;


            mainPanel.Controls.Add(tmpPanel);
            tmpPanel.Dock = DockStyle.Fill;

            tmpform.Close();
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
