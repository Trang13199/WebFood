using System;
using MySql.Data.MySqlClient;

namespace Web_food.DAO
{
    public class DBConnection
    {
        private static String str_mySQL = "Server=localhost;Port=3306;Database=dbwebfood;Uid=root;pwd=;";

        public MySqlConnection ConnectionSql()
        {
            MySqlConnection conn = new MySqlConnection(str_mySQL);
            try
            {
                conn.Open();
                // Console.WriteLine("success");
                return conn;
            }
            finally
            {
                conn.Close();
            }
        }

        // public static void Main(string[] args)
        // {
        //     Console.WriteLine("Getting Connection ...");
        //    
        // }
    }
}