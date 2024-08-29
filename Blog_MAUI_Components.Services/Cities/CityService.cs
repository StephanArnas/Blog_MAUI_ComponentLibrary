using System.Collections.ObjectModel;
using Blog_MAUI_Components.Application.Cities;
using Blog_MAUI_Components.Application.Common.Interfaces.Services;

namespace Blog_MAUI_Components.Services.Cities;

public class CityService : ICityService
{
    public Task<IReadOnlyList<CityVm>> GetAllCitiesAsync()
    {
        var cities = new List<CityVm>
        {
            new (1, "Paris"),
            new (2, "New York"),
            new (3, "Tokyo"),
            new (4, "London"),
            new (5, "Sydney")
        };

        return Task.FromResult<IReadOnlyList<CityVm>>(cities.AsReadOnly());
    }
}