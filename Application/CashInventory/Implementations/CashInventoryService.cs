using Application.AbstractInventory.Implementations;
using Domain.Money.DTOs;
using Domain.Money.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.CashInventory
{
    public class CashInventoryService : AbstractInventory<CashDTO>, ICashInventoryService
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

        public override void SetInventory(IList<CashDTO> newInventory)
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

        public IList<Cash> GetPaymentChange(double payment)
        {
            inventory = inventory.OrderByDescending(cash => cash.Price).ToList();
            IList<CashDTO> result = new List<CashDTO>();
            double currentChange = 0;
            int index = 0;
            while (index < inventory.Count)
            {
                if (currentChange == payment)
                    break;
                CashDTO currency = inventory[index];
                bool usable = ValidateCurrencyUsability(index, payment, currentChange);
                if (usable)
                {
                    currentChange += currency.Price;
                    result.Add(currency);
                }
                else
                {
                    index += 1;
                }
            }
            IList<Cash> groupedChange = GroupChange(result);
            return groupedChange;
        }

        private bool ValidateCurrencyUsability(int index, double payment, double currentChange)
        {
            bool usable = false;
            CashDTO currency = inventory[index];
            double price = currency.Price;
            bool lessThanPayment = price + currentChange <= payment;
            if (lessThanPayment && currency.Amount > 0)
            {
                inventory[index].Amount -= 1;
                usable = true;
            }
            return usable;
        }

        private static IList<Cash> GroupChange(IList<CashDTO> consumerChange)
        {
            IList<Cash> groupedChange = new List<Cash>();
            var GroupedChange =
                            from cash in consumerChange
                            group cash by cash.Price;

            foreach (var cashGroup in GroupedChange)
            {
                var cash = cashGroup.FirstOrDefault();
                groupedChange.Add(new Cash(cashGroup.Count(), cash.Price, cash.Name));
            }
            return groupedChange;
        }

        public override IList<CashDTO> GetInventory()
        {
            return inventory;
        }
    }
}
