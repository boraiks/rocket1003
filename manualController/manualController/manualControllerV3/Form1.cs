using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;
using System.Diagnostics;
using System.IO.Ports;


namespace manualControllerV3
{
    public partial class Form1 : Form
    {
        private Controller controller;
        public Stopwatch watch { get; set; }

        public Form1()
        {
            InitializeComponent();
            controller = new Controller(UserIndex.One);
            this.Text = "RocketManual";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watch = Stopwatch.StartNew();
            portOpener();
            timer.Start();
        }

        public void controllerCheck()
        {
            if(controller.IsConnected)
            {
                status.Text = "Connected";
            }
            
            else
            {
                status.Text = "Disconnected.";
            }
            
        }

        public void portOpener()
        {
            if (!port.IsOpen)
            {
                try
                {
                    port.Open();
                    error.Text = "";
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message;
                }
            }
        }

        public void controllerMovement()
        {

            if (controller.IsConnected)
            {
                var state = controller.GetState();

                int xValue= state.Gamepad.LeftThumbX;
                int yValue = state.Gamepad.LeftThumbY;
                //max = 32676, min = -32678

                int rangeBetweenRedBoxAndBlackBoxBorder = (blackBox.Width - redBox.Width) / 2;
                int xRatio = (xValue / rangeBetweenRedBoxAndBlackBoxBorder) / 10;
                int yRatio = (yValue / rangeBetweenRedBoxAndBlackBoxBorder) / 10;


                int xAngle = (xRatio + 44) * 2 + 2;
                int yAngle = (yRatio + 44) * 2 + 2;

                //x angle
                if (xAngle > 180)
                {
                    xAngle = 180;
                }

                if (xAngle < 0)
                {
                    xAngle = 0;
                }

                //y angle
                if (yAngle > 180)
                {
                    yAngle = 180;
                }

                if (yAngle < 0)
                {
                    yAngle = 0;
                }

                xValueLabel.Text = xAngle.ToString();
                yValueLabel.Text = yAngle.ToString();

                redBox.Location = new Point(13 + xAngle, 183-yAngle);
                
                if (port.IsOpen)
                {
                    port.Write("X");
                    port.Write(xAngle.ToString());

                    port.Write("Y");
                    port.Write(yAngle.ToString());
                }
            }

        }

        public void repeater()
        {
            if (watch.ElapsedMilliseconds > 15)
            {
                watch = Stopwatch.StartNew();
                //this project made by boraiks
                portOpener();
                controllerCheck();
                controllerMovement();

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                repeater();
                error2.Text = "";
            }

            catch (Exception ex)
            {
                error2.Text = ex.Message;
            }
        }
    }
}
