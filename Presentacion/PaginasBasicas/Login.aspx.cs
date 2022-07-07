using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PaginasBasicas_Login : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.Usuario ocnUsuario = new LiquidacionSueldos.Negocio.Usuario();

    DataTable dtUsuario = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Title = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
            lblClienteNombre.Text = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
            if (Session["CambioClave"].ToString() != "")
            {
                //mensaje que se cambio la clave con exito
                lblMensajeError.Text = @"<div class=""alert alert-success alert-dismissable"">
                        <button aria-hidden=""true"" data-dismiss=""alert"" class=""close"" type=""button"">x</button>
                        <a class=""alert-link"" href=""#"">Confirmacion</a><br/>
                        La contraseña se guardó correctamente<br>" + "</div>";
                Session["CambioClave"] = "";
            }
           
            if (!Page.IsPostBack)
                {
                    if (Session["_Autenticado"] != null) Session.Remove("_Autenticado");
                    if (Session["_usuNombreIngreso"] != null) Session.Remove("_usuNombreIngreso");
                    if (Session["_usuApellido"] != null) Session.Remove("_usuApellido");
                    if (Session["_usuNombre"] != null) Session.Remove("_usuNombre");
                    if (Session["_usuId"] != null) Session.Remove("_usuId");
                    if (Session["_perId"] != null) Session.Remove("_perId");
                    if (Session["_perNombre"] != null) Session.Remove("_perNombre");
                    if (Session["_perEsAdministrador"] != null) Session.Remove("_perEsAdministrador");
                    if (Session["_PaginasPermitidas"] != null) Session.Remove("_PaginasPermitidas");
                    if (Session["_CambiarClave"] != null) Session.Remove("_CambiarClave");
                    if (Session["_Guid"] != null) Session.Remove("_aluId");
                    if (Session["_CambioPreviamenteUsuario"] != null) Session.Remove("_CambioPreviamenteUsuario");

                    #region Alto y Ancho de Logo
                    LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
                    string Logo_Alto = "150";
                    string Logo_Ancho = "150";
                    Logo_Alto = ocnParametro.ObtenerValor("Logo_Alto");
                    Logo_Ancho = ocnParametro.ObtenerValor("Logo_Ancho");
                    ima.Height = Unit.Pixel(Convert.ToInt32(Logo_Alto));
                    ima.Width = Unit.Pixel(Convert.ToInt32(Logo_Ancho));
                    #endregion

                    this.btnIngresar.Focus();
                }
            
            this.txtUsuario.Focus();
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            this.lblUsuarioNoValido.Visible = false;
            //TRAE CAMPOS DE TABLA USUARIO Y PERFIL
            dtUsuario = LiquidacionSueldos.Negocio.Seguridad.Autenticar(txtUsuario.Text, txtClave.Text);

            if (dtUsuario != null)
            {
                if (dtUsuario.Rows.Count != 0)
                {
                    if (dtUsuario.Rows.Count > 0)
                    {
                        Session.Add("_Autenticado", true);
                        Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                        Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                        Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                        Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                        Session.Add("_perId", dtUsuario.Rows[0]["perId"].ToString());
                        Session.Add("_perNombre", dtUsuario.Rows[0]["perNombre"].ToString());
                        //Session.Add("_perEsAdministrador", (dtUsuario.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false));
                        Session.Add("_perEsAdministrador", (dtUsuario.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false));
                        Session.Add("_esAdministrador", (dtUsuario.Rows[0]["perEsAdministrador"].ToString()));
                        Session.Add("_PaginasPermitidas", dtUsuario.Rows[0]["PaginasPermitidas"].ToString());
                        Session.Add("_Guid", Guid.NewGuid());
                        Session.Add("_CambioPreviamenteUsuario", "0");

                        #region Si Clave es igual a 1, obligo a cambiarla
                        ocnUsuario = new LiquidacionSueldos.Negocio.Usuario(Convert.ToInt32(Session["_usuId"]));
                        if (ocnUsuario.usuClave == "hJsvP2MyI0P93Fo8jajwfkA07k1eshClrZ254ztq7BjeqBg2qH+SJqRjbGx3iTsL00CPbR/iJbsJB8VWqBETVQ==")
                        {
                            Session.Add("_CambiarClave", "1");
                            Response.Redirect("UsuarioCambiarClave.aspx", false);
                        }
                        else
                        {
                            Session.Add("_CambiarClave", "0");
                            Response.Redirect("Sesion.aspx", false);
                        }
                        #endregion
                    }
                    else
                    {
                        UsuarioNoValido();
                    }
                }
                else
                {
                    UsuarioNoValido();
                }
            }
            else
            {
                UsuarioNoValido();
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void UsuarioNoValido()
    {
        try
        {
            this.lblUsuarioNoValido.Visible = true;

            this.txtUsuario.Text = "";
            this.txtClave.Text = "";
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }
}