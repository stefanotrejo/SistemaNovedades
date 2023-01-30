using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using LiquidacionSueldos.Negocio;

// ABM DE LIQUIDACIONES

public partial class LiquidacionExtensionDocenteAlta : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Perfil ocnPerfil = new LiquidacionSueldos.Negocio.Perfil();
    DataTable dt, dt2 = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();    
    LiquidacionSueldos.Negocio.LiquidacionExtensionDocente objetoLiquidacion = new LiquidacionSueldos.Negocio.LiquidacionExtensionDocente();
    LiquidacionNovedades objetoLiquidacionAbierta = new LiquidacionNovedades();

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
            if (!this.Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Nueva Liquidacion Extension Docente";
                this.txtAnio.Text = DateTime.Now.Year.ToString();
                this.generarDescripcion();
                this.txtFechaInicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                int liquidacionID = 0;
                if (base.Request.QueryString["Id"] != null)
                {
                    liquidacionID = Convert.ToInt32(base.Request.QueryString["Id"]);
                    if (liquidacionID == 0)
                    {
                        this.txtEstado.Enabled = false;
                        this.txtEstado.Text = "A";
                    }
                    // Si es modificacion
                    else
                    {
                        this.Master.TituloDelFormulario = "Modificar liquidacion";
                        this.objetoLiquidacion = this.objetoLiquidacion.ObtenerUno(liquidacionID);
                        this.comboMesLiquidacion.SelectedIndex = Convert.ToInt32(this.objetoLiquidacion.liqMes) - 1;
                        this.txtAnio.Text = this.objetoLiquidacion.liqAnio;
                        this.txtEstado.Text = this.objetoLiquidacion.liqEstado;
                        this.comboEtapa.SelectedIndex = this.objetoLiquidacion.liqEtapa - 1;
                        this.txtDescripcion.Text = this.objetoLiquidacion.liqDescripcion;
                        this.comboMesLiquidacion.Enabled = false;
                        this.txtAnio.Enabled = false;
                        this.comboEtapa.Enabled = false;
                    }
                }
                this.objetoLiquidacionAbierta = new LiquidacionNovedades();
                this.objetoLiquidacionAbierta = this.objetoLiquidacionAbierta.ObtenerLiquidacionAbierta();
            }
        }
        catch (Exception exception1)
        {
            Exception exception = exception1;
            Label label = this.lblMensajeError;
            object[] message = new object[] { "<div class=\"alert alert-danger alert-dismissable\">\r\n<button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>\r\n<a class=\"alert-link\" href=\"#\">Error de Sistema</a><br/>\r\nSe ha producido el siguiente error:<br/>\r\nMESSAGE:<br>", exception.Message, "<br><br>EXCEPTION:<br>", exception.InnerException, "<br><br>TRACE:<br>", exception.StackTrace, "<br><br>TARGET:<br>", exception.TargetSite, "</div>" };
            label.Text = string.Concat(message);
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (base.Request.QueryString["Id"] != null)
            {
                this.generarDescripcion();
                this.objetoLiquidacion.liqId = Convert.ToInt32(base.Request.QueryString["Id"]);
                this.objetoLiquidacion.liqMes = this.convertirMesAnumeroMenosUno(this.comboMesLiquidacion.SelectedValue);
                if (this.txtAnio.Text.Length != 4)
                {
                    this.objetoLiquidacion.liqAnio = this.txtAnio.Text;
                }
                else
                {
                    this.objetoLiquidacion.liqAnio = this.txtAnio.Text.Substring(2, 2);
                }
                this.objetoLiquidacion.liqEtapa = Convert.ToInt32(this.comboEtapa.SelectedValue);
                this.objetoLiquidacion.liqDescripcion = this.txtDescripcion.Text;
                if (this.txtFechaInicio.Text == "")
                {
                    this.objetoLiquidacion.liqFechaInicio = Convert.ToDateTime("01/01/2001 00:00:00");
                }
                else
                {
                    this.objetoLiquidacion.liqFechaInicio = Convert.ToDateTime(this.txtFechaInicio.Text);
                }
                if (this.txtFechaCierre.Text == "")
                {
                    this.objetoLiquidacion.liqFechaCierre = new DateTime?(Convert.ToDateTime("01/01/2001 00:00:00"));
                }
                else
                {
                    this.objetoLiquidacion.liqFechaCierre = new DateTime?(Convert.ToDateTime(this.txtFechaCierre.Text));
                }

                this.objetoLiquidacion.liqEstado = this.txtEstado.Text;
                this.objetoLiquidacion.liqActivo = 1;

                if (this.objetoLiquidacion.liqId != 0)
                {
                    this.objetoLiquidacion.Actualizar(this.objetoLiquidacion.liqId, this.objetoLiquidacion.liqDescripcion, this.objetoLiquidacion.liqMes, this.objetoLiquidacion.liqAnio, this.objetoLiquidacion.liqEtapa, this.objetoLiquidacion.liqEstado, this.objetoLiquidacion.liqFechaInicio, this.objetoLiquidacion.liqFechaCierre, this.objetoLiquidacion.liqActivo);
                }
                else if (this.objetoLiquidacion.ValidarRepetido(this.objetoLiquidacion.liqMes, this.objetoLiquidacion.liqAnio, this.objetoLiquidacion.liqEtapa) != 0)
                {
                    this.lblMensajeError.Text = "<div class=\"alert alert-danger alert-dismissable\">\r\n                        <button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>                        \r\n                        La etapa seleccionada ya existe en esta Liquidacion <br></div>";
                }
                else
                {
                    int num = this.objetoLiquidacion.Insertar();
                    if (this.objetoLiquidacion.liqEtapa > 1)
                    {
                        this.objetoLiquidacion.AbrirEtapa(num);
                    }
                    this.lblMensajeError.Text = "<div class=\"alert alert-success alert-dismissable\">\r\n                        <button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>\r\n                        <a class=\"alert-link\" href=\"#\">Confirmacion</a><br/>\r\n                        Los cambios se guardaron correctamente<br></div>";
                }
            }
        }
        catch (Exception exception1)
        {
            Exception exception = exception1;
            Label label = this.lblMensajeError;
            object[] message = new object[] { "<div class=\"alert alert-danger alert-dismissable\">\r\n<button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>\r\n<a class=\"alert-link\" href=\"#\">Error de Sistema</a><br/>\r\nSe ha producido el siguiente error:<br/>\r\nMESSAGE:<br>", exception.Message, "<br><br>EXCEPTION:<br>", exception.InnerException, "<br><br>TRACE:<br>", exception.StackTrace, "<br><br>TARGET:<br>", exception.TargetSite, "</div>" };
            label.Text = string.Concat(message);
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

    protected void comboMesLiquidacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.generarDescripcion();
    }

    protected void generarDescripcion()
    {
        string str = "";
        string text = this.comboEtapa.Text;
        string str1 = text;
        if (text != null)
        {
            if (str1 == "1")
            {
                str = "Primera";
            }
            else if (str1 == "2")
            {
                str = "Segunda";
            }
            else if (str1 == "3")
            {
                str = "Tercera";
            }
        }
        TextBox textBox = this.txtDescripcion;
        string[] strArrays = new string[] { str, " Etapa del mes de ", this.comboMesLiquidacion.Text, " del ", this.txtAnio.Text };
        textBox.Text = string.Concat(strArrays);
    }

    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        this.generarDescripcion();
    }

    protected void comboEtapa_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.generarDescripcion();
    }

    protected string convertirMesAnumeroMenosUno(string mes)
    {
        string str = mes;
        string str1 = str;
        if (str != null)
        {
            switch (str1)
            {
                case "Enero":
                    {
                        return "12";
                    }
                case "Febrero":
                    {
                        return "01";
                    }
                case "Marzo":
                    {
                        return "02";
                    }
                case "Abril":
                    {
                        return "03";
                    }
                case "Mayo":
                    {
                        return "04";
                    }
                case "Junio":
                    {
                        return "05";
                    }
                case "Julio":
                    {
                        return "06";
                    }
                case "Agosto":
                    {
                        return "07";
                    }
                case "Septiembre":
                    {
                        return "08";
                    }
                case "Octubre":
                    {
                        return "09";
                    }
                case "Noviembre":
                    {
                        return "10";
                    }
                case "Diciembre":
                    {
                        return "11";
                    }
            }
        }
        return "00";
    }
}