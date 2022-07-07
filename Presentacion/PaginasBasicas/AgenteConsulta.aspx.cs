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
    DataTable dt,dt2 = new DataTable();
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

            String Sesion = Session["Resultado"].ToString();
            if (Sesion == "")
            {
                if (!Page.IsPostBack)
                {
                    this.Master.TituloDelFormulario = "Consulta de Agentes";
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                    int Id = 0;
                    if (Request.QueryString["Id"] != null)
                    {
                        Id = Convert.ToInt32(Request.QueryString["Id"]);                        
                    }
                    this.RadioDni.Checked = true;
                    ocnMenu = new LiquidacionSueldos.Negocio.Menu();
                    //trae solo años
                    dt = ocnMenu.LiquidacionObtenerTodo(); 

                    //trae meses por el año seleccionado
                    dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(dt.Rows[0]["AnioLiq"].ToString()));
                    
                    //CARGA DE DROPDOWNLISTS

                    //MENU ANIO DESDE
                    MenuRaizListaAnioDesde.DataSource = dt;
                    //MenuRaizLista.DataTextField = "Mes";
                    //MenuRaizLista.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioDesde.DataTextField = "AnioLiq";
                    //MenuRaizListaAnioDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioDesde.DataBind();

                    //MENU MES DESDE
                    MenuRaizListaMesDesde.DataSource = dt2;
                    MenuRaizListaMesDesde.DataTextField = "MesLiq";
                    MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesDesde.SelectedIndex = dt2.Rows.Count - 1;

                    MenuRaizListaMesDesde.DataBind();

                    //MENU ANIO HASTA
                    MenuRaizListaAnioHasta.DataSource = dt;
                    MenuRaizListaAnioHasta.DataTextField = "AnioLiq";
                    //MenuRaizListaAnioHasta.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioHasta.DataBind();

                    //MENU MES HASTA
                    MenuRaizListaMesHasta.DataSource = dt2;
                    MenuRaizListaMesHasta.DataTextField = "MesLiq";
                    MenuRaizListaMesHasta.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesHasta.SelectedIndex = dt2.Rows.Count - 1;
                    MenuRaizListaMesHasta.DataBind();                    
                }         
            }

            //SI VUELVE DE AGENTE DETALLE
            else
            {
                try
                {
                    this.Master.TituloDelFormulario = "Consulta de Agentes";
                    int Tipo = Convert.ToInt32(Session["Tipo"]);
                    int index = Convert.ToInt32(Session["index"]);
                    String txtSesion = Session["Textbox"].ToString();
                    txtAgeNroControl.Text = txtSesion;
                    RadioNumeroControl.Checked = false;
                    RadioApellidoyNombre.Checked = false;
                    RadioDni.Checked = false;
                    if (Tipo == 1)
                    {
                        RadioDni.Checked = true;
                    }
                    else
                    {
                        if (Tipo == 2)
                            RadioApellidoyNombre.Checked = true;
                        else
                            RadioNumeroControl.Checked = true;
                    }
                    
                    Session["Resultado"] = "";
                    Session["Tipo"] = "";
                    Session["index"] = "";
                    Session["Textbox"] = "";

                    //CARGA DE MENU LISTA
                    ocnMenu = new LiquidacionSueldos.Negocio.Menu();
                    dt = ocnMenu.LiquidacionObtenerTodo();
                    MenuRaizListaAnioDesde.DataSource = dt;
                    MenuRaizListaAnioDesde.DataTextField = "AnioLiq";
                    //MenuRaizListaAnioDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioDesde.DataBind();
                    MenuRaizListaAnioDesde.SelectedIndex = GlobalesAgenteConsulta.IndiceDropDownList1;

                    MenuRaizListaAnioHasta.DataSource = dt;
                    MenuRaizListaAnioHasta.DataTextField = "AnioLiq";
                    //MenuRaizListaAnioHasta.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioHasta.DataBind();
                    MenuRaizListaAnioHasta.SelectedIndex = GlobalesAgenteConsulta.IndiceDropDownList2;

                    //CARGO MENU LISTA DE MESES CON LOS VALORES QUE ESTABA ANTERIORMENTE
                    DataTable dtmesdesde = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(MenuRaizListaAnioDesde.SelectedValue));
                    DataTable dtmeshasta = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(MenuRaizListaAnioHasta.SelectedValue));

                    MenuRaizListaMesDesde.DataSource = dtmesdesde;
                    MenuRaizListaMesDesde.DataTextField = "MesLiq";
                    MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesDesde.DataBind();
                    MenuRaizListaMesDesde.SelectedIndex = GlobalesAgenteConsulta.IndiceMenuListaMesDesde;

                    MenuRaizListaMesHasta.DataSource = dtmeshasta;
                    MenuRaizListaMesHasta.DataTextField = "MesLiq";
                    MenuRaizListaMesHasta.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesHasta.DataBind();
                    MenuRaizListaMesHasta.SelectedIndex = GlobalesAgenteConsulta.IndiceMenuListaMesHasta;

                    
                    Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue); //PRUEBA
                    Session["Periodo2"] = Convert.ToDateTime(MenuRaizListaMesHasta.SelectedValue); //PRUEBA

                    //GlobalesAgenteConsulta.tipoOp = tipo.ToString();
                    GlobalesAgenteConsulta.indexOp = Grilla.PageIndex.ToString();

                    //Variables de Fechas seleccionadas                    
                    GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaMesDesde.SelectedValue;
                    GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaMesHasta.SelectedValue;

                    //Variables de Indices seleccionados
                    GlobalesAgenteConsulta.IndiceDropDownList1 = MenuRaizListaAnioDesde.SelectedIndex;
                    GlobalesAgenteConsulta.IndiceDropDownList2 = MenuRaizListaAnioHasta.SelectedIndex;
                    GlobalesAgenteConsulta.IndiceMenuListaMesDesde = MenuRaizListaMesDesde.SelectedIndex;
                    GlobalesAgenteConsulta.IndiceMenuListaMesHasta = MenuRaizListaMesHasta.SelectedIndex;
                    GrillaCargar(Convert.ToInt32(Session["AgenteConsulta.PageIndex"]), Tipo);

                }
                catch
                {
                    // EN CASO DE ERROR CON VARIABLES DE SESSION -> CARGAR VALORES POR DEFECTO

                    this.Master.TituloDelFormulario = "Consulta de Agentes";
                    if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                    int Id = 0;
                    if (Request.QueryString["Id"] != null)
                    {
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        /*INCIALIZADORES*/
                        //  ComboAgente.DataValueField = "Valor"; ComboAgente.DataTextField = "Texto"; ComboAgente.DataSource = (new LiquidacionSueldos.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); ComboAgente.DataBind();        
                        // this.ComboAgente.Focus();
                    }
           
                    this.RadioDni.Checked = true;
                    ocnMenu = new LiquidacionSueldos.Negocio.Menu();
                    //trae solo años
                    dt = ocnMenu.LiquidacionObtenerTodo();

                    //trae meses por el año seleccionado
                    dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(dt.Rows[0]["AnioLiq"].ToString()));

                    //CARGA DE DROPDOWNLISTS

                    //MENU ANIO DESDE
                    MenuRaizListaAnioDesde.DataSource = dt;
                    //MenuRaizLista.DataTextField = "Mes";
                    //MenuRaizLista.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioDesde.DataTextField = "AnioLiq";
                    //MenuRaizListaAnioDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioDesde.DataBind();

                    //MENU MES DESDE
                    MenuRaizListaMesDesde.DataSource = dt2;
                    MenuRaizListaMesDesde.DataTextField = "MesLiq";
                    MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesDesde.SelectedIndex = dt2.Rows.Count - 1;

                    MenuRaizListaMesDesde.DataBind();

                    //MENU ANIO HASTA
                    MenuRaizListaAnioHasta.DataSource = dt;
                    MenuRaizListaAnioHasta.DataTextField = "AnioLiq";
                    //MenuRaizListaAnioHasta.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaAnioHasta.DataBind();

                    //MENU MES HASTA
                    MenuRaizListaMesHasta.DataSource = dt2;
                    MenuRaizListaMesHasta.DataTextField = "MesLiq";
                    MenuRaizListaMesHasta.DataValueField = "Periodo de Liquidacion";
                    MenuRaizListaMesHasta.SelectedIndex = dt2.Rows.Count - 1;
                    MenuRaizListaMesHasta.DataBind();
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
            DateTime fecha1 = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
            DateTime fecha2 = Convert.ToDateTime(MenuRaizListaMesHasta.SelectedValue);
            
            Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
            Session["Periodo2"] = Convert.ToDateTime(MenuRaizListaMesHasta.SelectedValue);            

            int radioSeleccionado = 0;
            if (fecha1 <= fecha2)
            {
                if (txtAgeNroControl.Text != "") // VERIFICA QUE EL USUARIO HAYA INGRESADO ALGUN TEXTO
                {
                    Grilla.PageIndex = 0;
                    GlobalesAgenteConsulta.tipoOp = radioSeleccionado; 
                    GlobalesAgenteConsulta.indexOp = Grilla.PageIndex.ToString();                   
                    GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaMesDesde.SelectedValue;
                    GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaMesHasta.SelectedValue;

                    //Variables de Indices seleccionados
                    GlobalesAgenteConsulta.IndiceDropDownList1 = MenuRaizListaAnioDesde.SelectedIndex;
                    GlobalesAgenteConsulta.IndiceDropDownList2 = MenuRaizListaAnioHasta.SelectedIndex;
                    GlobalesAgenteConsulta.IndiceMenuListaMesDesde = MenuRaizListaMesDesde.SelectedIndex;
                    GlobalesAgenteConsulta.IndiceMenuListaMesHasta = MenuRaizListaMesHasta.SelectedIndex;
                    
                    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();

                    if (RadioNumeroControl.Checked == true) 
                    {
                        if (txtAgeNroControl.Text.Length == 8)
                        {
                            radioSeleccionado = 3;                            
                            GlobalesAgenteConsulta.tipoOp = radioSeleccionado;
                            GrillaCargar(Grilla.PageIndex, radioSeleccionado);
                        }
                        else
                        {
                            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                            El Numero de Control debe contener 8 digitos<br>" + "</div>";
                        }
                    }
                    // BUSCAR POR CUIL
                    else
                    {
                        if (RadioDni.Checked == true)
                        {
                            if (txtAgeNroControl.Text.Length >= 7)
                            {
                                radioSeleccionado = 1;
                                GlobalesAgenteConsulta.tipoOp = radioSeleccionado;
                                GrillaCargar(Grilla.PageIndex, radioSeleccionado);
                            }
                            else
                            {                                
                                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                               
                                El DNI debe contener 8 digitos<br>" + "</div>";
                            }
                        }
                        else
                        {
                            radioSeleccionado = 2;
                            GlobalesAgenteConsulta.tipoOp = radioSeleccionado;
                            GrillaCargar(Grilla.PageIndex, radioSeleccionado);
                        }
                    }
                }
            } 
            else 
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                La Fecha 'Hasta' no puede ser menor a la Fecha 'Desde'<br>" + "</div>";
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

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Grilla.Rows.Count != 0)
            {
                String NomRep = "InformeAgentesGenerico.rpt";
                //String NomRep = "CrystalReport.rpt";
                //DateTime periodoDesde = Convert.ToDateTime(MenuRaizListaAnioDesde.SelectedValue);
                //DateTime periodoHasta = Convert.ToDateTime(MenuRaizListaAnioHasta.SelectedValue);
                DateTime periodoDesde = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
                DateTime periodoHasta = Convert.ToDateTime(MenuRaizListaMesHasta.SelectedValue);
                String nombre = "";
                String nrocontrol = "";
                String dni = "";
                
                int tipo = 0;
                if (periodoDesde <= periodoHasta)
                {
                    if (txtAgeNroControl.Text != "") // VERIFICA QUE EL USUARIO HAYA INGRESADO ALGUN TEXTO
                    {
                        GlobalesAgenteConsulta.tipoOp = tipo;
                        GlobalesAgenteConsulta.indexOp = Grilla.PageIndex.ToString();
                        //Variables de Fechas seleccionadas
                        //GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaAnioDesde.SelectedValue;
                        //GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaAnioHasta.SelectedValue;
                        GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaMesDesde.SelectedValue;
                        GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaMesHasta.SelectedValue;
                        //Variables de Indices seleccionados
                        GlobalesAgenteConsulta.IndiceDropDownList1 = MenuRaizListaAnioDesde.SelectedIndex;
                        GlobalesAgenteConsulta.IndiceDropDownList2 = MenuRaizListaAnioHasta.SelectedIndex;
                        GlobalesAgenteConsulta.IndiceMenuListaMesDesde = MenuRaizListaMesDesde.SelectedIndex;
                        GlobalesAgenteConsulta.IndiceMenuListaMesHasta = MenuRaizListaMesHasta.SelectedIndex;
                        //Session["Periodo1"] = fecha1;
                        //Session["Periodo2"] = fecha2;
                        //Session["Periodo1"] = MenuRaizLista.SelectedValue;
                        //Session["Periodo2"] = MenuRaizLista2.SelectedValue;

                        LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
                        if (RadioNumeroControl.Checked == true) //BUSCAR POR NUMERO DE CONTROL
                        {
                            if (txtAgeNroControl.Text.Length == 8)
                            {
                                nrocontrol = txtAgeNroControl.Text;
                                FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
                                    + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
                                    + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);                                
                            }
                            else
                            {
                                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                            El Numero de Control debe contener 8 digitos<br>" + "</div>";
                            }
                        }
                        else // // BUSCAR POR CUIL
                        {
                            if (RadioDni.Checked == true)
                            {
                                if (txtAgeNroControl.Text.Length >= 7)
                                {
                                    dni = txtAgeNroControl.Text;
                                    FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
                                        + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
                                        + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);                                    
                                }
                                else
                                {
                                    lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                                El DNI debe contener 8 digitos<br>" + "</div>";
                                }
                            }
                            else
                            {
                                nombre = txtAgeNroControl.Text;
                                FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
                                    + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
                                    + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);                                
                            }
                        }                                           
                    }
                }
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    No hay datos para listar<br>" + "</div>";

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

    private void GrillaCargar(int PageIndex, int tipo)
    {
        try
        {
            Session["AgenteConsulta.PageIndex"] = PageIndex;
            Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue); //PRUEBA
            Session["Periodo2"] = Convert.ToDateTime(MenuRaizListaMesHasta.SelectedValue); //PRUEBA
            //Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaAnioDesde.SelectedValue); //PRUEBA
            //Session["Periodo2"] = Convert.ToDateTime(MenuRaizListaAnioHasta.SelectedValue); //PRUEBA
            dt = new DataTable();
            if (tipo == 1) //BUSCAR POR DNI
            {
                if (txtAgeNroControl.Text.Length == 8)
                {
                    //dt = ocnAgente.ObtenerAgentePorCuil(txtAgeNroControl.Text, Convert.ToDateTime(GlobalesAgenteConsulta.FechaAux1), Convert.ToDateTime(GlobalesAgenteConsulta.FechaAux2));

                    //CASO D.G PERSONAL - MOSTRAR SIN FILTRO
                    //if (Convert.ToInt32(Session["_esAdministrador"]) == 2)
                    //{
                    //    dt = ocnAgente.ObtenerAgentePorDni(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    //    //dt = ocnAgente.ObtenerAgentePorDni(txtAgeNroControl.Text, Convert.ToDateTime(MenuRaizLista.SelectedValue), Convert.ToDateTime(MenuRaizLista.SelectedValue));
                    //}
                    //else
                    //{
                    //    dt = ocnAgente.ObtenerAgentePorDniConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    //}
                    dt = ocnAgente.ObtenerAgentePorDniConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    if (dt.Rows.Count == 0) //Verifica que existe al menos 1 agente
                    {
                        lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        
                        El DNI ingresado no existe en esta liquidacion<br>" + "</div>";
                        this.Grilla.DataSource = null;
                        this.Grilla.DataBind();
                    }
                }
                else
                {
                    //lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                    //El DNI debe contener 8 digitos<br>" + "</div>";


                    lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                    El DNI debe contener 8 digitos<br>" + "</div>";

                    this.Grilla.DataSource = null;
                    this.Grilla.DataBind();
                }
            }
            else
            {
                if (tipo == 2) //BUSCAR POR NOMRBE
                {
                    ////CASO D.G PERSONAL - MOSTRAR SIN FILTRO
                    //if (Convert.ToInt32(Session["_esAdministrador"]) == 2)
                    //{
                    //    dt = ocnAgente.ObtenerAgentesPorNombre(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    //    //dt = ocnAgente.ObtenerAgentesPorNombre(txtAgeNroControl.Text, Convert.ToDateTime(MenuRaizLista.SelectedValue), Convert.ToDateTime(MenuRaizLista.SelectedValue));
                    //}
                    //else
                    //{
                    //    dt = ocnAgente.ObtenerAgentesPorNombreConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    //    //dt = ocnAgente.ObtenerAgentesPorNombreConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(MenuRaizLista.SelectedValue), Convert.ToDateTime(MenuRaizLista.SelectedValue));
                    //}
                    dt = ocnAgente.ObtenerAgentesPorNombreConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    if (dt.Rows.Count == 0) //Verifica que existe al menos 1 agente
                    {
                        lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        
                        El nombre ingresado no existe en el periodo de liquidacion seleccionado<br>" + "</div>";
                        this.Grilla.DataSource = null;
                        this.Grilla.DataBind();
                    }
                }
                else
                {
                    ////NRO DE CONTROL
                    ////CASO D.G PERSONAL - MOSTRAR SIN FILTRO
                    //if (Convert.ToInt32(Session["_esAdministrador"]) == 2)
                    //{
                    //    dt = ocnAgente.ObtenerAgenteXNroControl(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    //}
                    //else
                    //{
                    //    dt = ocnAgente.ObtenerAgenteXNroControlConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));
                    //}
                    dt = ocnAgente.ObtenerAgentesPorNroControlConFiltro(txtAgeNroControl.Text, Convert.ToDateTime(Session["Periodo1"]), Convert.ToDateTime(Session["Periodo2"]));                    
                        if (dt.Rows.Count == 0) //Verifica que existe al menos 1 agente
                        {
                            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        
                        El Numero de Control ingresado no existe en esta liquidacion<br>" + "</div>";
                            this.Grilla.DataSource = null;
                            this.Grilla.DataBind();
                        }                    
                }
            }
            if (dt.Rows.Count != 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();

                //if (dt.Rows.Count > 0)
                //{
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
                //}
            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
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

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page" && e.CommandName != "")
            {
                string Id = ((HyperLink)Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Controls[1]).Text;

                //if (e.CommandName == "Eliminar")
                //{
                //    ocnPerfil.Eliminar(Convert.ToInt32(Id));
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                //if (e.CommandName == "Copiar")
                //{
                //    ocnPerfil = new LiquidacionSueldos.Negocio.Perfil(Convert.ToInt32(Id));
                //    ocnPerfil.Copiar();
                //    this.GrillaCargar(this.Grilla.PageIndex);
                //}

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("PerfilRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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

    protected void Grilla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='#F7F7DE';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int tipo = 0;
            if (RadioDni.Checked == true)
            {
                tipo = 1;
            }
            else
            {
                if (RadioApellidoyNombre.Checked == true)
                {
                    tipo = 2;
                }
                else
                {
                    tipo = 3;
                }
            }
            if (Session["AgenteConsulta.PageIndex"] != null)
            {
                Session["AgenteConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("AgenteConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex, tipo);
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

    protected void lbuEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            ((LinkButton)sender).Visible = false;
            ((LinkButton)sender).Parent.Controls[3].Visible = true;
            ((LinkButton)sender).Parent.Controls[5].Visible = true;
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

    protected void btnEliminarCancelar_Click(object sender, EventArgs e)
    {
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

    protected void RadioNumeroControl_CheckedChanged(object sender, EventArgs e)
    {
        RadioDni.Checked = false;
        RadioApellidoyNombre.Checked = false;
        this.txtAgeNroControl.Text = "";
        this.txtAgeNroControl.Focus();
    }

    protected void RadioDni_CheckedChanged(object sender, EventArgs e)
    {
        RadioNumeroControl.Checked = false;
        RadioApellidoyNombre.Checked = false;
        this.txtAgeNroControl.Text = "";
        this.txtAgeNroControl.Focus();
    }

    protected void RadioApellidoyNombre_CheckedChanged(object sender, EventArgs e)
    {
        RadioNumeroControl.Checked = false;
        RadioDni.Checked = false;
        this.txtAgeNroControl.Text = "";
        this.txtAgeNroControl.Focus();
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

    protected void MenuRaizListaAnioHasta_SelectedIndexChanged(object sender, EventArgs e)
    {
        GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaAnioHasta.SelectedValue;
        GlobalesAgenteConsulta.IndiceDropDownList2 = MenuRaizListaAnioHasta.SelectedIndex;
        GlobalesAgenteConsulta.IndiceMenuListaMesHasta = MenuRaizListaMesHasta.SelectedIndex;
        //CARGO DROPDOWN MESES
        ocnMenu = new LiquidacionSueldos.Negocio.Menu();
        //        int anio = Convert.ToInt32(MenuRaizListaAnioHasta.SelectedValue.Substring(6));

        dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(MenuRaizListaAnioHasta.SelectedValue));
        MenuRaizListaMesHasta.DataSource = dt2;
        MenuRaizListaMesHasta.DataTextField = "MesLiq";
        MenuRaizListaMesHasta.DataValueField = "Periodo de Liquidacion";
        MenuRaizListaMesHasta.DataBind();


    }    
}