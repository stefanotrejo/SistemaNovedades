using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using LiquidacionSueldos.Datos;
using System.IO;

namespace LiquidacionSueldos.Negocio
{
    public class ArchivoExtDocEducacion
    {
        private Datos.Gestor ocdGestor = new Datos.Gestor();
        private DataTable Fila;
        private DataTable Tabla = new DataTable();

        #region Propiedades
        public string NroCOntrol { get; set; }
        public string PlantaTipo { get; set; }
        public string LugarPago { get; set; }
        public string Escuela { get; set; }
        public string Juris { get; set; }
        public string Prog { get; set; }
        public string SubP { get; set; }
        public string Actividad { get; set; }
        public string fuente { get; set; }
        public string dias_trabajados { get; set; }
        public string haberSinAporte { get; set; }
        public string haberConAporte { get; set; }
        public string total_haberes { get; set; }
        public string total_descuentos { get; set; }
        public string total_liquido { get; set; }
        public string C01 { get; set; }
        public string I01 { get; set; }
        public string C02 { get; set; }
        public string I02 { get; set; }
        public string C03 { get; set; }
        public string I03 { get; set; }
        public string C04 { get; set; }
        public string I04 { get; set; }
        public string C05 { get; set; }
        public string I05 { get; set; }
        public string C06 { get; set; }
        public string I06 { get; set; }
        public string C07 { get; set; }
        public string I07 { get; set; }
        public string C08 { get; set; }
        public string I08 { get; set; }

        #endregion

        // METODOS //

        // INICIO - Importacion de Agentes

