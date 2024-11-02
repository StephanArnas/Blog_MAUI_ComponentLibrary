using Blog_MAUI_Components.Application.Countries;

namespace Blog_MAUI_Components.Application.Common.Interfaces.Services;

public interface ICountryService
{
    Task<IReadOnlyList<CountryVm>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
}