using System;
using System.Collections.Generic;
using System.Text;

namespace XCBIR.Classes
{
    /// <summary>
    /// Represents login agent for the system
    /// </summary>
    public class login
    {
        /// <summary>
        /// The username of this login
        /// </summary>
        private string username;
        /// <summary>
        /// The password of this login
        /// </summary>
        private string password;
        /// <summary>
        /// The date of last login
        /// </summary>
        private DateTime lastLogin;

        /// <summary>
        /// Creates new instance of login class
        /// </summary>
        /// <param name="Username">The username of this instance</param>
        /// <param name="Password">The password of this instance</param>
        public login(string Username, string Password)
        {
            //This constructor may be used to initiate a session for this user on the system
            this.username = Username;
            this.password = Password;
            this.lastLogin = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the username of this login
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        /// <summary>
        /// Gets or sets the password of this login
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// Gets the date of last login
        /// </summary>
        public DateTime LastLogin
        {
            get
            {
                return lastLogin;
            }
        }

        /// <summary>
        /// Logs this user into the system
        /// </summary>
        public bool openSession()
        {
            bool sessionOpened = false;
            return sessionOpened;
        }
    }
}
