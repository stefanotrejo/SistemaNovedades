using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaginasBasicas_CerrarSesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("_PaginasPermitidas");
        Session.Remove("_Autenticado");
        Session.Remove("Resultado");
        //Session["Resultado"] = "";
        Session["Tipo"] = "";
        Session["index"] = "";
        Session["Textbox"] = "";
        Session["Periodo1"] = "";
        Session["Periodo2"] = "";
        Session["PeriodoSeleccionado"] = "";
        //Session.Clear();
        //Session.Abandon();

        Response.Redirect("Login.aspx", false);
        //Response.Redirect("PaginasBasicas/Login.aspx");
    }
}