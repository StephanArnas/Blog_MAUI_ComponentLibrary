using System.Collections;
using System.Windows.Input;
using Blog_MAUI_Components.MAUI.CustomControls.Labels.Base;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels;

public partial class PickerLabel
{
    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PickerLabel), propertyChanged: OnItemsSourceChanged);
    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(PickerLabel), defaultValue: null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);
    public static readonly BindableProperty ItemDisplayProperty = BindableProperty.Create(nameof(ItemDisplay), typeof(string), typeof(PickerLabel), propertyChanged: OnItemDisplayBindingChanged, defaultBindingMode: BindingMode.OneWay);
    public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(PickerLabel));

    public IList ItemsSource
    {
        get => (IList)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }
    
    public string ItemDisplay
    {
        get => (string)GetValue(ItemDisplayProperty);
        set => SetValue(ItemDisplayProperty, value);
    }
    
    public ICommand? TapCommand
    {
        get => (ICommand?)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }
    
    public PickerLabel()
    {
        InitializeComponent();
        
        Element.SetVisualElementBinding();
        Element.SetBinding(Picker.ItemsSourceProperty, nameof(ItemsSource));
        Element.SetBinding(Picker.SelectedItemProperty, nameof(SelectedItem));
        Element.BindingContext = this;
    }
    
    private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerLabel)bindable).OnItemsSourceChanged();
    private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerLabel)bindable).OnSelectedItemChanged();
    private static void OnItemDisplayBindingChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerLabel)bindable).OnItemDisplayBindingChanged();

    private void OnPickerTapped(object? sender, EventArgs e)
    {
        if (Element.ItemsSource == null || !Element.ItemsSource.Cast<object>().Any())
        {
            // The Picker has no items, so we don't want to show an empty Picker dialog.
            return;
        }

        Element.Unfocus();
        Element.Focus();
    }
    
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
        Element.ItemDisplayBinding = new Binding(ItemDisplay);
    }
}