using Domain.Products.Entities;
using Domain.Products.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Products.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository()
        {
            _dbContext = new ProductDbContext();
        }

        public IList<Product> GetAvailableProducts()
        {
            IList<Product> availableProducts = _dbContext.Products.OrderBy(product => product.name).ToList();
            return availableProducts;
        }

        public void UpdateAvailableProducts(IList<Product> availableProducts)
        {
            _dbContext.Products = availableProducts;
        }
    }
}