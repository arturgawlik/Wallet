using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalletDomain.Domain;

namespace WalletDomain.Services.Interfaces
{
    public interface IWalletService
    {
        Wallet Create(Wallet wallet);
        void Delete(int id);
        void Add(int walletId, decimal amount);
        void Substract(int walletId, decimal deciaml);
        void OverrideDebitOption(int walletId, bool allowDebit);
        IEnumerable<Wallet> GetWalletsByUserId(Guid userId);
        Wallet GetWalletById(int id);
        IEnumerable<Wallet> GetAll();
    }
}
