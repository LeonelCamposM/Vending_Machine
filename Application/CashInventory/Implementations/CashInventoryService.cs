using System.Collections.Generic;
using Application.AbstractInventory.Implementations;
using System.Linq;
using Domain.Money.DTOs;
using Application.CashInventory;

namespace Application.ProductInventory
{
    public class CashInventoryService : AbstractInventory<CashDTO>, ICashInventoryService
    {
        protected override int GetProductAmount(int index)
        {
           int amount = inventory.ElementAt(index).amount;
           return amount;
        }

        protected override double GetProductPrice(int index)
        {
            double price = inventory.ElementAt(index).price;
            return price;
        }

        protected override int GetRequestedUnits(int index)
        {
            int requestedUnits = inventory.ElementAt(index).requestedUnits;
            return requestedUnits;
        }

        public override void SetInventory(IList<CashDTO> newInventory)
        {
            inventory = newInventory;
        }

        protected override void SetProductAmount(int index, int newAmount)
        {
            inventory.ElementAt(index).amount = newAmount;
        }

        protected override void SetRequestedUnits(int index, int newUnits)
        {
            inventory.ElementAt(index).requestedUnits = newUnits;
        }
    }
}
