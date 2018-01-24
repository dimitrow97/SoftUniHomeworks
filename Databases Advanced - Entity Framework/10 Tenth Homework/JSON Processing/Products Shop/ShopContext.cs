namespace Products_Shop
{
    using Models;
    using System.Data.Entity;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.ProductsSold).WithRequired(p => p.Seller);

            modelBuilder.Entity<User>().HasMany(u => u.ProductsBought).WithOptional(p => p.Buyer);

            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(mc =>
            {
                mc.MapLeftKey("UserId");
                mc.MapRightKey("FriendId");
                mc.ToTable("UserFriends");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}