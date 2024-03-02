
using System;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using System.Device.I2c;
using Iot.Device.Button;
using Iot.Device.CharacterLcd;
using Torizon.Shell;

namespace Torizon {

    public abstract class DemoHardware : IDemoHardware
    {
        public GpioPin LedRed { get; set; }
        public GpioButton ButtonRed { get; set; }
        public Lcd1602 LCDDisplay { get; set; }

        protected virtual int Gpiochip { get; }
        protected virtual int PinLedRed { get; }
        protected virtual int PinButtonRed { get; }
        protected virtual int I2cBusId { get; }

        protected GpioController _gpioController;

        public enum Board
        {
            ApalisIMX8,
            VerdinIMX8MP,
            Unknown
        }

        public static string GetBoardModel()
        {
            var res = Exec.Bash("cat /proc-host/device-tree/model");
            if (res.exitCode != 0)
            {
                throw new System.Exception($"Failed to get board model :: {res.exitCode}");
            }

            return res.output;
        }

        public static Board GetBoard()
        {
            var model = GetBoardModel();
            if (model.Contains("Apalis iMX8"))
            {
                return Board.ApalisIMX8;
            }
            else if (model.Contains("Verdin iMX8M Plus"))
            {
                return Board.VerdinIMX8MP;
            }
            else
            {
                return Board.Unknown;
            }
        }

        public static DemoHardware GetHardware()
        {
            var board = GetBoard();
            return board switch
            {
                Board.ApalisIMX8 => new DemoApalisIMX8(),
                Board.VerdinIMX8MP => new DemoVerdinIMX8MP(),
                _ => throw new System.Exception($"Unknown board :: {board}"),
            };
        }

        public DemoHardware()
        {
            this._gpioController =
                new GpioController(
                    PinNumberingScheme.Logical,
                    new LibGpiodDriver(this.Gpiochip)
                );

            LedRed = this._gpioController.OpenPin(
                PinLedRed,
                PinMode.Output,
                PinValue.Low
            );

            ButtonRed = new GpioButton(
                PinButtonRed,
                false,
                true,
                this._gpioController,
                false,
                TimeSpan.FromMilliseconds(120)
            );

            var i2cDevSettings = new I2cConnectionSettings(
                this.I2cBusId, 0x3f
            );
            var i2cDev = I2cDevice.Create(i2cDevSettings);
            LCDDisplay = new Lcd1602(i2cDev, false) {
                BlinkingCursorVisible = false
            };
            // only to make sure the display is clear
            LCDDisplay.Clear();
        }
    }
}
