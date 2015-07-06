using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdapterLab
{
    using MTConnect;
    public partial class password : Form
    {
        private MachineTool machineTool;
        Adapter mAdapter = new Adapter();
        //Event mAvail = new Event("avail");

        public password()
        {
            InitializeComponent();
        }

        public password(MachineTool machineTool)
        {
            // TODO: Complete member initialization
            this.machineTool = machineTool;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == "OEM")
            {
                try
                {
                    this.machineTool.editModeEnable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (this.machineTool.connected)
                {
                    MessageBox.Show(this, "Changes will not take affect until the adapter has been stopped", "Warning");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Password Incorrect!", "Incorrect");
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = this.machineTool.Location;
            this.Left += this.machineTool.ClientSize.Width / 2 - this.Width / 2;
            this.Top += this.machineTool.ClientSize.Height / 2 - this.Height / 2;

            this.AcceptButton = button1;
        }
    }
}
