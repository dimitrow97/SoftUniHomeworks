using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Villain
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            List<int> minionsIds = new List<int>();
            string villainsName;
            string findMinionsQuery = File.ReadAllText("../../findMinions.sql");
            string findVillainNameQuery = File.ReadAllText("../../findVillainName.sql");
            string delFromMVQuery = File.ReadAllText("../../delFromMV.sql");
            string delFromVQuery = File.ReadAllText("../../delFromV.sql");
            string delFromMinionsQuery = File.ReadAllText("../../delFromM.sql");

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            conn.Open();

            using (conn)
            {
                SqlCommand findMinionsIds = new SqlCommand(findMinionsQuery, conn);
                SqlParameter findMinionsParam = new SqlParameter("@villainId", villainId);
                findMinionsIds.Parameters.Add(findMinionsParam);
                SqlDataReader findMinionsReader = findMinionsIds.ExecuteReader();

                while(findMinionsReader.Read())
                {
                    minionsIds.Add((int)findMinionsReader["MinionId"]);
                }
                findMinionsReader.Close();

                SqlCommand findVillainName = new SqlCommand(findVillainNameQuery, conn);
                SqlParameter findVillainNameParam = new SqlParameter("@villainId", villainId);
                findVillainName.Parameters.Add(findVillainNameParam);
                SqlDataReader findVillainNameReader = findVillainName.ExecuteReader();

                if (findVillainNameReader.Read())
                {
                    villainsName = (string)findVillainNameReader["Name"];
                }
                else
                {
                    Console.WriteLine("No such villain was found");
                    return;
                }

                findVillainNameReader.Close();

                SqlCommand delFromMinionsVillains = new SqlCommand(delFromMVQuery, conn);
                SqlParameter delFromMvParam = new SqlParameter("@villainId", villainId);
                delFromMinionsVillains.Parameters.Add(delFromMvParam);
                delFromMinionsVillains.ExecuteNonQuery();

                SqlCommand delFromVillains = new SqlCommand(delFromVQuery, conn);
                SqlParameter delFromVParam = new SqlParameter("@villainId", villainId);
                delFromVillains.Parameters.Add(delFromVParam);
                delFromVillains.ExecuteNonQuery();

                SqlCommand delFromMinions = new SqlCommand(delFromMinionsQuery, conn);                
                for (int i = 0; i < minionsIds.Count; i++)
                {                    
                    SqlParameter delFromMinParam = new SqlParameter("@minionId", minionsIds[i]);
                    delFromMinions.Parameters.Add(delFromMinParam);
                    delFromMinions.ExecuteNonQuery();
                    delFromMinions.Parameters.Clear();
                }
                Console.WriteLine($"{villainsName} was deleted");
                Console.WriteLine($"{minionsIds.Count} minions released");                
            }
            conn.Close();
        }
    }
}
