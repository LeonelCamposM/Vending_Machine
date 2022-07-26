using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Application.CashInventory;
using Domain.Money.DTOs;

namespace UnitTesting.Application.ProductInventoryServiceTests
{
    public class CashInventoryServiceTests
    {
        CashInventoryService inventoryService = new CashInventoryService();

        [Fact]
        public void ValidRequestedUnits()
        {
            // arrange
            IList<CashDTO> stock = new List<CashDTO>(){
                new CashDTO(10,500,"moneda", 1),
                new CashDTO(10,50,"moneda", 2),
                new CashDTO(10,25,"moneda", 3),
            };
            inventoryService.SetInventory(stock);

            // act 
            bool error = inventoryService.ValidateRequestedUnits();

            // assert
            error.Should().BeFalse();
        }

        [Fact]
        public void InvalidRequestedUnits()
        {
            // arrange
            IList<CashDTO> stock = new List<CashDTO>(){
                new CashDTO(10,500,"moneda", 1),
                new CashDTO(10,50,"moneda", 22),
                new CashDTO(10,25,"moneda", 42),
            };
            inventoryService.SetInventory(stock);

            // act 
            bool error = inventoryService.ValidateRequestedUnits();

            // assert
            error.Should().BeTrue();
        }

        [Fact]
        public void UpdateStock()
        {
            // arrange
            IList<CashDTO> stock = new List<CashDTO>(){
                new CashDTO(10,500,"moneda", 1),
                new CashDTO(10,50,"moneda", 2),
                new CashDTO(10,25,"moneda", 3),
            };
            inventoryService.SetInventory(stock);

            // act 
            IList<CashDTO> result = inventoryService.UpdateStock();

            // assert
            result.ElementAt(0).amount.Should().Be(9);
            result.ElementAt(1).amount.Should().Be(8);
            result.ElementAt(2).amount.Should().Be(7);
        }

        [Fact]
        public void ValidUpdateTotalCost()
        {
            // arrange
            IList<CashDTO> stock = new List<CashDTO>(){
                new CashDTO(10,500,"moneda", 1),
                new CashDTO(10,50,"moneda", 2),
                new CashDTO(10,25,"moneda", 3),
            };

            inventoryService.SetInventory(stock);

            // act 
            double totalCost = inventoryService.UpdateTotalCost();

            // assert
            totalCost.Should().Be(675.0);
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
            IList<CashDTO> stock = new List<CashDTO>(){
                new CashDTO(10,500,"moneda", 1),
                new CashDTO(10,50,"moneda", 2),
                new CashDTO(10,25,"moneda", 3),
            };

            inventoryService.SetInventory(stock);

            // act 
            double result = inventoryService.GetFullInventoryCost();

            // assert
            result.Should().Be(5750.0);
        }

        [Fact]
        public void GetPaymentChangeSuccess()
        {
            // arrange
            IList<CashDTO> stock = new List<CashDTO>(){
                new CashDTO(20,500,"moneda", 1),
                new CashDTO(30,100,"moneda", 2),
                new CashDTO(50,50,"moneda", 3),
                new CashDTO(25,25,"moneda", 3),
            };
            inventoryService.SetInventory(stock);

            // act 
            IList <CashDTO>  change = inventoryService.GetPaymentChange(3500);

            //// assert
            change.Length().Should().Be(7);
            change[0].price.Should().Be(500);
            change[1].price.Should().Be(500);
            change[2].price.Should().Be(500);
            change[3].price.Should().Be(500);
            change[4].price.Should().Be(500);
            change[5].price.Should().Be(500);
            change[6].price.Should().Be(500);
        }
    }
}