using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using NPOI.HSSF.Model; // InternalWorkbook
using NPOI.HSSF.UserModel; // HSSFWorkbook, HSSFSheet
using NPOI.SS.UserModel;
using WebNPOI.Code.Repository;
using WebNPOI.Code.Domain;
using WebNPOI.Code.Service;
using System.Text;
using WebNPOI.Code.Crosscutting;
using System.Net;

public static class FuncionesUtiles
{
    private static string SeparadorDecimal = "";
    private static string NotSeparadorDecimal = "";
    private static LiquidacionSueldos.Datos.Gestor ocnGestor = new LiquidacionSueldos.Datos.Gestor();
    private static DataTable dt;
    private static string mensaje;

    static FuncionesUtiles()
    {
        SeparadorDecimal = System.Configuration.ConfigurationSettings.AppSettings["SeparadorDecimal"].ToString();

        if (SeparadorDecimal == ",")
        {
            NotSeparadorDecimal = ".";
        }
        else
        {
            NotSeparadorDecimal = ",";
        }
    }

    public static decimal StringToDecimal(string Valor)
    {
        return Convert.ToDecimal(Valor.Replace(NotSeparadorDecimal, SeparadorDecimal));
    }

    public static string DecimalToString(decimal Valor)
    {
        return Valor.ToString().Replace(",", ".");
    }

    public static void ExportarAExcel(DataTable dt, string ArchivoNombre, Page Pagina)
    {
        try
        {
            WebNpoiService ser = new WebNpoiService();
            byte[] ba = ser.CreateExcel(dt, ArchivoNombre);

            Pagina.Response.Buffer = true;
            Pagina.Response.ContentType = "application/vnd.ms-excel";
            Pagina.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", ArchivoNombre));
            Pagina.Response.Charset = "UTF-8";
            Pagina.Response.ContentEncoding = Encoding.Default;
            Pagina.Response.OutputStream.Write(ba, 0, ba.Length);
            Pagina.Response.End();
        }
        catch (Exception oError)
        {
            throw oError;
        }
    }

    public static bool EsNumero(string s)
    {
        float output;
        return float.TryParse(s, out output);
    }

    public static string ObtenerIpPublica()
    {
        return "";
    }

    public static bool EsFecha(string Fecha)
    {
        DateTime FechaDt;
        return DateTime.TryParse(Fecha, out FechaDt);
    }

    public static bool EsFecha(string Dia, string Mes, string Ano)
    {
        bool Resultado = false;

        #region Sql
        string Sql = @"
set dateformat dmy

declare @Dia int, @Mes int, @Ano int, @FechaString varchar(50)
select @Dia = " + Dia.ToString() + @"
select @Mes = " + Mes.ToString() + @"
select @Ano = " + Ano.ToString() + @"

select @FechaString = 
case when @Dia < 10 then '0' else '' end + convert(varchar(50),@Dia) + '/' +
case when @Mes < 10 then '0' else '' end + convert(varchar(50),@Mes) + '/' +
convert(varchar(50),@Ano)

select ISDATE(@FechaString) as Resultado";
        #endregion

        dt = ocnGestor.EjecutarReaderSql(Sql);
        if (dt.Rows.Count != 0)
        {
            if (dt.Rows[0]["Resultado"].ToString() == "1")
            {
                Resultado = true;
            }
            else
            {
                Resultado = false;
            }
        }

        return Resultado;
    }

    public static void AbreVentana(String url)
    {
        //System.Web.UI.Page pagina = new System.Web.UI.Page();
        //pagina = HttpContext.Current.CurrentHandler();
        Page pagina = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterClientScriptBlock(pagina, typeof(string), "scr", "<script>window.open('" + url + "','popupwindow','location=no,toolbar=no,status=yes,menubar=no,scroll=yes,resizable=yes,directories=no');</script>", false); // registro script en scriptmanager (ajax)

    }

    public static string MensajeExito(string mensaje)
    {                
        return mensaje = @"<div class=""alert alert-success alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        <a class=""alert-link"" href=""#"">Confirmacion</a><br/>" + mensaje + 
                        "<br>" + "</div>";
    }

    public static string MensajeError(string mensaje)
    {        
        return mensaje = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        <a class=""alert-link"" href=""#"">Error</a><br/>" + mensaje +
                        "<br>" + "</div>";
    }

    public static string eliminarParametroUrl(string url, string key)
    {
        var uri = new Uri(url);

        // this gets all the query string key value pairs as a collection
        var newQueryString = HttpUtility.ParseQueryString(uri.Query);

        // this removes the key if exists
        newQueryString.Remove(key);

        // this gets the page path from root without QueryString
        string pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

        return newQueryString.Count > 0
            ? String.Format("{0}?{1}", pagePathWithoutQueryString, newQueryString)
            : pagePathWithoutQueryString;
    }

    public static string convertirNumeroAMesMasUno(int mes)
    {
        switch (mes)
        {
            case 1:
                return "Febrero";
            case 2:
                return "Marzo";
            case 3:
                return "Abril";
            case 4:
                return "Mayo";
            case 5:
                return "Junio";
            case 6:
                return "Julio";
            case 7:
                return "Agosto";
            case 8:
                return "Septiembre";
            case 9:
                return "Octubre";
            case 10:
                return "Noviembre";
            case 11:
                return "Diciembre";
            case 12:
                return "Enero";
        }
        return "";
    }

    public static Boolean agregarAnio(int mesActual)
    {
        switch (mesActual)
        {           
            case 12:
                return true;
            default:
                return false;
        }        
    }
}