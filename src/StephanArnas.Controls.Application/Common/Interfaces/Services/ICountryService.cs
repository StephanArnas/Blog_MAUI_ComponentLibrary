using StephanArnas.Controls.Application.Countries;

namespace StephanArnas.Controls.Application.Common.Interfaces.Services;

public interface ICountryService
{
    Task<IReadOnlyList<CountryVm>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
}