using Domain.Products.Entities;
using System.Collections.Generic;

namespace Domain.Products.Repositories
{
    public interface IProductRepository
    {
        IList<Product> GetAvailableProducts();
        void UpdateAvailableProducts(IList<Product> availableProducts);
    }
}
