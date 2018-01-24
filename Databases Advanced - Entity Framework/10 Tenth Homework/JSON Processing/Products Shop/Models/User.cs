using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products_Shop.Models
{
    public class User
    {
        public User()
        {
            this.Friends = new HashSet<User>();
            this.ProductsBought = new HashSet<Product>();
            this.ProductsSold = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        [StringLength(50 ,MinimumLength = 3)]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public ICollection<User> Friends { get; set; }        
        public ICollection<Product> ProductsSold { get; set; }        
        public ICollection<Product> ProductsBought { get; set; }        
    }
}
