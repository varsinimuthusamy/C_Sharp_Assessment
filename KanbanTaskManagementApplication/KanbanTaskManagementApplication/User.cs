using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Represents user.
    /// </summary>
    public class User
    {
        private static int _id = 0;

        /// <summary>
        /// Initilaizes an instance of <see cref="User"/> class.
        /// </summary>
        public User(string name, string email, string password)
        {
            Id = _id++;
            Name = name;
            Email = email; 
            Password = password;
        }

        /// <summary>
        /// Represents Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represents password.
        /// </summary>
        public string Password { get; set; }

    }
}
