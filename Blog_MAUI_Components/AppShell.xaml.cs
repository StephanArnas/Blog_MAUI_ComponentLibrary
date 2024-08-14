using Blog_MAUI_Components.MAUI.Common;

namespace Blog_MAUI_Components;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        SetBackgroundColor(this, ResourceHelper.GetResource<Color>("Primary"));
        SetTitleColor(this, ResourceHelper.GetResource<Color>("White"));
    }
}