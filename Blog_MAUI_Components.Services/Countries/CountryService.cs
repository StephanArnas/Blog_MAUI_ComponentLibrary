using Blog_MAUI_Components.Application.Common.Interfaces.Services;
using Blog_MAUI_Components.Application.Countries;

namespace Blog_MAUI_Components.Services.Countries;

public class CountryService : ICountryService
{
    public async Task<IReadOnlyList<CountryVm>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
    {
        var countries = new List<CountryVm>
        {
            new (1, "France"),
            new (2, "United States"),
            new (3, "Japan"),
            new (4, "United Kingdom"),
            new (5, "Australia")
        };

        await Task.Delay(2000, cancellationToken);
        
        return countries.AsReadOnly();
    }
}