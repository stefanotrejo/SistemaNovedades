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
    public static readonly String TituloDelFormulario = "Consulta de Novedades"; // Unmodifiable        
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
    LiquidacionSueldos.Negocio.Liquidacion objetoLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
    LiquidacionSueldos.Negocio.Jurisdiccion oJurisdiccion = new LiquidacionSueldos.Negocio.Jurisdiccion();
    LiquidacionSueldos.Negocio.NovedadInasistencia oNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();
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
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.TituloDelFormulario = Globals.TituloDelFormulario;
        try
        {
            selectJurisdiccion.Visible = false;
            checkObtenerTodos.Visible = false;
            lblJurisdiccion.Visible = false;

            int perfil = Convert.ToInt32(Session["_esAdministrador"]);
            if (perfil == 2 || perfil == 5)
            {
                cargarComboJurisdiccion();
            }

            // Liquidaciones
            objetoLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
            objetoLiquidacion = objetoLiquidacion.ObtenerLiquidacionAbierta();

            lblLiquidacion.Text = "";
            lblEtapa.Text = "";

            // Si no encuentró Liquidaciones abiertas -> busca Liquidaciones abierta para Personal (liqEstado = 'P')
            if (objetoLiquidacion == null)
            {
                objetoLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
                objetoLiquidacion = objetoLiquidacion.ObtenerLiquidacionAbiertaPersonal();

                lblLiquidacion.Text = "No hay liquidaciones abiertas";
                lblEtapa.Visible = false;
                lblEtapa.Visible = false;

                btnConsultar1.Enabled = false;
                btnDescargarArchivos.Visible = true;
            }
            else
            {
                GlobalesNovedadesConsulta.mesAnioLiq = objetoLiquidacion.mesAnioLiq;
                lblLiquidacion.Text = "Liquidacion (inicio de mes): " + objetoLiquidacion.mesAnioLiq;
                mesActual = Convert.ToInt32(objetoLiquidacion.mesAnioLiq.Substring(0, 2));
                mesActualString = FuncionesUtiles.convertirNumeroAMesMasUno(mesActual);
                anioActualInt = Int32.Parse(objetoLiquidacion.liqAnio.ToString());
                if (FuncionesUtiles.agregarAnio(mesActual))
                {
                    anioActualInt = Int32.Parse(objetoLiquidacion.liqAnio.ToString()) + 1;
                }

                anioActualString = DateTime.Now.ToString("yyyyMMdd").Substring(0, 2) + anioActualInt.ToString();
                string separador = " ";

                lblEtapa.Text = "Etapa: " + objetoLiquidacion.liqEtapa.ToString() + separador + "del mes de" + separador + mesActualString + separador + "del" + separador + anioActualString;
                if (objetoLiquidacion.liqFechaCierre < DateTime.Now)
                {
                    lblFechaCierre.Text = "No Disponible";
                }
                else
                {
                    lblFechaCierre.Text = objetoLiquidacion.liqFechaCierre.ToString().Substring(0, 16) + " hs";
                    lblFechaCierre.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }

            if (String.IsNullOrEmpty(Session["textBox"].ToString()))
            {
                //Cuando se carga la pagina por primera vez y cuando vuelve de otra pagina (NO ES POSTBACK)
                if (!Page.IsPostBack)
                {
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                    this.RadioDni.Checked = true;
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
                            RadioApellidoyNombre.Checked = false;
                            RadioDni.Checked = false;

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

    private void cargarComboJurisdiccion()
    {
        if (selectJurisdiccion.DataTextField == "")
        {
            listaJurisdiccion = oJurisdiccion.ObtenerTodosSelect();
            selectJurisdiccion.DataSource = listaJurisdiccion;
            selectJurisdiccion.DataTextField = "jurNombre";
            selectJurisdiccion.DataValueField = "jurId";
            selectJurisdiccion.DataBind();
            selectJurisdiccion.Enabled = false;
            selectJurisdiccion.Visible = true;
            checkObtenerTodos.Visible = true;
            lblJurisdiccion.Visible = true;
        }
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            Grilla.PageIndex = 0;
            Session["pageIndex"] = Grilla.PageIndex;
            LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
            Boolean errores = false;

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

            if (!errores)
            {
                //  getLiquidacionAbierta();
                GrillaCargar(Grilla.PageIndex, GlobalesNovedadesConsulta.mesAnioLiq);
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

    protected void btnDescargarArchivos_Click(object sender, EventArgs e)
    {

        int reparticion = Convert.ToInt32(Session["_esAdministrador"]);
        if (reparticion == 5)
            reparticion = 2;


        int liqId = GlobalesNovedadesConsulta.liqId;
        Response.Redirect("descargas.aspx?liquidacion=" + liqId
              + "&reparticion=" + reparticion, true);
    }

    private void GrillaCargar(int PageIndex, string mesanioliq)
    {
        // Carga la grilla segun el Radio seleccionado
        try
        {
            if (txtAgeNroControl.Text != "")
            {
                Session["AgenteConsulta.PageIndex"] = PageIndex;
                dt = new DataTable();
                int jurId;

                if (checkObtenerTodos.Checked)
                    jurId = 0;
                else
                    jurId = Convert.ToInt32(selectJurisdiccion.SelectedValue);

                //Busca por DNI                      
                if (RadioDni.Checked == true)
                {
                    string parametroDni = "";
                    // Convierte cuil a dni
                    if (txtAgeNroControl.Text.Length == 11)
                        parametroDni = txtAgeNroControl.Text.Substring(2, 8);
                    else
                        parametroDni = txtAgeNroControl.Text;

                    // verificar perfil y mandar a sp correspondiente                    
                    switch (Convert.ToInt32(Session["_esAdministrador"]))
                    {
                        case 1:
                            break;

                        case 2:
                            dt = ocnAgente.ObtenerAgentesPorDniPorMesAnioLiq(parametroDni, mesanioliq, jurId);
                            break;

                        case 3:
                            break;

                        case 4:
                            break;

                        case 5:
                            dt = ocnAgente.ObtenerAgentesPorDniPorMesAnioLiq(parametroDni, mesanioliq, jurId);
                            break;

                        case 6:
                            break;

                        // Vialidad
                        case 7:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqVialidad(parametroDni, mesanioliq);
                            break;

                        // TRIBUNAL DE CUENTAS
                        case 8:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqTribunalCuentas(parametroDni, mesanioliq);
                            break;

                        // RIEGO
                        case 9:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqRiego(parametroDni, mesanioliq);
                            break;

                        // POLICIA
                        case 10:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqPolicia(parametroDni, mesanioliq);
                            break;

                        // MUNICIPALIDADES
                        case 11:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqMunicipalidades(parametroDni, mesanioliq);
                            break;

                        // LEGISLATIVO
                        case 12:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqLegislativo(parametroDni, mesanioliq);
                            break;

                        // IPVU
                        case 13:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqIpvu(parametroDni, mesanioliq);
                            break;

                        // IOSEP
                        case 14:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqIosep(parametroDni, mesanioliq);
                            break;

                        // RECURSOS HIDRICOS
                        case 15:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqRecursosHidricos(parametroDni, mesanioliq);
                            break;

                        // CONSEJO DE EDUCACION
                        case 16:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqConsejoEducacion(parametroDni, mesanioliq);
                            break;

                        // AVIACION CIVIL
                        case 17:
                            dt = ocnAgente.ObtenerxDnixMesAnioLiqAviacionCivil(parametroDni, mesanioliq);
                            break;

                        // PREVISIONAL
                        case 18:
                            dt = ocnAgente.ObtenerAgentesPorDniPorMesAnioLiq(parametroDni, mesanioliq, jurId);
                            break;
                    }
                }
                else
                {
                    //Buscar por Nombre                
                    if (RadioApellidoyNombre.Checked == true)
                    {
                        switch (Convert.ToInt32(Session["_esAdministrador"]))
                        {
                            case 1:
                                break;

                            case 2:
                                dt = ocnAgente.ObtenerAgentesPorNombrePorMesAnioLiq(txtAgeNroControl.Text, mesanioliq, jurId);
                                break;

                            case 3:
                                break;

                            case 4:
                                break;

                            case 5:
                                dt = ocnAgente.ObtenerAgentesPorNombrePorMesAnioLiq(txtAgeNroControl.Text, mesanioliq, jurId);
                                break;

                            case 6:
                                break;

                            // Vialidad
                            case 7:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqVialidad(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // TRIBUNAL DE CUENTAS
                            case 8:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqTribunalCuentas(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // RIEGO
                            case 9:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqRiego(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // POLICIA
                            case 10:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqPolicia(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // MUNICIPALIDADES
                            case 11:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqMunicipalidades(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // LEGISLATIVO
                            case 12:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqLegislativo(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // IPVU
                            case 13:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqIpvu(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // IOSEP
                            case 14:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqIosep(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // RECURSOS HIDRICOS
                            case 15:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqRecursosHidricos(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // CONSEJO DE EDUCACION
                            case 16:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqConsejoEducacion(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // AVIACION CIVIL
                            case 17:
                                dt = ocnAgente.ObtenerxNombrexMesAnioLiqAviacionCivil(txtAgeNroControl.Text, mesanioliq);
                                break;
                        }
                    }
                    // Busca por Numero de Control
                    else
                    {
                        switch (Convert.ToInt32(Session["_esAdministrador"]))
                        {
                            case 1:
                                break;

                            case 2:
                                dt = ocnAgente.ObtenerAgentesPorNroControlPorMesAnioLiq(txtAgeNroControl.Text, mesanioliq, jurId);
                                break;

                            case 3:
                                break;

                            case 4:
                                break;

                            case 5:
                                dt = ocnAgente.ObtenerAgentesPorNroControlPorMesAnioLiq(txtAgeNroControl.Text, mesanioliq, jurId);
                                break;

                            case 6:
                                break;

                            // Vialidad
                            case 7:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqVialidad(txtAgeNroControl.Text, mesanioliq);
                                break;
                            // TRIBUNAL DE CUENTAS
                            case 8:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqTribunalCuentas(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // RIEGO
                            case 9:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqRiego(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // POLICIA
                            case 10:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqPolicia(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // MUNICIPALIDADES
                            case 11:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqMunicipalidades(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // LEGISLATIVO
                            case 12:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqLegislativo(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // IPVU
                            case 13:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqIpvu(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // IOSEP
                            case 14:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqIosep(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // RECURSOS HIDRICOS
                            case 15:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqRecursosHidricos(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // CONSEJO DE EDUCACION
                            case 16:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqConsejoEducacion(txtAgeNroControl.Text, mesanioliq);
                                break;

                            // AVIACION CIVIL
                            case 17:
                                dt = ocnAgente.ObtenerxControlxMesAnioLiqAviacionCivil(txtAgeNroControl.Text, mesanioliq);
                                break;
                        }
                    }
                }

                if (dt.Rows.Count != 0)
                {
                    this.Grilla.DataSource = dt;
                    this.Grilla.PageIndex = PageIndex;
                    this.Grilla.DataBind();
                    lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                }
                else
                {
                    this.Grilla.DataSource = null;
                    this.Grilla.DataBind();

                    if (RadioApellidoyNombre.Checked)
                        lblMensajeError.Text = FuncionesUtiles.MensajeError("El nombre ingresado No existe o pertenece a otra área en el periodo de liquidacion seleccionado");
                    else
                        if (RadioDni.Checked)
                        lblMensajeError.Text = FuncionesUtiles.MensajeError("El DNI ingresado No existe o pertenece a otra área en el periodo de liquidacion seleccionado");
                    else
                        lblMensajeError.Text = FuncionesUtiles.MensajeError("El Numero de Control ingresado ingresado No existe o pertenece a otra área en el periodo de liquidacion seleccionado");


                    /*  // Errores
                      switch (Convert.ToInt32(Session["radioSeleccionado"].ToString()))
                      {
                          // Dni
                          case 1:
                              lblMensajeError.Text = FuncionesUtiles.MensajeError("El DNI ingresado no existe en esta liquidacion");
                              break;

                          //  Apellido y Nombre
                          case 2:
                              lblMensajeError.Text = FuncionesUtiles.MensajeError("El nombre ingresado no existe en el periodo de liquidacion seleccionado");
                              break;

                          //  Numero de Control
                          case 3:
                              lblMensajeError.Text = FuncionesUtiles.MensajeError("El Numero de Control ingresado no existe en esta liquidacion");
                              break;
                      }*/
                    lblCantidadRegistros.Text = "Cantidad de registros: 0";
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

    private int getRadioSeleccionado()
    {
        /*
         Valores que devuelve:
         1- Si seleccionó por DNI
         2- Si seleccionó por Nombre y Apellido
         3- Si seleccionó por Numero de Control
         */
        if (RadioDni.Checked == true)
        {
            return 1;
        }
        else
        {
            if (RadioApellidoyNombre.Checked == true)
                return 2;
            else
                return 3;
        }
    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                //if (e.CommandName == "Eliminar")
                //{
                //    ocnPerfil.Eliminar(Convert.ToInt32(Id));
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                //    ocnPerfil = new LiquidacionSueldos.Negocio.Perfil(Convert.ToInt32(Id));
                //    ocnPerfil.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("PerfilRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int tipo = 0;
            if (RadioDni.Checked == true)
            {
                tipo = 1;
            }
            else
            {
                if (RadioApellidoyNombre.Checked == true)
                {
                    tipo = 2;
                }
                else
                {
                    tipo = 3;
                }
            }
            if (Session["AgenteConsulta.PageIndex"] != null)
            {
                Session["AgenteConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("AgenteConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex, Session["mesAnioLiq"].ToString());
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

    protected void RadioDni_CheckedChanged(object sender, EventArgs e)
    {
        bool var1 = RadioDni.Checked;
        bool var2 = RadioApellidoyNombre.Checked;
        bool var3 = RadioNumeroControl.Checked;

        Session["radioSeleccionado"] = 1;
        RadioNumeroControl.Checked = false;
        RadioApellidoyNombre.Checked = false;

        //RadioDni.Checked = true;
        this.txtAgeNroControl.Text = "";
        this.txtAgeNroControl.Focus();
    }

    protected void RadioApellidoyNombre_CheckedChanged(object sender, EventArgs e)
    {
        bool var1 = RadioDni.Checked;
        bool var2 = RadioApellidoyNombre.Checked;
        bool var3 = RadioNumeroControl.Checked;

        Session["radioSeleccionado"] = 2;
        RadioNumeroControl.Checked = false;
        RadioDni.Checked = false;
        RadioApellidoyNombre.Checked = true;
        this.txtAgeNroControl.Text = "";
        this.txtAgeNroControl.Focus();
    }

    protected void RadioNumeroControl_CheckedChanged(object sender, EventArgs e)
    {
        bool var1 = RadioDni.Checked;
        bool var2 = RadioApellidoyNombre.Checked;
        bool var3 = RadioNumeroControl.Checked;

        Session["radioSeleccionado"] = 3;
        RadioDni.Checked = false;
        RadioApellidoyNombre.Checked = false;
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

        objetoLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
        objetoLiquidacion = objetoLiquidacion.ObtenerLiquidacionAbierta();

        String NomRep = "InformeNovedadesCargadas2.rpt";
        FuncionesUtiles.AbreVentana("Reporte.aspx?liqId=" + objetoLiquidacion.liqId
            + "&reparticion=" + reparticion
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

    protected void checkObtenerTodos_CheckedChanged(object sender, EventArgs e)
    {
        if (checkObtenerTodos.Checked)
        {
            selectJurisdiccion.Enabled = false;
            //selectJurisdiccion.Visible = false;
        }
        else
        {
            selectJurisdiccion.Enabled = true;
            //      selectJurisdiccion.Visible = true;
        }
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
}