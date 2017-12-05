using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZKO.Forms
{
    /// <summary>
    /// Form used to inform the user while doining the long actions
    /// </summary>
    public partial class WorkingInfoForm : Form
    {
        public string TitleText
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }
        public string MessageText
        {
            get { return messageLable.Text; }
            set { messageLable.Text = value; }
        }

        public WorkingInfoForm(string title, string message)
        {
            InitializeComponent();

            TitleText = title;
            MessageText = message;
        }
    }
}
