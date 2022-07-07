using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioRegistracionCustom : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Usuario ocnUsuario = new LiquidacionSueldos.Negocio.Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario - Registracion";



                if (Request.QueryString["Ver"] != null)
                {
                    btnAceptar.Visible = false;
                }

                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);

                    /*INCIALIZADORES*/
                    perId.DataValueField = "Valor"; perId.DataTextField = "Texto"; perId.DataSource = (new LiquidacionSueldos.Negocio.Perfil()).ObtenerLista("[Seleccionar...]"); perId.DataBind();

                    if (Id != 0)
                    {
                        ocnUsuario = new LiquidacionSueldos.Negocio.Usuario(Id);
                        this.usuApellido.Text = ocnUsuario.usuApellido;
                        this.usuNombre.Text = ocnUsuario.usuNombre;
                        this.usuNombreIngreso.Text = ocnUsuario.usuNombreIngreso;
                        this.usuEmail.Text = ocnUsuario.usuEmail;
                        this.usuActivo.Checked = ocnUsuario.usuActivo;
                        this.perId.SelectedValue = (ocnUsuario.perId == 0 ? "" : ocnUsuario.perId.ToString());

                        /*Editar Habilitado*/
                    }
                    else
                    {


                        /*Nuevo Habilitado*/

                        /*cLoadNuevoCustom*/
                    }

                    this.usuApellido.Focus();
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
            Response.Redirect("UsuarioConsultaCustom.aspx", true);
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
                ocnUsuario = new LiquidacionSueldos.Negocio.Usuario(Id);

                ocnUsuario.usuApellido = usuApellido.Text;
                ocnUsuario.usuNombre = usuNombre.Text;
                ocnUsuario.usuNombreIngreso = usuNombreIngreso.Text;
                ocnUsuario.usuClaveProvisoria = "";
                ocnUsuario.usuCambiarClave = false;
                ocnUsuario.usuEmail = usuEmail.Text;
                ocnUsuario.usuActivo = usuActivo.Checked;

                ocnUsuario.perId = Convert.ToInt32((perId.SelectedValue.Trim() == "" ? "0" : perId.SelectedValue));
                /*....usuId = this.Master.usuId;*/


                ocnUsuario.usuFechaHoraCreacion = DateTime.Now;
                ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                ocnUsuario.usuIdCreacion = this.Master.usuId;
                ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;

                /*Validaciones*/
                string MensajeValidacion = "";

                if (usuEmail.Text.Trim().Length == 0)
                {
                    MensajeValidacion += "<br>* Email. Requerido";
                    usuEmail.Focus();
                }

                if (MensajeValidacion.Trim().Length == 0)
                {
                    if (Id == 0)
                    {
                        //Nuevo Usuario
                        ocnUsuario.usuClave = "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==";
                        ocnUsuario.Insertar();
                    }
                    else
                    {
                        //Editar Usuario
                        ocnUsuario.usuFechaHoraUltimaModificacion = DateTime.Now;
                        ocnUsuario.usuIdUltimaModificacion = this.Master.usuId;
                        ocnUsuario.Actualizar();
                    }

                    Response.Redirect("UsuarioConsultaCustom.aspx", true);
                }
                else
                {
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