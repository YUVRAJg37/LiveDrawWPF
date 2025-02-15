using System.Windows;
using System.Windows.Controls;
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

    private readonly DrawingManager _drawingManager = new();
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
        
        _drawingManager.Initialize();
    }

    private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            _drawingManager.StartDrawing(MainCanvas);
        }
    }

    private void Canvas_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _drawingManager.StopDrawing();
    }

    private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
    {
        _drawingManager.ContinueDrawing(e.GetPosition(MainCanvas));
    }
    private void ToggleCanvasVisibility_OnClick(object sender, RoutedEventArgs e)
    {
        _canvasVisibilityHandler.ToggleVisibility(this, MainCanvas);
    }
}