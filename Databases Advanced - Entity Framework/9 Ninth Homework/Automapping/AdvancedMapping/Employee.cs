using System;
using System.Collections.Generic;

namespace AdvancedMapping
{
    public class Employee
    {
        public Employee(string firstName, string lastName, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            BirthDay = new DateTime(1999, 10, 10);
            IsOnHoliday = true;
            Address = "123 Str";
            ManagerOf = new List<Employee>();
        }

        public void AddManagerTo(Employee employee)
        {
            employee.Manager = employee;
        }

        public void AddEmployee(Employee employee)
        {
            ManagerOf.Add(employee);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool IsOnHoliday { get; set; }
        public string Address { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> ManagerOf { get; set; }
    }
}
