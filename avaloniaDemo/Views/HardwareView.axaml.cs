using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Media;

namespace avaloniaDemo.Views;

public partial class HardwareView : UserControl
{
    public HardwareView()
    {
        InitializeComponent();

        this.Loaded += (obj, e) => {
            //this.ImageToAnimate.RenderTransform = new ScaleTransform(0.5, 0.5);
        };
    }
}
