using Blog_MAUI_Components.Presentation.Common;

namespace Blog_MAUI_Components.Presentation.Pages;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void GoToEntryPage(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(RouteConstants.EntryPage);
    }
    
    private async void GoToLabelPage(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(RouteConstants.LabelPage);
    }
}