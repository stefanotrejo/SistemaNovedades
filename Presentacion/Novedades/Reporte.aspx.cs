using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.OleDb;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

public partial class PaginasGenerales_Reporte : System.Web.UI.Page
{
    private ReportDocument cr = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        string NomRep;
        
        // Creando una Coleccion de Parametros
        ParameterValues Params = new ParameterValues();
        // Parametro Discreto q viene en el proc. alm. y se muestra en el Crystal Report
        ParameterDiscreteValue Par = new ParameterDiscreteValue();   
        Params.Clear();              // Limpiando la Coleccion de Datos

        NomRep = "~/Novedades/Reportes/" + Request.QueryString["NomRep"]; 
        string Ruta = MapPath(NomRep);
        NomRep = Ruta;
        cr.Load(NomRep);

        // Parametros:
        // Se repite el try-catch por cada parametro que pudiera ser recibido tenga o no valor.
   
        try
        {
            Int32 liqId;
            liqId = Int32.Parse(Request.QueryString["liqId"].ToString());            
            Par.Value = liqId;  
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@liqId"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {            
        }

        try
        {
            Int32 jurId;
            jurId = Int32.Parse(Request.QueryString["jurId"].ToString());
            Par.Value = jurId;
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@jurId"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
        }

        try
        {
            Int32 perEsAdministrador;
            perEsAdministrador = Int32.Parse(Request.QueryString["reparticion"].ToString());
            Par.Value = perEsAdministrador;
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@perEsAdministrador"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
        }



        // CRYSTAL REPORT                    
        //var crTableLogonInfos = new TableLogOnInfos();
        TableLogOnInfos crTableLogonInfo = new TableLogOnInfos();
        TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();

        //00 provider
        //01 password
        //02 persist security info
        //03 userID
        //04 catalogo = nombre de base de datos
        //05 datasource = servidor

        //Obtiene los datos de conexion de "AppSettings" dentro de "Webconfig" 
        var appSettings = ConfigurationManager.AppSettings;
        string result = appSettings["ConexionCadena"] ?? "Not Found";
        string[] resultados = result.Split(';');
        string[] ServerName = resultados[05].Split('=');
        string[] DatabaseName = resultados[04].Split('=');
        string[] UserID = resultados[03].Split('=');
        string[] Password = resultados[01].Split('=');

        // Generico
         crConnectionInfo.ServerName = ServerName[1];
         crConnectionInfo.DatabaseName = DatabaseName[1];
         crConnectionInfo.UserID = UserID[1];
         crConnectionInfo.Password = Password[1];

        // Para el Servidor
        /*crConnectionInfo.ServerName = "10.10.10.110\\MSSQLSERVER,1433";
        crConnectionInfo.DatabaseName = "LiquidacionSueldos";
        crConnectionInfo.UserID = "sa";
        crConnectionInfo.Password = "Sueldos2018";*/

        Tables CrTables;
        CrTables = cr.Database.Tables;
        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        {
            crtablelogoninfo = CrTable.LogOnInfo;
            crtablelogoninfo.ConnectionInfo = crConnectionInfo;
            CrTable.ApplyLogOnInfo(crtablelogoninfo);
            //var name = CrTable.Name;
            //var location = CrTable.Location;
            //CrTable.Location = CrTable.Name;            
        }

        crTableLogonInfo.Add(crtablelogoninfo);
        // Mostrando el Reporte     
        CrystalReportViewer1.ReportSource = cr; 
        cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NomRep);

        cr.Dispose();
        cr.Close();
        GC.Collect();
        #region Exportar reporte como excel o como doc
        //String Exporta;
        //Exporta = Page.Request["Exporta"];
        //if (Exporta == "1")
        //{
        //    cr.ExportToHttpResponse(ExportFormatType.Excel, Page.Response, true, NomRep);
        //}
        //else
        //{
        //    cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Page.Response, false, NomRep);
        //}
        #endregion 
    }

}