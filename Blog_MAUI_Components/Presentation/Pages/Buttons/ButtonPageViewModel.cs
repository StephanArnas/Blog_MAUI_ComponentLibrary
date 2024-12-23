using Blog_MAUI_Components.Presentation.Common;
using Microsoft.Extensions.Logging;
using Sharpnado.TaskLoaderView;

namespace Blog_MAUI_Components.Presentation.Pages.Buttons;

public class ButtonPageViewModel : ViewModelBase
{
    private readonly ILogger<ButtonPageViewModel> _logger;
    
    public TaskLoaderCommand DemoOneCommand { get; }

    public ButtonPageViewModel(
        ILogger<ButtonPageViewModel> logger)    
    {
        _logger = logger;

        DemoOneCommand = new TaskLoaderCommand(DemoOneAsync);

        _logger.LogInformation("Building ButtonPageViewModel");
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
    
    private async Task DemoOneAsync()
    {
        _logger.LogInformation("DemoOne()");

        await Task.Delay(5000); 
    }
}