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
            var connectionString = "Server=5.39.113.6, 3305;Database=CGIV2;User Id=Emirhan;Password=tYuB@Q8h4yZb;MultipleActiveResultSets=true";
            //var connectionString = "Server=mssql.fhict.local;Database=dbi435201_bitcogg;User Id=dbi435201_bitcogg;Password=kilever2000;MultipleActiveResultSets=true";
            services.AddTransient<ApplicationDbContext>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    connectionString ?? throw new InvalidOperationException()));
        }
    }
}
