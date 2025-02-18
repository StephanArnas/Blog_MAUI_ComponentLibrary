using StephanArnas.Controls.Application.Cities;

namespace StephanArnas.Controls.Application.Common.Interfaces.Services;

public interface ICityService
{
    Task<IReadOnlyList<CityVm>> GetAllCitiesAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CityVm>> GetCitiesAsync(int countryId, CancellationToken cancellationToken = default);
}