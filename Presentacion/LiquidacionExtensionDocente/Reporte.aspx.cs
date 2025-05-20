using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

public partial class PaginasGenerales_Reporte : System.Web.UI.Page
{
    private class Persona
    {
        public string Cuil { get; set; }
        public int AgeId { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Lista de personas (puede venir de un CSV, base de datos, etc.)
        List<Persona> personas = new List<Persona>
{

new Persona { Cuil = "27219684199", AgeId = 18348858 },
new Persona { Cuil = "27221549592", AgeId = 18344751 },
new Persona { Cuil = "20257099777", AgeId = 18347094 },
new Persona { Cuil = "27246403754", AgeId = 18348026 },
new Persona { Cuil = "27244941589", AgeId = 18348879 },
new Persona { Cuil = "27239272385", AgeId = 18349751 },
new Persona { Cuil = "27280489889", AgeId = 18349099 },
new Persona { Cuil = "27290688502", AgeId = 18349437 },
new Persona { Cuil = "24260786403", AgeId = 18347226 },
new Persona { Cuil = "27180899273", AgeId = 18344390 },
new Persona { Cuil = "20181024128", AgeId = 18344391 },
new Persona { Cuil = "20220089151", AgeId = 18345064 },
new Persona { Cuil = "20205898140", AgeId = 18345869 },
new Persona { Cuil = "23246963584", AgeId = 18346495 },
new Persona { Cuil = "27255960496", AgeId = 18349202 },
new Persona { Cuil = "27294444942", AgeId = 18349631 },
new Persona { Cuil = "20262622992", AgeId = 18347529 },
new Persona { Cuil = "20181845148", AgeId = 18345381 },
new Persona { Cuil = "27226698081", AgeId = 18346250 },
new Persona { Cuil = "20254460703", AgeId = 18346289 },
new Persona { Cuil = "27201524682", AgeId = 18347157 },
new Persona { Cuil = "27284330876", AgeId = 18348124 },
new Persona { Cuil = "27323146662", AgeId = 18350516 },
new Persona { Cuil = "27255426503", AgeId = 18350540 },
new Persona { Cuil = "20241898645", AgeId = 18350894 },
new Persona { Cuil = "27288298462", AgeId = 18352127 },
new Persona { Cuil = "27366418127", AgeId = 18352563 },
new Persona { Cuil = "27298371435", AgeId = 18352995 },
new Persona { Cuil = "27206728413", AgeId = 18353007 },
new Persona { Cuil = "27298109668", AgeId = 18353022 },
new Persona { Cuil = "23263857984", AgeId = 18358420 },
new Persona { Cuil = "27265700743", AgeId = 18365614 },
new Persona { Cuil = "27137753133", AgeId = 18365974 },
new Persona { Cuil = "27291794128", AgeId = 18351113 },
new Persona { Cuil = "27125316145", AgeId = 18352358 },
new Persona { Cuil = "27326885636", AgeId = 18353591 },
new Persona { Cuil = "27323704266", AgeId = 18353597 },
new Persona { Cuil = "27219684199", AgeId = 18354157 },
new Persona { Cuil = "27265700743", AgeId = 18354395 },
new Persona { Cuil = "27224461033", AgeId = 18354762 },
new Persona { Cuil = "27347842015", AgeId = 18354041 },
new Persona { Cuil = "20218970533", AgeId = 18354047 },
new Persona { Cuil = "27308279869", AgeId = 18354305 },
new Persona { Cuil = "23313053164", AgeId = 18351446 },
new Persona { Cuil = "20259646058", AgeId = 18350998 },
new Persona { Cuil = "27318334817", AgeId = 18354217 },
new Persona { Cuil = "27219100839", AgeId = 18349908 },
new Persona { Cuil = "20290125759", AgeId = 18352264 },
new Persona { Cuil = "20175638106", AgeId = 18350655 },
new Persona { Cuil = "20263468628", AgeId = 18348135 },
new Persona { Cuil = "27238092138", AgeId = 18348604 },
new Persona { Cuil = "27359414108", AgeId = 18349999 },
new Persona { Cuil = "27201524682", AgeId = 18353493 },
new Persona { Cuil = "27224258998", AgeId = 18344204 },
new Persona { Cuil = "27222487574", AgeId = 18344968 },
new Persona { Cuil = "27221549592", AgeId = 18352983 },
new Persona { Cuil = "20338888318", AgeId = 18350847 },
new Persona { Cuil = "27279135100", AgeId = 18348646 },
new Persona { Cuil = "20336394059", AgeId = 18348672 },
new Persona { Cuil = "27260786496", AgeId = 18346865 },
new Persona { Cuil = "27206728413", AgeId = 18346030 },
new Persona { Cuil = "27298371435", AgeId = 18349489 },
new Persona { Cuil = "27234673691", AgeId = 18345139 },
new Persona { Cuil = "27137753133", AgeId = 18345966 },
new Persona { Cuil = "20236217788", AgeId = 18344635 },
new Persona { Cuil = "27203270289", AgeId = 18358608 },
new Persona { Cuil = "27219101754", AgeId = 18354965 }, 
};


        string reporteRelativo = "~/PaginasBasicas/Reportes/Recibo.rpt";
        string rutaReporte = MapPath(reporteRelativo);

        var appSettings = ConfigurationManager.AppSettings;
        string result = appSettings["ConexionCadena"] ?? "Not Found";
        string[] resultados = result.Split(';');
        string[] ServerName = resultados[5].Split('=');
        string[] DatabaseName = resultados[4].Split('=');
        string[] UserID = resultados[3].Split('=');
        string[] Password = resultados[1].Split('=');

        ConnectionInfo crConnectionInfo = new ConnectionInfo
        {
            ServerName = ServerName[1],
            DatabaseName = DatabaseName[1],
            UserID = UserID[1],
            Password = Password[1]
        };

        string carpetaDestino = @"C:\Temp\ReportesPDF";
        if (!Directory.Exists(carpetaDestino))
        {
            Directory.CreateDirectory(carpetaDestino);
        }

        Dictionary<string, int> cuilCount = new Dictionary<string, int>();

        foreach (var persona in personas)
        {
            ReportDocument cr = new ReportDocument();
            cr.Load(rutaReporte);
            cr.Refresh();

            // Mostrar todos los parámetros disponibles
            foreach (ParameterFieldDefinition paramDef in cr.DataDefinition.ParameterFields)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("> Parámetro encontrado: {0} (Prompt: {1})", paramDef.Name, paramDef.PromptText));
            }

