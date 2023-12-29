using System;
namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Represents task.
    /// </summary>
    public class Task
    {
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
        public string Name { get; set; }

        /// <summary>
        /// Represents task description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents expiration date.
        /// </summary>
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
