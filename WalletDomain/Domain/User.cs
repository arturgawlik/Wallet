using System;
using System.Text.RegularExpressions;
using WalletDomain.Exceptions;

namespace WalletDomain.Domain
{
    public class User : IEquatable<User>
    {
        private static int _idCounter = 0;
        
        public User(string username, string email, string password)
        {
            SetUsername(username);
            SetEmail(email);
            SetPassword(password);
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public bool Equals(User other)
        {
            return Username.Equals(other.Username) && Email.Equals(other.Email) && Password.Equals(other.Password) && Id.Equals(other.Id);
        }


        public void SetUsername(string newUsername)
        {
            if (string.IsNullOrWhiteSpace(newUsername))
            {
                throw new UsernameException("Username is null or whitespace");
            }

            Username = newUsername;
        }

        public void SetEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                throw new EmailException("Email is null or whitespace");
            }
            
            CheckEmailValidity(newEmail);

            Email = newEmail;
        }

        public void SetPassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new PasswordException("Password is null or whitespace");
            }

            Password = newPassword;
        }

        private static void CheckEmailValidity(string newEmail)
        {
            var emailRegex = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");

            if (!emailRegex.IsMatch(newEmail))
            {
                throw new EmailException("Email is not match email regex");
            }
        }
    }
}
