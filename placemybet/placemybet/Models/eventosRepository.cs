using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class eventosRepository
    {
        private static readonly String DBUser = "root";
        private static readonly String DBPwd = "";
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal eventos retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            eventos d = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetDateTime(2) + " " + res.GetString(3) + " " + res.GetString(3));
                d = new eventos(res.GetInt32(0), res.GetDateTime(1), res.GetDateTime(2), res.GetString(3), res.GetString(4));
            }

            con.Close();
            return d;
        }
    }
}