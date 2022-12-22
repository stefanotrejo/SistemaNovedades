using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using Clases = LiquidacionSueldos.Negocio;
using System.Net;

public static class Globals
{
    public const Int32 BUFFER_SIZE = 10; // Unmodifiable
    public static String FILE_NAME = "Output.txt"; // Modifiable
    public static readonly String CODE_PREFIX = "US-"; // Unmodifiable
    public static readonly String TituloDelFormulario = "Carga de Novedades Docentes"; // Unmodifiable        
}

//                       CONSULTA DE NOVEDADES: SE UTILIZARÁ PARA CONSULTAR NOVEDADES HISTORICAS                         // 

/*Notas:
 * Los datos ingresados por el usuario se guardan en variables de Sesion y luego en variables globales, las cuales 
 * se envian por get cuando se hace click en algun resultado del datatable. Estos parametros se vuelven a recibir
 * por variabls globales al hacer click en el boton volver del formulario "NovedadesNuevo".

 */

public partial class UsuarioRegistracion : System.Web.UI.Page
{

    #region Variables 

    DataTable dt, dt2, listaJurisdiccion = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
    LiquidacionSueldos.Negocio.LiquidacionExtensionDocente oLiquidacionExtDoc = new LiquidacionSueldos.Negocio.LiquidacionExtensionDocente();
    LiquidacionSueldos.Negocio.Jurisdiccion oJurisdiccion = new LiquidacionSueldos.Negocio.Jurisdiccion();
    LiquidacionSueldos.Negocio.NovedadInasistencia oNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();
    LiquidacionSueldos.Negocio.NovedadExtensionDocente oNovedadExtDoc = new LiquidacionSueldos.Negocio.NovedadExtensionDocente();

    int mesActual, anioActualInt;
    String mesActualString, anioActualString;
    Boolean agregarAnio;

    //   Variables Globales

    public class GlobalesNovedadesConsulta
    {
        private static string _NroControl;
        public static string NroControl
        {
            get
            {
                return _NroControl;
            }
            set
            {
                _NroControl = value;
            }
        }

        private static string _Sesion;
        public static string SesionAgenteConsulta
        {
            get
            {
                return _Sesion;
            }
            set
            {
                _Sesion = value;
            }
        }

        private static int _radioSeleccionado;
        public static int radioSeleccionado
        {
            get
            {
                return _radioSeleccionado;
            }
            set
            {
                _radioSeleccionado = value;
            }
        }

        private static int _pageIndex;
        public static int pageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        private static string _mesAnioLiq;
        public static string mesAnioLiq
        {
            get
            {
                return _mesAnioLiq;
            }
            set
            {
                _mesAnioLiq = value;
            }
        }

        private static int _liqId;
        public static int liqId
        {
            get
            {
                return _liqId;
            }
            set
            {
                _liqId = value;
            }
        }

