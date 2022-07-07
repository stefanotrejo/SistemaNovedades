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
    public static readonly String TituloDelFormulario = "Informe de Novedades por Jurisdiccion"; // Unmodifiable    
}
public partial class UsuarioRegistracion : System.Web.UI.Page
{
    DataTable listaJurisdiccion, novedades = new DataTable();
    LiquidacionSueldos.Negocio.Jurisdiccion oJurisdiccion = new LiquidacionSueldos.Negocio.Jurisdiccion();
    LiquidacionSueldos.Negocio.NovedadInasistencia oNovedadInasistencia = new LiquidacionSueldos.Negocio.NovedadInasistencia();
    LiquidacionSueldos.Negocio.Liquidacion oLiquidacion = new LiquidacionSueldos.Negocio.Liquidacion();

    #region Variables Globales
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

        private static int _liqId;
        public static int liqId
        {
            get
            {
                return _liqId;
            }
            set
            {
                _liqId = value;
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

                    oLiquidacion = oLiquidacion.ObtenerLiquidacionAbierta();
                    Globales.liqId = oLiquidacion.liqId;

                    // Combos
                    listaJurisdiccion = oJurisdiccion.ObtenerTodosSelect();
                    selectJurisdiccion.DataSource = listaJurisdiccion;
                    selectJurisdiccion.DataTextField = "jurNombre";
                    selectJurisdiccion.DataValueField = "jurId";
                    selectJurisdiccion.DataBind();
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

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensajeError.Text = "";
            novedades = oNovedadInasistencia.ObtenerTodoLiquidacionJurisdiccion(Globales.liqId, Convert.ToInt32(selectJurisdiccion.SelectedValue));
            if (novedades.Rows.Count > 0)
            { 
            // validar si existen novedades para esa liqId y jurId
            lblMensajeError.Text = "";
            String NomRep = "InformeNovedadesCargadasJurisdiccion.rpt";
            FuncionesUtiles.AbreVentana("Reporte.aspx?liqId=" + Globales.liqId
                    + "&jurId=" + selectJurisdiccion.SelectedValue + "&NomRep=" + NomRep);
            }
            else
            {
                lblMensajeError.Text = FuncionesUtiles.MensajeError("No se encontraron Novedades en la Jurisdiccion seleccionada");
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