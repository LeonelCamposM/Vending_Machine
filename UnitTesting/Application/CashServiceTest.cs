using Application.Money.Implementations;
using Domain.Money.Entities;
using Domain.Money.Repositories;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTesting.Application.CashServiceTests
{
    public class CashServiceTests
    {
        [Fact]
        public void GetAvailableCash()
        {
            // arrange
            IList<Cash> stock = new List<Cash>(){
                new Cash(10,500,"moneda"),
                new Cash(10,100,"billete"),
                new Cash(10,25,"moneda"),
            };

            var mockProductRepository = new Mock<ICashRepository>();
            var moqService = new CashService(mockProductRepository.Object);
            mockProductRepository.Setup(repo => repo.GetAvailableCash()).Returns(stock.ToList());

            // act
            IList<Cash> result = moqService.GetAvailableCash();

            // assert
            result.Length().Should().Be(3);
        }

        [Fact]
        public void UpdateAvailableCash()
        {
            // arrange
            IList<Cash> stock = new List<Cash>(){
                new Cash(10,500,"moneda"),
                new Cash(10,100,"billete"),
                new Cash(10,25,"moneda"),
                new Cash(10,50,"moneda"),
            };

            var mockProductRepository = new Mock<ICashRepository>();
            var moqService = new CashService(mockProductRepository.Object);
            mockProductRepository.Setup(repo => repo.UpdateAvailableCash(stock));
            mockProductRepository.Setup(repo => repo.GetAvailableCash()).Returns(stock.ToList());

            // act
            moqService.UpdateAvailableCash(stock);
            IList<Cash> result = moqService.GetAvailableCash();

            // assert
            result.Length().Should().Be(4);
        }

    }
}