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

        // Perhaps extend this to have Read-Modify-Write static methods
        // for data integrity during concurrency? Situational.
    }
    #endregion
    #region Metodos
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Conceptos - Consulta";
                if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);
                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["AgenteConceptos.PageIndex"] == null)
                {
                    Session.Add("AgenteConceptos.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["AgenteConceptos.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //if (Session["ParametroConsulta.Nombre"] != null) { Parametro.Text = Session["ParametroConsulta.Nombre"].ToString(); } else { Session.Add("ParametroConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion
                if ((Request.QueryString["Id"] != null) && (Request.QueryString["Id"] != ""))
                {
                    GrillaCargar(PageIndex, Convert.ToInt32(Request.QueryString["Id"]));
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
//    protected void btnListar_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            if (Grilla.Rows.Count != 0)
//            {

//                String NomRep = "InformeAgentesGenerico.rpt";
//                //DateTime periodoDesde = Convert.ToDateTime(MenuRaizListaAnioDesde.SelectedValue);
//                //DateTime periodoHasta = Convert.ToDateTime(MenuRaizListaAnioHasta.SelectedValue);
//                String nombre = "";
//                String nrocontrol = "";
//                String dni = "";

//                ////    FUNCIONA A VECES
//                ////    Session["Periodo1"] = Convert.ToDateTime(MenuRaizLista.SelectedValue);
//                ////    Session["Periodo2"] = Convert.ToDateTime(MenuRaizLista2.SelectedValue);
//                int tipo = 0;
//                if (periodoDesde <= periodoHasta)
//                {
//                    if (txtAgeNroControl.Text != "") // VERIFICA QUE EL USUARIO HAYA INGRESADO ALGUN TEXTO
//                    {
//                        GlobalesAgenteConsulta.tipoOp = tipo;
//                        GlobalesAgenteConsulta.indexOp = Grilla.PageIndex.ToString();
//                        //Variables de Fechas seleccionadas
//                        //GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaAnioDesde.SelectedValue;
//                        //GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaAnioHasta.SelectedValue;
//                        GlobalesAgenteConsulta.FechaAux1 = MenuRaizListaMesDesde.SelectedValue;
//                        GlobalesAgenteConsulta.FechaAux2 = MenuRaizListaMesHasta.SelectedValue;
//                        //Variables de Indices seleccionados
//                        GlobalesAgenteConsulta.IndiceDropDownList1 = MenuRaizListaAnioDesde.SelectedIndex;
//                        GlobalesAgenteConsulta.IndiceDropDownList2 = MenuRaizListaAnioHasta.SelectedIndex;
//                        GlobalesAgenteConsulta.IndiceMenuListaMesDesde = MenuRaizListaMesDesde.SelectedIndex;
//                        GlobalesAgenteConsulta.IndiceMenuListaMesHasta = MenuRaizListaMesHasta.SelectedIndex;
//                        //Session["Periodo1"] = fecha1;
//                        //Session["Periodo2"] = fecha2;
//                        //Session["Periodo1"] = MenuRaizLista.SelectedValue;
//                        //Session["Periodo2"] = MenuRaizLista2.SelectedValue;

//                        LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
//                        if (RadioNumeroControl.Checked == true) //BUSCAR POR NUMERO DE CONTROL
//                        {
//                            if (txtAgeNroControl.Text.Length == 8)
//                            {
//                                nrocontrol = txtAgeNroControl.Text;
//                                FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
//                                    + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
//                                    + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);
//                                //tipo = 3;
//                                //GlobalesAgenteConsulta.tipoOp = tipo.ToString();
//                                //GrillaCargar(Grilla.PageIndex, tipo);
//                            }
//                            else
//                            {
//                                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
//                            <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
//                            <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
//                            El Numero de Control debe contener 8 digitos<br>" + "</div>";
//                            }
//                        }
//                        else // // BUSCAR POR CUIL
//                        {
//                            if (RadioDni.Checked == true)
//                            {
//                                if (txtAgeNroControl.Text.Length >= 7)
//                                {
//                                    dni = txtAgeNroControl.Text;
//                                    FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
//                                        + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
//                                        + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);
//                                    //tipo = 1;
//                                    //GlobalesAgenteConsulta.tipoOp = tipo.ToString();
//                                    //GrillaCargar(Grilla.PageIndex, tipo);
//                                }
//                                else
//                                {
//                                    lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
//                                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
//                                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
//                                El DNI debe contener 8 digitos<br>" + "</div>";
//                                }
//                            }
//                            else
//                            {
//                                nombre = txtAgeNroControl.Text;
//                                FuncionesUtiles.AbreVentana("Reporte.aspx?nombre=" + nombre
//                                    + "&periodoDesde=" + periodoDesde + "&periodoHasta=" + periodoHasta
//                                    + "&nrocontrol=" + nrocontrol + "&dni=" + dni + "&NomRep=" + NomRep);
//                                //tipo = 2;
//                                //GlobalesAgenteConsulta.tipoOp = tipo.ToString();
//                                //  GrillaCargar(Grilla.PageIndex, tipo);
//                            }
//                        }
//                        //IMPRIMIR LISTADO

//                        //    pasar tipo, txtbox, periodos,

//                        //    Int32 carid = Int32.Parse(carId.SelectedValue.ToString());
//                        //    Int32 plaid = Int32.Parse(plaId.SelectedValue.ToString());
//                        //    Int32 curid = Int32.Parse(curId.SelectedValue.ToString());
//                        //    Int32 camid = Int32.Parse(camId.SelectedValue.ToString());
//                        //    Int32 escid = Int32.Parse(escId.SelectedValue.ToString());
//                        //    Int32 aniocursado = 0;
//                        //    if (icuAnoCursado.Text.Trim().ToString() != "")
//                        //    {
//                        //        aniocursado = Convert.ToInt32(icuAnoCursado.Text.Trim().ToString());
//                        //    }

//                        //    NomRep = "InformeInscriptosCursadoPlanilla.rpt";

//                        //    FuncionesUtiles.AbreVentana("Reporte.aspx?carId=" + carid + "&plaId=" + plaid + "&curId=" + curid + "&camId=" + camid + "&escId=" + escid + "&anio=" + aniocursado + "&NomRep=" + NomRep);

//                    }
//                }
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
    private void GrillaCargar(int PageIndex, int ageId)
    {
        try
        {
            Session["ParametroConsulta.PageIndex"] = PageIndex;
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            dt = new DataTable();
            dt = ocnAgente.ObtenerConceptosPorAgente(ageId);
            this.Grilla.DataSource = dt;
            this.Grilla.PageIndex = PageIndex;
            this.Grilla.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblCantidadRegistros.Text = "Cantidad de registros: " + dt.Rows.Count.ToString();
            }
            else
            {
                lblCantidadRegistros.Text = "Cantidad de registros: 0";
            }

            //Nombre.Focus();
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
            //int tipo = 0;
            //if (RadioDni.Checked == true)
            //{
            //    tipo = 1;
            //}
            //else
            //{
            //    if (RadioApellidoyNombre.Checked == true)
            //    {
            //        tipo = 2;
            //    }
            //    else
            //    {
            //        tipo = 3;
            //    }
            //}
            if (Session["AgenteConsulta.PageIndex"] != null)
            {
                Session["AgenteConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("AgenteConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex, Convert.ToInt32(Request.QueryString["Id"]));
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
    //    private Boolean VerificarFechas (DateTime fecha1, DateTime fecha2)
    //    {
    //        try
    //        {
    //            lblMensajeError.Text = "";
    //            DateTime fecha1 = Convert.ToDateTime(MenuRaizLista.SelectedValue);
    //            DateTime fecha2 = Convert.ToDateTime(MenuRaizLista2.SelectedValue);
    //            //FUNCIONA A VECES
    //            Session["Periodo1"] = Convert.ToDateTime(MenuRaizLista.SelectedValue);
    //            Session["Periodo2"] = Convert.ToDateTime(MenuRaizLista2.SelectedValue);

    //            int tipo = 0;
    //            if (fecha1 <= fecha2)
    //            {
    //                if (txtAgeNroControl.Text != "") // VERIFICA QUE EL USUARIO HAYA INGRESADO ALGUN TEXTO
    //                {
    //                    Grilla.PageIndex = 0;
    //                    GlobalesAgenteConsulta.tipoOp = tipo.ToString();
    //                    GlobalesAgenteConsulta.indexOp = Grilla.PageIndex.ToString();
    //                    GlobalesAgenteConsulta.FechaAux1 = MenuRaizLista.SelectedValue;
    //                    GlobalesAgenteConsulta.FechaAux2 = MenuRaizLista2.SelectedValue;
    //                    //Session["Periodo1"] = fecha1;
    //                    //Session["Periodo2"] = fecha2;
    //                    GlobalesAgenteConsulta.DropDownList1 = MenuRaizLista.SelectedIndex;
    //                    GlobalesAgenteConsulta.DropDownList2 = MenuRaizLista2.SelectedIndex;
    //                    //Session["Periodo1"] = MenuRaizLista.SelectedValue;
    //                    //Session["Periodo2"] = MenuRaizLista2.SelectedValue;

    //                    LiquidacionSueldos.Negocio.NuevoAge1 ocnAgente2 = new LiquidacionSueldos.Negocio.NuevoAge1();
    //                    if (RadioNumeroControl.Checked == true) //BUSCAR POR NUMERO DE CONTROL
    //                    {
    //                        if (txtAgeNroControl.Text.Length == 8)
    //                        {
    //                            tipo = 3;
    //                            GlobalesAgenteConsulta.tipoOp = tipo.ToString();
    //                            GrillaCargar(Grilla.PageIndex, tipo);
    //                        }
    //                        else
    //                        {
    //                            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //    El Numero de Control debe contener 8 digitos<br>" + "</div>";
    //                        }
    //                    }
    //                    else // // BUSCAR POR CUIL
    //                    {
    //                        if (RadioDni.Checked == true)
    //                        {
    //                            if (txtAgeNroControl.Text.Length >= 7)
    //                            {
    //                                tipo = 1;
    //                                GlobalesAgenteConsulta.tipoOp = tipo.ToString();
    //                                GrillaCargar(Grilla.PageIndex, tipo);
    //                            }
    //                            else
    //                            {
    //                                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //                                <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //                                <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //                                El DNI debe contener 8 digitos<br>" + "</div>";
    //                            }
    //                        }
    //                        else
    //                        {
    //                            tipo = 2;
    //                            GlobalesAgenteConsulta.tipoOp = tipo.ToString();
    //                            GrillaCargar(Grilla.PageIndex, tipo);
    //                        }
    //                    }
    //                }
    //            } //Validar Fechas
    //            else //Validar Fechas
    //            {
    //                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //    <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //    <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //    La Fecha 'Hasta' no puede ser menor a la Fecha 'Desde'<br>" + "</div>";
    //                return false;
    //            }


    //        }//TRY Principal
    //        catch (Exception oError)
    //        {
    //            lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
    //<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
    //<a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
    //Se ha producido el siguiente error:<br/>
    //MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite +
    //"</div>";
    //        }
    //    }
    #endregion       
    protected void btnAceptar1_Click(object sender, EventArgs e)
    {
        try
        {
            //Session["Resultado"] = 0;

            ////PRUEBA
            //Session["Periodo1"] = Globales.periodoDesde;
            //Session["Periodo2"] = Globales.periodoHasta;

            ////PRUEBA 2
            //Session["Tipo"] = Globales.tipoOp;
            //Session["index"] = Globales.index;
            //Session["Textbox"] = Globales.textBox;


            //Response.Redirect("AgenteDetalle.aspx", true);
            Response.Redirect("AgenteDetalle.aspx?Id=" + Session["CadenaAgenteDetalle"], true);

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