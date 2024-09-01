using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;

namespace Blog_MAUI_Components.Infrastructure.Navigation;

// Read more about navigation : https://learn.microsoft.com/fr-fr/dotnet/architecture/maui/navigation

public class NavigationService : INavigationService
{
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