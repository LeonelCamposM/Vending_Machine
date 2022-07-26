using Application.CashInventory;
using Application.Money;
using Application.Money.Implementations;
using Application.ProductInventory;
using Application.Products;
using Application.Products.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICashService, CashService>();
            services.AddTransient<IProductInventoryService, ProductInventoryService>();
            services.AddTransient<ICashInventoryService, CashInventoryService>();
            return services;
        }
    }
}
