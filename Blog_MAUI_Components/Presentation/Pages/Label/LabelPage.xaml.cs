namespace Blog_MAUI_Components.Presentation.Pages.Label;

public partial class LabelPage
{
    public LabelPage(LabelPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}