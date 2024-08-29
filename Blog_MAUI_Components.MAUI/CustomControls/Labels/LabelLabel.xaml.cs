using System.Windows.Input;
using Blog_MAUI_Components.MAUI.CustomControls.Labels.Base;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels;

public partial class LabelLabel
{
    public LabelLabel()
    {
        InitializeComponent();
        
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (_, _) =>
        {
            TapCommand?.Execute(null);
        };
        GestureRecognizers.Add(tapGestureRecognizer);

        
        Element.SetVisualElementBinding();
        Element.SetBinding(Microsoft.Maui.Controls.Label.TextProperty, "Text", BindingMode.OneWay);
        Element.BindingContext = this;
    }
    
    public static readonly BindableProperty TextProperty = BindableProperty.Create("Text",
        typeof(string), typeof(LabelLabel), propertyChanged: TextChanged, defaultBindingMode: BindingMode.OneWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public static readonly BindableProperty TapCommandProperty = BindableProperty.Create("TapCommand",
        typeof(ICommand), typeof(LabelLabel));

    public ICommand? TapCommand
    {
        get => (ICommand?)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }

    private static void TextChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelLabel)bindable).UpdateTextView();

    private void UpdateTextView()
    {
        Element.Text = Text;
        InvalidateSurface(); 
    }
}