namespace Blog_MAUI_Components.MAUI.CustomControls.Buttons;

public partial class CustomButton
{
    private const string LowerKey = "lower";
    private const string UpperKey = "upper";

    public CustomButton()
    {
        InitializeComponent();
        
        var lowerAnimation = new Animation(v => AnimatedProgressBar.LowerRangeValue = (float)v, -0.4, 1.0);
        var upperAnimation = new Animation(v => AnimatedProgressBar.UpperRangeValue = (float)v, 0.0, 1.4);

        lowerAnimation.Commit(this, LowerKey, length: 1000, easing: Easing.CubicInOut, repeat: () => true);
        upperAnimation.Commit(this, UpperKey, length: 1000, easing: Easing.CubicInOut, repeat: () => true);
    }
}