using System;

namespace WalletDomain.Exceptions
{
    public class WalletException : Exception
    {
        public WalletException()
        {
        }
        public WalletException(string message) : base(message)
        {
        }
    }
}
