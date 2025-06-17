namespace Maui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        CheckConnectionAndLoad();
    }

    private void CheckConnectionAndLoad()
    {
        var current = Connectivity.NetworkAccess;

        if (current == NetworkAccess.Internet)
        {
            MyWebView.IsVisible = true;
            OfflineView.IsVisible = false;
            MyWebView.Source = "https://app.mbogdan.pl";
        }
        else
        {
            MyWebView.IsVisible = false;
            OfflineView.IsVisible = true;
        }

        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    private void Connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        CheckConnectionAndLoad();
    }
}