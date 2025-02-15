using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Windows.Point;

namespace LiveDraw;

public class DrawingManager
{
    private Polyline _polyline;
    private bool _isPainting = false;
    private double _brushThickness = 5.0f;
    private SolidColorBrush _paintBrush = new SolidColorBrush(Colors.Black);
    private SolidColorBrush _currentBrush;

    public void Initialize()
    {
        _currentBrush = _paintBrush;
    }

    public void StartDrawing(Canvas canvas)
    {
        _isPainting = true;
        _polyline = new Polyline()
        {
            Stroke = _currentBrush,
            StrokeThickness = _brushThickness,
            StrokeStartLineCap = PenLineCap.Round,
            StrokeEndLineCap = PenLineCap.Round,    
        };
        canvas.Children.Add(_polyline);
    }

    public void ContinueDrawing(Point point)
    {
        if (_isPainting)
        {
            _polyline.Points.Add(point);
        }
    }

    public void StopDrawing()
    {
        _isPainting = false;
    }
}