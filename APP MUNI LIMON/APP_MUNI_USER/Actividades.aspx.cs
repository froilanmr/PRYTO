using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Actividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.CargaListas();

            lblOnline.Text = (string)Session["nombre"];
        }
    }

    protected void CargaListas()
    {
        try
        {
            NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
            conx.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM tipoActividad where isBorrado=0", conx);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            while (leer.Read())
            {
                listaTipos.Items.Add(Convert.ToString(leer["nombre"]));
            }

            leer.Close();

            if (!listaTipos.Items.Count.Equals(0))
            {
                var seleccion = listaTipos.Items[0].Text;
                cmd = new NpgsqlCommand("SELECT * FROM actividad where isBorrado=0 and tipoActividad='"
                    + seleccion + "'", conx);
                leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    listaActividades.Items.Add(Convert.ToString(leer["nombre"]));
                }

                leer.Close();
                conx.Close();

                if (listaActividades.Items.Count.Equals(0))
                {
                    Error2.Visible = true;
                }
                else
                {
                    Error2.Visible = false;
                }
            }
            else
            {
                Error1.Visible = true;
            }
            
        } catch (NpgsqlException ex)
        {
            MsgBox("Error en la carga de los tipos de actividades.", Page, this);
        }
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void listaTipos_SelectedIndexChanged(object sender, EventArgs e)
    {
        var seleccion = listaTipos.SelectedValue;
        listaActividades.Items.Clear();
        try
        {
            NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
            conx.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM actividad where isBorrado=0 and tipoActividad='"
                + seleccion  + "'", conx);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            while (leer.Read())
            {
                listaActividades.Items.Add(Convert.ToString(leer["nombre"]));
            }

            leer.Close();
            conx.Close();

            if (listaActividades.Items.Count.Equals(0))
            {
                Error2.Visible = true;
            }
            else
            {
                Error2.Visible = false;
            }
        }
        catch(NpgsqlException ex)
        {
            MsgBox("Error en la carga de actividades relacionadas a un tipo.", Page, this);
        }
    }

    public Boolean PoseeInscripcion(string correo, string actividad)
    {
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        var conn = new NpgsqlConnection(connString);
        conn.Open();

        var cmd = new NpgsqlCommand("SELECT * FROM inscripcion WHERE correoInscrito='" + correo +
            "' AND actividad='" + actividad + "' AND isBorrado=0", conn);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        if (leer.Read())
        {
            conn.Close();
            leer.Close();
            return true;
        }

        conn.Close();
        leer.Close();
        return false;
    }

    /**
     * Verifica que no se hagan inscripciones negativas
     * 
     */
    public int ObtieneCupos(string nombreActividad, string tipoActividad)
    {
        int Cupos;
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";
        var conn = new NpgsqlConnection(connString);
        conn.Open();

        var cmd = new NpgsqlCommand("SELECT cupos FROM actividad WHERE nombre='"+
            nombreActividad + "' AND tipoActividad='" + tipoActividad + "'", conn);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        if (leer.Read())
        {
            Cupos = (int)leer["cupos"];
        }
        else
        {
            Cupos = -1;
        }

        conn.Close();
        leer.Close();
        return Cupos;
    }


    protected string ProcesarMes(int NumeroMes)
    {
        String NombreMes = "";
        switch (NumeroMes)
        {
            case 01:
                NombreMes = "Enero";
                break;

            case 02:
                NombreMes = "Febrero";
                break;

            case 03:
                NombreMes = "Marzo";
                break;

            case 04:
                NombreMes = "Abril";
                break;

            case 05:
                NombreMes = "Mayo";
                break;

            case 06:
                NombreMes = "Junio";
                break;

            case 07:
                NombreMes = "Julio";
                break;

            case 08:
                NombreMes = "Agosto";
                break;

            case 09:
                NombreMes = "Septiembre";
                break;

            case 10:
                NombreMes = "Octubre";
                break;

            case 11:
                NombreMes = "Noviembre";
                break;

            case 12:
                NombreMes = "Diciembre";
                break;
        }
        return NombreMes;
    }

    protected string ProcesarFecha(string fechaInicial)
    {
        string fechaFinal = "";

        char[] Array1 = new char[2];
        Array1[0] = fechaInicial[8];
        Array1[1] = fechaInicial[9];
        string StringNuevo1 = new string(Array1);
        fechaFinal += StringNuevo1;
        fechaFinal += " de ";

        char[] Array2 = new char[2];
        Array2[0] = fechaInicial[5];
        Array2[1] = fechaInicial[6];
        string StringNuevo2 = new string(Array2);
        int NumMes = Int32.Parse(StringNuevo2);
        StringNuevo2 = ProcesarMes(NumMes);
        fechaFinal += StringNuevo2;
        fechaFinal += " del ";

        char[] Array3 = new char[4];
        Array3[0] = fechaInicial[0];
        Array3[1] = fechaInicial[1];
        Array3[2] = fechaInicial[2];
        Array3[3] = fechaInicial[3];
        string StringNuevo3 = new string(Array3);
        fechaFinal += StringNuevo3;

        return fechaFinal;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var seleccionActividad = listaActividades.SelectedValue;
        var seleccionTipo = listaTipos.SelectedValue;
        try
        {
            NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
            conx.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM actividad where isBorrado=0 and tipoActividad='"
                + seleccionTipo + "' and nombre ='" + seleccionActividad + "'", conx);
            NpgsqlDataReader leer = cmd.ExecuteReader();

            if (leer.Read())
            {
                lblNombreActividad.Visible = true;
                lblNombreActividad.Text = Convert.ToString(leer["nombre"]);

                lbl1.Visible = true;
                lblFechaActividad.Visible = true;
                lblFechaActividad.Text = ProcesarFecha(Convert.ToString(leer["fecha"]));

                lblDescripcion.Visible = true;
                lblDescripcion.Text = Convert.ToString(leer["descripcion"]);

                lbl2.Visible = true;
                lblDireccion.Visible = true;
                lblDireccion.Text = Convert.ToString(leer["direccion"]);

                lbl3.Visible = true;
                lblCupos.Visible = true;
                lblCupos.Text = Convert.ToString(leer["cupos"]);

                Inscripcion.Visible = true;

                ImagenA.ImageUrl = Convert.ToString(leer["galeria"]);
                ImagenA.Visible = true;
            }

            leer.Close();
            conx.Close();
        }
        catch (NpgsqlException ex)
        {
            MsgBox("Error al mostrar la información acerca de la actividad.", Page, this);
        }
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void Inscripcion_Click(object sender, EventArgs e)
    {
        String fechaEntrada = DateTime.Today.ToString("yyyy/MM/dd");
        String horaEntrada = DateTime.Now.ToString("HH:mm:ss");

        var seleccionActividad = listaActividades.SelectedValue;
        var seleccionTipo = listaTipos.SelectedValue;
        string userAct = (string)Session["usuario"];

        string query = "insert into inscripcion(tipoActividad, actividad, correoInscrito, isBorrado, fechaEntrada)" +
            " VALUES (@Tipo, @Actividad, @Correo, 0, @FechaEntrada) ";
        var connString = "Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc";

        // Validación si actualmente posee una inscripción
        if (PoseeInscripcion(userAct, seleccionActividad))
        {
            MsgBox("1 inscripción máxima por persona, ya ustedd posee inscripción en esta actividad.", Page, this);
        }
        else
        {
            try
            {
                // Agrega la inscripción
                using (NpgsqlConnection con = new NpgsqlConnection(connString))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Tipo", seleccionTipo);
                        cmd.Parameters.AddWithValue("@Actividad", seleccionActividad);
                        cmd.Parameters.AddWithValue("@Correo", userAct);
                        cmd.Parameters.AddWithValue("@FechaEntrada", (fechaEntrada + " " + horaEntrada));
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lblNombreActividad.Visible = false;
                        lbl1.Visible = false;
                        lblFechaActividad.Visible = false;
                        lblDescripcion.Visible = false;
                        lbl2.Visible = false;
                        lblDireccion.Visible = false;
                        lbl3.Visible = false;
                        lblCupos.Visible = false;
                        Inscripcion.Visible = false;
                        ImagenA.Visible = false;

                        // Ya no hay cupos
                        if (ObtieneCupos(seleccionActividad, seleccionTipo).Equals(0))
                        {
                            MsgBox("Ya no quedan cupos para esta actividad.", Page, this);
                        }else if (ObtieneCupos(seleccionActividad, seleccionTipo).Equals(-1))
                        {
                            MsgBox("Error al obtener los cupos.", Page, this);
                        }
                        else
                        {
                            // Resta el cupo de la actividad
                            query = "UPDATE actividad set cupos=cupos-1 WHERE nombre=@Nombre and tipoActividad=@Tipo";
                            try
                            {
                                using (NpgsqlConnection con2 = new NpgsqlConnection(connString))
                                {
                                    using (NpgsqlCommand cmd2 = new NpgsqlCommand(query))
                                    {
                                        cmd2.Parameters.AddWithValue("@Nombre", seleccionActividad);
                                        cmd2.Parameters.AddWithValue("@Tipo", seleccionTipo);
                                        cmd2.Connection = con2;
                                        con2.Open();
                                        cmd2.ExecuteNonQuery();
                                        con2.Close();

                                        MsgBox("Se ha agregado su inscripción!", Page, this);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MsgBox("Error al restar el cupo de las actividades.  " + ex, Page, this);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox("Error al agregar la inscripción.", Page, this);
            }
        }
    }
}