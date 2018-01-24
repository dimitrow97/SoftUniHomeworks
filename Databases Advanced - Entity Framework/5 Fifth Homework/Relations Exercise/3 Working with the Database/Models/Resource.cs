using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _3_Working_with_the_Database
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
    public enum ResourceType {Video, Presentation, Document, Other }
}
