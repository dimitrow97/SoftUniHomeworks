using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Minion_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            string villainNameQuery = File.ReadAllText("../../villainNme.sql");
            string villainsMinionsQuery = File.ReadAllText("../../villainsMinions.sql");
            conn.Open();
            
            using (conn)
            {
                int villId = int.Parse(Console.ReadLine());
                SqlCommand findVillainName = new SqlCommand(villainNameQuery, conn);
                SqlParameter villainIdParam = new SqlParameter("@villainId", villId);
                findVillainName.Parameters.Add(villainIdParam);
                SqlDataReader reader = findVillainName.ExecuteReader();

                if (reader.Read())
                {
                    string villName = (string)reader["Name"];
                    Console.WriteLine($"Villain: {villName}");
                    reader.Close();

                    SqlCommand findVillainsMinions = new SqlCommand(villainsMinionsQuery, conn);
                    SqlParameter villainIdParameter = new SqlParameter("@villainsId", villId);
                    findVillainsMinions.Parameters.Add(villainIdParameter);
                    SqlDataReader newReader = findVillainsMinions.ExecuteReader();

                    int index = 1;
                    while (newReader.Read())
                    {
                        string minionName = (string)newReader["Name"];
                        int minionAge = (int)newReader["Age"];
                        Console.WriteLine($"{index}. {minionName} {minionAge}");
                        index++;
                    }
                }
                else Console.WriteLine($"No villain with ID {villId} exists in the database.");
            }
            conn.Close();
        }
    }
}
