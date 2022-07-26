using Domain.Money.Entities;
using System.Collections.Generic;

namespace Domain.Money.Repositories
{
    public interface ICashRepository
    {
        IList<Cash> GetAvailableCash();
        void UpdateAvailableCash(IList<Cash> availableCash);
    }
}
