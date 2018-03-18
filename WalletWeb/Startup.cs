using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletDomain.Domain;
using WalletDomain.Services.Interfaces;
using WalletInfrastructure.AbstractionImplementation;
using WalletInfrastructure.DB;
using WalletInfrastructure.Repository;

namespace WalletWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=Wallet;Trusted_Connection=True;ConnectRetryCount=0";
            //var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Wallet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            const string connection = "Data Source=localhost;Initial Catalog=Wallet;User ID=SA;Password=<Toshiba321>;";
            services.AddDbContext<WalletContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("WalletWeb")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WalletContext>()
                .AddDefaultTokenProviders();

            //IoC
            services.AddScoped(typeof(IWalletService), typeof(WalletService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}