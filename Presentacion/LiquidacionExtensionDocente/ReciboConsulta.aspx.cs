using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

//  CONSULTA DE LIQUIDACIONES

public static class Globals
{
    public const Int32 BUFFER_SIZE = 10; // Unmodifiable
    public static String FILE_NAME = "Output.txt"; // Modifiable
    public static readonly String CODE_PREFIX = "US-"; // Unmodifiable
}

public partial class LiquidacionExtensionDocente : System.Web.UI.Page
{
    DataTable dtAnioLiquidaciones, dtLiquidaciones = new DataTable();
    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente = new LiquidacionSueldos.Negocio.NuevoAge1();
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
    LiquidacionSueldos.Negocio.LiquidacionExtensionDocente objetoLiquidacion = new LiquidacionSueldos.Negocio.LiquidacionExtensionDocente();
    LiquidacionSueldos.Negocio.NovedadInasistencia oNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();

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

    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                EstablecerTituloFormulario();

                if (!IsUserAuthenticated())
                {
                    Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                }

                int id = ObtenerIdDesdeQueryString();

                if (this.Master != null)
                {
                    string dni = this.Master.usuNombreIngreso;
                    CargarAniosLiquidacion(dni);
                }
            }
        }
        catch (Exception oError)
        {
            ManejarError(oError, lblMensajeError);
        }
    }

    private void EstablecerTituloFormulario()
    {
        if (this.Master != null)
        {
            this.Master.TituloDelFormulario = "Consulta de Recibo de Sueldo de Extensi�n Horaria Docente";
        }
    }

    private bool IsUserAuthenticated()
    {
        return this.Session["_Autenticado"] != null;
    }

    private int ObtenerIdDesdeQueryString()
    {
        int id;
        return int.TryParse(Request.QueryString["Id"], out id) ? id : 0;
    }

    private void CargarAniosLiquidacion(string dni)
    {
        ocnMenu = new LiquidacionSueldos.Negocio.Menu();
        dtAnioLiquidaciones = ocnMenu.LiquidacionDocenteObtenerAnios(dni);

        MenuRaizListaAnioDesde.DataSource = dtAnioLiquidaciones;
        MenuRaizListaAnioDesde.DataTextField = "anio";
        MenuRaizListaAnioDesde.DataBind();
    }

    private void ManejarError(Exception oError, Label labelError)
    {
        // Puedes loguear el error si tienes un sistema de logging
        // LogManager.LogError(oError);

        labelError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    <a class=""alert-link"" href=""#"">Error</a><br/>
    Ha ocurrido un problema. Por favor, int�ntelo de nuevo m�s tarde.
    </div>";
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            CargarGrilla(1);
        }
        catch (Exception oError)
        {
            ManejarError(oError, lblMensajeError);
        }
    }

    private void CargarGrilla(int pageIndex)
    {
        try
        {
            lblCantidadRegistros.Text = "";
            string dni = this.Master.usuNombreIngreso;

            dtLiquidaciones = objetoLiquidacion.ObtenerTodosDniAnio(dni, 0);

            if (dtLiquidaciones.Rows.Count > 0)
            {
                Grilla.DataSource = dtLiquidaciones;
                Grilla.PageIndex = pageIndex;
                Grilla.DataBind();
                lblCantidadRegistros.Text = "Cantidad de registros: " + dtLiquidaciones.Rows.Count;
            }
            else
            {
                lblCantidadRegistros.Text = "NO SE ENCONTRARON RESULTADOS";
            }
        }
        catch (Exception oError)
        {
            ManejarError(oError, lblMensajeError);
        }
    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = Grilla.Rows[index];
                string id = row.Cells[0].Text;

                if (e.CommandName == "Quitar")
                {
                    ocnMenu.Eliminar(Convert.ToInt32(id));
                    CargarGrilla(Grilla.PageIndex);
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void MenuRaizListaAnioDesde_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ocnMenu = new LiquidacionSueldos.Negocio.Menu();
            dtAnioLiquidaciones = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(MenuRaizListaAnioDesde.SelectedValue));

            MenuRaizListaAnioDesde.DataSource = dtAnioLiquidaciones;
            MenuRaizListaAnioDesde.DataBind();
        }
        catch (Exception oError)
        {
            ManejarError(oError, lblMensajeError);
        }
    }

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }

        if (Grilla.Rows.Count > 0)
        {
            foreach (GridViewRow Fila in Grilla.Rows)
            {
                if (Fila.Cells[3].Text == "No") Fila.BackColor = System.Drawing.Color.Pink;
            }
        }
    }
}
