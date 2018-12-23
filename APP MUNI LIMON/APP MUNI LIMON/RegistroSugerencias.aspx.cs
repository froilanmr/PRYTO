using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroSugerencias : System.Web.UI.Page
{
    int Anonima = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /**
     * Función que envía mensaje al usuario sobre la operación a realizar 
     * 
    */
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void registrarSugerencia_Click(object sender, EventArgs e)
    {
        if(!telefono.Text.Equals("") || !correo.Text.Equals("") || !descripcion.Text.Equals(""))
        {
            if (!valoraciones.SelectedItem.Value.Equals(""))
            {
                try
                {
                    /* Conexión e inserción a la base de datos*/
                    NpgsqlConnection conectar = new NpgsqlConnection();
                    conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                    conectar.Open();
                    NpgsqlCommand insertar = new NpgsqlCommand("insert into sugerencia(isAnonima,correo,telefono, tipoTramite,valoracion,descripcion) values (" + 
                        Anonima + ", '" + correo.Text + "', "+ Int32.Parse(telefono.Text) + ",'"+ tipoTramite.SelectedItem.Value + "', " + (valoraciones.SelectedIndex + 1) +
                        ", '" + descripcion.Text + "')", conectar);
                    insertar.ExecuteNonQuery();
                    conectar.Close();

                    MsgBox("¡Se registró la sugerencia!", Page, this);

                    telefono.Text = "";
                    correo.Text = "";
                    descripcion.Text = "";
                    valoraciones.ClearSelection();
                    isAnonima.Checked = false;
                }
                catch (Exception ex) // Excepción en caso de datos duplicados
                {
                    MsgBox("Eror en la sugerencia.", Page, this);

                    telefono.Text = "";
                    correo.Text = "";
                    descripcion.Text = "";
                    valoraciones.ClearSelection();
                    isAnonima.Checked = false;
                }
            }
            else
            {
                MsgBox("Seleccione una valoración de 1 a 5 Estrellas", Page, this);
            }
        }
        else
        {
            MsgBox("No deben de haber campos vacíos.", Page, this);
        }
    }
    protected void anonimato(object sender, EventArgs e)
    {
        if (isAnonima.Checked)
        {
            Anonima = 1;
            telefono.Enabled = false;
            correo.Enabled = false;
        }
        else
        {
            Anonima = 0;
            telefono.Enabled = true;
            correo.Enabled = true;
        }
    }
}