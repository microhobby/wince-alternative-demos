
using System.Device.Gpio;
using Iot.Device.Button;

namespace Torizon {

    public class DemoVerdinIMX8MP : DemoHardware
    {
        override protected int Gpiochip { get => 0; }
        override protected int PinLedRed { get => 1; }
        override protected int PinButtonRed { get => 6; }

        public DemoVerdinIMX8MP() : base()
        {
        }
    }

}
