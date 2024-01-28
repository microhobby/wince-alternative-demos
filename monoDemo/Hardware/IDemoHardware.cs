using System.Device.Gpio;
using Iot.Device.Button;

namespace Torizon
{

    public interface IDemoHardware
    {
        GpioPin LedRed { get; set; }
        GpioButton ButtonRed { get; set; }
    }

}
