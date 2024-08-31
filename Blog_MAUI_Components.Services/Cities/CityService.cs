using Blog_MAUI_Components.Application.Cities;
using Blog_MAUI_Components.Application.Common.Interfaces.Services;

namespace Blog_MAUI_Components.Services.Cities;

public class CityService : ICityService
{
    private readonly List<CityVm> _cities =
    [
        new CityVm(1, 1, "Paris"),
        new CityVm(2, 1, "Lyon"),
        new CityVm(3, 1, "Marseille"),
        new CityVm(4, 1, "Toulouse"),
        new CityVm(5, 1, "Nice"),

        // United States
        new CityVm(6, 2, "New York"),
        new CityVm(7, 2, "Los Angeles"),
        new CityVm(8, 2, "Chicago"),
        new CityVm(9, 2, "Houston"),
        new CityVm(10, 2, "Phoenix"),

        // Japan
        new CityVm(11, 3, "Tokyo"),
        new CityVm(12, 3, "Osaka"),
        new CityVm(13, 3, "Kyoto"),
        new CityVm(14, 3, "Nagoya"),
        new CityVm(15, 3, "Fukuoka"),

        // United Kingdom
        new CityVm(16, 4, "London"),
        new CityVm(17, 4, "Manchester"),
        new CityVm(18, 4, "Birmingham"),
        new CityVm(19, 4, "Glasgow"),
        new CityVm(20, 4, "Liverpool"),

        // Australia
        new CityVm(21, 5, "Sydney"),
        new CityVm(22, 5, "Melbourne"),
        new CityVm(23, 5, "Brisbane"),
        new CityVm(24, 5, "Perth"),
        new CityVm(25, 5, "Adelaide")
    ];
    
    public async Task<IReadOnlyList<CityVm>> GetAllCitiesAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(2000, cancellationToken);
        
        return _cities.AsReadOnly();
    }

    public async Task<IReadOnlyList<CityVm>> GetCitiesAsync(int countryId, CancellationToken cancellationToken = default)
    {
        await Task.Delay(2000, cancellationToken);
        
        return _cities.Where(x => x.CountryId == countryId).ToList().AsReadOnly();
    }
}