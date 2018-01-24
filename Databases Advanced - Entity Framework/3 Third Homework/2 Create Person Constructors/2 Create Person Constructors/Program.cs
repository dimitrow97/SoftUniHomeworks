using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Create_Person_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Person person = new Person();

            try
            {
                if (input != null)
                {
                    string[] tokens = input.Split(',');
                    switch (tokens.Length)
                    {
                        case 1:
                            int age;
                            person = int.TryParse(tokens[0], out age) ? new Person(age) : new Person(tokens[0]);
                            break;
                        case 2:
                            person = new Person(tokens[0], int.Parse(tokens[1]));
                            break;
                    }
                }
            }
            catch
            {
                person = new Person();
            }
           
            Console.WriteLine($"{person.Name} {person.Age}");

           
        }
    }
}
