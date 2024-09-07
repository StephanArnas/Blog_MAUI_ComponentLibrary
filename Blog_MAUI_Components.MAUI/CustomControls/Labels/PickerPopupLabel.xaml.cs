using System.Collections;
using System.Windows.Input;
using Blog_MAUI_Components.MAUI.Common.Extensions;
using Blog_MAUI_Components.MAUI.CustomControls.Popups;
using CommunityToolkit.Maui.Views;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels;

public partial class PickerPopupLabel
{
    private CollectionPopup? _collectionPopup;
    private object? _previousSelectedItem;

    public PickerPopupLabel()
    {
        InitializeComponent();
        
        var tapped = new TapGestureRecognizer();
        tapped.Tapped += (_, _) =>
        {
            _collectionPopup = new CollectionPopup
            {
                Title = Label,
                BindingContext = this,
            };

            if (!string.IsNullOrEmpty(Title))
            {
                _collectionPopup.Title = Title;
                _collectionPopup.SetBinding(CollectionPopup.TitleProperty, "Title");
            }
            else
            {
                _collectionPopup.Title = Label;
                _collectionPopup.SetBinding(CollectionPopup.TitleProperty, "Label");
            }

            _collectionPopup.SetBinding(CollectionPopup.ItemsSourceProperty, "ItemsSource");
            _collectionPopup.SetBinding(CollectionPopup.SelectedItemProperty, "SelectedItem");
            _collectionPopup.ItemDisplay = ItemDisplay;

            InitUpdateViews();

            Shell.Current.ShowPopup(_collectionPopup);
        };
        GestureRecognizers.Add(tapped);
    }
    
    public static readonly BindableProperty ItemsSourceProperty = 
        BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PickerPopupLabel), 
            propertyChanged: ItemsSourceChanged, defaultBindingMode: BindingMode.OneWay);

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
            propertyChanged: ItemDisplayChanged, defaultBindingMode: BindingMode.OneWay);

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

    private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerPopupLabel)bindable).UpdateItemsSourceView();
    private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerPopupLabel)bindable).UpdateSelectedItemView();
    private static void ItemDisplayChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerPopupLabel)bindable).UpdateItemDisplayBindingView();
    private static void DefaultValueChanged(BindableObject bindable, object oldValue, object newValue) => ((PickerPopupLabel)bindable).UpdateDefaultValueView();

    private void InitUpdateViews()
    {
        UpdateItemsSourceView();
        UpdateSelectedItemView();
    }

    private void UpdateItemsSourceView()
    {
        if (_collectionPopup != null)
        {
            _collectionPopup.ItemsSource = ItemsSource;
        }
    }

    private void UpdateSelectedItemView()
    {
        if (_previousSelectedItem == null)
        {
            if (_previousSelectedItem != SelectedItem)
            {
                TapCommand?.Execute(SelectedItem);
            }
            _previousSelectedItem = SelectedItem;
        }
        else if (_previousSelectedItem != SelectedItem)
        {
            _previousSelectedItem = SelectedItem;
            TapCommand?.Execute(SelectedItem);
        }

        if (_collectionPopup != null)
        {
            _collectionPopup.SelectedItem = SelectedItem;
        }

        Element.BindingContext = SelectedItem;
        Element.Text = SelectedItem?.GetPropertyValue<string>(ItemDisplay) ?? string.Empty;

        OnPropertyChanged(ItemDisplay);
    }

    private void UpdateItemDisplayBindingView()
    {
        if (_collectionPopup != null)
        {
            _collectionPopup.ItemDisplay = ItemDisplay;
        }

        Element.SetBinding(Microsoft.Maui.Controls.Label.TextProperty, ItemDisplay);
    }

    private void UpdateDefaultValueView() => Element.Text = DefaultValue;
}