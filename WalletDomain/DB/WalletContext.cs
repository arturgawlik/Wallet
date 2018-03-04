using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Domain;

namespace WalletDomain.DB
{
    public class WalletContext : IdentityDbContext<ApplicationUser>
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
        }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
