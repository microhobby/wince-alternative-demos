using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using Torizon;
using Torizon.Shell;
using Torizon.WinForms.Animations;

namespace monoDemo
{
    public partial class Form1 : Form
    {
        readonly DemoHardware _demoHardware;
        readonly bool _embedded = false;
        private PinValue _ledState = PinValue.Low;

        public Form1()
        {
            InitializeComponent();

            var myArch = TorizonInfo.GetArch();

            if (myArch == TorizonInfo.Arch.Arm || myArch == TorizonInfo.Arch.Arm64)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                this._embedded = true;
                // we are in a embedded system, so let's use the GPIO
                this._demoHardware = DemoHardware.GetHardware();

                this._demoHardware.ButtonRed.ButtonUp += (object sender, EventArgs e) =>
                {
                    // toggle the led in the UI thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.button1.PerformClick();
                    });
                };

                // get the Torizon info
                this.labelTorizonVersion.Text = TorizonInfo.GetTorizonVersion();

                // get the hardware info
                this.labelHWInfo.Text = DemoHardware.GetBoardModel();
            }
            else
            {
                this._embedded = false;
            }

            // load the images
            this.welcome.ImageLocation = "./assets/monotechs.png";
            this.pictureBox1.ImageLocation = "./assets/ledoff.png";
            this.pictureBox2.ImageLocation = "./assets/torizon-logo-icon.png";
            this.pictureBox3.ImageLocation = "./assets/mono.png";
            this.pictureBox4.ImageLocation = "./assets/board.png";
            this.pictureBox5.ImageLocation = "./assets/tux.png";

            // get the kernel version
            this.labelKernelVersion.Text = TorizonInfo.GetKernelVersion();

            // get the framework version
            var framework = RuntimeInformation.FrameworkDescription;
            this.labelFrameworkVersion.Text = framework;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._embedded)
            {
                // toggle the led
                if (this._ledState == PinValue.Low)
                {
                    this._ledState = PinValue.High;
                    this.pictureBox1.ImageLocation = "./assets/ledon.png";
                }
                else
                {
                    this._ledState = PinValue.Low;
                    this.pictureBox1.ImageLocation = "./assets/ledoff.png";
                }

                this._demoHardware.LedRed.Write(this._ledState);
            }
        }

        private void CallZoomIn()
        {
            ImageAnimator.ZoomIn(
                this.imageModule,
                this.imageModule.Image.Width,
                this.imageModule.Image.Height,
                10, // tick
                1, // pace
                () => {
                    // only continue if the animation tab is selected
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                        this.CallZoomOut();
                }
            );
        }

        private void CallZoomOut()
        {
            ImageAnimator.ZoomOut(
                this.imageModule,
                0,
                0,
                10, // tick
                1, // pace
                () => {
                    // only continue if the animation tab is selected
                    if (this.tabControl1.SelectedTab == this.tabPage3)
                        this.CallZoomIn();
                }
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.imageModule.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imageModule.LoadAsync("https://docs.toradex.com/112616-apalis-imx8qm-8gb-wbit-front.png");
            //this.imageModule.LoadAsync("https://media1.tenor.com/m/apxQpu70-i4AAAAd/funny-animals-dog.gif");
            this.tableInfo.AutoScroll = true;

            // make sure to hide the onboard keyboard
            Exec.Bash(
                "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Hide"
            );

            // if you want to show the onboard screen you need to do it yourself
            EventHandler onboardToggle = (_sender, _e) =>
            {
                Exec.Bash(
                    "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.ToggleVisible"
                );
            };

            this.textBoxInput.GotFocus += onboardToggle;
            //this.textBoxInput.LostFocus += onboardToggle;
            this.textBoxInput.Leave += onboardToggle;

            // set the input text to the label
            this.textBoxInput.TextChanged += (_sender, _e) =>
            {
                this.labelInput.Text = $"Input ({this.textBoxInput.Text}): ";
            };

            // touch like events ??
            // If you want it you need to write it yourself
            bool _dragging = false;
            System.Drawing.Point _start = new System.Drawing.Point(0, 0);

            this.tableInfo.MouseDown += (_sender, _e) =>
            {
                _dragging = true;
                _start = _e.Location;
            };

            this.tableInfo.MouseMove += (_sender, _e) =>
            {
                if (_dragging)
                {
                    // get how many pixels we moved
                    System.Drawing.Point newPoint =
                        new System.Drawing.Point(
                            _start.X - _e.Location.X,
                            _start.Y - _e.Location.Y
                        );

                    // move the scroll bar
                    // update the start point
                    _start = _e.Location;
                    // and then move the scroll bar
                    var val = this.tableInfo.VerticalScroll.Value + newPoint.Y;

                    if (val > this.tableInfo.VerticalScroll.Maximum) {
                        this.tableInfo.VerticalScroll.Value = this.tableInfo.VerticalScroll.Maximum;
                    } else if (val < this.tableInfo.VerticalScroll.Minimum) {
                        this.tableInfo.VerticalScroll.Value = this.tableInfo.VerticalScroll.Minimum;
                    } else {
                        this.tableInfo.VerticalScroll.Value = val;
                    }
                }
            };

            this.tableInfo.MouseUp += (_sender, _e) =>
            {
                _dragging = false;
            };
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.tabPage3)
            {
                this.CallZoomIn();
            }
        }
    }
}
