using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using System;
using System.Linq;
using Mailer;

namespace EZKO
{
    public partial class TmpForm : System.Windows.Forms.Form
    {
        public TmpForm()
        {
            InitializeComponent();

            //GlobalSettings.Load();
            BasicMessagesHandler.SetLogFilePath(GlobalSettings.LogFilePath);
        }
    }
}
