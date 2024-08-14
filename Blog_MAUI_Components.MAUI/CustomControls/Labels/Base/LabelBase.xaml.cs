using Blog_MAUI_Components.MAUI.Common;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace Blog_MAUI_Components.MAUI.CustomControls.Labels.Base;

public partial class LabelBase
{
    public LabelBase()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty ViewProperty = BindableProperty.Create("View",
        typeof(View), typeof(LabelBase), defaultValue: null, BindingMode.OneWay, ViewHelper.ValidateCustomView, ElementChanged);

    public View View
    {
        get => (View)GetValue(ViewProperty);
        set => SetValue(ViewProperty, value);
    }
    
    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create("IsRequired",
        typeof(bool), typeof(LabelBase), defaultValue: false, propertyChanged: IsRequiredChanged);

    public bool IsRequired
    {
        get => (bool)GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }
    
    public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label",
        typeof(string), typeof(LabelBase), propertyChanged: LabelChanged);

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    private static void ElementChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelBase)bindable).UpdateElementView();
    private static void IsRequiredChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelBase)bindable).UpdateIsRequiredView();
    private static void LabelChanged(BindableObject bindable, object oldValue, object newValue) => ((LabelBase)bindable).UpdateLabelView();
    
    private void UpdateElementView()
    {
        BorderLabel.Content = View;
        UpdateIsRequiredView();
    }

    private void UpdateIsRequiredView()
    {
        RequiredLabel.IsVisible = IsRequired;
    }

    private void UpdateLabelView()
    {
        LabelLabel.Text = Label;
        LabelLabel.IsVisible = !string.IsNullOrEmpty(Label);
    }
    
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        BorderCanvasView.InvalidateSurface(); // Repaint when binding context changes
    }
    
    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(); // Clear the canvas

        var paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = ResourceHelper.GetResource<Color>("Gray900").ToSKColor(), // Default border color
            StrokeWidth = 3,
            IsAntialias = true // Smooth edges
        };

        const float radius = 20f; // Corner radius
        const float labelExtraSpace = 8; // Fixed length for the segment
        float borderThickness = paint.StrokeWidth / 2;

        // Define the full rectangle based on the canvas size
        var rect = new SKRect(
            borderThickness,
            borderThickness,
            e.Info.Width - borderThickness,
            e.Info.Height - borderThickness
        );

        // Measure the Label's width
        float labelWidth = (float)LabelLabel.Width * e.Info.Width / (float)BorderCanvasView.Width;

        // Measure the RequiredLabel's width
        float isRequiredWidth = RequiredLabel.IsVisible ? (float)RequiredLabel.Width * e.Info.Width / (float)BorderCanvasView.Width : 0;

        // Calculate endX correctly
        float topLineRightSegmentStartX = 
            rect.Left + radius + labelExtraSpace + isRequiredWidth + labelWidth + labelExtraSpace;

        // Draw the top-left arc
        canvas.DrawArc(new SKRect(rect.Left, rect.Top, rect.Left + 2 * radius, rect.Top + 2 * radius), startAngle: 180, sweepAngle: 90, useCenter: false, paint);

        // Draw the top-right arc
        canvas.DrawArc(new SKRect(rect.Right - 2 * radius, rect.Top, rect.Right, rect.Top + 2 * radius), startAngle: 270, sweepAngle: 90, useCenter: false, paint);

        // Draw the bottom-right arc
        canvas.DrawArc(new SKRect(rect.Right - 2 * radius, rect.Bottom - 2 * radius, rect.Right, rect.Bottom), startAngle: 0, sweepAngle: 90, useCenter: false, paint);

        // Draw the bottom-left arc
        canvas.DrawArc(new SKRect(rect.Left, rect.Bottom - 2 * radius, rect.Left + 2 * radius, rect.Bottom), startAngle: 90, sweepAngle: 90, useCenter: false, paint);

        // Draw the left segment of the top line with a fixed length of 10 units
        canvas.DrawLine(rect.Left + radius, rect.Top, rect.Left + radius + labelExtraSpace, rect.Top, paint);

        // Draw the right segment of the top line from the end of the label to the top-right arc
        canvas.DrawLine(topLineRightSegmentStartX, rect.Top, rect.Right - radius, rect.Top, paint);

        // Draw the right line between the top-right and bottom-right arcs
        canvas.DrawLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius, paint);

        // Draw the bottom line between the bottom-right and bottom-left arcs
        canvas.DrawLine(rect.Left + radius, rect.Bottom, rect.Right - radius, rect.Bottom, paint);

        // Draw the left line between the bottom-left and top-left arcs
        canvas.DrawLine(rect.Left, rect.Top + radius, rect.Left, rect.Bottom - radius, paint);
    }
}