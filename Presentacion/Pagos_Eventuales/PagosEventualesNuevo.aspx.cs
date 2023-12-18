using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

//  CONSULTA DE PAGOS EVENTALES

public partial class UsuarioRegistracion : System.Web.UI.Page
{

    //Region variables globales 
    LiquidacionSueldos.Negocio.Agente ocnAgente = new LiquidacionSueldos.Negocio.Agente();
    public class Globales
    {
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
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Pagos Eventuales";
                if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                this.RadioNumeroControl.Checked = true;
                this.txtAgeNroControl.Focus();
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
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

    #region Radios

    protected void RadioNumeroControl_CheckedChanged(object sender, EventArgs e)
    {
        RadioCuil.Checked = false;
    }

    protected void RadioCuil_CheckedChanged(object sender, EventArgs e)
    {
        RadioNumeroControl.Checked = false;
    }

    #endregion

    protected void BtnConsultarLugarPago_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            if ((txtAgeCuit.Text.Trim().Length != 0) && (txtAgeLugarPagoCodigo.Text.Trim().Length != 0))
            {
                LiquidacionSueldos.Negocio.Agente ocnAgente3 = new LiquidacionSueldos.Negocio.Agente();
                ocnAgente3 = ocnAgente.ObtenerAgentePorCuilyLugarDePago(txtAgeCuit.Text, txtAgeLugarPagoCodigo.Text);
                Globales.NroControl = ocnAgente3.ageNroControl;
                if (ocnAgente3 != null) //VERIFICA QUE EXISTE UN AGENTE CON ESE CUIL Y LUGAR DE PAGO
                {
                    txtAgeLugarPago.Text = ocnAgente3.LugarPago;
                }
                else
                {
                    lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">El Lugar de Pago es incorrecto</a><br/>";
                }
            }
            else //CUIL O CODIGO DE LUGAR DE PAGO VACIO
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">El CUIL o Codigo de Lugar de Pago es incorrecto</a><br/>";
            }
        }
        catch (Exception oError)
        {
            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">El CUIL o Codigo de Lugar de Pago es incorrecto</a><br/>
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
            LiquidacionSueldos.Negocio.Agente agenteObtenido = new LiquidacionSueldos.Negocio.Agente();

            //Busca Agente por numero de control
            if (RadioNumeroControl.Checked == true)
            {
                agenteObtenido = ocnAgente.ObtenerAgentePorNroControl(this.txtAgeNroControl.Text);
                if (agenteObtenido.LugarPago != null) //Si el lugar de pago del agente coincide con un lug de pago existente
                {
                    this.txtAgeApellidoNombre.Text = agenteObtenido.ageApellidoNombre;
                    this.txtAgeCuit.Text = agenteObtenido.ageCUIT;
                    this.txtAgeLugarPago.Text = agenteObtenido.LugarPago;
                    this.txtAgeLugarPagoCodigo.Text = agenteObtenido.lpaCodigo.ToString();
                }

                //EL NRO DE CONTROL NO EXISTE  -> Seteo campos en vacio y muestro error
                else
                {
                    txtAgeCuit.Text = "";
                    txtAgeLugarPagoCodigo.Text = "";
                    txtAgeLugarPago.Text = "";
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("El Numero de Control ingresado no existe");
                    /*lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                    El Numero de Control ingresado no existe<br>" + "</div>";*/
                }
            }
            //Busca Agente por CUIL
            else
            {
                agenteObtenido = ocnAgente.ObtenerAgentePorCuil(txtAgeNroControl.Text);
                //Si trae algun agente con ese cuil
                if (agenteObtenido.ageApellidoNombre != null)
                {
                    this.txtAgeApellidoNombre.Text = agenteObtenido.ageApellidoNombre;
                    this.txtAgeCuit.Text = agenteObtenido.ageCUIT;
                    this.txtAgeLugarPago.Text = agenteObtenido.LugarPago;
                    this.txtAgeLugarPagoCodigo.Text = agenteObtenido.lpaCodigo.ToString();
                    this.txtAgeLugarPagoCodigo.ReadOnly = true;
                    this.txtAgeLugarPago.ReadOnly = true;
                }
                else
                {
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("El Cuil ingresado no existe");
                    /*lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                    El Cuil ingresado no existe<br>" + "</div>";*/
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
            if (txtAgeImporte.Text.Trim().Length != 0)
            {
                // BUSQUEDA POR CUIL
                if (RadioCuil.Checked == true)
                {
                    //ocnAgente.ageNroControl = Globales.NroControl; //Toma el numero de control de la var global en caso de buscar por cuil
                    //por si modifica el cuil despues de haber hecho la consulta
                    ocnAgente = ocnAgente.ObtenerAgentePorCuil(this.txtAgeNroControl.Text);
                }
                // BUSQUEDA POR NRO DE CONTROL
                else
                {
                    ocnAgente = ocnAgente.ObtenerAgentePorNroControl(this.txtAgeNroControl.Text);
                    //ocnAgente.ageNroControl = this.txtAgeNroControl.Text;//Toma el numero de control del formulario 
                }

                //ocnAgente = ocnAgente.ObtenerAgentePorNroControl(ocnAgente.ageNroControl);                
                //int Id = Convert.ToInt32(Request.QueryString["Id"]);                

                //Conversion cuil a dni
                String ageCuit = txtAgeCuit.Text;
                String ageDni = ageCuit.Substring(2, 8);
                ocnAgente.ageDNI = ageDni;
                float val = Convert.ToSingle(txtAgeImporte.Text);
                ocnAgente.facimporte = val;
                int fechaCorrecta;
                /* fecha correcta
                    1 = Ok
                    0 = Incorrecto
                 */
                int id = 0;

                if (ocnAgente.ageApellidoNombre.Trim().Length != 0)
                {
                    if (CheckBoxAcumulado.Checked == true)
                    #region    PAGO ACUMULADO
                    {
                        ocnAgente.pevPagoAcumulado = 1;
                        fechaCorrecta = FechaComparar(DropDownListMesDesde.SelectedIndex, DropDownListMesHasta.SelectedIndex, Convert.ToInt32(TxtBoxAnioDesde.Text), Convert.ToInt32(TxtBoxAnioHasta.Text));
                        if (fechaCorrecta == 1)
                        {
                            id = ocnAgente.Insertar();
                            ocnAgente.pevId = id;
                            for (int i = DropDownListMesDesde.SelectedIndex; i <= DropDownListMesHasta.SelectedIndex; i++)
                            {
                                ocnAgente.dpeMes = i;
                                ocnAgente.dpeAnio = Convert.ToInt32(TxtBoxAnioDesde.Text);
                                ocnAgente.InsertarDetallePagoEventual();
                            }
                            Response.Redirect("PagosEventualesConsulta.aspx", true);
                        }
                        else
                        {
                            if (fechaCorrecta == 2)
                            {
                                //INSERTA PAGO EVENTUAL EN PAGOS EVENTUALES
                                id = ocnAgente.Insertar();
                                ocnAgente.pevId = id;
                                for (int i = DropDownListMesDesde.SelectedIndex; i <= 12; i++)
                                {
                                    ocnAgente.dpeMes = i;
                                    ocnAgente.dpeAnio = Convert.ToInt32(TxtBoxAnioDesde.Text);
                                    ocnAgente.InsertarDetallePagoEventual();
                                }

                                for (int i = 1; i <= DropDownListMesHasta.SelectedIndex; i++)
                                {
                                    ocnAgente.dpeMes = i;
                                    ocnAgente.dpeAnio = Convert.ToInt32(TxtBoxAnioHasta.Text);
                                    ocnAgente.InsertarDetallePagoEventual();
                                }
                                Response.Redirect("PagosEventualesConsulta.aspx", true);
                            }
                            else
                            {
                                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                                Los años o meses ingresados son incorrectos<br>" + "</div>";
                            }
                        }
                    }
                    #endregion
                    else
                    #region PAGO UNICO 
                    {
                        //VALIDACION FECHAS SELECCIONADAS
                        //comento para cargar pagos de años anteriores
                        //fechaCorrecta = FechaValidar(DropDownListMesDesde.SelectedIndex, Convert.ToInt32(TxtBoxAnioDesde.Text));
                        fechaCorrecta = 1;
                        if (fechaCorrecta == 1)
                        {
                            ocnAgente.pevPagoAcumulado = 0;
                            //INSERTA PAGO EN PAGOS EVENTUALES
                            id = ocnAgente.Insertar();
                            //DAR DE ALTA EL/LOS MESES PAGADOS EN DetallePagoEventual
                            ocnAgente.pevId = id;
                            ocnAgente.dpeMes = DropDownListMesDesde.SelectedIndex;
                            ocnAgente.dpeAnio = Convert.ToInt32(TxtBoxAnioDesde.Text);
                            ocnAgente.dpeConcepto = txtConcepto.Text;
                            ocnAgente.InsertarDetallePagoEventual();
                            Response.Redirect("PagosEventualesConsulta.aspx", true);
                        }
                        //FECHA INCORRECTA
                        else
                        {
                            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                           <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                            El mes ingresado no es valido<br>" + "</div>";
                        }
                    }
                    #endregion
                }
                // NUMERO DE CONTROL NO EXISTE
                else
                {
                    lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                    El número de control no existe<br>" + "</div>";
                }
            }
            //NO INGRESÓ EL IMPORTE
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                Debe ingresar el importe<br>" + "</div>";
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

    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        // Importa desde un TXT y realiza los pagos eventuales automaticamente. Se debe ingresar el mes, año, imorte y descripcion
        try
        {
            bool hayErrores = false;

            #region Validar Errores
            if (DropDownListMesDesde.SelectedIndex != 0)
            {
                if (!String.IsNullOrEmpty(TxtBoxAnioDesde.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(txtAgeImporte.Text.Trim()))
                    {

                        if (!String.IsNullOrEmpty(txtConcepto.Text.Trim()))
                        {

                        }
                        else
                        {
                            lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar el concepto");
                            hayErrores = true;
                        }
                    }
                    else
                    {
                        lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar el Importe");
                        hayErrores = true;
                    }
                }
                else
                {
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe ingresar el Año");
                    hayErrores = true;
                }
            }
            else
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Debe seleccionar el Mes");
                hayErrores = true;
            }
            #endregion

            if (!hayErrores)
            {
                String linea;
                System.IO.StreamReader archivo2 = new System.IO.StreamReader(@"c:\temp\pagoseventuales.txt");
                while (archivo2.EndOfStream == false)
                {
                    linea = archivo2.ReadLine();
                    String numeroControl = linea.Substring(0, 8);
                    if (txtAgeImporte.Text.Trim().Length != 0)
                    {
                        //// BUSQUEDA POR NRO DE CONTROL
                        ocnAgente = ocnAgente.ObtenerAgentePorNroControl(numeroControl);
                        ocnAgente.ageDNI = ocnAgente.ageCUIT.Substring(2, 8);
                        ocnAgente.facimporte = Convert.ToSingle(txtAgeImporte.Text);
                        int id = 0;
                        ocnAgente.pevPagoAcumulado = 0;
                        id = ocnAgente.Insertar();

                        // DAR DE ALTA EL/LOS MESES PAGADOS EN DetallePagoEventual
                        ocnAgente.pevId = id;
                        ocnAgente.dpeMes = DropDownListMesDesde.SelectedIndex;
                        ocnAgente.dpeAnio = Convert.ToInt32(TxtBoxAnioDesde.Text);
                        ocnAgente.dpeConcepto = txtConcepto.Text;
                        ocnAgente.InsertarDetallePagoEventual();
                    }
                    //ERROR IMPORTE
                    else
                    {
                        lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                        Debe ingresar el importe<br>" + "</div>";
                    }
                }
            }

            lblMensajeError.Text = FuncionesUtiles.MensajeExito("Carga realizada correctamente");
            limpiarCampos();
            //Response.Redirect("PagosEventualesConsulta.aspx", true);              
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
            Response.Redirect("PagosEventualesConsulta.aspx", true);
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

    private void limpiarCampos()
    {
        this.txtAgeNroControl.Text = "";
        this.txtAgeImporte.Text = "";
        this.txtConcepto.Text = "";
    }

    protected void CheckBoxAcumulado_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBoxAcumulado.Checked == true)
        {
            TxtBoxAnioHasta.Visible = true;
            DropDownListMesHasta.Visible = true;
        }
        else
        {
            TxtBoxAnioHasta.Visible = false;
            DropDownListMesHasta.Visible = false;
        }
    }

    private int FechaValidar(int MesDesde, int AnioDesde)
    {
        int b = 0;
        if (AnioDesde == DateTime.Now.Year || AnioDesde == DateTime.Now.Year - 1)
        {
            if (MesDesde != 0)
            {
                b = 1;
            }
        }
        return b;
    }

    private int FechaComparar(int MesDesde, int MesHasta, int AnioDesde, int AnioHasta)
    {
        int b = 0;
        //VERIFICA QUE EL USUARIO INGRESE EL AÑO ACTUAL O EL ANTERIOR EN AÑO DESDE Y AÑO HASTA
        // Devuelve 1 = CORRECTO,  0 = INCORRECTO
        if (AnioDesde == DateTime.Now.Year || AnioDesde == DateTime.Now.Year - 1)
        {
            if (AnioHasta == DateTime.Now.Year || AnioHasta == DateTime.Now.Year - 1)
            {
                if (AnioDesde == AnioHasta)
                {
                    if (MesDesde < MesHasta)
                    {
                        if (MesDesde != 0)
                        {
                            //TODO BIEN
                            b = 1;
                        }
                    }
                }
                else
                {
                    if (AnioDesde < AnioHasta)
                    {
                        b = 2;
                    }
                }
            }
        }
        return b;
    }

    protected void btnCuotasPagadas_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep = "AgentePagosRealizados.rpt";
            String numeroControl = "0";
            String dni = "0";            

            if (RadioNumeroControl.Checked)
                numeroControl = txtAgeNroControl.Text;
            else
                dni = txtAgeNroControl.Text.Substring(2, 8);

            FuncionesUtiles.AbreVentana("Reporte.aspx?dni=" + dni + "&numeroControl=" + numeroControl + "&NomRep=" + NomRep);
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
