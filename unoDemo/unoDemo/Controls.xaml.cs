using System.Device.Gpio;
using Iot.Device.Graphics;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Torizon;
using BitmapImage = Microsoft.UI.Xaml.Media.Imaging.BitmapImage;

namespace unoDemo;

public sealed partial class Controls : Page
{
    DemoHardware? demoHardware;
    PinValue ledState = PinValue.Low;
    BitmapImage _ledOffBitmap = new(new Uri("ms-appx:///unoDemo/Assets/ledoff.png"));
    BitmapImage _ledOnBitmap = new(new Uri("ms-appx:///unoDemo/Assets/ledon.png"));

    public Controls()
    {
        this.InitializeComponent();

        this.Loaded += (obj, e) => {
            var arch = TorizonInfo.GetArch();
            if (arch == TorizonInfo.Arch.Arm || arch == TorizonInfo.Arch.Arm64)
            {
                demoHardware ??= DemoHardware.GetHardware();
            }
        };
    }

    public void OnTextChanging(object sender, TextBoxTextChangingEventArgs e)
    {
        var text = ((TextBox)sender).Text;
        this.TextInputLabel.Text = $"Input ({text})";

        if (demoHardware == null)
        {
            return;
        }

        demoHardware.LCDDisplay.Clear();
        demoHardware.LCDDisplay.Write(text);
    }

    public void OnLedToggle(object sender, RoutedEventArgs e)
    {
        if (demoHardware == null)
        {
            return;
        }

        ledState = (ledState == PinValue.Low) ? PinValue.High : PinValue.Low;
        demoHardware.LedRed.Write(ledState);

        // also change the image twin
        this.LedImage.Source =
            ledState == PinValue.High ?
                _ledOnBitmap : _ledOffBitmap;
    }
}