        private static int _novedadId;
        public static int novedadId
        {
            get
            {
                return _novedadId;
            }
            set
            {
                _novedadId = value;
            }
        }        
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.TituloDelFormulario = Globals.TituloDelFormulario;
        habilitarDeshabilitarBotones(false);
        try
        {
            this.Session["usuId"] = int.Parse(this.Session["_usuId"].ToString());

            /*En Session: guardo los valores actuales seleccionados por el usuario para recargarlos cuando vuelva 
            * desde otra pagina (POSTBACK). Es vacio cuando carga por primera vez la pagina*/

            #region Verificar Liquidaciones Abiertas para Docentes
            // Liquidaciones
            oLiquidacionExtDoc = liquidacionAbierta();

            lblLiquidacion.Text = "";
            lblEtapa.Text = "";

            btnGenerarArchivo.Visible = false;

            // Si no hay liquidaciones abiertas
            if (oLiquidacionExtDoc == null)
            {
                lblLiquidacion.Text = "No hay liquidaciones abiertas";
                lblEtapa.Visible = false;
                lblEtapa.Visible = false;
                btnConsultar1.Enabled = false;
                btnAceptar1.Visible = false;
            }
            else
            {
                Session["mesAnioLiq"] = oLiquidacionExtDoc.mesanio;
                Session["liqId"] = oLiquidacionExtDoc.id;
                btnDescargarArchivos.Visible = false;
                lblLiquidacion.Text = "Liquidacion (inicio de mes): " + oLiquidacionExtDoc.mesanio;
                mesActual = Convert.ToInt32(oLiquidacionExtDoc.mesanio.Substring(0, 2));
                mesActualString = FuncionesUtiles.convertirNumeroAMesMasUno(mesActual);

                anioActualString = DateTime.Now.ToString().Substring(6, 4);
                if (FuncionesUtiles.agregarAnio(mesActual))
                {
                    anioActualInt = Int32.Parse(oLiquidacionExtDoc.anio.ToString()) + 1;
                    anioActualString = DateTime.Now.ToString().Substring(6, 2) + anioActualInt.ToString();
                }

                string separador = " ";

                lblEtapa.Text = "Etapa: " + oLiquidacionExtDoc.etapa.ToString() + separador + "del mes de" + separador + mesActualString + separador + "del" + separador + anioActualString;
                if (oLiquidacionExtDoc.fechaCierre < DateTime.Now)
                {
                    lblFechaCierre.Text = "No Disponible";
                }
                else
                {
                    lblFechaCierre.Text = oLiquidacionExtDoc.fechaCierre.ToString().Substring(0, 16) + " hs";
                    lblFechaCierre.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }

            #endregion

            if (String.IsNullOrEmpty(Session["textBox"].ToString()))
            {
                //Cuando se carga la pagina por primera vez y cuando vuelve de otra pagina (NO ES POSTBACK)
                if (!Page.IsPostBack)
                {
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                    this.RadioNumeroControl.Checked = true;
                    Session["radioSeleccionado"] = 1;
                }
                // Cuando es postback!
                else
                {
                    if (Session["periodo"].ToString() != null && Session["periodo"].ToString() != "")
                    {
                        try
                        {
                            string radioSeleccionado = Session["radioSeleccionado"].ToString();
                            string pageIndex = Session["pageIndex"].ToString();
                            string textBox = Session["textBox"].ToString();

                            Session["radioSeleccionado"] = 1;
                            if (this.Session["radioSeleccionado"].ToString() != "" && this.Session["pageIndex"].ToString() != ""
                                && this.Session["textBox"].ToString() != "")
                            {
                                //Session["mesAnioLiq"] = getLiquidacionAbierta();
                                txtAgeNroControl.Text = Session["textBox"].ToString();
                            }

                            // Radios                                     
                            RadioNumeroControl.Checked = false;
                            //                            RadioApellidoyNombre.Checked = false;
                            //                        RadioDni.Checked = false;
                            /*
                                                    switch (Convert.ToInt32(Session["radioSeleccionado"].ToString()))
                                                    {
                                                        case 1:
                                                            RadioDni.Checked = true;
                                                            break;
                                                        case 2:
                                                            RadioApellidoyNombre.Checked = true;
                                                            break;
                                                        case 3:
                                                            RadioNumeroControl.Checked = true;
                                                            break;
                                                        default:
                                                            RadioDni.Checked = true;
                                                            break;
                                                    }
                                                    */
                            // Esto estaba activado para cargar nuevamente la grilla con resultados
                            //GrillaCargar(Convert.ToInt32(Session["index"]), Session["mesAnioLiq"].ToString());
                            //Limpio variables de Session                                                                                    
                            Session["Textbox"] = "";
                        }
                        // EN CASO DE ERROR CON VARIABLES DE SESSION -> CARGAR VALORES POR DEFECTO
                        catch
                        {
                            this.Master.TituloDelFormulario = Globals.TituloDelFormulario;
                            if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                        }
                    }
                    // autopostback de los componentes
                    else
                    {
                    }
                }
            }

            // Cuando vuelve de otra pagina y hay que recargar los datos como estaban antes
            /*
            else
            {
                try
                {
                    // Session["mesAnioLiq"] = getLiquidacionAbierta();
                    txtAgeNroControl.Text = Session["textBox"].ToString();

                    // Seteo el radio que estaba seleccionado anteriormente
                    if (Session["radioSeleccionado"].ToString() != null && (Session["radioSeleccionado"].ToString() != ""))
                    {
                        switch (Convert.ToInt32(Session["radioSeleccionado"].ToString()))
                        {
                            case 1:
                                RadioDni.Checked = true;
                                break;
                            case 2:
                                RadioApellidoyNombre.Checked = true;
                                break;
                            case 3:
                                RadioNumeroControl.Checked = true;
                                break;
                            default:
                                RadioDni.Checked = true;
                                break;
                        }
                    }
                    // Si ocurre algun error con los radios, pongo por defecto DNI
                    else
                    {
                        RadioDni.Checked = true;
                        Session["radioSeleccionado"] = 1;
                    }
                    // Antes estaba activado para cargar grilla automaticamente
                    //GrillaCargar(Convert.ToInt32(Session["pageIndex"].ToString()), Session["mesAnioLiq"].ToString());
                }
                catch
                {
                    // EN CASO DE ERROR CON VARIABLES DE SESSION -> CARGAR VALORES POR DEFECTO
                    this.Master.TituloDelFormulario = Globals.TituloDelFormulario;
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                }
            }
            */
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
"</div>";
        }
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
            Boolean errores = false;            
            habilitarDeshabilitarBotones(false);

            /*
             // Validaciones
             if (RadioDni.Checked == true)
             {
                 if (txtAgeNroControl.Text.Length != 7 && txtAgeNroControl.Text.Length != 8 && txtAgeNroControl.Text.Length != 11)
                 {
                     lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un DNI o CUIL valido");
                     errores = true;
                 }
             }
             else
             {
                 if (RadioNumeroControl.Checked == true)
                     if (txtAgeNroControl.Text.Length != 8)
                     {
                         lblMensajeError.Text = FuncionesUtiles.MensajeError("El Numero de Control debe contener 8 digitos");
                         errores = true;
                     }
             }
             */

            if (RadioNumeroControl.Checked == true)
                if (txtAgeNroControl.Text.Length != 8)
                {
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("El Numero de Control debe contener 8 digitos");
                    errores = true;
                }

            if (!errores)
            {
                //  getLiquidacionAbierta();
                string mesanio = Session["mesAnioLiq"].ToString();
                DataTable dt = new DataTable();
                dt = ocnAgente.ObtenerAgentesExtDocente(mesanio, txtAgeNroControl.Text, "", "");

                if (dt.Rows.Count == 0)
                {
                    if (RadioNumeroControl.Checked)
                        lblMensajeError.Text = FuncionesUtiles.MensajeError("El Numero de Control ingresado ingresado No existe o pertenece a otra área en el periodo de liquidacion seleccionado");
                }
                else
                {
                    if (dt.Rows[0]["Nombre"].ToString().Trim().Length > 0)
                    {
                        txtNombre.Text = Convert.ToString(dt.Rows[0]["Nombre"]);
                    }
                    else
                    {
                        txtNombre.Text = "";
                    }

                    if (dt.Rows[0]["Cuil"].ToString().Trim().Length > 0)
                    {
                        txtCuil.Text = Convert.ToString(dt.Rows[0]["Cuil"]);
                    }
                    else
                    {
                        txtCuil.Text = "";
                    }

                    if (dt.Rows[0]["Lugar de Pago"].ToString().Trim().Length > 0)
                    {
                        txtLugarPago.Text = Convert.ToString(dt.Rows[0]["Lugar de Pago"]);
                    }
                    else
                    {
                        txtLugarPago.Text = "";
                    }

                    if (dt.Rows[0]["Cargo"].ToString().Trim().Length > 0)
                    {
                        txtCargo.Text = Convert.ToString(dt.Rows[0]["Cargo"]);
                    }
                    else
                    {
                        txtCargo.Text = "";
                    }

                    btnAceptar1.Visible = true;  
                    GlobalesNovedadesConsulta.novedadId = oNovedadExtDoc.ValidarRepetido(oLiquidacionExtDoc.id, txtAgeNroControl.Text);
                    if (GlobalesNovedadesConsulta.novedadId != 0)
                    {
                        btnEliminar.Visible = true;
                        btnAceptar1.Visible = false;
                    }                    
                }
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
            Se ha producido el siguiente error:<br/>
            MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
            "</div>";
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombre.Text == "")
            {
                this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un Agente");
            }
            else
            {
                this.lblMensajeError.Text = "";
                oLiquidacionExtDoc = liquidacionAbierta();

                oNovedadExtDoc.ageId = 0; // lo actualizamos por b.d
                oNovedadExtDoc.ageNrocontrol = txtAgeNroControl.Text;
                oNovedadExtDoc.dias_descontar = 30;
                oNovedadExtDoc.liqId = oLiquidacionExtDoc.id;
                oNovedadExtDoc.usuId = Convert.ToInt32(this.Session["usuId"].ToString());
                oNovedadExtDoc.usuCrea_id = oNovedadExtDoc.usuId;

                if (oNovedadExtDoc.ValidarRepetido(oLiquidacionExtDoc.id, txtAgeNroControl.Text) != 0)
                {
                    this.lblMensajeError.Text = FuncionesUtiles.MensajeError("La Novedad ingresada ya existe en el Sistema");
                    return;
                }

                oNovedadExtDoc.Insertar();
                base.Response.Redirect(base.Request.UrlReferrer.ToString(), true);
                return;
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
            Se ha producido el siguiente error:<br/>
            MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
            "</div>";
        }
    }

