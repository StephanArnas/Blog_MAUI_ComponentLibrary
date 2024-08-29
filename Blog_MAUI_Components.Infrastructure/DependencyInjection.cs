using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using Blog_MAUI_Components.Infrastructure.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace Blog_MAUI_Components.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();

        return services;
    }
}
