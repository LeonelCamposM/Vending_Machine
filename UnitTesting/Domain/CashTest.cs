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
            cash.amount.Should().Be(10);
            cash.price.Should().Be(500);
            cash.name.Should().Be("moneda");
        }
        
        [Fact]
        public void InitCashtDTO()
        {
            // arrange
            CashDTO product = new CashDTO(10, 500, "moneda", 2);

            // assert
            product.amount.Should().Be(10);
            product.price.Should().Be(500);
            product.name.Should().Be("moneda");
            product.requestedUnits.Should().Be(2);
        }
    }
}