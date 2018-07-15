using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalletDomain.Domain;
using WalletInfrastructure.AbstractionImplementation;

namespace WalletInfrastructure.DB
{
    public class WalletContext : IdentityDbContext<ApplicationUser>
    {
        private readonly SqlSettings _settings;
        public DbSet<Wallet> Wallets { get; set; }
        
        public WalletContext(DbContextOptions<WalletContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }
    }
}