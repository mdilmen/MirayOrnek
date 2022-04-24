using Microsoft.Extensions.DependencyInjection;
using MirayOrnek.Data.Repositories;
using MirayOrnek.Data.Repositories.Interfaces;
using MirayOrnek.Services;
using MirayOrnek.Services.Interfaces;
using Serilog;
using Serilog.Core;

namespace MirayOrnek.Configurations
{
    public static class ServiceRegistration
    {
        public static void AddMirayOrnekTransient(this IServiceCollection serviceCollection)
        {
            // Services
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<IBasketService, BasketService>();

            // Repositories
            serviceCollection.AddTransient<IBasketRepository, BasketRepository>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();

        }
    }
}
