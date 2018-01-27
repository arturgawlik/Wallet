using System;
using System.Collections.Generic;
using System.Text;

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
