using System;
using Cgi_Api.Composition.Installer.Interfaces;
using Cgi_Api.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cgi_Api.Composition
{
    public class DbInstalller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Change hardcoded Connectionstring
            var connectionString = "Server=.;Database=CGI_V2;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddTransient<ApplicationDbContext>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    connectionString ?? throw new InvalidOperationException()));
        }
    }
}
