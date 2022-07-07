using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaginasBasicas_AyudaRegistracionCustom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("../PaginasGenerales/AyudaRegistracionCustom.aspx?Id=" + Request.QueryString["Id"].ToString(), true);
    }
}