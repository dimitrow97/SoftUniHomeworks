using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IncreaseMinionsAge
{
    class StartUp
    {
        static void Main(string[] args)
        {            
            List<int> minionIds = Console.ReadLine().Split().Select(int.Parse).ToList();

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");
            conn.Open();

            using (conn)
            {
                string increaseMinionsAgeQuery = $@"UPDATE Minions
                                      SET Age = Age + 1, Name = LOWER(Name)
                                      WHERE Id IN ({string.Join(", ", minionIds)})";

                SqlCommand increaseMinionsAge = new SqlCommand(increaseMinionsAgeQuery, conn);
                increaseMinionsAge.ExecuteNonQuery();

                string affectedMinionsQuery = $@"SELECT m.Name, m.Age FROM Minions AS m WHERE m.Id IN ({string.Join(", ", minionIds)})";
                SqlCommand affectedMinions = new SqlCommand(affectedMinionsQuery, conn);
                SqlDataReader affectedMinionsReader = affectedMinions.ExecuteReader();

                while (affectedMinionsReader.Read())
                {
                    Console.WriteLine($"{affectedMinionsReader[0]} {affectedMinionsReader[1]}");
                }
                affectedMinionsReader.Close();
            }
            conn.Close();
        }
    }
}