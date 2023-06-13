using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // display current date and time
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayDateTimeNow();
        }

        // executes every second
        private void timer_Tick(object sender, EventArgs e)
        {
            DisplayDateTimeNow();
        }

        // display current date and time 
        private void DisplayDateTimeNow ()
        {
            //lblToday.Text = DateTime.Now.ToLongDateString();
            lblToday.Text = DateTime.Now.ToString("D");
            //lblTime.Text = DateTime.Now.ToLongTimeString();
            lblTime.Text = DateTime.Now.ToString("T");
        }

        // user selected date for the party
        private void dtpParty_ValueChanged(object sender, EventArgs e)
        {
            DateTime partyDay = dtpParty.Value.Date; // ignore time 
            // calculate how many sleeps
            // difference of dates is measured in timespan - an internal way of measuring passage of time
            TimeSpan difference = partyDay.Subtract(DateTime.Today);
            int days = difference.Days; // measured in Days

            lblMessage.Text = "The party is on " + partyDay.ToLongDateString();
            if (days < 0) // in the past
                lblMessage.Text += "\nSorry you missed it :-(";
            else if (days == 0)
                lblMessage.Text += "\nYay, It's today!!!";
            else if (days == 1)
                lblMessage.Text += "\nIt's tomorrow, one more sleep";
            else
                lblMessage.Text += "\n" + days.ToString() + " more sleeps";
        }
    }
}
