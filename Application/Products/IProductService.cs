using Domain.Products.Entities;
using System.Collections.Generic;

namespace Application.Products
{
    public interface IProductService
    {
        IList<Product> GetAvailableProducts();
        void UpdateAvailableProducts(IList<Product> availableProducts);
    }
}
