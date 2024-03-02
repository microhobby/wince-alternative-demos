using System.Runtime.InteropServices;
using System.Device.Gpio;
using Avalonia.Controls;
using Torizon;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace avaloniaDemo.Views;

public partial class ControlsView : UserControl
{
    DemoHardware? demoHardware;
    PinValue ledState = PinValue.Low;
    readonly Bitmap _ledOffBitmap = new(
        AssetLoader.Open(new Uri("avares://avaloniaDemo/Assets/ledoff.png"))
    );
    readonly Bitmap _ledOnfBitmap = new(
        AssetLoader.Open(new Uri("avares://avaloniaDemo/Assets/ledon.png"))
    );

    public ControlsView()
    {
        InitializeComponent();

        this.Loaded += (obj, e) => {
            var arch = TorizonInfo.GetArch();

            // is embedded ??
            if (
                arch == TorizonInfo.Arch.Arm64 ||
                arch == TorizonInfo.Arch.Arm
            )
            {
                demoHardware ??= DemoHardware.GetHardware();
            }
        };
    }

    public void TextBox_TextChanging (object sender, TextChangingEventArgs e)
    {
        if (demoHardware == null)
        {
            return;
        }

        var text = this.TextInput.Text;
        demoHardware.LCDDisplay.Clear();
        demoHardware.LCDDisplay.Write(text!);
    }

    public void OnLed_Toggle (object sender, RoutedEventArgs e)
    {
        if (demoHardware == null)
        {
            return;
        }

        ledState = (ledState == PinValue.Low) ? PinValue.High : PinValue.Low;
        demoHardware.LedRed.Write(ledState);

        // also change the image twin
        this.LedImage.Source =
            (ledState == PinValue.Low) ? _ledOffBitmap : _ledOnfBitmap;
    }
}
