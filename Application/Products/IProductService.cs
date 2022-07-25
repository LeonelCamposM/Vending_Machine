using Domain.Products.DTOs;
using Domain.Products.Entities;
using System.Collections.Generic;

namespace Application.Products
{
    public interface IProductService
    {
        IList<Product> GetAvailableProducts();
        bool ValidateRequestedUnits(IList<ProductDTO> stock);
        IList<ProductDTO> UpdateStock(IList<ProductDTO> stock);
        double UpdateTotalCost(IList<ProductDTO> stock);
        string CostFormat(double cost);
    }
}
