using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

// ABM DE LIQUIDACIONES

public partial class PerfilRegistracion : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Perfil ocnPerfil = new LiquidacionSueldos.Negocio.Perfil();
    DataTable dt, dt2, resultado = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    //LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
    LiquidacionSueldos.Negocio.NovedadInasistencia objetoNin = new LiquidacionSueldos.Negocio.NovedadInasistencia();

    #region Variables Globales
    public class Globales
    {
        private static int _ninId;
        public static int ninId
        {
            get
            {                
                return _ninId;
            }
            set
            {                
                _ninId = value;
            }
        }

        private static int _tipoOp;
        public static int tipoOp
        {
            get
            {
                // Reads are usually simple
                return _tipoOp;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _tipoOp = value;
            }
        }

        private static string _Agrupamiento;
        public static string agrupamiento
        {
            get
            {               
                return _Agrupamiento;
            }
            set
            {                
                _Agrupamiento = value;
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

        // Perhaps extend this to have Read-Modify-Write static methods
        // for data integrity during concurrency? Situational.
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {       
        try
        {            
            //Primera vez que se carga - NO ES POSTBACK
            if (!Page.IsPostBack)
            {
                if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                this.Master.TituloDelFormulario = "Actualizar Novedad";
                Session["PreviousPage"] = Request.UrlReferrer.ToString();               
                Session["ninId"] = Convert.ToInt32(Request.QueryString["Id"]);
                if (Request.QueryString["Id"] != null)
                {                                        
                    Session["agrupamiento"] = Convert.ToString(Request.QueryString["agru"]);                    
                    Session["fechaLiquidacion"] = Convert.ToDateTime(Request.QueryString["fechaLiquidacion"].Substring(0, 10));
                    if (int.Parse(Session["ninId"].ToString()) != 0)
                    {                        
                        Cargar_ComboConceptos();
                        resultado = objetoNin.ObtenerUno(int.Parse(Session["ninId"].ToString()));
                        ComboConceptos.SelectedValue = Convert.ToString(resultado.Rows[0]["ncoId"]);
                        bloquearCampoCantidadFecha();
                        txtDiasMin.Text = Convert.ToString(resultado.Rows[0]["ninCantidad"]);
                        String Fecha = Convert.ToString(resultado.Rows[0]["ninFechaDesde"]).Substring(0, 10).Replace('/', '-');                        
                        txtFecha.Text = Fecha.Substring(6, 4) + '-' + Fecha.Substring(3, 2) + '-' + Fecha.Substring(0, 2);
                    }
                    else                    
                        Response.Redirect(Session["PreviousPage"].ToString(), true);                    
                }
                else
                {
                    Response.Redirect(Session["PreviousPage"].ToString(), true);
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

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            #region Validaciones
            //Agregar validacion si ya existe o no con Campo Activo y si esta en 0 poner en 1.

            lblMensajeError.Text = "";
            bool hayErrores = false;

            if (fechaValida())
            {
                // INICIO Validacion de cantidad ingresada de dias segun el codigo de concepto
                // Codigo novedad <10 or =10 or >15
                if (Convert.ToInt32(ComboConceptos.SelectedValue) <= 10
            || Convert.ToInt32(ComboConceptos.SelectedValue) > 15)                
                    {
                    if (txtDiasMin.Text != null && txtDiasMin.Text != "")
                    {
                        // Codigo = 10
                        if (Convert.ToInt32(ComboConceptos.SelectedValue) == 10)
                        {
                            if (Convert.ToInt32(txtDiasMin.Text) >= 1 && Convert.ToInt32(txtDiasMin.Text) <= 60)
                                objetoNin.ninCantidad = Convert.ToInt32(txtDiasMin.Text);
                            else
                            {
                                lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor mayor que 0 y menor o igual a 60");
                                hayErrores = true;
                            }
                        }
                        // caso <10 o >15
                        else
                        {
                            if (Convert.ToInt32(txtDiasMin.Text) >= 1 && Convert.ToInt32(txtDiasMin.Text) <= 30)
                                objetoNin.ninCantidad = Convert.ToInt32(txtDiasMin.Text);
                            else
                            {
                                lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor mayor que 0 y menor o igual a 30");
                                hayErrores = true;
                            }
                        }
                    }
                    else
                    {
                        lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor en el campo Cantidad");
                        hayErrores = true;
                    }
                }
                else
                    objetoNin.ninCantidad = -1;
            }
            else
            {
                hayErrores = true;
                if (txtFecha.Text == "")
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar una Fecha Valida");
                else
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("La Fecha ingresada no debe ser mayor al mes de Liquidacion");
            }

            // FIN VALIDACION

            if (!hayErrores)
            {
                //objetoNin.ncoId = Convert.ToInt32(ComboConceptos.SelectedValue);
                //objetoNin.ninFechaRegistro = DateTime.Now;

                // validacion para codigo 13 - Baja
               /* if (Convert.ToInt32(ComboConceptos.SelectedValue) == 13)
                    objetoNin.ninFechaDesde = Globales.fechaLiquidacion;
                else
                    objetoNin.ninFechaDesde = Convert.ToDateTime(txtFecha.Text);                                
                    */

                objetoNin.Actualizar(int.Parse(Session["ninId"].ToString()), Convert.ToInt32(txtDiasMin.Text), Convert.ToDateTime(txtFecha.Text), int.Parse(Session["_usuId"].ToString()));
                //Session["Actualizado"] = 1;
                string pagina = Session["PreviousPage"].ToString();
                //Response.Redirect(Session["PreviousPage"].ToString() + "&operacion=2", true);
                Response.Redirect(FuncionesUtiles.eliminarParametroUrl(Session["PreviousPage"].ToString(), "operacion") + "&operacion=2", true);
            }

            #endregion            
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
        //Response.Redirect(Session["PreviousPage"].ToString(), true); esto estaba sin comentar
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            objetoNin.Eliminar(int.Parse(Session["ninId"].ToString()), int.Parse(Session["_usuId"].ToString()));
            //Session["Actualizado"] = 2;
            //Response.Redirect(Session["PreviousPage"].ToString() + "&operacion=3", true);
            Response.Redirect(FuncionesUtiles.eliminarParametroUrl(Session["PreviousPage"].ToString(), "operacion") + "&operacion=3", true);
            
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {                        
                Response.Redirect(FuncionesUtiles.eliminarParametroUrl(Session["PreviousPage"].ToString(),"operacion"), true);
            //Response.Redirect(Session["PreviousPage"].ToString(), true);
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
      /*  if (Convert.ToInt32(ComboConceptos.SelectedValue) >= 11)
            txtDiasMin.Enabled = false;
        else
            txtDiasMin.Enabled = true;*/
    }

    private void Cargar_ComboConceptos()
    {
        // MANDAR AGRUPAMIENTO DESDE NOVEDADNUEVO 
        // CASO DOCENTES BLOQUEAR TODO SOLO DEJAR ELIMINAR

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
                    dt = objetoNovedadConcepto.ObtenerListaConceptos();
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
                    dt = objetoNovedadConcepto.ObtenerListaConceptos();
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

    protected bool fechaValida()
    {
        bool resultado = false;
        if (txtFecha.Text != "")
        {
            /*  if (Convert.ToDateTime(txtFecha.Text) <= Globales.fechaLiquidacion && txtFecha.Text != "")
                  resultado = true;
              else
                  resultado = false;*/
            resultado = true;
        }
        return resultado;
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

    public static string eliminarUrlParametro(string url, string key)
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
}