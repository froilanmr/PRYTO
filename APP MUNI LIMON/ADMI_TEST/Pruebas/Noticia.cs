using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMI_TEST.Pruebas
{
    class Noticia
    {
        public Noticia() { }

        public bool Insertar(String titulo, String descripcion, String galeria, String fechaPublicacion)
        {
            String fechaEntrada = DateTime.Today.ToString("yyyy/MM/dd");
            String horaEntrada = DateTime.Now.ToString("HH:mm:ss");

            try
            {
                string query = "insert into noticia(titulo,descripcion,galeria, isBorrado, fechaEntrada, fechaPublica)" +
                    " values (@titulo, @descripcion, @galeria, 0, @fechaEntrada, @fechaPublica)";
                var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@galeria", galeria);
                        cmd.Parameters.AddWithValue("@fechaEntrada", fechaEntrada + " " + horaEntrada);
                        cmd.Parameters.AddWithValue("@fechaPublica", fechaPublicacion);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return true;
                    }
                }

            }
            catch (NpgsqlException ex) { }
            return false;
        }

        public Boolean Leer()
        {
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM noticia ", conn);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read())
            {
                return true;
            }

            return false;
        }

        public Boolean Borrar(String titulo)
        {
            string query = "UPDATE noticia set isBorrado=1 WHERE titulo=@titulo";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@titulo", titulo);
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
