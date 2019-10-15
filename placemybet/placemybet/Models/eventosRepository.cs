﻿using MySql.Data.MySqlClient;
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
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo2";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<eventos> retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            eventos d = null;
            List<eventos> evento = new List<eventos>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetString(3));
                d = new eventos(res.GetInt32(0), res.GetDateTime(1), res.GetString(2), res.GetString(3));
                evento.Add(d);
            }

            con.Close();
            return evento;
        }

        internal List<EventosDTO> retrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            EventosDTO d = null;
            List<EventosDTO> evento = new List<EventosDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetString(3));
                d = new EventosDTO(res.GetString(2), res.GetString(3));
                evento.Add(d);
            }

            con.Close();
            return evento;
        }

    }
}