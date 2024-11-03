namespace Blog_MAUI_Components.Application.Common.Interfaces.Infrastructure;

public interface IDisplayService
{
    Task ShowPopupAsync(string title, string message, string accept = "OK");
}