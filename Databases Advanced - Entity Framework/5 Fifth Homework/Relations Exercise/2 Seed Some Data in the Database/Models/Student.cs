﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2_Seed_Some_Data_in_the_Database
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
        [Required]
        public DateTime BirthDay { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