    protected LiquidacionSueldos.Negocio.LiquidacionExtensionDocente liquidacionAbierta()
    {
        oLiquidacionExtDoc = new LiquidacionSueldos.Negocio.LiquidacionExtensionDocente();
        oLiquidacionExtDoc = oLiquidacionExtDoc.ObtenerLiquidacionAbierta();
        return oLiquidacionExtDoc;
    }

    protected void btnDescargarArchivos_Click(object sender, EventArgs e)
    {

        int reparticion = Convert.ToInt32(Session["_esAdministrador"]);
        if (reparticion == 5)
            reparticion = 2;


        int liqId = Convert.ToInt32(Session["liqId"].ToString());
        Response.Redirect("descargas.aspx?liquidacion=" + Convert.ToInt32(Session["liqId"].ToString())
              + "&reparticion=" + reparticion, true);

        /*
       string nombreArchivo = "RLSTNOPE.txt";        
       string rutaVirtual = "~/Novedades/ArchivosNoPresentismo/" + liqId.ToString() + "/" + reparticion.ToString() + "/" + nombreArchivo;
       string rutaFisica = System.Web.HttpContext.Current.Server.MapPath(rutaVirtual);                 
       string fileName = Path.GetFileName(rutaFisica);
       string fileExt = Path.GetExtension(rutaFisica);

       // Determina el contenido del archivo
       string type = "";        
       if (fileExt != null)
       {
           switch (fileExt.ToLower())
           {
               case ".htm":
               case ".html":
                   type = "text/HTML";
                   break;

               case ".txt":
                   type = "text/plain";
                   break;

               case ".doc":
               case ".rtf":
                   type = "Application/msword";
                   break;

               default:
                   type = "application/octet-stream";
                       break;
           }
       }
            if (type != "")
                   Response.ContentType = type;

       // Fin - Determina el contenido del archivo
       */
    }

