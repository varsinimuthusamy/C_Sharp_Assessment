using System;
using System.ComponentModel;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Represents task.
    /// </summary>
    public class Task : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private DateTime _created;
        private int _id = 0;
        /// <summary>
        /// Initializes an instance of <see cref="Task"/> class.
        /// </summary>
        public Task()
        {
            TaskId = 1;
        }

        /// <summary>
        /// Initializes an instance of <see cref="Task"/> class.
        /// </summary>
        public Task(string name, string description, DateTime dateTime) 
        {
            Name = name;
            Description = description;
            DueDate = dateTime;
        }

        /// <summary>
        /// Represents task Id.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Represents task name.
        /// </summary>
        public string Name { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Represents task description.
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Represents expiration date.
        /// </summary>
        public DateTime DueDate
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
                OnPropertyChanged("DueDate");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
