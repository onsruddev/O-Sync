namespace AdapterLab
{
    partial class MachineTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineTool));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hostname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.port2 = new System.Windows.Forms.TextBox();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.axisGB = new System.Windows.Forms.GroupBox();
            this.fiveAxis = new System.Windows.Forms.RadioButton();
            this.fourAxis = new System.Windows.Forms.RadioButton();
            this.threeAxis = new System.Windows.Forms.RadioButton();
            this.machineGB = new System.Windows.Forms.GroupBox();
            this.highRail = new System.Windows.Forms.RadioButton();
            this.fixedBridge = new System.Windows.Forms.RadioButton();
            this.gantry = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cncField = new System.Windows.Forms.TextBox();
            this.gather = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.processGB = new System.Windows.Forms.GroupBox();
            this.dualProc = new System.Windows.Forms.RadioButton();
            this.singleProc = new System.Windows.Forms.RadioButton();
            this.tablesGB = new System.Windows.Forms.GroupBox();
            this.dualTable = new System.Windows.Forms.RadioButton();
            this.singleTable = new System.Windows.Forms.RadioButton();
            this.editMode = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.model = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.genXML = new System.Windows.Forms.Button();
            this.axisP2GB = new System.Windows.Forms.GroupBox();
            this.fiveAxisP2 = new System.Windows.Forms.RadioButton();
            this.fourAxisP2 = new System.Windows.Forms.RadioButton();
            this.threeAxisP2 = new System.Windows.Forms.RadioButton();
            this.toolChangerGB = new System.Windows.Forms.GroupBox();
            this.rotary12 = new System.Windows.Forms.RadioButton();
            this.gifu = new System.Windows.Forms.RadioButton();
            this.AxisNumGB = new System.Windows.Forms.GroupBox();
            this.cAxis2ID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.aAxis2ID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.uAxis2ID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.zAxis2ID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.yAxis2ID = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.xAxis2ID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cAxisID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.aAxisID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.uAxisID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.zAxisID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.yAxisID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.xAxisID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cncName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.axisGB.SuspendLayout();
            this.machineGB.SuspendLayout();
            this.processGB.SuspendLayout();
            this.tablesGB.SuspendLayout();
            this.axisP2GB.SuspendLayout();
            this.toolChangerGB.SuspendLayout();
            this.AxisNumGB.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.hostname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.port2);
            this.groupBox1.Controls.Add(this.stop);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Host/IP";
            // 
            // hostname
            // 
            this.hostname.Enabled = false;
            this.hostname.Location = new System.Drawing.Point(213, 12);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(178, 20);
            this.hostname.TabIndex = 23;
            this.hostname.Text = "localhost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "P2 Port";
            // 
            // port2
            // 
            this.port2.Enabled = false;
            this.port2.Location = new System.Drawing.Point(561, 13);
            this.port2.Name = "port2";
            this.port2.Size = new System.Drawing.Size(62, 20);
            this.port2.TabIndex = 4;
            this.port2.Text = "7879";
            this.port2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(82, 13);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 3;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(1, 13);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 2;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // port
            // 
            this.port.Enabled = false;
            this.port.Location = new System.Drawing.Point(445, 13);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(62, 20);
            this.port.TabIndex = 1;
            this.port.Text = "7878";
            this.port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "P1 Port";
            // 
            // axisGB
            // 
            this.axisGB.Controls.Add(this.fiveAxis);
            this.axisGB.Controls.Add(this.fourAxis);
            this.axisGB.Controls.Add(this.threeAxis);
            this.axisGB.Enabled = false;
            this.axisGB.Location = new System.Drawing.Point(12, 231);
            this.axisGB.Name = "axisGB";
            this.axisGB.Size = new System.Drawing.Size(322, 48);
            this.axisGB.TabIndex = 6;
            this.axisGB.TabStop = false;
            this.axisGB.Text = "Axis P1";
            // 
            // fiveAxis
            // 
            this.fiveAxis.AutoSize = true;
            this.fiveAxis.Location = new System.Drawing.Point(203, 15);
            this.fiveAxis.Name = "fiveAxis";
            this.fiveAxis.Size = new System.Drawing.Size(53, 17);
            this.fiveAxis.TabIndex = 8;
            this.fiveAxis.Text = "5 Axis";
            this.fiveAxis.UseVisualStyleBackColor = true;
            this.fiveAxis.CheckedChanged += new System.EventHandler(this.fiveAxis_CheckedChanged);
            // 
            // fourAxis
            // 
            this.fourAxis.AutoSize = true;
            this.fourAxis.Location = new System.Drawing.Point(114, 15);
            this.fourAxis.Name = "fourAxis";
            this.fourAxis.Size = new System.Drawing.Size(53, 17);
            this.fourAxis.TabIndex = 7;
            this.fourAxis.Text = "4 Axis";
            this.fourAxis.UseVisualStyleBackColor = true;
            this.fourAxis.CheckedChanged += new System.EventHandler(this.fourAxis_CheckedChanged);
            // 
            // threeAxis
            // 
            this.threeAxis.AutoSize = true;
            this.threeAxis.Checked = true;
            this.threeAxis.Location = new System.Drawing.Point(36, 16);
            this.threeAxis.Name = "threeAxis";
            this.threeAxis.Size = new System.Drawing.Size(53, 17);
            this.threeAxis.TabIndex = 6;
            this.threeAxis.TabStop = true;
            this.threeAxis.Text = "3 Axis";
            this.threeAxis.UseVisualStyleBackColor = true;
            this.threeAxis.CheckedChanged += new System.EventHandler(this.threeAxis_CheckedChanged);
            // 
            // machineGB
            // 
            this.machineGB.Controls.Add(this.highRail);
            this.machineGB.Controls.Add(this.fixedBridge);
            this.machineGB.Controls.Add(this.gantry);
            this.machineGB.Enabled = false;
            this.machineGB.Location = new System.Drawing.Point(12, 177);
            this.machineGB.Name = "machineGB";
            this.machineGB.Size = new System.Drawing.Size(322, 48);
            this.machineGB.TabIndex = 10;
            this.machineGB.TabStop = false;
            this.machineGB.Text = "Machine";
            // 
            // highRail
            // 
            this.highRail.AutoSize = true;
            this.highRail.Location = new System.Drawing.Point(203, 15);
            this.highRail.Name = "highRail";
            this.highRail.Size = new System.Drawing.Size(108, 17);
            this.highRail.TabIndex = 8;
            this.highRail.Text = "High Rail / H. Mill";
            this.highRail.UseVisualStyleBackColor = true;
            this.highRail.CheckedChanged += new System.EventHandler(this.highRail_CheckedChanged);
            // 
            // fixedBridge
            // 
            this.fixedBridge.AutoSize = true;
            this.fixedBridge.Location = new System.Drawing.Point(114, 15);
            this.fixedBridge.Name = "fixedBridge";
            this.fixedBridge.Size = new System.Drawing.Size(83, 17);
            this.fixedBridge.TabIndex = 7;
            this.fixedBridge.Text = "Fixed Bridge";
            this.fixedBridge.UseVisualStyleBackColor = true;
            this.fixedBridge.CheckedChanged += new System.EventHandler(this.fixedBridge_CheckedChanged);
            // 
            // gantry
            // 
            this.gantry.AutoSize = true;
            this.gantry.Checked = true;
            this.gantry.Location = new System.Drawing.Point(36, 16);
            this.gantry.Name = "gantry";
            this.gantry.Size = new System.Drawing.Size(56, 17);
            this.gantry.TabIndex = 6;
            this.gantry.TabStop = true;
            this.gantry.Text = "Gantry";
            this.gantry.UseVisualStyleBackColor = true;
            this.gantry.CheckedChanged += new System.EventHandler(this.gantry_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "CNC IP";
            // 
            // cncField
            // 
            this.cncField.Enabled = false;
            this.cncField.Location = new System.Drawing.Point(326, 68);
            this.cncField.Name = "cncField";
            this.cncField.Size = new System.Drawing.Size(174, 20);
            this.cncField.TabIndex = 12;
            // 
            // gather
            // 
            this.gather.Tick += new System.EventHandler(this.gather_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 16;
            // 
            // processGB
            // 
            this.processGB.Controls.Add(this.dualProc);
            this.processGB.Controls.Add(this.singleProc);
            this.processGB.Enabled = false;
            this.processGB.Location = new System.Drawing.Point(350, 285);
            this.processGB.Name = "processGB";
            this.processGB.Size = new System.Drawing.Size(322, 48);
            this.processGB.TabIndex = 11;
            this.processGB.TabStop = false;
            this.processGB.Text = "Process";
            // 
            // dualProc
            // 
            this.dualProc.AutoSize = true;
            this.dualProc.Location = new System.Drawing.Point(114, 15);
            this.dualProc.Name = "dualProc";
            this.dualProc.Size = new System.Drawing.Size(47, 17);
            this.dualProc.TabIndex = 7;
            this.dualProc.Text = "Dual";
            this.dualProc.UseVisualStyleBackColor = true;
            this.dualProc.CheckedChanged += new System.EventHandler(this.dualProc_CheckedChanged);
            // 
            // singleProc
            // 
            this.singleProc.AutoSize = true;
            this.singleProc.Checked = true;
            this.singleProc.Location = new System.Drawing.Point(36, 16);
            this.singleProc.Name = "singleProc";
            this.singleProc.Size = new System.Drawing.Size(54, 17);
            this.singleProc.TabIndex = 6;
            this.singleProc.TabStop = true;
            this.singleProc.Text = "Single";
            this.singleProc.UseVisualStyleBackColor = true;
            // 
            // tablesGB
            // 
            this.tablesGB.Controls.Add(this.dualTable);
            this.tablesGB.Controls.Add(this.singleTable);
            this.tablesGB.Enabled = false;
            this.tablesGB.Location = new System.Drawing.Point(350, 231);
            this.tablesGB.Name = "tablesGB";
            this.tablesGB.Size = new System.Drawing.Size(322, 48);
            this.tablesGB.TabIndex = 17;
            this.tablesGB.TabStop = false;
            this.tablesGB.Text = "Tables";
            // 
            // dualTable
            // 
            this.dualTable.AutoSize = true;
            this.dualTable.Location = new System.Drawing.Point(114, 15);
            this.dualTable.Name = "dualTable";
            this.dualTable.Size = new System.Drawing.Size(31, 17);
            this.dualTable.TabIndex = 7;
            this.dualTable.Text = "2";
            this.dualTable.UseVisualStyleBackColor = true;
            // 
            // singleTable
            // 
            this.singleTable.AutoSize = true;
            this.singleTable.Checked = true;
            this.singleTable.Location = new System.Drawing.Point(36, 16);
            this.singleTable.Name = "singleTable";
            this.singleTable.Size = new System.Drawing.Size(31, 17);
            this.singleTable.TabIndex = 6;
            this.singleTable.TabStop = true;
            this.singleTable.Text = "1";
            this.singleTable.UseVisualStyleBackColor = true;
            // 
            // editMode
            // 
            this.editMode.Location = new System.Drawing.Point(415, 345);
            this.editMode.Name = "editMode";
            this.editMode.Size = new System.Drawing.Size(75, 23);
            this.editMode.TabIndex = 18;
            this.editMode.Text = "Edit Mode";
            this.editMode.UseVisualStyleBackColor = true;
            this.editMode.Click += new System.EventHandler(this.editMode_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(300, 345);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // model
            // 
            this.model.Enabled = false;
            this.model.Location = new System.Drawing.Point(573, 68);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(89, 20);
            this.model.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(506, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "CNC Model";
            // 
            // genXML
            // 
            this.genXML.Enabled = false;
            this.genXML.Location = new System.Drawing.Point(168, 345);
            this.genXML.Name = "genXML";
            this.genXML.Size = new System.Drawing.Size(95, 23);
            this.genXML.TabIndex = 22;
            this.genXML.Text = "Configure Agent";
            this.genXML.UseVisualStyleBackColor = true;
            this.genXML.Click += new System.EventHandler(this.genXML_Click);
            // 
            // axisP2GB
            // 
            this.axisP2GB.Controls.Add(this.fiveAxisP2);
            this.axisP2GB.Controls.Add(this.fourAxisP2);
            this.axisP2GB.Controls.Add(this.threeAxisP2);
            this.axisP2GB.Enabled = false;
            this.axisP2GB.Location = new System.Drawing.Point(12, 285);
            this.axisP2GB.Name = "axisP2GB";
            this.axisP2GB.Size = new System.Drawing.Size(322, 48);
            this.axisP2GB.TabIndex = 9;
            this.axisP2GB.TabStop = false;
            this.axisP2GB.Text = "Axis P2";
            // 
            // fiveAxisP2
            // 
            this.fiveAxisP2.AutoSize = true;
            this.fiveAxisP2.Location = new System.Drawing.Point(203, 15);
            this.fiveAxisP2.Name = "fiveAxisP2";
            this.fiveAxisP2.Size = new System.Drawing.Size(53, 17);
            this.fiveAxisP2.TabIndex = 8;
            this.fiveAxisP2.Text = "5 Axis";
            this.fiveAxisP2.UseVisualStyleBackColor = true;
            // 
            // fourAxisP2
            // 
            this.fourAxisP2.AutoSize = true;
            this.fourAxisP2.Location = new System.Drawing.Point(114, 15);
            this.fourAxisP2.Name = "fourAxisP2";
            this.fourAxisP2.Size = new System.Drawing.Size(53, 17);
            this.fourAxisP2.TabIndex = 7;
            this.fourAxisP2.Text = "4 Axis";
            this.fourAxisP2.UseVisualStyleBackColor = true;
            // 
            // threeAxisP2
            // 
            this.threeAxisP2.AutoSize = true;
            this.threeAxisP2.Checked = true;
            this.threeAxisP2.Location = new System.Drawing.Point(36, 16);
            this.threeAxisP2.Name = "threeAxisP2";
            this.threeAxisP2.Size = new System.Drawing.Size(53, 17);
            this.threeAxisP2.TabIndex = 6;
            this.threeAxisP2.TabStop = true;
            this.threeAxisP2.Text = "3 Axis";
            this.threeAxisP2.UseVisualStyleBackColor = true;
            // 
            // toolChangerGB
            // 
            this.toolChangerGB.Controls.Add(this.rotary12);
            this.toolChangerGB.Controls.Add(this.gifu);
            this.toolChangerGB.Enabled = false;
            this.toolChangerGB.Location = new System.Drawing.Point(350, 177);
            this.toolChangerGB.Name = "toolChangerGB";
            this.toolChangerGB.Size = new System.Drawing.Size(322, 48);
            this.toolChangerGB.TabIndex = 18;
            this.toolChangerGB.TabStop = false;
            this.toolChangerGB.Text = "Tool Changer";
            // 
            // rotary12
            // 
            this.rotary12.AutoSize = true;
            this.rotary12.Checked = true;
            this.rotary12.Location = new System.Drawing.Point(36, 19);
            this.rotary12.Name = "rotary12";
            this.rotary12.Size = new System.Drawing.Size(56, 17);
            this.rotary12.TabIndex = 7;
            this.rotary12.TabStop = true;
            this.rotary12.Text = "Rotary";
            this.rotary12.UseVisualStyleBackColor = true;
            // 
            // gifu
            // 
            this.gifu.AutoSize = true;
            this.gifu.Location = new System.Drawing.Point(114, 19);
            this.gifu.Name = "gifu";
            this.gifu.Size = new System.Drawing.Size(50, 17);
            this.gifu.TabIndex = 6;
            this.gifu.Text = "GIFU";
            this.gifu.UseVisualStyleBackColor = true;
            // 
            // AxisNumGB
            // 
            this.AxisNumGB.Controls.Add(this.cAxis2ID);
            this.AxisNumGB.Controls.Add(this.label14);
            this.AxisNumGB.Controls.Add(this.aAxis2ID);
            this.AxisNumGB.Controls.Add(this.label15);
            this.AxisNumGB.Controls.Add(this.uAxis2ID);
            this.AxisNumGB.Controls.Add(this.label16);
            this.AxisNumGB.Controls.Add(this.zAxis2ID);
            this.AxisNumGB.Controls.Add(this.label17);
            this.AxisNumGB.Controls.Add(this.yAxis2ID);
            this.AxisNumGB.Controls.Add(this.label18);
            this.AxisNumGB.Controls.Add(this.xAxis2ID);
            this.AxisNumGB.Controls.Add(this.label19);
            this.AxisNumGB.Controls.Add(this.cAxisID);
            this.AxisNumGB.Controls.Add(this.label12);
            this.AxisNumGB.Controls.Add(this.aAxisID);
            this.AxisNumGB.Controls.Add(this.label11);
            this.AxisNumGB.Controls.Add(this.uAxisID);
            this.AxisNumGB.Controls.Add(this.label10);
            this.AxisNumGB.Controls.Add(this.zAxisID);
            this.AxisNumGB.Controls.Add(this.label9);
            this.AxisNumGB.Controls.Add(this.yAxisID);
            this.AxisNumGB.Controls.Add(this.label8);
            this.AxisNumGB.Controls.Add(this.xAxisID);
            this.AxisNumGB.Controls.Add(this.label7);
            this.AxisNumGB.Enabled = false;
            this.AxisNumGB.Location = new System.Drawing.Point(12, 94);
            this.AxisNumGB.Name = "AxisNumGB";
            this.AxisNumGB.Size = new System.Drawing.Size(660, 77);
            this.AxisNumGB.TabIndex = 11;
            this.AxisNumGB.TabStop = false;
            this.AxisNumGB.Text = "Define Axis ID\'s";
            // 
            // cAxis2ID
            // 
            this.cAxis2ID.Enabled = false;
            this.cAxis2ID.Location = new System.Drawing.Point(391, 48);
            this.cAxis2ID.Name = "cAxis2ID";
            this.cAxis2ID.Size = new System.Drawing.Size(30, 20);
            this.cAxis2ID.TabIndex = 35;
            this.cAxis2ID.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(371, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "C2";
            // 
            // aAxis2ID
            // 
            this.aAxis2ID.Enabled = false;
            this.aAxis2ID.Location = new System.Drawing.Point(314, 48);
            this.aAxis2ID.Name = "aAxis2ID";
            this.aAxis2ID.Size = new System.Drawing.Size(30, 20);
            this.aAxis2ID.TabIndex = 33;
            this.aAxis2ID.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(294, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "A2";
            // 
            // uAxis2ID
            // 
            this.uAxis2ID.Enabled = false;
            this.uAxis2ID.Location = new System.Drawing.Point(238, 48);
            this.uAxis2ID.Name = "uAxis2ID";
            this.uAxis2ID.Size = new System.Drawing.Size(30, 20);
            this.uAxis2ID.TabIndex = 31;
            this.uAxis2ID.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(218, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "U2";
            // 
            // zAxis2ID
            // 
            this.zAxis2ID.Enabled = false;
            this.zAxis2ID.Location = new System.Drawing.Point(166, 48);
            this.zAxis2ID.Name = "zAxis2ID";
            this.zAxis2ID.Size = new System.Drawing.Size(30, 20);
            this.zAxis2ID.TabIndex = 29;
            this.zAxis2ID.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(146, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Z2";
            // 
            // yAxis2ID
            // 
            this.yAxis2ID.Enabled = false;
            this.yAxis2ID.Location = new System.Drawing.Point(95, 48);
            this.yAxis2ID.Name = "yAxis2ID";
            this.yAxis2ID.Size = new System.Drawing.Size(30, 20);
            this.yAxis2ID.TabIndex = 27;
            this.yAxis2ID.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(75, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Y2";
            // 
            // xAxis2ID
            // 
            this.xAxis2ID.Enabled = false;
            this.xAxis2ID.Location = new System.Drawing.Point(26, 48);
            this.xAxis2ID.MaxLength = 1;
            this.xAxis2ID.Name = "xAxis2ID";
            this.xAxis2ID.Size = new System.Drawing.Size(30, 20);
            this.xAxis2ID.TabIndex = 25;
            this.xAxis2ID.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "X2";
            // 
            // cAxisID
            // 
            this.cAxisID.Enabled = false;
            this.cAxisID.Location = new System.Drawing.Point(391, 19);
            this.cAxisID.Name = "cAxisID";
            this.cAxisID.Size = new System.Drawing.Size(30, 20);
            this.cAxisID.TabIndex = 23;
            this.cAxisID.Text = "6";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(371, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "C";
            // 
            // aAxisID
            // 
            this.aAxisID.Enabled = false;
            this.aAxisID.Location = new System.Drawing.Point(314, 19);
            this.aAxisID.Name = "aAxisID";
            this.aAxisID.Size = new System.Drawing.Size(30, 20);
            this.aAxisID.TabIndex = 21;
            this.aAxisID.Text = "5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(294, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "A";
            // 
            // uAxisID
            // 
            this.uAxisID.Enabled = false;
            this.uAxisID.Location = new System.Drawing.Point(238, 19);
            this.uAxisID.Name = "uAxisID";
            this.uAxisID.Size = new System.Drawing.Size(30, 20);
            this.uAxisID.TabIndex = 19;
            this.uAxisID.Text = "4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "U";
            // 
            // zAxisID
            // 
            this.zAxisID.Enabled = false;
            this.zAxisID.Location = new System.Drawing.Point(166, 19);
            this.zAxisID.Name = "zAxisID";
            this.zAxisID.Size = new System.Drawing.Size(30, 20);
            this.zAxisID.TabIndex = 17;
            this.zAxisID.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Z";
            // 
            // yAxisID
            // 
            this.yAxisID.Enabled = false;
            this.yAxisID.Location = new System.Drawing.Point(95, 19);
            this.yAxisID.Name = "yAxisID";
            this.yAxisID.Size = new System.Drawing.Size(30, 20);
            this.yAxisID.TabIndex = 15;
            this.yAxisID.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Y";
            // 
            // xAxisID
            // 
            this.xAxisID.Enabled = false;
            this.xAxisID.Location = new System.Drawing.Point(26, 19);
            this.xAxisID.MaxLength = 1;
            this.xAxisID.Name = "xAxisID";
            this.xAxisID.Size = new System.Drawing.Size(30, 20);
            this.xAxisID.TabIndex = 13;
            this.xAxisID.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "X";
            // 
            // cncName
            // 
            this.cncName.Location = new System.Drawing.Point(76, 68);
            this.cncName.Name = "cncName";
            this.cncName.Size = new System.Drawing.Size(187, 20);
            this.cncName.TabIndex = 25;
            this.cncName.TextChanged += new System.EventHandler(this.cncName_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "CNC Name";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "O-Sync";
            this.notifyIcon1.ContextMenuStrip = this.contextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "O-Sync";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "O-Sync";
            this.contextMenu.Size = new System.Drawing.Size(111, 114);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Enabled = false;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MachineTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 375);
            this.Controls.Add(this.cncName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.AxisNumGB);
            this.Controls.Add(this.toolChangerGB);
            this.Controls.Add(this.axisP2GB);
            this.Controls.Add(this.genXML);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.model);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editMode);
            this.Controls.Add(this.tablesGB);
            this.Controls.Add(this.processGB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.axisGB);
            this.Controls.Add(this.cncField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.machineGB);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineTool";
            this.Text = "O-Sync Adapter - C.R. Onsrud";
            this.Load += new System.EventHandler(this.MachineTool_Load);
            this.Resize += new System.EventHandler(this.OnResize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.axisGB.ResumeLayout(false);
            this.axisGB.PerformLayout();
            this.machineGB.ResumeLayout(false);
            this.machineGB.PerformLayout();
            this.processGB.ResumeLayout(false);
            this.processGB.PerformLayout();
            this.tablesGB.ResumeLayout(false);
            this.tablesGB.PerformLayout();
            this.axisP2GB.ResumeLayout(false);
            this.axisP2GB.PerformLayout();
            this.toolChangerGB.ResumeLayout(false);
            this.toolChangerGB.PerformLayout();
            this.AxisNumGB.ResumeLayout(false);
            this.AxisNumGB.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.GroupBox axisGB;
        private System.Windows.Forms.RadioButton fiveAxis;
        private System.Windows.Forms.RadioButton fourAxis;
        private System.Windows.Forms.RadioButton threeAxis;
        private System.Windows.Forms.GroupBox machineGB;
        private System.Windows.Forms.RadioButton fixedBridge;
        private System.Windows.Forms.RadioButton gantry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cncField;
        private System.Windows.Forms.Timer gather;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox processGB;
        private System.Windows.Forms.RadioButton dualProc;
        private System.Windows.Forms.RadioButton singleProc;
        private System.Windows.Forms.GroupBox tablesGB;
        private System.Windows.Forms.RadioButton dualTable;
        private System.Windows.Forms.RadioButton singleTable;
        private System.Windows.Forms.Button editMode;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox port2;
        private System.Windows.Forms.TextBox model;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button genXML;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox hostname;
        private System.Windows.Forms.GroupBox axisP2GB;
        private System.Windows.Forms.RadioButton fiveAxisP2;
        private System.Windows.Forms.RadioButton fourAxisP2;
        private System.Windows.Forms.RadioButton threeAxisP2;
        private System.Windows.Forms.GroupBox toolChangerGB;
        private System.Windows.Forms.RadioButton rotary12;
        private System.Windows.Forms.RadioButton gifu;
        private System.Windows.Forms.GroupBox AxisNumGB;
        private System.Windows.Forms.TextBox cAxisID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox aAxisID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uAxisID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox zAxisID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox yAxisID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox xAxisID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cncName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton highRail;
        private System.Windows.Forms.TextBox cAxis2ID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox aAxis2ID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox uAxis2ID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox zAxis2ID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox yAxis2ID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox xAxis2ID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}

