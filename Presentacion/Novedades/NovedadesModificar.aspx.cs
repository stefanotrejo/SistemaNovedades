using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Globalization;

// ABM DE LIQUIDACIONES

public partial class PerfilRegistracion : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Perfil ocnPerfil = new LiquidacionSueldos.Negocio.Perfil();    
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.NovedadInasistencia oNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();
    DataTable dt, dt2, resultado = new DataTable();
    string previousPage;

    public class Globales
    {
        private static int _novedadInasistenciaID;
        public static int novedadInasistenciaID
        {
            get
            {
                return _novedadInasistenciaID;
            }
            set
            {
                _novedadInasistenciaID = value;
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

        private static int _usuID;
        public static int usuID
        {
            get
            {
                return _usuID;
            }
            set
            {
                _usuID = value;
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
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string agrupamiento;
            int esAdministrador;
            DataTable novedadInasistencia = new DataTable();
            LiquidacionSueldos.Negocio.Liquidacion oLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();

            this.Master.TituloDelFormulario = "Actualizar Novedad";
            if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
            
            oLiquidacion = oLiquidacion.ObtenerLiquidacionAbierta();
            if (oLiquidacion == null)
            {
                cambiarEstadoBoton(false);
                cambiarEstadoTextBox(false);
                lblMensajeError.Text = FuncionesUtiles.MensajeError(CodigosErrores.errorLiquidacionCerrada);
                return;
            }

            if (!Page.IsPostBack)
            {
                Globales.novedadInasistenciaID = Convert.ToInt32(Request.QueryString["Id"]);
                if (Globales.novedadInasistenciaID == 0) Response.Redirect(Session["PreviousPage"].ToString(), true);

                agrupamiento = Request.QueryString["agru"];
                esAdministrador = Convert.ToInt32(Session["_esAdministrador"]);
                Session["PreviousPage"] = Request.UrlReferrer.ToString();
                Session["novedadInasistenciaID"] = Globales.novedadInasistenciaID;
                Session["agrupamiento"] = agrupamiento;

                cargarConceptos(esAdministrador, agrupamiento);

                oNovedadInasistencia = oNovedadInasistencia.ObtenerUno(Globales.novedadInasistenciaID);
                ComboConceptos.SelectedValue = Convert.ToString(oNovedadInasistencia.ncoId);
                txtDiasMin.Text = oNovedadInasistencia.ninCantidad.ToString();
                txtFecha.Text = FuncionesUtiles.convertirFechaParaTextbox(oNovedadInasistencia.ninFechaDesdeString);
                bloquearCampoCantidadFecha();
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

    protected void cambiarEstadoBoton(bool estado)
    {
        btnActualizar.Visible = estado;
        btnEliminar.Visible = estado;
    }

    protected void cambiarEstadoTextBox(bool estado)
    {
        txtDiasMin.Enabled = estado;
        txtFecha.Enabled = estado;
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.Liquidacion oLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
        if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

        oLiquidacion = oLiquidacion.ObtenerLiquidacionAbierta();
        if (oLiquidacion == null)
        {
            cambiarEstadoBoton(false);
            cambiarEstadoTextBox(false);
            lblMensajeError.Text = lblMensajeError.Text = FuncionesUtiles.MensajeError(CodigosErrores.errorLiquidacionCerrada);
            return;
        }

        try
        {
            lblMensajeError.Text = "";
            bool hayErrores = false;

            if (fechaValida())
            {
                // INICIO Validacion de cantidad ingresada de dias segun el codigo de concepto
                // Codigo novedad <=10 or >15
                if (Convert.ToInt32(ComboConceptos.SelectedValue) <= 10
                    || Convert.ToInt32(ComboConceptos.SelectedValue) > 15)
                {
                    if (txtDiasMin.Text != "")
                    {
                        if (Convert.ToInt32(ComboConceptos.SelectedValue) == 10)
                        {
                            if (Convert.ToInt32(txtDiasMin.Text) >= 1 && Convert.ToInt32(txtDiasMin.Text) <= 60)
                                oNovedadInasistencia.ninCantidad = Convert.ToInt32(txtDiasMin.Text);
                            else
                            {
                                lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar un valor mayor que 0 y menor o igual a 60");
                                return;
                            }
                        }
                        // caso <10 o >15
                        else
                        {
                            if (Convert.ToInt32(txtDiasMin.Text) >= 1 && Convert.ToInt32(txtDiasMin.Text) <= 30)
                                oNovedadInasistencia.ninCantidad = Convert.ToInt32(txtDiasMin.Text);
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
                    oNovedadInasistencia.ninCantidad = -1;
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
                oNovedadInasistencia.Actualizar(Globales.novedadInasistenciaID, Convert.ToInt32(txtDiasMin.Text),
                                    Convert.ToDateTime(txtFecha.Text), int.Parse(Session["_usuID"].ToString()));
                string pagina = Session["PreviousPage"].ToString();
                Response.Redirect(FuncionesUtiles.eliminarParametroUrl(Session["PreviousPage"].ToString(), "operacion") + "&operacion=2", true);
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

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.Liquidacion oLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
        if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

        oLiquidacion = oLiquidacion.ObtenerLiquidacionAbierta();
        if (oLiquidacion == null)
        {
            cambiarEstadoBoton(false);
            cambiarEstadoTextBox(false);
            lblMensajeError.Text = lblMensajeError.Text = FuncionesUtiles.MensajeError(CodigosErrores.errorLiquidacionCerrada);
            return;
        }

        try
        {
            oNovedadInasistencia.Eliminar(int.Parse(Session["novedadInasistenciaID"].ToString()), int.Parse(Session["_usuID"].ToString()));
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
            Response.Redirect(FuncionesUtiles.eliminarParametroUrl(Session["PreviousPage"].ToString(), "operacion"), true);
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
    }

    private void cargarConceptos(int esAdministrador, string agrupamiento)
    {
        // MANDAR AGRUPAMIENTO DESDE NOVEDADNUEVO 
        // CASO DOCENTES BLOQUEAR TODO SOLO DEJAR ELIMINAR
        ComboConceptos.DataValueField = "ncoId";
        ComboConceptos.DataTextField = "CodigoDenominacion";
        LiquidacionSueldos.Negocio.NovedadConcepto objetoNovedadConcepto = new LiquidacionSueldos.Negocio.NovedadConcepto();

        switch (esAdministrador)
        {
            case 1:
                break;

            case 2:
                if (agrupamiento == "06")
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
                if (agrupamiento == "06")
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

        dt.Columns.Add("CodigoDenominacion", typeof(string), "ncoCod + ' - ' + ncoNombre");
        ComboConceptos.DataSource = dt;
        ComboConceptos.DataBind();
    }

    protected bool fechaValida()
    {
        bool resultado = false;
        if (txtFecha.Text != "")
        {
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