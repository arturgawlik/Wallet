﻿using System;
using System.Collections.Generic;
using System.Linq;
using WalletDomain.Domain;
using WalletDomain.Exceptions;
using WalletDomain.Services.Interfaces;
using WalletInfrastructure.DB;

namespace WalletInfrastructure.Repository
{
    public class WalletService : IWalletService
    {
        private readonly WalletContext _context;
        
        public WalletService(WalletContext context)
        {
            _context = context;
        }

        public void Add(int walletId, decimal amount)
        {
            if (amount < 0)
            {
                throw new WalletException($"Amount is equal: {amount}, when it can not be smaller than zero.");
            }
            if (amount == 0)
            {
                return;
            }
            if (walletId <= 0)
            {
                throw new WalletException($"walletId is equal: {walletId}, when it can not be samller or equal to zero.");
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == walletId);
            wallet.Add(amount);

            _context.Wallets.Update(wallet);

            _context.SaveChanges();
        }

        public Wallet Create(Wallet wallet)
        {
            var createdWallet = _context.Wallets.Add(wallet);
            _context.SaveChanges();

            return createdWallet.Entity;
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new WalletException($"Id is equal: {id}, when it can not be smaller or equal to zero.");
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == id);

            if (wallet == null)
            {
                return;
            }

            _context.Wallets.Remove(wallet);
            _context.SaveChanges();
        }

        public Wallet GetWalletById(int id)
        {
            return _context.Wallets.Where(w => w.Id == id).ToList().FirstOrDefault();
        }

        public IEnumerable<Wallet> GetAll()
        {
            return _context.Wallets;
        }

        public IEnumerable<Wallet> GetWalletsByUserId(Guid userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId).ToList();
        }

        public void OverrideDebitOption(int walletId, bool allowDebit)
        {
            if (walletId <= 0)
            {
                throw new WalletException($"walletId is equal: {walletId}, when it can not be samller or equal to zero.");
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == walletId);

            if (wallet == null)
            {
                throw new WalletException("Wallet object is null.");
            }

            wallet.AllowDebit = allowDebit;

            _context.Wallets.Update(wallet);
            _context.SaveChanges();
        }

        public void Substract(int walletId, decimal amount)
        {
            if (amount < 0)
            {
                throw new WalletException($"amount is: {amount}, when it can not be smaller than zero. Can not to substract negative value.");
            }
            if (walletId <= 0)
            {
                throw new WalletException($"walletId is: {walletId}, when it can not be smaller than zero.");
            }

            var wallet = _context.Wallets.FirstOrDefault(w => w.Id == walletId);

            if (wallet == null)
            {
                throw new WalletException("wallet object is null.");
            }

            wallet.Substract(amount);

            _context.Wallets.Update(wallet);

            _context.SaveChanges();
        }
    }
}