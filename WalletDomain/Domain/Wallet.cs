﻿using System;
using WalletDomain.Exceptions;
using WalletDomain.Settings;

namespace WalletDomain.Domain
{
    public class Wallet
    {
        public Wallet()
        {
        }
        public Wallet(string name, decimal state, Guid userId)
        {
            Name = name;
            UserId = userId;
            State = state;
            AllowDebit = WalletSettings.AllowDebit;
        }

        public int Id { get; private set; }
        public decimal State { get; private set; }
        public string Name { get; private set; }
        public Guid UserId { get; private set; }


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

            if (State - value < 0 && !AllowDebit)
            {
                throw new WalletNotEnoughtFundsException("Wallet state cant be smaller than 0 when options dont let that");
            }

            State -= value;
        }

        public void OverrideDebitOption(bool allowDebit)
        {
            AllowDebit = allowDebit;
        }
    }
}