            // Buscar y aplicar el parámetro 'age_id' o '@age_id'
            string[] posiblesNombres = { "age_id", "@age_id" };
            bool parametroAsignado = false;

            // Aplicar al informe principal
            foreach (ParameterFieldDefinition paramDef in cr.DataDefinition.ParameterFields)
            {
                if (Array.Exists(posiblesNombres, name => name == paramDef.Name))
                {
                    ParameterValues Params = new ParameterValues();
                    ParameterDiscreteValue Par = new ParameterDiscreteValue();
                    Par.Value = persona.AgeId;
                    Params.Add(Par);
                    paramDef.ApplyCurrentValues(Params);
                    parametroAsignado = true;
                }
            }

            foreach (Section section in cr.ReportDefinition.Sections)
            {
                foreach (ReportObject reportObject in section.ReportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreport = (SubreportObject)reportObject;
                        ReportDocument subDoc = cr.OpenSubreport(subreport.SubreportName);

                        // Aplicar parámetros al subinforme
                        foreach (ParameterFieldDefinition paramDef in subDoc.DataDefinition.ParameterFields)
                        {
                            if (Array.Exists(posiblesNombres, name => name == paramDef.Name))
                            {
                                ParameterValues Params = new ParameterValues();
                                ParameterDiscreteValue Par = new ParameterDiscreteValue();
                                Par.Value = persona.AgeId;
                                Params.Add(Par);
                                paramDef.ApplyCurrentValues(Params);
                            }
                        }

                        // Aplicar la conexión a cada tabla del subinforme
                        foreach (Table subTable in subDoc.Database.Tables)
                        {
                            TableLogOnInfo crtablelogoninfo = subTable.LogOnInfo;
                            crtablelogoninfo.ConnectionInfo = crConnectionInfo;
                            subTable.ApplyLogOnInfo(crtablelogoninfo);
                        }
                    }
                }
            }

            if (!parametroAsignado)
            {
                throw new Exception("No se encontró el parámetro 'age_id' o '@age_id' en el informe principal.");
            }

            // Aplicar la conexión
            foreach (Table CrTable in cr.Database.Tables)
            {
                TableLogOnInfo crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }

            if (cuilCount.ContainsKey(persona.Cuil))
                cuilCount[persona.Cuil]++;
            else
                cuilCount[persona.Cuil] = 1;

            string cuilConSufijo = cuilCount[persona.Cuil] > 1
                ? string.Format("{0}-{1}", persona.Cuil, cuilCount[persona.Cuil])
                : persona.Cuil;

            string rutaDestino = string.Format(@"{0}\{1}.pdf", carpetaDestino, cuilConSufijo);
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions
            {
                DiskFileName = rutaDestino
            };

            ExportOptions exportOpts = cr.ExportOptions;
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.DestinationOptions = diskOpts;

            try
            {
                cr.Export();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar PDF para CUIL " + persona.Cuil + ": " + ex.Message);
            }
            finally
            {
                cr.Close();
                cr.Dispose();
            }

            GC.Collect();
        }
    }
}
