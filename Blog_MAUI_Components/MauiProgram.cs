using Blog_MAUI_Components.MAUI;
using Blog_MAUI_Components.Presentation.Common;
using Blog_MAUI_Components.Presentation.Pages.Entry;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace Blog_MAUI_Components;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .AddBlogComponents()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if __ANDROID__
            // Remove the underline from the EditText.
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        Routing.RegisterRoute(RouteConstants.EntryPage, typeof(EntryPage));

        return builder.Build();
    }
}