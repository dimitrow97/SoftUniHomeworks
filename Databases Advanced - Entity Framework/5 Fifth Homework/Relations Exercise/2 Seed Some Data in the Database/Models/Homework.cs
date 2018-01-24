using System;
using System.ComponentModel.DataAnnotations;

namespace _2_Seed_Some_Data_in_the_Database
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }   
        [Required]     
        public ContentType ContextsType { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
    public enum ContentType { application, pdf, zip }
}
