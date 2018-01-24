using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Setup
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true");
            string createMinionsDBQuery = "CREATE DATABASE MinionsDB";
            string createTablesQuery = File.ReadAllText(@"..\..\initialSetup.sql");

            SqlCommand createDB = new SqlCommand(createMinionsDBQuery, conn);
            SqlCommand createTables = new SqlCommand(createTablesQuery, conn);

            conn.Open();
            using (conn)
            {
                createDB.ExecuteNonQuery();
                createTables.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
