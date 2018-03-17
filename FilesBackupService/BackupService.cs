using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

//https://docs.microsoft.com/en-us/dotnet/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer#BK_CreateProject

namespace FilesBackupService
{
    public partial class BackupService : ServiceBase
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        private Timer timer;
        private bool isRunning = false;

        public BackupService()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.  
            ServiceStatus serviceStatus = new ServiceStatus
            {
                dwCurrentState = ServiceState.SERVICE_START_PENDING,
                dwWaitHint = 100000
            };
            SetServiceStatus(ServiceHandle, ref serviceStatus);
                
            // Update the service state to Running.  
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(ServiceHandle, ref serviceStatus);

            LogMessage("Backup Service started");
            timer.Start();
        }

        protected override void OnStop()
        {
            LogMessage("Backup Service stopped.");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!isRunning && CanRunService())
            {
                LogMessage("Backup started...");
                BackupFiles();
                LogMessage("Backup has succesfully ended.");
            }
        }

        private void BackupFiles()
        {
            isRunning = true;

            try
            {
                if(CheckSourcePath() && CheckTargetPath())
                {
                    LogMessage("Files backup started...");
                    string fileName = GetZipFileName();
                    LogMessage("Creating backup into " + fileName);
                    ZipFile.CreateFromDirectory(Properties.ServiceSettings.Default.SourceFolderPath, fileName);
                    LogMessage("Files backup succesfully ended.");
                }
            }
            catch (Exception ex)
            {
                LogMessage("An error occured while trying to backup files!");
                LogErrorMessage(ex);
            }

            isRunning = false;
        }

        private bool CheckTargetPath()
        {
            bool result = true;
            try
            {
                if (!Directory.Exists(Properties.ServiceSettings.Default.TargetFolderPath))
                    Directory.CreateDirectory(Properties.ServiceSettings.Default.TargetFolderPath);
            }
            catch (Exception ex)
            {
                result = false;
                LogErrorMessage(ex);
            }

            return result;
        }

        private bool CheckSourcePath()
        {
            bool result = true;
            try
            {
                if (!Directory.Exists(Properties.ServiceSettings.Default.SourceFolderPath))
                {
                    LogErrorMessage("Source directory " + Properties.ServiceSettings.Default.TargetFolderPath + " doesn't exist!");
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                LogErrorMessage(ex);
            }

            return result;
        }

        private string GetZipFileName()
        {
            string result = "";
            DateTime now = DateTime.Now;

            try
            {
                string fileName = "\\ezkoBackup_" + now.ToString("ddMMyyyyHHmmss") + ".zip";
                result = Properties.ServiceSettings.Default.TargetFolderPath + fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private bool CanRunService()
        {
            bool result = false;

            try
            {
                //DayOfWeek:
                // 0 -> Sunday
                // 1 - 6 -> Monday - Saturday 

                DateTime now = DateTime.Now;
                TimeSpan backupTime = Properties.ServiceSettings.Default.BackupTime;

                // If DayInWeek is set to 0 -> daily backup
                if (Properties.ServiceSettings.Default.DayInWeek == 0)
                    result = ((now.Hour == backupTime.Hours) && (now.Minute == backupTime.Minutes));
                else if (now.DayOfWeek == Day())
                    result = ((now.Hour == backupTime.Hours) && (now.Minute == backupTime.Minutes));

                if (result)
                    timer.Interval = 80000;
                else
                    timer.Interval = 30000;
            }
            catch (Exception ex)
            {
                result = false;
                LogErrorMessage(ex);
            }

            return result;
        }

        private void LogMessage(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Properties.ServiceSettings.Default.LogFilePath, true))
                {
                    writer.Write(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ": ");
                    writer.WriteLine(message);
                }
            }
            catch (Exception)
            {
            }
        }

        private void LogErrorMessage(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Properties.ServiceSettings.Default.LogFilePath, true))
                {
                    writer.Write(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + " ERROR > ");
                    writer.WriteLine(ex.ToString());
                }
            }
            catch (Exception)
            {
            }
        }

        private void LogErrorMessage(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Properties.ServiceSettings.Default.LogFilePath, true))
                {
                    writer.Write(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "ERROR > ");
                    writer.WriteLine(message);
                }
            }
            catch (Exception)
            {
            }
        }

        private DayOfWeek Day()
        {
            switch (Properties.ServiceSettings.Default.DayInWeek)
            {
                case 1:
                    return DayOfWeek.Monday;
                case 2:
                    return DayOfWeek.Tuesday;
                case 3:
                    return DayOfWeek.Wednesday;
                case 4:
                    return DayOfWeek.Thursday;
                case 5:
                    return DayOfWeek.Friday;
                case 6:
                    return DayOfWeek.Saturday;
                case 7:
                    return DayOfWeek.Sunday;
                default:
                    throw new Exception("Unsupported number of day used in settings file. Use number from 0 to 7.");
            }
        }
    }
}
