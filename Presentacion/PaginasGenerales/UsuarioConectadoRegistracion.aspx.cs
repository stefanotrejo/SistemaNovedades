using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioConectadoRegistracion : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.UsuarioConectado ocnUsuarioConectado = new LiquidacionSueldos.Negocio.UsuarioConectado();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario Conectado - Registracion";

				//if (this.Session["_Autenticado"] == null) Response.Redirect("~/PaginasBasicas/Login.aspx", true);

                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false; 
                    btnAceptar1.Visible = false;
                }
            
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

					/*INCIALIZADORES*/
					usuId.DataValueField = "Valor"; usuId.DataTextField = "Texto"; usuId.DataSource = (new LiquidacionSueldos.Negocio.Usuario()).ObtenerListaCustom("[Seleccionar...]"); usuId.DataBind();

					if (Id != 0)
                    {
						ocnUsuarioConectado = new LiquidacionSueldos.Negocio.UsuarioConectado(Id);
						this.ucoFechaHoraUltimaConexion.Text = ocnUsuarioConectado.ucoFechaHoraUltimaConexion;
						this.ucoGuid.Text = ocnUsuarioConectado.ucoGuid;
						this.ucoIpPublica.Text = ocnUsuarioConectado.ucoIpPublica;
						this.ucoDesconectar.Checked = ocnUsuarioConectado.ucoDesconectar;
						this.ucoActivo.Checked = ocnUsuarioConectado.ucoActivo;
						this.usuId.SelectedValue = (ocnUsuarioConectado.usuId == 0 ? "" : ocnUsuarioConectado.usuId.ToString());

                        /*Editar Habilitado*/
					}
                    else
                    {
                        ucoFechaHoraUltimaConexion.Text = DateTime.Now;


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.usuId.Focus();
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
		
	protected void btnCancelar_Click(object sender, EventArgs e)
	{
        try
        {
            Response.Redirect("UsuarioConectadoConsulta.aspx", true);
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
			    ocnUsuarioConectado = new LiquidacionSueldos.Negocio.UsuarioConectado(Id);

			    ocnUsuarioConectado.ucoFechaHoraUltimaConexion = Convert.ToDateTime(ucoFechaHoraUltimaConexion.Text); 
			    ocnUsuarioConectado.ucoGuid = ucoGuid.Text; 
			    ocnUsuarioConectado.ucoIpPublica = ucoIpPublica.Text; 
			    ocnUsuarioConectado.ucoDesconectar = ucoDesconectar.Checked; 
			    ocnUsuarioConectado.ucoActivo = ucoActivo.Checked; 

				ocnUsuarioConectado.usuId = Convert.ToInt32((usuId.SelectedValue.Trim() == "" ? "0" : usuId.SelectedValue)); 
                /*....usuId = this.Master.usuId;*/
                

				ocnUsuarioConectado.ucoFechaHoraCreacion = DateTime.Now;
				ocnUsuarioConectado.ucoFechaHoraUltimaModificacion = DateTime.Now;
				ocnUsuarioConectado.usuIdCreacion = this.Master.usuId;
				ocnUsuarioConectado.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
			    string MensajeValidacion = "";

                if (MensajeValidacion.Trim().Length == 0)
			    {
				    if (Id == 0)
				    {
					    //Nuevo
					    ocnUsuarioConectado.Insertar();
				    }
				    else
				    {
					    //Editar
				        ocnUsuarioConectado.ucoFechaHoraUltimaModificacion = DateTime.Now;
				        ocnUsuarioConectado.usuIdUltimaModificacion = this.Master.usuId;
					    ocnUsuarioConectado.Actualizar();
				    }
					
				    Response.Redirect("UsuarioConectadoConsulta.aspx", true);
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