namespace _5_Photographers
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotoContext : DbContext
    {
        public PhotoContext()
            : base("name=PhotoContext")
        {
        }
        public virtual DbSet<Photographer> Photographers { get; set; }
    }
}