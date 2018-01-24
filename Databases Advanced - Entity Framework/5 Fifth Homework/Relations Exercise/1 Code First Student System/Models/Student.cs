using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1_Code_First_Student_System
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; } 
        
    }
}
