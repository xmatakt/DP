using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleIntegratedCalendarTest
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            googleIntegratedCalendarControl.InitializeController(@"data source=DELLWIN8;initial catalog=Ezko;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;");
        }
    }
}
