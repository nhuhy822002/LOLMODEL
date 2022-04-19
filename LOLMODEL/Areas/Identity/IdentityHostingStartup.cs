using System;
using LOLMODEL.Areas.Identity.Data;
using LOLMODEL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LOLMODEL.Areas.Identity.IdentityHostingStartup))]
namespace LOLMODEL.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginDbContextConnection")));

                services.AddDefaultIdentity<LOLMODELUser>(options =>
                { 
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<LoginDbContext>();
            });

        }
    }
}