using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMI_TEST.Pruebas
{
    class Sugerencia
    {
        public Sugerencia() { }

        public bool Insertar(String correo, String tipoTramite, 
            String descripcion, int valoraciones, int Anonima, int telefono)
        {
            String fechaEntrada = DateTime.Today.ToString("yyyy/MM/dd");
            String horaEntrada = DateTime.Now.ToString("HH:mm:ss");

            try
            {
                /* Conexión e inserción a la base de datos*/
                NpgsqlConnection conectar = new NpgsqlConnection();
                conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                conectar.Open();
                NpgsqlCommand insertar = new NpgsqlCommand("insert into sugerencia(isAnonima,correo,telefono, tipoTramite," +
                    "valoracion,descripcion,isBorrado,fechaEntrada) values (" +
                    Anonima + ", '" + correo + "', " + telefono + ",'" +
                    tipoTramite + "', " + valoraciones+ ", '" +
                    descripcion+ "', 0, '" + (fechaEntrada + " " + horaEntrada) + "')", conectar);
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

            var cmd = new NpgsqlCommand("SELECT * FROM sugerencia ", conn);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read())
            {
                return true;
            }

            return false;
        }

        public Boolean Borrar(String nombre, String descripcion)
        {
            string query = "UPDATE sugerencia set isBorrado=1 WHERE correo=@Correo and descripcion=@Descripcion";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Correo", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
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
