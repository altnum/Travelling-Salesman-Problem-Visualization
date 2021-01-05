using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingSalesmanProblemVisualization
{
    public partial class StopController : Form
    {
        public StopController()
        {
            InitializeComponent();
        }

        private void StopController_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void StopController_FormClosing(object sender, FormClosingEventArgs e)
        {
            


            
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (Program.travellingSalesman.finishedCalc == false && timer1.Enabled)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                Program.travellingSalesman.pressedStop = true;
                ContinueButton.Visible = true;
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (Program.travellingSalesman.finishedCalc == false && timer1.Enabled)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                Program.travellingSalesman.pressedStop = false;
                Program.travellingSalesman.mre.Set();
                ContinueButton.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.travellingSalesman.finishedCalc)
                timer1.Stop();
            TimeHolder.Text = (int.Parse(TimeHolder.Text) + 1).ToString();
        }

        private void StopController_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void BreakButton_Click(object sender, EventArgs e)
        {
            if (Program.travellingSalesman.finishedCalc == false)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                Program.travellingSalesman.finishedCalc = true;
                Program.travellingSalesman.pressedStop = true;
                Program.travellingSalesman.Enabled = true;

                Program.travellingSalesman.mre.Set();
            }

            Close();

            //Program.travellingSalesman.routes = "";

            //Program.travellingSalesman.distanceStatus.Text = "Distance in km: ";
        }
    }
}
