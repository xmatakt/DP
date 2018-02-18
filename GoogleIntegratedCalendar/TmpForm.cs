using DatabaseCommunicator.Controllers;
using DatabaseCommunicator.Model;
using ExceptionHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            EzkoEntities db = new EzkoEntities(GlobalSettings.ConnectionString);
            EzkoController ezkoController = new EzkoController(GlobalSettings.ConnectionString);
            //Budget b = db.Budgets.First(x => x.PatientID == 10);
            //PDFCreator.EZKODocumentation.BudgetToPDF pdf = new PDFCreator.EZKODocumentation.BudgetToPDF(@"C:\AATimo\tmp.pdf", b);
            //if (pdf.CreatePdf())
            //    System.Diagnostics.Process.Start(@"C:\AATimo\tmp.pdf");

            //var v = db.Forms.First(x => x.ID == 1);
            //PDFCreator.EZKODocumentation.FormToPDF pdf = new PDFCreator.EZKODocumentation.FormToPDF(@"C:\AATimo\tmp.pdf", v);
            //if (pdf.CreatePdf())
            //    System.Diagnostics.Process.Start(@"C:\AATimo\tmp.pdf");

            Patient b = db.Patients.First(x => x.ID == 13);
            User u = db.Users.First(x => x.ID == 2);
            PDFCreator.EZKODocumentation.EhrToPDF pdf = new PDFCreator.EZKODocumentation.EhrToPDF(@"C:\AATimo\tmp.pdf", b, u, ezkoController);
            if (pdf.CreatePdf())
                System.Diagnostics.Process.Start(@"C:\AATimo\tmp.pdf");
        }
    }
}
