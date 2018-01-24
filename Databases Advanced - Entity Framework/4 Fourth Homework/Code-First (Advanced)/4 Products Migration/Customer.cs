using System.Collections.Generic;

namespace _4_Products_Migration
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public List<Sale> SalesForCustomer { get; set; }
    }
}
