using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Exceptions;

namespace WalletDomain.Domain
{
    public class Wallet
    {
        public Wallet(string name, int userId)
        {
            if (userId <= 0)
            {
                throw new WalletException("UserId cant be smallet or equal to zero when new wallet is creating");
            }

            Name = name;
            UserId = userId;
        }

        private decimal state;
        public string Name { get; private set; }
        public int UserId { get; private set; }


        public bool AllowDebit { get; set; }
        

        public void Add(decimal value)
        {
            if (value < 0)
            {
                throw new WalletException("Adding value cant be smaller than 0");
            }
            
            if (value == 0)
            {
                return;
            }

            state += value;
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public void Substract(decimal value)
        {
            if (value < 0)
            {
                throw new WalletException("Substracting value cant be smaller than 0");
            }

            if (value == 0)
            {
                return;
            }

            state -= value;
        }
    }
}
