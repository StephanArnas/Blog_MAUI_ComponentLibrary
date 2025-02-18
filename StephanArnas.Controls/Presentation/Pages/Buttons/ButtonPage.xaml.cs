namespace StephanArnas.Controls.Presentation.Pages.Buttons;

public partial class ButtonPage
{
    public ButtonPage(ButtonPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}