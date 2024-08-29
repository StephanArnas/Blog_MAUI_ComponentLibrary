namespace Blog_MAUI_Components.Presentation.Pages.Search;

public partial class CitySearchPage
{
    public CitySearchPage(CitySearchPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}