using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Oldest_Family_Member
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Person member = new Person(input[0], Int32.Parse(input[1]));
                family.AddMember(member);
            }

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
