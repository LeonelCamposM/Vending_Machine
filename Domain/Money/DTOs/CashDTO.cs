namespace Domain.Money.DTOs
{
    public class CashDTO
    {
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int RequestedUnits { get; set; }

        public CashDTO(int amount, double price, string name, int requestedUnits)
        {
            Amount = amount;
            Price = price;
            Name = name;
            RequestedUnits = requestedUnits;
        }
    }
}
