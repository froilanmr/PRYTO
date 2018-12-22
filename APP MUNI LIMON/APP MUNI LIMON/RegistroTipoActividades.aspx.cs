using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroTipoActividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registrarTipoActividad_Click(object sender, EventArgs e)
    {
        /* Condicion para datos vacíos*/
        if(!nombreTipoActividad.Text.Equals("") || !descripcionTipoActividad.Text.Equals(""))
        {
            try
            {
                /* Conexión e inserción a la base de datos*/
                NpgsqlConnection conectar = new NpgsqlConnection();
                conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                conectar.Open();
                NpgsqlCommand insertar = new NpgsqlCommand("insert into tipoActividad values ('" + nombreTipoActividad.Text + "', '" + descripcionTipoActividad.Text + "')", conectar);
                insertar.ExecuteNonQuery();
                conectar.Close();

                MsgBox("¡Se registro el tipo de actividad!", Page, this);

                nombreTipoActividad.Text = "";
                descripcionTipoActividad.Text = "";
            }
            catch (Exception ex) // Excepción en caso de datos duplicados
            {
                MsgBox("¡El tipo de Actividad ya se encuentra registrado! Ingrese uno nuevo.", Page, this);
                nombreTipoActividad.Text = "";
                descripcionTipoActividad.Text = "";
            }
        }
        else
        {
            MsgBox("Es necesario rellenar todos los espacios.",Page,this);
        }
                
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
}