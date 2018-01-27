using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Exceptions;
using WalletDomain.Settings;

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
            _allowDebit = WalletSettings.AllowDebit;
        }

        public decimal State { get; private set; }
        public string Name { get; private set; }
        public int UserId { get; private set; }


        private bool _allowDebit;
        

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

            State += value;
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

            if (State - value < 0 && !_allowDebit)
            {
                throw new WalletNotEnoughtFundsException("Wallet state cant be smaller than 0 when options dont let that");
            }

            State -= value;
        }

        public void OverrideDebitOption(bool allowDebit)
        {
            _allowDebit = allowDebit;
        }
    }
}