    protected void btnGenerarArchivo_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            int reparticion = Convert.ToInt32(Session["_esAdministrador"]);
            if (reparticion == 5)
                reparticion = 2;

            int liqId = Convert.ToInt32(Session["liqId"].ToString());
            dt = oNovedadInasistencia.GenerarListadoTestigoNoPresentismo(liqId, reparticion);

            // Inicio - Genercion de Archivos No Presentismo
            string nombreArchivo = "RLSTNOPE.txt";
            String path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo"), liqId.ToString(), reparticion.ToString());
            String pathConNombreArchivo = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo"), liqId.ToString(), reparticion.ToString(), nombreArchivo);

            // Si no existe el directorio, lo creo
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Si existe el archivo, lo elimino
            if (System.IO.File.Exists(pathConNombreArchivo))
            {
                File.SetAttributes(pathConNombreArchivo, FileAttributes.Normal);
                File.Delete(pathConNombreArchivo);
            }

            // Defino donde guardar el archivo que estoy generando
            using (StreamWriter file = new StreamWriter(pathConNombreArchivo, true))
            {
                // Inicio - Encabezado                
                string paramFecha = DateTime.Now.ToString("dd/MM/yyyy");
                string titulo = "LISTADO TESTIGO PERSONAL SIN PRESENTISMO";
                string linea = paramFecha.PadRight(15) + titulo + "P g.".PadLeft(10);
                file.WriteLine(linea);

                string lineaVacia = Environment.NewLine;
                file.WriteLine(lineaVacia);
                // Fin - Encabezado

                // Inicio - Titulo columnas
                linea = "".PadRight(10) + "Nro Control".PadLeft(10) + "Planta".PadLeft(10) + "Mes".PadLeft(11) + "Anio".PadLeft(12);
                file.WriteLine(linea);
                // Fin - Titulo columnas

                int totalPlantaContratada = 0;
                int totalPlantaPermanente = 0;

                foreach (DataRow row in dt.Rows)
                {
                    List<string> items = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        items.Add(row[col].ToString());
                    }
                    linea = linea = "".PadRight(10) + string.Join("".PadLeft(10), items.ToArray());
                    file.WriteLine(linea);

                    if (row["planta"].ToString() == "C")
                        totalPlantaContratada++;
                    else
                        totalPlantaPermanente++;
                }

