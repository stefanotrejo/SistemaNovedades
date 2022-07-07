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
}
public partial class UsuarioRegistracion : System.Web.UI.Page
{
    DataTable dt, dt2, listaLiquidaciones = new DataTable();
    LiquidacionSueldos.Negocio.NovedadInasistencia objetoNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();
    LiquidacionSueldos.Negocio.Liquidacion oLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();
    string nombreArchivo = "";

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

        private static int _pageIndex;
        public static int pageIndex
        {
            get
            {
                // Reads are usually simple
                return _pageIndex;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _pageIndex = value;
            }
        }
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

            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Consulta de Agentes";
                if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                }

                // Combos            
                if (selectLiquidaciones.DataTextField == "")
                {
                    listaLiquidaciones = oLiquidacion.ObtenerTodosSelect();
                    selectLiquidaciones.DataSource = listaLiquidaciones;
                    selectLiquidaciones.DataTextField = "Nombre";
                    selectLiquidaciones.DataValueField = "Id";
                    selectLiquidaciones.DataBind();
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

    protected void btnGenerarNoPresentismo_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime fechaseleccionada = Convert.ToDateTime(MenuRaizLista.SelectedValue);            
            dt = new DataTable();
            nombreArchivo = "NOPRESEN";
            lblMensajeError.Text = "";

            // ejecutar sp generar archivo no presentismo
            dt = objetoNovedadInasistencia.GenerarNoPresentismo(Convert.ToInt32(selectLiquidaciones.SelectedValue));
            if (dt.Rows.Count > 0)
                CrearArchivo(dt, nombreArchivo);  
            else
                lblMensajeError.Text = FuncionesUtiles.MensajeError("No se encontraron resultados");

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

    protected void btnGenerarMultasSuspensiones_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime fechaseleccionada = Convert.ToDateTime(MenuRaizLista.SelectedValue);            
            dt = new DataTable();
            nombreArchivo = "MULSUS";
            lblMensajeError.Text = "";

            // ejecutar sp generar archivo no presentismo
            dt = objetoNovedadInasistencia.GenerarMultasSuspensiones(Convert.ToInt32(selectLiquidaciones.SelectedValue));
            if (dt.Rows.Count > 0)
                CrearArchivo(dt, nombreArchivo);
            else
                lblMensajeError.Text = FuncionesUtiles.MensajeError("No se encontraron resultados");                    
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

    protected void CrearArchivo(DataTable dt, string nombreArchivo)
    {
        try
        {
            string Ruta = "C:/Users/stefano/Desktop/";
            if (System.IO.File.Exists(Ruta + nombreArchivo + ".txt"))
            {
                File.SetAttributes(Ruta + nombreArchivo + ".txt", FileAttributes.Normal);
                File.Delete(Ruta + nombreArchivo + ".txt");
            }
            using (StreamWriter file = new StreamWriter(Ruta += nombreArchivo + ".txt", true))
            {
                foreach (DataRow row in dt.Rows)
                {
                    List<string> items = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        items.Add(row[col].ToString());
                    }
                    string linea = string.Join("|", items.ToArray());
                    file.WriteLine(linea);
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

}