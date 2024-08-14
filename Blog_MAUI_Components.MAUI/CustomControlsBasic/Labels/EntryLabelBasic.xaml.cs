using System.Windows.Input;
using Blog_MAUI_Components.MAUI.CustomControls.Labels.Base;

namespace Blog_MAUI_Components.MAUI.CustomControlsBasic.Labels;

public partial class EntryLabelBasic
{
    public EntryLabelBasic()
    {
        InitializeComponent();
        
        Element.SetVisualElementBinding();
        Element.SetBinding(Entry.TextProperty, "Text", BindingMode.TwoWay);
        Element.BindingContext = this;
    }
    
    public static readonly BindableProperty TextProperty = BindableProperty.Create("Text",
        typeof(string), typeof(EntryLabelBasic), propertyChanged: TextChanged, defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create("Placeholder",
        typeof(string), typeof(EntryLabelBasic), propertyChanged: PlaceholderChanged);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard",
        typeof(Keyboard), typeof(EntryLabelBasic), Keyboard.Plain, propertyChanged: KeyboardChanged);

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create("ReturnType",
        typeof(ReturnType), typeof(EntryLabelBasic), ReturnType.Done, propertyChanged: ReturnTypeChanged);

    public ReturnType ReturnType
    {
        get => (ReturnType)GetValue(ReturnTypeProperty);
        set => SetValue(ReturnTypeProperty, value);
    }

    public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create("ReturnCommand",
        typeof(ICommand), typeof(EntryLabelBasic), defaultValue: null, propertyChanged: ReturnCommandChanged);

    public ICommand ReturnCommand
    {
        get => (ICommand)GetValue(ReturnCommandProperty);
        set => SetValue(ReturnCommandProperty, value);
    }

    public static readonly BindableProperty TextTransformProperty = BindableProperty.Create("TextTransform",
        typeof(TextTransform), typeof(EntryLabelBasic), defaultValue: TextTransform.Default, propertyChanged: TextTransformChanged);
    
    public TextTransform TextTransform
    {
        get => (TextTransform)GetValue(TextTransformProperty);
        set => SetValue(TextTransformProperty, value);
    }
    
    private static void TextChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabelBasic)bindable).UpdateTextView();
    private static void PlaceholderChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabelBasic)bindable).UpdatePlaceholderView();
    private static void KeyboardChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabelBasic)bindable).UpdateKeyboardView();
    private static void ReturnTypeChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabelBasic)bindable).UpdateReturnTypeView();
    private static void ReturnCommandChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabelBasic)bindable).UpdateReturnCommandView();
    private static void TextTransformChanged(BindableObject bindable, object oldValue, object newValue) => ((EntryLabelBasic)bindable).UpdateTextTransformView();
    
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