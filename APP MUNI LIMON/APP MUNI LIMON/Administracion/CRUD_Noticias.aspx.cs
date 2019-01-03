using Npgsql;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_CRUD_Noticias : System.Web.UI.Page
{
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
        string query = "select titulo,descripcion, galeria from noticia";
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
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    public String ObtieneGaleria()
    {
        String listaIMGS = "";
        if (fileGaleria.HasFiles)
        {
            foreach (HttpPostedFile uploadedFile in fileGaleria.PostedFiles)
            {
                uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/Noticias/"), uploadedFile.FileName));
                listaIMGS += "~/Images/Noticias/" + uploadedFile.FileName + ",";
            }
        }
        //listaIMGS = listaIMGS.Remove(listaIMGS.Length - 1);
        return listaIMGS;
    }
    
    protected void Insert(object sender, EventArgs e)
    {
        
        string titulo = txtTitulo.Text;
        string descripcion = txtDescripcion.Text;
        if (!titulo.Equals("") || !descripcion.Equals(""))
        {
            try
            {
                string query = "insert into noticia(titulo,descripcion,galeria) values (@titulo, @descripcion, @galeria)";
                string lista = ObtieneGaleria();
                var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@galeria", lista);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MsgBox("¡Se registró la noticia!", Page, this);

                txtTitulo.Text = "";
                txtDescripcion.Text = "";
                this.BindGrid();
            }
            catch (NpgsqlException ex)
            {

            }
        }
        else
        {
            MsgBox("Es necesario que rellene todos los espacios.", Page, this);
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
        string titulo = (string)GridView1.DataKeys[e.RowIndex].Values[0];
        string NuevoTitulo = (row.FindControl("txtTitulo") as TextBox).Text;
        string descripcion = (row.FindControl("txtDescripcion") as TextBox).Text;
        string query = "UPDATE noticia SET titulo=@Titulo, descripcion=@Descripcion WHERE titulo=@TituloViejo";
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

        using (NpgsqlConnection con = new NpgsqlConnection(connString))
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@TituloViejo", titulo);
                cmd.Parameters.AddWithValue("@Titulo", NuevoTitulo);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string titulo = (string)GridView1.DataKeys[e.RowIndex].Values[0];
        string query = "DELETE FROM noticia WHERE titulo=@titulo";
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        using (NpgsqlConnection con = new NpgsqlConnection(connString))
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@titulo", titulo);
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
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Desea eliminar esta Noticia?');";
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}