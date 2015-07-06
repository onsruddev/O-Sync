using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

//------------------------------------------------------------------------------------------------------------------//
//---------------------------------- DO NOT FUCK WITH THIS CODE!!! SHIT IS SENSITIVE!!! ----------------------------//
//------------------------ SERIOUSLY... ASK BEFORE EDITING ANY OF THIS CODE SO YOU DON'T BREAK IT ------------------//
//------------------------------------------------------------------------------------------------------------------//

namespace AdapterLab
{
    class WriteToDB
    {
        List<string> lastBuffer = new List<string>();

        private MachineTool machineTool;
        private Report reportProc1;
        System.Data.OleDb.OleDbConnection conn;

        public WriteToDB(MachineTool machineTool)
        {
            this.machineTool = machineTool;
            
        }

        public WriteToDB(Report reportProc1)
        {
            this.reportProc1 = reportProc1;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Write To Dump DataBase --------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public short WriteToDump(List<List<string>> buffer)
        {
            string[] tempArray = new string[buffer.Count];
            short ret = 0;
            char[] delim = {','};

            for (int i = 0; i < buffer.Count; i++)
            {
                List<List<string>> splitBuffer = new List<List<string>>();
                for (int j = 0; j < buffer[i].Count; j++)
                {
                    tempArray = buffer[i][j].Split(delim);

                    List<string> tempSplit = new List<string>();
                    
                    tempSplit = tempArray.ToList();
                    splitBuffer.Add(tempSplit);

                }

                        try
                        {
                            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\OnsrudLog.accdb;Persist Security Info=False;");
                            conn.Open();
                            System.Data.OleDb.OleDbCommand cmd = new OleDbCommand(@"INSERT into dump(drives_ok, Alarm1, Alarm2, Alarm3, Alarm4, Alarm5, Alarm6, Alarm7, Alarm8, Alarm9, Alarm10, XPos, YPos, ZPos, APos, CPos, XLoad, YLoad, ZLoad, ALoad, CLoad, ULoad, Program, Sub_Program, Block, Line, Tool, Selected_Table, Process) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", conn);
                            cmd.Parameters.Add("drives_ok", splitBuffer[0][1]);
                            cmd.Parameters.Add("Alarm1", splitBuffer[1][1]);
                            cmd.Parameters.Add("Alarm2", splitBuffer[2][1]);
                            cmd.Parameters.Add("Alarm3", splitBuffer[3][1]);
                            cmd.Parameters.Add("Alarm4", splitBuffer[4][1]);
                            cmd.Parameters.Add("Alarm5", splitBuffer[5][1]);
                            cmd.Parameters.Add("Alarm6", splitBuffer[6][1]);
                            cmd.Parameters.Add("Alarm7", splitBuffer[7][1]);
                            cmd.Parameters.Add("Alarm8", splitBuffer[8][1]);
                            cmd.Parameters.Add("Alarm9", splitBuffer[9][1]);
                            cmd.Parameters.Add("Alarm10", splitBuffer[10][1]);
                            cmd.Parameters.Add("XPos", splitBuffer[11][1]);
                            cmd.Parameters.Add("YPos", splitBuffer[12][1]);
                            cmd.Parameters.Add("ZPos", splitBuffer[13][1]);
                            cmd.Parameters.Add("APos", splitBuffer[14][1]);
                            cmd.Parameters.Add("CPos", splitBuffer[15][1]);
                            cmd.Parameters.Add("XLoad", splitBuffer[16][1]);
                            cmd.Parameters.Add("YLoad", splitBuffer[17][1]);
                            cmd.Parameters.Add("ZLoad", splitBuffer[18][1]);
                            cmd.Parameters.Add("ALoad", splitBuffer[19][1]);
                            cmd.Parameters.Add("CLoad", splitBuffer[20][1]);
                            cmd.Parameters.Add("ULoad", splitBuffer[21][1]);
                            cmd.Parameters.Add("Program", splitBuffer[22][1]);
                            cmd.Parameters.Add("Sub_Program", splitBuffer[23][1]);
                            //cmd.Parameters.Add("Cycle_Time", splitBuffer[24][1]);
                            cmd.Parameters.Add("Block", splitBuffer[25][1]);
                            cmd.Parameters.Add("Line", splitBuffer[26][1]);
                            cmd.Parameters.Add("Tool", splitBuffer[27][1]);
                            cmd.Parameters.Add("Selected_Table", splitBuffer[28][1]);
                            cmd.Parameters.Add("Process", splitBuffer[29][1]);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception e)
                        {
                            conn.Close();
                            MessageBox.Show(e.ToString());

                        }
            }
                
                return ret;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Write To The Events Database --------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public short WriteToEvent(List<List<string>> buffer)
        {
            string[] bufferArray = GetChanged(buffer);
            short ret = 0;
            char[] delim = {','};
            string[][] bufferSplit = new string[bufferArray.Length][];
            bool changedValues = false;
            
            
                for (int i = 0; i < bufferArray.Length; i++)
                {
                    if (bufferArray[i] != null)
                    {
                        bufferSplit[i] = bufferArray[i].Split(delim);
                        changedValues = true;
                    }
                }

            if (changedValues == true)
            {
                try
                {
                    conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\OnsrudLog.accdb;Persist Security Info=False;");

                    conn.Open();

                    for (int i = 0; i < bufferSplit.Length; i++)
                    {
                        if (bufferSplit[i] != null && bufferSplit[i][1] != "0")
                        {
                            string header = bufferSplit[i][0];
                            string content = bufferSplit[i][1];
                            System.Data.OleDb.OleDbCommand cmd = new OleDbCommand(@"INSERT into events(header, content) values(?,?)", conn);
                            cmd.Parameters.Add("header", header);
                            cmd.Parameters.Add("content", content);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    conn.Close();
                    MessageBox.Show("Could not open Database! Error: " + e.ToString());
                    ret = -1;
                    return ret;
                }
                
                return ret;
            }
            return ret;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Write To The Down Time Database -----------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public short WriteToDownTime(List<List<string>> buffer)
        {
            string[] tempArray = new string[buffer.Count];
            List<List<List<string>>> finalBuffer = new List<List<List<string>>>();
            short ret = 0;
            char[] delim = {','};

            for (int i = 0; i < buffer.Count; i++)
            {
                List<List<string>> splitBuffer = new List<List<string>>();
                for (int j = 0; j < buffer[i].Count; j++)
                {
                    tempArray = buffer[i][j].Split(delim);

                    // tempArray.ToList();
                    List<string> tempSplit = new List<string>();
                    
                    tempSplit = tempArray.ToList();
                    splitBuffer.Add(tempSplit);

                }

                        try
                        {
                            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\downtime.accdb;Persist Security Info=False;");
                            conn.Open();
                            System.Data.OleDb.OleDbCommand cmd = new OleDbCommand(@"INSERT into downtime(start, end, duration, reason) values(?,?,?,?)", conn);
                            cmd.Parameters.Add("startime", splitBuffer[0][1]);
                            cmd.Parameters.Add("endtime", splitBuffer[1][1]);
                            cmd.Parameters.Add("duration", splitBuffer[2][1]);
                            cmd.Parameters.Add("reason", splitBuffer[3][1]);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception e)
                        {
                            conn.Close();
                            MessageBox.Show(e.ToString());

                        }
            }
                
                return ret;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Write to Snapshot Database ----------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        public short WriteToSnapshot(List<List<string>> buffer)
        {
            string[] tempArray = new string[buffer.Count];
            short ret = 0;
            char[] delim = { ',' };

            tempArray = buffer[buffer.Count - 1][buffer[buffer.Count - 1].Count - 1].Split(delim);
            List<string> tempSplit = new List<string>();
            tempSplit = tempArray.ToList();

                try
                {
                    conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\OnsrudLog.accdb;Persist Security Info=False;");
                    conn.Open();
                    System.Data.OleDb.OleDbCommand cmd = new OleDbCommand(@"INSERT into dump(drives_ok, Alarm1, Alarm2, Alarm3, Alarm4, Alarm5, Alarm6, Alarm7, Alarm8, Alarm9, Alarm10, XPos, YPos, ZPos, APos, CPos, XLoad, YLoad, ZLoad, ALoad, CLoad, ULoad, Program, Sub_Program, Block, Line, Tool, Selected_Table, Process) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", conn);
                    cmd.Parameters.Add("drives_ok", tempSplit[0][1]);
                    cmd.Parameters.Add("Alarm1", tempSplit[1][1]);
                    cmd.Parameters.Add("Alarm2", tempSplit[2][1]);
                    cmd.Parameters.Add("Alarm3", tempSplit[3][1]);
                    cmd.Parameters.Add("Alarm4", tempSplit[4][1]);
                    cmd.Parameters.Add("Alarm5", tempSplit[5][1]);
                    cmd.Parameters.Add("Alarm6", tempSplit[6][1]);
                    cmd.Parameters.Add("Alarm7", tempSplit[7][1]);
                    cmd.Parameters.Add("Alarm8", tempSplit[8][1]);
                    cmd.Parameters.Add("Alarm9", tempSplit[9][1]);
                    cmd.Parameters.Add("Alarm10", tempSplit[10][1]);
                    cmd.Parameters.Add("XPos", tempSplit[11][1]);
                    cmd.Parameters.Add("YPos", tempSplit[12][1]);
                    cmd.Parameters.Add("ZPos", tempSplit[13][1]);
                    cmd.Parameters.Add("APos", tempSplit[14][1]);
                    cmd.Parameters.Add("CPos", tempSplit[15][1]);
                    cmd.Parameters.Add("XLoad", tempSplit[16][1]);
                    cmd.Parameters.Add("YLoad", tempSplit[17][1]);
                    cmd.Parameters.Add("ZLoad", tempSplit[18][1]);
                    cmd.Parameters.Add("ALoad", tempSplit[19][1]);
                    cmd.Parameters.Add("CLoad", tempSplit[20][1]);
                    cmd.Parameters.Add("ULoad", tempSplit[21][1]);
                    cmd.Parameters.Add("Program", tempSplit[22][1]);
                    cmd.Parameters.Add("Sub_Program", tempSplit[23][1]);
                    //cmd.Parameters.Add("Cycle_Time", tempSplit[24][1]);
                    cmd.Parameters.Add("Block", tempSplit[25][1]);
                    cmd.Parameters.Add("Line", tempSplit[26][1]);
                    cmd.Parameters.Add("Tool", tempSplit[27][1]);
                    cmd.Parameters.Add("Selected_Table", tempSplit[28][1]);
                    cmd.Parameters.Add("Process", tempSplit[29][1]);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    conn.Close();
                    MessageBox.Show(e.ToString());

                }
            

            return ret;
        }

        //------------------------------------------------------------------------------------------------------------------//
        //---------------------------------- Get The Changed Values --------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------//

        private string[] GetChanged(List<List<string>> buffer)
        {
            int bufferSize = buffer.Count - 1;
            int values = buffer[0].Count;
            string[] changedValue = new string[values];
            string[] filter = { "X Pos", "Y Pos", "Z Pos", "A Pos", "C Pos", "U Pos", 
                                "X Load", "Y Load", "Z Load", "A Load", "C Load", "U Load",
                                "Cycle Time", "Block Number", "Current Line" };
            string[] split;
            char[] delim = { ',' };
            bool filtered = false;

            if (lastBuffer.Count == 0)
            {
               lastBuffer = buffer[bufferSize];
            }

            for (int i = 0; i < values; i++)
            {
                 //string temp = buffer[bufferSize][i].Substring(2, 3);
                 if (buffer[bufferSize][i] != lastBuffer[i])
                 {
                     // Split the item
                     split = buffer[bufferSize][i].Split(delim);

                     // Check each item again the filters.
                     for (int j = 0; j < filter.Length; j++)
                     {
                         if (split[0] != filter[j])
                         {
                             filtered = false;
                         }
                         else
                         {
                             filtered = true;
                         }
                     }
                     
                     // Filter out Alarms, Positions, Loads, Times and other unwanted items in the Events DB
                     if (i < 10 && buffer[bufferSize][i].Length == 7 || filtered)
                     {

                     }
                     else
                     {
                         changedValue[i] = buffer[bufferSize][i];
                         lastBuffer[i] = buffer[bufferSize][i];
                     }
                 }
             }
            
            return changedValue;
        }

    }
}
