using Microsoft.Extensions.Logging;
using Sharpnado.TaskLoaderView;
using StephanArnas.Controls.Mobile.Presentation.Common;

namespace StephanArnas.Controls.Mobile.Presentation.Pages.Buttons;

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
    
    private async Task DemoOneAsync()
    {
        _logger.LogInformation("DemoOne()");

        await Task.Delay(5000); 
    }
}