using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _1_Code_First_Student_System
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }   
        [Required]     
        public ResourceType ResourcesType { get; set; }
        [Required]
        public string URL { get; set; }
        public virtual Course Course { get; set; }
    }
    public enum ResourceType {[Description("Video")]Video, [Description("Presentation")]Presentation, Document, Other }
}
