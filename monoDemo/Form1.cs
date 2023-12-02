using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.Unix.Native;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using Torizon;

namespace monoDemo
{
    public partial class Form1 : Form
    {
        readonly DemoHardware _demoHardware;
        readonly bool _embedded = false;
        private PinValue _ledState = PinValue.Low;

        public static string ExecuteCommand(string command)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash", // or "cmd.exe" on Windows
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        public Form1()
        {
            var res = Syscall.uname(out Utsname uts);

            InitializeComponent();

            if (res != 0) {
                throw new Exception("Failed to get machine architecture");
            } else {

                if (uts.machine.Contains("arm") || uts.machine.Contains("aarch64")) {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;

                    this._embedded = true;
                    // we are in a embedded system, so let's use the GPIO]
                    this._demoHardware = new DemoVerdinIMX8MP();

                    this._demoHardware.ButtonRed.ButtonUp += (object sender, EventArgs e) =>
                    {
                        // toggle the led in the UI thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.button1.PerformClick();
                        });
                    };

                    // get the Torizon info
                    var vtorizon = ExecuteCommand("grep PRETTY_NAME /etc/os-release | cut -d= -f2- | tr -d '\\\"'");
                    this.labelTorizonVersion.Text = vtorizon;

                    // get the hardware info
                    var hardware = ExecuteCommand("cat /proc-host/device-tree/model");
                    this.labelHWInfo.Text = hardware;
                } else {
                    this._embedded = false;
                }

                // laod the images
                this.pictureBox1.ImageLocation = "./assets/ledoff.png";
                this.pictureBox2.ImageLocation = "./assets/torizon-logo-icon.png";
                this.pictureBox3.ImageLocation = "./assets/mono.png";
                this.pictureBox4.ImageLocation = "./assets/board.png";

                // get the framework info
                // style the table to have a gray background in the second row
                this.tableInfo.CellPaint += (object sender, TableLayoutCellPaintEventArgs e) =>
                {
                    if (e.Row == 1) {
                        e.Graphics.FillRectangle(
                            Brushes.LightGray, e.CellBounds
                        );
                    }
                };

                var framework = RuntimeInformation.FrameworkDescription;
                this.labelFrameworkVersion.Text = framework;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._embedded) {
                // toggle the led
                if (this._ledState == PinValue.Low) {
                    this._ledState = PinValue.High;
                    this.pictureBox1.ImageLocation = "./assets/ledon.png";
                } else {
                    this._ledState = PinValue.Low;
                    this.pictureBox1.ImageLocation = "./assets/ledoff.png";
                }

                this._demoHardware.LedRed.Write(this._ledState);
            }
        }
    }
}
