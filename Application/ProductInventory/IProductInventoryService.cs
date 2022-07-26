using Domain.Products.DTOs;
using System.Collections.Generic;

namespace Application.ProductInventory
{
    public interface IProductInventoryService
    {
        public IList<ProductDTO> UpdateInventory();
        public double UpdateTotalCost();
        public string CostFormat(double cost);
        public double GetFullInventoryCost();
        public void SetInventory(IList<ProductDTO> newInventory);
        public IList<ProductDTO> GetInventory();
    }
}
