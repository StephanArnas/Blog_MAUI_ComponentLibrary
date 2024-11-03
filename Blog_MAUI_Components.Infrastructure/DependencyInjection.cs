using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using Blog_MAUI_Components.Infrastructure.Displays;
using Blog_MAUI_Components.Infrastructure.Navigation;
using Blog_MAUI_Components.Infrastructure.Toasts;
using Microsoft.Extensions.DependencyInjection;

namespace Blog_MAUI_Components.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IToastService, ToastService>();
        services.AddSingleton<IDisplayService, DisplayService>();
        
        return services;
    }
}
