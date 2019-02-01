using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace examen.Models
{
    public class Recetasrepository
    {
        // Método de conexión:
        private MySql.Data.MySqlClient.MySqlConnection Connect()
        {
            // String con los datos del servidor:
            string con = "Server=34.220.190.143;Database=cocina;Uid=examen;Password=examen;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(con);

            return conn;
        }

        // Recuperación de datos por id:
        internal Receta RetrieveId(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection c = Connect();
            MySql.Data.MySqlClient.MySqlCommand cmd = c.CreateCommand();

            // Consulta con los parámetros correspondientes pasados:
            cmd.CommandText = " select * from recetas where id = @A";
            cmd.Parameters.AddWithValue("@A", id);

            c.Open();
            MySql.Data.MySqlClient.MySqlDataReader res = cmd.ExecuteReader();

            Receta r = null;
            // Lee la receta y coge sus datos:
            if (res.Read())
            {
                r = new Receta(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
            }

            c.Close();
            return r;
        }

        // Devuelve la lista entera:
        internal List<Receta> Retrieve()
        {
            // Conexión a sql y consulta:
            MySql.Data.MySqlClient.MySqlConnection conexion = Connect();
            MySql.Data.MySqlClient.MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandText = " select * from recetas";

            try
            {
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataReader res = cmd.ExecuteReader();

                // Creamos objeto mercado y lista:
                Receta receta = null;
                List<Receta> recetas = new List<Receta>();

                while (res.Read())
                {
                    // Introducimos los datos y añadimos a la lista todo:
                    receta = new Receta(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    recetas.Add(receta);
                }

                // Cerramos la conexión a la bd:
                conexion.Close();
                return recetas;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }

        }

    }
}