        public void ObtenerAgentesExtDoc()
        {
            try
            {
                ArchivoExtDocEducacion oAgente = new ArchivoExtDocEducacion();
                Fila = new DataTable();
                Fila = ocdGestor.EjecutarReader("[ExtensionDocente.Archivo_Educacion]", new object[,] {
                });
                Crear_Archivo_Educacion(Fila);

                Fila = ocdGestor.EjecutarReader("[ExtensionDocente.Archivo_Ganancias]", new object[,] {
                }); 
                Crear_Archivo_Ganancias(Fila);
                /*
                if (Fila.Rows.Count > 0)
                {
                    if (Fila.Rows[0]["NroCOntrol"].ToString().Trim().Length > 0)
                    {
                        oAgente.NroCOntrol = Convert.ToString(Fila.Rows[0]["NroCOntrol"]);
                    }

                    if (Fila.Rows[0]["PlantaTipo"].ToString().Trim().Length > 0)
                    {
                        oAgente.PlantaTipo = Convert.ToString(Fila.Rows[0]["PlantaTipo"]);
                    }

                    if (Fila.Rows[0]["LugarPago"].ToString().Trim().Length > 0)
                    {
                        oAgente.LugarPago = Convert.ToString(Fila.Rows[0]["LugarPago"]);
                    }

                    if (Fila.Rows[0]["Escuela"].ToString().Trim().Length > 0)
                    {
                        oAgente.Escuela = Convert.ToString(Fila.Rows[0]["Escuela"]);
                    }

                    if (Fila.Rows[0]["Juris"].ToString().Trim().Length > 0)
                    {
                        oAgente.Juris = Convert.ToString(Fila.Rows[0]["Juris"]);
                    }

                    if (Fila.Rows[0]["Prog"].ToString().Trim().Length > 0)
                    {
                        oAgente.Prog = Convert.ToString(Fila.Rows[0]["Prog"]);
                    }
                    if (Fila.Rows[0]["SubP"].ToString().Trim().Length > 0)
                    {
                        oAgente.SubP = Convert.ToString(Fila.Rows[0]["SubP"]);
                    }
                    if (Fila.Rows[0]["Actividad"].ToString().Trim().Length > 0)
                    {
                        oAgente.Actividad = Convert.ToString(Fila.Rows[0]["Actividad"]);
                    }

                    if (Fila.Rows[0]["fuente"].ToString().Trim().Length > 0)
                    {
                        oAgente.fuente = Convert.ToString(Fila.Rows[0]["fuente"]);
                    }

                    if (Fila.Rows[0]["dias_trabajados"].ToString().Trim().Length > 0)
                    {
                        oAgente.dias_trabajados = Convert.ToString(Fila.Rows[0]["dias_trabajados"]);
                    }

                    if (Fila.Rows[0]["haberSinAporte"].ToString().Trim().Length > 0)
                    {
                        oAgente.haberSinAporte = Convert.ToString(Fila.Rows[0]["haberSinAporte"]);
                    }

                    if (Fila.Rows[0]["haberConAporte"].ToString().Trim().Length > 0)
                    {
                        oAgente.haberConAporte = Convert.ToString(Fila.Rows[0]["haberConAporte"]);
                    }

                    if (Fila.Rows[0]["total_haberes"].ToString().Trim().Length > 0)
                    {
                        oAgente.total_haberes = Convert.ToString(Fila.Rows[0]["total_haberes"]);
                    }

                    if (Fila.Rows[0]["total_descuentos"].ToString().Trim().Length > 0)
                    {
                        oAgente.total_descuentos = Convert.ToString(Fila.Rows[0]["total_descuentos"]);
                    }

                    if (Fila.Rows[0]["total_liquido"].ToString().Trim().Length > 0)
                    {
                        oAgente.total_liquido = Convert.ToString(Fila.Rows[0]["total_liquido"]);
                    }

                    if (Fila.Rows[0]["C01"].ToString().Trim().Length > 0)
                    {
                        oAgente.C01 = Convert.ToString(Fila.Rows[0]["C01"]);
                    }

                    if (Fila.Rows[0]["I01"].ToString().Trim().Length > 0)
                    {
                        oAgente.I01 = Convert.ToString(Fila.Rows[0]["I01"]);
                    }

                    if (Fila.Rows[0]["C02"].ToString().Trim().Length > 0)
                    {
                        oAgente.C02 = Convert.ToString(Fila.Rows[0]["C02"]);
                    }

                    if (Fila.Rows[0]["I02"].ToString().Trim().Length > 0)
                    {
                        oAgente.I02 = Convert.ToString(Fila.Rows[0]["I02"]);
                    }

                    if (Fila.Rows[0]["C03"].ToString().Trim().Length > 0)
                    {
                        oAgente.C03 = Convert.ToString(Fila.Rows[0]["C03"]);
                    }

                    if (Fila.Rows[0]["I03"].ToString().Trim().Length > 0)
                    {
                        oAgente.I03 = Convert.ToString(Fila.Rows[0]["I03"]);
                    }

                    if (Fila.Rows[0]["C04"].ToString().Trim().Length > 0)
                    {
                        oAgente.C04 = Convert.ToString(Fila.Rows[0]["C04"]);
                    }

                    if (Fila.Rows[0]["I04"].ToString().Trim().Length > 0)
                    {
                        oAgente.I04 = Convert.ToString(Fila.Rows[0]["I04"]);
                    }

                    if (Fila.Rows[0]["C05"].ToString().Trim().Length > 0)
                    {
                        oAgente.C05 = Convert.ToString(Fila.Rows[0]["C05"]);
                    }

                    if (Fila.Rows[0]["I05"].ToString().Trim().Length > 0)
                    {
                        oAgente.I05 = Convert.ToString(Fila.Rows[0]["I05"]);
                    }

                    if (Fila.Rows[0]["C06"].ToString().Trim().Length > 0)
                    {
                        oAgente.C06 = Convert.ToString(Fila.Rows[0]["C06"]);
                    }

                    if (Fila.Rows[0]["I06"].ToString().Trim().Length > 0)
                    {
                        oAgente.I06 = Convert.ToString(Fila.Rows[0]["I06"]);
                    }

                    if (Fila.Rows[0]["C07"].ToString().Trim().Length > 0)
                    {
                        oAgente.C07 = Convert.ToString(Fila.Rows[0]["C07"]);
                    }

                    if (Fila.Rows[0]["I07"].ToString().Trim().Length > 0)
                    {
                        oAgente.I07 = Convert.ToString(Fila.Rows[0]["I07"]);
                    }

                    if (Fila.Rows[0]["C08"].ToString().Trim().Length > 0)
                    {
                        oAgente.C08 = Convert.ToString(Fila.Rows[0]["C08"]);
                    }

                    if (Fila.Rows[0]["I08"].ToString().Trim().Length > 0)
                    {
                        oAgente.I08 = Convert.ToString(Fila.Rows[0]["I08"]);
                    }
                    
                }
                return oAgente;*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Crear_Archivo_Educacion(DataTable dt)
        {
            try
            {
                String fecha = DateTime.Today.ToString("dd/MM/yyyy").Replace('/', '-');
                string Ruta = "C:/temp/extdoc_cge";
                if (System.IO.File.Exists(Ruta + fecha + ".txt"))
                {
                    File.SetAttributes(Ruta + fecha + ".txt", FileAttributes.Normal);
                    File.Delete(Ruta + fecha + ".txt");
                }
                using (StreamWriter file = new StreamWriter(Ruta += fecha + ".txt", true))
                {
                    foreach (DataRow row in dt.Rows)
                    {                                                
                        int cantidad_items = 0;
                        string conceptos_importes = "";
                        string prueba = row["C01"].ToString();

                        if (row["C01"].ToString().Trim().Length > 0
                            && row["I01"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C01"].ToString().Trim()
                                                + row["I01"].ToString().Trim();
                        }

                        if (row["C02"].ToString().Trim().Length > 0
                           && row["I02"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C02"].ToString().Trim()
                                                + row["I02"].ToString().Trim();
                        }

                        if (row["C03"].ToString().Trim().Length > 0
                             && row["I03"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C03"].ToString().Trim()
                                                + row["I03"].ToString().Trim();
                        }

                        if (row["C04"].ToString().Trim().Length > 0
                             && row["I04"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C04"].ToString().Trim()
                                                + row["I04"].ToString().Trim();
                        }
                        
                        if (row["C05"].ToString().Trim().Length > 0
                              && row["I05"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C05"].ToString().Trim()
                                                + row["I05"].ToString().Trim();
                        }

                        if (row["C06"].ToString().Trim().Length > 0
                              && row["I06"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C06"].ToString().Trim()
                                                + row["I06"].ToString().Trim();
                        }

                        if (row["C07"].ToString().Trim().Length > 0
                              && row["I07"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C07"].ToString().Trim()
                                                + row["I07"].ToString().Trim();
                        }

                        if (row["C08"].ToString().Trim().Length > 0
                              && row["I08"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C08"].ToString().Trim()
                                                + row["I08"].ToString().Trim();
                        }

                        string cantidad_items_string = cantidad_items.ToString();
                        if (cantidad_items < 10)
                            cantidad_items_string = "0" + cantidad_items;

                        string linea = row["encabezado"].ToString().Trim() + cantidad_items_string + conceptos_importes;
                        file.WriteLine(linea);

                    }
                }                
            }
            catch (Exception oError)
            {
                string error = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
               "</div>";
            }
        }

        protected void Crear_Archivo_Ganancias(DataTable dt)
        {
            try
            {
                String fecha = DateTime.Today.ToString("dd/MM/yyyy").Replace('/', '-');
                string Ruta = "C:/temp/ganancias_extdoc";
                if (System.IO.File.Exists(Ruta + fecha + ".txt"))
                {
                    File.SetAttributes(Ruta + fecha + ".txt", FileAttributes.Normal);
                    File.Delete(Ruta + fecha + ".txt");
                }
                using (StreamWriter file = new StreamWriter(Ruta += fecha + ".txt", true))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int cantidad_items = 0;
                        string conceptos_importes = "";
                        string prueba = row["C01"].ToString();

                        if (row["C01"].ToString().Trim().Length > 0
                            && row["I01"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C01"].ToString().Trim()
                                                + row["I01"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        if (row["C02"].ToString().Trim().Length > 0
                           && row["I02"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C02"].ToString().Trim()
                                                + row["I02"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim(); 

                        }

                        if (row["C03"].ToString().Trim().Length > 0
                             && row["I03"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C03"].ToString().Trim()
                                                + row["I03"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        if (row["C04"].ToString().Trim().Length > 0
                             && row["I04"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C04"].ToString().Trim()
                                                + row["I04"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        if (row["C05"].ToString().Trim().Length > 0
                              && row["I05"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C05"].ToString().Trim()
                                                + row["I05"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        if (row["C06"].ToString().Trim().Length > 0
                              && row["I06"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C06"].ToString().Trim()
                                                + row["I06"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        if (row["C07"].ToString().Trim().Length > 0
                              && row["I07"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C07"].ToString().Trim()
                                                + row["I07"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        if (row["C08"].ToString().Trim().Length > 0
                              && row["I08"].ToString().Trim() != "000000000")
                        {
                            cantidad_items++;
                            conceptos_importes = conceptos_importes
                                                + row["C08"].ToString().Trim()
                                                + row["I08"].ToString().Trim()
                                                + row["numero_cuota"].ToString().Trim() + row["total_cuota"].ToString().Trim();
                        }

                        string cantidad_items_string = cantidad_items.ToString();
                        if (cantidad_items < 10)
                            cantidad_items_string = "0" + cantidad_items;

                        string linea = row["encabezado"].ToString().Trim() + cantidad_items_string + conceptos_importes;
                        file.WriteLine(linea);

                    }
                }
            }
            catch (Exception oError)
            {
                string error = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
               "</div>";
            }
        }

    }
}
