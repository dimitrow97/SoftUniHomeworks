using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Local_Store_Improvement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ProductsContext context = new ProductsContext();
            context.Database.Initialize(force: true);
            context.SaveChanges();

            string backUpQuery = File.ReadAllText(@"../../backUp.sql");

            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Integrated Security=true;");
            conn.Open();
            SqlCommand backUp = new SqlCommand(backUpQuery, conn);
            using (conn)
            {
                backUp.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
