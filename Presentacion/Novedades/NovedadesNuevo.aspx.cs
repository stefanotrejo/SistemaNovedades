using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using LiquidacionSueldos.Negocio;

//  CARGA DE NOVEDADES

public partial class UsuarioRegistracion : System.Web.UI.Page
{
    #region Variables
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.NovedadInasistencia objetoNovedad = new LiquidacionSueldos.Negocio.NovedadInasistencia();
    LiquidacionSueldos.Negocio.Liquidacion objetoLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
    DataTable dt = new DataTable();
    string txtAgeSituRev, txtAgeBloqueo;

    //  Variables Globales 

    public class Globales
    {
        public static readonly String TituloDelFormulario = "Carga de Novedades"; // Unmodifiable    

        private static string _NroControl;
        public static string NroControl
        {
            get
            {
                // Reads are usually simple
                return _NroControl;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _NroControl = value;
            }
        }

        //private static DataTable _dt;
        //public static DataTable dt
        //{
        //    get
        //    {
        //        // Reads are usually simple
        //        return _dt;
        //    }
        //    set
        //    {
        //        // You can add logic here for race conditions,
        //        // or other measurements
        //        _dt = value;
        //    }
        //}

        private static LiquidacionSueldos.Negocio.NuevoAge1 _oAgente;
        public static LiquidacionSueldos.Negocio.NuevoAge1 oAgente
        {
            get
            {
                // Reads are usually simple
                return _oAgente;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _oAgente = value;
            }
        }

        private static int _idGlobal;
        public static int idGlobal
        {
            get
            {
                // Reads are usually simple
                return _idGlobal;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _idGlobal = value;
            }
        }

        private static int _pageIndex;
        public static int pageIndex
        {
            get
            {
                // Reads are usually simple
                return _pageIndex;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _pageIndex = value;
            }
        }

        private static int _radioSeleccionado;
        public static int radioSeleccionado
        {
            get
            {
                // Reads are usually simple
                return _radioSeleccionado;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _radioSeleccionado = value;
            }
        }

        private static string _periodo;
        public static string periodo
        {
            get
            {
                // Reads are usually simple
                return _periodo;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _periodo = value;
            }
        }

        private static string _textBox;
        public static string textBox
        {
            get
            {
                // Reads are usually simple
                return _textBox;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _textBox = value;
            }
        }

        private static int _liqId;
        public static int liqId
        {
            get
            {
                // Reads are usually simple
                return _liqId;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _liqId = value;
            }
        }

        private static string _agrupamiento;
        public static string agrupamiento
        {
            get
            {
                return _agrupamiento;
            }
            set
            {
                _agrupamiento = value;
            }
        }

        private static int _usuId;
        public static int usuId
        {
            get
            {
                // Reads are usually simple
                return _usuId;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _usuId = value;
            }
        }

        private static DateTime _fechaLiquidacion;
        public static DateTime fechaLiquidacion
        {
            get
            {
                return _fechaLiquidacion;
            }
            set
            {
                _fechaLiquidacion = value;
            }
        }

        private static string _paginaActual;
        public static string paginaActual
        {
            get
            {
                return _paginaActual;
            }
            set
            {
                _paginaActual = value;
            }
        }


    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            string resultadoOperacion = Request.QueryString["operacion"];

            if (Request.QueryString["operacion"] != null)
            {
                switch (resultadoOperacion)
                {
                    // Novedad Agregada
                    case "1":
                        lblMensajeError.Text = FuncionesUtiles.MensajeExito("La Novedad se registró correctamente");
                        break;

                    // Novedad Actualizada
                    case "2":
                        lblMensajeError.Text = FuncionesUtiles.MensajeExito("La Novedad se actualizó correctamente");
                        break;

                    // Novedad Eliminada
                    case "3":
                        lblMensajeError.Text = FuncionesUtiles.MensajeExito("La Novedad se eliminó correctamente");
                        break;
                }
            }

