using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CRUD_Sugerencias : System.Web.UI.Page
{
    int Anonima = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        string query = "select tipoTramite, isAnonima, valoracion, descripcion from sugerencia where isBorrado=0";
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    conn.Close();
                }
            }
        }
        

        /**
         * Sección de Codigo donde carga la lista de actividades disponibles 
         * 
        **/
        try
        {
            string user = (string)Session["usuario"];
            string contra = (string)Session["contra"];
            NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
            conx.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM usuario where correo = '" + user + "' and contrasenna = '" + contra + "' and isBorrado=0", conx);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            while (leer.Read())
            {
                telefono.Text = Convert.ToString(leer["telefono"]);
                correo.Text = user;

                telefono.Enabled = false;
                correo.Enabled = false;
            }
            leer.Close();
            conx.Close();
        }
        catch(NpgsqlException ex)
        {
            MsgBox("Error", Page, this);
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

    protected void registrarSugerencia_Click(object sender, EventArgs e)
    {
        if (!telefono.Text.Equals("") || !correo.Text.Equals("") || !descripcion.Text.Equals(""))
        {
            if (!valoraciones.SelectedItem.Value.Equals(""))
            {
                try
                {
                    /* Conexión e inserción a la base de datos*/
                    NpgsqlConnection conectar = new NpgsqlConnection();
                    conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                    conectar.Open();
                    NpgsqlCommand insertar = new NpgsqlCommand("insert into sugerencia(isAnonima,correo,telefono, tipoTramite,valoracion,descripcion,isBorrado) values (" +
                        Anonima + ", '" + correo.Text + "', " + Int32.Parse(telefono.Text) + ",'" + tipoTramite.SelectedItem.Value + "', " + (valoraciones.SelectedIndex + 1) +
                        ", '" + descripcion.Text + "', 0)", conectar);
                    insertar.ExecuteNonQuery();
                    conectar.Close();

                    MsgBox("¡Se registró la sugerencia!", Page, this);

                    telefono.Text = "";
                    correo.Text = "";
                    descripcion.Text = "";
                    valoraciones.ClearSelection();
                    isAnonima.Checked = false;
                    this.BindGrid();
                }
                catch (Exception ex) // Excepción en caso de datos duplicados
                {
                    MsgBox("Eror en la sugerencia.", Page, this);
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
        }
        else
        {
            Anonima = 0;
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string Descri = (string)GridView1.DataKeys[e.RowIndex].Values[0];
        string Descripcion = (row.FindControl("txtExperiencia") as TextBox).Text;
        string TipoTramite = (row.FindControl("txtTipoTramite") as DropDownList).SelectedItem.Value;
        int TipoValoracion = (((row.FindControl("txtTipo") as CheckBox).Checked) ? 1 : 0) ;
        int Valoracion = (row.FindControl("txtValoracion") as RadioButtonList).SelectedIndex + 1;

        string Nombre = (string)Session["usuario"];

        
        if (!TipoTramite.Equals("") || !Descripcion.Equals("") || !Valoracion.Equals(-1))
        {
            string query = "UPDATE sugerencia SET isAnonima=@Anonima, tipoTramite=@Tipo, valoracion=@Valoracion," +
                "descripcion=@Descripcion WHERE correo=@Correo and telefono=@Telefono";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Anonima", TipoValoracion);
                        cmd.Parameters.AddWithValue("@Tipo", TipoTramite);
                        cmd.Parameters.AddWithValue("@Valoracion", Valoracion);
                        cmd.Parameters.AddWithValue("@Descripcion", Descripcion);

                        cmd.Parameters.AddWithValue("@Correo", correo.Text);
                        cmd.Parameters.AddWithValue("@Telefono", Int32.Parse(telefono.Text));
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                GridView1.EditIndex = -1;
                this.BindGrid();
            }
            catch (NpgsqlException ex)
            {
                MsgBox("Error en la actualización de los datos.", Page, this);
            }
        }
        else
        {
            MsgBox("Verique que todos lo campos estén llenos/seleccionados.", Page, this);
        }
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string nombre = (string)Session["usuario"];
        string descripcion = (string)GridView1.DataKeys[e.RowIndex].Values[0];
        try
        {
            string query = "UPDATE sugerencia set isBorrado=1 WHERE correo=@Correo and descripcion=@Descripcion";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Correo", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }
        catch(NpgsqlException ex)
        {
            MsgBox("Error en el Eliminado.", Page, this);
        }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[4].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('¿Desea eliminar esta sugerencia?');";
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

}