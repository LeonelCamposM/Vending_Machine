using Domain.Money.DTOs;
using FluentAssertions;
using Xunit;
using Domain.Money.Entities;

namespace UnitTesting.Domain.ProductTests
{
    public class CashTests
    {
        [Fact]
        public void InitCash()
        {
            // arrange
            Cash cash = new Cash(10, 500, "moneda");

            // assert
            cash.Amount.Should().Be(10);
            cash.Price.Should().Be(500);
            cash.Name.Should().Be("moneda");
        }
        
        [Fact]
        public void InitCashtDTO()
        {
            // arrange
            CashDTO product = new CashDTO(10, 500, "moneda", 2);

            // assert
            product.Amount.Should().Be(10);
            product.Price.Should().Be(500);
            product.Name.Should().Be("moneda");
            product.RequestedUnits.Should().Be(2);
        }
    }
}