using System.Collections.Generic;
using System;
using System.Globalization;

namespace Application.AbstractInventory.Implementations
{
    public abstract class AbstractInventory<T>
    {
        private readonly string _specifier = "N";
        private readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("es-ES");
        public IList<T> inventory = new List<T>();

        public AbstractInventory()
        {
        }

        public IList<T> UpdateInventory()
        {
            int index = 0;
            foreach (var product in inventory)
            {
                if (GetRequestedUnits(index) != 0)
                {
                    int newAmount = GetItemAmount(index) - GetRequestedUnits(index);
                    SetItemAmount(index, newAmount);
                    SetRequestedUnits(index, 0);
                }
                index += 1;
            }
            return inventory;
        }

        public double UpdateTotalCost()
        {
            double totalCost = 0;
            int index = 0;
            foreach (var product in inventory)
            {
                totalCost += GetItemPrice(index) * GetRequestedUnits(index);
                index += 1;
            }
            return totalCost;
        }

        public string CostFormat(double cost)
        {
            double newCost = Math.Round(cost, 2);
            string result = "₡ " + newCost.ToString(_specifier, _culture);
            result = result.Remove(result.Length() - 1);
            return result;
        }

        public double GetFullInventoryCost()
        {
            double totalCost = 0;
            int index = 0;
            foreach (var product in inventory)
            {
                totalCost += GetItemPrice(index) * GetItemAmount(index);
                index += 1;
            }
            return totalCost;
        }

        protected abstract double GetItemPrice(int index);
        protected abstract int GetItemAmount(int index);
        protected abstract int GetRequestedUnits(int index);
        protected abstract void SetItemAmount(int index, int newAmount);
        protected abstract void SetRequestedUnits(int index, int newUnits);
        public abstract void SetInventory(IList<T> inventory);
        public abstract IList<T> GetInventory();
    }
}
