
using System;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using Iot.Device.Button;
using Torizon.Shell;

namespace Torizon {

    public abstract class DemoHardware : IDemoHardware
    {
        public GpioPin LedRed { get; set; }
        public GpioButton ButtonRed { get; set; }

        protected virtual int Gpiochip { get; }
        protected virtual int PinLedRed { get; }
        protected virtual int PinButtonRed { get; }

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
            switch (board)
            {
                case Board.ApalisIMX8:
                    return new DemoApalisIMX8();
                case Board.VerdinIMX8MP:
                    return new DemoVerdinIMX8MP();
                default:
                    throw new System.Exception($"Unknown board :: {board}");
            }
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
        }
    }
}
