/*
 * Copyright Copyright 2012, System Insights, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *       http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AdapterLab
{
    using MTConnect;

    //--------------------------------------------------------------------------------------------------------------------//
    //--------------------------------------- Class Vars -----------------------------------------------------------------//
    //--------------------------------------------------------------------------------------------------------------------//

    public partial class MachineTool : Form
    {
        public ushort hFanucConn = 0;            // FANUC Handle
        //public ushort hFanucUI = 0;          // FANUC Handle UI Thread
        public ushort hFanucMonitor = 0;     // FANUC Handle Monitor Thread
        public short axisXmNum = 1;                    // X Master Axis Number
        public short axisYNum = 2;                     // Y Axis Number
        public short axisZNum = 3;                     // Z Axis Number
        public short axisCNum = 6;                     // C Axis Number
        public short axisANum = 5;                     // A Axis Number
        public short axisUNum = 4;                     // U Axis Number
        public bool gantryChecked = false;      // Gantry Machine Check
        public bool fixedBridgeChecked = false; // Fixed Bridge Machine Check
        public bool highRailChecked = false;    // High Rail / Hybrid Mill Check
        public bool dualTableChecked = false;   // Dual Table Machine Check
        public bool dualProcChecked = false;    // Dual Process Machine Check
        public bool axis3 = false;              // 3 Axis Machine Check
        public bool axis4 = false;              // 4 Axis Machine Check
        public bool axis5 = false;              // 5 Axis Machine Check
        public bool axis3P2 = false;              // P2 3 Axis Machine Check
        public bool axis4P2 = false;              // P2 4 Axis Machine Check
        public bool axis5P2 = false;              // P2 5 Axis Machine Check
        bool halt = false;                      // Requested Halt variable
        public bool connected = false;          // Check to see if connection is active
        bool editModeEnabled = false;           // Check for edit mode
        string fanucIP = "192.168.1.1";         // CNC IP
        public string nickName = string.Empty;         // Machine nickname
        public Focas1.ODBST fanucStatus;        // Fanuc Status
        public double totalDownTime = 0;        // Down Time Counter  

        // XML Variables
        public string xmlNameP1 = string.Empty;
        public string xmlNameP2 = string.Empty;
        public string cncModel = string.Empty;
        public string hostIP = string.Empty;
        public string portP1 = string.Empty;
        public string portP2 = string.Empty;

        // Tool Changer
        public bool gifuChanger = false;

        // Threads
        Thread thread1;
        Thread thread2;

        private WriteXML xml;
        private downTime dt;
        private Report reportProc1;
        private Report reportProc2;

        //-----------------------------------------------------------------------------------------------------------------//
        //------------------------------ Initialize MachineTool -----------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------------------//

        public MachineTool()
        {
            InitializeComponent();
            
            reportProc1 = new Report(this);
            reportProc2 = new Report(this);
            xml = new WriteXML(this);

            // Load saved settings if available
            if (File.Exists("settings.ini"))
            {
                loadSettings();
            }

            stop.Enabled = false;

            // Check Number Of Axes
            if (threeAxis.Checked)
            {
                axis3 = true;
            }
            if (fourAxis.Checked)
            {
                axis4 = true;
            }
            if (fiveAxis.Checked)
            {
                axis5 = true;
            }

            if (threeAxisP2.Checked)
            {
                axis3P2 = true;
            }
            if (fourAxisP2.Checked)
            {
                axis4P2 = true;
            }
            if (fiveAxisP2.Checked)
            {
                axis5P2 = true;
            }

            if (gifu.Checked)
            {
                gifuChanger = true;
            }
            else gifuChanger = false;

            if (gantry.Checked)
            {
                gantryChecked = true;
            }
            else if (fixedBridge.Checked)
            {
                fixedBridgeChecked = true;
            }
            else if (highRail.Checked)
            {
                highRailChecked = true;
            }

            nickName = cncName.Text;
            cncModel = model.Text;
            hostIP = this.hostname.Text;
            fanucIP = cncField.Text;
            portP1 = this.port.Text;
            portP2 = this.port2.Text;
            try
            {
                axisXmNum = Convert.ToInt16(xAxisID.Text); // X Master Axis Number
                axisYNum = Convert.ToInt16(yAxisID.Text);  // Y Axis Number
                axisZNum = Convert.ToInt16(zAxisID.Text);  // Z Axis Number
                if (cAxisID.Text != "-")
                    axisCNum = Convert.ToInt16(cAxisID.Text);  // C Axis Number
                if (aAxisID.Text != "-")
                    axisANum = Convert.ToInt16(aAxisID.Text);  // A Axis Number
                if (uAxisID.Text != "-")
                    axisUNum = Convert.ToInt16(uAxisID.Text);  // U Axis Number
            }
            catch(Exception ex)
            {
                MessageBox.Show("Axis ID's must be a valid number or a '-' if the axis is not being used. X, Y & Z must be a valid integer only.");
            }

            WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        //-------------------------------------------------------------------------------------------------------------------//
        //----------------------------- CNC Connect & Test ------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------------------------------------//


        public void cncConnect()
        {
            // Open a Cndex Session
            int result = Focas1.cnc_allclibhndl3(fanucIP, 8193, 6, out hFanucConn);
            //int result = Focas1.cnc_allclibhndl(out hFanucLib);
            fanucStatus = new Focas1.ODBST();

            // Check to see if the session was successful. If it was, enter a loop to continually test for connection.
            if (result == 0)
            {
                while (Focas1.cnc_statinfo(hFanucConn, fanucStatus) == Focas1.EW_OK && halt == false)
                {
                    connected = true;
                    Thread.Sleep(1000);
                }

                // If the loop was not halted on purpose (Stop Button was not clicked), then display tbe error
                if (halt == false)
                {
                    //MessageBox.Show("Cndex Disconnected!");
                    Focas1.cnc_freelibhndl(hFanucConn);
                    connected = false;
                    return;
                }
                //Focas1.cnc_freelibhndl(hFanucLib);
                return;
            }
            else
            {
                // If we did not enter the loop at all then the connection was not successful, so display an error
                Focas1.cnc_freelibhndl(hFanucConn);
                MessageBox.Show("Error connecting to CNC at: " + fanucIP + ":8193");
                return;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------//
        //------------------------------------- Monitor Axes Positions & Feed Rates -----------------------------------------//
        //-------------------------------------------------------------------------------------------------------------------//

        private void monitor()
        {
            int result = Focas1.cnc_allclibhndl3(fanucIP, 8193, 6, out hFanucMonitor);

            Thread.Sleep(1000);
  
            short max_axes = reportProc1.getConfiguredAxes(hFanucMonitor);
            // If we are connected, then enter loop
            while (connected)
            {
                // Check Process 1 values
                reportProc1.getChangedValues(this);
                reportProc1.getAxesPos(this, hFanucMonitor);
                reportProc1.BufferDataItems();
                reportProc1.mAdapter.SendChanged();
                
                // If dual process machine, check Process 2 values
                if (dualProc.Checked)
                {
                    reportProc2.getChangedValues(this);
                    reportProc2.getAxesPos(this, hFanucMonitor);
                    reportProc2.BufferDataItems();
                    reportProc2.mAdapter.SendChanged();
                }
                //Thread.Sleep(1); // Let the thread sleep for 1 miliseconds. This will test the loop 200 times a second.
            }
            Focas1.cnc_freelibhndl(hFanucMonitor);
            return;
        }
        //--------------------------------------------------------------------------------------------------------------------//
        //----------------------------------- Start Button Click -------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------------------//

        private void startAdapter()
        {
            // Start the adapter lib with the port number in the text box
            reportProc1.mAdapter.Port = Convert.ToInt32(port.Text);
            reportProc1.mAdapter.Start();

            if (dualProc.Checked)
            {
                reportProc2.mAdapter.Port = Convert.ToInt32(port2.Text);
                reportProc2.mAdapter.Start();
            }

            thread1 = new Thread(new ThreadStart(cncConnect));
            thread1.IsBackground = true;
            thread1.Start();

            // Monitor Axes Positions
            //Thread.Sleep(1000);
            thread2 = new Thread(new ThreadStart(monitor));
            thread2.IsBackground = true;
            thread2.Start();

            // Disable start and enable stop.
            start.Enabled = false;
            stop.Enabled = true;

            // Start our periodic timer
            gather.Interval = 1000;
            gather.Enabled = true;

        }

        private void start_Click(object sender, EventArgs e)
        {
            startAdapter();
        }

        //-------------------------------------------------------------------------------------------------------------------//
        //----------------------------------- Stop button Click -------------------------------------------------------------//
        //-------------------------------------------------------------------------------------------------------------------//

        private void stopAdapter()
        {
            // Stop Axes Monitor Loop
            halt = true;
            connected = false;

            //server.CloseSession_C(hCndex, out errClass, out errNum);

            // Stop everything...
            reportProc1.mAdapter.Stop();

            if (dualProc.Checked)
            {
                reportProc2.mAdapter.Stop();
            }
            stop.Enabled = false;
            start.Enabled = true;
            gather.Enabled = false;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            stopAdapter();
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Gather Changed Info -----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void gather_Tick(object sender, EventArgs e)
        {

        }

        //------------------------------------------------------------------------------------------------------------------//
        //--------------------------------- Enable All Fields For Editing --------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public void editModeEnable()
        {
            machineGB.Enabled = true;
            axisGB.Enabled = true;
            processGB.Enabled = true;
            tablesGB.Enabled = true;
            cncField.Enabled = true;
            saveButton.Enabled = true;
            genXML.Enabled = true;
            model.Enabled = true;
            port.Enabled = true;
            port2.Enabled = true;
            hostname.Enabled = true;
            editMode.Enabled = false;
            editModeEnabled = true;
            axisP2GB.Enabled = true;
            toolChangerGB.Enabled = true;
            AxisNumGB.Enabled = true;
            xAxisID.Enabled = true;
            yAxisID.Enabled = true;
            zAxisID.Enabled = true;
            uAxisID.Enabled = true;
            aAxisID.Enabled = true;
            cAxisID.Enabled = true;
        }

        //-----------------------------------------------------------------------------------------------------------------//
        //--------------------------------- Save & Disable All Fields -----------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------------------//


        public void editModeDisable()
        {
            machineGB.Enabled = false;
            axisGB.Enabled = false;
            processGB.Enabled = false;
            tablesGB.Enabled = false;
            cncField.Enabled = false;
            genXML.Enabled = false;
            model.Enabled = false;
            port.Enabled = false;
            port2.Enabled = false;
            saveButton.Enabled = false;
            hostname.Enabled = false;
            editMode.Enabled = true;
            axisP2GB.Enabled = false;
            toolChangerGB.Enabled = false;
            AxisNumGB.Enabled = false;
            xAxisID.Enabled = false;
            yAxisID.Enabled = false;
            zAxisID.Enabled = false;
            uAxisID.Enabled = false;
            aAxisID.Enabled = false;
            cAxisID.Enabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------//
        //--------------------------------- Save Machine Setup ------------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------------------//

        public void saveSettings()
        {
            // Local Variables
            string[] saveBuffer = new string[24];

            // Hostname
            saveBuffer[0] = hostname.Text;

            // Store the port number
            saveBuffer[1] = port.Text;
            saveBuffer[2] = port2.Text;

            // Store CNC Name
            saveBuffer[3] = cncField.Text;

            // Store CNC Model
            saveBuffer[4] = model.Text;

            // Check Machine Type Configured
            if (gantry.Checked)
            {
                saveBuffer[5] = "MachineType=0";
            }
            else if (fixedBridge.Checked)
            {
                saveBuffer[5] = "MachineType=1";
            }

            // Check Number of Tables Configured
            if (singleTable.Checked)
            {
                saveBuffer[6] = "NumTables=0";
            }
            else if (dualTable.Checked)
            {
                saveBuffer[6] = "NumTables=1";
            }

            // Check Number Of Processes
            if (singleProc.Checked)
            {
                saveBuffer[7] = "NumProcesses=0";
            }
            else if (dualProc.Checked)
            {
                saveBuffer[7] = "numProcesses=1";
            }

            // Check Number Of Axes
            if (threeAxis.Checked)
            {
                saveBuffer[8] = "NumMachineAxesP1=3";
            }
            if (fourAxis.Checked)
            {
                saveBuffer[8] = "NumMachineAxesP1=4";
            }
            if (fiveAxis.Checked)
            {
                saveBuffer[8] = "NumMachineAxesP1=5";
            }

            // Check Number Of Axes
            if (threeAxisP2.Checked)
            {
                saveBuffer[9] = "NumMachineAxesP2=3";
            }
            if (fourAxisP2.Checked)
            {
                saveBuffer[9] = "NumMachineAxesP2=4";
            }
            if (fiveAxisP2.Checked)
            {
                saveBuffer[9] = "NumMachineAxesP2=5";
            }

            if (!gifu.Checked)
            {
                saveBuffer[10] = "ToolChanger=1";
            }
            else
            {
                saveBuffer[10] = "ToolChanger=2";
            }

            saveBuffer[11] = "xAxisID=" + xAxisID.Text;
            saveBuffer[12] = "yAxisID=" + yAxisID.Text;
            saveBuffer[13] = "zAxisID=" + zAxisID.Text;
            saveBuffer[14] = "uAxisID=" + uAxisID.Text;
            saveBuffer[15] = "aAxisID=" + aAxisID.Text;
            saveBuffer[16] = "cAxisID=" + cAxisID.Text;

            saveBuffer[17] = "xAxis2ID=" + xAxisID.Text;
            saveBuffer[18] = "yAxis2ID=" + yAxisID.Text;
            saveBuffer[19] = "zAxis2ID=" + zAxisID.Text;
            saveBuffer[20] = "uAxis2ID=" + uAxisID.Text;
            saveBuffer[21] = "aAxis2ID=" + aAxisID.Text;
            saveBuffer[22] = "cAxis2ID=" + cAxisID.Text;

            saveBuffer[23] = "MachineName=" + cncName.Text;

            //saveBuffer[17] = "DownTime=" + dt.totalElapsed;

            // Write all the variables to the ini
            File.WriteAllLines("settings.ini", saveBuffer);
        }

        //-----------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Load Machine Setup -----------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------------------//

        private void loadSettings()
        {
            // Check to see if an INI has been created
            if (File.Exists("settings.ini"))
            {
                // Load the file into the Buffer
                string[] loadBuffer = File.ReadAllLines("settings.ini");

                if (loadBuffer.Length > 10)
                {
                    // Load Hostname
                    this.hostname.Text = loadBuffer[0];

                    // Load Port Numbers
                    this.port.Text = loadBuffer[1];
                    this.port2.Text = loadBuffer[2];

                    // Load the CNC IP
                    this.cncField.Text = loadBuffer[3];

                    // Load CNC Model
                    this.model.Text = loadBuffer[4];

                    // Check Macine Type (Gantry / Fixed Bridge)
                    if (loadBuffer[5] == "MachineType=0")
                    {
                        gantry.Checked = true;
                    }
                    else if (loadBuffer[5] == "MachineType=1")
                    {
                        fixedBridge.Checked = true;
                    }
                    else if (loadBuffer[5] == "MachineType=2")
                    {
                        highRail.Checked = true;
                    }


                    // Check the number of tables
                    if (loadBuffer[6] == "NumTables=0")
                    {
                        singleTable.Checked = true;
                    }
                    else
                    {
                        dualTable.Checked = true;
                    }

                    // Check the number of processes P1
                    if (loadBuffer[7] == "NumProcesses=0")
                    {
                        singleProc.Checked = true;
                    }
                    else
                    {
                        dualProc.Checked = true;
                    }

                    // Check the number of machine axes
                    if (loadBuffer[8] == "NumMachineAxesP1=3")
                    {
                        threeAxis.Checked = true;
                    }
                    else if (loadBuffer[8] == "NumMachineAxesP1=4")
                    {
                        fourAxis.Checked = true;
                    }
                    else
                    {
                        fiveAxis.Checked = true;
                    }

                    // Check the number of machine axes P2
                    if (loadBuffer[9] == "NumMachineAxesP2=3")
                    {
                        threeAxisP2.Checked = true;
                    }
                    else if (loadBuffer[9] == "NumMachineAxesP2=4")
                    {
                        fourAxisP2.Checked = true;
                    }
                    else
                    {
                        fiveAxisP2.Checked = true;
                    }

                    if (loadBuffer[10] == "ToolChanger=1")
                    {
                        rotary12.Checked = true;
                    }
                    else
                    {
                        gifu.Checked = true;
                    }

                    char[] delim = { '=' };
                    string[] ids = loadBuffer[11].Split(delim);
                    xAxisID.Text = ids[1];
                    ids = loadBuffer[12].Split(delim);
                    yAxisID.Text = ids[1];
                    ids = loadBuffer[13].Split(delim);
                    zAxisID.Text = ids[1];
                    ids = loadBuffer[14].Split(delim);
                    uAxisID.Text = ids[1];
                    ids = loadBuffer[15].Split(delim);
                    aAxisID.Text = ids[1];
                    ids = loadBuffer[16].Split(delim);
                    cAxisID.Text = ids[1];
                    ids = loadBuffer[17].Split(delim);
                    xAxis2ID.Text = ids[1];
                    ids = loadBuffer[18].Split(delim);
                    yAxis2ID.Text = ids[1];
                    ids = loadBuffer[19].Split(delim);
                    zAxis2ID.Text = ids[1];
                    ids = loadBuffer[20].Split(delim);
                    uAxis2ID.Text = ids[1];
                    ids = loadBuffer[21].Split(delim);
                    aAxis2ID.Text = ids[1];
                    ids = loadBuffer[22].Split(delim);
                    cAxis2ID.Text = ids[1];

                    string[] machName = loadBuffer[23].Split(delim);
                    if (machName[1] != string.Empty)
                        cncName.Text = machName[1];



                    //double dTime = Convert.ToDouble(loadBuffer[17].Split(delim));

                }
                else
                {
                    MessageBox.Show("Unable to load settings. File may be incomplete or corrupt!");
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Save Button Click ------------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------------------//

        private void saveButton_Click(object sender, EventArgs e)
        {
            var confirmSave = MessageBox.Show("Are you sure you want to save this configuration?", "Save", MessageBoxButtons.YesNo);
            if (confirmSave == DialogResult.Yes)
            {
                saveSettings();
                editModeDisable();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Dual Proc Check Changed ------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------------------//

        private void dualProc_CheckedChanged(object sender, EventArgs e)
        {
            if (dualProc.Checked && editModeEnabled == true)
            {
                port2.Enabled = true;
                axisP2GB.Enabled = true;
                uAxisID.Enabled = false;
            }
            else
            {
                port2.Enabled = false;
                axisP2GB.Enabled = false;
                uAxisID.Enabled = true;
            }
        }


        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Create Devices.XML ------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void genXML_Click(object sender, EventArgs e)
        {
            // Create an instance of WriteXML
            WriteXML xml1 = new WriteXML(this);

            // MessageBox asking to to generate new XML and CFG files
            var confirmSave = MessageBox.Show("This will Generate an XML file for the current configuration. Would you like to continue?", "Generate XML", MessageBoxButtons.YesNo);
            if (confirmSave == DialogResult.Yes)
            {
                // Check if Dual Process
                if (dualProc.Checked)
                {
                    string[] buffer = new string[9];
                    string[] buffer2 = new string[2];
                    // Call the functions to write the XML and CFG for P1 and P2
                    xml1.proc1(buffer);
                    xml1.proc2(buffer);
                    xml1.agentCFG(buffer2);

                    // Check to see if directory exists and write all lines to the files
                    if (Directory.Exists("./agent/bin"))
                    {
                        File.WriteAllLines(@"./agent/bin/Devices.xml", buffer);
                        File.WriteAllLines(@"./agent/bin/agent.cfg", buffer2);
                    }
                    else
                    {
                        MessageBox.Show("Directory /agnet/bin does not exist!", "Error");
                    }
                    // Ask to save the configuration to settings.ini
                    var askSave = MessageBox.Show("Configuration files have been written! Would you like to save the current configuration?", "Save", MessageBoxButtons.YesNo);
                    if (askSave == DialogResult.Yes)
                    {
                        saveSettings();
                        editModeDisable();
                    }
                }
                else
                {
                    // If the machine is single process
                    string[] buffer = new string[6];
                    string[] buffer2 = new string[2];
                    // Call the functions to generate the XML and CFG for P1 only
                    xml1.proc1(buffer);
                    xml1.agentCFG(buffer2);

                    // Check to see if the directory exists
                    if (Directory.Exists("./agent/bin"))
                    {
                        File.WriteAllLines(@"./agent/bin/Devices.xml", buffer);
                        File.WriteAllLines(@"./agent/bin/agent.cfg", buffer2);
                    }
                    else
                    {
                        MessageBox.Show("Directory /agent/bin does not exist!", "Error");
                    }
                    // ask to save the current configuration to settings.ini
                    var askSave = MessageBox.Show("Configuration files have been written! Would you like to save the current configuration?", "Save", MessageBoxButtons.YesNo);
                    if (askSave == DialogResult.Yes)
                    {
                        saveSettings();
                        editModeDisable();
                    }

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Form Closing Event ------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Stop Axes Monitor Loop
            if (!start.Enabled)
            {
                halt = true;
                connected = false;

                // Stop everything...
                reportProc1.mAdapter.Stop();

                if (dualProc.Checked)
                {
                    reportProc2.mAdapter.Stop();
                }
            }
            gather.Enabled = false;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- OnResize Event ----------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void OnResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, "O-Sync", "Double click to open", ToolTipIcon.None);
            }
            if (WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Notfiy Icon Functions ---------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.BringToFront();
                contextMenu.Show(Cursor.Position.X, Cursor.Position.Y - 110);
            }
            
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Edit Mode Button Click --------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void editMode_Click(object sender, EventArgs e)
        {
            password password = new password(this);
            password.Show();
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Validate Axis ID's ------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private bool validateAxisIDS()
        {
            short xID, yID, zID, aID, cID, uID, portOne, portTwo;
           
            try
            {
                if (xAxisID.Text != "-")
                    xID = Convert.ToInt16(xAxisID.Text);
                if (yAxisID.Text != "-")
                    yID = Convert.ToInt16(xAxisID.Text);
                if (zAxisID.Text != "-")
                    zID = Convert.ToInt16(zAxisID.Text);
                if (aAxisID.Text != "-")
                    aID = Convert.ToInt16(aAxisID.Text);
                if (cAxisID.Text != "-")
                    cID = Convert.ToInt16(cAxisID.Text);
                if (uAxisID.Text != "-")
                    uID = Convert.ToInt16(uAxisID.Text);
                portOne = Convert.ToInt16(port.Text);
                if (port2.Text != "----")
                portTwo = Convert.ToInt16(port2.Text);
            }
            catch
            {
                MessageBox.Show("Axis ID's & port numbers must be a valid number", "Error");
                return false;
            }
            return true;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Four Axis Radio Button --------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void fourAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (fourAxis.Checked)
            {
                cAxisID.Enabled = true;
                aAxisID.Enabled = false;
                aAxisID.Text = "-";
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Five Axis Button Checked ------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void fiveAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (fiveAxis.Checked)
            {
                aAxisID.Enabled = true;
                cAxisID.Enabled = true;
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Three Axis Button Checked -----------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void threeAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (threeAxis.Checked)
            {
                aAxisID.Enabled = false;
                cAxisID.Enabled = false;
                aAxisID.Text = "-";
                cAxisID.Text = "-";
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- CNC Name Changed --------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void cncName_TextChanged(object sender, EventArgs e)
        {
            nickName = cncName.Text;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- High Rail Radio Button --------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void highRail_CheckedChanged(object sender, EventArgs e)
        {
            if (highRail.Checked)
            {
                highRailChecked = true;
                gantryChecked = false;
                fixedBridgeChecked = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Fixed Brdige Radio Button -----------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void fixedBridge_CheckedChanged(object sender, EventArgs e)
        {
            if (highRail.Checked)
            {
                highRailChecked = false;
                gantryChecked = false;
                fixedBridgeChecked = true;
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Gantry Radio Button -----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void gantry_CheckedChanged(object sender, EventArgs e)
        {
            if (highRail.Checked)
            {
                highRailChecked = false;
                gantryChecked = true;
                fixedBridgeChecked = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Form Load Event ---------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void MachineTool_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            GetRegKeys();
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Popup Menu Item Exit ----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Start Popup Menu --------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startAdapter();
            start.Enabled = false;
            stop.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;
            restartToolStripMenuItem.Enabled = true;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Popup Menu Item Stop ----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopAdapter();
            start.Enabled = true;
            stop.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            restartToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = true;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Popup Menu Item Restart -------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (start.Enabled)
            {
                stopAdapter();
                startAdapter();
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Popup Menu Item Open ------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        public void GetRegKeys()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");

            String[] Key = rk.GetSubKeyNames();


            if (File.Exists(@"C:\DB\regkeys.txt"))
            {
                string[] bufferRegKeys = File.ReadAllLines(@"C:\DB\regkeys.txt");

                if (bufferRegKeys.Length != Key.Length)
                {
                    // If there are less saved keys than there are new keys
                    // Then a program has been added. We will find out how
                    // Many programs have been installed on the machine
                    if (bufferRegKeys.Length < Key.Length)
                    {
                        int valueDifference = Key.Length - bufferRegKeys.Length;
                        string[] newKeyName = new string[valueDifference];

                        for (int count = 0; Key.Length < count; count++)
                        {
                            int newKeyCount = 0;
                            if (bufferRegKeys[count] != Key[count])
                            {
                                newKeyName[newKeyCount] = Key[count - newKeyCount];
                                newKeyCount++;
                            }
                        }
                        File.WriteAllLines(@"C:\DB\regkeys.txt", Key);
                        File.WriteAllLines(@"C:\DB\addedRegkeys.txt", newKeyName);
                    }

                    if (bufferRegKeys.Length > Key.Length)
                    {
                        int valueDifference = bufferRegKeys.Length - Key.Length;
                        string[] delKeyName = new string[valueDifference];

                        for (int count = 0; Key.Length < count; count++)
                        {
                            int delKeyCount = 0;
                            if (bufferRegKeys[count] != Key[count])
                            {
                                delKeyName[delKeyCount] = Key[count + delKeyCount];
                                delKeyCount++;
                            }
                        }
                        File.WriteAllLines(@"C:\DB\regkeys.txt", Key);
                        File.WriteAllLines(@"C:\DB\addedRegkeys.txt", delKeyName);
                    }
                }

            }

            if (!File.Exists(@"C:\DB\regkeys.txt"))
            {
                // File.WriteAllLines(@"C:\DB\regkeys.txt", Key);
                StreamWriter file = new StreamWriter(@"C:\DB\regkeys.txt");

                foreach (String subKey in rk.GetSubKeyNames())
                {
                    file.WriteLine(rk.OpenSubKey(subKey).GetValue(@"DisplayName"));
                }

            }
        }
    }
}



