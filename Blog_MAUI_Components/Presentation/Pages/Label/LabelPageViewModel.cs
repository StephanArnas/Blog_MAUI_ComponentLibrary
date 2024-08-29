using Blog_MAUI_Components.Application.Cities;
using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using Blog_MAUI_Components.Presentation.Common;
using Blog_MAUI_Components.Presentation.Pages.Entry;
using Blog_MAUI_Components.Presentation.Pages.Search;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace Blog_MAUI_Components.Presentation.Pages.Label;

public partial class LabelPageViewModel : ViewModelBase
{
    private readonly ILogger<LabelPageViewModel> _logger;
    private readonly INavigationService _navigationService;
    
    [ObservableProperty]
    private CityVm? _cityOfBirth;
    
    [ObservableProperty]
    private CityVm? _cityOfResidence;
    
    [ObservableProperty]
    private bool _isLoading;

    public LabelPageViewModel(
        ILogger<LabelPageViewModel> logger,
        INavigationService navigationService)
    {
        _logger = logger;
        _navigationService = navigationService;

        _logger.LogInformation("Building LabelPageViewModel");
    }
    
    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _logger.LogInformation("ApplyQueryAttributes( query: {Query} )", query);
        
        if (query.TryGetValue(nameof(CityOfBirth), out var cityOfBirth))
        {
            CityOfBirth = (CityVm)cityOfBirth;
        }
        
        if (query.TryGetValue(nameof(CityOfResidence), out var cityOfResidence))
        {
            CityOfResidence = (CityVm)cityOfResidence;
        }
        
        base.ApplyQueryAttributes(query);
    }

    public override void OnAppearing()
    {
        _logger.LogInformation("OnAppearing()");

        base.OnAppearing();
    }

    public override void OnDisappearing()
    {
        _logger.LogInformation("OnDisappearing()");
        
        base.OnDisappearing();
    }

    [RelayCommand]
    private Task GoToCityOfBirthSearch()
    {
        _logger.LogInformation("GoToCityOfBirthSearch()");

        var parameters = new Dictionary<string, object> { { CitySearchPageViewModel.ExpectedResultNameParameter, nameof(CityOfBirth) } };
        return _navigationService.NavigateToAsync(RouteConstants.CitySearchPage, parameters);
    }

    [RelayCommand]
    private Task GoToCityOfResidenceSearch()
    {
        _logger.LogInformation("GoToCityOfResidenceSearch()");

        var parameters = new Dictionary<string, object> { { CitySearchPageViewModel.ExpectedResultNameParameter, nameof(CityOfResidence) } };
        return _navigationService.NavigateToAsync(RouteConstants.CitySearchPage, parameters);
    }
    
    [RelayCommand]
    private async Task Save()
    {
        _logger.LogInformation("Save()");

        IsLoading = true;
        
        await Task.Delay(2000);
        
        IsLoading = false;
    }
}