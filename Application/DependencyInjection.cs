using Microsoft.Extensions.DependencyInjection;
using Application.Products;
using Application.Products.Implementations;
using Application.Money;
using Application.Money.Implementations;
using Application.ProductInventory;
using Application.CashInventory;

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
