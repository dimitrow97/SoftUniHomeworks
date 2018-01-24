namespace _3_Working_with_the_Database
{
    using System.Data.Entity;

    public class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("name=StudentsContext")
        {
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}