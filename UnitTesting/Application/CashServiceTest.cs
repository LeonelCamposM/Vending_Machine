﻿using Application.Money.Implementations;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Moq;
using Domain.Money.Repositories;
using Domain.Money.Entities;

namespace UnitTesting.Application.CashServiceTests
{
    public class CashServiceTests
    {
        [Fact]
        public void GetAvailableProducts()
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
        
    }
}