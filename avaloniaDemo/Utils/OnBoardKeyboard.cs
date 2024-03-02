using System;
using Torizon.Shell;

namespace Torizon.Controls;

public class TextBox : Avalonia.Controls.TextBox
{
    protected override Type StyleKeyOverride { get; }

    public TextBox() : base()
    {
        this.StyleKeyOverride = typeof(Avalonia.Controls.TextBox);

        // construct it and already hide the keyboard
        Exec.Bash(
            "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Hide"
        );

        GotFocus += (_sender, _e) => {
            Exec.Bash(
                "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Show"
            );
        };

        LostFocus += (_sender, _e) => {
            Exec.Bash(
                "dbus-send --type=method_call --dest=org.onboard.Onboard /org/onboard/Onboard/Keyboard org.onboard.Onboard.Keyboard.Hide"
            );
        };
    }
}
