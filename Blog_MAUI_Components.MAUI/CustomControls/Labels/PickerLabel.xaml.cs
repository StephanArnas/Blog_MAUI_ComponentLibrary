using System.Collections;
using System.Windows.Input;
using Blog_MAUI_Components.MAUI.CustomControls.Labels.Base;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels;

public partial class PickerLabel
{
    public PickerLabel()
    {
        InitializeComponent();
        
        Element.SetVisualElementBinding();
        Element.SetBinding(Picker.ItemsSourceProperty, nameof(ItemsSource));
        Element.SetBinding(Picker.SelectedItemProperty, nameof(SelectedItem));
        Element.BindingContext = this;
    }
    
    private void OnPickerTapped(object sender, EventArgs e)
    {
        if (Element.ItemsSource == null || !Element.ItemsSource.Cast<object>().Any())
        {
            // The Picker has no items, so we don't want to show an empty Picker dialog.
            return;
        }

        Element.Unfocus();
        Element.Focus();
    }
    
    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PickerLabel), propertyChanged: OnItemsSourceChanged);

    public IList ItemsSource
    {
        get => (IList)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(PickerLabel), null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

    public object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }
    
    public static readonly BindableProperty ItemDisplayBindingProperty = 
        BindableProperty.Create(nameof(ItemDisplayBinding), typeof(string), typeof(PickerLabel), propertyChanged: OnItemDisplayBindingChanged, defaultBindingMode: BindingMode.OneWay);

    public string ItemDisplayBinding
    {
        get => (string)GetValue(ItemDisplayBindingProperty);
        set => SetValue(ItemDisplayBindingProperty, value);
    }
    
    public static readonly BindableProperty TapCommandProperty = 
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(PickerLabel));

    public ICommand? TapCommand
    {
        get => (ICommand?)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }
    
    private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerLabel)bindable).OnItemsSourceChanged();
    private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerLabel)bindable).OnSelectedItemChanged();
    private static void OnItemDisplayBindingChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerLabel)bindable).OnItemDisplayBindingChanged();

    private void OnItemsSourceChanged()
    {
        Element.ItemsSource = ItemsSource;
    }

    private void OnSelectedItemChanged()
    {
        Element.SelectedItem = SelectedItem;
        TapCommand?.Execute(null);
    }

    private void OnItemDisplayBindingChanged()
    {
        Element.ItemDisplayBinding = new Binding(ItemDisplayBinding);
    }
}