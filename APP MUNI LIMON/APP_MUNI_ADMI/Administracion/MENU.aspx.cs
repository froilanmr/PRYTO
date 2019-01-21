using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_MENU : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOnline.Text = (string)Session["nombre"];
    }

    protected void panelNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUD_TipoActividad.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUD_Actividades.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUD_Noticias.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("READ_Sugerencias.aspx");
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("RD_Inscripciones.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Estadisticas.aspx");
    }
}