using Blog_MAUI_Components.MAUI.CustomControls.ProgressBars;
using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ProgressBar = Microsoft.Maui.Controls.ProgressBar;

namespace Blog_MAUI_Components.MAUI;

public static class DependencyInjection
{
    public static MauiAppBuilder AddBlogComponents(this MauiAppBuilder builder)
    {
        builder.UseSkiaSharp();
        
        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<ProgressBar, ProgressBarHandler>();
        });
        
        return builder;
    }
}