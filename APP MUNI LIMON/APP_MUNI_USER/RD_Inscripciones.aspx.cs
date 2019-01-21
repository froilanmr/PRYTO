using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_RUD_Inscripciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
            lblOnline.Text = (string)Session["nombre"];
        }
    }

    private void BindGrid()
    {
        string user = (string)Session["usuario"];
        DataTable datos = new DataTable();
        int contador = 0;

        try
        {
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("select actividad from inscripcion where isBorrado=0 and correoInscrito='" + user + "'", conn);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            while (leer.Read())
            {
                string nombreActividad = Convert.ToString(leer["actividad"]);

                string consulta = "SELECT nombre, fecha, direccion, descripcion FROM actividad " +
                    "WHERE nombre = '" + nombreActividad + "' AND isBorrado=0";
                try
                {
                    using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
                    {
                        using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                if (contador.Equals(0))
                                {
                                    sda.Fill(dt);
                                    datos = dt.Copy();
                                    contador += 1;
                                }
                                else
                                {
                                    sda.Fill(dt);
                                    datos.Merge(dt);
                                }
                                conn2.Close();
                            }
                        }
                    }
                }
                catch(NpgsqlException ex)
                {
                    MsgBox("Error en la carga de la informacion de las actividades." + ex, Page, this);
                }
            }
            conn.Close();
        }
        catch(NpgsqlException ex)
        {
            MsgBox("Error en la recuperación de los datos de las inscripciones.", Page, this);
        }


        GridView1.DataSource = datos;
        GridView1.DataBind();
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

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];

        string actividad = (string)GridView1.DataKeys[e.RowIndex].Values[0];
        string user = (string)Session["usuario"];

        string query;
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

        try
        {
            query = "UPDATE inscripcion set isBorrado=1 WHERE actividad=@Actividad and correoInscrito=@Correo";
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Actividad", actividad);
                    cmd.Parameters.AddWithValue("@Correo", user);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    query = "UPDATE actividad set cupos=cupos+1 WHERE nombre=@Nombre";
                    try
                    {
                        using (NpgsqlConnection con2 = new NpgsqlConnection(connString))
                        {
                            using (NpgsqlCommand cmd2 = new NpgsqlCommand(query))
                            {
                                cmd2.Parameters.AddWithValue("@Nombre", actividad);
                                cmd2.Connection = con2;
                                con2.Open();
                                cmd2.ExecuteNonQuery();
                                con2.Close();

                                this.BindGrid();
                                MsgBox("Se ha eliminado su cupo de esta actividad.", Page, this);
                            }
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        MsgBox("Error al devolver el cupo: " + ex, Page, this);
                    }
                }
            }
            
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error en el Eliminado.", Page, this);
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[4].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('¿Desea eliminar esta sugerencia?');";
        }
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}