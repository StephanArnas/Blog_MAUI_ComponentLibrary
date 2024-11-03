using System.Collections;
using System.Windows.Input;
using Blog_MAUI_Components.MAUI.Common.Extensions;
using Blog_MAUI_Components.MAUI.CustomControls.Popups;
using CommunityToolkit.Maui.Views;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels;

public partial class PickerPopupLabel
{
    private CollectionPopup? _collectionPopup;
    private readonly TapGestureRecognizer _tapGestureRecognizer;

    public PickerPopupLabel()
    {
        InitializeComponent();
        
        _tapGestureRecognizer = new TapGestureRecognizer();
        _tapGestureRecognizer.Tapped += OnTapped;

        GestureRecognizers.Add(_tapGestureRecognizer);
    }
    
    private void OnTapped(object? sender, EventArgs e)
    {
        _collectionPopup = new CollectionPopup
        {
            BindingContext = this,
            Title = !string.IsNullOrEmpty(Title) ? Title : Label,
            ItemsSource = ItemsSource,
            SelectedItem = SelectedItem,
            ItemDisplay = ItemDisplay,
        };

        _collectionPopup.SetBinding(CollectionPopup.SelectedItemProperty, "SelectedItem");
        _collectionPopup.SetBinding(CollectionPopup.ItemsSourceProperty, "ItemsSource");

        Shell.Current.ShowPopup(_collectionPopup);
    }
    
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        ActionIconSource ??= "chevron_bottom.png";
        ActionIconCommand ??= new Command(() => OnTapped(null, EventArgs.Empty));
    }
    
    public static readonly BindableProperty ItemsSourceProperty = 
        BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PickerPopupLabel), 
            defaultBindingMode: BindingMode.OneWay);

    public IList? ItemsSource
    {
        get => (IList?)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty = 
        BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(PickerPopupLabel), 
            propertyChanged: SelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

    public object? SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public static readonly BindableProperty TapCommandProperty = 
        BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(PickerPopupLabel), 
            defaultBindingMode: BindingMode.TwoWay);

    public ICommand? TapCommand
    {
        get => (ICommand?)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }

    public static readonly BindableProperty ItemDisplayProperty = 
        BindableProperty.Create(nameof(ItemDisplay), typeof(string), typeof(PickerPopupLabel), 
            defaultBindingMode: BindingMode.OneWay);

    public string ItemDisplay
    {
        get => (string)GetValue(ItemDisplayProperty);
        set => SetValue(ItemDisplayProperty, value);
    }

    public static readonly BindableProperty DefaultValueProperty = 
        BindableProperty.Create(nameof(DefaultValue), typeof(string), typeof(PickerPopupLabel), 
            propertyChanged: DefaultValueChanged, defaultBindingMode: BindingMode.OneWay);

    public string DefaultValue
    {
        get => (string)GetValue(DefaultValueProperty);
        set => SetValue(DefaultValueProperty, value);
    }

    public static readonly BindableProperty TitleProperty = 
        BindableProperty.Create(nameof(Title), typeof(string), typeof(PickerPopupLabel));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerPopupLabel)bindable).UpdateSelectedItemView();
    private static void DefaultValueChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerPopupLabel)bindable).UpdateDefaultValueView();

    private void UpdateSelectedItemView()
    {
        TapCommand?.Execute(SelectedItem);
        Element.Text = SelectedItem?.GetPropertyValue<string>(ItemDisplay) ?? string.Empty;
    }

    private void UpdateDefaultValueView()
    {
        Element.Text = DefaultValue;
    }
}