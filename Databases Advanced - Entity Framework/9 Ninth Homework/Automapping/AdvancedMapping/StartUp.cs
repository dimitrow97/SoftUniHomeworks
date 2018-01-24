using AdvancedMapping.DTOs;
using AutoMapper;
using System;

namespace AdvancedMapping
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Initializate();

            Employee employee = new Employee("Ivan", "Petrov", 200.00m);
            employee.AddManagerTo(employee);
            employee.AddEmployee(new Employee("Mitko", "Stoyanov", 100.00m));
            employee.AddEmployee(new Employee("Radko", "Kolev", 150.00m));

            ManagerDTO dto = Mapper.Map<ManagerDTO>(employee);
            
            Console.WriteLine($"{dto.FirstName} {dto.LastName} | Employees: {dto.ManagerOf.Count}");
            dto.ManagerOf.ForEach(emp => Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Salary} "));
        }

        public static void Initializate()
        {
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dto => dto.Salary, opt => opt.MapFrom(src => src.Salary));

                conf.CreateMap<Employee, ManagerDTO>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dto => dto.ManagerOf, opt => opt.MapFrom(src => src.ManagerOf));
            });

        }
    }
}
