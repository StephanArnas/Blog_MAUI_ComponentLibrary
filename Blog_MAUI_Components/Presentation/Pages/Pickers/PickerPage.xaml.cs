namespace Blog_MAUI_Components.Presentation.Pages.Pickers;

public partial class PickerPage
{
    public PickerPage(Pickers.PickerPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}