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
using System.Windows.Shapes;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Interaction logic for TaskDetailWindow.xaml
    /// </summary>
    public partial class TaskDetailWindow : Window
    {
        public Task task { get; set; }
        public TaskDetailWindow(Task Tasks)
        {
            task = Tasks;
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            task.Name = textBoxName.Text;
            task.Description = textBoxDescription.Text;
            task.DueDate = DateTime.Parse(textBoxDueDate.Text);
            Close();
        }
    }
}
