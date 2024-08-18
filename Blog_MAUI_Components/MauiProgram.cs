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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        ApplyStyleCustomization();
        
        // Register your pages.
        builder.Services.AddTransientWithShellRoute<EntryPage, EntryPageViewModel>(RouteConstants.EntryPage);

        return builder.Build();
    }
    
    private static void ApplyStyleCustomization()
    {
        EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if __ANDROID__
            // Remove the underline from the EditText
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
        });
        
        EntryHandler.Mapper.AppendToMapping("SetUpEntry", (handler, view) =>
        {
#if ANDROID

#elif IOS || MACCATALYST
            // Remove outline from the UITextField
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
      
#endif
        });
    }
}