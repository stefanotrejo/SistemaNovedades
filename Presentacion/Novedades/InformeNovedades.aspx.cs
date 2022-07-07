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
    public static readonly String TituloDelFormulario = "Informe de Novedades Cargadas"; // Unmodifiable    
}
public partial class UsuarioRegistracion : System.Web.UI.Page
{
    DataTable dt, dt2, tablaLiquidaciones = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
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
            #region PERFILES
            int perfil = Convert.ToInt32(Session["_esAdministrador"]);
            switch (perfil)
            {
                case 1: //ADMINISTRADOR
                    break;

                case 2: //D.G. PERSONAL - GRUPO 7                       
                    //btnListar.Visible = false;
                    break;

                case 3: //UERT            
                    break;

                case 4: //DIRECTOR                   
                    break;

                case 5: //PERSONAL EXTENDIDO
                        //CASO 2 MAS BOTON CONCEPTOS
                        //btnListar.Visible = false;
                    break;
            }
            #endregion
            String Sesion = Session["Resultado"].ToString();
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
                    
                    //traer años donde haya 
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

                    tablaLiquidaciones = objetoLiquidacion.ObtenerTodos(MenuRaizListaMesDesde.Text, MenuRaizListaAnioDesde.Text.Substring(2),0);

                    comboLiquidaciones.DataSource = dt2;
                    comboLiquidaciones.DataTextField = "liqDescripcion";
                    comboLiquidaciones.DataValueField = "liqId";
                    comboLiquidaciones.SelectedIndex = dt2.Rows.Count - 1;
                    comboLiquidaciones.DataBind();


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
 
    /*
    protected void btnConsultarLugarPago_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            LiquidacionSueldos.Negocio.LugarPago objetoLugarPago = new LiquidacionSueldos.Negocio.LugarPago();
            if (txtCodigoLugarPago.Text.Length == 5)
            {
                if (validarLugarPago(txtCodigoLugarPago.Text))
                {
                    txtDescripcion.Text = objetoLugarPago.ObtenerPorCodigo(Convert.ToInt32(txtCodigoLugarPago.Text)).lpaNombre;
                    btnGenerarListado.Enabled = true;
                }
                else
                {
                    btnGenerarListado.Enabled = false;
                    lblMensajeError.Text = FuncionesUtiles.MensajeError("El codigo ingresado es incorrecto");
                }
            }
            else
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("El codigo debe tener 5 digitos");
                btnGenerarListado.Enabled = false;
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
    */
    protected bool validarLugarPago(string codigo)
    {
        LiquidacionSueldos.Negocio.LugarPago objetoLugarPago = new LiquidacionSueldos.Negocio.LugarPago();
        if (objetoLugarPago.ObtenerPorCodigo(Convert.ToInt32(codigo)) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnGenerarListado_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";

            if (validarLugarPago(txtCodigoLugarPago.Text))
            {
                DateTime fecha1 = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
                Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);

                String NomRep = "InformeEmpleadosporLugardePagoporMesAnioLiq.rpt";
                String MesAnioLiq = MenuRaizListaMesDesde.SelectedValue.Substring(3, 2);
                MesAnioLiq = MesAnioLiq + '/' + MenuRaizListaMesDesde.SelectedValue.Substring(8, 2);
                String MesAnioLiq2 = MenuRaizListaMesDesde.Text + '/' + MenuRaizListaAnioDesde.Text;
                FuncionesUtiles.AbreVentana("Reporte.aspx?LugarPago=" + txtCodigoLugarPago.Text
                                            + "&MesAnioLiq=" + MesAnioLiq
                                            + "&NomRep=" + NomRep);
            }
            else
            {
                btnGenerarListado.Enabled = false;
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

    protected void checkMostrarTodos_CheckedChanged(object sender, EventArgs e)
    {
        // se activa cuando cambia el check


    }
}