                file.WriteLine(lineaVacia);
                file.WriteLine(lineaVacia);
                file.WriteLine(lineaVacia);

                // Totales
                string tituloTotalRegistros = "TOTAL DE REGISTROS:";
                file.WriteLine("".PadRight(9) + tituloTotalRegistros + (totalPlantaContratada + totalPlantaPermanente).ToString().PadLeft(10));
                file.WriteLine(lineaVacia);
                string tituloPlantaContratada = "Planta Contratada:";
                file.WriteLine("".PadRight(10) + tituloPlantaContratada + totalPlantaContratada.ToString().PadLeft(10));
                file.WriteLine(lineaVacia);
                string tituloPlantaPermanente = "Planta Permanente:";
                file.WriteLine("".PadRight(10) + tituloPlantaPermanente + totalPlantaPermanente.ToString().PadLeft(10));
                file.WriteLine(lineaVacia);
            }

            // FIN - GENERACION DE ARCHIVOS

            /*
            string fileName = "~/Novedades/ArchivosNoPresentismo/" + liqId.ToString() + "/" + reparticion.ToString() + "/" + nombreArchivo;

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + nombreArchivo);

            string forma1 = System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo/" + liqId.ToString() + "/" + reparticion.ToString() + "/" + nombreArchivo);
            string forma2 = fileName;

            Response.WriteFile(forma1);



            Response.ContentType = "";
            Response.End();

            /*
            // Prompts user to save file
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo + ";");
            string fileToDownload = System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo/" + liqId.ToString() + "/" + reparticion.ToString() + "/" + nombreArchivo);
            response.TransmitFile(fileToDownload);

            //response.TransmitFile(path + "/" + nombreArchivo);
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();




            /*FuncionesUtiles.AbreVentana(url);
            Response.WriteFile(yourData, 0, yourData.Length);

            Response.ContentType = "text/plain";
            Response.OutputStream.Write(buffer, 0, buffer.Length);
            Response.AddHeader("Content-Disposition", "attachment;filename=yourfile.txt");
            Response.Redirect(path, false);*/




