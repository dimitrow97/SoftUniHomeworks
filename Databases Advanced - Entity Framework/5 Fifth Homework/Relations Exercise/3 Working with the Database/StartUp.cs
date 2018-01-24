using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Working_with_the_Database
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();
            var func = int.Parse(Console.ReadLine());
            Console.WriteLine("Write a number from 0 to 5. Each number from 1 to represents a task from problem 3.");
            Console.WriteLine("If this is the FIRST TIME you execute the program, PLEASE USE OPTION 0 TO CREATE AND FILL THE DATABASE!");

            if(func == 1)
            {
                var students = context.Students.ToList();
                var homeworks = context.Homeworks.ToList();
                foreach(var s in students)
                {
                    Console.WriteLine($"Student Name: {s.Name}");                    
                    foreach(var h in homeworks)
                    {
                        if(h.Student.Id == s.Id)
                        Console.WriteLine($" Homework: {h.Content}.{h.ContextsType}");
                    }
                    Console.WriteLine("-------------------------");
                }
            }

            if(func == 2)
            {
                var courses = context.Courses.OrderBy(e => e.StartDate).ThenByDescending(e => e.EndDate).ToList();
                var resources = context.Resources.ToList();

                foreach(var c in courses)
                {
                    Console.WriteLine($"Course: {c.Name} Description: {c.Description}");
                    foreach(var r in resources)
                    {
                        if (c.Id == r.Course.Id)
                            Console.WriteLine($"Resource: {r.Name}.{r.ResourcesType} URL: {r.URL}");
                    }
                    Console.WriteLine("-------------------------");
                }
            }

            if(func == 3)
            {                
                var courses = context.Courses.Where(e => e.Resources.Count() > 5).OrderByDescending(e => e.Resources.Count()).ThenByDescending(e => e.StartDate).ToList();
                foreach (var c in courses)
                {
                    Console.WriteLine($"Course: {c.Name}");
                    Console.WriteLine($"Resource Count: {c.Resources.Count()}");                    
                    Console.WriteLine("-------------------------");
                }
            }

            if(func == 4)
            {
                Console.WriteLine("Write the date in format yyyy/mm/dd: ");
                int[] dateParams = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
                DateTime date = new DateTime(dateParams[0], dateParams[1], dateParams[2]);
                var course = context.Courses.Where(e => e.StartDate < date && e.EndDate > date).OrderByDescending(e => e.Students.Count()).ThenByDescending(e => DbFunctions.DiffDays(e.EndDate,e.StartDate)).ToList();
                foreach(var c in course)
                {
                    Console.WriteLine($"Course name: {c.Name}");
                    Console.WriteLine($"Course StartDate: {c.StartDate} and Course EndDate: {c.EndDate}");
                    Console.WriteLine($"Course duration: {c.EndDate.Date.Subtract(c.StartDate).Days}");
                    Console.WriteLine($"Number of students enrolled: {c.Students.Count()}");
                    Console.WriteLine("-------------------------");
                }
            }

            if(func == 5)
            {
                var student = context.Students.OrderByDescending(x => x.Courses.Sum(z => z.Price)).ThenByDescending(x => x.Courses.Count()).ThenBy(x => x.Name).ToList();
                       
                foreach(var s in student)
                {                    
                    Console.WriteLine($"Student name: {s.Name}");
                    Console.WriteLine($"Number of courses enrolled: {s.Courses.Count()}");                                      
                    Console.WriteLine($"Total price: {s.Courses.Sum(z => z.Price)}");
                    Console.WriteLine($"Average price: {s.Courses.Average(z => z.Price)}");
                    Console.WriteLine("-------------------------");
                }
            }

            if(func == 0)
            {                
                context.Database.Initialize(force: true);
                context.SaveChanges();

                string backUpQuery = File.ReadAllText(@"../../backUp.sql");

                SqlConnection conn = new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB; Integrated Security=true;");
                conn.Open();
                SqlCommand backUp = new SqlCommand(backUpQuery, conn);
                using (conn)
                {
                    backUp.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
