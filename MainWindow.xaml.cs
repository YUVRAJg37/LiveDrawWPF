using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace LiveDraw;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double _width = 0;
    private double _height = 0;
    
    private readonly CanvasVisibilityHandler _canvasVisibilityHandler = new();
    
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object obj, RoutedEventArgs e)
    {
        this.Topmost = true;
        _width = this.ActualWidth;
        _height = this.ActualHeight;
            
        Canvas.SetLeft(ToolBar, (_width / 2) - (ToolBar.ActualHeight/2));
        Canvas.SetTop(ToolBar, 50);

        MainInkCanvas.Height = Height;
        MainInkCanvas.Width = _width;
        
        MainInkCanvas.DefaultDrawingAttributes = new DrawingAttributes()
        {
            Color = Colors.Black,
            FitToCurve = true,
            Width = 5,
            Height = 5
        };
    }
    
    private void ToggleCanvasVisibility_OnClick(object sender, RoutedEventArgs e)
    {
        _canvasVisibilityHandler.ToggleVisibility(this, MainInkCanvas);
    }

    private void BrushButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        MainInkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
    }

    private void EraserButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
    }
}