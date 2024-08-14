using Blog_MAUI_Components.MAUI.Common;

namespace Blog_MAUI_Components.MAUI.CustomControlsBasic.Labels.Base;

public partial class LabelBase
{
    public LabelBase()
    {
        InitializeComponent();
    }
    
    public static readonly BindableProperty ViewProperty = BindableProperty.Create("View",
        typeof(View), typeof(LabelBase), defaultValue: null, BindingMode.OneWay, ViewHelper.ValidateCustomView, ElementChanged);

    public View View
    {
        get => (View)GetValue(ViewProperty);
        set => SetValue(ViewProperty, value);
    }
    
    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create("IsRequired",
        typeof(bool), typeof(LabelBase), defaultValue: false, propertyChanged: IsRequiredChanged);

    public bool IsRequired
    {
        get => (bool)GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }
    
    public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label",
        typeof(string), typeof(LabelBase), propertyChanged: LabelChanged);

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    private static void ElementChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelBase)bindable).UpdateElementView();
    private static void IsRequiredChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelBase)bindable).UpdateIsRequiredView();
    private static void LabelChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelBase)bindable).UpdateLabelView();
    
    private void UpdateElementView()
    {
        BorderLabel.Content = View;
        UpdateIsRequiredView();
    }

    private void UpdateIsRequiredView()
    {
        RequiredLabel.IsVisible = IsRequired;
    }

    private void UpdateLabelView()
    {
        LabelLabel.Text = Label;
        LabelLabel.IsVisible = !string.IsNullOrEmpty(Label);
    }
}
