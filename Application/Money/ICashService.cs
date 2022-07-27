using Domain.Money.Entities;
using System.Collections.Generic;

namespace Application.Money
{
    public interface ICashService
    {
        IList<Cash> GetAvailableCash();
        void UpdateAvailableCash(IList<Cash> availableCash);
    }
}
