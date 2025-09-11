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

new Persona { Cuil = "20270214100", AgeId = 19294308 },
new Persona { Cuil = "27238110438", AgeId = 19293558 },
new Persona { Cuil = "27168026841", AgeId = 19294962 },
new Persona { Cuil = "27258188492", AgeId = 19296246 },
new Persona { Cuil = "23261612534", AgeId = 19305170 },
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
