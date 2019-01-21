using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMI_TEST.Pruebas
{
    class Actividad
    {
        public Actividad() { }

        public bool Insertar(String nombre, String tipo, String fecha, String direccion,
            String descripcion, String galeria, int cupos)
        {
            String fechaEntrada = DateTime.Today.ToString("yyyy/MM/dd");
            String horaEntrada = DateTime.Now.ToString("HH:mm:ss");
            try
            {
                /* Conexión e inserción a la base de datos*/
                NpgsqlConnection conectar = new NpgsqlConnection();
                conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                conectar.Open();
                NpgsqlCommand insertar = new NpgsqlCommand("insert into actividad values ('" + nombre + "', '" + fecha +
                    "', '" + tipo + "', '" + direccion + "', '" + descripcion + "', " +
                    cupos + ", '" + galeria + "', 0, '" + (fechaEntrada + " " + horaEntrada) + "')", conectar);
                insertar.ExecuteNonQuery();
                conectar.Close();

                return true;
            }
            catch (Exception ex) // Excepción en caso de datos duplicados
            {

            }
            return false;
        }

        public Boolean Leer()
        {
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM actividad ", conn);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read())
            {
                return true;
            }

            return false;
        }

        public Boolean Borrar(String nombre)
        {
            string query = "UPDATE actividad set isBorrado=1 WHERE nombre=@nombre";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            return false;
        }
    }
}
