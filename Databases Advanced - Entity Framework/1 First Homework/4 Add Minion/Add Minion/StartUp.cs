using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Minion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInput = Console.ReadLine().Split(' ').ToArray();
            string[] villianInput = Console.ReadLine().Split(' ').ToArray();

            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string minionTown = minionInput[3];
            string villianName = villianInput[1];

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            conn.Open();

            using (conn)
            {
                string searchTheTown = $"USE MinionsDB SELECT * FROM Towns WHERE Name = '{minionTown}'";
                SqlCommand searchTheTownCommand = new SqlCommand(searchTheTown, conn);
                SqlDataReader searchTheTownReader = searchTheTownCommand.ExecuteReader();

                int counter = 0;
                if (searchTheTownReader.Read())
                    counter = 1;
                else counter = 0;
                searchTheTownReader.Close();

                if (counter == 1)
                    counter = 0;
                else
                {
                    string addTown = $"USE MinionsDB INSERT INTO Towns (Name, CountryID) VALUES ('{minionTown}', {5})";
                    SqlCommand addTownCommand = new SqlCommand(addTown, conn);
                    addTownCommand.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                    counter = 0;
                }

                string searchTheVillian = $"USE MinionsDB SELECT * FROM Villains WHERE Name = '{villianName}'";
                SqlCommand searchTheVillianCommand = new SqlCommand(searchTheVillian, conn);
                SqlDataReader searchTheVillianReader = searchTheVillianCommand.ExecuteReader();

                while (searchTheVillianReader.Read())
                {
                    counter += 1;
                }
                searchTheVillianReader.Close();

                if (counter == 1)
                    counter = 0;
                else
                {
                    string addVillian = $"USE MinionsDB INSERT INTO Villains (Name, Evilness) VALUES ('{villianName}', 'evil')";
                    SqlCommand addVillianCommand = new SqlCommand(addVillian, conn);
                    addVillianCommand.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villianName} was added to the database."); counter = 0;
                }

                string selectTownID = $"USE MinionsDB SELECT ID FROM Towns WHERE Name = '{minionTown}'";
                SqlCommand selectTownIDCommand = new SqlCommand(selectTownID, conn);
                int TownID = 0;
                int VillianID = 0;
                int MinionID = 0;
                SqlDataReader selectTownIDReader = selectTownIDCommand.ExecuteReader();

                while (selectTownIDReader.Read())
                {
                    TownID = (int)selectTownIDReader[0];
                }
                selectTownIDReader.Close();

                string selectVillianID = $"USE MinionsDB SELECT ID FROM Villains WHERE Name = '{villianName}'";
                SqlCommand selectVillianIDCommand = new SqlCommand(selectVillianID, conn);
                SqlDataReader selectVillianIDReader = selectVillianIDCommand.ExecuteReader();

                while (selectVillianIDReader.Read())
                {
                    VillianID = (int)selectVillianIDReader[0];
                }
                selectVillianIDReader.Close();

                string addMinion = $"USE MinionsDB INSERT INTO Minions(Name, TownID, Age) VALUES ('{minionName}', {TownID}, {minionAge})";
                SqlCommand addMinionCommand = new SqlCommand(addMinion, conn);
                addMinionCommand.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}");

                string selectMinionID = $"USE MinionsDB SELECT ID FROM Minions WHERE Name = '{minionName}'";
                SqlCommand selectMinionIDCommand = new SqlCommand(selectMinionID, conn);
                SqlDataReader selectMinionIDReader = selectMinionIDCommand.ExecuteReader();

                while (selectMinionIDReader.Read())
                {
                    MinionID = (int)selectMinionIDReader[0];
                }
                selectMinionIDReader.Close();

                string addMinionVillian = $"USE MinionsDB INSERT INTO MinionsVillains (MinionId, VillainId) VALUES ({MinionID},{VillianID})";
                SqlCommand addMinionVillianCommand = new SqlCommand(addMinionVillian, conn);
                addMinionVillianCommand.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
