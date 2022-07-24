namespace Domain.Products.DTOs
{
    public class ProductDTO
    {
        public int amount { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public int requestedUnits { get; set; }

        public ProductDTO(int amount, double price, string name, int requestedUnits)
        {
            this.amount = amount;
            this.price = price;
            this.name = name;
            this.requestedUnits = requestedUnits;
        }
    }
}
