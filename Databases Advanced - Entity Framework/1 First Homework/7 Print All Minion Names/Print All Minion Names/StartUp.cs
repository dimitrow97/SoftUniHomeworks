using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_All_Minion_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string minionNamesQuery = @"USE MinionsDB SELECT LOWER(Name) AS Name FROM Minions";
            List<string> Names = new List<string>();

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            conn.Open();

            using (conn)
            {
                SqlCommand minionNames = new SqlCommand(minionNamesQuery, conn);
                SqlDataReader nameReader = minionNames.ExecuteReader();
                
                while(nameReader.Read())
                {
                    Names.Add((string)nameReader["Name"]);
                }

                for(int i = 0; i <= (Names.Count / 2); i++)
                {                              
                    if((Names.Count % 2 != 0) && (i == (Names.Count / 2)))
                        Console.WriteLine(Names[i]);
                    else
                    {
                        Console.WriteLine(Names[i]);
                        Console.WriteLine(Names[(Names.Count - 1) - i]);
                    }
                }
            }
            conn.Close();
        }
    }
}
