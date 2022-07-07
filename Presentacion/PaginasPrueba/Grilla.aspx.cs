using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class PaginasPrueba_Grilla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime FechaSeleccionada = DateTime.Now;
        DataTable Dt = new DataTable();

        LiquidacionSueldos.Negocio.Agente ocnAgente = new LiquidacionSueldos.Negocio.Agente();
        Dt = ocnAgente.ObtenerAgentesxFechaDeCarga(FechaSeleccionada);

        this.Grilla.DataSource = Dt;
        this.Grilla.PageIndex = 0;
        this.Grilla.DataBind();
    }
}