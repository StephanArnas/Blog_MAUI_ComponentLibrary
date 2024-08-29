using System.Collections.ObjectModel;
using Blog_MAUI_Components.Application.Cities;
using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using Blog_MAUI_Components.Application.Common.Interfaces.Services;
using Blog_MAUI_Components.Presentation.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace Blog_MAUI_Components.Presentation.Pages.Search;

public partial class CitySearchPageViewModel : ViewModelBase
{
    private readonly ILogger<CitySearchPageViewModel> _logger;
    private readonly ICityService _cityService;
    private readonly INavigationService _navigationService;
    private string? _expectedResultName; 
    
    public const string ExpectedResultNameParameter = "ExpectedResultName";
    public const string DefaultResultParameter = "DefaultResult";
    
    [ObservableProperty]
    private ObservableCollection<CityVm> _cities;
    
    [ObservableProperty]
    private CityVm? _selectedCity;
    
    public CitySearchPageViewModel(
        ILogger<CitySearchPageViewModel> logger,
        ICityService cityService,
        INavigationService navigationService)
    {
        _logger = logger;
        _cityService = cityService;
        _navigationService = navigationService;
        
        _cities = new ObservableCollection<CityVm>();

        _logger.LogInformation("Building CitySearchPageViewModel");
    }
    
    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _logger.LogInformation("ApplyQueryAttributes( query: {Query} )", query);
        
        if (query.TryGetValue(ExpectedResultNameParameter, out var expectedResultName))
        {
            _expectedResultName = (string)expectedResultName;
        }
        
        base.ApplyQueryAttributes(query);
    }

    public override async void OnAppearing()
    {
        _logger.LogInformation("OnAppearing()");
        
        await LoadCitiesAsync();

        base.OnAppearing();
    }

    public override void OnDisappearing()
    {
        _logger.LogInformation("OnDisappearing()");
        
        base.OnDisappearing();
    }
    
    private async Task LoadCitiesAsync()
    {
        _logger.LogInformation("LoadCitiesAsync()");

        Cities.Clear();

        var cities = await _cityService.GetAllCitiesAsync();

        foreach (var city in cities)
        {
            Cities.Add(city);
        }
    }

    [RelayCommand]
    private Task CitySelected()
    {
        _logger.LogInformation("CitySelected()");

        if (SelectedCity is null)
        {
            return Task.CompletedTask;
        }

        var parameters = new Dictionary<string, object> { { _expectedResultName ?? DefaultResultParameter, SelectedCity } };
        return _navigationService.NavigateToAsync("..", parameters);
    }
}