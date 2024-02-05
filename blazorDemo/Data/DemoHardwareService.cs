namespace blazorDemo.DemoHardware;

using System.Device.Gpio;
using Iot.Device.Gpio.Drivers;
using Torizon;

public class DemoHardwareService
{
    public DemoHardware? Hardware { get; set; }
    public bool IsEmbedded => this.Hardware != null;
    private bool _ledState;
    public PinValue LEDState {
        get {
            return _ledState ? PinValue.High : PinValue.Low;
        }

        set {
            _ledState = value == PinValue.High;
            if (this.IsEmbedded)
            {
                this.Hardware!.LedRed.Write(_ledState);
            }
        }
    }

    public DemoHardwareService()
    {
        // create the hardware singleton ?
        var myArch = TorizonInfo.GetArch();
        if (myArch == TorizonInfo.Arch.Arm || myArch == TorizonInfo.Arch.Arm64)
        {
            // we are in a embedded system, so let's use the GPIO
            this.Hardware = DemoHardware.GetHardware();
        }
    }
}
