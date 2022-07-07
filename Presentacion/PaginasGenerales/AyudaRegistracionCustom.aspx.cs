using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class AyudaRegistracionCustom : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Ayuda ocnAyuda = new LiquidacionSueldos.Negocio.Ayuda();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Ayuda - Registracion (Recuerde refrescar la pagina origen para mostrar ayuda en la ventana modal)";

				//if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

					/*INCIALIZADORES*/

					if (Id != 0)
                    {
						ocnAyuda = new LiquidacionSueldos.Negocio.Ayuda(Id);
						this.ayuPaginaNombre.Text = ocnAyuda.ayuPaginaNombre;
						this.ayuDescripcion.Text = ocnAyuda.ayuDescripcion;

                        /*Editar Habilitado*/
					}
                    else
                    {
                        /*Nuevo Habilitado*/
                        /*cLoadNuevoCustom*/
                    }

                    this.ayuDescripcion.Focus();
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
		
	protected void btnAceptar_Click(object sender, EventArgs e)
	{
        try
        {
		    int Id = 0;
		    if (Request.QueryString["Id"] != null)
		    {
			    Id = Convert.ToInt32(Request.QueryString["Id"]);
			    ocnAyuda = new LiquidacionSueldos.Negocio.Ayuda(Id);

			    ocnAyuda.ayuPaginaNombre = ayuPaginaNombre.Text; 
			    ocnAyuda.ayuDescripcion = ayuDescripcion.Text;
                ocnAyuda.ayuActivo = true;

                /*....usuId = this.Master.usuId;*/                

				ocnAyuda.ayuFechaHoraCreacion = DateTime.Now;
				ocnAyuda.ayuFechaHoraUltimaModificacion = DateTime.Now;
				ocnAyuda.usuIdCreacion = this.Master.usuId;
				ocnAyuda.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if(ayuDescripcion.Text.Trim().Length == 0)
                {
                    MensajeValidacion += @"<br>* Descripcion. Requerido";
                    ayuDescripcion.Focus();
                }

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
				    }
				    else
				    {
					    //Editar
				        ocnAyuda.ayuFechaHoraUltimaModificacion = DateTime.Now;
				        ocnAyuda.usuIdUltimaModificacion = this.Master.usuId;
					    ocnAyuda.Actualizar();
				    }

                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                }
			    else
			    {
				    Response.Write("MENSAJE DE ERROR:<br>" + MensajeValidacion);

                    lblMensajeError.Text = @"<div class=""alert alert-warning alert-dismissable"">
        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
        <a class=""alert-link"" href=""#"">Error de Sistema</a><br/>
        Se ha producido el siguiente error:<br/>" + MensajeValidacion + "</div>";
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