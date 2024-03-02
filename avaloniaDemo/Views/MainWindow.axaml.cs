using System.Device.Gpio;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Torizon;

namespace avaloniaDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // only run in fullscreen if in the embedded
        if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
        {
            this.WindowState = WindowState.FullScreen;
        }
    }
}
