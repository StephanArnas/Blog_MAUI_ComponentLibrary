namespace Blog_MAUI_Components.MAUI.Common;

public static class ResourceHelper
{
    public static T GetResource<T>(string key)
    {
        if (Application.Current!.Resources.TryGetValue(key, out var value))
        {
            return (T)value;
        }

        throw new InvalidOperationException($"key {key} not found in the resource dictionary");
    }
}