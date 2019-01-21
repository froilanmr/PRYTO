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
            lblOnline.Text = (string)Session["nombre"];

            try
            {
                NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
                conx.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM actividad where isBorrado=0", conx);
                NpgsqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    listaTipos.Items.Add(Convert.ToString(leer["nombre"]));
                }

                leer.Close();

                this.BindGrid(listaTipos.SelectedValue);
            }
            catch(Exception ex)
            {
                MsgBox("Error al cargar las actividades", Page, this);
            }
        }
    }

    private void BindGrid(string actividad)
    {
        DataTable datos = new DataTable();
        int contador = 0;

        try
        {
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
            var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("select correoInscrito from inscripcion where isBorrado=0 and actividad='" + actividad + "'", conn);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            while (leer.Read())
            {
                string correoInscrito = Convert.ToString(leer["correoInscrito"]);

                string consulta = "SELECT nombre, correo, telefono FROM usuario " +
                    "WHERE correo = '" + correoInscrito + "' AND isBorrado=0";
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
                catch (NpgsqlException ex)
                {
                    MsgBox("Error en la carga de la informacion de las actividades." + ex, Page, this);
                }
            }
            leer.Close();
            conn.Close();
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error en la recuperación de los datos de las inscripciones.", Page, this);
        }


        GridView1.DataSource = datos;
        GridView1.DataBind();

        /*
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        string consulta = "select correoInscrito from inscripcion where isBorrado=0 and actividad='" + actividad + "'";
        try
        {
            using (NpgsqlConnection conn2 = new NpgsqlConnection(connString))
            {
                using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(consulta, conn2))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        conn2.Close();
                    }
                }
            }
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error en la carga de la informacion de las actividades." + ex, Page, this);
        }*/
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

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid(listaTipos.SelectedValue);
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid(listaTipos.SelectedValue);
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];

        string actividad = (string)GridView1.DataKeys[e.RowIndex].Values[0];
        string user = (string)Session["usuario"];

        try
        {
            string query = "UPDATE inscripcion set isBorrado=1 WHERE actividad=@Actividad and correoInscrito=@Correo";
            var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
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
                }
            }
            this.BindGrid(listaTipos.SelectedValue);
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error en el Eliminado.", Page, this);
        }
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid(listaTipos.SelectedValue);
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void listaTipos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindGrid(listaTipos.SelectedValue);
    }
}