namespace Domain.Money.DTOs
{
    public class CashDTO
    {
        public int amount { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public int requestedUnits { get; set; }

        public CashDTO(int amount, double price, string name, int requestedUnits)
        {
            this.amount = amount;
            this.price = price;
            this.name = name;
            this.requestedUnits = requestedUnits;
        }
    }
}
