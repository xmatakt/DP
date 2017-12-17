using System;
using System.Windows.Forms;
using DatabaseCommunicator.Controllers;
using ExceptionHandler;
using DatabaseCommunicator.Model;
using DatabaseCommunicator.Classes;

namespace EZKO.UserControls.Ambulantion
{
    public partial class FilterEventUserControl : UserControl
    {
        private EzkoController ezkoController;
        private AmbulantionUserControl ambulantionControl;
        private string searchAll = "Nezáleží";

        #region Public properties
        public bool ApplyFilter
        {
            get{ return (doctorComboBox.SelectedIndex > 0 || nurseComboBox.SelectedIndex > 0 || infrastructureComboBox.SelectedIndex > 0); }
        }
        public CalendarEventFilter Filter
        {
            get
            {
                CalendarEventFilter result = new CalendarEventFilter()
                {
                    Doctor = doctor,
                    Nurse = nurse,
                    Infrastructure = infrastructure
                };

                return result;
            }
        }
        #endregion

        #region Private properties
        private User doctor { get { return doctorComboBox.SelectedItem as User; } }
        private User nurse { get { return nurseComboBox.SelectedItem as User; } }
        private Infrastructure infrastructure { get { return infrastructureComboBox.SelectedItem as Infrastructure; } }
        #endregion

        public FilterEventUserControl()
        {
            InitializeComponent();
        }

        #region Public methods
        public void SetEzkoController(EzkoController ezkoController)
        {
            this.ezkoController = ezkoController;
            UpdateControl();
        }

        public void SetAmbulantionContorlPanel(AmbulantionUserControl ambulantionControl)
        {
            this.ambulantionControl = ambulantionControl;
        }

        public void UpdateControl()
        {
            InitiazlizeDoctorComboBox();
            InitiazlizeNurseComboBox();
            InitiazlizeInfrastructureComboBox();
        }

        public void SetTitleLabel(DateTime selectionStart, DateTime selectionEnd)
        {
            if (!selectionStart.Date.Equals(selectionEnd.Date))
                titleLabel.Text = "Rozvrh ambulancie " + selectionStart.ToString("dddd d.MMMM yyyy") + " - " +
                    selectionEnd.ToString("dddd d.MMMM yyyy");
            else
                titleLabel.Text = "Rozvrh ambulancie " + selectionStart.ToString("dddd d.MMMM yyyy");
        }

        public void SetTitleLabel(DateTime date)
        {
            titleLabel.Text = "Rozvrh ambulancie " + date.ToString("dddd d.MMMM yyyy");
        }
        #endregion

        #region Private methods
        private void InitiazlizeDoctorComboBox()
        {
            try
            {
                doctorComboBox.Items.Clear();
                doctorComboBox.Items.Add(searchAll);
                foreach (var item in ezkoController.GetDoctors())
                {
                    doctorComboBox.Items.Add(item);
                }

                doctorComboBox.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri načítaní filtra pre doktorov", e);
            }
        }
        private void InitiazlizeNurseComboBox()
        {
            try
            {
                nurseComboBox.Items.Clear();
                nurseComboBox.Items.Add(searchAll);
                foreach (var item in ezkoController.GetNurses())
                {
                    nurseComboBox.Items.Add(item);
                }

                nurseComboBox.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri načítaní filtra pre sestričky", e);
            }
        }

        private void InitiazlizeInfrastructureComboBox()
        {
            try
            {
                infrastructureComboBox.Items.Clear();
                infrastructureComboBox.Items.Add(searchAll);
                foreach (var item in ezkoController.GetInfrastructure())
                {
                    infrastructureComboBox.Items.Add(item);
                }

                infrastructureComboBox.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                BasicMessagesHandler.ShowErrorMessage("Vyskytla sa chyba pri načítaní filtra pre inftaštruktúru", e);
            }
        }
        #endregion

        #region UI events
        private void searchInEventsButton_Click(object sender, EventArgs e)
        {
            ambulantionControl.LoadEvents(Filter);
        }
        #endregion
    }
}
