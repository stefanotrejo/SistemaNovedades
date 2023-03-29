using System;
using System.Data;
using System.IO;
using System.Web;

namespace LiquidacionSueldos.Negocio
{
    public class ArchivoExtDocEducacion
    {
        private Datos.Gestor ocdGestor = new Datos.Gestor();
        private DataTable Results;
        const string Educacion = "EDUCACION";
        const string Ganancias = "GANANCIAS";

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

        public void Generar(int liqID)
        {
            try
            {
                ArchivoExtDocEducacion oAgente = new ArchivoExtDocEducacion();
                Results = new DataTable();

                Results = ocdGestor.EjecutarReader("[ExtensionDocente.Archivo_Educacion]", new object[,] {
                });
                Crear_Archivo_Educacion(Results, GetDestinyPathFile(Educacion, liqID));

                Results = ocdGestor.EjecutarReader("[ExtensionDocente.Archivo_Ganancias]", new object[,] {
                });
                Crear_Archivo_Ganancias(Results, GetDestinyPathFile(Ganancias, liqID));

                //Fila = ocdGestor.EjecutarReader("[ExtensionDocente.Archivo_Ministerio]", new object[,] {
                //});
                //Crear_Archivo_Ministerio(Fila);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Crear_Archivo_Educacion(DataTable dt, string pathFile)
        {
            try
            {
                DeleteFileIfExists(pathFile);

                using (StreamWriter streamWriter = new StreamWriter(pathFile, true))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int cantidad_items = 0;
                        string conceptos_importes = "";

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
                        streamWriter.WriteLine(linea);
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

        protected void Crear_Archivo_Ganancias(DataTable dt, string pathFile)
        {
            try
            {
                DeleteFileIfExists(pathFile);                
                using (StreamWriter streamWriter = new StreamWriter(pathFile, true))
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
                        streamWriter.WriteLine(linea);
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

        protected string GetDestinyPathFile(string archivo, int liqID)
        {
            String fecha_actual = DateTime.Today.ToString("dd/MM/yyyy").Replace('/', '-');
            string directory_path = System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosExtensionDocente");
            string nombre_archivo;

            CreateDirectoryIfNotExists(System.IO.Path.Combine(directory_path, liqID.ToString()));

            switch (archivo)
            {
                case Educacion:
                    nombre_archivo = "extdoc_cge.txt";
                    break;
                case Ganancias:
                    nombre_archivo = "ganancias_extdoc.txt";
                    break;
                default:
                    return "";
            }

            return System.IO.Path.Combine(directory_path, liqID.ToString(), nombre_archivo);
        }

        protected void DeleteFileIfExists(string pathFile)
        {
            if (System.IO.File.Exists(pathFile))
            {
                File.SetAttributes(pathFile, FileAttributes.Normal);
                File.Delete(pathFile);
            }
        }

        protected void CreateDirectoryIfNotExists(string directory)
        {            
            if (Directory.Exists(directory))
            {                
                return;
            }
            
            DirectoryInfo di = Directory.CreateDirectory(directory);
        }
    }



    //        protected void Crear_Archivo_Ministerio(DataTable dt)
    //        {
    //            try
    //            {
    //                String fecha = DateTime.Today.ToString("dd/MM/yyyy").Replace('/', '-');
    //                string Ruta = "C:/temp/extdoc_ministerio";
    //                if (System.IO.File.Exists(Ruta + fecha + ".txt"))
    //                {
    //                    File.SetAttributes(Ruta + fecha + ".txt", FileAttributes.Normal);
    //                    File.Delete(Ruta + fecha + ".txt");
    //                }
    //                using (StreamWriter file = new StreamWriter(Ruta += fecha + ".txt", true))
    //                {
    //                    var delimiter = "\t";
    //                    string line = "";
    //                    foreach (DataColumn column in dt.Columns)
    //                    {
    //                        line = line + string.Join(delimiter, column.ColumnName);
    //                    }
    //                    file.WriteLine(line);

    //                    foreach (DataRow row in dt.Rows)
    //                    {
    //                        for (int i = 0; i < dt.Columns.Count; i++)
    //                        {                            
    //                            file.WriteLine(row[i].ToString());
    //                        }                      
    //                    }
    //                }
    //            }
    //            catch (Exception oError)
    //            {
    //                string error = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //               "</div>";
    //            }
    //        }
    //}
}
