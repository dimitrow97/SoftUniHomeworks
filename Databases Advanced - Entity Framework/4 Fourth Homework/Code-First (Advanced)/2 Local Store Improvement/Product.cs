namespace _2_Local_Store_Improvement
{
    public class Product
    {
        public Product(string name, string distributor, string description)
        {
            this.Name = name;
            this.Distributor = distributor;
            this.Description = description;            
        }
        public Product(string name, string distributor, string description, decimal price, decimal weight, int quantity)
        {
            this.Name = name;
            this.Distributor = distributor;
            this.Description = description;
            this.Price = price;
            this.Weight = weight;
            this.Quantity = quantity;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distributor { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Weight { get; set; }
        public int? Quantity { get; set; }
    }
}
