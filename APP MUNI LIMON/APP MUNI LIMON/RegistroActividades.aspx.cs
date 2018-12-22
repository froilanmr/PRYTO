using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroActividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /**
         * Sección de Codigo donde carga la lista de actividades disponibles 
         * 
        **/
        NpgsqlConnection conx = new NpgsqlConnection("Host=baasu.db.elephantsql.com;Username=sylwognc;Password=5JNHiefCNAoEb9-sD1DUJWzEh8k7uMQO;Database=sylwognc");
        conx.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM tipoActividad", conx);
        NpgsqlDataReader leer = cmd.ExecuteReader();

        while (leer.Read())
        {
            tipoActividades.Items.Add(Convert.ToString(leer["nombre"]));
        }
        leer.Close();
        conx.Close();

        tipoActividades.Items.Insert(0, new ListItem("<Seleccione un tipo de Actividad>", "0"));

    }
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void registrarNoticia_Click(object sender, EventArgs e)
    {
        /*
        MsgBox(galeriaActividades.PostedFile.FileName.ToString(), Page, this);
        if (galeriaActividades.HasFile)     // Valida si hay archivos seleccionados
        {
            int iUploadedCnt = 0;
            int iFailedCnt = 0;
            HttpFileCollection hfc = Request.Files;

            if (hfc.Count <= 10)    // 10 FILES RESTRICTION.
            {
                for (int i = 0; i <= hfc.Count - 1; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (!File.Exists(Server.MapPath("DATOS\\") +
                            Path.GetFileName(hpf.FileName)))
                        {
                            DirectoryInfo objDir =
                                new DirectoryInfo(Server.MapPath("DATOS\\"));

                            string sFileName = Path.GetFileName(hpf.FileName);
                            string sFileExt = Path.GetExtension(hpf.FileName);

                            // CHECK FOR DUPLICATE FILES.
                            FileInfo[] objFI =
                                objDir.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

                            if (objFI.Length > 0)
                            {
                                // CHECK IF FILE WITH THE SAME NAME EXISTS 
                                foreach (FileInfo file in objFI)
                                {
                                    string sFileName1 = objFI[0].Name;
                                    string sFileExt1 = Path.GetExtension < objFI[0].Name;

                                    if (sFileName1.Replace(sFileExt1, "") ==
                                            sFileName.Replace(sFileExt, ""))
                                    {
                                        iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // SAVE THE FILE IN A FOLDER.
                                hpf.SaveAs(Server.MapPath("DATOS\\") +
                                    Path.GetFileName(hpf.FileName));
                                iUploadedCnt += 1;
                            }
                        }
                    }
                }
                //lblUploadStatus.Text = "<b>" + iUploadedCnt + "</b> file(s) Uploaded.";
                //lblFailedStatus.Text = "<b>" + iFailedCnt + 
                   // "</b> duplicate file(s) could not be uploaded.";
            }
            //else lblUploadStatus.Text = "Max. 10 files allowed.";
        }
        //else lblUploadStatus.Text = "No files selected.";
        */
    }
}