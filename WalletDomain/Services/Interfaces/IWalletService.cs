using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Domain;

namespace WalletDomain.Services.Interfaces
{
    public interface IWalletService
    {
        Wallet Create(string name, int userId);
        void Delete(int Id);
        void Add(int walletId, decimal amount);
        void Substract(int walletId, decimal deciaml);
        void OverrideDebitOption(int walletId, bool allowDebit);
    }
}
