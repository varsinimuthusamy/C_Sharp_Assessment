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
using System.Windows.Threading;

namespace Bouncing_Ball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double newPosX;
        private double newPosY;
        private Ellipse ellipse;
        public MainWindow()
        {
            InitializeComponent();
            Canvas.SetLeft(PaintCanvas, 0);
            Canvas.SetTop(PaintCanvas, 0);
            Canvas.SetBottom(PaintCanvas,200);
            Canvas.SetRight(PaintCanvas, 200);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(100);
            dispatcherTimer.Start();
            ellipse = new Ellipse() { Width = 100, Height = 100, Fill = Brushes.Red };
            PaintCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, 100);
            Canvas.SetTop(ellipse, 100);
            newPosX = Canvas.GetLeft(ellipse);
            newPosY = Canvas.GetTop(ellipse);
            
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            PaintCanvas.Children.Remove(ellipse);
            PaintCanvas.Children.Add(ellipse);
            var result = Canvas.GetLeft(PaintCanvas);
            if (Canvas.GetLeft(PaintCanvas) >= Canvas.GetLeft(ellipse) || Canvas.GetTop(PaintCanvas) == Canvas.GetTop(ellipse))
            {
                Canvas.SetLeft(ellipse, newPosX += 4);
                Canvas.SetTop(ellipse, newPosY += 4);
            }
            else
            {
                Canvas.SetLeft(ellipse, newPosX -= 4);
                Canvas.SetTop(ellipse, newPosY -= 4);
            }
        } 

        
    }
}
