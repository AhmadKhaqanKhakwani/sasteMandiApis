using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SasteMandi.RegisterServices
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMobileService, MobileService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            return services;
        }
    }
}
