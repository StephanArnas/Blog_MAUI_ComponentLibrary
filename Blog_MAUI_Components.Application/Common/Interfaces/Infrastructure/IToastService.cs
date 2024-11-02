using CommunityToolkit.Maui.Core;

namespace Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;

public interface IToastService
{
    Task ShowAsync(string message, ToastDuration duration = ToastDuration.Short, double textSize = 14.0);
}