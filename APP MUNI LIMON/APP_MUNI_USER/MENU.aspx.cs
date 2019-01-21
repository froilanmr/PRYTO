using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MENU : System.Web.UI.Page
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
        Response.Redirect("Actividades.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("READ_Noticias.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUD_Sugerencias.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("RD_Inscripciones.aspx");
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}