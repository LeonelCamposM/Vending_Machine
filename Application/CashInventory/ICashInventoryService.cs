using Domain.Money.DTOs;
using System.Collections.Generic;

namespace Application.CashInventory
{
    public interface ICashInventoryService
    {
        public bool ValidateRequestedUnits();
        public IList<CashDTO> UpdateStock();
        public double UpdateTotalCost();
        public string CostFormat(double cost);
        public double GetFullInventoryCost();
        public void SetInventory(IList<CashDTO> newInventory);
        public IList<CashDTO> GetPaymentChange(double payment);
        public IList<CashDTO> GetInventory();
    }
}
