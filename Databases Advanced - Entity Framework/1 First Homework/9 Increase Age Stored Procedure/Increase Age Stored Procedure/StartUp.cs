using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Increase_Age_Stored_Procedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int minionsId = int.Parse(Console.ReadLine());
            string increaseAgeByUSPQuery = $@"USE MinionsDB EXEC usp_GetOlder {minionsId}";
            string affectedMinionQuery = $@"USE MinionsDB SELECT Name, Age FROM Minions WHERE Id = {minionsId}";
            string getOlderUSPQuery = File.ReadAllText(@"../../getOlderUSP.sql");

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS; Database=MinionsDB; Integrated Security=true");
            conn.Open();

            using (conn)
            {
                try
                {                    
                    SqlCommand increaseAgeByUSP = new SqlCommand(increaseAgeByUSPQuery, conn);
                    increaseAgeByUSP.ExecuteNonQuery();
                }
                catch
                {
                    SqlCommand getOlderUSP = new SqlCommand(getOlderUSPQuery, conn);
                    getOlderUSP.ExecuteNonQuery();
                    SqlCommand increaseAgeByUSP = new SqlCommand(increaseAgeByUSPQuery, conn);
                    increaseAgeByUSP.ExecuteNonQuery();
                }

                SqlCommand affectedMinion = new SqlCommand(affectedMinionQuery, conn);
                SqlDataReader showAffectedMinion = affectedMinion.ExecuteReader();
                if (showAffectedMinion.Read())
                    Console.WriteLine($"{showAffectedMinion["Name"]} {showAffectedMinion["Age"]}");
            }
            conn.Close();
        }
    }
}
