using System;
using GLib;
using Uno.UI.Runtime.Skia.Gtk;

namespace unoDemo.Skia.Gtk;

public class Program
{
    public static void Main(string[] args)
    {
        ExceptionManager.UnhandledException += delegate (UnhandledExceptionArgs expArgs)
        {
            Console.WriteLine("GLIB UNHANDLED EXCEPTION" + expArgs.ExceptionObject.ToString());
            expArgs.ExitApplication = true;
        };

        var host = new GtkHost(() => new AppHead());
        // FIXME: if your machine supports openGL remove this
        host.RenderSurfaceType = RenderSurfaceType.Software;
        
        host.Run();
    }
}
