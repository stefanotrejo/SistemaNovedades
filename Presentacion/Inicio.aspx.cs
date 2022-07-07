using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PaginasBasicas_Inicio : System.Web.UI.Page
{
    LiquidacionSueldos.Datos.Gestor ocdGestor = new LiquidacionSueldos.Datos.Gestor();
    LiquidacionSueldos.Negocio.Parametro ocnParametro = new LiquidacionSueldos.Negocio.Parametro();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //this.Master.TituloDelFormulario = "Menu Inicio";
                this.Master.TituloDelFormulario = "Menu Inicio";
                if (this.Session["_Autenticado"] == null) Response.Redirect("PaginasBasicas/Login.aspx", true);

                if (!Page.IsPostBack)
                {
                    if (Session["_CambiarClave"] != null)
                    {
                        if (Session["_CambiarClave"].ToString() == "0")
                        {
                            Inicializar();
                        }
                        else
                        {
                            Response.Redirect("UsuarioCambiarClave.aspx", false);
                        }
                    }
                }
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }

    private void Inicializar()
    {
        if (this.Session["_Autenticado"] == null)
        {
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            if (Session["_perId"] != null)
            {
                menCargar();
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }

    protected void menCargar()
    {
        try
        {
            dt = new DataTable();

            string Sql = "";

            #region Sql
            Sql = @"
declare @perId int
select @perId = " + this.Master.perId.ToString() + @"

set dateformat dmy

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
and men.menId in
(
select men1.menIdPadre
from PerfilMenu pme1, Menu men1
where 1 = 1
and men1.menActivo = 1
and men1.menId = pme1.menId
and pme1.perId = @perId
and men1.menIdPadre > 0
and men.menEsMenu = 1
)
order by menOrden

open cMenuPadre
fetch next from cMenuPadre into @menId, @menNombre, @menUrl
while @@FETCH_STATUS = 0
begin
	--Recorro los menu padres
	select @Cadena = @Cadena + '
	
<h3><p style=""color: #333333"">' + @menNombre + '</p></h3>
	<ol class=""breadcrumb"">'

    select @Cadena = @Cadena + '
		<li><a href=""' + Menu.menUrl + '"">' + Menu.menNombre + '</a> </li>'
    from Menu, PerfilMenu  
    where Menu.menIdPadre = @menId 
    and Menu.menActivo = 1
    and Menu.menId = PerfilMenu.menId
    and PerfilMenu.perId = @perId
    order by Menu.menNombre
   
	select @Cadena = @Cadena + '
	</ol><br />'
   
    fetch next from cMenuPadre into @menId, @menNombre, @menUrl
end
close cMenuPadre
deallocate cMenuPadre

select @Cadena as Cadena";
            #endregion

            dt = ocdGestor.EjecutarReaderSql(Sql);

            if (dt != null)
            {
                if (lblMenu.Text.Trim().Length != 0)
                {
                    lblMenu.Text += @"<hr class=""hr-line-dashed"" />";
                }

                lblMenu.Text += dt.Rows[0]["Cadena"].ToString().Trim();
            }
        }
        catch (Exception oError)
        {
            Response.Write("MESSAGE:<br>" + oError.Message + "<br><br>EXCEPTION:<br>" + oError.InnerException + "<br><br>TRACE:<br>" + oError.StackTrace + "<br><br>TARGET:<br>" + oError.TargetSite);
        }
    }
}