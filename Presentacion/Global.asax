<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación
        //RoutingData(System.Web.Routing.RouteTable.Routes);
    }

    private void RountingData(System.Web.Routing.RouteCollection routecollection)
    {
        routecollection.MapPageRoute("login", "Login", "~/Login.aspx");
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación


    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión
        Session["Resultado"] = "";
        Session["Tipo"] = "";
       // Session["index"] = "";
        Session["Textbox"] = "";
        Session["Periodo1"] = "";
        Session["Periodo2"] = "";
        Session["PeriodoSeleccionado"] = "";
        Session["CambioClave"] = "";
        Session["CadenaAgenteDetalle"] = "";
    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.
        Session["Resultado"] = "";
        Session["Tipo"] = "";
        Session["index"] = "";
        Session["Textbox"] = "";
        Session["Periodo1"] = "";
        Session["Periodo2"] = "";
        Session["PeriodoSeleccionado"] = "";
        Session["CambioClave"] = "";
    }

</script>
