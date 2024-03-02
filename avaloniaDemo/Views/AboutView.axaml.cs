using System.Runtime.InteropServices;
using Avalonia.Controls;
using Torizon;

namespace avaloniaDemo.Views;

public partial class AboutView : UserControl
{
    public AboutView()
    {
        InitializeComponent();

        this.Loaded += (obj, e) => {
            var arch = TorizonInfo.GetArch();
            if (
                arch == TorizonInfo.Arch.Arm64 ||
                arch == TorizonInfo.Arch.Arm
            )
            {
                this.TorizonVersion.Text = TorizonInfo.GetTorizonVersion();
                this.LinuxVersion.Text = TorizonInfo.GetKernelVersion();

                this.BoardVersion.Text = DemoHardware.GetBoardModel();

                var _dotnetVersion = RuntimeInformation.FrameworkDescription;
                this.DotNetVersion.Text =
                    $"{_dotnetVersion} running on {arch}";
            }
        };
    }
}
