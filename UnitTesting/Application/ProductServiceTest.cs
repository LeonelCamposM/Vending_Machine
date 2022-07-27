using Application.Products.Implementations;
using Domain.Products.Entities;
using Domain.Products.Repositories;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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

        [Fact]
        public void UpdateAvailableProducts()
        {
            // arrange
            IList<Product> stock = new List<Product>(){
                new Product(10,500,"Coca cola"),
                new Product(8,600,"Pepsi"),
                new Product(10,550,"Fanta"),
            };

            var mockProductRepository = new Mock<IProductRepository>();
            var moqService = new ProductService(mockProductRepository.Object);
            mockProductRepository.Setup(repo => repo.UpdateAvailableProducts(stock));
            mockProductRepository.Setup(repo => repo.GetAvailableProducts()).Returns(stock.ToList());

            // act
            moqService.UpdateAvailableProducts(stock);
            IList<Product> result = moqService.GetAvailableProducts();

            // assert
            result.Length().Should().Be(3);
        }

    }
}