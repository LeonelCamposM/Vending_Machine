using Domain.Money.Entities;
using Domain.Money.Repositories;
using System.Collections.Generic;

namespace Application.Money.Implementations
{
    public class CashService : ICashService
    {
        private readonly ICashRepository _cashRepository;

        public CashService(ICashRepository cashRepository)
        {
            _cashRepository = cashRepository;
        }

        public IList<Cash> GetAvailableCash()
        {
            return _cashRepository.GetAvailableCash();
        }

        public void UpdateAvailableCash(IList<Cash> availableCash)
        {
            _cashRepository.UpdateAvailableCash(availableCash);
        }
    }
}
