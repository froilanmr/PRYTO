using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMI_TEST.Pruebas
{
    class Usuario
    {
        public Usuario() { }

        public bool Insertar(String nombre, String correo, String contrasenna, int telefono)
        {
            string query = "INSERT INTO usuario VALUES(@Nombre, @Correo, @Contrasenna, @Telefono, 0)";

            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Contrasenna", contrasenna);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);

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
