using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LiveDraw;

public class CanvasVisibilityHandler
{
    private enum CanvasVisibilityMode
    {
        TRANSPARENT,
        INVISIBLE,
        VISIBILE,
    }
    private CanvasVisibilityMode _canvasVisibilityMode = CanvasVisibilityMode.TRANSPARENT;

    public void ToggleVisibility(Window window, InkCanvas canvas)
    {
        switch (_canvasVisibilityMode)
        {
            case CanvasVisibilityMode.TRANSPARENT:
                canvas.Background = Brushes.Transparent;
                window.Background = (Brush)new BrushConverter().ConvertFromString("#00000000");
                _canvasVisibilityMode = CanvasVisibilityMode.INVISIBLE;
                break;
            case CanvasVisibilityMode.INVISIBLE:
                canvas.Background = Brushes.White;
                window.Background = (Brush)new BrushConverter().ConvertFromString("#01000000");
                _canvasVisibilityMode = CanvasVisibilityMode.VISIBILE;
                break;
            case CanvasVisibilityMode.VISIBILE:
                canvas.Background = Brushes.Transparent;
                window.Background = (Brush)new BrushConverter().ConvertFromString("#01000000");
                _canvasVisibilityMode = CanvasVisibilityMode.TRANSPARENT;
                break;
            default:
                break;
        }
    }
}