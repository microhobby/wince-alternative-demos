using Toradex.Utils;

namespace unoDemo;

public sealed partial class Animation : Page, IDisposable
{
    private bool _isAnimating = true;

    public new void Dispose()
    {
        _isAnimating = false;
        base.Dispose();
        GC.SuppressFinalize(this);
    }

    public Animation()
    {
        this.InitializeComponent();

        this.Loaded += (obj, e) => {
            _isAnimating = true;

            var outAgain = () => {
            };

            var inAgain = () => {
                if (!_isAnimating) return;
                Animations.ImageZoomIn(this.ImageToAnimate, 1, 2000, outAgain);
            };

            outAgain = () => {
                if (!_isAnimating) return;
                Animations.ImageZoomOut(this.ImageToAnimate, 0, 2000, inAgain);
            };

            Animations.ImageZoomOut(this.ImageToAnimate, 0, 2000, inAgain);
        };
    }

}
