namespace unoDemo;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
    }

    private void Tabview_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count > 0 && e.RemovedItems[0] is TabViewItem oldTab)
        {
            // kill it?
            (oldTab.Content as IDisposable)?.Dispose();
        }
    }
}
