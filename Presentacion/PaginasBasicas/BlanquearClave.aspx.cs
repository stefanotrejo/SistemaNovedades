using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PaginasBasicas_BlanquearClave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string EmailRecuperacion = "";
        string Usuario = "";

        if (Request.QueryString["EmailRecuperacion"] != null) EmailRecuperacion = Request.QueryString["EmailRecuperacion"].ToString();
        if (Request.QueryString["Usuario"] != null) Usuario = Request.QueryString["Usuario"].ToString();

        DataTable dt = new DataTable();
        LiquidacionSueldos.Negocio.RecuperarClave ocnRecuperarClave = new LiquidacionSueldos.Negocio.RecuperarClave();
        dt = ocnRecuperarClave.ObtenerConValoresEncriptados(Usuario, EmailRecuperacion);

        if (dt.Rows.Count != 0)
        {
            LiquidacionSueldos.Negocio.Usuario ocnUsuario = new LiquidacionSueldos.Negocio.Usuario();
            ocnUsuario.BlanquearClaveUsuarioEmail(dt.Rows[0]["rclUsuario"].ToString(), dt.Rows[0]["rclEmailRecuperacion"].ToString());

            #region /*AQUI DEBO CARGAR VARIABLES DE SESION Y DIRECCION A CAMBIAR CLAVE*/
            DataTable dtUsuario = new DataTable();
            dtUsuario = ocnUsuario.ObtenerUnoUsuarioEmail(dt.Rows[0]["rclUsuario"].ToString(), dt.Rows[0]["rclEmailRecuperacion"].ToString());
            if (dtUsuario.Rows.Count != 0)
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
                if (Session["_aluId"] != null) Session.Remove("_aluId");

                Session.Add("_Autenticado", true);
                Session.Add("_usuId", dtUsuario.Rows[0]["usuId"].ToString());
                Session.Add("_usuNombreIngreso", dtUsuario.Rows[0]["usuNombreIngreso"].ToString());
                Session.Add("_usuApellido", dtUsuario.Rows[0]["usuApellido"].ToString());
                Session.Add("_usuNombre", dtUsuario.Rows[0]["usuNombre"].ToString());
                Session.Add("_perId", dtUsuario.Rows[0]["perId"].ToString());
                Session.Add("_perNombre", dtUsuario.Rows[0]["perNombre"].ToString());
                Session.Add("_perEsAdministrador", (dtUsuario.Rows[0]["perEsAdministrador"].ToString() == "1" ? true : false));
                Session.Add("_PaginasPermitidas", dtUsuario.Rows[0]["PaginasPermitidas"].ToString());
                Session.Add("_aluId", dtUsuario.Rows[0]["aluId"].ToString());
                Session.Add("_empId", dtUsuario.Rows[0]["empId"].ToString());
                Session.Add("_CambiarClave", "1");

                Response.Redirect("UsuarioCambiarClave.aspx", false);
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
            #endregion
        }
        else
        {
            Response.Redirect("Login.aspx", true);
        }        
    }
}