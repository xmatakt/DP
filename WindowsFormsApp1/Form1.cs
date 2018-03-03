using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Point originalLocation;
        private bool move = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            originalLocation = new Point(e.Location.X, e.Location.Y);
            panel1.BringToFront();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(move)
            {
                int diff = e.Location.Y - originalLocation.Y;
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + diff);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

            //if(panel1.Co)
        }
    }
}
