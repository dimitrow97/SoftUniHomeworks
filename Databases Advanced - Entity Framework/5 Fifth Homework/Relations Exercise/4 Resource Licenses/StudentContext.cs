namespace _4_Resource_Licenses
{
    using System.Data.Entity;    
    using Models;

    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
            Database.SetInitializer<StudentContext>(null);
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<ResourceLicense> Licenses { get; set; }
    }
}