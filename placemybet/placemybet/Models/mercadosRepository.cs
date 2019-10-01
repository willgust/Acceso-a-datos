using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class mercadosRepository
    {
        private static readonly String DBUser = "root";
        private static readonly String DBPwd = "";
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal mercados retrieve()
            {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            mercados d = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetDecimal(4) + " " + res.GetDecimal(5));
                d = new mercados(res.GetInt32(0), res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetDecimal(4), res.GetDecimal(5));
            }

            con.Close();
            return d;
        }
        
    }
}