﻿using System;
using MySql.Data.MySqlClient;

namespace Web_food.DAO
{
    public class DaoRegister
    {
        public bool doRegister(string account, string pwd, string mail)
        {
            DBConnection DbConnection = new DBConnection();
            MySqlConnection conn = DbConnection.ConnectionSql();
            conn.Open();
            string sql =
                "insert into user(user_account,user_password,user_mail,level) values (@user_account,@user_password,@user_mail,1)";
            // string sql = "INSERT into user VALUES (null,'"+account+"','"+pwd+"','"+mail+"',1)";
            MySqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = sql;


            sqlCommand.Parameters.AddWithValue("user_account", account);
            sqlCommand.Parameters.AddWithValue("user_password", pwd);
            sqlCommand.Parameters.AddWithValue("user_mail", mail);

            if (checkUserExist(account, mail))
                
            {
                Console.WriteLine("existed user");
                return false;
            }
            int x = sqlCommand.ExecuteNonQuery();
            if (x > 0)
            {
                return true;
            }
            return false;
        }

        public bool checkUserExist(string account, string email)
        {
            DBConnection DbConnection = new DBConnection();
            MySqlConnection conn = DbConnection.ConnectionSql();
            conn.Open();

            string sqlselect = "select user_account, user_mail from user";
            MySqlCommand sqlCommandselect = conn.CreateCommand();
            sqlCommandselect.CommandText = sqlselect;
            MySqlDataReader reader = sqlCommandselect.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (account == reader[0].ToString() && email == reader[1].ToString())
                    {
                        return  true;
                    }
                }
            }

            return false;
        }
    }
}