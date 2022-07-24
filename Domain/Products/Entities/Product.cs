namespace Domain.Products.Entities
{
    public class Product
    {
        public int amount { get; set; }
        public double price { get; set; }
        public string name { get; set; }

        public Product(int amount, double price, string name)
        {
            this.amount = amount;
            this.price = price;
            this.name = name;
        }
    }
}
