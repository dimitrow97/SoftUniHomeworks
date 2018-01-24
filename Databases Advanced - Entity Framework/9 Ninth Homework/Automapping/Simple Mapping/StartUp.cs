using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Simple_Mapping.DTOs;

namespace Simple_Mapping
{
    class StartUp
    {
        static void Main(string[] args)
        {
            AutoMapping();

            Employee employee = new Employee()
            {
                FirstName = "Ivan",
                LastName = "Penchev",
                Salary = 200m,
                Address = "Sliven, bul.Panayot Hitov 12",
                BirthDay = DateTime.Now
            };

            EmployeeDTO dto = Mapper.Map<EmployeeDTO>(employee);
            Console.WriteLine($"{dto.FirstName} {dto.LastName}, with a salary of:{dto.Salary}$");
        }

        public static void AutoMapping()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Employee, EmployeeDTO>(); });
        }
    }
}
