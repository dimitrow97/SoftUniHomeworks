using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string FileSystemPath { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
