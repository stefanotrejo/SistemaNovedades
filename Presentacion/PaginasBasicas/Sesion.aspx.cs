﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PaginasBasicas_Sesion : System.Web.UI.Page
{
    LiquidacionSueldos.Negocio.UsuarioConectado ocnUsuarioConectado = new LiquidacionSueldos.Negocio.UsuarioConectado();
    DataTable dt = new DataTable();

    #region Propiedades
    public string PaginasPermitidas
    {
        get { if (Session["_PaginasPermitidas"] != null) { return Session["_PaginasPermitidas"].ToString(); } else { return ""; } }
        set
        {
            if (Session["_PaginasPermitidas"] != null)
            {
                Session["_PaginasPermitidas"] = value;
            }
            else
            {
                Session.Add("_PaginasPermitidas", value);
            }
        }
    }

    public bool Autenticado
    {
        get
        {
            if (Session["_Autenticado"] != null)
            {
                return (Session["_Autenticado"].ToString() == "1" ? true : false);
            }
            else
            {
                return false;
            }
        }

        set
        {
            if (Session["_Autenticado"] != null)
            {
                Session["_Autenticado"] = value;
            }
            else
            {
                Session.Add("_Autenticado", value);
            }
        }
    }

    public string usuNombreIngreso
    {
        get { if (Session["_usuNombreIngreso"] != null) { return Session["_usuNombreIngreso"].ToString(); } else { return ""; } }
        set
        {
            if (Session["_usuNombreIngreso"] != null)
            {
                Session["_usuNombreIngreso"] = value;
            }
            else
            {
                Session.Add("_usuNombreIngreso", value);
            }
        }
    }

    public string usuApellido
    {
        get { if (Session["_usuApellido"] != null) { return Session["_usuApellido"].ToString(); } else { return ""; } }
        set
        {
            if (Session["_usuApellido"] != null)
            {
                Session["_usuApellido"] = value;
            }
            else
            {
                Session.Add("_usuApellido", value);
            }
        }
    }

    public string usuNombre
    {
        get { if (Session["_usuNombre"] != null) { return Session["_usuNombre"].ToString(); } else { return ""; } }
        set
        {
            if (Session["_usuNombre"] != null)
            {
                Session["_usuNombre"] = value;
            }
            else
            {
                Session.Add("_usuNombre", value);
            }
        }
    }

    public string usuId
    {
        get
        {
            if (Session["_usuId"] != null)
            {
                return (Session["_usuId"] != null ? Session["_usuId"].ToString() : "0");
            }
            else
            {
                return "";
            }
        }
        set
        {
            if (Session["_usuId"] != null)
            {
                Session["_usuId"] = value;
            }
            else
            {
                Session.Add("_usuId", value);
            }
        }
    }

    public string perNombre
    {
        get { if (Session["_perNombre"] != null) { return Session["_perNombre"].ToString(); } else { return ""; } }
        set
        {
            if (Session["_perNombre"] != null)
            {
                Session["_perNombre"] = value;
            }
            else
            {
                Session.Add("_perNombre", value);
            }
        }
    }

    public string perId
    {
        get { if (Session["_perId"] != null) { return Session["_perId"].ToString(); } else { return ""; } }
        set
        {
            if (Session["_perId"] != null)
            {
                Session["_perId"] = value;
            }
            else
            {
                Session.Add("_perId", value);
            }
        }
    }

    public bool perEsAdministrador
    {
        get { if (Session["_perEsAdministrador"] != null) { return (Session["_perEsAdministrador"].ToString() == "1" ? true : false); } else { return false; } }
        set
        {
            if (Session["_perEsAdministrador"] != null)
            {
                Session["_perEsAdministrador"] = value;
            }
            else
            {
                Session.Add("_perEsAdministrador", value);
            }
        }
    }

    public bool CambioPreviamenteUsuario
    {
        get
        {
            if (Session["_CambioPreviamenteUsuario"] != null)
            {
                return Session["_CambioPreviamenteUsuario"].ToString() == "1" ? true : false;
            }
            else
            {
                return false;
            }
        }
        set
        {
            if (Session["_CambioPreviamenteUsuario"] != null)
            {
                Session["_CambioPreviamenteUsuario"] = value;
            }
            else
            {
                Session.Add("_CambioPreviamenteUsuario", value);
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Title = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();

            if (this.Session["_Autenticado"] == null) Response.Redirect("Login.aspx", true);

            Session["Resultado"] = "";
            Session["Tipo"] = "";
            Session["index"] = "";
            Session["Textbox"] = "";
            Session["Periodo1"] = "";
            Session["Periodo2"] = "";
            Session["PeriodoSeleccionado"] = "";
            Session["EstadoLiquidacion"] = "";

            // Novedades Nuevo
            Session["Id"] = "";
            Session["periodo"] = "";
            Session["textBox"] = "";
            Session["radioSeleccionado"] = "";
            Session["pageIndex"] = "";
            Session["CambioClave"] = "";

            // Novedades Modificar
            Session["Actualizado"] = "";

            // Novedades Consulta
            Session["textBox"] = "";
            Session["liqId"] = "";
            Session["radioSeleccionado"] = "";
            Session["mesAnioLiq"] = "";

            if (!Page.IsPostBack)
            {
                if (Session["_usuNombreIngreso"] != null)
                {
                    if (Session["_perId"] != null)
                    {
                    }

                    tim_Tick(sender, e);
                }
                else
                {
                    Response.Redirect("Login.aspx", true);
                }

                #region Alto y Ancho de Logo
                LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
                string Logo_Alto = "150";
                string Logo_Ancho = "150";
                Logo_Alto = ocnParametro.ObtenerValor("Logo_Alto");
                Logo_Ancho = ocnParametro.ObtenerValor("Logo_Ancho");
                ima.Height = Unit.Pixel(Convert.ToInt32(Logo_Alto));
                ima.Width = Unit.Pixel(Convert.ToInt32(Logo_Ancho));
                #endregion

                if (Session["_Guid"] != null) lblGuid.Text = Session["_Guid"].ToString();
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    protected void tim_Tick(object sender, EventArgs e)
    {
        try
        {
            if (IsSessionTimedOut())
            {
                Session.Add("_Autenticado", this.Autenticado);
                Session.Add("_usuNombreIngreso", this.usuNombreIngreso);
                Session.Add("_usuApellido", this.usuApellido);
                Session.Add("_usuNombre", this.usuNombre);
                Session.Add("_usuId", this.usuId);
                Session.Add("_perId", this.perId);
                Session.Add("_perNombre", this.perNombre);
                Session.Add("_perEsAdministrador", this.perEsAdministrador);
                Session.Add("_PaginasPermitidas", this.PaginasPermitidas);
                Session.Add("_CambioPreviamenteUsuario", this.CambioPreviamenteUsuario);

                Response.Redirect("Login.aspx", true);
            }

            #region Seguridad para conectar y desconectar usuarios cuando cambia de clave
            dt = ocnUsuarioConectado.ObtenerConectar(Convert.ToInt32(this.usuId), this.lblGuid.Text, FuncionesUtiles.ObtenerIpPublica());
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0]["Desconectar"].ToString() == "1")
                    {
                        Response.Redirect("CerrarSesion.aspx", true);
                    }
                }
            }
            #endregion
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    public static bool IsSessionTimedOut()
    {
        HttpContext ctx = HttpContext.Current;
        if (ctx == null)
            throw new Exception("Este método sólo se puede usar en una aplicación Web");

        //Comprobamos que haya sesión en primer lugar 
        //(por ejemplo si por ejemplo EnableSessionState=false)
        if (ctx.Session == null)
            return false;   //Si no hay sesión, no puede caducar
        //Se comprueba si se ha generado una nueva sesión en esta petición
        if (!ctx.Session.IsNewSession)
            return false;   //Si no es una nueva sesión es que no ha caducado

        HttpCookie objCookie = ctx.Request.Cookies["ASP.NET_SessionId"];
        //Esto en teoría es imposible que pase porque si hay una 
        //nueva sesión debería existir la cookie, pero lo compruebo porque
        //IsNewSession puede dar True sin ser cierto (más en el post)
        if (objCookie == null)
            return false;

        //Si hay un valor en la cookie es que hay un valor de sesión previo, pero como la sesión 
        //es nueva no debería estar, por lo que deducimos que la sesión anterior ha caducado
        if (!string.IsNullOrEmpty(objCookie.Value))
            return true;
        else
            return false;
    }

}