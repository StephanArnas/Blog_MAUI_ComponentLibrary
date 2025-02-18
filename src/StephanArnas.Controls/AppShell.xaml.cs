using StephanArnas.Controls.Maui.Common.Helpers;

namespace StephanArnas.Controls;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        SetBackgroundColor(this, ResourceHelper.GetResource<Color>("Primary"));
        SetTitleColor(this, ResourceHelper.GetResource<Color>("White"));
    }
}