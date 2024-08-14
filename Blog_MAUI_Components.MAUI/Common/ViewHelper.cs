namespace Blog_MAUI_Components.MAUI.Common;

public static class ViewHelper
{
    public static bool ValidateCustomView(BindableObject bindable, object value)
    {
        if (value is not View)
        {
            throw new InvalidOperationException("Only View allowed");
        }

        return true;
    }
}