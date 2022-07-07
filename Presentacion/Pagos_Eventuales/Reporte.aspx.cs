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

        ParameterValues Params = new ParameterValues();       // Creando una Coleccion de Parametros
        ParameterDiscreteValue Par = new ParameterDiscreteValue();   // Parametro Discreto q viene en el proc. alm. y se muestra en el Crystal Report
        Params.Clear();              // Limpiando la Coleccion de Datos

        NomRep = "~/PaginasGenerales/Reportes/" + Request.QueryString["NomRep"]; //  System.Web.UI.Page.Request.Item["NomRep"]; 
        string Ruta = MapPath(NomRep);  //System.Web.UI.Page.Server.MapPath(NomRep);
        NomRep = Ruta;
        cr.Load(NomRep);

        //Parametros opcionales - Se repite el try-catch por cada parametro que pudiera ser recibido tenga o no valor.

        //try
        //{
        //    DateTime fechaseleccionada;
        //    fechaseleccionada = DateTime.Parse(Request.QueryString["fechaseleccionada"]);
        //    Par.Value = fechaseleccionada;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@fechaseleccionada"].ApplyCurrentValues(Params);   // Aplicando los valores de nuestra coleccion a los parametros del crystal report
        //}
        //catch (Exception oError)
        //{
        //    //throw oError;
        //}

        try
        {
            DateTime fechaseleccionada;
            fechaseleccionada = DateTime.Parse(Request.QueryString["fechaseleccionada"]);
            Par.Value = fechaseleccionada;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@Fechacarga"].ApplyCurrentValues(Params);   // Aplicando los valores de nuestra coleccion a los parametros del crystal report
        }
        catch (Exception oError)
        {
            //throw oError;
        }

        try
        {
            Int32 anio;
            anio = Int32.Parse(Request.QueryString["anio"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = anio;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@anio"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }
            
        try
        {
            Int32 escId;
            escId = Int32.Parse(Request.QueryString["escId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = escId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@escId"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //    throw oError;
        }


    
        try
        {
            Int32 aplicafiltrofecha;
            aplicafiltrofecha = Int32.Parse(Request.QueryString["aplicafiltrofecha"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = aplicafiltrofecha;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@aplicafiltrofecha"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //    throw oError;
        }

        try
        {
            DateTime fechaDesde;
            fechaDesde = DateTime.Parse(Request.QueryString["fechaDesde"]);
            Par.Value = fechaDesde;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@fechadesde"].ApplyCurrentValues(Params);   // Aplicando los valores de nuestra coleccion a los parametros del crystal report
        }
        catch (Exception oError)
        {
            //throw oError;
        }

        try
        {
            DateTime fechaHasta;
            Params.Clear();
            fechaHasta = DateTime.Parse(Request.QueryString["fechaHasta"]);
            Par.Value = fechaHasta;
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@fechahasta"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //throw oError;
        }

        try
        {
            DateTime ixaFechaExamen;
            Params.Clear();
            ixaFechaExamen = DateTime.Parse(Request.QueryString["ixaFechaExamen"]);
            Par.Value = ixaFechaExamen;
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@ixaFechaExamen"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //throw oError;
        }


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

        //Obtiene los datos de conexion desde el apartado de AppSettings dentro de "Webconfig" 
        var appSettings = ConfigurationManager.AppSettings;
        string result = appSettings["ConexionCadena"] ?? "Not Found";
        string[] resultados = result.Split(';');
        string[] ServerName = resultados[05].Split('=');
        string[] DatabaseName = resultados[04].Split('=');
        string[] UserID = resultados[03].Split('=');
        string[] Password = resultados[01].Split('=');

        crConnectionInfo.ServerName = ServerName[1];
        crConnectionInfo.DatabaseName = DatabaseName[1];
        crConnectionInfo.UserID = UserID[1];
        crConnectionInfo.Password = Password[1];

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
        //CrystalReportViewer1.ReportSource = cr; // Mostrando el Reporte - Funciona igual sin esto
        cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NomRep);
        //CrystalReportViewer1.ReportSource = cr; // Mostrando el Reporte - Funciona igual sin esto

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