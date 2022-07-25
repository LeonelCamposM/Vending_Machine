namespace Presentation.Products.Models
{
    internal class Money
    {
        public string type { get; set; }
        public double value { get; set; }
        public int enteredUnits { get; set; }

        public Money(string type, double value, int enteredUnits)
        {
            this.type = type;   
            this.value = value;
            this.enteredUnits = enteredUnits;
        }
    }
}
