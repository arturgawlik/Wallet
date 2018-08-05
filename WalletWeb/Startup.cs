using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletInfrastructure.AbstractionImplementation;
using WalletInfrastructure.DB;
using WalletWeb.IoC;
using FluentValidation.AspNetCore;
using WalletDomain.Services.Interfaces;
using WalletInfrastructure.Repository;

namespace WalletWeb
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }
        private IContainer ApplicationContainer { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Wallet;Trusted_Connection=True;ConnectRetryCount=0";
            //var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Wallet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //const string connection = "Data Source=localhost;Initial Catalog=Wallet;User ID=SA;Password=<Toshiba321>;";
			services.AddDbContext<WalletContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("WalletWeb")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WalletContext>()
                .AddDefaultTokenProviders();

			//IoC
			//var builder = new ContainerBuilder();
			//builder.Populate(services);
			//builder.RegisterModule(new ContainerModule(Configuration));
			//ApplicationContainer = builder.Build();
			//
			//return new AutofacServiceProvider(ApplicationContainer);
			services.AddScoped<IWalletService, WalletService>();
			services.AddSingleton<SqlSettings>(new SqlSettings { ConnectionString = Configuration.GetSection("sql").GetValue<string>("connectionString") });
			//services.Configure<SqlSettings>(Configuration.GetSection("sql"));
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