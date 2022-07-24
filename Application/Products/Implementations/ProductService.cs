using Domain.Products.Repositories;
using Domain.Products.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Products.Implementations
{
    internal class ProductService : IProductService
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
    }
}
