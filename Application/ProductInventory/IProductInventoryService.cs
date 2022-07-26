using Domain.Products.DTOs;
using System.Collections.Generic;

namespace Application.ProductInventory
{
    public interface IProductInventoryService
    {
        public bool ValidateRequestedUnits();
        public IList<ProductDTO> UpdateStock();
        public double UpdateTotalCost();
        public string CostFormat(double cost);
        public double GetFullInventoryCost();
        public void SetInventory(IList<ProductDTO> newInventory);
        public IList<ProductDTO> GetInventory();
    }
}
