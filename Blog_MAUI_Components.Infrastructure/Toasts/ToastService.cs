using Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Blog_MAUI_Components.Infrastructure.Toasts;

public class ToastService : IToastService
{
    public Task ShowAsync(string message, ToastDuration duration = ToastDuration.Short, double textSize = 14.0)
    {
        return Toast.Make(message, duration, textSize).Show();
    }
}