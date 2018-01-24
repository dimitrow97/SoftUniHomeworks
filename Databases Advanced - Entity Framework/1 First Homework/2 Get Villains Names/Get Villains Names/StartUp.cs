using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Villains_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string getVillainsNameQuery = File.ReadAllText("../../getVillainsName.sql");

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            conn.Open();

            SqlCommand getVillainsName = new SqlCommand(getVillainsNameQuery, conn);           
            using (conn)
            {
                SqlDataReader reader = getVillainsName.ExecuteReader();
                while (reader.Read())
                {
                    string VillainName = (string)reader["Name"];
                    int MinionsCount = (int)reader["MinionsCount"];
                    Console.WriteLine($"{VillainName} {MinionsCount}");
                }
            }
            conn.Close();
        }
    }
}
