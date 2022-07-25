using Domain.Money.Entities;
using System.Collections.Generic;

namespace Infrastructure.Money
{
    internal class CashDbContext
    {
        public CashDbContext()
        {
        }

        // IList simulates a database
        public IEnumerable<Cash> Money = new List<Cash>(){
            new Cash(20,500,"Moneda"),
            new Cash(30,100,"Moneda"),
            new Cash(50,50,"Moneda"),
            new Cash(25,25,"Moneda"),
        };
    }
}
