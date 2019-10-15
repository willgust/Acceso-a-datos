using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class apuestasRepository
    {
        private static readonly String DBUser = "root";
        private static readonly String DBPwd = "";
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=" + DBUser + ";password=" + DBPwd + ";database=placemybetarchivo2";

            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<apuestas> retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            apuestas d = null;
            List<apuestas> apuesta = new List<apuestas>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                d = new apuestas(res.GetInt32(0), res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5), res.GetInt32(6));
                apuesta.Add(d);
            }

            con.Close();
            return apuesta;
        }

        internal List<ApuestasDTO> retrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            ApuestasDTO d = null;
            List<ApuestasDTO> apuesta = new List<ApuestasDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                d = new ApuestasDTO(res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(6));
                apuesta.Add(d);
            }

            con.Close();
            return apuesta;
        }

        internal void save(apuestas d)
        {

          

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            //command.CommandText = "insert into apuestas(tipo,cuota,apostado,correo_usuario,esOver) values ('"+ d.tipo + "','" + d.cuota + "','" + d.apostado + "','" + d.correo_usuario + "','" + d.esOver + "');";
            command.CommandText = "insert into apuestas(tipo,cuota,apostado,correo_usuario,ID_mercados,esOver) values ('" + d.tipo + "','" + d.cuota + "','" + d.apostado + "','" + d.correo_usuario + "','" + d.ID_mercados + "','" + d.esOver + "');";
            Debug.WriteLine("command " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
            }
        }

        /*internal List<ApuestasDTO> cuotas()
        {
            int dineroOver = 0;
            int dineroUnder = 0;
            int probabilidadOver = 0;
            int probabilidadUnder = 0;
            List<ApuestasDTO> apuestas = new List<ApuestasDTO>();
            foreach (ApuestasDTO apuesta in apuestas)
            {
                if (apuesta.esOver == 1)
                {
                    dineroOver = dineroOver + Convert.ToInt32(apuesta.apostado);
                    probabilidadOver = dineroOver / (dineroOver + dineroUnder);
                }
                else
                {
                    dineroUnder = dineroUnder + Convert.ToInt32(apuesta.apostado);
                    probabilidadUnder = dineroUnder / (dineroOver + dineroUnder);
                }
            }
            decimal cuotaOver = Convert.ToDecimal((1 / probabilidadOver) * 0.95);
            decimal cuotaUnder = Convert.ToDecimal((1 / probabilidadUnder) * 0.95);
            decimal[] valores = { cuotaOver , cuotaUnder };
            return apuesta;

            /*int dineroOver = 0;
            int dineroUnder = 0;
            int probabilidadOver = 0;
            int probabilidadUnder = 0;
            if (d.esOver == 1)
            {
                dineroOver = dineroOver + Convert.ToInt32(d.apostado);
                probabilidadOver = dineroOver / (dineroOver + dineroUnder);
            }
            else
            {
                dineroUnder = dineroUnder + Convert.ToInt32(d.apostado);
                probabilidadUnder = dineroUnder / (dineroOver + dineroUnder);
            }

            Double cuotaOver = (1 / probabilidadOver) * 0.95;
            Double cuotaUnder = (1 / probabilidadUnder) * 0.95;
            Convert.ToInt32(cuotaOver);

            return cuotaOver;

        }*/


    }
}