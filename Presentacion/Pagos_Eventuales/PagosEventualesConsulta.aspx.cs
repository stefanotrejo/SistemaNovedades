using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class ParametroConsultaCustom : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
    LiquidacionSueldos.Negocio.Agente ocnAgente = new LiquidacionSueldos.Negocio.Agente();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = "Pagos Eventuales - Consulta";

                //if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

                #region PageIndex
                int PageIndex = 0;
                if (this.Session["ParametroConsulta.PageIndex"] == null)
                {
                    Session.Add("ParametroConsulta.PageIndex", 0);
                }
                else
                {
                    PageIndex = Convert.ToInt32(Session["ParametroConsulta.PageIndex"]);
                }
                #endregion

                #region Variables de sesion para filtros
                //if (Session["ParametroConsulta.Nombre"] != null) { Parametro.Text = Session["ParametroConsulta.Nombre"].ToString(); } else { Session.Add("ParametroConsulta.Nombre", Nombre.Text.Trim()); }
                #endregion

                ocnMenu = new LiquidacionSueldos.Negocio.Menu();
                dt = ocnMenu.ObtenerListaFechas();
                MenuRaizLista.DataSource = dt;
                MenuRaizLista.DataTextField = "FechaCarga";
                MenuRaizLista.DataBind();
                // GrillaCargar(PageIndex);
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PagosEventualesNuevo.aspx", false);
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

    protected void CrearArchivo(DataTable dt)
    {
        try
        {
            String fecha = DateTime.Today.ToString("dd/MM/yyyy").Replace('/', '-');
            //string Ruta = "C:/Users/stefano/Desktop/ArchivoCreado";
            string Ruta = "C:/Users/stefano/Desktop/PagoEventual";
            if (System.IO.File.Exists(Ruta + fecha + ".txt"))
            {
                File.SetAttributes(Ruta + fecha + ".txt", FileAttributes.Normal);
                File.Delete(Ruta + fecha + ".txt");
            }
            using (StreamWriter file = new StreamWriter(Ruta += fecha + ".txt", true))
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

    protected void btnExportarTxt_Click(object sender, EventArgs e)
    {
        try
        {
            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            // int menId = 0;
            DateTime fechaseleccionada = Convert.ToDateTime(MenuRaizLista.SelectedValue);

            //  menId = Convert.ToInt32(MenuRaizLista.SelectedValue);
            dt = new DataTable();
            //     dt = ocnParametro.ObtenerTodoBuscarxNombre(Nombre.Text.Trim());
            dt = ocnAgente.ObtenerRegistrosDeAgentes(fechaseleccionada);
            CrearArchivo(dt); //Genera TXT            
            ocnAgente.pevFechaCarga = fechaseleccionada;
            ocnAgente.Actualizar(); /*AQUI PONEMOS EN 1 LOS YA GENERADOS*/
            Response.Redirect("PagosEventualesConsulta.aspx", true);
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

    protected void btnInformeContaduria_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep = "InformeContaduria.rpt";
            DateTime fechaseleccionada = Convert.ToDateTime(MenuRaizLista.SelectedValue);
            DateTime periodoDesde = fechaseleccionada;
            String nombre = "";
            String nrocontrol = "";
            String dni = "";
            FuncionesUtiles.AbreVentana("Reporte.aspx?fechaseleccionada=" + fechaseleccionada + "&NomRep=" + NomRep);
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

    protected void btnInformeTesoreria_Click(object sender, EventArgs e)
    {
        try
        {
            String NomRep = "InformeTesoreria.rpt";
            DateTime fechaseleccionada = Convert.ToDateTime(MenuRaizLista.SelectedValue);
            DateTime periodoDesde = fechaseleccionada;
            //DateTime periodoHasta = Globales.periodoHasta;
            String nombre = "";
            String nrocontrol = "";
            String dni = "";
            FuncionesUtiles.AbreVentana("Reporte.aspx?fechaseleccionada=" + fechaseleccionada + "&NomRep=" + NomRep);
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

    private void GrillaCargar(int PageIndex) //CARGA LA GRILLA 
    {
        try
        {
            Session["ParametroConsulta.PageIndex"] = PageIndex;

            #region Variables de sesion para filtros
            //[VariablesDeSesionParaFiltros1]
            #endregion
            // int menId = 0;
            DateTime fechaseleccionada = Convert.ToDateTime(MenuRaizLista.SelectedValue);

            //  menId = Convert.ToInt32(MenuRaizLista.SelectedValue);
            dt = new DataTable();
            //     dt = ocnParametro.ObtenerTodoBuscarxNombre(Nombre.Text.Trim());
            dt = ocnAgente.ObtenerAgentesxFechaDeCarga(fechaseleccionada);

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

            // Nombre.Focus();
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

    private void CargarTodos() //CARGA LA GRILLA 
    {
        try
        {
            ocnMenu = new LiquidacionSueldos.Negocio.Menu();
            dt = ocnMenu.ObtenerListaTodasLasFechas();
            MenuRaizLista.DataSource = dt;
            MenuRaizLista.DataTextField = "FechaCarga";
            MenuRaizLista.DataBind();
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

                if (e.CommandName == "Eliminar")
                {
                    //ocnParametro.Eliminar(Convert.ToInt32(Id));
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Copiar")
                {
                    ocnParametro = new LiquidacionSueldos.Negocio.Parametro(Convert.ToInt32(Id));
                    //ocnParametro.Copiar();
                    this.GrillaCargar(this.Grilla.PageIndex);
                }

                if (e.CommandName == "Ver")
                {
                    Response.Redirect("ParametroRegistracion.aspx?Id=" + Id + "&Ver=1", false);
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
            if (Session["ParametroConsulta.PageIndex"] != null)
            {
                Session["ParametroConsulta.PageIndex"] = e.NewPageIndex;
            }
            else
            {
                Session.Add("ParametroConsulta.PageIndex", e.NewPageIndex);
            }

            this.GrillaCargar(e.NewPageIndex);
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

    protected void btnEliminarAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = 0;
            Id = Convert.ToInt32(((HyperLink)((GridViewRow)((Button)sender).Parent.Parent).Cells[0].Controls[1]).Text);

            ocnParametro.Eliminar(Id);

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
        ((Button)sender).Parent.Controls[1].Visible = true;
        ((Button)sender).Parent.Controls[3].Visible = false;
        ((Button)sender).Parent.Controls[5].Visible = false;
    }

    protected void Nombre_TextChanged(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex);
    }

    protected void btnAplicar_Click(object sender, EventArgs e)
    {
        GrillaCargar(Grilla.PageIndex); //CARGA GRILLA CON DATO SELECCIONADO DEL COMBO
    }

    protected void MenuRaizLista_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GrillaCargar(Grilla.PageIndex);
            //        //    int menId = 0;
            //        //    menId = Convert.ToInt32(MenuRaizLista.SelectedValue);
            //        //    ocnMenu = new LiquidacionSueldos.Negocio.Menu(menId);
            //        //    ObtenerListaFechas()
            //        //    txtTituloMenuRaiz.Text = ocnMenu.menNombre;
            //        //    txtOrdenMenuRaiz.Text = ocnMenu.menOrden.ToString();
            //        //    txtTituloMenuRaiz.Focus();

            //        //    GrillaCargar(Grilla.PageIndex);

            //        //    txtTituloMenuSecundario.Text = "";
            //        //    txtURLMenuSecundario.Text = "";
            //        //    lblmenIdSecundario.Text = "";
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnTraerTodos_Click(object sender, EventArgs e)
    {
        try
        {
            CargarTodos();


        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }
}