
using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SasteMandi.RegisterServices
{
    public static class Repository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
