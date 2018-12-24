using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuTipoActividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Popular la tabla
        DataTable dt = new DataTable();
        dt.Columns.Add("Modulo", typeof(string));
        dt.Columns.Add("Registro", typeof(ButtonColumn));
        dt.Columns.Add("Actualizacion", typeof(ButtonField));
        dt.Columns.Add("Consulta", typeof(ButtonField));
        dt.Columns.Add("Borrado", typeof(ButtonField));

        DataRow filaNueva = dt.NewRow();
        filaNueva["Modulo"] = "Tipos de Actividades";
        dt.Rows.Add(filaNueva);

        filaNueva = dt.NewRow();
        filaNueva["Modulo"] = "Actividades";
        dt.Rows.Add(filaNueva);

        filaNueva = dt.NewRow();
        filaNueva["Modulo"] = "Noticias";
        dt.Rows.Add(filaNueva);

        filaNueva = dt.NewRow();
        filaNueva["Modulo"] = "Inscripciones";
        dt.Rows.Add(filaNueva);

        filaNueva = dt.NewRow();
        filaNueva["Modulo"] = "Sugerencias";
        dt.Rows.Add(filaNueva);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}