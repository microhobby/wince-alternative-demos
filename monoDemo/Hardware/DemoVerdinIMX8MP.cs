
using System.Device.Gpio;
using Iot.Device.Button;

namespace Torizon
{

    public class DemoVerdinIMX8MP : DemoHardware
    {
        override protected int Gpiochip { get => 0; }
        // SODIMM 212
        // Yavia J3 - 24
        override protected int PinLedRed { get => 6; }
        // SODIMM 208
        // Yavia J3 - 22
        override protected int PinButtonRed { get => 1; }

        public DemoVerdinIMX8MP() : base()
        {
        }
    }

}
