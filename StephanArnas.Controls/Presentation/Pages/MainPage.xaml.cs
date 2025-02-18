namespace StephanArnas.Controls.Presentation.Pages;

public partial class MainPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}