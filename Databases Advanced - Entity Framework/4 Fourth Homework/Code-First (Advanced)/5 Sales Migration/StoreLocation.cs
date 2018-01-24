using System.Collections.Generic;

namespace _5_Sales_Migration
{
    public class StoreLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<Sale> SalesInStore { get; set; }
    }
}
