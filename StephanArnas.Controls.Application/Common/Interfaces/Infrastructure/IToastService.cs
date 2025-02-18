using CommunityToolkit.Maui.Core;

namespace StephanArnas.Controls.Application.Common.Interfaces.Infrastructure;

public interface IToastService
{
    Task ShowAsync(string message, ToastDuration duration = ToastDuration.Short, double textSize = 14.0);
}