using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_Shop.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }        
        public ICollection<Category> Categories { get; set; }
        public int? BuyerId { get; set; }
        public User Buyer { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
    }
}
