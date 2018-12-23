using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroActividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /**
         * Sección de Codigo donde carga la lista de actividades disponibles 
         * 
        **/
        NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
        conx.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM tipoActividad", conx);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        while (leer.Read())
        {
            tipoActividades.Items.Add(Convert.ToString(leer["nombre"]));
        }
        leer.Close();
        conx.Close();

        tipoActividades.Items.Insert(0, new ListItem("<Seleccione un tipo de Actividad>", "0"));

    }
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void registrarNoticia_Click(object sender, EventArgs e)
    {
        String listaIMGS = "";
        if (!nombreActividad.Text.Equals("") || !fechaActividad.Text.Equals("") || !direccionActividad.Text.Equals("")
            || !descripcionActividad.Text.Equals("") || !cuposActividad.Text.Equals(""))
        {
            if (galeriaActividades.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in galeriaActividades.PostedFiles)
                {
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/Actividades/"), uploadedFile.FileName));
                    listaIMGS += "~/Images/Actividades/" + uploadedFile.FileName + ",";
                }
            }
            listaIMGS = listaIMGS.Remove(listaIMGS.Length - 1);
            try
            {
                /* Conexión e inserción a la base de datos*/
                NpgsqlConnection conectar = new NpgsqlConnection();
                conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                conectar.Open();
                NpgsqlCommand insertar = new NpgsqlCommand("insert into actividad values ('" + nombreActividad.Text + "', '" + fechaActividad.Text +
                    "', '" + tipoActividades.Text + "', '"+ direccionActividad.Text + "', '"+ descripcionActividad.Text + "', " +
                    Int32.Parse(cuposActividad.Text) + ", '" + listaIMGS +"')", conectar);
                insertar.ExecuteNonQuery();
                conectar.Close();

                MsgBox("¡Se registró la actividad!", Page, this);

                nombreActividad.Text = "";
                fechaActividad.Text = "";
                direccionActividad.Text = "";
                descripcionActividad.Text = "";
                cuposActividad.Text = "";
            }
            catch (Exception ex) // Excepción en caso de datos duplicados
            {
                MsgBox("¡Actividad Duplicada! Cambie el nombre de la actividad.", Page, this);

                nombreActividad.Text = "";
                fechaActividad.Text = "";
                direccionActividad.Text = "";
                descripcionActividad.Text = "";
                cuposActividad.Text = "";
            }
        }
        else
        {
            MsgBox("Debe de rellenar todos los campos.", Page, this);
        }
    }
}