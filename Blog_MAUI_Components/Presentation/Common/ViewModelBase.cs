using CommunityToolkit.Mvvm.ComponentModel;

namespace Blog_MAUI_Components.Presentation.Common;

public  abstract class ViewModelBase : ObservableObject, IQueryAttributable
{
    protected bool IsAppearingFromDetailPage;
    
    public ViewModelBase() { }

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        query.Clear();
    }

    public virtual void OnAppearing()
    {
        IsAppearingFromDetailPage = false;
    }

    public virtual void OnDisappearing() { }
}