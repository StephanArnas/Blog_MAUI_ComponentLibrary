namespace Blog_MAUI_Components.Presentation.Pages.Entry;

public partial class EntryPage
{
    public EntryPage(EntryPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}