
using System.Windows.Forms;

namespace Torizon.WinForms.Animations
{
    public class ImageAnimator
    {
        public delegate void AnimationFinished();

        public static void ZoomIn(
            PictureBox img, int w, int h,
            int tick = 10,
            int pace = 10,
            AnimationFinished callback = null
        ) {
            double aspectRatio = (double)w / h;

            // zero it
            img.Size = new System.Drawing.Size(0, 0);

            // center it
            img.Location = new System.Drawing.Point(
                (img.Parent.ClientSize.Width - img.Width) / 2,
                (img.Parent.ClientSize.Height - img.Height) / 2
            );

            var zoomTimer = new Timer();
            zoomTimer.Interval = tick; // ms
            zoomTimer.Tick += (sender, e) => {
                // the arguments w and h are the limits, the end of the size
                // zoom in in perspective
                if (img.Width < w)
                {
                    img.Width += pace;
                    img.Height = (int)(img.Width / aspectRatio);
                    // fix it on the center
                    img.Location = new System.Drawing.Point(
                        (img.Parent.ClientSize.Width - img.Width) / 2,
                        (img.Parent.ClientSize.Height - img.Height) / 2
                    );
                }

                if (img.Height < h)
                {
                    img.Height += pace;
                    img.Width = (int)(img.Height * aspectRatio);
                    // fix it on the center
                    img.Location = new System.Drawing.Point(
                        (img.Parent.ClientSize.Width - img.Width) / 2,
                        (img.Parent.ClientSize.Height - img.Height) / 2
                    );
                }

                if (img.Width >= w && img.Height >= h)
                {
                    zoomTimer.Stop();

                    // call the callback
                    callback?.Invoke();
                }
            };

            zoomTimer.Start();
        }

        public static void ZoomOut(
            PictureBox img, int w, int h,
            int tick = 10,
            int pace = 10,
            AnimationFinished callback = null
        ) {
            double aspectRatio = (double)img.Width / img.Height;

            var zoomTimer = new Timer();
            zoomTimer.Interval = tick; // ms
            zoomTimer.Tick += (sender, e) => {
                // the arguments w and h are the limits, the end of the size
                // zoom out in perspective
                if (img.Width > w)
                {
                    img.Width -= pace;
                    img.Height = (int)(img.Width / aspectRatio);
                    // fix it on the center
                    img.Location = new System.Drawing.Point(
                        (img.Parent.ClientSize.Width - img.Width) / 2,
                        (img.Parent.ClientSize.Height - img.Height) / 2
                    );
                }

                if (img.Height > h)
                {
                    img.Height -= pace;
                    img.Width = (int)(img.Height * aspectRatio);
                    // fix it on the center
                    img.Location = new System.Drawing.Point(
                        (img.Parent.ClientSize.Width - img.Width) / 2,
                        (img.Parent.ClientSize.Height - img.Height) / 2
                    );
                }

                if (img.Width <= w && img.Height <= h)
                {
                    zoomTimer.Stop();

                    // call the callback
                    callback?.Invoke();
                }
            };

            zoomTimer.Start();
        }
    }
}
