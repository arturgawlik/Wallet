using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalletDomain.Domain;
using WalletInfrastructure.AbstractionImplementation;

namespace WalletInfrastructure.DB
{
    public class WalletContext : IdentityDbContext<ApplicationUser>
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
        }
        public DbSet<Wallet> Wallets { get; set; }
    }
}