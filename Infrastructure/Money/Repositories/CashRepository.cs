using Domain.Money.Entities;
using Domain.Money.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Money.Repositories
{
    internal class CashRepository : ICashRepository
    {
        private readonly CashDbContext _dbContext;

        public CashRepository()
        {
            _dbContext = new CashDbContext();
        }

        public IList<Cash> GetAvailableCash()
        {
            IList<Cash> availableCash = _dbContext.Money.OrderByDescending(cash => cash.amount).ToList();
            return availableCash;
        }
    }
}