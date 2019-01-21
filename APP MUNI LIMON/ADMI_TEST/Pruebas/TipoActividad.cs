using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TipoActividad
/// </summary>
public class TipoActividad
{
    public TipoActividad()
    {

    }

    public bool Insertar(String nombre, String descripcion)
    {
        String fechaEntrada = DateTime.Today.ToString("yyyy/MM/dd");
        String horaEntrada = DateTime.Now.ToString("HH:mm:ss");

        if (!nombre.Equals("") || !descripcion.Equals(""))
        {
            try
            {
                string query = "INSERT INTO tipoActividad VALUES(@Nombre, @Descripcion, 0, @FechaEntrada)";

                var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@FechaEntrada", fechaEntrada + " " + horaEntrada);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                }
            }
            catch (NpgsqlException ex)
            {

            }
        }
        return false;
    }

    public Boolean Leer()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        var conn = new NpgsqlConnection(connString);
        conn.Open();

        var cmd = new NpgsqlCommand("SELECT * FROM tipoActividad ", conn);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        if (leer.Read())
        {
            return true;
        }

        return false;
    }

    public Boolean Borrar(String nombre)
    {
        string query = "UPDATE tipoActividad set isBorrado=1 WHERE nombre=@nombre";
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