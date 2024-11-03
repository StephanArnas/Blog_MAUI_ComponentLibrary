using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;

namespace Blog_MAUI_Components.Infrastructure.Displays;

public class DisplayService : IDisplayService
{
    public Task ShowPopupAsync(string title, string message, string accept = "OK")
    {
        return Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert(title, message, accept);
    }
}