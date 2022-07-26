namespace Domain.Money.Entities
{
    public class Cash
    {
        public int amount { get; set; }
        public double price { get; set; }
        public string name { get; set; }

        public Cash(int amount, double price, string name)
        {
            this.amount = amount;
            this.price = price;
            this.name = name;
        }
    }
}
