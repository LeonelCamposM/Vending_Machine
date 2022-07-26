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

        public bool ValidateRequestedUnits()
        {
            bool inputError = false;
            int index = 0;
            foreach (var product in inventory)
            {
                if (GetProductAmount(index) < GetRequestedUnits(index))
                {
                    inputError = true;
                }
                index += 1;
            }
            return inputError;
        }

        public IList<T> UpdateStock()
        {
            int index = 0;
            foreach (var product in inventory)
            {
                if (GetRequestedUnits(index) != 0)
                {
                    int newAmount = GetProductAmount(index) - GetRequestedUnits(index);
                    SetProductAmount(index, newAmount);
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
                totalCost += GetProductPrice(index) * GetRequestedUnits(index);
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
                totalCost += GetProductPrice(index) * GetProductAmount(index);
                index += 1;
            }
            return totalCost;
        }

        protected abstract double GetProductPrice(int index);
        protected abstract int GetProductAmount(int index);
        protected abstract int GetRequestedUnits(int index);
        protected abstract void SetProductAmount(int index, int newAmount);
        protected abstract void SetRequestedUnits(int index, int newUnits);
        public abstract void SetInventory(IList<T> inventory);
        public abstract IList<T> GetInventory();
    }
}
