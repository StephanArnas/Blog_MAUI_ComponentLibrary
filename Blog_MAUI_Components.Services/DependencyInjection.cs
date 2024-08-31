using Blog_MAUI_Components.Application.Common.Interfaces.Services;
using Blog_MAUI_Components.Services.Cities;
using Blog_MAUI_Components.Services.Countries;
using Microsoft.Extensions.DependencyInjection;

namespace Blog_MAUI_Components.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICountryService, CountryService>();
        services.AddSingleton<ICityService, CityService>();

        return services;
    }
}
