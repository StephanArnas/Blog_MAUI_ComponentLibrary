using System.Collections;
using Blog_MAUI_Components.MAUI.Common.Helpers;
using Blog_MAUI_Components.MAUI.MarkupExtensions;

namespace Blog_MAUI_Components.MAUI.CustomControls.Popups;

public partial class CollectionPopup
{
    public CollectionPopup()
    {
        InitializeComponent();
        
        var tapped = new TapGestureRecognizer();
        tapped.Tapped += (_, _) => Close();
        CloseImage.GestureRecognizers.Add(tapped); 
    }
    
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title",
        typeof(string), typeof(CollectionPopup), propertyChanged: TitleChanged, defaultBindingMode: BindingMode.OneWayToSource);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource",
        typeof(IList), typeof(CollectionPopup));

    public IList? ItemsSource
    {
        get => (IList?)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem",
        typeof(object), typeof(CollectionPopup), defaultBindingMode: BindingMode.TwoWay);

    public object? SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public static readonly BindableProperty ItemDisplayProperty = BindableProperty.Create("ItemDisplay",
        typeof(string), typeof(CollectionPopup), defaultBindingMode: BindingMode.OneWayToSource);

    public string? ItemDisplay
    {
        get => (string?)GetValue(ItemDisplayProperty);
        set
        {
            SetValue(ItemDisplayProperty, value);
            InitCollectionViewItems();
        }
    }

    private static void TitleChanged(BindableObject bindable, object oldValue, object newValue) => ((CollectionPopup)bindable).UpdateTitleView();

    private void UpdateTitleView() => TitleLabel.Text = Title;

    private void InitCollectionViewItems()
    {
        PickerCollectionView.ItemTemplate = new DataTemplate(() =>
        {
            var contentView = new ContentView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Padding = new Thickness(16, 14),
                WidthRequest = GutterSystem.WidthScreen
            };

            // Put in comment the Triggers which was responsible for changing the background color for the selected item. 
            // It's not working properly in MAUI, I created a bug issue: https://github.com/dotnet/maui/issues/24655
            /*contentView.Triggers.Add(new DataTrigger(typeof(ContentView))
            {
                Binding = new Binding("."),
                Value = SelectedItem,
                Setters =
                {
                    new Setter
                    {
                        Property = VisualElement.BackgroundColorProperty,
                        Value = ResourceHelper.GetThemeColor("PrimaryDark", "Primary")
                    }
                }
            });*/
            
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, _) =>
            {
                SelectedItem = ((ContentView)s!).BindingContext;
                Close();
            };
            contentView.GestureRecognizers.Add(tapGestureRecognizer);

            var label = new Label
            {
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Fill,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            label.SetBinding(Label.TextProperty, new Binding(ItemDisplay));
            
            contentView.Content = label;

            return contentView;
        });
        
        PickerCollectionView.MaximumHeightRequest = GutterSystem.HeightScreen / 1.3;
    }
}