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
    DataTable dt, dt2 = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    //LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
    LiquidacionSueldos.Negocio.Liquidacion objetoLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();

    #region Variables Globales
    public class GlobalesAgenteConsulta
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

        private static string _Sesion;
        public static string SesionAgenteConsulta
        {
            get
            {
                // Reads are usually simple
                return _Sesion;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _Sesion = value;
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

        private static string _indexOp;
        public static string indexOp
        {
            get
            {
                // Reads are usually simple
                return _indexOp;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _indexOp = value;
            }
        }

        private static string _FechaAux1;
        public static string FechaAux1
        {
            get
            {
                // Reads are usually simple
                return _FechaAux1;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _FechaAux1 = value;
            }
        }

        private static string _FechaAux2;
        public static string FechaAux2
        {
            get
            {
                // Reads are usually simple
                return _FechaAux2;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _FechaAux2 = value;
            }
        }

        private static int _DropDownList1;
        public static int IndiceDropDownList1
        {
            get
            {
                // Reads are usually simple
                return _DropDownList1;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _DropDownList1 = value;
            }
        }

        private static int _DropDownList2;
        public static int IndiceDropDownList2
        {
            get
            {
                // Reads are usually simple
                return _DropDownList2;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _DropDownList2 = value;
            }
        }

        private static int _MenuListaMesDesde;
        public static int IndiceMenuListaMesDesde
        {
            get
            {
                // Reads are usually simple
                return _MenuListaMesDesde;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _MenuListaMesDesde = value;
            }
        }

        private static int _MenuListaMesHasta;
        public static int IndiceMenuListaMesHasta
        {
            get
            {
                // Reads are usually simple
                return _MenuListaMesHasta;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _MenuListaMesHasta = value;
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
            //Primera vez que se carga
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Nueva liquidacion";
                txtAnio.Text = DateTime.Now.Year.ToString();
                txtFechaInicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    if (Id != 0)
                    {
                        this.Master.TituloDelFormulario = "Modificar liquidacion";
                        //Cargo datos de la Liquidacion 
                        objetoLiquidacion = objetoLiquidacion.ObtenerUno(Id);
                        comboMesLiquidacion.SelectedIndex = Convert.ToInt32(objetoLiquidacion.liqMes) - 1;
                        txtAnio.Text = objetoLiquidacion.liqAnio;
                        comboEtapa.SelectedIndex = objetoLiquidacion.liqEtapa - 1;
                        txtDescripcion.Text = objetoLiquidacion.liqDescripcion;

                        //Bloqueo campos que no se deben modificar
                        comboMesLiquidacion.Enabled = false;
                        txtAnio.Enabled = false;
                        comboEtapa.Enabled = false;
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
            if (Request.QueryString["Id"] != null)
            {
                if (txtDescripcion.Text != "")
                {
                    objetoLiquidacion.liqId = Convert.ToInt32(Request.QueryString["Id"]);
                    objetoLiquidacion.liqMes = comboMesLiquidacion.SelectedValue;
                    objetoLiquidacion.liqAnio = txtAnio.Text.Substring(2);
                    objetoLiquidacion.liqEtapa = Convert.ToInt32(comboEtapa.SelectedValue);
                    objetoLiquidacion.liqDescripcion = txtDescripcion.Text;
                    objetoLiquidacion.liqFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                    objetoLiquidacion.liqFechaCierre = null;
                    objetoLiquidacion.liqEstado = "";
                    objetoLiquidacion.liqActivo = 1;

                    //Si es un registro
                    if (objetoLiquidacion.liqId == 0)
                    {
                        if (objetoLiquidacion.ValidarRepetido(objetoLiquidacion.liqMes, objetoLiquidacion.liqAnio, objetoLiquidacion.liqEtapa) == 0)
                        {
                            objetoLiquidacion.Insertar();
                            lblMensajeError.Text = @"<div class=""alert alert-success alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        <a class=""alert-link"" href=""#"">Confirmacion</a><br/>
                        Los cambios se guardaron correctamente<br>" + "</div>";
                        }
                        else
                            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        La etapa seleccionada ya existe en esta Liquidacion <br>" + "</div>";
                    }
                }
                else
                {
                    lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        Debe completar todos los campos<br>" + "</div>";
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("LiquidacionesConsulta.aspx", true);
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