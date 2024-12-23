﻿using Blog_MAUI_Components.Infrastructure;
using Blog_MAUI_Components.MAUI;
using Blog_MAUI_Components.Presentation.Common;
using Blog_MAUI_Components.Presentation.Pages;
using Blog_MAUI_Components.Presentation.Pages.Buttons;
using Blog_MAUI_Components.Presentation.Pages.Entry;
using Blog_MAUI_Components.Presentation.Pages.Pickers;
using Blog_MAUI_Components.Services;
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

        builder.Services.AddInfrastructure();
        builder.Services.AddServices();

        ApplyStyleCustomization();
        
        // Register your pages.
        builder.Services.AddTransient<MainPage, MainPageViewModel>();
        builder.Services.AddTransientWithShellRoute<ButtonPage, ButtonPageViewModel>(RouteConstants.ButtonPage);
        builder.Services.AddTransientWithShellRoute<EntryPage, EntryPageViewModel>(RouteConstants.EntryPage);
        builder.Services.AddTransientWithShellRoute<PickerPage, PickerPageViewModel>(RouteConstants.PickerPage);
        builder.Services.AddTransientWithShellRoute<PickerPopupPage, PickerPageViewModel>(RouteConstants.PickerPopupPage);
        
        return builder.Build();
    }
    
    private static void ApplyStyleCustomization()
    {
        EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
        {
#if ANDROID
        // Remove the underline from the EditText
        handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
        });
        
        EntryHandler.Mapper.AppendToMapping("SetUpEntry", (handler, _) =>
        {
#if ANDROID

#elif IOS || MACCATALYST
        // Remove outline from the UITextField
        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS

#endif
        });
        
        PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, _) =>
        {
#if ANDROID
        // Remove the underline from the Spinner (Picker)
        handler.PlatformView.Background = null;
#endif
        });

        PickerHandler.Mapper.AppendToMapping("SetUpPicker", (handler, _) =>
        {
#if ANDROID
        // Set the background to transparent
        handler.PlatformView.Background = null;
#elif IOS || MACCATALYST
        // Remove border for the UITextField (Picker)
        if (handler.PlatformView is UIKit.UITextField textField)
        {
            textField.BorderStyle = UIKit.UITextBorderStyle.None;
        }
#elif WINDOWS

#endif
        });
    }
}