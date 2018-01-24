namespace _1_Code_First_Student_System
{
    using System;
    using System.Data.Entity;
    using System.Linq;

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