using System;
namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Represents task.
    /// </summary>
    public class Task
    {
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
        public DateTime ExpirationDate { get; set; }
    }
}
