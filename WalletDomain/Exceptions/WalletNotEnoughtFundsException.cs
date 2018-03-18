using System;

namespace WalletDomain.Exceptions
{
    public class WalletNotEnoughtFundsException : Exception
    {
        public WalletNotEnoughtFundsException()
        {
        }
        public WalletNotEnoughtFundsException(string message) : base(message)
        {
        }
    }
}
