﻿using Npgsql;
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
        Session["usuario"] = "";
        Session["contra"] = "";
        Session["nombre"] = "";
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsPostBack == true)
            {
                if (txtContraseña.Text.Equals("") || correoUsuario.Text.Equals(""))
                {
                    Response.Write("<script>window.alert('Ingrese usuario y contraseña.');</script>");
                }
                else
                {
                    var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                    var conn = new NpgsqlConnection(connString);
                    conn.Open();

                    var cmd = new NpgsqlCommand("SELECT * FROM usuarioADMI where correo = '" + correoUsuario.Text + "' and contrasenna = '" + txtContraseña.Text + "'", conn);
                    NpgsqlDataReader leer = cmd.ExecuteReader();

                    if (leer.Read())
                    {
                        Session["usuario"] = correoUsuario.Text;
                        Session["contra"] = txtContraseña.Text;
                        Session["nombre"] = Convert.ToString(leer["nombre"]);
                        conn.Close();
                        Response.Redirect("Administracion/MENU.aspx");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Este usuario no se encuentra registrado.');</script>");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>window.alert('El usuario y/o contraseña son incorrectos.'" + ex + ");</script>");
            txtContraseña.Text = "";
        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignIn.aspx");
    }
}