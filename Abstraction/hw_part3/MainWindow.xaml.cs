using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hw_part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum SelectedShape { Circle, Rectangle, Line }
        int pointCount;        
        SelectedShape currentShape;        
        Random selectedVertex = new Random();
        List<Point> points = new List<Point>();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void circleOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Circle;
        }

        private void rectOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Rectangle;
        }

        private void lineOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Line;
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shapeToRender = null;

            // Configure the correct shape to draw.
            switch (currentShape)
            {
                case SelectedShape.Circle:
                    shapeToRender = new Ellipse() { Fill = Brushes.Green, Height = 15, Width = 15 };
                    pointCount++;
                    break;
                case SelectedShape.Rectangle:
                    shapeToRender = new Rectangle() { Fill = Brushes.Red, Height = 35, Width = 35, RadiusX = 10, RadiusY = 10 };
                    break;
                case SelectedShape.Line:
                    shapeToRender = new Line() 
                    {
                        Stroke = Brushes.Blue, StrokeThickness = 5, X1 = 0, X2 = 300, Y1 = 0, Y2 = 0,
                        StrokeStartLineCap= PenLineCap.Triangle,
                        StrokeEndLineCap= PenLineCap.Round
                    };
                    break;
                default:
                    return;
            }

            // Set top/left position to draw in the canvas.
            Canvas.SetLeft(shapeToRender, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shapeToRender, e.GetPosition(canvasDrawingArea).Y);
            
                        
            // Draw shape!
            canvasDrawingArea.Children.Add(shapeToRender);

            Type shapeType = shapeToRender.GetType();
            if (shapeType == typeof(Line))
            {
                double x = e.GetPosition(canvasDrawingArea).X;
                double y = e.GetPosition(canvasDrawingArea).Y;
                double w = 300;
                double h = 100;
                DrawRuler(x, y, w, h);
            }

            points.Add(e.GetPosition(canvasDrawingArea));
            bool threePointsExist = checkPointCount();
            renderTriangleIf(threePointsExist);
        }

        private void DrawRuler(double x, double y, double w, double h)
        {
            if (w < 10 || h <5)
            {
                return;
            }
            else
            {
                Line tickMark = new Line()
                {
                    Stroke = Brushes.Black, StrokeThickness = 5, X1 = 0, X2 = 0, Y1 = -h, Y2 =0,
                    StrokeStartLineCap = PenLineCap.Triangle,
                    StrokeEndLineCap = PenLineCap.Round,
                };

                // Set top/left position to draw in the canvas.
                double midX = x +(w/2);
                Canvas.SetLeft(tickMark, midX);
                Canvas.SetTop(tickMark, y);
                
                // Draw shape!
                canvasDrawingArea.Children.Add(tickMark);
                DrawRuler(x, y, w / 2, h / 2);
                DrawRuler(midX, y, w / 2, h / 2);
            }            
        }

        private void renderTriangleIf(bool threePointsExist)
        {
            if (threePointsExist)
            {
                int pointIndex = selectedVertex.Next(3);
                Point myPoint = points[pointIndex];

                while (pointCount <= 1000)
                {   
                    int nextPointIndex = selectedVertex.Next(3);
                    Point nextPoint = points[nextPointIndex];

                    Shape circle = new Ellipse() { Fill = Brushes.Green, Height = 15, Width = 15 };
                    double midpointX = Math.Abs((myPoint.X + nextPoint.X) / 2);
                    double midpointY = Math.Abs((myPoint.Y + nextPoint.Y) / 2);

                    Canvas.SetLeft(circle, midpointX);
                    Canvas.SetTop(circle, midpointY);

                    canvasDrawingArea.Children.Add(circle);
                    myPoint = new Point(midpointX, midpointY);
                    pointCount++;
                }
            }
        }

        private bool checkPointCount()
        {
            if (pointCount==3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {            
            removeShape(sender, e);
        }

        private void removeShape(object sender, MouseButtonEventArgs e)
        {
            // First, get the X,Y location of where the user clicked.
            Point pt = e.GetPosition((Canvas)sender);

            // Use the HitTest() method of VisualTreeHelper to see if the user clicked
            // on an item in the canvas.
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

            // If the result is not null, they DID click on a shape!
            if (result != null)
            {
                // Get the underlying shape clicked on, and remove it from the canvas.
                canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
            }
        }
    }
}
