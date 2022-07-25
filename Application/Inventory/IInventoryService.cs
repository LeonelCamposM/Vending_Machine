using Domain.Products.DTOs;
using System.Collections.Generic;

namespace Application.Inventory
{
    public interface IInventoryService
    {
        bool ValidateRequestedUnits(IList<ProductDTO> inventory);
        IList<ProductDTO> UpdateStock(IList<ProductDTO> inventory);
        double UpdateTotalCost(IList<ProductDTO> inventory);
        string CostFormat(double cost);
        double GetFullInventoryCost(IList<ProductDTO> inventory);
    }
}
