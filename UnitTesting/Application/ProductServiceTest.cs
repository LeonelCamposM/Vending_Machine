using Application.Products.Implementations;
using System.Collections.Generic;
using Domain.Products.DTOs;
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
        ProductService productService  = new ProductService(null);


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
        public void ValidRequestedUnits()
        {
            // arrange
            IList<ProductDTO> stock = new List<ProductDTO>(){
                new ProductDTO(10,500,"Coca cola", 1),
                new ProductDTO(8,600,"Pepsi", 2),
                new ProductDTO(10,550,"Fanta", 3),
                new ProductDTO(15,725,"Sprite", 2)
            };

            // act 
            bool error = productService.ValidateRequestedUnits(stock);

            // assert
            error.Should().BeFalse();
        }

        [Fact]
        public void InvalidRequestedUnits()
        {
            // arrange
            IList<ProductDTO> stock = new List<ProductDTO>(){
                new ProductDTO(10,500,"Coca cola", 11),
                new ProductDTO(8,600,"Pepsi", 2),
                new ProductDTO(10,550,"Fanta", 3),
                new ProductDTO(15,725,"Sprite", 2)
            };

            // act 
            bool error = productService.ValidateRequestedUnits(stock);

            // assert
            error.Should().BeTrue();
        }

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

            // act 
            IList<ProductDTO> result = productService.UpdateStock(stock);

            // assert
            result.ElementAt(0).amount.Should().Be(0);
            result.ElementAt(1).amount.Should().Be(6);
            result.ElementAt(2).amount.Should().Be(7);
            result.ElementAt(3).amount.Should().Be(13);
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

            // act 
            double totalCost = productService.UpdateTotalCost(stock);

            // assert
            totalCost.Should().Be(9300.0);
        }

        [Fact]
        public void ValidCostFormat()
        {
            // arrange
            double totalCost = 9300.0;
            // act 
            string result = productService.CostFormat(totalCost);

            // assert
            result.Should().Be("₡ 9.300,00");
        }
    }
}