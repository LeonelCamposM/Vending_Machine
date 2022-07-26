using Application.Products.Implementations;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Moq;
using Domain.Products.Repositories;
using Domain.Products.Entities;

namespace UnitTesting.Application.ProductServiceTests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetAvailableProducts()
        {
            // arrange
            IList<Product> stock = new List<Product>(){
                new Product(10,500,"Coca cola"),
                new Product(8,600,"Pepsi"),
                new Product(10,550,"Fanta"),
                new Product(15,725,"Sprite")
            };

            var mockProductRepository = new Mock<IProductRepository>();
            var moqService = new ProductService(mockProductRepository.Object);
            mockProductRepository.Setup(repo => repo.GetAvailableProducts()).Returns(stock.ToList());

            // act
            IList<Product> result = moqService.GetAvailableProducts();

            // assert
            result.Length().Should().Be(4);
        }
        
    }
}