            // FIN - DESCARGA DE TXT



        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
           "</div>";
        }

    }

    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

    protected void CrearArchivo(DataTable dt, int codigoInforme, int etapa)
    {
        try
        {
            /* Codigos de Informe:
             * 1 - > NO PRESENTISMO 
             * 2 - > MULTAS Y SUSPENSIONES 
             * 3 - > BAJAS             
             */

            string Ruta = "C:/";
            string nombreArchivo;
            string fecha = DateTime.Today.ToString("dd/MM/yyyy").Replace('/', '-');

            // RECIBIR NUMERO DE ETAPA 
            if (codigoInforme == 1)
                nombreArchivo = "NOPRESEN";
            else
            {
                nombreArchivo = "MULSUS";
                // "PMULPC.1" o PMULPC.2 o PMULPC.3

                // BAJAS
                // PEPERSPC.1 O .2 O .3
            }

            if (System.IO.File.Exists(Ruta + nombreArchivo + fecha + ".txt"))
            {
                File.SetAttributes(Ruta + nombreArchivo + fecha + ".txt", FileAttributes.Normal);
                File.Delete(Ruta + nombreArchivo + fecha + ".txt");
            }

            using (StreamWriter file = new StreamWriter(Ruta += fecha + ".txt", true))
            {
                foreach (DataRow row in dt.Rows)
                {
                    List<string> items = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        items.Add(row[col].ToString());
                    }
                    string linea = string.Join("|", items.ToArray());
                    file.WriteLine(linea);
                }
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
Se ha producido el siguiente error:<br/>
MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
           "</div>";
        }

    }

    //protected void RadioDni_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool var1 = RadioDni.Checked;
    //    bool var2 = RadioApellidoyNombre.Checked;
    //    bool var3 = RadioNumeroControl.Checked;

    //    Session["radioSeleccionado"] = 1;
    //    RadioNumeroControl.Checked = false;
    //    RadioApellidoyNombre.Checked = false;

    //    //RadioDni.Checked = true;
    //    this.txtAgeNroControl.Text = "";
    //    this.txtAgeNroControl.Focus();
    //}

    //protected void RadioApellidoyNombre_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool var1 = RadioDni.Checked;
    //    bool var2 = RadioApellidoyNombre.Checked;
    //    bool var3 = RadioNumeroControl.Checked;

    //    Session["radioSeleccionado"] = 2;
    //    RadioNumeroControl.Checked = false;
    //    RadioDni.Checked = false;
    //    RadioApellidoyNombre.Checked = true;
    //    this.txtAgeNroControl.Text = "";
    //    this.txtAgeNroControl.Focus();
    //}

    protected void RadioNumeroControl_CheckedChanged(object sender, EventArgs e)
    {
        //bool var1 = RadioDni.Checked;
        //bool var2 = RadioApellidoyNombre.Checked;
        bool var3 = RadioNumeroControl.Checked;

        Session["radioSeleccionado"] = 3;
        //RadioDni.Checked = false;
        //RadioApellidoyNombre.Checked = false;
        RadioNumeroControl.Checked = true;
        this.txtAgeNroControl.Text = "";
        this.txtAgeNroControl.Focus();
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        int reparticion;
        if (Convert.ToInt32(Session["_esAdministrador"]) == 5)
            reparticion = 2;
        else
            reparticion = Convert.ToInt32(Session["_esAdministrador"]);

        String NomRep = "NovedadesCargadasExtDoc.rpt";
        FuncionesUtiles.AbreVentana("Reporte.aspx?liqId="
            + Session["liqId"].ToString()
                + "&NomRep=" + NomRep);
    }

    protected void btnListarPorUsuario_Click(object sender, EventArgs e)
    {
        int reparticion;
        if (Convert.ToInt32(Session["_esAdministrador"]) == 5)
            reparticion = 2;
        else
            reparticion = Convert.ToInt32(Session["_esAdministrador"]);

        String NomRep = "InformeNovedadesCargadasPorUsuario.rpt";
        FuncionesUtiles.AbreVentana("Reporte.aspx?liqId=" + Convert.ToInt32(Session["liqId"].ToString())
            + "&reparticion=" + reparticion
                + "&NomRep=" + NomRep);
    }

    public string obtenerPrefijoURLServidor(string serverUrl, bool forceHttps)
    {
        if (serverUrl.IndexOf("://") > -1)
            return serverUrl;
        string newUrl = serverUrl;
        Uri originalUri = System.Web.HttpContext.Current.Request.Url;
        newUrl = (forceHttps ? "https" : originalUri.Scheme) +
            "://" + originalUri.Authority + newUrl;
        return newUrl;
    }

    protected void habilitarDeshabilitarBotones(bool estado)
    {
        btnDescargarArchivos.Visible = estado;
        btnGenerarArchivo.Visible = estado;
        btnListarUsuario.Visible = estado;
        btnEliminar.Visible = estado;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombre.Text == "")
            {
                this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un Agente");
                return;
            }

            this.lblMensajeError.Text = "";
            int usuId = Convert.ToInt32(this.Session["usuId"].ToString());
            if (usuId == 0 || GlobalesNovedadesConsulta.novedadId == 0)
            {
                this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Ocurrio un error");
                return;
            }

            oNovedadExtDoc.Eliminar(GlobalesNovedadesConsulta.novedadId, usuId);
            //base.Response.Redirect(base.Request.UrlReferrer.ToString(), true);
            //lResponse.Redirect("NovedadesConsultaExtDocente.aspx" + "?operacion=2", true);
            Response.Redirect("NovedadesConsultaExtDocente.aspx", false);
            return;
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                                    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                                    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                                    Se ha producido el siguiente error:<br/>
                                    MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
                                    "</div>";
        }
    }
}