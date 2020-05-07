using System;
using System.Collections.Generic;
using System.Text;
using Cgi_Api.Composition.Installer.Interfaces;
using Cgi_Api.Services;
using Cgi_Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cgi_Api.Composition.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
