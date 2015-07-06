using System;
using System.Threading;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace AdapterLab
{
    using MTConnect;
    public class Report
    {
        

        private MachineTool machineTool;

        public Adapter mAdapter = new Adapter();
        public Event mAvail = new Event("avail");

        // Events
        public Event mProcess = new Event("proc");
        public Event mSelProc = new Event("selected_proc");
        public Event mMode = new Event("mode");
        public Event mProgram = new Event("program");
        public Event mSubProgram = new Event("subprogram");
        public Event mActiveTool = new Event("tool");
        public Event mActiveLine = new Event("line");
        public Event mBlkNum = new Event("block");
        public Event mFeedOv = new Event("feed_ov");
        public Event mSpeedOv = new Event("speed_ov");
        public Event mRapidOv = new Event("rapid_ov");
        public Event mPrgFeed = new Event("prgm_feed");
        public Event mPrgSpeed = new Event("prgm_speed");
        public Event mRealFeed = new Event("real_feed");
        public Event mRealSpeed = new Event("real_speed");
        public Event mRapidFeed = new Event("rapid_feed");
        public Event mSelTable = new Event("selected_table");
        public Event mCycleTime = new Event("cycle_time");
        public Event mCutTime = new Event("cut_time");
        public Event mOpTime = new Event("op_time");
        public Event mDrivesReady = new Event("drives_ready");
        public Event mDrivesOn = new Event("drives_on");
        public Event mDownTimeDuration = new Event("down_time_duration");
        public Event mLastDownTimeDuration = new Event("last_down_time_duration");
        public Event mDTReason = new Event("down_time_reason");
        public Event mDTLastReason = new Event("last_down_time_reason");
       
        // Op Messages
        public Event mOpMsg1 = new Event("op_msg1");
        public Event mOpMsg2 = new Event("op_msg2");
        public Event mOpMsg3 = new Event("op_msg3");
        public Event mOpMsg4 = new Event("op_msg4");

        // Alarms
        public Event mAlarm1 = new Event("alarm_1");
        public Event mAlarm2 = new Event("alarm_2");
        public Event mAlarm3 = new Event("alarm_3");
        public Event mAlarm4 = new Event("alarm_4");
        public Event mAlarm5 = new Event("alarm_5");
        public Event mAlarm6 = new Event("alarm_6");
        public Event mAlarm7 = new Event("alarm_7");
        public Event mAlarm8 = new Event("alarm_8");
        public Event mAlarm9 = new Event("alarm_9");
        public Event mAlarm10 = new Event("alarm_10");

        // Axis Absolute Position Variables
        public Sample xmPos = new Sample("xAct_pos");
        public Sample yPos = new Sample("yAct_pos");
        public Sample uPos = new Sample("uAct_pos");
        public Sample zPos = new Sample("zAct_pos");
        public Sample aPos = new Sample("aAct_pos");
        public Sample cPos = new Sample("cAct_pos");

        // Axis Work Position Variables
        public Sample xWPos = new Sample("xWork_pos");
        public Sample yWPos = new Sample("yWork_pos");
        public Sample uWPos = new Sample("uWork_pos");
        public Sample zWPos = new Sample("zWork_pos");
        public Sample aWPos = new Sample("aWork_pos");
        public Sample cWPos = new Sample("cWork_pos");

        // Axis Programmed Position Variables
        public Sample xCPos = new Sample("xCmd_pos");
        public Sample yCPos = new Sample("yCmd_pos");
        public Sample uCPos = new Sample("uCmd_pos");
        public Sample zCPos = new Sample("zCmd_pos");
        public Sample aCPos = new Sample("aCmd_pos");
        public Sample cCPos = new Sample("cCmd_pos");

        // Axis Motor Loads
        public Sample xMotorLoad = new Sample("xMotorLoad");
        public Sample yMotorLoad = new Sample("yMotorLoad");
        public Sample zMotorLoad = new Sample("zMotorLoad");
        public Sample uMotorLoad = new Sample("uMotorLoad");
        public Sample aMotorLoad = new Sample("aMotorLoad");
        public Sample cMotorLoad = new Sample("cMotorLoad");

        public Sample xMotorLoadAvg = new Sample("xMotorLoad_Avg");
        public Sample yMotorLoadAvg = new Sample("yMotorLoad_Avg");
        public Sample zMotorLoadAvg = new Sample("zMotorLoad_Avg");
        public Sample uMotorLoadAvg = new Sample("uMotorLoad_Avg");
        public Sample aMotorLoadAvg = new Sample("aMotorLoad_Avg");
        public Sample cMotorLoadAvg = new Sample("cMotorLoad_Avg");

        public Sample xMotorLoadPeak = new Sample("xMotorLoad_Peak");
        public Sample yMotorLoadPeak = new Sample("yMotorLoad_Peak");
        public Sample zMotorLoadPeak = new Sample("zMotorLoad_Peak");
        public Sample uMotorLoadPeak = new Sample("uMotorLoad_Peak");
        public Sample aMotorLoadPeak = new Sample("aMotorLoad_Peak");
        public Sample cMotorLoadPeak = new Sample("cMotorLoad_Peak");

        public Sample xMotorTemp = new Sample("xMotorTemp");
        public Sample yMotorTemp = new Sample("xMotorTemp");
        public Sample zMotorTemp = new Sample("xMotorTemp");
        public Sample aMotorTemp = new Sample("xMotorTemp");
        public Sample cMotorTemp = new Sample("xMotorTemp");
        public Sample uMotorTemp = new Sample("xMotorTemp");

        public Sample xMotorPulseTemp = new Sample("xMotorPulseTemp");
        public Sample yMotorPulseTemp = new Sample("xMotorPulseTemp");
        public Sample zMotorPulseTemp = new Sample("xMotorPulseTemp");
        public Sample aMotorPulseTemp = new Sample("xMotorPulseTemp");
        public Sample cMotorPulseTemp = new Sample("xMotorPulseTemp");
        public Sample uMotorPulseTemp = new Sample("xMotorPulseTemp");

        public Sample xMotorVoltage = new Sample("xVoltage");
        public Sample yMotorVoltage = new Sample("xVoltage");
        public Sample zMotorVoltage = new Sample("xVoltage");
        public Sample aMotorVoltage = new Sample("xVoltage");
        public Sample cMotorVoltage = new Sample("xVoltage");
        public Sample uMotorVoltage = new Sample("xVoltage");


        //public Condition mWarning = new Condition("warning");
        //public Condition mAnomoly = new Condition("anomoly");
        //public Condition mFault = new Condition("fault");


        // Fanuc Path Number
        private short path = 0;
        private short maxPath = 2;

        // Cndex Error Lines
        public string errLine1 = "";
        public string errLine2 = "";
        public string errLine3 = "";
        public string errLine4 = "";

        // Cndex Warning
        public string warningmsg = "";

        // Main Program
        Focas1.ODBEXEPRG mainProgram = new Focas1.ODBEXEPRG();
        Focas1.ODBPRO subProgram = new Focas1.ODBPRO();

        // Timers
        Focas1.IODBTIME cycleTime = new Focas1.IODBTIME();
        Focas1.IODBTIME opTime = new Focas1.IODBTIME();
        Focas1.IODBTIME cuttingTime = new Focas1.IODBTIME();

        Focas1.IODBPSD_1 cycTimeMin = new Focas1.IODBPSD_1();
        Focas1.IODBPSD_1 cycTimeSec = new Focas1.IODBPSD_1();

        // Active Program Lines
        public string line1 = "";
        public string line2 = "";
        public string line3 = "";
        public string line4 = "";
        public string line5 = "";
        public string line6 = "";
        public string line7 = "";
        public string line8 = "";

        // Active Program Blk
        ushort length = 50;
        short blkNum = 0;
        char[] lineData = new char[49];
        string currentLine = string.Empty;
        string lastLine = string.Empty;

        // Axes Positions
        //private string xAbsPos = "";

        // Tool Info
        short addrType = 0;
        short dataType = 0;
        ushort dataLength = 16;
        ushort toolData = 276;
        Focas1.IODBPMC0 pmcData = new Focas1.IODBPMC0();

        // Alarm Variables
        short alarmNum = 10;
        public string[] alarm = new string[10];
        public string[] alarmType = new string[10];
        public string[] alarmNumber = new string[10];
        Focas1.ODBALMMSG2 alarmMsg = new Focas1.ODBALMMSG2();

        // Overrides
        Focas1.IODBPMC0 pmcOverrides = new Focas1.IODBPMC0();
        int feedOverride = 0;
        int speedOverride = 0;
        int rapidOverride = 0;
        Focas1.IODBPMC0 pmcDrivesOn = new Focas1.IODBPMC0();

        // Recording
        List<List<string>> buffer = new List<List<string>>();
        List<List<string>> dtBufferItems = new List<List<string>>();
        private bool bufferDumped = false;
        private const short BUFFER_SIZE = 100;
        WriteToDB writeDB;
        int index;
        bool driveReady = false;
        bool drivesOn = false;
        bool extraCycle = false;


        // Axis Positions
        Focas1.ODBAXIS absAxisX = new Focas1.ODBAXIS();
        Focas1.ODBAXIS absAxisY = new Focas1.ODBAXIS();
        Focas1.ODBAXIS absAxisZ = new Focas1.ODBAXIS();
        Focas1.ODBAXIS absAxisC = new Focas1.ODBAXIS();
        Focas1.ODBAXIS absAxisA = new Focas1.ODBAXIS();
        Focas1.ODBAXIS absAxisU = new Focas1.ODBAXIS();

        Focas1.ODBAXIS wrkAxisX = new Focas1.ODBAXIS();
        Focas1.ODBAXIS wrkAxisY = new Focas1.ODBAXIS();
        Focas1.ODBAXIS wrkAxisZ = new Focas1.ODBAXIS();
        Focas1.ODBAXIS wrkAxisC = new Focas1.ODBAXIS();
        Focas1.ODBAXIS wrkAxisA = new Focas1.ODBAXIS();
        Focas1.ODBAXIS wrkAxisU = new Focas1.ODBAXIS();

        Focas1.ODBAXIS distToGoXmAxis = new Focas1.ODBAXIS();
        Focas1.ODBAXIS distToGoYAxis = new Focas1.ODBAXIS();
        Focas1.ODBAXIS distToGoZAxis = new Focas1.ODBAXIS();
        Focas1.ODBAXIS distToGoCAxis = new Focas1.ODBAXIS();
        Focas1.ODBAXIS distToGoAAxis = new Focas1.ODBAXIS();
        Focas1.ODBAXIS distToGoUAxis = new Focas1.ODBAXIS();

        // Motor Loads
        short numAxis = 8;
        Focas1.ODBSVLOAD motorLoad = new Focas1.ODBSVLOAD();
        private int[] xSamples = new int[50];
        private int[] ySamples = new int[50];
        private int[] zSamples = new int[50];
        private int[] aSamples = new int[50];
        private int[] cSamples = new int[50];
        private int[] uSamples = new int[50];
        public int xAvgLoad = -1;
        public int yAvgLoad = -1;
        public int zAvgLoad = -1;
        public int aAvgLoad = -1;
        public int cAvgLoad = -1;
        public int uAvgLoad = -1;
        public int xPeakLoad = 0;
        public int yPeakLoad = 0;
        public int zPeakLoad = 0;
        public int aPeakLoad = 0;
        public int cPeakLoad = 0;
        public int uPeakLoad = 0;
        private short sampleIndex = 0;

        // Axis Temps
        short typeBitValue = 0;

        // Downtime
        downTime dt;
        static double totalElapsedDT = 0;
        bool reasonSet = false; // Has this downtime already started a timer and asked for a reason?
        string startTime = string.Empty;
        string endTime = string.Empty;
        string duration = string.Empty;
        bool dtBuffer = false;



        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Constructor -------------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public Report(MachineTool machineTool)
        {
            this.machineTool = machineTool;
            writeDB = new WriteToDB(this);
            dt = new downTime(this);

            Focas1.ODBDIAGIF attribType = new Focas1.ODBDIAGIF();

            int[] typeBits = GetBit(attribType.info.info1.diag_type, 1, 2);
            if (typeBits[0] == 0 && typeBits[1] == 0)
                typeBitValue = 5;
            if (typeBits[0] == 0 && typeBits[1] == 1)
                typeBitValue = 6;
            if (typeBits[0] == 1 && typeBits[1] == 0)
                typeBitValue = 8;
            if (typeBits[0] == 1 && typeBits[1] == 1)
                typeBitValue = 12;

            mAdapter.AddDataItem(mAvail);
            mAdapter.AddDataItem(mSelProc);
            mAdapter.AddDataItem(mMode);
            mAdapter.AddDataItem(mSelTable);
            mAdapter.AddDataItem(mProgram);
            mAdapter.AddDataItem(mSubProgram);
            mAdapter.AddDataItem(mBlkNum);
            mAdapter.AddDataItem(mActiveLine);
            mAdapter.AddDataItem(mActiveTool);
            mAdapter.AddDataItem(mFeedOv);
            mAdapter.AddDataItem(mSpeedOv);
            mAdapter.AddDataItem(mRapidOv);
            mAdapter.AddDataItem(mPrgFeed);
            mAdapter.AddDataItem(mPrgSpeed);
            mAdapter.AddDataItem(mRealFeed);
            mAdapter.AddDataItem(mRealSpeed);
            //mAdapter.AddDataItem(mFault);
            mAdapter.AddDataItem(mCycleTime);
            mAdapter.AddDataItem(mCutTime);
            mAdapter.AddDataItem(mOpTime);
            mAdapter.AddDataItem(mDrivesReady);
            mAdapter.AddDataItem(mDrivesOn);
            mAdapter.AddDataItem(mDownTimeDuration);
            mAdapter.AddDataItem(mLastDownTimeDuration);
            mAdapter.AddDataItem(mDTReason);
            mAdapter.AddDataItem(mDTLastReason);

            // Axis Position
            mAdapter.AddDataItem(xmPos);
            mAdapter.AddDataItem(xWPos);
            mAdapter.AddDataItem(xCPos);

            mAdapter.AddDataItem(yPos);
            mAdapter.AddDataItem(yWPos);
            mAdapter.AddDataItem(yCPos);

            mAdapter.AddDataItem(zPos);
            mAdapter.AddDataItem(zWPos);
            mAdapter.AddDataItem(zCPos);

            mAdapter.AddDataItem(aPos);
            mAdapter.AddDataItem(aWPos);
            mAdapter.AddDataItem(aCPos);


            mAdapter.AddDataItem(uPos);
            mAdapter.AddDataItem(uWPos);
            mAdapter.AddDataItem(uCPos);


            mAdapter.AddDataItem(cPos);
            mAdapter.AddDataItem(cWPos);
            mAdapter.AddDataItem(cCPos);



            // Motor Loads
            mAdapter.AddDataItem(xMotorLoad);
            mAdapter.AddDataItem(yMotorLoad);
            mAdapter.AddDataItem(zMotorLoad);
            mAdapter.AddDataItem(aMotorLoad);
            mAdapter.AddDataItem(uMotorLoad);
            mAdapter.AddDataItem(cMotorLoad);

            mAdapter.AddDataItem(xMotorLoadAvg);
            mAdapter.AddDataItem(yMotorLoadAvg);
            mAdapter.AddDataItem(zMotorLoadAvg);
            mAdapter.AddDataItem(aMotorLoadAvg);
            mAdapter.AddDataItem(uMotorLoadAvg);
            mAdapter.AddDataItem(cMotorLoadAvg);

            mAdapter.AddDataItem(xMotorLoadPeak);
            mAdapter.AddDataItem(yMotorLoadPeak);
            mAdapter.AddDataItem(zMotorLoadPeak);
            mAdapter.AddDataItem(aMotorLoadPeak);
            mAdapter.AddDataItem(uMotorLoadPeak);
            mAdapter.AddDataItem(cMotorLoadPeak);

            // Motor Temps
            mAdapter.AddDataItem(xMotorTemp);
            mAdapter.AddDataItem(yMotorTemp);
            mAdapter.AddDataItem(zMotorTemp);
            mAdapter.AddDataItem(aMotorTemp);
            mAdapter.AddDataItem(cMotorTemp);
            mAdapter.AddDataItem(uMotorTemp);

            // Pulse Temps
            mAdapter.AddDataItem(xMotorPulseTemp);
            mAdapter.AddDataItem(yMotorPulseTemp);
            mAdapter.AddDataItem(zMotorPulseTemp);
            mAdapter.AddDataItem(aMotorPulseTemp);
            mAdapter.AddDataItem(cMotorPulseTemp);
            mAdapter.AddDataItem(uMotorPulseTemp);

            // Voltages
            mAdapter.AddDataItem(xMotorVoltage);
            mAdapter.AddDataItem(yMotorVoltage);
            mAdapter.AddDataItem(zMotorVoltage);
            mAdapter.AddDataItem(aMotorVoltage);
            mAdapter.AddDataItem(cMotorVoltage);
            mAdapter.AddDataItem(uMotorVoltage);

            // Op Messages
            mAdapter.AddDataItem(mOpMsg1);
            mAdapter.AddDataItem(mOpMsg2);
            mAdapter.AddDataItem(mOpMsg3);
            mAdapter.AddDataItem(mOpMsg4);

            // Alarms
            mAdapter.AddDataItem(mAlarm1);
            mAdapter.AddDataItem(mAlarm2);
            mAdapter.AddDataItem(mAlarm3);
            mAdapter.AddDataItem(mAlarm4);
            mAdapter.AddDataItem(mAlarm5);
            mAdapter.AddDataItem(mAlarm6);
            mAdapter.AddDataItem(mAlarm7);
            mAdapter.AddDataItem(mAlarm8);
            mAdapter.AddDataItem(mAlarm9);
            mAdapter.AddDataItem(mAlarm10);
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get Axes Positions ------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public void getAxesPos(MachineTool machineTool, ushort hFanucAxes)
        {
            
            // Absolute Axis
            Focas1.cnc_absolute2(hFanucAxes, machineTool.axisXmNum, 8, absAxisX); // X
            Focas1.cnc_absolute2(hFanucAxes, machineTool.axisYNum, 8, absAxisY); // Y
            Focas1.cnc_absolute2(hFanucAxes, machineTool.axisZNum, 8, absAxisZ); // Z

            // Work Axis
            Focas1.cnc_relative2(hFanucAxes, machineTool.axisXmNum, 8, wrkAxisX);
            Focas1.cnc_relative2(hFanucAxes, machineTool.axisYNum, 8, wrkAxisY);
            Focas1.cnc_relative2(hFanucAxes, machineTool.axisZNum, 8, wrkAxisZ);

            //Random rndm = new Random();*/
            xmPos.Value = absAxisX.data[0].ToString();
            yPos.Value = absAxisY.data[0].ToString();
            zPos.Value = absAxisZ.data[0].ToString();

            xWPos.Value = wrkAxisX.data[0].ToString();
            yWPos.Value = wrkAxisY.data[0].ToString();
            zWPos.Value = wrkAxisZ.data[0].ToString();

            // Get the Axis Temps
            Focas1.ODBDGN_1 axisXTemp = new Focas1.ODBDGN_1();
            Focas1.ODBDGN_1 axisYTemp = new Focas1.ODBDGN_1();
            Focas1.ODBDGN_1 axisZTemp = new Focas1.ODBDGN_1();

            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 308, machineTool.axisXmNum, typeBitValue, axisXTemp);
            xMotorTemp.Value = axisXTemp.ldata.ToString();
            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 308, machineTool.axisYNum, typeBitValue, axisYTemp);
            yMotorTemp.Value = axisYTemp.ldata.ToString();
            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 308, machineTool.axisZNum, typeBitValue, axisZTemp);
            zMotorTemp.Value = axisZTemp.ldata.ToString();

            // Axis Pulse Temps
            Focas1.ODBDGN_1 axisXPulseTemp = new Focas1.ODBDGN_1();
            Focas1.ODBDGN_1 axisYPulseTemp = new Focas1.ODBDGN_1();
            Focas1.ODBDGN_1 axisZPulseTemp = new Focas1.ODBDGN_1();

            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 309, machineTool.axisXmNum, typeBitValue, axisXPulseTemp);
            xMotorPulseTemp.Value = axisXPulseTemp.ldata.ToString();
            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 309, machineTool.axisYNum, typeBitValue, axisYPulseTemp);
            yMotorPulseTemp.Value = axisYPulseTemp.ldata.ToString();
            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 309, machineTool.axisZNum, typeBitValue, axisZPulseTemp);
            zMotorPulseTemp.Value = axisZPulseTemp.ldata.ToString();

            // Axis Voltages
            Focas1.ODBDGN_1 axisXVoltage = new Focas1.ODBDGN_1();
            Focas1.ODBDGN_1 axisYVoltage = new Focas1.ODBDGN_1();
            Focas1.ODBDGN_1 axisZVoltage = new Focas1.ODBDGN_1();

            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 752, machineTool.axisXmNum, typeBitValue, axisXVoltage);
            xMotorVoltage.Value = axisXVoltage.ldata.ToString();
            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 752, machineTool.axisYNum, typeBitValue, axisYVoltage);
            yMotorVoltage.Value = axisYVoltage.ldata.ToString();
            Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 752, machineTool.axisZNum, typeBitValue, axisZVoltage);
            zMotorVoltage.Value = axisZVoltage.ldata.ToString();


            // Motor Loads
            //short numAxis = getConfiguredAxes(hFanucAxes);
            Focas1.cnc_rdsvmeter(hFanucAxes, ref numAxis, motorLoad);
            int[] axisMotorLoad = new int[numAxis];
            axisMotorLoad[0] = motorLoad.svload1.data;
            axisMotorLoad[1] = motorLoad.svload2.data;
            axisMotorLoad[2] = motorLoad.svload3.data;
            axisMotorLoad[3] = motorLoad.svload4.data;
            axisMotorLoad[4] = motorLoad.svload5.data;
            axisMotorLoad[5] = motorLoad.svload6.data;
            axisMotorLoad[6] = motorLoad.svload7.data;
            axisMotorLoad[7] = motorLoad.svload8.data;
           
            // X Axis Loads
            xMotorLoad.Value = axisMotorLoad[machineTool.axisXmNum - 1].ToString();
            if (drivesOn)
                xSamples[sampleIndex] = axisMotorLoad[machineTool.axisXmNum - 1];
            if (xSamples[49] != null)
                xMotorLoadAvg.Value = SampleMotorLoad(xAvgLoad, ref xSamples, ref xPeakLoad).ToString();
            
            // Y Axis Loads
            yMotorLoad.Value = axisMotorLoad[machineTool.axisYNum - 1].ToString();
            if (drivesOn)
                ySamples[sampleIndex] = axisMotorLoad[machineTool.axisYNum - 1];
            if (ySamples[49] != null)
                yMotorLoadAvg.Value = SampleMotorLoad(yAvgLoad, ref ySamples, ref yPeakLoad).ToString();
            
            // Z Axis Loads
            zMotorLoad.Value = axisMotorLoad[machineTool.axisZNum - 1].ToString();
            if (drivesOn)
                zSamples[sampleIndex] = axisMotorLoad[machineTool.axisZNum - 1];
            if (zSamples[49] != null)
                zMotorLoadAvg.Value = SampleMotorLoad(zAvgLoad, ref zSamples, ref zPeakLoad).ToString();

            // 4 Axis Machine Sampling (C Axis)
            if (machineTool.axis4 || machineTool.axis5)
            {
                Focas1.cnc_absolute2(hFanucAxes, machineTool.axisCNum, 8, absAxisC);
                Focas1.cnc_relative2(hFanucAxes, machineTool.axisCNum, 8, wrkAxisC);
                Focas1.ODBDGN_1 axisCTemp = new Focas1.ODBDGN_1();
                Focas1.ODBDGN_1 axisCPulseTemp = new Focas1.ODBDGN_1();
                Focas1.ODBDGN_1 axisCVoltage = new Focas1.ODBDGN_1();

                cPos.Value = absAxisC.data[0].ToString();
                cWPos.Value = wrkAxisC.data[0].ToString();
                cMotorLoad.Value = axisMotorLoad[machineTool.axisCNum - 1].ToString();
                if (drivesOn)
                    cSamples[sampleIndex] = axisMotorLoad[machineTool.axisCNum - 1];
                if (cSamples[49] != null)
                    cMotorLoadAvg.Value = SampleMotorLoad(cAvgLoad, ref cSamples, ref cPeakLoad).ToString();

                Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 308, machineTool.axisCNum, typeBitValue, axisCTemp);
                Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 309, machineTool.axisCNum, typeBitValue, axisCPulseTemp);
                Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 752, machineTool.axisCNum, typeBitValue, axisCVoltage);
                cMotorTemp.Value = axisCTemp.ldata.ToString();
            }
            // 5 Axis Machine Sampling (A Axis)
            if (machineTool.axis5)
            {
                Focas1.cnc_absolute2(hFanucAxes, machineTool.axisANum, 8, absAxisA);
                Focas1.cnc_relative2(hFanucAxes, machineTool.axisANum, 8, wrkAxisA);
                aPos.Value = absAxisA.data[0].ToString();
                aWPos.Value = wrkAxisA.data[0].ToString();
                aMotorLoad.Value = axisMotorLoad[machineTool.axisANum - 1].ToString();
                if (drivesOn)
                    aSamples[sampleIndex] = axisMotorLoad[machineTool.axisANum - 1];
                if (aSamples[49] != null)
                    aMotorLoadAvg.Value = SampleMotorLoad(aAvgLoad, ref aSamples, ref aPeakLoad).ToString();
                Focas1.ODBDGN_1 axisATemp = new Focas1.ODBDGN_1();
                Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 308, machineTool.axisANum, typeBitValue, axisATemp);
                aMotorTemp.Value = axisATemp.ldata.ToString();
            }

            // Fixed Bridge Dual Table Only (U Axis)
            if (machineTool.dualTableChecked && machineTool.fixedBridgeChecked)
            {
                Focas1.cnc_absolute2(hFanucAxes, machineTool.axisUNum, 8, absAxisU);
                Focas1.cnc_relative2(hFanucAxes, machineTool.axisUNum, 8, wrkAxisU);
                uPos.Value = absAxisU.data.ToString();
                uWPos.Value = wrkAxisU.data.ToString();
                uMotorLoad.Value = axisMotorLoad[machineTool.axisUNum - 1].ToString();
                if (drivesOn)
                    uSamples[sampleIndex] = axisMotorLoad[machineTool.axisUNum - 1];
                if (uSamples[49] != null)
                    uMotorLoadAvg.Value = SampleMotorLoad(uAvgLoad, ref uSamples, ref uPeakLoad).ToString();
                Focas1.ODBDGN_1 axisUTemp = new Focas1.ODBDGN_1();
                Focas1.cnc_diagnoss(machineTool.hFanucMonitor, 308, machineTool.axisUNum, typeBitValue, axisUTemp);
                uMotorTemp.Value = axisUTemp.ldata.ToString();
            }
            
            sampleIndex++;
            if (sampleIndex == 50)
            {
                sampleIndex = 0;
            }

        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get  Changed Values -----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public void getChangedValues(MachineTool machineTool)
        {
            mAdapter.Begin();

            // Display if machine is available
            if (machineTool.connected)
            {
                mAvail.Value = "AVAILABLE";

                // Display Active Process
                Focas1.cnc_getpath(machineTool.hFanucMonitor, out path, out maxPath);
                if (path == 1)
                {
                    mSelProc.Value = "1";
                }
                else if (path == 2)
                {
                    mSelProc.Value = "2";
                }

//--------------------------------------------------------------------------------------------------------------
                // Display Active Part Program & Sub-Program
                short ret2 = Focas1.cnc_rdexecprog(machineTool.hFanucMonitor, ref length, out blkNum, lineData);
                mBlkNum.Value = blkNum.ToString();
                mActiveLine.Value = GetProgramName(lineData, "\n");

//--------------------------------------------------------------------------------------------------------------
                Focas1.cnc_rdprgnum(machineTool.hFanucMonitor, subProgram);
                mSubProgram.Value = subProgram.data.ToString();

//--------------------------------------------------------------------------------------------------------------
                int ret = Focas1.cnc_exeprgname(machineTool.hFanucMonitor, mainProgram);
                //string progName = mainProgram.name.ToString();
                mProgram.Value = GetProgramName(mainProgram.name, "\0");

//--------------------------------------------------------------------------------------------------------------
                /*uint lineToReadFrom = 1;
                string progData = string.Empty;
                uint linesToRead = 5;
                uint charToRead = 100;

                Focas1.cnc_rdprogline2(machineTool.hFanucMonitor, mainProgram.o_num, lineToReadFrom, progData, ref linesToRead, ref charToRead);*/

//--------------------------------------------------------------------------------------------------------------
                // Display the current selected mode
                switch (machineTool.fanucStatus.aut)
                {
                    case 0:
                        {
                            mMode.Value = "MDI";
                            break;
                        }
                    case 1:
                        {
                            mMode.Value = "AUTO";
                            break;
                        }
                    case 3:
                        {
                            mMode.Value = "EDIT";
                            break;
                        }
                    case 4:
                        {
                            mMode.Value = "HAND WHEEL";
                            break;
                        }
                    case 5:
                        {
                            mMode.Value = "JOG";
                            break;
                        }
                    case 6:
                        {
                            mMode.Value = "TEACH JOG";
                            break;
                        }
                    case 7:
                        {
                            mMode.Value = "TEACH HANDLE";
                            break;
                        }
                    case 8:
                        {
                            mMode.Value = "INC FEED";
                            break;
                        }
                    case 9:
                        {
                            mMode.Value = "REFERENCE";
                            break;
                        }
                    case 10:
                        {
                            mMode.Value = "REMOTE";
                            break;
                        }
                }

//--------------------------------------------------------------------------------------------------------------
                // Currently Selected Table
                mSelTable.Value = 0;

//--------------------------------------------------------------------------------------------------------------
                // Current Active Tool
                if (machineTool.gifuChanger == false)
                {
                    Focas1.pmc_rdpmcrng(machineTool.hFanucMonitor, addrType, dataType, toolData, toolData, dataLength,
                        pmcData);
                    mActiveTool.Value = pmcData.cdata[0].ToString();
                }
                else
                {
                    Focas1.ODBM macroInfo = new Focas1.ODBM();
                    Focas1.cnc_rdmacro(machineTool.hFanucMonitor, 276, 10, macroInfo);
                    float toolNum = macroInfo.mcr_val / (10 ^ macroInfo.dec_val);
                    mActiveTool.Value = toolNum.ToString();
                }


//--------------------------------------------------------------------------------------------------------------
                // Display Alarms
                alarmNum = 10;
                ret = Focas1.cnc_rdalmmsg2(machineTool.hFanucMonitor, -1, ref alarmNum, alarmMsg);
                alarm[0] = alarmMsg.msg1.alm_msg;
                alarm[1] = alarmMsg.msg2.alm_msg;
                alarm[2] = alarmMsg.msg3.alm_msg;
                alarm[3] = alarmMsg.msg4.alm_msg;
                alarm[4] = alarmMsg.msg5.alm_msg;
                alarm[5] = alarmMsg.msg6.alm_msg;
                alarm[6] = alarmMsg.msg7.alm_msg;
                alarm[7] = alarmMsg.msg8.alm_msg;
                alarm[8] = alarmMsg.msg9.alm_msg;
                alarm[9] = alarmMsg.msg10.alm_msg;

                alarm[0] = alarm[0].Substring(0, alarmMsg.msg1.msg_len);
                alarm[1] = alarm[1].Substring(0, alarmMsg.msg2.msg_len);
                alarm[2] = alarm[2].Substring(0, alarmMsg.msg3.msg_len);
                alarm[3] = alarm[3].Substring(0, alarmMsg.msg4.msg_len);
                alarm[4] = alarm[4].Substring(0, alarmMsg.msg5.msg_len);
                alarm[5] = alarm[5].Substring(0, alarmMsg.msg6.msg_len);
                alarm[6] = alarm[6].Substring(0, alarmMsg.msg7.msg_len);
                alarm[7] = alarm[7].Substring(0, alarmMsg.msg8.msg_len);
                alarm[8] = alarm[8].Substring(0, alarmMsg.msg9.msg_len);
                alarm[9] = alarm[9].Substring(0, alarmMsg.msg10.msg_len);

                alarmType[0] = almType(alarmMsg.msg1.type);
                alarmType[1] = almType(alarmMsg.msg2.type);
                alarmType[2] = almType(alarmMsg.msg3.type);
                alarmType[3] = almType(alarmMsg.msg4.type);
                alarmType[4] = almType(alarmMsg.msg5.type);
                alarmType[5] = almType(alarmMsg.msg6.type);
                alarmType[6] = almType(alarmMsg.msg7.type);
                alarmType[7] = almType(alarmMsg.msg8.type);
                alarmType[8] = almType(alarmMsg.msg9.type);
                alarmType[9] = almType(alarmMsg.msg10.type);

                alarmNumber[0] = alarmMsg.msg1.alm_no.ToString() + ": ";
                alarmNumber[1] = alarmMsg.msg2.alm_no.ToString() + ": ";
                alarmNumber[2] = alarmMsg.msg3.alm_no.ToString() + ": ";
                alarmNumber[3] = alarmMsg.msg4.alm_no.ToString() + ": ";
                alarmNumber[4] = alarmMsg.msg5.alm_no.ToString() + ": ";
                alarmNumber[5] = alarmMsg.msg6.alm_no.ToString() + ": ";
                alarmNumber[6] = alarmMsg.msg7.alm_no.ToString() + ": ";
                alarmNumber[7] = alarmMsg.msg8.alm_no.ToString() + ": ";
                alarmNumber[8] = alarmMsg.msg9.alm_no.ToString() + ": ";
                alarmNumber[9] = alarmMsg.msg10.alm_no.ToString() + ": ";

                for (short i = 0; i < alarmType.Length; i++)
                {
                    if (alarmType[i] == "SW" && alarm[i].ToString() == string.Empty)
                    {
                        alarmType[i] = string.Empty;
                        alarm[i] = string.Empty;
                        alarmNumber[i] = string.Empty;
                    }
                }
                mAlarm1.Value = alarmType[0].ToString() + alarmNumber[0] + alarm[0].ToString();
                mAlarm2.Value = alarmType[1].ToString() + alarmNumber[1] + alarm[1].ToString();
                mAlarm3.Value = alarmType[2].ToString() + alarmNumber[2] + alarm[2].ToString();
                mAlarm4.Value = alarmType[3].ToString() + alarmNumber[3] + alarm[3].ToString();
                mAlarm5.Value = alarmType[4].ToString() + alarmNumber[4] + alarm[4].ToString();
                mAlarm6.Value = alarmType[5].ToString() + alarmNumber[5] + alarm[5].ToString();
                mAlarm7.Value = alarmType[6].ToString() + alarmNumber[6] + alarm[6].ToString();
                mAlarm8.Value = alarmType[7].ToString() + alarmNumber[7] + alarm[7].ToString();
                mAlarm9.Value = alarmType[8].ToString() + alarmNumber[8] + alarm[8].ToString();
                mAlarm10.Value = alarmType[9].ToString() + alarmNumber[9] + alarm[9].ToString();

//--------------------------------------------------------------------------------------------------------------
                // Clocks
                Focas1.cnc_rdparam(machineTool.hFanucMonitor, 6758, 0, 8, cycTimeMin);
                Focas1.cnc_rdparam(machineTool.hFanucMonitor, 6757, 0, 8, cycTimeSec);
                mCycleTime.Value = cycTimeMin.cdata.ToString() + "." + (cycTimeSec.ldata / 1000).ToString();

                //Focas1.cnc_rdtimer(machineTool.hFanucLib, 1, cycleTime);
                // mOpTime.Value = cycleTime.minute.ToString() + "." + cycleTime.msec.ToString();

//--------------------------------------------------------------------------------------------------------------
                // Display Feed, Speed overrides
                ret = Focas1.pmc_rdpmcrng(machineTool.hFanucMonitor, 0, 0, 96, 96, 16, pmcOverrides);
                mFeedOv.Value = (255-pmcOverrides.cdata[0]).ToString();
                ret = Focas1.pmc_rdpmcrng(machineTool.hFanucMonitor, 0, 0, 30, 30, 16, pmcOverrides);
                mSpeedOv.Value = pmcOverrides.cdata[0].ToString();

//--------------------------------------------------------------------------------------------------------------
                // Display Programmed Feed & Speed
                mPrgFeed.Value = "0";
                mPrgSpeed.Value = "0";

//--------------------------------------------------------------------------------------------------------------
                // Check the current feed rates
                Focas1.ODBACT feedRate = new Focas1.ODBACT();
                Focas1.cnc_actf(machineTool.hFanucMonitor, feedRate);
                mRealFeed.Value = (feedRate.data / 10000).ToString();

//--------------------------------------------------------------------------------------------------------------
                // Check Spindle Speed
                Focas1.ODBACT2 spindleSpeed = new Focas1.ODBACT2();
                Focas1.cnc_acts2(machineTool.hFanucMonitor, 1, spindleSpeed);
                mRealSpeed.Value = (spindleSpeed.data[0] / 10000).ToString();

//--------------------------------------------------------------------------------------------------------------
                // Get Drives Ready
                int ret3 = Focas1.pmc_rdpmcrng(machineTool.hFanucMonitor, 1, 0, 1, 1, 16, pmcDrivesOn);
                driveReady = GetBit(pmcDrivesOn.cdata[0], 7, true);
                mDrivesReady.Value = driveReady ? "Ready" : "Not Ready";

//--------------------------------------------------------------------------------------------------------------
                // Get Messages
                Focas1.OPMSG3 opmsg = new Focas1.OPMSG3();
                short msgSize = 5;
                Focas1.cnc_rdopmsg3(machineTool.hFanucMonitor, -1, ref msgSize, opmsg);

                // Op Message 1
                if (opmsg.msg1.datano != 0 && opmsg.msg1.datano != -1)
                {
                    mOpMsg1.Value = opmsg.msg1.data.ToString();
                }
                else
                {
                    mOpMsg1.Value = string.Empty;
                }

                // Op Message 2
                if (opmsg.msg2.datano != 0 && opmsg.msg2.datano != -1)
                {
                    mOpMsg2.Value = opmsg.msg2.data.ToString();
                }
                else
                {
                    mOpMsg2.Value = string.Empty;
                }

                // Op Message 3
                if (opmsg.msg3.datano != 0 && opmsg.msg3.datano != -1)
                {
                    mOpMsg3.Value = opmsg.msg3.data.ToString();
                }
                else
                {
                    mOpMsg3.Value = string.Empty;
                }

                // Op Message 4
                if (opmsg.msg4.datano != 0 && opmsg.msg4.datano != -1)
                {
                    mOpMsg4.Value = opmsg.msg4.data.ToString();
                }
                else
                {
                    mOpMsg4.Value = string.Empty;
                }

//--------------------------------------------------------------------------------------------------------------
                // Get Drives On
                ret3 = Focas1.pmc_rdpmcrng(machineTool.hFanucMonitor, 1, 0, 0, 0, 16, pmcDrivesOn);
                drivesOn = GetBit(pmcDrivesOn.cdata[0], 2);
                mDrivesOn.Value = drivesOn ? "Drives On" : "Drives Off";

//--------------------------------------------------------------------------------------------------------------
                // If Drives are not on and we have a reason set already, figure out how long we have been in estop
                if (!drivesOn && reasonSet)
                {
                    mDownTimeDuration.Value = dt.GetElapsedDownTime(ref totalElapsedDT);
                }

                // If the drives are not on and we do not have a reason set, show the reason popup box
                // And start our downtime counter. Also set reason to true. 
                if (!drivesOn && !reasonSet)
                {
                    machineTool.Invoke((MethodInvoker)delegate() { dt.Show(); });
                    startTime = dt.startDownTimeCounter();
                    reasonSet = true;
                }

                // If the drives are on (We have cleared all the errors), and we have a reason set (We just came out of estop)
                // So we will get the duration of the downtime, the reason for the downtime and record it.
                if (drivesOn && reasonSet)
                {
                    duration = dt.GetElapsedDownTime(ref totalElapsedDT);
                    endTime = dt.stopDownTimeCounter();
                    mDTReason.Value = dt.reason;

                    // Log the Downtime here
                    dtBuffer = true;
                    BufferDataItems();
                    dtBuffer = false;

                    reasonSet = false;
                }

                if (mDTReason.Value != string.Empty)
                {
                    // Now that we are back in our normal loop, the reason is no longer needed
                    // So now we set it to an empty string and set it to the reason for the last
                    // Downtime period that we had.
                    mDTLastReason.Value = dt.reason;
                    mDTReason.Value = string.Empty;
                    mDownTimeDuration.Value = string.Empty;
                    mLastDownTimeDuration.Value = duration;
                }

//---------------------------------------------------------------------------------------------------------------



                

                // Get Feed Hold


                // Vac On / Off
                Focas1.IODBPMC0 vacSensors = new Focas1.IODBPMC0();
                ret3 = Focas1.pmc_rdpmcrng(machineTool.hFanucMonitor, 5, 0, 46,46, 16, vacSensors);
                bool vac1 = GetBit(vacSensors.cdata[0], 1, false);
                bool vac2 = GetBit(vacSensors.cdata[0], 2, false);
                bool vac3 = GetBit(vacSensors.cdata[0], 3, false);
                bool vac4 = GetBit(vacSensors.cdata[0], 4, false);
                bool vac5 = GetBit(vacSensors.cdata[0], 5, false);
                bool vac6 = GetBit(vacSensors.cdata[0], 6, false);
                bool vac7 = GetBit(vacSensors.cdata[0], 7, false);
                bool vac8 = GetBit(vacSensors.cdata[0], 8, false);

            }
            else
            {
                mAvail.Value = "UNAVAILABLE";
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get Configured Axis -----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//
        

        public short getConfiguredAxes(ushort hFanucAxes)
        {
            Focas1.ODBSYSEX sys = new Focas1.ODBSYSEX();
            Focas1.cnc_sysinfo_ex(hFanucAxes, sys);

            // Max Axes
            short maxAxis = sys.max_axis;

            return maxAxis;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get Axes Names ----------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public void getAxesNames(ushort hFanucAxes, short maxAxes)
        {
            Focas1.ODBAXISNAME name = new Focas1.ODBAXISNAME();
            byte[] axisName = new byte[maxAxes];

            short i = 0;
            for (; i < maxAxes; i++)
            {
                Focas1.cnc_rdaxisname(hFanucAxes, ref i, name);
                axisName[i - 1] = name.data1.name;
            }
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get Alarm Types ---------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private string almType(short type)
        {
            string alm = "";
            switch (type)
            {
                case 0:
                    {
                        alm = "SW";
                        break;
                    }
                case 1:
                    {
                        alm = "PW";
                        break;
                    }
                case 2:
                    {
                        alm = "IO";
                        break;
                    }
                case 3:
                    {
                        alm = "OT";
                        break;
                    }
                case 4:
                    {
                        alm = "OH";
                        break;
                    }
                case 5:
                    {
                        alm = "SV";
                        break;
                    }
                case 6:
                    {
                        alm = "SR";
                        break;
                    }
                case 7:
                    {
                        alm = "MC";
                        break;
                    }
                case 8:
                    {
                        alm = "SP";
                        break;
                    }
                case 9:
                    {
                        alm = "DS";
                        break;
                    }
                case 10:
                    {
                        alm = "IE";
                        break;
                    }
                case 11:
                    {
                        alm = "BG";
                        break;
                    }
                case 12:
                    {
                        alm = "SN";
                        break;
                    }
                case 14:
                    {
                        alm = "EX";
                        break;
                    }
                case 15:
                    {
                        alm = "EX";
                        break;
                    }
                case 19:
                    {
                        alm = "PC";
                        break;
                    }
            }
            return alm;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get Program Names -------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private string GetProgramName(char[] program, string terminator)
        {
            string progName = program[0].ToString();

            if (progName == "\0" && terminator == "\n")
            {
                return lastLine;
            }

            for (int i = 1; i < program.Length; i++)
            {
                if (program[i].ToString() != terminator)
                {
                    progName = progName + program[i].ToString();
                }
                else
                {
                    if (terminator == "\n")
                        lastLine = progName;
                    
                    return progName;
                }
            }

            return "No Program Active";
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get Bit From Binary -----------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private bool GetBit(int value, int bitToRead, bool swapped = false)
        {
            int[] binValues = {128,64,32,16,8,4,2,1};

             for (int i = 0; i < binValues.Length; i++)
             {
                 if (value >= binValues[i])
                 {
                     value = value - binValues[i];
                     binValues[i] = 1;
                 }
                 else
                 {
                     binValues[i] = 0;
                 }
             }
             bool on = true;
            if (binValues[bitToRead - 1] == 0 && swapped)
            {
                return on;
            }
            else if (binValues[bitToRead - 1] == 0 && !swapped)
            {
                on = false;
                return on;
            }
            else if (binValues[bitToRead - 1] == 1 && swapped)
            {
                on = false;
                return on;
            }
            else if (binValues[bitToRead - 1] == 1 && !swapped)
            {
                return on;
            }
            on = false;
            return on;
            
            
        }


        private int[] GetBit(int value, short bitToRead, int numOfBits = 1, bool swapped = false)
        {
            int[] binValues = { 16384, 8192, 4096, 2048, 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
            int[] retValue = new int[numOfBits];

            for (int i = 0; i < binValues.Length; i++)
            {
                if (value >= binValues[i])
                {
                    value = value - binValues[i];
                    binValues[i] = 1;
                }
                else
                {
                    binValues[i] = 0;
                }
            }

            for (int i = bitToRead; i < numOfBits; i++)
            {
                int j = 0;
                retValue[j] = binValues[i - 1];
            }

            return retValue;
        }


        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Buffer Data Items For Recording -----------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

         public void BufferDataItems()
         {
             if (dtBuffer)
             {
                 List<string> dtValues = new List<string>();
                 dtValues.Add("Downtime Start," + startTime);
                 dtValues.Add("Downtime End," + endTime);
                 dtValues.Add("Downtime Duration," + duration);
                 dtValues.Add("Downtime Reason," + dt.reason);

                 dtBufferItems.Add(dtValues);
                 writeDB.WriteToDownTime(dtBufferItems);
             }

             List<string> values = new List<string>();
             values.Add("Drives Ready," + mDrivesReady.Value);
             values.Add("Alarm1," + mAlarm1.Value);
             values.Add("Alarm2," + mAlarm2.Value);
             values.Add("Alarm3," + mAlarm3.Value);
             values.Add("Alarm4," + mAlarm4.Value);
             values.Add("Alarm5," + mAlarm5.Value);
             values.Add("Alarm6," + mAlarm6.Value);
             values.Add("Alarm7," + mAlarm7.Value);
             values.Add("Alarm8," + mAlarm8.Value);
             values.Add("Alarm9," + mAlarm9.Value);
             values.Add("Alarm10," + mAlarm10.Value);
             values.Add("X Pos," + xmPos.Value);
             values.Add("Y Pos," + yPos.Value);
             values.Add("Z Pos," + zPos.Value);
             values.Add("A Pos," + aPos.Value);
             values.Add("C Pos," + cPos.Value);
             values.Add("X Load," + xMotorLoad.Value);
             values.Add("Y Load," + yMotorLoad.Value);
             values.Add("Z Load," + zMotorLoad.Value);
             values.Add("A Load," + aMotorLoad.Value);
             values.Add("C Load," + cMotorLoad.Value);
             values.Add("U Load," + uMotorLoad.Value);
             values.Add("Program," + mProgram.Value);
             values.Add("Cycle Time," + mCycleTime.Value);
             values.Add("Sub Program," + mSubProgram.Value);
             values.Add("Block Number," + mBlkNum.Value);
             values.Add("Current Line," + mActiveLine.Value);
             values.Add("Active Tool," + mActiveTool.Value);
             values.Add("Selected Table," + mSelTable.Value);
             values.Add("Process," + mSelProc.Value);

             /*values.Add("X Load Avg," + xMotorLoadAvg.Value);
             values.Add("Y Load Avg," + yMotorLoadAvg.Value);
             values.Add("Z Load Avg," + zMotorLoadAvg.Value);
             values.Add("A Load Avg," + aMotorLoadAvg.Value);
             values.Add("C Load Avg," + cMotorLoadAvg.Value);
             values.Add("U Load Avg," + uMotorLoadAvg.Value);*/

             values.Add("X Load Peak," + xMotorLoadAvg.Value);
             values.Add("Y Load Peak," + yMotorLoadAvg.Value);
             values.Add("Z Load Peak," + zMotorLoadAvg.Value);
             values.Add("A Load Peak," + aMotorLoadAvg.Value);
             values.Add("C Load Peak," + cMotorLoadAvg.Value);
             values.Add("U Load Peak," + uMotorLoadAvg.Value);

             /*values.Add("X2 Load," + x2MotorLoad.Value);
             values.Add("X2 Load Avg," + x2MotorLoad.Value);
             values.Add("U2 Load," + u2MotorLoad.Value);
             values.Add("U2 Load Avg," + u2MotorLoad.Value);
             values.Add("Y2 Load," + y2MotorLoad.Value);
             values.Add("Y2 Load Avg," + y2MotorLoad.Value);*/

            /*buffer.Add(values);
            writeDB.WriteToEvent(buffer);


             if (!bufferDumped && !driveReady)
             {
                 writeDB.WriteToDump(buffer);
                 bufferDumped = true;
             }
             else if (bufferDumped == true && driveReady)
             {
                 bufferDumped = false;
             }
             if (!driveReady && !extraCycle)
             {
                 extraCycle = true;
             }

             if (buffer.Count > BUFFER_SIZE)
             {
                 buffer.RemoveAt(0);
             }*/
             
         }

         //------------------------------------------------------------------------------------------------------------------//
         //---------------------------------- Average Motor Loads And Peak --------------------------------------------------//
         //------------------------------------------------------------------------------------------------------------------//

        private int SampleMotorLoad(int runningAverage, ref int[] samples, ref int peak)
        {
            // Average samples and run through this shitty makeshift low pass filter.
            int liveAverage = 0;

            // If we are not up to 50 samples then return
            if (samples[49] == null || samples[49] == -1)
            {
                return runningAverage;
            }
            
            // When we have our 50 samples, we are going to iterate through them and add them all together.
            // We are also going to check to see if the current sample is larger than our last peak.
            // Then we can set the sample to -1 to start our samples count over.
            for(int i = 0; i<samples.Length; i++)
            {
                liveAverage = liveAverage + samples[i];

                if (samples[i] > peak)
                {
                    peak = samples[i];
                }

                samples[i] = -1;
            }

            // Now we can divide all our samples by our sample count.
            liveAverage = liveAverage / samples.Length;
            
            // Assign our running average.
            runningAverage = runningAverage + liveAverage / 2;

            return runningAverage;

        }

     }
}