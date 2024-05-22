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
                this.Master.TituloDelFormulario = "Descarga de Archivos";
                if (this.Session["_Autenticado"] == null) Response.Redirect("PaginasBasicas/Login.aspx", true);

                var archivosPorPerfil = new Dictionary<string, string[]>();
                Int32 liqId, reparticion;
                liqId = Int32.Parse(Request.QueryString["liquidacion"].ToString());
                reparticion = Int32.Parse(Request.QueryString["reparticion"].ToString());
                string directorio = "~/Novedades/ArchivosNoPresentismo/" + liqId + "/2";

                archivosPorPerfil.Add("99", new string[] { "NOPRESEN", "PEMULPC", "PEPERSPC" });

                if (Directory.Exists(Server.MapPath(directorio)))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Archivo");
                    dt.Columns.Add("Tamaño");                    

                    string[] archivosPermitidos = archivosPorPerfil[reparticion.ToString()];
                    foreach (string strfile in Directory.GetFiles(Server.MapPath(directorio)))
                    {
                        FileInfo fi = new FileInfo(strfile);
                        string fileName = fi.Name.ToLower();
                        foreach (string archivo in archivosPermitidos)
                        {
                            if (fileName.Contains(archivo.ToLower()))
                            {
                                dt.Rows.Add(fi.Name, fi.Length.ToString());
                            }
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
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

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Novedades/NovedadesConsulta.aspx", true);
        }

        catch (Exception oError)
        {
        }
    }
}