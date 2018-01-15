namespace AppendLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|').ToList();
            input.Reverse();
            var result = new List<string>();
            foreach (var item in input)
            {
                var nums = item.Split(' ').ToList();
                foreach (var num in nums)
                {
                    if (num != "") result.Add(num);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
