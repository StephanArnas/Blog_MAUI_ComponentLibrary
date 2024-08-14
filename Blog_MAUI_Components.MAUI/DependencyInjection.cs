using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Blog_MAUI_Components.MAUI;

public static class DependencyInjection
{
    public static MauiAppBuilder AddBlogComponents(this MauiAppBuilder builder)
    {
        builder.UseSkiaSharp();

        return builder;
    }
}