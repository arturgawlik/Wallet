using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalletDomain.DB;
using WalletDomain.Domain;
using WalletDomain.Exceptions;
using WalletDomain.Services.Interfaces;

namespace WalletDomain.Services.Services
{
    class WalletService : IWalletService
    {
        private readonly WalletContext _context;
        public WalletService(WalletContext context)
        {
            _context = context;
        }

        public void Add(int walletId, decimal amount)
        {
            if (amount < 0 || walletId <= 0)
            {
                throw new WalletException();
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == walletId);
            wallet.Add(amount);

            _context.Wallets.Update(wallet);

            _context.SaveChanges();
        }

        public Wallet Create(string name, int userId)
        {
            if (string.IsNullOrWhiteSpace(name) || userId <= 0)
            {
                throw new WalletException();
            }

            var wallet = new Wallet(name, userId);

            var createdWallet = _context.Wallets.Add(wallet);
            _context.SaveChanges();

            return createdWallet.Entity;
        }

        public void Delete(int Id)
        {
            if (Id <= 0)
            {
                throw new WalletException();
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == Id);

            if (wallet == null)
            {
                return;
            }

            _context.Wallets.Remove(wallet);
            _context.SaveChanges
        }

        public void OverrideDebitOption(int walletId, bool allowDebit)
        {
            if (walletId <= 0)
            {
                throw new WalletException();
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == walletId);

            if (wallet == null)
            {
                throw new WalletException();
            }

            wallet.AllowDebit = allowDebit;

            _context.Wallets.Update(wallet);
        }

        public void Substract(int walletId, decimal amount)
        {
            if (amount < 0 || walletId <= 0)
            {
                throw new WalletException();
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == walletId);
            wallet.Substract(amount);

            _context.Wallets.Update(wallet);

            _context.SaveChanges();
        }
    }
}
