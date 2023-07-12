using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class PaginasBasicas_Inicio : System.Web.UI.Page
{
    LiquidacionSueldos.Datos.Gestor ocdGestor = new LiquidacionSueldos.Datos.Gestor();
    LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //this.Master.TituloDelFormulario = "Menu Inicio";
                this.Master.TituloDelFormulario = "Descarga de Archivos Extension Docente";
                if (this.Session["_Autenticado"] == null) Response.Redirect("PaginasBasicas/Login.aspx", true);

                Int32 liqId;
                liqId = Int32.Parse(Request.QueryString["liqID"].ToString());
                //reparticion = Int32.Parse(Request.QueryString["reparticion"].ToString());
                //string directorio = "~/Novedades/ArchivosExtensionDocente/" + liqId + "/" + reparticion;
                string directorio = "~/Novedades/ArchivosExtensionDocente/" + liqId ;

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
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
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
        Int32 liqId;
        liqId = Int32.Parse(Request.QueryString["liqID"].ToString());        
        string directorio = "~/Novedades/ArchivosExtensionDocente/" + liqId+"/";

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "filename="
            + e.CommandArgument);
        Response.TransmitFile(Server.MapPath(directorio)
        + e.CommandArgument);
        Response.End();
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Novedades/DescargaExtDocentePrincipal.aspx", true);            
        }

        catch (Exception oError)
        {
        }
    }
}