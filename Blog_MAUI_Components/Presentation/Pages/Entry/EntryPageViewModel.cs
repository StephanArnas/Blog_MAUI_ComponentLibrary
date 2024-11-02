using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using Blog_MAUI_Components.Presentation.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Blog_MAUI_Components.Presentation.Pages.Entry;

public partial class EntryPageViewModel : ViewModelBase
{
    private readonly ILogger<EntryPageViewModel> _logger;
    private readonly IToastService _toastService;    
    [ObservableProperty]
    private string? _fullName;
    
    [ObservableProperty]
    private string? _email;

    [ObservableProperty]
    private ValidationResult? _validationResult;
    
    public EntryPageViewModel(
        ILogger<EntryPageViewModel> logger,
        IToastService toastService)    
    {
        _logger = logger;
        _toastService = toastService;

        _logger.LogInformation("Building EntryPageViewModel");
    }
    
    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _logger.LogInformation("ApplyQueryAttributes( query: {Query} )", query);
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
    private async Task Save()
    {
        _logger.LogInformation("Save()");
        
        var validator = new EntryPageViewModelValidator();
        ValidationResult = await validator.ValidateAsync(this);
        if (!ValidationResult.IsValid)
        {
            return;
        }
        
        await _toastService.ShowAsync("Saved !!");
    }
}