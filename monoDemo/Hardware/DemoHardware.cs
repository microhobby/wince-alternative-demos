
using System;
using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using Iot.Device.Button;

namespace Torizon {

    public abstract class DemoHardware : IDemoHardware
    {
        public GpioPin LedRed { get; set; }
        public GpioButton ButtonRed { get; set; }

        protected virtual int Gpiochip { get; }
        protected virtual int PinLedRed { get; }
        protected virtual int PinButtonRed { get; }

        protected GpioController _gpioController;

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
