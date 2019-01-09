using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsPostBack == true)
            {
                if (nombre.Text.Equals("") || correo.Text.Equals("") || telefono.Text.Equals("") || contraseña.Text.Equals(""))
                {
                    Response.Write("<script>window.alert('Debe de rellenar todos los campos.');</script>");
                }
                else
                {
                    string query = "INSERT INTO usuario VALUES(@Nombre, @Correo, @Contrasenna, @Telefono, 0)";

                    var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

                    using (NpgsqlConnection con = new NpgsqlConnection(connString))
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", nombre.Text);
                            cmd.Parameters.AddWithValue("@Correo", correo.Text);
                            cmd.Parameters.AddWithValue("@Contrasenna", contraseña.Text);
                            cmd.Parameters.AddWithValue("@Telefono", Int32.Parse(telefono.Text));

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    Response.Write("<script>window.alert('Se registró correctamente.');</script>");
                    Session["usuario"] = correo.Text;
                    Session["contra"] = contraseña.Text;
                    Response.Redirect("MENU.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>window.alert('Error en el registro, verifique los datos.');</script>");
        }
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}