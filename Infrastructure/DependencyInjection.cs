using Domain.Money.Repositories;
using Domain.Products.Repositories;
using Infrastructure.Money.Repositories;
using Infrastructure.Products.Repositories;
using Microsoft.Extensions.DependencyInjection;


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
