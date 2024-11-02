using Blog_MAUI_Components.Application.Cities;

namespace Blog_MAUI_Components.Application.Common.Interfaces.Services;

public interface ICityService
{
    Task<IReadOnlyList<CityVm>> GetAllCitiesAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CityVm>> GetCitiesAsync(int countryId, CancellationToken cancellationToken = default);
}