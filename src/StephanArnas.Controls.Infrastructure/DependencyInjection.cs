using StephanArnas.Controls.Application.Common.Interfaces.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using StephanArnas.Controls.Infrastructure.Displays;
using StephanArnas.Controls.Infrastructure.Navigation;
using StephanArnas.Controls.Infrastructure.Toasts;

namespace StephanArnas.Controls.Infrastructure;

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
