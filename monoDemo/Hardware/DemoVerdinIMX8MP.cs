
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
        // SODIMM 53
        // SODIM 55
        // Yavia J3 - 25 SDA
        // Yavia J3 - 26 SCL
        override protected int I2cBusId { get => 1; }

        public DemoVerdinIMX8MP() : base()
        {
        }
    }

}
