using System;

namespace WalletDomain.Exceptions
{
    public class UsernameException : Exception
    {
        public UsernameException()
        {
        }
        public UsernameException(string message) : base(message)
        {
        }
    }
}