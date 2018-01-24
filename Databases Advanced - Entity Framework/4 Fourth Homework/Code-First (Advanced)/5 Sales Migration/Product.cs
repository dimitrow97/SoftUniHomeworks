using System.Collections.Generic;

namespace _5_Sales_Migration
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Sale> SalesOfProduct { get; set; }
    }
}
