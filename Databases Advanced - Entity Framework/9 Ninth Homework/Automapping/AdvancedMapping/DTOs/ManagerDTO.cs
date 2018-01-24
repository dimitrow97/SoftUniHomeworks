using System.Collections.Generic;

namespace AdvancedMapping.DTOs
{
    public class ManagerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmployeeDTO> ManagerOf { get; set; }
    }
}
