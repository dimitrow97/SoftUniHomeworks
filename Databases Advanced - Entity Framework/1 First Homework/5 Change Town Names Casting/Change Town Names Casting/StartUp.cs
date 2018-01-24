using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change_Town_Names_Casting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string countTownsInCountryQuery = File.ReadAllText("../../townsCount.sql");
            string upperCaseNamesQuery = File.ReadAllText("../../upperCaseNames.sql");

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            conn.Open();

            using (conn)
            {
                SqlCommand countTownsInCountry = new SqlCommand(countTownsInCountryQuery, conn);
                SqlParameter countTownsParam = new SqlParameter("@countryName", country);
                countTownsInCountry.Parameters.Add(countTownsParam);
                SqlDataReader countTowns = countTownsInCountry.ExecuteReader();
                if(countTowns.Read())
                {
                    int count = (int)countTowns["Count"];
                    if (count >= 1)
                    {
                        Console.WriteLine($"{count} town names were affected.");
                        countTowns.Close();
                        SqlCommand upperCaseNames = new SqlCommand(upperCaseNamesQuery, conn);
                        SqlParameter upperCaseParam = new SqlParameter("@countryName", country);
                        upperCaseNames.Parameters.Add(upperCaseParam);
                        SqlDataReader upperCasedNames = upperCaseNames.ExecuteReader();
                        Console.Write("[");                        
                        List<string> Towns = new List<string>();
                        while(upperCasedNames.Read())
                        {
                            string upperedName = (string)upperCasedNames["Town"];
                            if (count == 1)
                                Console.Write($"{upperedName}");
                            else
                            {
                                Towns.Add(upperedName);                               
                            }
                        }
                        if(count > 1)
                            Console.Write($"{string.Join(", ", Towns)}");
                        Console.Write("]");
                    }
                    else Console.WriteLine("No town names were affected.");
                }
            }
            conn.Close();
        }
    }
}
