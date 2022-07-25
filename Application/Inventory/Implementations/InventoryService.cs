using System.Collections.Generic;
using Domain.Products.DTOs;
using System;
using System.Globalization;

namespace Application.Inventory.Implementations
{
    public class InventoryService : IInventoryService
    {
        private string specifier = "N";
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");

        public InventoryService()
        {
        }

        public bool ValidateRequestedUnits(IList<ProductDTO> inventory)
        {
            bool inputError = false;
            foreach (var product in inventory)
            {
                if (product.amount < product.requestedUnits)
                {
                    inputError = true;
                }
            }
            return inputError;
        }

        public IList<ProductDTO> UpdateStock(IList<ProductDTO> inventory)
        {
            foreach (var product in inventory)
            {
                if (product.requestedUnits != 0)
                {
                    product.amount -= product.requestedUnits;
                    product.requestedUnits = 0;
                }
            }
            return inventory;
        }

        public double UpdateTotalCost(IList<ProductDTO> inventory)
        {
            double totalCost = 0;
            foreach (var product in inventory)
            {
                totalCost += product.price * product.requestedUnits;
            }
            return totalCost;
        }

        public string CostFormat(double cost)
        {
            double newCost = Math.Round(cost, 2);
            string result = "₡ " + newCost.ToString(specifier, culture);
            result = result.Remove(result.Length() - 1);
            return result;
        }

        public double GetFullInventoryCost(IList<ProductDTO> inventory)
        {
            double totalCost = 0;
            foreach (var product in inventory)
            {
                totalCost += product.price * product.amount;
            }
            return totalCost;
        }
    }
}
