namespace EmployeeData
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            double PersonalID = double.Parse(Console.ReadLine());
            int UniqueEmployeeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {secondName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {PersonalID}");
            Console.WriteLine($"Unique Employee number: {UniqueEmployeeNumber}");
        }
    }
    }
}
