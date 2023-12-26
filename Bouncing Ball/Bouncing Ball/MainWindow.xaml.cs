using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bouncing_Ball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _left = true;
        private bool _top = true;
        private double newPosX;
        private double newPosY;
        private Ellipse ellipse;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(10000);
            dispatcherTimer.Start();
            ellipse = new Ellipse() { Width = 50, Height = 50, Fill = Brushes.Red };
            PaintCanvas.Children.Add(ellipse);
        }

        /// <summary>
        /// Dispatcher timer method.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            PaintCanvas.Children.Remove(ellipse);
            PaintCanvas.Children.Add(ellipse);
            ChangeDirection();
            MoveBouncingBall();
        }

        /// <summary>
        /// Move bouncing ball.
        /// </summary>
        private void MoveBouncingBall()
        {
            if (_left == true)
            {
                var result = Canvas.GetRight(PaintCanvas);
                var result1 = Canvas.GetLeft(ellipse);
                Canvas.SetLeft(ellipse, newPosX -= 4);
            }
            else
            {
                Canvas.SetLeft(ellipse, newPosX += 4);
            }
            if (_top == true)
            {
                var result = Canvas.GetBottom(PaintCanvas);
                var result1 = Canvas.GetTop(ellipse);
                Canvas.SetTop(ellipse, newPosY -= 4);
            }
            else
            {
                Canvas.SetTop(ellipse, newPosY += 4);
            }
        }

        /// <summary>
        /// Change direction of ball.
        /// </summary>
        private void ChangeDirection()
        {
            if (Canvas.GetLeft(PaintCanvas) >= Canvas.GetLeft(ellipse))
            {
                _left = false;
            }
            var result = Canvas.GetRight(PaintCanvas);
            var result1 = Canvas.GetLeft(ellipse);
            var result2 = Canvas.GetRight(ellipse);
            if (Canvas.GetRight(PaintCanvas) <= Canvas.GetLeft(ellipse))
            {
                _left = true;
            }
            if (Canvas.GetTop(PaintCanvas) >= Canvas.GetTop(ellipse))
            {
                _top = false;
            }
            if (Canvas.GetBottom(PaintCanvas) <= Canvas.GetTop(ellipse))
            {
                _top = true;
            }
        }

        /// <summary>
        /// Event of Window loaded.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(ellipse, 100);
            Canvas.SetTop(ellipse, 100);
            newPosX = Canvas.GetLeft(ellipse);
            newPosY = Canvas.GetTop(ellipse);
            Canvas.SetLeft(PaintCanvas, 0);
            Canvas.SetTop(PaintCanvas, 0);
            var result = PaintCanvas.ActualWidth;
            var result1 = PaintCanvas.ActualHeight;
            Canvas.SetRight(PaintCanvas, PaintCanvas.ActualHeight);
            Canvas.SetBottom(PaintCanvas, PaintCanvas.ActualWidth);
        }

        /// <summary>
        /// Resize canvas.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void Resize_Canvas(object sender, SizeChangedEventArgs e)
        {
            var result = PaintCanvas.ActualWidth;
            Canvas.SetRight(PaintCanvas, PaintCanvas.ActualHeight);
            Canvas.SetBottom(PaintCanvas, PaintCanvas.ActualWidth);
        }
    }
}