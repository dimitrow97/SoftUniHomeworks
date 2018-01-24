using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_Full_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftuniContext context = new SoftuniContext();

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us"); // DataTime format

            var employees = context.Employees
            .Where(c => c.Projects.Any(t => t.StartDate.Year > 2000 && t.StartDate.Year < 2004))
            .Take(30);
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} {p.StartDate} {p.EndDate}");
                }
            }
        }        
    }
}
