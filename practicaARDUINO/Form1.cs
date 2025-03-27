using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace practicaARDUINO
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; }
        public Form1()
        {
            InitializeComponent();
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM3";
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            this.FormClosing += Form1_FormClosing;
            this.btnApagado.Click += btnApagado_Click;
            this.btnEncender.Click += btnEncender_Click;
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
        private void btnApagado_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }
    }
}
