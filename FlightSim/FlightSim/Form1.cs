using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSim
{
    public partial class Form1 : Form
    {

        double t = 0;
        double dt = 0.1;
        Atm logic;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) timer1.Stop();
            else timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            t = 0;
            double y0 = (double)edHeight.Value;
            double v0 = (double)edVelocity.Value;
            double a = (double)edAngle.Value;
            double weight = (double)edWeight.Value;
            double S = (double)edSquare.Value;
            logic = new Atm(y0,v0,a,S,weight);

            
            labDistance.Text = Convert.ToString(logic.calculateXY(0).Item1);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            Tuple<double, double> coords = logic.calculateXY(t);
            label4.Text = Convert.ToString(t);
            labDistance.Text = Convert.ToString(coords.Item1);
            if (logic.isLanded()) timer1.Stop();
        }
    }
}
