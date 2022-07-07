using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using excelLibreria = Microsoft.Office.Interop.Excel;
using System.IO;

public partial class PaginasPrueba_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string path = "C:\\Excel";
        //string[] fileEntries = Directory.GetFiles(path);
        //foreach (string fileName in fileEntries)
        //{ 
        //    Console.WriteLine(fileName);
        //}
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.PrestacionDineraria objetoPrestacionDineraria = new LiquidacionSueldos.Negocio.PrestacionDineraria();
        string path = "C:\\Test.xls";
        Application excel = new Application();
//        excel.Visible = true;        
        Workbook libroExcel = excel.Workbooks.Open(path);
        Worksheet hojaExcel = (Worksheet)libroExcel.Sheets["Planillas con RIPTE y actualiz"];
        //hojaExcel.Select(Type.Missing);
        Range usedRange = hojaExcel.UsedRange;        
        excelLibreria.Range nombreDamnificado = usedRange.Cells[6, 3] as Range;                
        excelLibreria.Range cuilDamnificado = usedRange.Cells[6, 7] as Range;
        excelLibreria.Range fechaOcurrencia = usedRange.Cells[7, 3] as Range;
        excelLibreria.Range fechaLiquidacion = usedRange.Cells[15, 3] as Range;
        excelLibreria.Range montoFinal = usedRange.Cells[70, 8] as Range;

        objetoPrestacionDineraria.pdiNombre= nombreDamnificado.Value2.ToString();
        objetoPrestacionDineraria.pdiCuil= cuilDamnificado.Value2.ToString();
        objetoPrestacionDineraria.pdiFechaOcurrencia = Convert.ToDateTime(fechaOcurrencia.Value.ToString());
        objetoPrestacionDineraria.pdiFechaLiquidacion = Convert.ToDateTime(fechaLiquidacion.Value.ToString());
        decimal montoFinalDecimal = Convert.ToDecimal(montoFinal.Value2.ToString());
        string montoFinalPesosArgentinos = montoFinalDecimal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-AR"));
        objetoPrestacionDineraria.pdiDiferencia = Convert.ToDecimal(montoFinalPesosArgentinos.Substring(1));
        objetoPrestacionDineraria.pdiActivo = 1;

        //if (obtenervalidarrepetido)
        objetoPrestacionDineraria.Insertar();

        //String nombreDamnificadoFormateado = nombreDamnificado.Value2.ToString();        
        //String cuilDamnificadoFormateado = cuilDamnificado.Value2.ToString();
        //String fechaOcurrenciaFormateado = fechaOcurrencia.Value2.ToString();
        //String fechaLiquidacionFormateado = fechaLiquidacion.Value2.ToString();
        //String montoFinalFormateado = montoFinal.Value2.ToString();
        //decimal montoFinalDecimal = Convert.ToDecimal(montoFinalFormateado);        
        //string montoFinalPesosArgentinos = montoFinalDecimal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-AR"));        
        libroExcel.Close();
    }   
}