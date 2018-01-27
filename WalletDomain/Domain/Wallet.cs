using System;
using System.Collections.Generic;
using System.Text;

namespace WalletDomain.Domain
{
    public class Wallet
    {
        public Wallet(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }

        public string Name { get; private set; }
        public int UserId { get; private set; }
        public bool AllowDebit { get; set; }

        public void Add(int v)
        {
            throw new NotImplementedException();
        }

        public object GetBalance()
        {
            throw new NotImplementedException();
        }

        public void Substract(int v)
        {
            throw new NotImplementedException();
        }
    }
}