            // Primera carga de Pagina - NO ES POSTBACK
            if (!Page.IsPostBack)
            {
                txtDiasMin.Text = "";
                //this.Master.TituloDelFormulario = Globales.TituloDelFormulario;
                this.Master.TituloDelFormulario = "Carga de Novedades";
                if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if ((Request.QueryString["Id"] != null) && (Request.QueryString["Id"] != ""))
                {
                    Session["idGlobal"] = Convert.ToInt32(Request.QueryString["Id"]);
                    Session["periodo"] = Request.QueryString["periodo"];
                    Session["fechaLiquidacion"] = Convert.ToDateTime("30" + "/" + Session["periodo"].ToString().ToString().Substring(0, 2) + "/" + "20" + Session["periodo"].ToString().Substring(3, 2));
                    Session["textBox"] = Request.QueryString["textBox"];
                    Session["pageIndex"] = Convert.ToInt32(Request.QueryString["pageIndex"]);
                    Session["agrupamiento"] = Convert.ToString(Request.QueryString["agrupamiento"]);
                    Session["usuId"] = int.Parse(Session["_usuId"].ToString());
                    objetoLiquidacion = objetoLiquidacion.ObtenerLiquidacionAbierta();
                    Session["liqId"] = objetoLiquidacion.liqId;
                    Session["Resultado"] = 0;

                    if (Convert.ToInt32(Session["idGlobal"]) != 0)
                    {
                        CargarDatosAgente(Convert.ToInt32(Session["idGlobal"]), Convert.ToInt32(Session["liqId"].ToString()));
                        Cargar_ComboConceptos();
                        CargarGrillaNovedades(Grilla.PageIndex);
                        txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    Session["Resultado"] = "";
                    Response.Redirect("NovedadesConsulta.aspx", true);
                }
            }
            // CUANDO ES POSTBACK
            else
            {

            }

        }
        catch (Exception oError)
        {
            Session["Resultado"] = "";
        }
    }

    /*  protected bool validarNovedad(int ncoId, int ageID, int liqID)
      {


      } */

