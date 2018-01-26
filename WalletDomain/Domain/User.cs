using System;
using System.Collections.Generic;
using System.Text;

namespace WalletDomain
{
    public class User : IEquatable<User>
    {
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Equals(User other)
        {
            return Username.Equals(other.Username) && Email.Equals(other.Email) && Password.Equals(other.Password) && Id.Equals(other.Id);
        }


        public static bool operator ==(User firstUser, User secondUser )
        {
            return firstUser.Equals(secondUser);
        }

        public static bool operator !=(User firstUser, User secondUser)
        {
            return !firstUser.Equals(secondUser);
        }
    }
}
