using StephanArnas.Controls.Application.Common.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using StephanArnas.Controls.Services.Cities;
using StephanArnas.Controls.Services.Countries;

namespace StephanArnas.Controls.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICountryService, CountryService>();
        services.AddSingleton<ICityService, CityService>();

        return services;
    }
}
