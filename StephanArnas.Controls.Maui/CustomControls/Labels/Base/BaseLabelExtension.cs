namespace StephanArnas.Controls.Maui.CustomControls.Labels.Base;

public static class BaseLabelExtension
{
    public static void SetVisualElementBinding(this VisualElement visualElement)
    {
        visualElement.SetBinding(VisualElement.IsEnabledProperty, "IsEnabled", BindingMode.TwoWay);
        visualElement.SetBinding(VisualElement.IsVisibleProperty, "IsVisible", BindingMode.TwoWay);
    }
}