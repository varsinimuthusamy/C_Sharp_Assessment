using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Represents project.
    /// </summary>
    public class Project
    {
        private ObservableCollection<Task> task;
        private ObservableCollection<Task> task1;
        private ObservableCollection<Task> task2;
        public Project()
        {
            Todo = new ObservableCollection<Task>();
            Progress = new ObservableCollection<Task>();
            Done = new ObservableCollection<Task>();
        }

        /// <summary>
        /// Represents project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Represents todo list.
        /// </summary>
        public ObservableCollection<Task> Todo
        {
            get { return task; }
            set { task = value; }
        }

        /// <summary>
        /// Represents progress list.
        /// </summary>
        public ObservableCollection<Task> Progress
        {
            get { return task1; }
            set { task1 = value; }
        }

        /// <summary>
        /// Represents done list.
        /// </summary>
        public ObservableCollection<Task> Done
        {
            get { return task2; }
            set { task2 = value; }
        }
    }
}
