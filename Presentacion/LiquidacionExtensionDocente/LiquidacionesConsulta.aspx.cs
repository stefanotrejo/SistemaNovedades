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
    DataTable dt, dt2 = new DataTable();
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
            //Si se esta cargando por primera vez
            if (!Page.IsPostBack)
            {
                DeshabilitarBotonesLiquidacion();

                this.Master.TituloDelFormulario = "Consulta de Liquidaciones Extension Docente";
                if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                }

                ocnMenu = new LiquidacionSueldos.Negocio.Menu();

                //Trae solo a�os
                dt = ocnMenu.LiquidacionObtenerTodo();

                //Trae meses por a�o seleccionado
                dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(dt.Rows[0]["AnioLiq"].ToString()));

                //Combo Anio Desde
                MenuRaizListaAnioDesde.DataSource = dt;
                MenuRaizListaAnioDesde.DataTextField = "AnioLiq";
                MenuRaizListaAnioDesde.DataBind();
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
            //DateTime fecha1 = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
            //Session["Periodo1"] = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);
            GrillaCargar(1);
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("LiquidacionesNuevo.aspx?Id=" + 0, false);
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

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLiqId.Text != null)
            {
                Response.Redirect("LiquidacionesNuevo.aspx?Id=" + txtLiqId.Text, false);
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        Debe seleccionar una liquidacion<br>" + "</div>";
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

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLiqId.Text != "")
            {
                lblMensajeError.Text = "";
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        Debe seleccionar una liquidacion<br>" + "</div>";
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

    protected void btnAbrirr_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLiqId.Text != "")
            {
                lblMensajeError.Text = "";
                //UPDATE estado de Liquidacion a: 'A'
                objetoLiquidacion.ActualizarEstado(Convert.ToInt32(txtLiqId.Text), "A");
                Response.Redirect("~/Liquidaciones/LiquidacionesConsulta.aspx", true);
                Session["EstadoLiquidacion"] = 4;
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        Debe seleccionar una liquidacion<br>" + "</div>";
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

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLiqId.Text != "")
            {
                lblMensajeError.Text = "";
                //UPDATE estado de Liquidacion a 'C'
                objetoLiquidacion.ActualizarEstado(Convert.ToInt32(txtLiqId.Text), "C");
                Response.Redirect("~/Liquidaciones/LiquidacionesConsulta.aspx", true);
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        Debe seleccionar una liquidacion<br>" + "</div>";
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

    protected void btnCerrarPersonal_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLiqId.Text != "")
            {
                lblMensajeError.Text = "";
                //UPDATE estado de Liquidacion a 'P'
                objetoLiquidacion.ActualizarEstado(Convert.ToInt32(txtLiqId.Text), "P");
                Session["EstadoLiquidacion"] = 5;

                // GENERAR PARA TODOS LOS PERFILES "PERESADMINISTRADOR"

                DataTable perfilesConNovedades = new DataTable();
                int reparticion = Convert.ToInt32(Session["_esAdministrador"]);
                if (reparticion == 5)
                    reparticion = 2;

                //int liqId = Convert.ToInt32(Session["liqId"].ToString());
                int liqId = Convert.ToInt32(txtLiqId.Text);
                perfilesConNovedades = oNovedadInasistencia.PerfilesConNovedades(liqId);

                foreach (DataRow row in perfilesConNovedades.Rows)
                {
                    generarArchivosNoPresentismo(liqId, Convert.ToInt32(row["perEsAdministrador"].ToString()));
                }

                Response.Redirect("~/Liquidaciones/LiquidacionesConsulta.aspx", true);
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>                        
                        Debe seleccionar una liquidacion<br>" + "</div>";
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

    //    protected void btnListar_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            if (Grilla.Rows.Count != 0)
    //            {
    //                String NomRep = "InformeAgentesGenerico.rpt";
    //                DateTime periodoDesde = Convert.ToDateTime(MenuRaizListaMesDesde.SelectedValue);                
    //                String nombre = "";
    //                String nrocontrol = "";
    //                String dni = "";

    //                int tipo = 0;                
    //            }
    //            else
    //            {
    //                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //    No hay datos para listar<br>" + "</div>";

    //            }
    //        }
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //        Se ha producido el siguiente error:<br/>
    //        MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }

    //    }

    private void GrillaCargar(int PageIndex)
    {
        try
        {

            lblCantidadRegistros.Text = "";
            int liqEtapa = Convert.ToInt32(comboEtapa.SelectedValue);
            if (chkObtenerTodos.Checked == true)
                liqEtapa = 0;

            dt = objetoLiquidacion.ObtenerTodos(MenuRaizListaMesDesde.Text, MenuRaizListaAnioDesde.Text.Substring(2), liqEtapa);

            if (dt.Rows.Count > 0)
            {
                this.Grilla.DataSource = dt;
                this.Grilla.PageIndex = PageIndex;
                this.Grilla.DataBind();
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
            }
            else
            {
                lblCantidadRegistros.Text = "NO SE ENCONTRARON RESULTADOS";
                //lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
                //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
                //No se encontraron resultados<br>" + "</div>";
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void Grilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort" && e.CommandName != "Page")
            {
                string Id = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                if (e.CommandName == "Quitar")
                {
                    ocnMenu.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Seleccionar")
                {
                    txtLiqId.Text = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    txtMes.Text = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                    txtAnio.Text = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                    txtEtapa.Text = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                    txtFechaInicio.Text = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text.Substring(0, 10);
                    if (Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text == "")
                        txtEstado.Text = "";
                    else
                        txtEstado.Text = Grilla.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
                    HabilitarBotonesLiquidacion();
                    //Habilita o deshabilita botones de Abrir y Cerrar Liquidacion
                    switch (txtEstado.Text)
                    {
                        case "A":
                            btnCerrarPersonal.Enabled = true;
                            btnCerrar.Enabled = false;
                            btnAbrir.Enabled = false;
                            btnGenerarArchivos.Enabled = true;
                            break;
                        case "P":
                            btnCerrarPersonal.Enabled = false;
                            btnCerrar.Enabled = true;
                            btnGenerarArchivos.Enabled = true;
                            break;
                        case "C":
                            btnCerrarPersonal.Enabled = false;
                            btnCerrar.Enabled = false;
                            btnGenerarArchivos.Enabled = true;
                            break;

                        default:
                            btnEliminar.Enabled = true;
                            btnAbrir.Enabled = true;
                            btnCerrarPersonal.Enabled = false;
                            btnCerrar.Enabled = false;
                            btnGenerarArchivos.Enabled = true;
                            break;
                    }
                    this.txtLiqId.Focus();
                }

                if (e.CommandName == "ActivarInactivar")
                {
                    ocnMenu.ActivarInactivar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void HabilitarBotonesLiquidacion()
    {
        btnEliminar.Enabled = true;
        btnAbrir.Enabled = true;
        btnModificar.Enabled = true;
        btnGenerarOrdenPago.Enabled = true;
    }

    protected void DeshabilitarBotonesLiquidacion()
    {
        btnEliminar.Enabled = false;
        btnAbrir.Enabled = false;
        btnCerrarPersonal.Enabled = false;
        btnCerrar.Enabled = false;
        btnModificar.Enabled = false;
        btnGenerarArchivos.Enabled = false;
        btnGenerarOrdenPago.Enabled = false;
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

    protected void btnEliminarAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            //ocnPerfil.Eliminar(Id);

            ((Button)sender).Parent.Controls[1].Visible = true;
            ((Button)sender).Parent.Controls[3].Visible = false;
            ((Button)sender).Parent.Controls[5].Visible = false;

            GrillaCargar(Grilla.PageIndex);
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
        try
        {
            if (txtLiqId.Text != "")
            {

            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    Debe seleccionar una liquidacion<br>" + "</div>";
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
        ocnMenu = new LiquidacionSueldos.Negocio.Menu();
        dt2 = ocnMenu.LiquidacionObtenerPorAnio(Convert.ToInt32(MenuRaizListaAnioDesde.SelectedValue));

        //MENU MES DESDE
        MenuRaizListaMesDesde.DataSource = dt2;
        MenuRaizListaMesDesde.DataTextField = "MesLiq";
        MenuRaizListaMesDesde.DataValueField = "Periodo de Liquidacion";
        MenuRaizListaMesDesde.DataBind();

        GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaMesDesde.SelectedValue;
        GlobalesAgenteConsulta.IndiceDropDownList1 = MenuRaizListaAnioDesde.SelectedIndex;
        GlobalesAgenteConsulta.IndiceMenuListaMesDesde = MenuRaizListaMesDesde.SelectedIndex;
    }

    protected void btnGenerarArchivos_Click(object sender, EventArgs e)
    {
        LiquidacionSueldos.Negocio.ArchivoExtDocEducacion archivosEducacion = new LiquidacionSueldos.Negocio.ArchivoExtDocEducacion();
        int liqID = Convert.ToInt32(txtLiqId.Text);
        archivosEducacion.Generar(liqID);
        lblMensajeError.Text = FuncionesUtiles.MensajeExito("Archivos generados con Exito");
    }

    protected void generarArchivosNoPresentismo(int paramLiqId, int paramReparticion)
    {
        DataTable dt = new DataTable();
        string nombreArchivo, path, pathConNombreArchivo;

        int reparticion = paramReparticion;
        if (reparticion == 5)
            reparticion = 2;

        int liqId = paramLiqId;

        #region Archivo Testigo No Presentismo
        // Inicio - Genercion de Archivos No Presentismo

        dt = oNovedadInasistencia.GenerarListadoTestigoNoPresentismo(liqId, reparticion);
        nombreArchivo = "RLSTNOPE.txt";
        string Ruta = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo"));

        path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo"), liqId.ToString(), reparticion.ToString());
        pathConNombreArchivo = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo"), liqId.ToString(), reparticion.ToString(), nombreArchivo);


        // Si no existe el directorio, lo creo
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        // Si existe el archivo, lo elimino
        if (System.IO.File.Exists(pathConNombreArchivo))
        {
            File.SetAttributes(pathConNombreArchivo, FileAttributes.Normal);
            File.Delete(pathConNombreArchivo);
        }

        // Defino donde guardar el archivo que estoy generando
        using (StreamWriter file = new StreamWriter(pathConNombreArchivo, true))
        {
            // Inicio - Encabezado                
            string paramFecha = DateTime.Now.ToString("dd/MM/yyyy");
            string titulo = "LISTADO TESTIGO PERSONAL SIN PRESENTISMO";
            string linea = paramFecha.PadRight(15) + titulo + "P g.".PadLeft(10);
            file.WriteLine(linea);

            string lineaVacia = Environment.NewLine;
            file.WriteLine(lineaVacia);
            // Fin - Encabezado

            // Inicio - Titulo columnas
            linea = "".PadRight(10) + "Nro Control".PadLeft(10) + "Planta".PadLeft(10) + "Mes".PadLeft(11) + "Anio".PadLeft(12);
            file.WriteLine(linea);
            // Fin - Titulo columnas

            int totalPlantaContratada = 0;
            int totalPlantaPermanente = 0;

            foreach (DataRow row in dt.Rows)
            {
                List<string> items = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    items.Add(row[col].ToString());
                }
                linea = linea = "".PadRight(10) + string.Join("".PadLeft(10), items.ToArray());
                file.WriteLine(linea);

                if (row["planta"].ToString() == "C")
                    totalPlantaContratada++;
                else
                    totalPlantaPermanente++;
            }

            file.WriteLine(lineaVacia);
            file.WriteLine(lineaVacia);
            file.WriteLine(lineaVacia);

            // Totales
            string tituloTotalRegistros = "TOTAL DE REGISTROS:";
            file.WriteLine("".PadRight(9) + tituloTotalRegistros + (totalPlantaContratada + totalPlantaPermanente).ToString().PadLeft(10));
            file.WriteLine(lineaVacia);
            string tituloPlantaContratada = "Planta Contratada:";
            file.WriteLine("".PadRight(10) + tituloPlantaContratada + totalPlantaContratada.ToString().PadLeft(10));
            file.WriteLine(lineaVacia);
            string tituloPlantaPermanente = "Planta Permanente:";
            file.WriteLine("".PadRight(10) + tituloPlantaPermanente + totalPlantaPermanente.ToString().PadLeft(10));
            file.WriteLine(lineaVacia);
        }
        // FIN - GENERACION DE ARCHIVOS NO PRESENTISMO
        #endregion

        #region ARCHIVO NO PRESENTISMO
        // Inicio - Genercion de Archivos No Presentismo

        dt = oNovedadInasistencia.GenerarArchivoNoPresentismo(liqId, reparticion);
        nombreArchivo = "NOPRESEN.txt";
        pathConNombreArchivo = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Novedades/ArchivosNoPresentismo"), liqId.ToString(), reparticion.ToString(), nombreArchivo);

        // Si existe el archivo, lo elimino
        if (System.IO.File.Exists(pathConNombreArchivo))
        {
            File.SetAttributes(pathConNombreArchivo, FileAttributes.Normal);
            File.Delete(pathConNombreArchivo);
        }

        // Escribo el txt linea por linea
        using (StreamWriter file = new StreamWriter(pathConNombreArchivo, true))
        {
            foreach (DataRow row in dt.Rows)
            {
                file.WriteLine(row["columna"].ToString());
            }
        }
        #endregion
    }

    protected void btnGenerarOrdenPago_Click(object sender, EventArgs e)
    {                
        try
        {
            String NomRep = "OrdenPagoExtensionHoraria.rpt";
            NomRep = "OrdenPago.rpt";
            
            int liqID = Convert.ToInt32(txtLiqId.Text);                        
            FuncionesUtiles.AbreVentana("../Pagos_Eventuales/Reporte.aspx?liq_id=" + liqID+ "&NomRep=" + NomRep);
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

    protected void btnGenerarOrdenPagoPatronal_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep = "OrdenPagoExtensionHorariaPatronal.rpt";
            //NomRep = "OrdenPago.rpt";

            int liqID = Convert.ToInt32(txtLiqId.Text);
            FuncionesUtiles.AbreVentana("../Pagos_Eventuales/Reporte.aspx?liq_id=" + liqID + "&NomRep=" + NomRep);
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

    protected void btnGenerarOrdenPagoEmpleado_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep = "OrdenPagoExtensionHorariaEmpleado.rpt";
            //NomRep = "OrdenPago.rpt";

            int liqID = Convert.ToInt32(txtLiqId.Text);
            FuncionesUtiles.AbreVentana("../Pagos_Eventuales/Reporte.aspx?liq_id=" + liqID + "&NomRep=" + NomRep);
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