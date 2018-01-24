using _4_Resource_Licenses.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _4_Resource_Licenses
{
    public class Resource
    {
        public Resource()
        {
            this.ResourceLicenses = new HashSet<ResourceLicense>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }   
        [Required]     
        public ResourceType ResourcesType { get; set; }
        [Required]
        public string URL { get; set; }
        public virtual Course Course { get; set; }        
        public virtual ICollection<ResourceLicense> ResourceLicenses { get; set; }
    }
    public enum ResourceType {Video, Presentation, Document, Other }
}
