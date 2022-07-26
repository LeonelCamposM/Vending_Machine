namespace Domain.Products.Entities
{
    public class Product
    {
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        public Product(int amount, double price, string name)
        {
            Amount = amount;
            Price = price;
            Name = name;
        }
    }
}
