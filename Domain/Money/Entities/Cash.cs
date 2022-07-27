namespace Domain.Money.Entities
{
    public class Cash
    {
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        public Cash(int amount, double price, string name)
        {
            Amount = amount;
            Price = price;
            Name = name;
        }
    }
}
