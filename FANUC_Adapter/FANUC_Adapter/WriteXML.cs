using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterLab
{
    using MTConnect;
    class WriteXML
    {

        // Create an instance of the machinetool class
        private MachineTool machineTool;

        // Constructor
        public WriteXML(MachineTool machineTool)
        {
            this.machineTool = machineTool;
        }

//------------------------------------------------------------------------------------------------------------------//
//----------------------------------- Process 1 XML Generation -----------------------------------------------------//
//------------------------------------------------------------------------------------------------------------------//
        
        public string[] proc1(string[] buffer)
        {
            getDeviceName();

            buffer[0] = @"<?xml version='1.0' encoding='UTF-8'?>
<MTConnectDevices xmlns:mt='urn:mtconnect.org:MTConnectDevices:1.2' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns='urn:mtconnect.org:MTConnectDevices:1.2' xsi:schemaLocation='urn:mtconnect.org:MTConnectDevices:1.2 http://www.mtconnect.org/schemas/MTConnectDevices_1.2.xsd'>
  <Header creationTime='' assetBufferSize='1024' sender='localhost' assetCount='0' version='1.2' instanceId='0' bufferSize='131072'/>
  <Devices>
    <Device name='" + this.machineTool.xmlNameP1 + @"' uuid='" + this.machineTool.xmlNameP1 + @"' id='FANUC_1'>
      <Description model='" + this.machineTool.cncModel + @"' manufacturer='CR_ONSRUD'>CR Onsrud - Machine</Description>
      <DataItems>
        <DataItem type='AVAILABILITY' category='EVENT' id='proc1_avail' name='avail'/>
      </DataItems>";

            buffer[1] = @"    <Components>
        <Axes name='axes' id='axes_proc1'>
          <Components>
            <Linear name='X' id='AXIS_X_proc1'>
              <DataItems>
                <DataItem type='POSITION' category='SAMPLE' id='proc1_xPos' name='xAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_xWorkPos' name='xWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_xCmdPos' name='xCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_xMotorLoad' name='xMotorLoad' units='Ampere' nativeUnits='Ampere'/>
			  </DataItems>
			</Linear>
			<Linear name='Y' id='AXIS_Y_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_yPos' name='yAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_yWorkPos' name='yWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_yCmdPos' name='yCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_yMotorLoad' name='yMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>
			<Linear name='Z' id='AXIS_Z_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_zPos' name='zAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_zWorkPos' name='zWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_zCmdPos' name='zCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_zMotorLoad' name='zMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>";

            if (this.machineTool.highRailChecked)
            {
                buffer[1] = @"    <Components>
        <Axes name='axes' id='axes_proc1'>
          <Components>
            <Linear name='X' id='AXIS_X_proc1'>
              <DataItems>
                <DataItem type='POSITION' category='SAMPLE' id='proc1_xPos' name='xAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_xWorkPos' name='xWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_xCmdPos' name='xCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_xMotorLoad' name='xMotorLoad' units='Ampere' nativeUnits='Ampere'/>
			  </DataItems>
			</Linear>
			<Linear name='X2' id='AXIS_X2_proc1'>
			  <DataItems>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_x2MotorLoad' name='x2MotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>
			<Linear name='U' id='AXIS_U_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_uPos' name='uAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_uWorkPos' name='uWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_uCmdPos' name='uCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_uMotorLoad' name='uMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>
			<Linear name='U2' id='AXIS_U2_proc1'>
			  <DataItems>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_u2MotorLoad' name='u2MotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>
			<Linear name='Y' id='AXIS_Y_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_yPos' name='yAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_yWorkPos' name='yWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_yCmdPos' name='yCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_yMotorLoad' name='yMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>
			<Linear name='Y2' id='AXIS_Y2_proc1'>
			  <DataItems>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_y2MotorLoad' name='y2MotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>
			<Linear name='Z' id='AXIS_Z_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_zPos' name='zAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_zWorkPos' name='zWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_zCmdPos' name='zCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_zMotorLoad' name='zMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>";
            }

            if (machineTool.gantryChecked && !machineTool.highRailChecked)
            {
                buffer[2] = @"			<Linear name='U' id='AXIS_U_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_uPos' name='uAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_uWorkPos' name='uWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_uCmdPos' name='uCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_uMotorLoad' name='uMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
			</Linear>";
            }

            if (this.machineTool.axis4)
            {
                buffer[3] = @"            <Rotary name='C' id='AXIS_C_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_cPos' name='cAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_cWorkPos' name='cWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_cCmdPos' name='cCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_cMotorLoad' name='cMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
            </Rotary>";
            }
            else if (this.machineTool.axis5)
            {
                buffer[3] = @"            <Rotary name='C' id='AXIS_C_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_cPos' name='cAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_cWorkPos' name='cWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_cCmdPos' name='cCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_cMotorLoad' name='cMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
            </Rotary>
            <Rotary name='A' id='AXIS_A_proc1'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_aPos' name='aAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_aWorkPos' name='aWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc1_aCmdPos' name='aCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
                <DataItem type='LOAD' category='SAMPLE' id='proc1_aMotorLoad' name='aMotorLoad' units='Ampere' nativeUnits='Ampere'/>
              </DataItems>
            </Rotary>";
            }

            buffer[4] = @"		  </Components>
        </Axes>
<Controller name='Program' id='proc1_Program'>
          <DataItems>
			<DataItem type='DRIVES_READY' category='EVENT' id='proc1_drives_ready' name='drives_ready'/>
			<DataItem type='CYCLE_TIME' category='EVENT' id='proc1_cycle_time' name='cycle_time'/>
		    <DataItem type='PROGRAM_NAME' category='EVENT' id='proc1_program' name='program'/>
			<DataItem type='PROGRAM_NAME' category='EVENT' id='proc1_subprogram' name='subprogram'/>
			<DataItem type='BLOCK' category='EVENT' id='proc1_blk' name='block'/>
			<DataItem type='LINE' category='EVENT' id='proc1_line' name='line'/>
		  </DataItems>
		</Controller>
		<Controller name='Controller' id='proc1_controller'>
		  <DataItems>
			<DataItem type='CONTROLER_MODE' category='EVENT' id='proc1_mode' name='mode'/>
			<DataItem type='SYSTEM' category='EVENT' id='proc1_proc' name='selected_proc'/>
			<DataItem type='TOOL_ID' category='EVENT' id='proc1_tool' name='tool'/>
		  </DataItems>
		</Controller>
		<Controller name='Alarms' id='proc1_alarms'>
		  <DataItems>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_1' name='alarm_1'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_2' name='alarm_2'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_3' name='alarm_3'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_4' name='alarm_4'/>	
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_5' name='alarm_5'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_6' name='alarm_6'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_7' name='alarm_7'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_8' name='alarm_8'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_9' name='alarm_9'/>
			<DataItem type='Fault' category='EVENT' id='proc1_alarm_10' name='alarm_10'/>			
          </DataItems>
        </Controller>
		<Spindle name='spindle' id='proc1_spindle'>
			<DataItem type='SPINDLE_SPEED' subType='OVERRIDE' category='EVENT' id='proc1_speed_ov' name='speed_ov'/>
			<DataItem type='SPINDLE_SPEED' subType='COMMANDED' category='EVENT' id='proc1_prgm_speed' name='prgm_speed'/>
		</Spindle>
      </Components>
    </Device>";

            if (this.machineTool.xmlNameP2 == string.Empty)
            {
                buffer[5] = @"   </Devices>
</MTConnectDevices>";
            }
            return buffer;
        }

//------------------------------------------------------------------------------------------------------------------//
//----------------------------------- Process 2 XML Generation -----------------------------------------------------//
//------------------------------------------------------------------------------------------------------------------//
        public string[] proc2(string[] buffer)
        {

            buffer[5] = @"    <Device name='" + this.machineTool.xmlNameP2 + @"' uuid='" + this.machineTool.xmlNameP2 + @"' id='FANUC_2'>
      <Description model='" + this.machineTool.cncModel + @"' manufacturer='CR_ONSRUD'>CR Onsrud - Machine</Description>
      <DataItems>
        <DataItem type='AVAILABILITY' category='EVENT' id='proc2_avail' name='avail'/>
      </DataItems>";

            buffer[6] = @"    <Components>
        <Axes name='axes' id='axes_proc2'>
          <Components>
            <Linear name='X' id='AXIS_X_proc2'>
              <DataItems>
                <DataItem type='POSITION' category='SAMPLE' id='proc2_xPos' name='xAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_xWorkPos' name='xWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_xCmdPos' name='xCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
			  </DataItems>
			</Linear>
			<Linear name='Y' id='AXIS_Y_proc2'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_yPos' name='yAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_yWorkPos' name='yWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_yCmdPos' name='yCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
              </DataItems>
			</Linear>
			<Linear name='Z' id='AXIS_Z_proc2'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_zPos' name='zAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_zWorkPos' name='zWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_zCmdPos' name='zCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
              </DataItems>
			</Linear>";

            if (this.machineTool.axis4 == true)
            {
                buffer[7] = @"            <Linear name='C' id='AXIS_C_proc2'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_cPos' name='cAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_cWorkPos' name='cWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_cCmdPos' name='cCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
              </DataItems>
            </Linear>";
            }
            else if (this.machineTool.axis5 == true)
            {
                buffer[7] = @"            <Linear name='C' id='AXIS_C_proc2'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_cPos' name='cAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_cWorkPos' name='cWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_cCmdPos' name='cCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
              </DataItems>
            </Linear>
            <Linear name='A' id='AXIS_A_proc2'>
			  <DataItems>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_aPos' name='aAct_pos' subType='ACTUAL' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_aWorkPos' name='aWork_pos' subType='WORK' units='INCHES' nativeUnits='INCHES'/>
				<DataItem type='POSITION' category='SAMPLE' id='proc2_aCmdPos' name='aCmd_pos' subType='COMMANDED' units='INCHES' nativeUnits='INCHES'/>
              </DataItems>
            </Linear>";
            }

            buffer[8] = @"            <DataItem type='AXIS_FEEDRATE' subType='OVERRIDE' category='EVENT' id='proc2_feed_ov' name='feed_ov'/>
			<DataItem type='AXIS_FEEDRATE' subType='OVERRIDE' category='EVENT' id='proc2_rapid_ov' name='rapid_ov'/>
			<DataItem type='AXIS_FEEDRATE' subType='COMMANDED' category='EVENT' id='proc2_prgm_feed' name='prgm_feed'/>
          </Components>
        </Axes>
        <Controller name='controller' id='proc2_controller'>
          <DataItems>
            <DataItem type='CONTROLER_MODE' category='EVENT' id='proc2_mode' name='mode'/>
            <DataItem type='PROGRAM_NAME' category='EVENT' id='proc2_program' name='program'/>
			<DataItem type='PROGRAM_NAME' category='EVENT' id='proc2_subprogram' name='subprogram'/>
			<DataItem type='BLOCK' category='EVENT' id='proc2_blk' name='block'/>
			<DataItem type='LINE' category='EVENT' id='proc2_line' name='line'/>
			<DataItem type='SYSTEM' category='EVENT' id='proc2_proc' name='selected_proc'/>
			<DataItem type='TOOL_ID' category='EVENT' id='proc2_tool' name='tool'/>
			<DataItem type='Fault' category='CONDITION' id='proc2_fault' name='fault'/>	
          </DataItems>
        </Controller>
		<Spindle name='spindle' id='proc2_spindle'>
			<DataItem type='SPINDLE_SPEED' subType='OVERRIDE' category='EVENT' id='proc2_speed_ov' name='speed_ov'/>
			<DataItem type='SPINDLE_SPEED' subType='COMMANDED' category='EVENT' id='proc2_prgm_speed' name='prgm_speed'/>
		</Spindle>
      </Components>
    </Device>
  </Devices>
</MTConnectDevices>";
            return buffer;
        }

//------------------------------------------------------------------------------------------------------------------//
//----------------------------------- Agent Configuration File -----------------------------------------------------//
//------------------------------------------------------------------------------------------------------------------//

        public string[] agentCFG(string[] buffer)
        {
            buffer[0] = @"Devices = ./Devices.xml
AllowPut = true
ReconnectInterval = 1000
BufferSize = 17
SchemaVersion = 1.3

Adapters { 
   " + this.machineTool.xmlNameP1 + @" { 
      Host = " + this.machineTool.hostIP + @"
      Port = " + this.machineTool.portP1 + @"
   } ";

            if (this.machineTool.xmlNameP2 != "")
            {
                buffer[1] = @"
   " + this.machineTool.xmlNameP2 + @" { 
      Host = " + this.machineTool.hostIP + @"
      Port = " + this.machineTool.portP2 + @"
   } 
}

Files {
    schemas {
        Path = ../schemas
        Location = /schemas/
    }
    styles {
        Path = ../styles
        Location = /styles/
    }
    Favicon {
        Path = ../styles/favicon.ico
        Location = /favicon.ico
    }
}

StreamsStyle {
  Location = /styles/Streams.xsl
}

# Logger Configuration
logger_config
{
    logging_level = debug
    output = cout
}";
            }
            else
            {
                buffer[1] = @"}

Files {
    schemas {
        Path = ../schemas
        Location = /schemas/
    }
    styles {
        Path = ../styles
        Location = /styles/
    }
    Favicon {
        Path = ../styles/favicon.ico
        Location = /favicon.ico
    }
}

StreamsStyle {
  Location = /styles/Streams.xsl
}

# Logger Configuration
logger_config
{
    logging_level = debug
    output = cout
}";
            }

            return buffer;
        }

//-----------------------------------------------------------------------------------------------------------------//
//---------------------------------- Create Device Name For XML ---------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------//

        public void getDeviceName()
        {
            if (machineTool.nickName != string.Empty && machineTool.dualProcChecked)
            {
                machineTool.xmlNameP1 = machineTool.nickName + "_Proc1";
                machineTool.xmlNameP2 = machineTool.nickName + "_Proc2";
                return;
            }
            else if (machineTool.nickName != string.Empty && !machineTool.dualProcChecked)
            {
                machineTool.xmlNameP1 = machineTool.nickName;
                return;
            }

            // Local Variables
            string[] bufferName = new string[4];

            // Check Number Of Axes
            if (this.machineTool.axis3)
            {
                bufferName[0] = "_3AXIS";
            }
            if (this.machineTool.axis4)
            {
                bufferName[0] = "_4AXIS";
            }
            if (this.machineTool.axis5)
            {
                bufferName[0] = "_5AXIS";
            }

            // Check Machine Type Configured
            if (this.machineTool.gantryChecked)
            {
                bufferName[1] = "_GANTRY";
            }
            else if (this.machineTool.fixedBridgeChecked)
            {
                bufferName[1] = "_FIXEDBRIDGE";
            }

            // Check Number Of Processes
            if (this.machineTool.dualProcChecked)
            {
                bufferName[2] = "_PROC1";
                bufferName[3] = "_PROC2";

                // CNC names for P1 and P2
                machineTool.xmlNameP1 = "FANUC" + bufferName[0] + bufferName[1] + bufferName[2];
                machineTool.xmlNameP2 = "FANUC" + bufferName[0] + bufferName[1] + bufferName[3];
            }
            else
            {
                machineTool.xmlNameP1 = "FANUC" + bufferName[0] + bufferName[1];
            }
        }
    }
}