    protected void guardarValoresEnSession()
    {
        Session["Resultado"] = 0;
        Session["Id"] = Request.QueryString["Id"];
        Session["mesanioliq"] = Request.QueryString["mesanioliq"];
        Session["textBox"] = Request.QueryString["textBox"];
        //Session["radioSeleccionado"] = Request.QueryString["radioSeleccionado"];
        Session["pageIndex"] = Request.QueryString["pageIndex"];
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect(Request.RawUrl, true);
            //int idGlobal = Convert.ToInt32(Session["idGlobal"]);
            //  string periodo = Session["periodo"].ToString();
            // string textBox = Session["textBox"].ToString();
            //string radioSeleccionado = Session["radioSeleccionado"].ToString();
            //int pageIndex = Convert.ToInt32(Session["pageIndex"]);

            /*Response.Redirect("NovedadesConsulta.aspx?Id = " + Convert.ToInt32(Session["idGlobal"])
                                                              + "&periodo=" + Session["periodo"].ToString() + "&textBox="
                                                              + Session["textBox"].ToString() + "&radioSeleccionado=" + Convert.ToInt32(Session["radioSeleccionado"])
                                                              + "&pageIndex=" + Convert.ToInt32(Session["pageIndex"]), true);*/

            Response.Redirect("NovedadesConsulta.aspx", true);

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

    protected void btnAgregarNovedad_Click(object sender, EventArgs e)
    {
        this.lblMensajeError.Text = "";
        bool flag = false;
        int num = 1;
        this.objetoLiquidacion = this.objetoLiquidacion.ObtenerLiquidacionAbierta();
        if ((this.txtAgeSituRev == "R" || this.txtAgeSituRev == "Cargo retenido") && Convert.ToInt32(this.ComboConceptos.SelectedValue) != 16)
        {
            NovedadInasistencia novedadInasistencium = new NovedadInasistencia();
          //  num = novedadInasistencium.ValidarBajaCargoRetenido(Convert.ToInt32(this.Session["idGlobal"]), this.objetoLiquidacion.liqId);
        }
        if (num != 1)
        {
            this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Primero debe cargar 16- Baja cargo retenido");
        }
        else
        {
            if (!this.fechaValida())
            {
                flag = true;
                if (this.txtFecha.Text != "")
                {
                    this.lblMensajeError.Text = FuncionesUtiles.MensajeError("La Fecha ingresada no debe ser mayor al mes de Liquidacion");
                }
                else
                {
                    this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar una Fecha Valida");
                }
            }
            else if (Convert.ToInt32(this.ComboConceptos.SelectedValue) > 10 && Convert.ToInt32(this.ComboConceptos.SelectedValue) <= 15)
            {
                this.objetoNovedad.ninCantidad = 30;
            }
            else if (this.txtDiasMin.Text == null || !(this.txtDiasMin.Text != ""))
            {
                this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor en el campo Cantidad");
                flag = true;
            }
            else if (Convert.ToInt32(this.ComboConceptos.SelectedValue) == 10)
            {
                if (Convert.ToInt32(this.txtDiasMin.Text) < 1 || Convert.ToInt32(this.txtDiasMin.Text) > 60)
                {
                    this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor mayor que 0 y menor o igual a 60");
                    flag = true;
                }
                else
                {
                    this.objetoNovedad.ninCantidad = Convert.ToInt32(this.txtDiasMin.Text);
                }
            }
            else if (Convert.ToInt32(this.txtDiasMin.Text) < 1 || Convert.ToInt32(this.txtDiasMin.Text) > 30)
            {
                this.lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor mayor que 0 y menor o igual a 30");
                flag = true;
            }
            else
            {
                this.objetoNovedad.ninCantidad = Convert.ToInt32(this.txtDiasMin.Text);
            }
            if (!flag)
            {
                this.objetoNovedad.NuevoAgeId1 = Convert.ToInt32(this.Session["idGlobal"]);
                this.objetoNovedad.ncoId = Convert.ToInt32(this.ComboConceptos.SelectedValue);
                this.objetoNovedad.ninFechaRegistro = DateTime.Now;
                if (Convert.ToInt32(this.ComboConceptos.SelectedValue) != 13)
                {
                    this.objetoNovedad.ninFechaDesde = Convert.ToDateTime(this.txtFecha.Text);
                }
                else
                {
                    this.objetoNovedad.ninFechaDesde = Convert.ToDateTime(this.Session["fechaLiquidacion"].ToString());
                }
                this.objetoLiquidacion = this.objetoLiquidacion.ObtenerLiquidacionAbierta();
                this.objetoNovedad.liqId = this.objetoLiquidacion.liqId;
                this.objetoNovedad.usuCreaID = Convert.ToInt32(this.Session["usuId"].ToString());
                if (Convert.ToInt32(this.Session["_esAdministrador"]) != 5)
                {
                    this.objetoNovedad.perEsAdministrador = Convert.ToInt32(this.Session["_esAdministrador"]);
                }
                else
                {
                    this.objetoNovedad.perEsAdministrador = 2;
                }
                this.objetoNovedad.ninActivo = 1;
                if (this.objetoNovedad.ValidarConceptoRepetido(this.objetoNovedad.ncoId, this.objetoNovedad.NuevoAgeId1, this.objetoNovedad.liqId) != 0)
                {
                    this.lblMensajeError.Text = FuncionesUtiles.MensajeError("La Novedad ingresada ya existe en el Sistema");
                    return;
                }
                this.objetoNovedad.Insertar();
                base.Response.Redirect(string.Concat(FuncionesUtiles.eliminarParametroUrl(base.Request.UrlReferrer.ToString(), "operacion"), "&operacion=1"), true);
                return;
            }
        }
    }

    private void Cargar_ComboConceptos()
    {
        ComboConceptos.DataValueField = "ncoId";
        ComboConceptos.DataTextField = "CodigoDenominacion";
        LiquidacionSueldos.Negocio.NovedadConcepto objetoNovedadConcepto = new LiquidacionSueldos.Negocio.NovedadConcepto();

        switch (Convert.ToInt32(Session["_esAdministrador"]))
        {
            case 1:
                break;

            case 2:
                if (Session["agrupamiento"].ToString() == "06")
                {
                    dt = objetoNovedadConcepto.ObtenerListaConceptosDocentes();
                    txtDiasMin.Enabled = false;
                }
                else
                {
                    if (string.Equals(ocnAgente.PlantaTipo, "Contratado", StringComparison.InvariantCulture))
                        dt = objetoNovedadConcepto.ObtenerListaConceptosPlantaContratados();
                    else
                        dt = objetoNovedadConcepto.ObtenerListaConceptos();
                }
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                if (Session["agrupamiento"].ToString() == "06")
                {
                    dt = objetoNovedadConcepto.ObtenerListaConceptosDocentes();
                    txtDiasMin.Enabled = false;
                }
                else
                {
                    if (string.Equals(ocnAgente.PlantaTipo, "Contratado", StringComparison.InvariantCulture))
                        dt = objetoNovedadConcepto.ObtenerListaConceptosPlantaContratados();
                    else
                        dt = objetoNovedadConcepto.ObtenerListaConceptos();
                }
                break;

            case 6:
                break;

            // Vialidad
            case 7:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;
            // TRIBUNAL DE CUENTAS
            case 8:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // RIEGO
            case 9:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // POLICIA
            case 10:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // MUNICIPALIDADES
            case 11:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // LEGISLATIVO
            case 12:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // IPVU
            case 13:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // IOSEP
            case 14:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // RECURSOS HIDRICOS
            case 15:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // CONSEJO DE EDUCACION
            case 16:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;

            // AVIACION CIVIL
            case 17:
                dt = objetoNovedadConcepto.ObtenerListaConceptosDescentralizados();
                break;
        }

        //dt = objetoNovedadConcepto.ObtenerListaConceptos();

        dt.Columns.Add("CodigoDenominacion", typeof(string), "ncoCod + ' - ' + ncoNombre");
        ComboConceptos.DataSource = dt;
        ComboConceptos.DataBind();
    }

    protected void CargarDatosAgente(int Id, int liqId)
    {
        ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
        ocnAgente = ocnAgente.ObtenerAgentePorId(Id);

        this.txtAgeApellidoNombre.Text = ocnAgente.Nombre;
        this.txtAgeCuit.Text = ocnAgente.Cuil;
        String FechaNac = "";
        FechaNac = ocnAgente.FechaNac.Substring(0, 2) + "/" + ocnAgente.FechaNac.Substring(2, 2) + "/" + ocnAgente.FechaNac.Substring(4, 2);
        this.txtAgeLugarPago.Text = ocnAgente.LugarPago;
        this.txtAgeEscuela.Text = ocnAgente.Escuela;
        this.txtAgePlanta.Text = ocnAgente.PlantaTipo;
        this.txtAgeNroControl.Text = ocnAgente.NroCOntrol;
        this.txtAgeSituRev = this.ocnAgente.SituRev;
        this.txtAgeBloqueo = this.ocnAgente.Bloqueo;


        //SI ES DOCENTE
        if ((ocnAgente.Agru == "06") && (ocnAgente.tramo == "0"))
        {
            if ((ocnAgente.Apertura == "132") || (ocnAgente.Apertura == "133") || (ocnAgente.Apertura == "660") || (ocnAgente.Apertura == "661"))
            {   
                //this.txtAgeCargo.Text = ocnAgente.Cargo + " - " + ocnAgente.HsCat;
            }
            else
            {
                //this.txtAgeCargo.Text = ocnAgente.Cargo;
            }
        }
        else
        {
            //this.txtAgeCargo.Text = ocnAgente.Cargo;
        }

        if (ocnAgente.Anios != "")
        {
            if (ocnAgente.Anios == "*N")
            {
                //txtAntiguedadReconocida.Text = ocnAgente.Anios + ocnAgente.Meses;
            }
            else
            {
                //this.txtAntiguedadReconocida.Text = ocnAgente.Anios + " Años" + " - " + ocnAgente.Meses + " Meses";
            }
        }
        else
        {
            //txtAntiguedadReconocida.Text = ocnAgente.Anios;
        }

        String FechaDeIngreso = "";
        FechaDeIngreso = ocnAgente.FechaIngreso.Substring(0, 2) + "/" + ocnAgente.FechaIngreso.Substring(2, 2) + "/" + ocnAgente.FechaIngreso.Substring(4, 2);
        //this.txtAgeFechaIngreso.Text = FechaDeIngreso;
        if (ocnAgente.AniosAntig == "*N")
        {
            //txtAgeAntiguedad.Text = ocnAgente.AniosAntig;
        }
        else
        {
            //this.txtAgeAntiguedad.Text = ocnAgente.AniosAntig + " años";
        }

        //this.txtAgePeriodo.Text = ocnAgente.MesAnioLiq.Substring(0, 2) + " del " + "20" + ocnAgente.MesAnioLiq.Substring(3, 2);
        //this.txtAgeDiasTrabajados.Text = ocnAgente.DiasTrabajados;
        //this.txtAgeSituacionRevista.Text = ocnAgente.SituRev;       

        #region DESACTIVO TODOS LOS CAMPOS 
        ////CAMPOS DIRECTOR
        //this.txtAgeHaber.Visible = false;
        //this.lblHaber.Visible = false;
        //this.txtAgeSalarioFamiliar.Visible = false;
        //this.lblSalarioFamiliar.Visible = false;
        //this.txtAgeLiquido.Visible = false;
        //this.lblLiquido.Visible = false;

        ////CAMPOS D.G. PERSONAL
        //this.txtAsistenciaPerfecta.Visible = false;
        //this.lblAsistenciaPerfecta.Visible = false;
        //this.txtRiesgoVida.Visible = false;
        //this.lblRiesgoVida.Visible = false;
        //this.txtJubRetActivo.Visible = false;
        //this.lblJurRetActivo.Visible = false;
        //this.txtDiasNoTrabajados.Visible = false;
        //this.lblDiasNoTrabajados.Visible = false;

        ////CAMPOS UERT
        //this.txtAgeDescuentos.Visible = false;
        //this.lblDescuentos.Visible = false;
        //this.txtTotalSinCargo.Visible = false;
        //this.lblTotalSinCargosAlHaber.Visible = false;
        //this.txtRemuneracionOIT.Visible = false;
        //this.lblRemuneracionOit.Visible = false;

        //CAMPOS PERSONAL EXTENDIDO        
        //this.btnConceptos.Visible = false;
        #endregion 

        #region ACTIVO CAMPOS SEGUN PERFIL

        int perfil = Convert.ToInt32(Session["_esAdministrador"]);
        switch (perfil)
        {
            case 1: //ADMINISTRADOR
                //btnConceptos.Visible = true;
                break;

            case 2: //D.G. PERSONAL - GRUPO 7
                //this.txtAsistenciaPerfecta.Visible = true;
                //this.lblAsistenciaPerfecta.Visible = true;
                //this.txtRiesgoVida.Visible = true;
                //this.lblRiesgoVida.Visible = true;
                //this.txtJubRetActivo.Visible = true;
                //this.lblJurRetActivo.Visible = true;
                //if (Convert.ToInt32(ocnAgente.AsistenciaPerfecta) == 1)
                //    this.txtAsistenciaPerfecta.Text = "Si";
                //else
                //    this.txtAsistenciaPerfecta.Text = "No";

                //if (Convert.ToInt32(ocnAgente.RiesgoDeVida) == 1)
                //    this.txtRiesgoVida.Text = "Si";
                //else
                //    this.txtRiesgoVida.Text = "No";

                //if (Convert.ToInt32(ocnAgente.JubRetActivo) == 1)
                //    this.txtJubRetActivo.Text = "Si";
                //else
                //    this.txtJubRetActivo.Text = "No";
                //habilitarCamposPersonal();
                break;

            case 3: //UERT
                //this.txtAgeDescuentos.Visible = true;
                //this.lblDescuentos.Visible = true;
                //this.txtTotalSinCargo.Visible = true;
                //this.lblTotalSinCargosAlHaber.Visible = true;
                //this.txtRemuneracionOIT.Visible = true;
                //this.lblRemuneracionOit.Visible = true;
                //this.txtDiasNoTrabajados.Visible = true;
                //this.lblDiasNoTrabajados.Visible = true;

                //this.txtAgeDescuentos.Text = "$" + ocnAgente.TotalDescuentos;
                //this.txtTotalSinCargo.Text = "$" + ocnAgente.TotalSinCargosAlHaber;
                //this.txtRemuneracionOIT.Text = "$" + ocnAgente.RemuneracionOit;
                //if (ocnAgente.DiasNoTrabajados != null)
                //    this.txtDiasNoTrabajados.Text = ocnAgente.DiasNoTrabajados;
                //else this.txtDiasNoTrabajados.Text = "0";
                break;

            case 4: //DIRECTOR
                //this.txtAgeHaber.Visible = true;
                //this.lblHaber.Visible = true;
                //this.txtAgeSalarioFamiliar.Visible = true;
                //this.lblSalarioFamiliar.Visible = true;
                //this.txtAgeLiquido.Visible = true;
                //this.lblLiquido.Visible = true;
                //this.txtDiasNoTrabajados.Visible = true;
                //this.lblDiasNoTrabajados.Visible = true;
                //this.txtAgeHaber.Text = "$" + ocnAgente.TotalHaberes;
                //this.txtAgeSalarioFamiliar.Text = "$" + ocnAgente.HaberC_aporte;
                //this.txtAgeLiquido.Text = "$" + ocnAgente.Liquido;
                //this.txtDiasNoTrabajados.Text = ocnAgente.DiasNoTrabajados;
                break;

            case 5: //PERSONAL EXTENDIDO
                //CASO 2 MAS BOTON CONCEPTOS
                //habilitarCamposPersonal();
                //btnConceptos.Visible = true;
                //btnListar.Visible = false;
                break;
        }
        #endregion
    }

    private void CargarGrillaNovedades(int PageIndex)
    {
        try
        {
            Session["PerfilConsulta.PageIndex"] = PageIndex;

            dt = new DataTable();
            dt = objetoNovedad.ObtenerTodoPorAgenteEtapa(Convert.ToInt32(Session["idGlobal"]), Convert.ToInt32(Session["liqId"].ToString()));
            this.Grilla.DataSource = dt;
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();
            lblCantidadRegistros.Text = "Novedades registradas: ";

            if (dt.Rows.Count > 0)
            {
                lblCantidadRegistros.Text = lblCantidadRegistros.Text + dt.Rows.Count.ToString();
            }
            else
            {
                lblCantidadRegistros.Text = lblCantidadRegistros.Text + "0";
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

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                if (e.CommandName == "Eliminar")
                {
                    //Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                    lbuEliminar_Click(sender, e);
                    //ocnPerfil.Eliminar(Convert.ToInt32(Id));
                    // this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                    //ocnPerfil = new LiquidacionSueldos.Negocio.Perfil(Convert.ToInt32(Id));
                    //ocnPerfil.Copiar();
                    //this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;
                    //Response.Redirect("PerfilRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
            if (Session["PerfilConsulta.PageIndex"] != null)
            {
                Session["PerfilConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("PerfilConsulta.PageIndex", e.NewPageIndex);
            }

            this.CargarGrillaNovedades(e.NewPageIndex);
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

    protected void lbuEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            ((LinkButton)sender).Visible = false;
            ((LinkButton)sender).Parent.Controls[3].Visible = true;
            ((LinkButton)sender).Parent.Controls[5].Visible = true;
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

    protected void eliminar_click(object sender, EventArgs e)
    {
        try
        {
            ((LinkButton)sender).Visible = false;
            ((LinkButton)sender).Parent.Controls[3].Visible = true;
            ((LinkButton)sender).Parent.Controls[5].Visible = true;
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

    protected void ComboConceptos_SelectedIndexChanged(object sender, EventArgs e)
    {
        bloquearCampoCantidadFecha();
    }

    private void bloquearCampoCantidadFecha()
    {
        // Bloquea campo cantidad y fecha segun codigo. Mantener el mismo codigo que 
        // en NovedadesNuevo -> protected void ComboConceptos_SelectedIndexChanged(object sender, EventArgs e)
        txtFecha.Enabled = true;
        txtDiasMin.Enabled = true;

        if (Convert.ToInt32(ComboConceptos.SelectedValue) >= 11
            && Convert.ToInt32(ComboConceptos.SelectedValue) <= 15)
            txtDiasMin.Enabled = false;
        /*
                if (Convert.ToInt32(ComboConceptos.SelectedValue) == 12 ||
                    (Convert.ToInt32(ComboConceptos.SelectedValue) == 13))
                    txtFecha.Enabled = false;
                    */
    }

    protected bool fechaValida()
    {
        bool resultado = false;
        if (txtFecha.Text != "")
        {
            /*  if (Convert.ToDateTime(txtFecha.Text) <= Session["fechaLiquidacion"].ToString() && txtFecha.Text != "")
                  resultado = true;
              else
                  resultado = false;*/
            resultado = true;
        }
        return resultado;
    }
}
