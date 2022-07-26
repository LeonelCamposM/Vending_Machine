using Domain.Products.DTOs;
using System.Collections.Generic;
using Application.AbstractInventory.Implementations;
using System.Linq;

namespace Application.ProductInventory
{
    public class ProductInventoryService : AbstractInventory<ProductDTO>, IProductInventoryService
    {
        protected override int GetItemAmount(int index)
        {
           int amount = inventory.ElementAt(index).Amount;
           return amount;
        }

        protected override double GetItemPrice(int index)
        {
            double price = inventory.ElementAt(index).Price;
            return price;
        }

        protected override int GetRequestedUnits(int index)
        {
            int requestedUnits = inventory.ElementAt(index).RequestedUnits;
            return requestedUnits;
        }

        public override void SetInventory(IList<ProductDTO> newInventory)
        {
            inventory = newInventory;
        }

        protected override void SetItemAmount(int index, int newAmount)
        {
            inventory.ElementAt(index).Amount = newAmount;
        }

        protected override void SetRequestedUnits(int index, int newUnits)
        {
            inventory.ElementAt(index).RequestedUnits = newUnits;
        }

        public override IList<ProductDTO> GetInventory()
        {
            return inventory;
        }
    }
}
