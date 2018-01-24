using AutoMapper;
using AutoMapper.QueryableExtensions;
using Projection.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            InitiateMapping();
            FeedDbWithRandomEmployees();
            PrintResults();

        }

        public static void PrintResults()
        {
            using (var context = new EmployeeContext())
            {

                foreach (var employee in context.Employees.Where(s => s.Salary > 20000.00m).ProjectTo<EmployeeDTO>().ToList())
                {
                    Console.WriteLine($"{employee.FirstName} {employee.Salary} – Manager: {employee.Manager}");
                }
            }
        }

        public static void FeedDbWithRandomEmployees()
        {
            for (int i = 0; i < 20; i++)
            {
                string firstName, lastName, address;
                decimal salary;
                GenerateRandomEmplyee(i, out firstName, out lastName, out address, out salary);
                Employee employee = new Employee()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Salary = salary,
                    Address = address
                };


                if (i % 3 == 1)
                {
                    string firstNameManager, lastNameManager, addressManager;
                    decimal salaryManager;
                    GenerateRandomEmplyee(i + 100, out firstNameManager, out lastNameManager, out addressManager, out salaryManager);
                    Employee manager = new Employee()
                    {
                        FirstName = firstNameManager,
                        LastName = lastNameManager,
                        Salary = salaryManager,
                        Address = addressManager
                    };
                    employee.Manager = manager;
                }
                AddEmployee(employee);
            }
        }

        public static void GenerateRandomEmplyee(int i, out string firstName, out string lastName, out string address, out decimal salary)
        {
            firstName = "John" + i;
            lastName = "Doe" + i;
            address = $"Str{123 + i}. Bl.{i + 3}";
            string randomSalary = DateTime.Now.Ticks.ToString().ToString();
            salary = decimal.Parse(randomSalary.Substring(randomSalary.Length - 6)) * (i + 33) % 100000;
        }

        public static void AddEmployee(Employee employee)
        {
            using (var context = new EmployeeContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();

            }
        }
        public static void InitiateMapping()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>()
            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dto => dto.Salary, opt => opt.MapFrom(src => src.Salary))
            .ForMember(dto => dto.Manager, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Manager.FirstName) ? "[no manager]" : src.Manager.FirstName)));
        }
    }
}