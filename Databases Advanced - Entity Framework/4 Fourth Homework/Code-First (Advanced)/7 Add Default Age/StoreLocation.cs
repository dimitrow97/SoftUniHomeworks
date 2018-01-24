using System.Collections.Generic;

namespace _7_Add_Default_Age
{
    public class StoreLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<Sale> SalesInStore { get; set; }
    }
}
