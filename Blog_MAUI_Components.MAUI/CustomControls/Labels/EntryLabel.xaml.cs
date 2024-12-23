using System.Windows.Input;
using Blog_MAUI_Components.MAUI.CustomControls.Labels.Base;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels;

public partial class EntryLabel
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(EntryLabel), propertyChanged: TextChanged, defaultBindingMode: BindingMode.TwoWay);
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(EntryLabel), propertyChanged: PlaceholderChanged);
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(EntryLabel), defaultValue: Keyboard.Plain, propertyChanged: KeyboardChanged);
    public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(EntryLabel), defaultValue: ReturnType.Done, propertyChanged: ReturnTypeChanged);
    public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(EntryLabel), defaultValue: null, propertyChanged: ReturnCommandChanged);
    public static readonly BindableProperty TextTransformProperty = BindableProperty.Create(nameof(TextTransform), typeof(TextTransform), typeof(EntryLabel), defaultValue: TextTransform.Default, propertyChanged: TextTransformChanged);
    
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public ReturnType ReturnType
    {
        get => (ReturnType)GetValue(ReturnTypeProperty);
        set => SetValue(ReturnTypeProperty, value);
    }

    public ICommand ReturnCommand
    {
        get => (ICommand)GetValue(ReturnCommandProperty);
        set => SetValue(ReturnCommandProperty, value);
    }
    
    public TextTransform TextTransform
    {
        get => (TextTransform)GetValue(TextTransformProperty);
        set => SetValue(TextTransformProperty, value);
    }
    
    public EntryLabel()
    {
        InitializeComponent();
        
        Element.SetVisualElementBinding();
        Element.SetBinding(Entry.TextProperty, nameof(Text), BindingMode.TwoWay);
        Element.BindingContext = this;
    }
    
    private static void TextChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabel)bindable).UpdateTextView();
    private static void PlaceholderChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabel)bindable).UpdatePlaceholderView();
    private static void KeyboardChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabel)bindable).UpdateKeyboardView();
    private static void ReturnTypeChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabel)bindable).UpdateReturnTypeView();
    private static void ReturnCommandChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabel)bindable).UpdateReturnCommandView();
    private static void TextTransformChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabel)bindable).UpdateTextTransformView();
    
    private void UpdateTextView()
    {
        if (Keyboard == Keyboard.Numeric)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Element.Text = Text;
                return;
            }

            Element.Text = int.TryParse(Text, out var number) 
                ? number.ToString() 
                : Text[..^1];
        }
        else
        {
            Element.Text = Text;
        }
    }

    private void UpdatePlaceholderView() => Element.Placeholder = Placeholder;
    private void UpdateKeyboardView() => Element.Keyboard = Keyboard;
    private void UpdateReturnTypeView() => Element.ReturnType = ReturnType;
    private void UpdateReturnCommandView() => Element.ReturnCommand = ReturnCommand;
    private void UpdateTextTransformView() => Element.TextTransform = TextTransform;
}