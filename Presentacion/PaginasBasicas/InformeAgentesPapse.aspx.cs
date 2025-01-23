using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
public static class Globals
{
    public const Int32 BUFFER_SIZE = 10; // Unmodifiable
    public static String FILE_NAME = "Output.txt"; // Modifiable
    public static readonly String CODE_PREFIX = "US-"; // Unmodifiable
    public static readonly String TituloDelFormulario = "Informe de Agentes"; // Unmodifiable    
    public const Int32 perfilPapse = 0;
    public const string papseReportName = "InformePapseConFiltros.rpt";
    public const string defaultReportName = "InformeEmpleadosporLugardePagoporMesAnioLiq.rpt";
}
public partial class UsuarioRegistracion : System.Web.UI.Page
{
    DataTable dt, dt2 = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
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
            String Sesion = Session["Resultado"].ToString();
            configuracionPapse(true);
            if (Sesion == "")
            {
                if (!Page.IsPostBack)
                {
                    this.Master.TituloDelFormulario = Globals.TituloDelFormulario;
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                    int Id = 0;
                    if (Request.QueryString["Id"] != null)
                    {
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                    }

                    ocnMenu = new LiquidacionSueldos.Negocio.Menu();
                    //trae solo años
                    dt = ocnMenu.LiquidacionObtenerTodo();
                    //trae meses por el año seleccionado
                    dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(dt.Rows[0]["AnioLiq"].ToString()));

                    // Combos
                    MenuRaizListaAnioDesde.DataSource = dt;
                    MenuRaizListaAnioDesde.DataTextField = "AnioLiq";
                    MenuRaizListaAnioDesde.DataBind();

                    MenuRaizListaMesDesde.DataSource = dt2;
                    MenuRaizListaMesDesde.DataTextField = "MesLiq";
                    MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesDesde.SelectedIndex = dt2.Rows.Count - 1;
                    MenuRaizListaMesDesde.DataBind();
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

    protected void configuracionPapse(bool condition)
    {
        txtClaseDesde.Visible = condition;
        lblClaseDesde.Visible = condition;
        txtClaseDesde.Visible = condition;
        lblClaseHasta.Visible = condition;
        txtClaseHasta.Visible = condition;
        lblAntiguedadDesde.Visible = condition;
        lblAntiguedadHasta.Visible = condition;
        txtAntiguedadDesde.Visible = condition;
        txtAntiguedadHasta.Visible = condition;
        lblSexo.Visible = condition;
        radioSexo.Visible = condition;
        btnGenerarListado.Enabled = condition;
    }

    protected void btnGenerarListado_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            String NomRep = Globals.defaultReportName;
            int profileCode = Convert.ToInt32(Session["_esAdministrador"]);
            if (!areValidClasses())
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Verifique los campos clase_desde y clase_hasta");
                return;
            }

            int claseDesde;
            try
            {
                claseDesde = Int32.Parse(txtClaseDesde.Text);
            }
            catch (FormatException)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Ingrese un numero");
                return;
            }

            int claseHasta;
            try
            {
                claseHasta = Int32.Parse(txtClaseHasta.Text);
            }
            catch (FormatException)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Ingrese un numero");
                return;
            }

            if (txtAntiguedadDesde.Text == "")
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Ingrese la antiguedad desde");
                return;
            }

            int antiguedadDesde;
            try
            {
                antiguedadDesde = Int32.Parse(txtAntiguedadDesde.Text);
            }
            catch (FormatException)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Ingrese un numero");
                return;
            }

            if (antiguedadDesde < 0)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("El valor debe ser mayor que 0");
                return;
            }

            if (txtAntiguedadHasta.Text == "")
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Ingrese la antiguedad hasta");
                return;
            }

            int antiguedadHasta;
            try
            {
                antiguedadHasta = Int32.Parse(txtAntiguedadHasta.Text);
            }
            catch (FormatException)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Ingrese un numero");
                return;
            }

            if (antiguedadHasta < 0 || antiguedadHasta > 99)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("El valor debe ser mayor que 0 y menor a 100");
                return;
            }

            if (antiguedadHasta < antiguedadDesde)
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("La antiguedad desde debe ser menor que la antiguedad hasta");
                return;
            }

            if (radioSexo.Text == "")
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("Seleccione el sexo");
                return;
            }

            NomRep = Globals.papseReportName;
            Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
            String MesAnioLiq = MenuRaizListaMesDesde.SelectedValue.Substring(3, 2);
            MesAnioLiq = MesAnioLiq + '/' + MenuRaizListaMesDesde.SelectedValue.Substring(8, 2);

            string sexo = "";
            switch (radioSexo.Text)
            {
                case "M":
                    sexo = "V";
                    break;
                case "F":
                    sexo = "M";
                    break;
            }

            FuncionesUtiles.AbreVentana("Reporte.aspx?LugarPago=" + ""
                           + "&clase_desde=" + txtClaseDesde.Text
                           + "&clase_hasta=" + txtClaseHasta.Text
                           + "&antiguedad_desde=" + txtAntiguedadDesde.Text
                           + "&antiguedad_hasta=" + txtAntiguedadHasta.Text
                           + "&sexo=" + sexo
                           + "&MesAnioLiq=" + MesAnioLiq
                           + "&NomRep=" + NomRep);
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

    protected void MenuRaizListaAnioDesde_SelectedIndexChanged(object sender, EventArgs e)
    {

        //CARGO DROPDOWN MESES
        ocnMenu = new LiquidacionSueldos.Negocio.Menu();
        //int anio = Convert.ToInt32(MenuRaizListaAnioDesde.SelectedValue.Substring(6));

        //actualizo mes desde
        //dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(dt.Rows[0]["AnioLiq"].ToString()));
        dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(MenuRaizListaAnioDesde.SelectedValue));
        //MENU MES DESDE
        MenuRaizListaMesDesde.DataSource = dt2;
        MenuRaizListaMesDesde.DataTextField = "MesLiq";
        MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
        MenuRaizListaMesDesde.DataBind();

        GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaMesDesde.SelectedValue;
        //Variables de Indices seleccionados
        GlobalesAgenteConsulta.IndiceDropDownList1 = MenuRaizListaAnioDesde.SelectedIndex;
        GlobalesAgenteConsulta.IndiceMenuListaMesDesde = MenuRaizListaMesDesde.SelectedIndex;

        //dt = ocnMenu.LiquidacionObtenerPorAnio(anio);
        //MenuRaizListaMesDesde.DataSource = dt;
        //MenuRaizListaMesDesde.DataTextField = "MesLiq";
        //MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
        //MenuRaizListaMesDesde.DataBind();
    }

    protected bool areValidClasses()
    {
        return ((txtClaseDesde.Text.Length == 4) && (txtClaseHasta.Text.Length == 4))
            && int.Parse(txtClaseDesde.Text) <= int.Parse(txtClaseHasta.Text)
            && int.Parse(txtClaseDesde.Text) > 0
            && int.Parse(txtClaseHasta.Text) > 0;
    }
}