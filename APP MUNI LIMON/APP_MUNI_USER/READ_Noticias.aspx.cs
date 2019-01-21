using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class READ_Noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            string query = "select titulo, descripcion,galeria from noticia where isBorrado=0";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();

                        conn.Close();
                    }
                }
            }

            /*
            ArrayList Lista = new ArrayList();
            string[] Archivos = System.IO.Directory.GetFiles(Server.MapPath("Images/Noticias"), "*");

            int cont = 0;
            foreach(string archivo in Archivos)
            {
                Lista.Add("/Images/Noticias/" + System.IO.Path.GetFileName(archivo));
            }

            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT titulo, descripcion FROM noticia ", conn);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read())
            {
                //Session["nombre"] = Convert.ToString(leer["nombre"]);
                conn.Close();
            }

            Repeater1.DataSource = Lista;
            Repeater1.DataBind();
            */
        }
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}