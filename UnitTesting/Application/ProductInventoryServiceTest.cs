using Application.ProductInventory;
using System.Collections.Generic;
using Domain.Products.DTOs;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace UnitTesting.Application.ProductInventoryServiceTests
{
    public class ProductInventoryServiceTests
    {
        readonly ProductInventoryService inventoryService = new();

        [Fact]
        public void UpdateStock()
        {
            // arrange
            IList<ProductDTO> stock = new List<ProductDTO>(){
                new ProductDTO(10,500,"Coca cola", 10),
                new ProductDTO(8,600,"Pepsi", 2),
                new ProductDTO(10,550,"Fanta", 3),
                new ProductDTO(15,725,"Sprite", 2)
            };
            inventoryService.SetInventory(stock);

            // act 
            IList<ProductDTO> result = inventoryService.UpdateInventory();

            // assert
            result.ElementAt(0).Amount.Should().Be(0);
            result.ElementAt(1).Amount.Should().Be(6);
            result.ElementAt(2).Amount.Should().Be(7);
            result.ElementAt(3).Amount.Should().Be(13);
        }

        [Fact]
        public void ValidUpdateTotalCost()
        {
            // arrange
            IList<ProductDTO> stock = new List<ProductDTO>(){
                new ProductDTO(10,500,"Coca cola", 10),
                new ProductDTO(8,600,"Pepsi", 2),
                new ProductDTO(10,550,"Fanta", 3),
                new ProductDTO(15,725,"Sprite", 2)
            };
            inventoryService.SetInventory(stock);

            // act 
            double totalCost = inventoryService.UpdateTotalCost();

            // assert
            totalCost.Should().Be(9300.0);
        }

        [Fact]
        public void ValidCostFormat()
        {
            // arrange
            double totalCost = 9300.0;
            // act 
            string result = inventoryService.CostFormat(totalCost);

            // assert
            result.Should().Be("₡ 9.300,00");
        }

        [Fact]
        public void GetFullInventoryCost()
        {
            // arrange
            IList<ProductDTO> stock = new List<ProductDTO>(){
                new ProductDTO(10,500,"Coca cola", 1),
                new ProductDTO(8,600,"Pepsi", 2),
                new ProductDTO(10,550,"Fanta", 3),
                new ProductDTO(15,725,"Sprite", 2)
            };
            inventoryService.SetInventory(stock);

            // act 
            double result = inventoryService.GetFullInventoryCost();

            // assert
            result.Should().Be(26175);
        }
    }
}