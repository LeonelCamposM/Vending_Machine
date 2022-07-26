using Microsoft.Extensions.DependencyInjection;
using Domain.Products.Repositories;
using Domain.Money.Repositories;
using Infrastructure.Products.Repositories;
using Infrastructure.Money.Repositories;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICashRepository, CashRepository>();
            return services;
        }
    }
}
