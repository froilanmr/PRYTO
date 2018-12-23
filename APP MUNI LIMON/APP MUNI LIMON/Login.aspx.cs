using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
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
                if (txtContraseña.Text == "" || correoUsuario.Text == "")
                {
                    Response.Write("<script>window.alert('Ingrese usuario y contraseña.');</script>");
                }
                else
                {
                    var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                    var conn = new NpgsqlConnection(connString);
                    conn.Open();

                    var cmd = new NpgsqlCommand("SELECT * FROM usuario where usuario = '" + correoUsuario.Text + "' and contrasena = '" + txtContraseña.Text + "'", conn);
                    NpgsqlDataReader leer = cmd.ExecuteReader();

                    if (leer.Read())
                    {
                        if (Convert.ToString(leer["tipousuario"]) == "1")
                        {
                            if (Convert.ToString(leer["habilitado"]) == "1")
                            {
                                Response.Redirect("frmMenuAdmin.aspx");
                            }
                        }
                        else if (Convert.ToString(leer["tipousuario"]) == "2")
                        {
                            if (Convert.ToString(leer["habilitado"]) == "1")
                            {
                                Response.Redirect("frmMenuRecepcion.aspx");
                            }
                        }
                        else if (Convert.ToString(leer["tipousuario"]) == "3")
                        {
                            Response.Redirect("frmcliente.aspx");
                        }
                        else
                        {
                            Response.Write("<script>window.alert('Este usuario no posee ningún perfil.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Este usuario no se encuentra registrado.');</script>");
                    }
                    conn.Close();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>window.alert('El usuario y/o contraseña son incorrectos.');</script>");
            txtContraseña.Text = "";
        }
    }
}