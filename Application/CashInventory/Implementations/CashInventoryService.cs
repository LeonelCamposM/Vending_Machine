using System.Collections.Generic;
using Application.AbstractInventory.Implementations;
using System.Linq;
using Domain.Money.DTOs;

namespace Application.CashInventory
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

        public IList<CashDTO> GetPaymentChange(double payment)
        {
            inventory = inventory.OrderByDescending(cash => cash.price).ToList();
            IList <CashDTO> result = new List<CashDTO>();
            double currentChange = 0;
            int index = 0;
            while(index < inventory.Count)
            {
                if (currentChange == payment)
                {
                    break;
                }
                CashDTO cash = inventory[index];
                double tempChange = cash.price;
                if(tempChange+currentChange <= payment && cash.amount > 0)
                {
                    currentChange += tempChange;
                    inventory[index].amount -= 1;
                    result.Add(cash);
                }
                else
                {
                    index += 1;
                }
            }
            return result;
        }

        public override IList<CashDTO> GetInventory()
        {
            return inventory;
        }
    }
}
