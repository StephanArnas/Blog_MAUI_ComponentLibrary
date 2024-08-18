using Blog_MAUI_Components.Presentation.Common;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Sharpnado.TaskLoaderView;

namespace Blog_MAUI_Components.Presentation.Pages.Entry;

public partial class EntryPageViewModel : ViewModelBase
{
    private readonly ILogger<EntryPageViewModel> _logger;
    
    [ObservableProperty]
    private string? _email;

    [ObservableProperty]
    private ValidationResult? _validationResult;
    
    public TaskLoaderCommand SaveCommand { get; }
    
    public EntryPageViewModel(
        ILogger<EntryPageViewModel> logger)
    {
        _logger = logger;

        SaveCommand = new TaskLoaderCommand(SaveAsync);

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
    
    private async Task SaveAsync()
    {
        _logger.LogInformation("SaveAsync()");
        
        var validator = new EntryPageViewModelValidator();
        ValidationResult = await validator.ValidateAsync(this);
        if (!ValidationResult.IsValid)
        {
            return;
        }
        
        await Toast.Make("Saved !!").Show();
    }
}