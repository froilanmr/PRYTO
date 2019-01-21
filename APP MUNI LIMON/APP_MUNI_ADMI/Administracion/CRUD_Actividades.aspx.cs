using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Administracion_CRUD_Actividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
            lblOnline.Text = (string)Session["nombre"];
        }
        if (!(txtTipo.Items.Count > 0))
        {
            txtTipo.Enabled = false;
            txtNombre.Enabled = false;
            txtFecha.Enabled = false;
            txtDireccion.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCupos.Enabled = false;
            btnAdd.Enabled = false;
            fileGaleria.Enabled = false;
            MsgBox("No se realizarán inserciones de Actividades debido a que no hay tipos registrados.", Page, this);
        }
    }
    private void BindGrid()
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        string query = "select nombre,tipoActividad, fecha, direccion, descripcion, cupos from actividad where isBorrado=0 order by fechaEntrada DESC";
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
        txtTipo.Items.Clear();

        NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
        conx.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM tipoActividad where isBorrado=0", conx);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        while (leer.Read())
        {
            txtTipo.Items.Add(Convert.ToString(leer["nombre"]));
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

    protected void Insert(object sender, EventArgs e)
    {
        String listaIMGS = "";

        String fechaEntrada = DateTime.Today.ToString("yyyy/MM/dd");
        String horaEntrada = DateTime.Now.ToString("HH:mm:ss");

        if (!txtNombre.Text.Equals("") || !txtFecha.Text.Equals("") || !txtDireccion.Text.Equals("")
            || !txtDescripcion.Text.Equals("") || !txtCupos.Text.Equals("") || txtTipo.SelectedIndex.Equals(-1))
        {
            if (fileGaleria.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in fileGaleria.PostedFiles)
                {
                    listaIMGS += "/Images/Actividades/" + uploadedFile.FileName + ",";
                }
                listaIMGS = listaIMGS.Remove(listaIMGS.Length - 1);
            }
            DateTime dt1 = DateTime.Parse(txtFecha.Text);
            DateTime dt2 = DateTime.Now;
            if (dt1 >= dt2)
            {
                try
                {
                    /* Conexión e inserción a la base de datos*/
                    NpgsqlConnection conectar = new NpgsqlConnection();
                    conectar.ConnectionString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
                    conectar.Open();
                    NpgsqlCommand insertar = new NpgsqlCommand("insert into actividad values ('" + txtNombre.Text + "', '" + txtFecha.Text +
                        "', '" + txtTipo.Text + "', '" + txtDireccion.Text + "', '" + txtDescripcion.Text + "', " +
                        Int32.Parse(txtCupos.Text) + ", '" + listaIMGS + "', 0, '" + (fechaEntrada + " " + horaEntrada) + "')", conectar);
                    insertar.ExecuteNonQuery();
                    conectar.Close();

                    MsgBox("¡Se registró la actividad!", Page, this);

                    this.BindGrid();
                    txtNombre.Text = "";
                    txtFecha.Text = "";
                    txtDireccion.Text = "";
                    txtDescripcion.Text = "";
                    txtCupos.Text = "";
                }
                catch (Exception ex) // Excepción en caso de datos duplicados
                {
                    MsgBox("¡Error en la Inserción, verifique los datos.", Page, this);
                }
            }
            else
            {
                MsgBox("La fecha de la Actividad es Inválida.", Page, this);
            }
        }
        else
        {
            MsgBox("Debe de rellenar todos los campos.", Page, this);
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
        string nombre = (string) GridView1.DataKeys[e.RowIndex].Values[0];
        string NuevoNombre = (row.FindControl("txtNombre") as TextBox).Text;
        string tipo = (row.FindControl("txtTipo") as ListBox).Text;
        string fecha = (row.FindControl("txtFecha") as TextBox).Text;
        string direccion = (row.FindControl("txtDireccion") as TextBox).Text;
        string descripcion = (row.FindControl("txtDescripcion") as TextBox).Text;
        string cupos = (row.FindControl("txtCupos") as TextBox).Text;
        

        if (NuevoNombre.Equals("") || tipo.Equals("") || fecha.Equals("")
            || direccion.Equals("") || descripcion.Equals("") || !cupos.Equals("") || txtTipo.SelectedIndex.Equals(-1))
        {
            string query = "UPDATE actividad SET nombre=@Nombre, descripcion=@Descripcion, tipoActividad=@Tipo, " +
            "direccion=@Direccion, fecha=@Fecha, cupos=@Cupos WHERE nombre=@NombreViejo";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@NombreViejo", nombre);
                        cmd.Parameters.AddWithValue("@Nombre", NuevoNombre);
                        cmd.Parameters.AddWithValue("@Tipo", tipo);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);
                        cmd.Parameters.AddWithValue("@Cupos", Int32.Parse(cupos));
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch(NpgsqlException ex)
            {
                MsgBox("Se presentó la siguiente excepción: " + ex, Page, this);
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        else
        {
            MsgBox("No se permite la actualización a Espacios Vacíos.", Page, this);
        }
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string titulo = (string) GridView1.DataKeys[e.RowIndex].Values[0];
        string query = "UPDATE actividad set isBorrado=1 WHERE nombre=@Nombre";
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        using (NpgsqlConnection con = new NpgsqlConnection(connString))
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@Nombre", titulo);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        this.BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Desea eliminar esta Actividad?');";
            }
            else if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                ListBox listaNueva = (ListBox)e.Row.FindControl("txtTipo");
                NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
                conx.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM tipoActividad where isBorrado=0", conx);
                NpgsqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    listaNueva.Items.Add(Convert.ToString(leer["nombre"]));
                }
                leer.Close();
                conx.Close();
            }
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Login.aspx");
    }
}