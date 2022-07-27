using Domain.Products.Entities;
using Domain.Products.Repositories;
using System.Collections.Generic;

namespace Application.Products.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAvailableProducts()
        {
            return _productRepository.GetAvailableProducts();
        }

        public void UpdateAvailableProducts(IList<Product> availableProducts)
        {
            _productRepository.UpdateAvailableProducts(availableProducts);
        }
    }
}
