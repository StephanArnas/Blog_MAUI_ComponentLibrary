namespace StephanArnas.Controls.Presentation.Pages.Pickers;

public partial class PickerPopupPage
{
    public PickerPopupPage(PickerPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}