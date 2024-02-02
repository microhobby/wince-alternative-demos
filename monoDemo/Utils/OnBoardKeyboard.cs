using System;
using Torizon.Shell;

namespace Torizon.WinForms.OnBoardKeyboard
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        private readonly EventHandler _onboardHide = (_sender, _e) =>
        {
            Exec.Bash(
                "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Hide"
            );
        };

        private readonly EventHandler _onboardShow = (_sender, _e) =>
        {
            Exec.Bash(
                "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Show"
            );
        };

        public TextBox() : base()
        {
            // construct it and already hide the keyboard
            Exec.Bash(
                "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Hide"
            );

            this.GotFocus += _onboardShow;
            this.LostFocus += _onboardHide;
        }
    }
}
