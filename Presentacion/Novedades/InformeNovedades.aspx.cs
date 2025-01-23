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
    DataTable aniosResult, mesesResult, liquidacionesResult = new DataTable();
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
                    actualizarListaAnios();
                    actualizarListaMeses();
                    actualizarListaLiquidaciones();
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

    protected void actualizarListaAnios()
    {
        aniosResult = ocnMenu.LiquidacionObtenerTodo();
        listaAnios.DataSource = aniosResult;
        listaAnios.DataTextField = "AnioLiq";
        listaAnios.DataBind();
    }

    protected void actualizarListaMeses()
    {
        mesesResult = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(listaAnios.SelectedValue));
        listaMeses.DataSource = mesesResult;
        listaMeses.DataTextField = "MesLiq";
        listaMeses.DataValueField = "Periodo de Liquidacion";
        listaMeses.DataBind();
    }

    protected void actualizarListaLiquidaciones()
    {
        liquidacionesResult = objetoLiquidacion.ObtenerTodos
                                          (listaMeses.Text.Substring(3, 2), listaAnios.Text.Substring(2), 2);
        listaLiquidaciones.DataSource = liquidacionesResult;
        listaLiquidaciones.DataTextField = "liqDescripcion";
        listaLiquidaciones.DataValueField = "liqId";
        listaLiquidaciones.DataBind();
    }

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

            if (String.IsNullOrEmpty(listaLiquidaciones.SelectedValue))
            {
                return;
            }

            //String NomRep = "InformeNovedadesCargadas2.rpt";
            String NomRep = "InformeNovedadesCargadasPorUsuario.rpt";
            
            FuncionesUtiles.AbreVentana("Reporte.aspx?liqId=" + listaLiquidaciones.SelectedValue
                + "&reparticion=" + 2
                    + "&NomRep=" + NomRep);     
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
        actualizarListaMeses();
        actualizarListaLiquidaciones();
    }

    protected void checkMostrarTodos_CheckedChanged(object sender, EventArgs e)
    {
        // se activa cuando cambia el check


    }

    protected void listaLiquidaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void listaMeses_SelectedIndexChanged(object sender, EventArgs e)
    {
        actualizarListaLiquidaciones();
    }
}