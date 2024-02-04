
namespace Torizon
{

    public class DemoApalisIMX8 : DemoHardware
    {
        override protected int Gpiochip { get => 2; }
        override protected int PinLedRed { get => 12; }
        override protected int PinButtonRed { get => 6; }

        public DemoApalisIMX8() : base()
        {
        }
    }

}
