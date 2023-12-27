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

namespace RectangleRevolverGame
{
    using System.Timers;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _rowCount;
        private int _columnCount;
        private int _currentRowCount = 0;
        private int _currentColumnCount = 0;
        private bool _right = true;
        private bool _down = true;
        private DispatcherTimer _timer;
        private DispatcherTimer _reverseTimer;

        /// <summary>
        /// Represents main window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Elapsed;
            _reverseTimer = new DispatcherTimer();
            _reverseTimer.Interval = TimeSpan.FromSeconds(1);
            _reverseTimer.Tick += Reverse_Timer_Elapsed;
        }

        /// <summary>
        /// Represents reverse movement of rectangle.
        /// </summary>
        private void Move_Reverse()
        {
            if (_right && _down)
            {
                _currentRowCount++;
            }
            else if (!_down && _right)
            {
                _currentColumnCount++;
            }
            else if (!_down && !_right)
            {
                _currentRowCount--;
            }
            else
            {
                _currentColumnCount--;
            }
        }

        /// <summary>
        /// Represents reverse timer method.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void Reverse_Timer_Elapsed(object? sender, EventArgs e)
        {
            UpdateDirection();
            Move_Reverse();
            Grid.SetColumn(rectangle, _currentColumnCount);
            Grid.SetRow(rectangle, _currentRowCount);
        }

        /// <summary>
        /// Represents movement of rectangle.
        /// </summary>
        private void Move_Rectangle()
        {
            if(_right && _down)
            {
                _currentColumnCount++;
            }
            else if(_down)
            {
                _currentRowCount++;
            }
            else if (!_right)
            {
                _currentColumnCount--;
            }
            else
            {
                _currentRowCount--;
            }
        }

        /// <summary>
        /// Represents timer method.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void Timer_Elapsed(object? sender, EventArgs e)
        {
            UpdateDirection();
            Move_Rectangle();
            Grid.SetColumn(rectangle, _currentColumnCount);
            Grid.SetRow(rectangle, _currentRowCount);
        }

        /// <summary>
        /// Start rectangle movement.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Eventargs.</param>
        private void Start(object sender, RoutedEventArgs e)
        {
            _reverseTimer?.Stop();
            _timer.Start();
        }

        /// <summary>
        /// Represents update of direction
        /// </summary>
        private void UpdateDirection()
        {
            if(_currentColumnCount == _columnCount - 1)
            {
                _right = false;
            }
            if( _currentRowCount == _rowCount - 1)
            {
                _down = false;
            }
            if(_currentRowCount == 0)
            {
                _down = true;
            }
            if(_currentColumnCount == 0)
            {
                _right = true;
            }
        }

        /// <summary>
        /// Reverse rectangle movement.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Eventargs.</param>
        private void Reverse(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
            _reverseTimer.Start();
        }

        /// <summary>
        /// Represents Row Count Text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void RowCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            grid.RowDefinitions.Clear();
            if(int.TryParse(RowCount.Text, out _rowCount))
            {

            }
            AddRow();
        }

        /// <summary>
        /// Represents Column Count Text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void ColumnCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            grid.ColumnDefinitions.Clear();
            if (int.TryParse(ColumnCount.Text, out _columnCount))
            {

            }
            AddColumn();
        }

        /// <summary>
        /// Add column to grid.
        /// </summary>
        private void AddColumn()
        {
            for(int i  = 0; i < _columnCount; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        /// <summary>
        /// Add row to grid.
        /// </summary>
        private void AddRow()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}
