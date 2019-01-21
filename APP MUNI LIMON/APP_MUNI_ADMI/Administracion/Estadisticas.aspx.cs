using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_Estadisticas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (DropDownList1.SelectedValue.Equals("Actividades"))
            {
                this.SetActividades();
            }
            else
            {
                this.SetTipos();
            }

            lblOnline.Text = (string)Session["nombre"];
        }
    }

    private void SetTipos()
    {
        UpdatePanel1.Visible = true;
        DataTable primera = new DataTable();
        DataTable segunda = new DataTable();
        DataTable final = new DataTable();


        DataTable tablaMas = ObtieneTipoMas();
        DataTable tablaMenos = ObtieneTipoMenos();

        DataTable tablaVieja = ObtieneTipoViejo();
        DataTable tablaNueva = ObtieneTipoNuevo();

        primera = MergeTablesByIndex(tablaMas, tablaMenos);
        segunda = MergeTablesByIndex(tablaVieja, tablaNueva);
        final = MergeTablesByIndex(primera, segunda);

        
        DataTable vacia = new DataTable();
        vacia.Columns.Add("actividad", typeof(String));
        vacia.Columns.Add("NuevaAct", typeof(String));
        vacia.Columns.Add("actividad2", typeof(String));
        vacia.Columns.Add("NuevaAct2", typeof(String));
        vacia.Columns.Add("nombre", typeof(String));
        vacia.Columns.Add("fecha", typeof(String));
        vacia.Columns.Add("nombre2", typeof(String));
        vacia.Columns.Add("fecha2", typeof(String));

        
        DataRow dr = vacia.NewRow();

        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";
        vacia.Rows.Add(dr);

        DataTable equis = new DataTable();
        equis = MergeTablesByIndex(final, vacia);

        GridView1.DataSource = equis;
        GridView1.DataBind();
        GridView1.HeaderRow.Cells[0].Text = "Tipo con más Actividades";
        GridView1.HeaderRow.Cells[1].Text = "Tipo con menos Actividades";
        GridView1.HeaderRow.Cells[2].Text = "Tipo más antiguo registrado";
        GridView1.HeaderRow.Cells[3].Text = "Tipo más reciente registrado";
        
    }

    private void SetActividades()
    {
        UpdatePanel1.Visible = true;
        DataTable primera = new DataTable();
        DataTable segunda = new DataTable();
        DataTable final = new DataTable();


        DataTable tablaMas = ObtieneActividadMas();
        DataTable tablaMenos = ObtieneActividadMenos();

        DataTable tablaVieja = ObtieneActividadProxima();
        DataTable tablaNueva = ObtieneActividadLegana();

        primera = MergeTablesByIndex(tablaMas, tablaMenos);
        segunda = MergeTablesByIndex(tablaVieja, tablaNueva);
        final = MergeTablesByIndex(primera, segunda);

        DataTable vacia = new DataTable();
        vacia.Columns.Add("tipoActividad", typeof(String));
        vacia.Columns.Add("Nueva", typeof(String));
        vacia.Columns.Add("Tipo", typeof(String));
        vacia.Columns.Add("Nueva2", typeof(String));
        vacia.Columns.Add("Viejo", typeof(String));
        vacia.Columns.Add("Nuevo", typeof(String));

        DataRow dr = vacia.NewRow();

        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        vacia.Rows.Add(dr);

        final = MergeTablesByIndex(final, vacia);

        GridView1.DataSource = final;
        GridView1.DataBind();
        GridView1.HeaderRow.Cells[0].Text = "Actividad con más inscripciones";
        GridView1.HeaderRow.Cells[1].Text = "Actividad con menos inscripciones";
        GridView1.HeaderRow.Cells[2].Text = "Actividad más proxima a realizarse";
        GridView1.HeaderRow.Cells[3].Text = "Actividad más lejana por realizarse";
        
    }

    private DataTable ObtieneActividadLegana()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();


        string consulta = "select nombre as nombre2, fecha as fecha2 from actividad where isBorrado=0 order by fecha2 DESC limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (resultado)
                    {
                        sda.Fill(resultado);
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener la actividad mas lejana." + ex, Page, this);
        }

        return resultado;
    }

    private DataTable ObtieneActividadProxima()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();


        string consulta = "select nombre, fecha from actividad where isBorrado=0 order by fecha asc limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (resultado)
                    {
                        sda.Fill(resultado);
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener las actividad mas proxima." + ex, Page, this);
        }

        return resultado;
    }

    private DataTable ObtieneActividadMenos()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();


        string consulta = "select actividad as actividad2, count(actividad) as NuevaAct2 from inscripcion where isBorrado=0 group by actividad2 order by NuevaAct2 asc limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (resultado)
                    {
                        sda.Fill(resultado);
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener la actividad con menos inscripciones." + ex, Page, this);
        }

        return resultado;
    }

    private DataTable ObtieneActividadMas()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();


        string consulta = "select actividad, count(actividad) as NuevaAct from inscripcion where isBorrado=0 group by actividad order by NuevaAct desc limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (resultado)
                    {
                        sda.Fill(resultado);
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener la actividad con mas inscripciones." + ex, Page, this);
        }

        return resultado;
    }

    public static DataTable MergeTablesByIndex(DataTable t1, DataTable t2)
    {
        if (t1 == null || t2 == null) throw new ArgumentNullException("t1 or t2", "Both tables must not be null");

        DataTable t3 = t1.Clone();  // first add columns from table1
        foreach (DataColumn col in t2.Columns)
        {
            string newColumnName = col.ColumnName;
            int colNum = 1;
            while (t3.Columns.Contains(newColumnName))
            {
                newColumnName = string.Format("{0}_{1}", col.ColumnName, ++colNum);
            }
            t3.Columns.Add(newColumnName, col.DataType);
        }
        var mergedRows = t1.AsEnumerable().Zip(t2.AsEnumerable(),
            (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
        foreach (object[] rowFields in mergedRows)
            t3.Rows.Add(rowFields);

        return t3;
    }

    protected DataTable ObtieneTipoMas()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();


        string consulta = "select tipoActividad, count(tipoActividad) as Nueva from actividad where isBorrado=0 group by tipoActividad order by Nueva desc limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (resultado)
                    {
                        sda.Fill(resultado);
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener los tipos mas usados." + ex, Page, this);
        }

        return resultado;
    }

    protected DataTable ObtieneTipoMenos()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();
        string consulta = "select tipoActividad as Tipo, count(tipoActividad) as Nueva2 " +
                    "from actividad " +
                    "where isBorrado=0 " +
                    "group by Tipo " +
                    "order by Nueva2 asc limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        resultado = dt;
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener los tipos menos usados." + ex, Page, this);
        }

        return resultado;
    }

    protected DataTable ObtieneTipoViejo()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();
        string consulta = "select nombre as Viejo " +
            "from tipoActividad " +
            "where isBorrado=0 " +
            "order by fechaEntrada asc " +
            "limit 1";
        
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        resultado = dt;
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener los tipos mas usados." + ex, Page, this);
        }

        return resultado;
    }

    protected DataTable ObtieneTipoNuevo()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        DataTable resultado = new DataTable();
        string consulta = "select nombre as Nuevo " +
            "from tipoActividad " +
            "where isBorrado=0 " +
            "order by fechaEntrada DESC " +
            "limit 1";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        resultado = dt;
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al obtener los tipos mas usados." + ex, Page, this);
        }

        return resultado;
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login.aspx");
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //this.BindGrid();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.Equals("Actividades"))
        {
            GridView1.HeaderRow.Cells[0].Text = "Actividad con más inscripciones";
            GridView1.HeaderRow.Cells[1].Text = "Actividad con menos inscripciones";
            GridView1.HeaderRow.Cells[2].Text = "Actividad más proxima a realizarse";
            GridView1.HeaderRow.Cells[3].Text = "Actividad más lejana por realizarse";
            this.SetActividades();
        }
        else
        {
            GridView1.HeaderRow.Cells[0].Text = "Tipo con más Actividades";
            GridView1.HeaderRow.Cells[1].Text = "Tipo con menos Actividades";
            GridView1.HeaderRow.Cells[2].Text = "Tipo más antiguo registrado";
            GridView1.HeaderRow.Cells[3].Text = "Tipo más reciente registrado";
            this.SetTipos();
        }
        
    }
}