using System;
using System.Collections.Generic;
using System.Text;

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
