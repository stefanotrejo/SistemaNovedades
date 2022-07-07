using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class UsuarioCambiarClave : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Usuario ocnUsuario = new LiquidacionSueldos.Negocio.Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                this.Master.TituloDelFormulario = " Usuario - Cambiar Clave";

                if (this.Master.CambiarClave)
                {
                    /*SIGNIFICA QUE LA CLAVE ACTUAL ES 1*/
                    this.ClaveActual.Visible = false;
                    this.ClaveNueva.Focus();
                }
                else
                {
                    this.ClaveActual.Visible = true;
                    this.ClaveActual.Focus();
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
            ocnUsuario = new LiquidacionSueldos.Negocio.Usuario(this.Master.usuId);
            string sClaveActual = LiquidacionSueldos.Datos.Utiles.GetHash(ClaveActual.Text.Trim());

            /*Validaciones*/
            string MensajeValidacion = "";

            if (ClaveActual.Visible)
            {
                if (sClaveActual != ocnUsuario.usuClave)
                {
                    MensajeValidacion += "<br>* Clave Actual. Incorrecta !!!";
                    ClaveActual.Focus();
                }
            }

            if (MensajeValidacion.Trim().Length == 0)
            {
                string sClaveNueva = LiquidacionSueldos.Negocio.Seguridad.EncriptarClave(RepitaClave.Text.Trim());
                ocnUsuario.CambiarClave(this.Master.usuId, sClaveNueva);
                Session["CambioClave"] = "1";
                /*CERRAR SESION DE OTROS EQUIPOS*/
                LiquidacionSueldos.Negocio.UsuarioConectado ocnUsuarioConectado = new LiquidacionSueldos.Negocio.UsuarioConectado();
                ocnUsuarioConectado.DesconectarOtros(this.Master.usuId, Session["_Guid"].ToString(), FuncionesUtiles.ObtenerIpPublica());

                Response.Redirect("CerrarSesion.aspx", false);
                //Response.Redirect("http://localhost:52989/PaginasBasicas/Login.aspx", true); 
            }
            else
            {
                lblMensajeError.Text = @"<div class=""alert alert-danger alert-dismissable"">
<button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
<a class=""alert-link"" href=""#"">Error</a><br/>" + MensajeValidacion + "</div>";
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