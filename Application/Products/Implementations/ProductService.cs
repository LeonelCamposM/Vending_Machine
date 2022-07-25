using Domain.Products.Repositories;
using Domain.Products.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Products.DTOs;
using System;
using System.Globalization;

namespace Application.Products.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private string specifier = "N";
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAvailableProducts()
        {
            return _productRepository.GetAvailableProducts();
        }

        public bool ValidateRequestedUnits(IList<ProductDTO> stock)
        {
            bool inputError = false;
            foreach (var product in stock)
            {
                if (product.amount < product.requestedUnits)
                {
                    inputError = true;
                }
            }
            return inputError;
        }

        public IList<ProductDTO> UpdateStock(IList<ProductDTO> stock)
        {
            foreach (var product in stock)
            {
                if (product.requestedUnits != 0)
                {
                    product.amount -= product.requestedUnits;
                    product.requestedUnits = 0;
                }
            }
            return stock;
        }

        public double UpdateTotalCost(IList<ProductDTO> stock)
        {
            double totalCost = 0;
            foreach (var product in stock)
            {
                totalCost += product.price * product.requestedUnits;
            }
            return totalCost;
        }

        public string CostFormat(double cost)
        {
            double newCost = Math.Round(cost, 2);
            string result = "₡ " + cost.ToString(specifier, culture);
            result = result.Remove(result.Length() - 1);
            return result;
        }
    }
}
