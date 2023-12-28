using System.Windows;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Interaction logic for TaskManager.xaml
    /// </summary>
    public partial class TaskManager : Window
    {
        Project project = new Project();
        public TaskManager()
        {
            InitializeComponent();
        }

        private void Add_Task(object sender, RoutedEventArgs e)
        {
            MessageBox.Show();
            project.Todo.Add(new Task());
        }
    }
}
