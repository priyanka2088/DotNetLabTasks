using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    internal class User
    {
        //encapsulation

        private string userName;
        private string password;
        private string email;
        // Properties
        public string Username { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }

        // Constructor
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        public void UpdateUser(string newUsername, string newPassword, string newEmail)
        {
            Username = newUsername;
            Password = newPassword;
            Email = newEmail;
        }
        // Method to display user information
        public void DisplayUser()
        {
            Console.WriteLine($"Username: {Username}, Email: {Email}");
        }
    }
}
