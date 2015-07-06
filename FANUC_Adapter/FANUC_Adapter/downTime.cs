using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace AdapterLab
{
    using MTConnect;
    public partial class downTime : Form
    {
        Report report;
        Stopwatch start;

        public string startTime;
        public string endTime;
        public string reason = string.Empty;

        public downTime(Report report)
        {
            this.report = report;
            InitializeComponent();
        }

        public string setDownTimeReason()
        {
            if (lunch.Checked)
            {
                reason = "Lunch / Break";
            }
            else if (loading.Checked)
            {
                reason = "Loading / Unloading Machine";
            }
            else if (machineError.Checked)
            {
                reason = "Machine Error: " + this.report.alarmType[0] + " " + this.report.alarm[0];
            }
            else if (endOfShift.Checked)
            {
                reason = "End Of Shift";
            }
            else if (maintenance.Checked)
            {
                reason = "Maintenance";
            }
            else if (cleaning.Checked)
            {
                reason = "Cleaning";
            }
            else if (other.Checked)
            {
                reason = otherTextBox.Text;
            }
                return reason;
        }

        public string startDownTimeCounter()
        {
            startTime = DateTime.Now.ToString("MMM DD, YYYY HH:mm:ss");
            start = Stopwatch.StartNew();

            return startTime;
        }

        // Stop our downtime counter

        public string stopDownTimeCounter()
        {
            start.Stop();

            endTime = DateTime.Now.ToString("MMM DD, YYYY HH:mm:ss");

            return endTime;
        }

        // Retrieve the current downtime

        public string GetElapsedDownTime(ref double totalElapsed)
        {
            double elapsed = start.ElapsedTicks / (double)Stopwatch.Frequency;

            totalElapsed = totalElapsed + elapsed;

            string formattedEDT = formatTime(elapsed);

            return formattedEDT;
        }


        // What happens when we click the accept button?

        private void acceptButton_Click(object sender, EventArgs e)
        {
            setDownTimeReason();
            this.Hide();
        }


        // Format the time into a recognizable format

        private string formatTime(double elapsedDT)
        {
            // Our deliminator
            char[] delim = { '.' };
            // Out elapsed time in string format
            string edt = elapsedDT.ToString();
            // We split the string into pieces by finding our deliminator (".") and breaking at that point.
            string[] splitDT = edt.Split(delim);
            // Convert the seconds back into an integer
            int secondsIndex = Convert.ToInt32(splitDT[0]);
            // Keep track of minutes
            int minutesIndex = 0;
            // Keep track of hours
            int hoursIndex = 0;
            // This will be our new line that is output after all the calculations
            string newTime = string.Empty;

            // If the seconds get to 60, enter the loop
            // If we are already in the loop and we have subtracted 60 from
            // Our seconds, check to see if the value is still greater than 59.
            // If it is, repeat until our value is less than 60.
            while (secondsIndex > 59)
            {
                // Subtrack 60 from our seconds value
                secondsIndex = secondsIndex - 60;
                // Add 1 to the index (minutes)
                minutesIndex += 1;

                // Check to see if our minutes have exceeded 59
                while (minutesIndex > 59)
                {
                    // If they have, subtract 60 from our minutes
                    minutesIndex = minutesIndex - 60;
                    // Add 1 to the hours
                    hoursIndex += 1;
                }

            }

            // Check to see if we have a value in the minutes or hours, if not, then we will only show the seconds
            if (minutesIndex == 0 && hoursIndex == 0)
            {
                newTime = secondsIndex.ToString();
                return newTime;
            }
            // Check to see if we have a value only in the minutes. If we do, then we will display the minutes and seconds
            else if (minutesIndex != 0  && hoursIndex == 0)
            {
                newTime = minutesIndex.ToString() + "." + secondsIndex.ToString();
                return newTime;
            }
            // Check to see if we have a value in the hours. If we do, then display hours, minutes and seconds.
            else if (hoursIndex != 0)
            {
                newTime = hoursIndex.ToString() + "." + minutesIndex.ToString() + "." + secondsIndex.ToString();
                return newTime;
            }

            return newTime;
            
        }

        /*public string DownTimeLogEntry()
        {
            string currentDate = DateTime.Now.ToString("YYYY:MM:DD");



            string logEntry = currentDate + " Down Time Reason: " + reason + " Time Elapsed: " + elapsed + "Total Down Time (Day): " + totalElapsed;

            return logEntry;
        }*/
    }
}
