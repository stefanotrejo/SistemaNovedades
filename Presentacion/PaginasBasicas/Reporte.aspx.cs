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

        NomRep = "~/PaginasBasicas/Reportes/" + Request.QueryString["NomRep"]; //  System.Web.UI.Page.Request.Item["NomRep"]; 
        string Ruta = MapPath(NomRep);  //System.Web.UI.Page.Server.MapPath(NomRep);
        NomRep = Ruta;

        cr.Load(NomRep);

        try
        {
            String claseDesde = Request.QueryString["clase_desde"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = claseDesde;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@clase_desde"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            String claseHasta = Request.QueryString["clase_hasta"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = claseHasta;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario            
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@clase_hasta"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            DateTime periodoDesde;
            periodoDesde = DateTime.Parse(Request.QueryString["periodoDesde"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = periodoDesde;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@periodoDesde"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }


        try
        {
            DateTime periodoHasta;
            periodoHasta = DateTime.Parse(Request.QueryString["periodoHasta"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = periodoHasta;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@periodoHasta"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            String nombre;
            nombre = Request.QueryString["nombre"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = nombre;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@nombre"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            String nrocontrol;
            nrocontrol = Request.QueryString["nrocontrol"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = nrocontrol;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@nrocontrol"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            String dni;
            dni = Request.QueryString["dni"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = dni;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@dni"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            String LugarPago;
            LugarPago = Request.QueryString["LugarPago"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = LugarPago;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@LugarPago"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        try
        {
            String MesAnioLiq;
            MesAnioLiq = Request.QueryString["MesAnioLiq"].ToString(); // System.Web.UI.Page.Request.Item["anio"];
            Par.Value = MesAnioLiq;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
            Params.Add(Par);
            cr.DataDefinition.ParameterFields["@MesAnioLiq"].ApplyCurrentValues(Params);
        }
        catch (Exception oError)
        {
            //   throw oError;
        }

        #region EJEMPLO OTROS PARAMETROS

        //try
        //{
        //    Int32 carId;
        //    carId = Int32.Parse(Request.QueryString["carId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = carId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@carId"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        ////    throw oError;
        //}

        //try
        //{
        //    Int32 plaId;
        //    plaId = Int32.Parse(Request.QueryString["plaId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = plaId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@plaId"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        ////    throw oError;
        //}

        //try
        //{
        //    Int32 curId;
        //    curId = Int32.Parse(Request.QueryString["curId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = curId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@curId"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        ////    throw oError;
        //}

        //try
        //{
        //    Int32 camId;
        //    camId = Int32.Parse(Request.QueryString["camId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = camId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@camId"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        ////    throw oError;
        //}

        //try
        //{
        //    Int32 escId;
        //    escId = Int32.Parse(Request.QueryString["escId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = escId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@escId"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        ////    throw oError;
        //}


        //try
        //{
        //    Int32 ixaNumeroActa;
        //    ixaNumeroActa = Int32.Parse(Request.QueryString["ixaNumeroActa"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = ixaNumeroActa;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@ixaNumeroActa"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        //    //    throw oError;
        //}

        //try
        //{ 
        //    Int32 aplicafiltrofecha;
        //    aplicafiltrofecha = Int32.Parse(Request.QueryString["aplicafiltrofecha"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = aplicafiltrofecha;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@aplicafiltrofecha"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        //    //    throw oError;
        //}



        //try
        //{
        //    DateTime fechaDesde;
        //    fechaDesde = DateTime.Parse(Request.QueryString["fechaDesde"]);
        //    Par.Value = fechaDesde;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@fechadesde"].ApplyCurrentValues(Params);   // Aplicando los valores de nuestra coleccion a los parametros del crystal report
        //}
        //catch (Exception oError)
        //{
        //    //throw oError;
        //}

        //try
        //{
        //    DateTime fechaHasta;
        //    Params.Clear();
        //    fechaHasta = DateTime.Parse(Request.QueryString["fechaHasta"]);  
        //    Par.Value = fechaHasta;
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@fechahasta"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        //    //throw oError;
        //}


        //try
        //{
        //    DateTime ixaFechaExamen;
        //    Params.Clear();
        //    ixaFechaExamen = DateTime.Parse(Request.QueryString["ixaFechaExamen"]);
        //    Par.Value = ixaFechaExamen;
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@ixaFechaExamen"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        //    //throw oError;
        //}


        //try
        //{
        //    Int32 aluId;
        //    aluId = Int32.Parse(Request.QueryString["aluId"].ToString()); // System.Web.UI.Page.Request.Item["anio"];
        //    Par.Value = aluId;  // Asignando un Valor Discreto a nuestra variable jalando el valor de una caja de texto de tu formulario
        //    Params.Add(Par);
        //    cr.DataDefinition.ParameterFields["@aluId"].ApplyCurrentValues(Params);
        //}
        //catch (Exception oError)
        //{
        //    //    throw oError;
        //}

        #endregion

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


        var appSettings = ConfigurationManager.AppSettings;
        string result = appSettings["ConexionCadena"] ?? "Not Found";
        string[] resultados = result.Split(';');

        string[] ServerName = resultados[05].Split('=');
        string[] DatabaseName = resultados[04].Split('=');
        string[] UserID = resultados[03].Split('=');
        string[] Password = resultados[01].Split('=');



        // Generico - Funciona
        crConnectionInfo.ServerName = ServerName[1];
        crConnectionInfo.DatabaseName = DatabaseName[1];
        crConnectionInfo.UserID = UserID[1];
        crConnectionInfo.Password = Password[1];

        // Para el Servidor -- Prueba
        //crConnectionInfo.ServerName = "10.10.10.110\\MSSQLSERVER,1433";
        //crConnectionInfo.DatabaseName = "LiquidacionSueldos";
        //crConnectionInfo.UserID = "sa";
        //crConnectionInfo.Password = "Sueldos2018";


        //crConnectionInfo.ServerName = "172.16.210.26\\MSSQLSERVER,1433";
        //crConnectionInfo.DatabaseName = "LiquidacionSueldos";
        //crConnectionInfo.UserID = "sueldos";
        //crConnectionInfo.Password = "Sueldos2018";



        //WIN-N31A391PN30
        //crConnectionInfo.ServerName = "GPSDE-GESTPROY"; 172.16.164.158\MSSQLSERVER,1433

        //crConnectionInfo.DatabaseName = "LiquidacionSueldos";
        //crConnectionInfo.UserID = "sueldos1";
        //crConnectionInfo.Password = "Sueldo2018";

        //for (int i = 0; i < cr.Database.Tables.Count; i++)
        //{
        //    cr.Database.Tables[i].Name = cr.Database.Tables[i].Location;
        //}

        Tables CrTables;
        CrTables = cr.Database.Tables;


        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        {
            crtablelogoninfo = CrTable.LogOnInfo;
            crtablelogoninfo.ConnectionInfo = crConnectionInfo;
            CrTable.ApplyLogOnInfo(crtablelogoninfo);
            //CrTable.Location corresponde al nombre del sp
            //CrTable.Name corresponde al nombre que le pone el asistente de Crystal report 
            //no permite . solo guion bajo.
            //CrTable.Location = CrTable.Name;

        }

        crTableLogonInfo.Add(crtablelogoninfo);
        CrystalReportViewer1.ReportSource = cr; // Mostrando el Reporte
        cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NomRep);
        CrystalReportViewer1.ReportSource = cr; // Mostrando el Reporte

        String Exporta;
        Exporta = Page.Request["Exporta"];
        if (Exporta == "1")
        {
            cr.ExportToHttpResponse(ExportFormatType.Excel, Page.Response, true, NomRep);
        }
        else
        {
            cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Page.Response, false, NomRep);
        }
    }

    static void ReadSetting(string key)
    {
        try
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            //Console.WriteLine(result);
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading app settings");
        }
    }

}