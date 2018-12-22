using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroNoticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
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

    protected void registrarNoticia_Click(object sender, EventArgs e)
    {
        /*
        string filepath = Server.MapPath("\\Datos");
        HttpFileCollection uploadedFiles = Request.Files;
        Span1.Text = string.Empty;

        for(int i = 0;i < uploadedFiles.Count;i++) {
            HttpPostedFile userPostedFile = uploadedFiles[i];
            try {
                if (userPostedFile.ContentLength > 0) {
                    MsgBox(galeriaNoticia.PostedFiles.ToString(), Page, this);

                    Span1.Text += "File Name: " + userPostedFile.FileName + "<br>";
              
                   userPostedFile.SaveAs(filepath + "\\" +    Path.GetFileName(userPostedFile.FileName));                  
                   Span1.Text += "Location where saved: " +   filepath + "\\" +   Path.GetFileName(userPostedFile.FileName) + "<p>";
                }
            } catch(Exception Ex) {
                Span1.Text += "Error: <br>" + Ex.Message;
            }
        }*/
        //MsgBox(galeriaNoticia.PostedFiles.ToString(), Page, this);
    }
}