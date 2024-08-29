using System.Collections.ObjectModel;
using Blog_MAUI_Components.Application.Cities;

namespace Blog_MAUI_Components.Application.Common.Interfaces.Services;

public interface ICityService
{
    Task<IReadOnlyList<CityVm>> GetAllCitiesAsync();
}