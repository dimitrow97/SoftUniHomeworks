using SoftUni.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            // 17.Call a Stored Procedure
            #region SQL Procedure
            /*CREATE PROC FindProjectsByEmployeeName(@firstName VARCHAR(MAX), @lastName VARCHAR(MAX))
              AS 
              BEGIN
              SELECT p.* FROM Projects AS p
              INNER JOIN EmployeesProjects AS ep ON ep.ProjectID = p.ProjectID
              INNER JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
              WHERE e.FirstName = @firstName AND e.LastName = @lastName
              END*/
            #endregion            
            //string[] employeeNames = Console.ReadLine().Split(' ');
            //CallStoredProc(employeeNames);

            // 18.Employees Maximum Salary
            //EmployeesMaximumSalary();
        }

        public static void EmployeesMaximumSalary()
        {
            SoftUniContext context = new SoftUniContext();
            foreach (var d in context.Departments)
            {
                foreach (var s in context.Employees.Where(a => d.DepartmentID == a.DepartmentID && (a.Salary < 30000 || a.Salary > 70000)).OrderByDescending(a => a.Salary).Take(1))
                {
                    Console.WriteLine($"{d.Name} - {s.Salary}");
                }                
            }
        }

        public static void CallStoredProc(string[] employeeNames)
        {
            SoftUniContext context = new SoftUniContext();
            var projects = context.Database.SqlQuery<Project>($"EXEC dbo.FindProjectsByEmployeeName {employeeNames[0]}, {employeeNames[1]}");
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} - {project.Description}, {project.StartDate}");
            }
        }
    }
}
