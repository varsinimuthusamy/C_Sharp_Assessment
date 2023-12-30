using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Interaction logic for TaskManager.xaml
    /// </summary>
    public partial class TaskManager : Window
    {
        public Project project { get; set; }
        public Task Tasks { get; set; }
        public TaskManager()
        {
            project = new Project();
            InitializeComponent();
        }
        private void Add_Task(object sender, RoutedEventArgs e)
        {
            Tasks = new Task();
            TaskDetailWindow taskDetailWindow = new TaskDetailWindow(Tasks);
            taskDetailWindow.ShowDialog();
            project.Todo.Add(Tasks);
        }
        private void Delete_Task(object sender, RoutedEventArgs e)
        {
            var result = (Task)toDoTask.SelectedItem; 
            project.Todo.Remove(result);
        }
        private void Edit_Task(object sender, RoutedEventArgs e)
        {
            var result = (Task)toDoTask.SelectedItem;
            TaskDetailWindow taskDetailWindow = new TaskDetailWindow(result);
            taskDetailWindow.ShowDialog();
        }

    }
}
