using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroNoticias : System.Web.UI.Page
{
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

    protected void registrarNoticia_Click(object sender, EventArgs e)
    {
        String listaIMGS = "";
        if(!tituloNoticia.Text.Equals("") || !descripcionNoticia.Text.Equals(""))
        {
            if (galeriaNoticia.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in galeriaNoticia.PostedFiles)
                {
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/Noticias/"), uploadedFile.FileName));
                    listaIMGS += "~/Images/Noticias/" + uploadedFile.FileName + ",";
                }
            }
            listaIMGS = listaIMGS.Remove(listaIMGS.Length - 1);
            try
            {
                /* Conexión e inserción a la base de datos*/
                NpgsqlConnection conectar = new NpgsqlConnection();
                conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                conectar.Open();
                NpgsqlCommand insertar = new NpgsqlCommand("insert into noticia(titulo,descripcion,galeria) values ('" + tituloNoticia.Text + "', '" + descripcionNoticia.Text +
                    "', '" + listaIMGS + "')", conectar);
                insertar.ExecuteNonQuery();
                conectar.Close();

                MsgBox("¡Se registró la noticia!", Page, this);

                tituloNoticia.Text = "";
                descripcionNoticia.Text = "";
            }
            catch (Exception ex) // Excepción en caso de datos duplicados
            {
                MsgBox("¡Noticia Duplicada! Verifique el título.", Page, this);

                tituloNoticia.Text = "";
                descripcionNoticia.Text = "";
            }
        }
        else
        {
            MsgBox("Debe de rellenar todos los campos.", Page, this);
        }
    }
}