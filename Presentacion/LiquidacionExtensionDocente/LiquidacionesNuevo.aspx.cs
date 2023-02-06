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
    //LiquidacionExtensionDocente objetoLiquidacionAbierta = new LiquidacionExtensionDocente();

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
            Master.TituloDelFormulario = "Nueva Liquidacion Extension Docente";
            if (!Page.IsPostBack)
            {
                txtAnio.Text = DateTime.Now.Year.ToString();
                txtFechaInicio.Text = DateTime.Today.ToString("yyyy-MM-dd");
                generarDescripcionLiquidacion();

                int liquidacionID = 0;
                if (base.Request.QueryString["Id"] != null)
                {
                    liquidacionID = Convert.ToInt32(base.Request.QueryString["Id"]);
                    if (liquidacionID != 0)
                    {
                        Master.TituloDelFormulario = "Modificar liquidacion";
                    }
                    objetoLiquidacion = objetoLiquidacion.ObtenerUno(liquidacionID);
                    comboMesLiquidacion.SelectedIndex = Convert.ToInt32(objetoLiquidacion.mes) - 1;
                    txtAnio.Text = objetoLiquidacion.anio;
                    txtEstado.Text = objetoLiquidacion.estado;
                    comboEtapa.SelectedIndex = objetoLiquidacion.etapa - 1;
                    txtDescripcion.Text = objetoLiquidacion.descripcion;
                    //comboMesLiquidacion.Enabled = false;
                    //txtAnio.Enabled = false;
                    //comboEtapa.Enabled = false;

                }
            }
        }
        catch (Exception exception1)
        {
            Exception exception = exception1;
            Label label = lblMensajeError;
            object[] message = new object[] { "<div class=\"alert alert-danger alert-dismissable\">\r\n<button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>\r\n<a class=\"alert-link\" href=\"#\">Error de Sistema</a><br/>\r\nSe ha producido el siguiente error:<br/>\r\nMESSAGE:<br>", exception.Message, "<br><br>EXCEPTION:<br>", exception.InnerException, "<br><br>TRACE:<br>", exception.StackTrace, "<br><br>TARGET:<br>", exception.TargetSite, "</div>" };
            label.Text = string.Concat(message);
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            objetoLiquidacion.mes = convertirMesAnumeroMenosUno(comboMesLiquidacion.SelectedValue);
            if (txtAnio.Text.Length != 4)
            {
                objetoLiquidacion.anio = txtAnio.Text;
            }
            else
            {
                objetoLiquidacion.anio = txtAnio.Text.Substring(2, 2);
            }

            objetoLiquidacion.etapa = Convert.ToInt32(comboEtapa.SelectedValue);
            generarDescripcionLiquidacion();
            objetoLiquidacion.descripcion = txtDescripcion.Text;

            if (txtFechaInicio.Text == "")
            {
                objetoLiquidacion.fechaInicio = Convert.ToDateTime("01/01/2001 00:00:00");
            }
            else
            {
                objetoLiquidacion.fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            }

            if (txtFechaCierre.Text == "")
            {
                objetoLiquidacion.fechaCierre = Convert.ToDateTime("01/01/2001 00:00:00");
            }
            else
            {
                objetoLiquidacion.fechaCierre = Convert.ToDateTime(txtFechaCierre.Text);
            }

            objetoLiquidacion.estado = txtEstado.Text;






            if (base.Request.QueryString["Id"] != null)
            {
                objetoLiquidacion.id = Convert.ToInt32(base.Request.QueryString["Id"]);
            }

            if (objetoLiquidacion.ValidarRepetido(objetoLiquidacion.mes, objetoLiquidacion.anio, objetoLiquidacion.etapa) == 0)
            {
                if (objetoLiquidacion.id != 0)
                {
                    objetoLiquidacion.Actualizar(objetoLiquidacion.id, objetoLiquidacion.descripcion, objetoLiquidacion.mes, objetoLiquidacion.anio, objetoLiquidacion.etapa, objetoLiquidacion.estado, objetoLiquidacion.fechaInicio, objetoLiquidacion.fechaCierre, objetoLiquidacion.activo);
                }
                else
                {
                    int num = objetoLiquidacion.Insertar();
                    if (objetoLiquidacion.etapa > 1)
                    {
                        objetoLiquidacion.AbrirEtapa(num);
                    }
                    lblMensajeError.Text = "<div class=\"alert alert-success alert-dismissable\">\r\n                        <button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>\r\n                        <a class=\"alert-link\" href=\"#\">Confirmacion</a><br/>\r\n                        Los cambios se guardaron correctamente<br></div>";
                }
            }
            else
            {
                lblMensajeError.Text = "<div class=\"alert alert-danger alert-dismissable\">\r\n                        <button aria-hidden=\"true\" data-dismiss=\"alert\" class=\"close\" type=\"button\">x</button>                        \r\n                        La etapa seleccionada ya existe en esta Liquidacion <br></div>";
            }
        }
        catch (Exception exception1)
        {
            Exception exception = exception1;
            Label label = lblMensajeError;
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
        generarDescripcionLiquidacion();
    }

    protected void generarDescripcionLiquidacion()
    {
        string str = "";
        string text = comboEtapa.Text;
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
        TextBox textBox = txtDescripcion;
        string[] strArrays = new string[] { str, " Etapa del mes de ", comboMesLiquidacion.Text, " del ", txtAnio.Text };
        textBox.Text = string.Concat(strArrays);
    }

    protected void txtAnio_TextChanged(object sender, EventArgs e)
    {
        generarDescripcionLiquidacion();
    }

    protected void comboEtapa_SelectedIndexChanged(object sender, EventArgs e)
    {
        generarDescripcionLiquidacion();
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