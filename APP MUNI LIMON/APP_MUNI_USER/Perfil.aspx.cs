using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.CargaDatos();
            contrasenna.Attributes["type"] = "password";
        }
    }

    protected void CargaDatos()
    {
        string usuario = (string)Session["usuario"];
        string contra = (string)Session["contra"];
        NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
        conx.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM usuario where correo='" + usuario+ "' and contrasenna='"+ contra+"'" , conx);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        if (leer.Read())
        {
            nombre.Text = Convert.ToString(leer["nombre"]);
            correo.Text = Convert.ToString(leer["correo"]);
            contrasenna.Text = Convert.ToString(leer["contrasenna"]);
            telefono.Text = Convert.ToString(leer["telefono"]);
        }
        leer.Close();
        conx.Close();
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if(MessageBox.Show("¿Desea eliminar su Perfil?" ,"Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            string query = "UPDATE usuario set isBorrado=1 WHERE nombre=@nombre";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@nombre", correo.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            MsgBox("Se eliminó el Perfil.", Page, this);
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string Nombre = nombre.Text;
        string Correo = correo.Text;
        string Contraseña = contrasenna.Text;
        int Telefono = Int32.Parse(telefono.Text);
        string CorreoActual = (string)Session["usuario"];

        if (!Nombre.Equals("") || !Correo.Equals("") || !Contraseña.Equals("") || !Telefono.Equals(""))
        {
            try
            {
                string query = "UPDATE usuario SET nombre=@Nombre, correo=@Correo, contrasenna=@Contraseña," +
            "telefono=@Telefono WHERE correo=@CorreoActual";
                var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                        cmd.Parameters.AddWithValue("@Telefono", Telefono);
                        cmd.Parameters.AddWithValue("@CorreoActual", Correo);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MsgBox("¡Se ha actualizado la información del Perfíl!", Page, this);
                Session["usuario"] = Correo;
                Session["contra"] = Contraseña;
                Session["nombre"] = Nombre;
            }
            catch (NpgsqlException ex)
            {
                MsgBox("Error en la Actualización del Perfil, verifique los datos.", Page, this);
            }
        }
        else
        {
            MsgBox("Rellene todos los espacios por favor.", Page, this);
            Response.Redirect("Perfil.apsx");
        }
    }
}