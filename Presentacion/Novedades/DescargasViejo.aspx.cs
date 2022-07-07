using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Novedades_Descargas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.NovedadInasistencia oNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();
        try
        {      
            Int32 liqId, reparticion;
            liqId = Int32.Parse(Request.QueryString["liquidacion"].ToString());                        
            reparticion = Int32.Parse(Request.QueryString["reparticion"].ToString());
            string directorio = "~/Novedades/ArchivosNoPresentismo/" + liqId + "/" + reparticion;

            // Cargo el data table
            DataTable dt = new DataTable();
            dt.Columns.Add("Archivo");
            dt.Columns.Add("Tamaño");
            dt.Columns.Add("Tipo");

            foreach (string strfile in Directory.GetFiles(Server.MapPath(directorio)))
            {
                FileInfo fi = new FileInfo(strfile);
                dt.Rows.Add(fi.Name, fi.Length.ToString(),
                    GetFileTypeByExtension(fi.Extension));
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception oError)
        {
        }

    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Novedades/NovedadesConsulta.aspx", true);
            //Response.Redirect(Session["PreviousPage"].ToString(), true);
        }

        catch (Exception oError)
        {            
        }
    }

    private string GetFileTypeByExtension(string fileExtension)
    {
        switch (fileExtension.ToLower())
        {
            case ".docx":
            case ".doc":
                return "Microsoft Word Document";
            case ".xlsx":
            case ".xls":
                return "Microsoft Excel Document";
            case ".txt":
                return "Text Document";
            case ".jpg":
            case ".png":
                return "Image";
            default:
                return "Unknown";
        }
    }

    protected void GridView1_RowCommand(object sender,
        GridViewCommandEventArgs e)
    {
        Int32 liqId, reparticion;
        liqId = Int32.Parse(Request.QueryString["liquidacion"].ToString());
        reparticion = Int32.Parse(Request.QueryString["reparticion"].ToString());
        string directorio = "~/Novedades/ArchivosNoPresentismo/" + liqId + "/" + reparticion + "/";

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "filename="
            + e.CommandArgument);
        Response.TransmitFile(Server.MapPath(directorio)
        + e.CommandArgument);
        Response.End();
    }
}