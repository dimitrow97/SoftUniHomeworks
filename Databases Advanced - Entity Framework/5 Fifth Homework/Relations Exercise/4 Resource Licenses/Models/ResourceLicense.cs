using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Resource_Licenses.Models
{
    public class ResourceLicense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Resource ResourcesOfLicense { get; set; }
    }
}
