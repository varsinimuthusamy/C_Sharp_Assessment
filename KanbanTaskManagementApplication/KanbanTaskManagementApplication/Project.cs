using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Represents project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Represents todo list.
        /// </summary>
        public List<Task> Todo;

        /// <summary>
        /// Represents progress list.
        /// </summary>
        public List<Task> Progress;

        /// <summary>
        /// Represents done list.
        /// </summary>
        public List<Task> Done;
    }
}
