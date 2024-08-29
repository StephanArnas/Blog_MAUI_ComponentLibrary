using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using Microsoft.Maui.Controls;

namespace Blog_MAUI_Components.Infrastructure.Navigation;

// Read more about navigation : https://learn.microsoft.com/fr-fr/dotnet/architecture/maui/navigation

public class NavigationService : INavigationService
{
    public Task InitializeAsync()
    {
        // TODO: Not implemented yet, need login and main page.
        return Task.CompletedTask;
    }
    
    public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
    {
        return routeParameters != null
            ? Shell.Current.GoToAsync(route, routeParameters)
            : Shell.Current.GoToAsync(route);
    }
    
    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}