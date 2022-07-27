using Domain.Products.DTOs;
using Domain.Products.Entities;
using FluentAssertions;
using Xunit;

namespace UnitTesting.Domain.ProductTests
{
    public class ProductTests
    {
        [Fact]
        public void InitProduct()
        {
            // arrange
            Product product = new(10, 500, "Coca cola");

            // assert
            product.Amount.Should().Be(10);
            product.Price.Should().Be(500);
            product.Name.Should().Be("Coca cola");
        }

        [Fact]
        public void InitProductDTO()
        {
            // arrange
            ProductDTO product = new(10, 500, "Coca cola", 2);

            // assert
            product.Amount.Should().Be(10);
            product.Price.Should().Be(500);
            product.Name.Should().Be("Coca cola");
            product.RequestedUnits.Should().Be(2);
        }
    }
}