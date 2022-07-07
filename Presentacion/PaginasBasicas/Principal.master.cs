using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class PaginasBasicas_Principal : System.Web.UI.MasterPage
{
    DataTable dt;
    LiquidacionSueldos.Negocio.Menu ocnMenu = new LiquidacionSueldos.Negocio.Menu();
    LiquidacionSueldos.Datos.Gestor ocdGestor = new LiquidacionSueldos.Datos.Gestor();
    LiquidacionSueldos.Negocio.Usuario ocnUsuario = new LiquidacionSueldos.Negocio.Usuario();
    LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
    LiquidacionSueldos.Negocio.Ayuda ocnAyuda = new LiquidacionSueldos.Negocio.Ayuda();

    #region Propiedades
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

    public bool CambiarClave
    {
        get
        {
            if (Session["_CambiarClave"] != null)
            {
                return (Session["_CambiarClave"].ToString() == "1" ? true : false);
            }
            else
            {
                return false;
            }
        }

        set
        {
            if (Session["_CambiarClave"] != null)
            {
                Session["_CambiarClave"] = value;
            }
            else
            {
                Session.Add("_CambiarClave", value);
            }
        }
    }

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

    public string TituloDelFormulario
    {
        get
        {
            return this.lblTituloDelFormulario.Text.Trim();
        }
        set
        {
            this.lblTituloDelFormulario.Text = value;
        }
    }

    public bool Autenticado
    {
        get
        {
            if (Session["_Autenticado"] != null)
            {
                return (Session["_Autenticado"].ToString() == "True" ? true : false);
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

    public int usuId
    {
        get
        {
            if (Session["_usuId"] != null)
            {
                return (Session["_usuId"] != null ? Convert.ToInt32(Session["_usuId"]) : 0);
            }
            else
            {
                return 0;
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

    public int perId
    {
        get { if (Session["_perId"] != null) { return Convert.ToInt32(Session["_perId"]); } else { return 0; } }
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
        get { if (Session["_perEsAdministrador"] != null) { return (Session["_perEsAdministrador"].ToString() == "True" ? true : false); } else { return false; } }
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
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Page.Title = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
                lblClienteNombre.Text = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();
                lblClienteNombre1.Text = System.Configuration.ConfigurationSettings.AppSettings["ClienteNombre"].ToString();

                if (Session["_Autenticado"] == null) Response.Redirect("CerrarSesion.aspx", true);
                if (Session["_Autenticado"].ToString() == "0") Response.Redirect("CerrarSesion.aspx", true);
                if (Session["_perId"] == null) Response.Redirect("CerrarSesion.aspx", true);
                if (Session["_usuId"] == null || Session["_usuId"].ToString() == "0") Response.Redirect("CerrarSesion.aspx", true);

                this.lblUsuario.Text = this.usuNombre + " " + this.usuApellido;
                this.lblPerfil.Text = this.perNombre;

                if (!CambiarClave)
                {
                    /*EN CASO QUE SEA UN DISPOSITIVO MOVIL, NO CARGO EL MENU Y NO MUESTRO EL BOTON "MOSTRAR MENU"*/
                    string uAg = Request.ServerVariables["HTTP_USER_AGENT"];
                    Regex regEx = new Regex(@"android|iphone|ipad|ipod|blackberry|symbianos", RegexOptions.IgnoreCase);
                    bool isMobile = regEx.IsMatch(uAg);

                    if (!isMobile)
                    {
                        lblBotonBarraMenu.Text = @"<a class=""navbar-minimalize minimalize-styl-2 btn btn-primary"" href=""#""><i class=""fa fa-bars""></i></a>";

                        MenuCargar();
                    }
                }

                #region CARGAR AYUDA
                string ayuPaginaNombre = Page.AppRelativeVirtualPath;
                int ayuId = 0;

                dt = new DataTable();
                ocnAyuda = new LiquidacionSueldos.Negocio.Ayuda();
                dt = ocnAyuda.ObtenerxNombrePagina(ayuPaginaNombre, usuId);
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        ayuId = Convert.ToInt32(dt.Rows[0]["ayuId"]);
                        ocnAyuda = new LiquidacionSueldos.Negocio.Ayuda(ayuId);

                        lblayuId.Text = ayuId.ToString();
                        lblAyudaTitulo.Text = "Ayuda: " + TituloDelFormulario;
                        lblayuDescripcion.Text = ocnAyuda.ayuDescripcion;

                        //lblEditarAyuda.Text = @"<li><a href=""AyudaRegistracionCustom.aspx?Id=" + lblayuId.Text.Trim() + @""" target=""_blank""><i class=""fa fa-question-circle""></i></a></li>";

                        //if (this.perEsAdministrador || Session["_CambioPreviamenteUsuario"].ToString() == "1")
                        //{
                        //    lblEditarAyuda.Visible = true;
                        //}
                        //else
                        //{
                        //    lblEditarAyuda.Visible = false;
                        //}
                    }
                }
                #endregion
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void MenuCargar()
    {
        try
        {
            dt = new DataTable();

            #region Sql
            string Sql = @"
set dateformat dmy

declare @perId int
select @perId = " + this.perId.ToString() + @"

declare @Cadena varchar(max), @menId int, @menNombre varchar(1000), @menUrl varchar(1000)

select @Cadena = ''

declare cMenuPadre cursor for 
select men.menId, men.menNombre, men.menUrl
from Menu men, PerfilMenu pme
where 1 = 1
and men.menActivo = 1
and men.menId = pme.menId 
and pme.perId = @perId
and men.menIdPadre = 0
order by menOrden

open cMenuPadre
fetch next from cMenuPadre into @menId, @menNombre, @menUrl
while @@FETCH_STATUS = 0
begin
	--Recorro los menu padres
	select @Cadena = @Cadena + '<li><a href=""' + @menUrl + '""><i class=""fa fa-th-large""></i><span class=""nav-label"">' + @menNombre + '</span><span class=""fa arrow""></span></a>'

    select @Cadena = @Cadena + '
	<ul class=""nav nav-second-level""><li><a href=""' + Menu.menUrl + '"">' + Menu.menNombre + '</a></li></ul>'
    from Menu, PerfilMenu  
    where Menu.menIdPadre = @menId 
    and Menu.menActivo = 1
    and Menu.menId = PerfilMenu.menId
    and PerfilMenu.perId = @perId
    order by Menu.menNombre
   
	select @Cadena = @Cadena + '
</li>
'
   
    fetch next from cMenuPadre into @menId, @menNombre, @menUrl
end
close cMenuPadre
deallocate cMenuPadre

select @Cadena as Cadena";
            #endregion

            dt = ocdGestor.EjecutarReaderSql(Sql);

            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    repMenu.DataSource = dt;
                    repMenu.DataBind();
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }
}
