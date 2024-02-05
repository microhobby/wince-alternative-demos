using Torizon;

namespace unoDemo;

public sealed partial class About : Page
{
    public About()
    {
        this.InitializeComponent();

        this.Loaded += (obj, e) => {
            var arch = TorizonInfo.GetArch();
            if (arch == TorizonInfo.Arch.Arm || arch == TorizonInfo.Arch.Arm64)
            {
                this.TorizonVersion.Text = TorizonInfo.GetTorizonVersion();
                this.LinuxVersion.Text = TorizonInfo.GetKernelVersion();

                this.BoardVersion.Text = DemoHardware.GetBoardModel();

                var _dotnetVersion =
                    System.Runtime.InteropServices
                        .RuntimeInformation.FrameworkDescription;
                this.DotNetVersion.Text =
                    $"{_dotnetVersion} running on {TorizonInfo.GetArch()}";
            }
        };
    }
}
