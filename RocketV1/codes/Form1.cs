using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.XInput;
using System.Diagnostics;
using System.IO.Ports;


namespace rocketManualv2
{
    public partial class Form1 : Form
    {

        private Controller controller;
        private Stopwatch stopwatch;
        private int angle;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Controller";
            controller = new Controller(UserIndex.One);

            timer1.Interval = 10;
            timer1.Start();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            init();
            stopwatch = Stopwatch.StartNew();
        }

        public void init()
        {
            if (!port.IsOpen)
            {
                try
                {
                    port.Open();
                }
                catch(Exception)
                {
                    MessageBox.Show("fix me up //init func.");
                }
            }
        }

        public void sender()
        {
            try
            {
                if (!port.IsOpen)
                {
                    init();
                }
                if (port.IsOpen)
                {
                    port.Write(angle.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("you suck at coding try something else moron");
            }
        }


        public void varTest()
        {
            var batteryInfo = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
            var state = controller.GetState();

            //fix it (displays empty)
            batteryLabel.Text = batteryInfo.BatteryLevel.ToString();


            //Gamepad Buttons
            if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y))
            {
                labelY.BackColor = Color.Red;
            }
            else
            {
                labelY.BackColor = Color.Gray;
            }

            if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X))
            {
                labelX.BackColor = Color.Red;
            }
            else
            {
                labelX.BackColor = Color.Gray;
            }

            if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B))
            {
                labelB.BackColor = Color.Red;
            }
            else
            {
                labelB.BackColor = Color.Gray;
            }

            if (state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
            {
                labelA.BackColor = Color.Red;
            }
            else
            {
                labelA.BackColor = Color.Gray;
            }


            //Triggers
            const int triggerThreshold = 10;
            int rightTrigger = state.Gamepad.RightTrigger;
            int leftTrigger1 = state.Gamepad.LeftTrigger;

            bool isRightTriggerAction = triggerThreshold < rightTrigger;
            bool isLeftTriggerAction = triggerThreshold < leftTrigger1;

            this.rightTrigger.Maximum = 255;
            this.leftTrigger1.Maximum = 255;

            if (isRightTriggerAction == true)
            {
                this.rightTrigger.Value = rightTrigger;
                rightNum.Text = rightTrigger.ToString();

                if (this.rightTrigger.Value > this.rightTrigger.Maximum)
                {
                    this.rightTrigger.Value = 256;
                    rightNum.Text = rightTrigger.ToString();
                }
            }
            else
            {
                this.rightTrigger.Value = 0;
                rightNum.Text = rightTrigger.ToString();
            }


            if (isLeftTriggerAction == true)
            {
                this.leftTrigger1.Value = leftTrigger1;
                leftNum.Text = leftTrigger1.ToString();

                if (this.leftTrigger1.Value > this.leftTrigger1.Maximum)
                {
                    this.leftTrigger1.Value = 255;
                    leftNum.Text = leftTrigger1.ToString();
                }
            }
            else
            {
                this.leftTrigger1.Value = 0;
                leftNum.Text = leftTrigger1.ToString();
            }


            //Thumbstick test

            xValued.Text = state.Gamepad.LeftThumbX.ToString();
            yValued.Text = state.Gamepad.LeftThumbY.ToString();

            //max x = 32767
            //min x = -32768

            int sizeOfxCoord = xCoord.Size.Width;
            //int sizeOfyCoord = yCoord.Size.Height;

            int valueLeftXX = state.Gamepad.LeftThumbX;
            int valueLeftXX2MakeItWork = Math.Abs(valueLeftXX);

            int maxBorderXX = 32767;
            int minBorderXX = -32768;

            int valueLeftXY = state.Gamepad.LeftThumbY;
            int valueLeftXY2MakeItWork = Math.Abs(valueLeftXY);

            int maxBorderXY = 32767;
            int minBorderXY = -32768;

            int thumbstickThreshold = 10;
            bool isLeftThumbXXAction = thumbstickThreshold < valueLeftXX2MakeItWork;
            bool isLeftThumbXYAction = thumbstickThreshold < valueLeftXY2MakeItWork;

            var xBarLocation = xBar.Location;
            int xBarYLocation = xBarLocation.Y;
            int xBarXLocation = xBarLocation.X;

            int rangeXXLeft = sizeOfxCoord / 2 - xBar.Size.Width / 2;
            int rangeXYUp = sizeOfxCoord / 2 - xBar.Size.Height / 2;
            //sizeOfx.Text = rangeXLeft.ToString(); -> 60

            // 0 -> 32768
            // 0 -> 60

            int ratioXXMin = minBorderXX / rangeXXLeft;
            int ratioXXMax = maxBorderXX / rangeXXLeft;

            int ratioXYMin = minBorderXY / rangeXYUp;
            int ratioXYMax = maxBorderXY / rangeXYUp;
            //sizeOfx.Text = ratioXX.ToString(); -> 546

            int ratedXXRangeMin = valueLeftXX / ratioXXMin;
            int ratedXXRangeMax = valueLeftXX / ratioXXMax;

            int ratedXYRangeMin = valueLeftXY / ratioXYMin;
            int ratedXYRangeMax = valueLeftXY / ratioXYMax;

            //ratedXXRangeMax = 44
            //ratedXXRangeMin = -44

            int angle = (ratedXXRangeMax + 44) * 2 + 2;

            label3.Text = angle.ToString();


            if (isLeftThumbXXAction == true)
            {


                if (valueLeftXX >= 0)
                {
                    xBar.Location = new Point(104 - ratedXXRangeMin, 205);
                    xBar.BackColor = Color.Red;

                    sender();


                }

                if (valueLeftXX < 0)
                {
                    xBar.Location = new Point(104 - (-1 * ratedXXRangeMax), 205);
                    xBar.BackColor = Color.Red;

                    sender();

                }


            }
            else if (isLeftThumbXXAction == false)
            {
                xBar.Location = new Point(104, 205);
                xBar.BackColor = Color.Black;

            }

            if (isLeftThumbXYAction == true)
            {

                if (valueLeftXY > 0)
                {
                    yBar.Location = new Point(106, 347 + ratedXYRangeMin);
                    yBar.BackColor = Color.Red;
                }

                if (valueLeftXY < 0)
                {
                    yBar.Location = new Point(106, 347 + (-1 * ratedXYRangeMax));
                    yBar.BackColor = Color.Red;
                }
            }

            else if (isLeftThumbXYAction == false)
            {
                yBar.Location = new Point(106, 347);
                yBar.BackColor = Color.Black;
            }
        }

        public void portWrite()
        {
            if (stopwatch.ElapsedMilliseconds > 100)
            {
                stopwatch.Restart();
                port.Write(angle.ToString());
            }
        }
        

        
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!controller.IsConnected)
            {
                statusLabel.Text = "Disconnected.";
            }

            else if (controller.IsConnected)
            {
                statusLabel.Text = "Connected.";
                varTest();

            }
        }
    }
}
