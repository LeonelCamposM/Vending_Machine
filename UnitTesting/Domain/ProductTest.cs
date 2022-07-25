using Domain.Products.DTOs;
using FluentAssertions;
using Xunit;
using Domain.Products.Entities;

namespace UnitTesting.Application.ProductTests
{
    public class ProductTests
    {
        [Fact]
        public void InitProduct()
        {
            // arrange
           Product product = new Product(10, 500, "Coca cola");

            // assert
            product.amount.Should().Be(10);
            product.price.Should().Be(500);
            product.name.Should().Be("Coca cola");
        }
        
        [Fact]
        public void InitProductDTO()
        {
            // arrange
            ProductDTO product = new ProductDTO(10, 500, "Coca cola", 2);

            // assert
            product.amount.Should().Be(10);
            product.price.Should().Be(500);
            product.name.Should().Be("Coca cola");
            product.requestedUnits.Should().Be(2);
        }
    }
}