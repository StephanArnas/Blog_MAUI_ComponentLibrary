namespace Blog_MAUI_Components.Presentation.Pages.Pickers;

public partial class PickerPopupPage
{
    public PickerPopupPage(PickerPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}